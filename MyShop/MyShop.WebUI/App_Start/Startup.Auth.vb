Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.Owin
Imports Microsoft.Owin
Imports Microsoft.Owin.Security.Cookies
Imports Microsoft.Owin.Security.Google
Imports Owin

Partial Public Class Startup
    ' 인증 구성에 대한 자세한 내용은 https://go.microsoft.com/fwlink/?LinkId=301864를 참조하세요.
    Public Sub ConfigureAuth(app As IAppBuilder)
        ' 요청당 단일 인스턴스를 사용하도록 db 컨텍스트, 사용자 관리자 및 로그인 관리자 구성
        app.CreatePerOwinContext(AddressOf ApplicationDbContext.Create)
        app.CreatePerOwinContext(Of ApplicationUserManager)(AddressOf ApplicationUserManager.Create)
        app.CreatePerOwinContext(Of ApplicationSignInManager)(AddressOf ApplicationSignInManager.Create)

        ' 애플리케이션이 쿠키를 사용하여 로그인된 사용자에 대한 정보를 저장할 수 있도록 합니다.
        ' 또한 쿠키를 사용하여 타사 로그인 공급자를 통한 사용자 로그인 관련 정보를 일시적으로 저장하도록 설정합니다.
        ' 쿠키에 서명 구성
        ' OnValidateIdentity는 사용자가 로그인할 때 애플리케이션에서 보안 스탬프를 확인하도록 설정합니다.
        ' 암호를 변경하거나 계정에 외부 로그인을 추가할 때 사용되는 보안 기능입니다.
        app.UseCookieAuthentication(New CookieAuthenticationOptions() With {
            .AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
            .Provider = New CookieAuthenticationProvider() With {
                .OnValidateIdentity = SecurityStampValidator.OnValidateIdentity(Of ApplicationUserManager, ApplicationUser)(
                    validateInterval:=TimeSpan.FromMinutes(30),
                    regenerateIdentity:=Function(manager, user) user.GenerateUserIdentityAsync(manager))},
            .LoginPath = New PathString("/Account/Login")})

        app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie)

        ' 애플리케이션에서 2단계 인증 프로세스의 두 번째 단계를 확인할 때 사용자 정보를 일시적으로 저장하도록 설정합니다.
        app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5))

        ' 애플리케이션에서 전화나 전자 메일 같은 두 번째 로그인 확인 단계를 기억하도록 설정합니다.
        ' 이 옵션을 선택하면 사용자가 로그인한 디바이스에서 로그인 프로세스의 두 번째 확인 단계를 기억합니다.
        ' 로그인할 때의 [사용자 이름 및 암호 저장] 옵션과 유사합니다.
        app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie)

        ' 타사 로그인 공급자로 로그인할 수 있으려면 다음 줄의 주석 처리를 제거하십시오.
        'app.UseMicrosoftAccountAuthentication(
        '    clientId:="",
        '    clientSecret:="")

        'app.UseTwitterAuthentication(
        '   consumerKey:="",
        '   consumerSecret:="")

        'app.UseFacebookAuthentication(
        '   appId:="",
        '   appSecret:="")

        'app.UseGoogleAuthentication(New GoogleOAuth2AuthenticationOptions() With {
        '   .ClientId = "",
        '   .ClientSecret = ""})
    End Sub
End Class
