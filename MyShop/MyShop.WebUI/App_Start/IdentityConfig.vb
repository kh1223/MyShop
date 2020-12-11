Imports System.Threading.Tasks
Imports System.Security.Claims
Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework
Imports Microsoft.AspNet.Identity.Owin
Imports Microsoft.Owin
Imports Microsoft.Owin.Security

Public Class EmailService
    Implements IIdentityMessageService

    Public Function SendAsync(message As IdentityMessage) As Task Implements IIdentityMessageService.SendAsync
        ' 전자 메일을 보낼 전자 메일 서비스를 여기에 플러그 인으로 추가합니다.
        Return Task.FromResult(0)
    End Function
End Class

Public Class SmsService
    Implements IIdentityMessageService

    Public Function SendAsync(message As IdentityMessage) As Task Implements IIdentityMessageService.SendAsync
        ' 텍스트 메시지를 보낼 SMS 서비스를 여기에 플러그 인으로 추가합니다.
        Return Task.FromResult(0)
    End Function
End Class

' 이 애플리케이션에서 사용되는 애플리케이션 사용자 관리자를 구성합니다. UserManager는 ASP.NET Identity에서 정의하며 애플리케이션에서 사용됩니다.
Public Class ApplicationUserManager
    Inherits UserManager(Of ApplicationUser)

    Public Sub New(store As IUserStore(Of ApplicationUser))
        MyBase.New(store)
    End Sub

    Public Shared Function Create(options As IdentityFactoryOptions(Of ApplicationUserManager), context As IOwinContext) As ApplicationUserManager
        Dim manager = New ApplicationUserManager(New UserStore(Of ApplicationUser)(context.Get(Of ApplicationDbContext)()))

        ' 사용자 이름에 대한 유효성 검사 논리 구성
        manager.UserValidator = New UserValidator(Of ApplicationUser)(manager) With {
            .AllowOnlyAlphanumericUserNames = False,
            .RequireUniqueEmail = True
        }

        ' 암호에 대한 유효성 검사 논리 구성
        manager.PasswordValidator = New PasswordValidator With {
            .RequiredLength = 6,
            .RequireNonLetterOrDigit = True,
            .RequireDigit = True,
            .RequireLowercase = True,
            .RequireUppercase = True
        }

        ' 사용자 잠금 기본값 구성
        manager.UserLockoutEnabledByDefault = True
        manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5)
        manager.MaxFailedAccessAttemptsBeforeLockout = 5

        ' 2단계 인증 공급자를 등록합니다. 이 애플리케이션은 사용자 확인 코드를 받는 단계에서 전화 및 전자 메일을 사용합니다.
        ' 공급자 및 플러그 인을 여기에 쓸 수 있습니다.
        manager.RegisterTwoFactorProvider("전화 코드", New PhoneNumberTokenProvider(Of ApplicationUser) With {
                                          .MessageFormat = "보안 코드는 {0}입니다."
                                      })
        manager.RegisterTwoFactorProvider("전자 메일 코드", New EmailTokenProvider(Of ApplicationUser) With {
                                          .Subject = "보안 코드",
                                          .BodyFormat = "보안 코드는 {0}입니다."
                                          })
        manager.EmailService = New EmailService()
        manager.SmsService = New SmsService()
        Dim dataProtectionProvider = options.DataProtectionProvider
        If (dataProtectionProvider IsNot Nothing) Then
            manager.UserTokenProvider = New DataProtectorTokenProvider(Of ApplicationUser)(dataProtectionProvider.Create("ASP.NET Identity"))
        End If

        Return manager
    End Function

End Class

' 이 애플리케이션에서 사용되는 애플리케이션 로그인 관리자를 구성합니다.
Public Class ApplicationSignInManager
    Inherits SignInManager(Of ApplicationUser, String)
    Public Sub New(userManager As ApplicationUserManager, authenticationManager As IAuthenticationManager)
        MyBase.New(userManager, authenticationManager)
    End Sub

    Public Overrides Function CreateUserIdentityAsync(user As ApplicationUser) As Task(Of ClaimsIdentity)
        Return user.GenerateUserIdentityAsync(DirectCast(UserManager, ApplicationUserManager))
    End Function

    Public Shared Function Create(options As IdentityFactoryOptions(Of ApplicationSignInManager), context As IOwinContext) As ApplicationSignInManager
        Return New ApplicationSignInManager(context.GetUserManager(Of ApplicationUserManager)(), context.Authentication)
    End Function
End Class
