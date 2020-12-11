Imports System.ComponentModel.DataAnnotations

Public Class ExternalLoginConfirmationViewModel
    <Required>
    <Display(Name:="전자 메일")>
    Public Property Email As String
End Class

Public Class ExternalLoginListViewModel
    Public Property ReturnUrl As String
End Class

Public Class SendCodeViewModel
    Public Property SelectedProvider As String
    Public Property Providers As ICollection(Of System.Web.Mvc.SelectListItem)
    Public Property ReturnUrl As String
    Public Property RememberMe As Boolean
End Class

Public Class VerifyCodeViewModel
    <Required>
    Public Property Provider As String
    
    <Required>
    <Display(Name:="코드")>
    Public Property Code As String
    
    Public Property ReturnUrl As String
    
    <Display(Name:="이 브라우저 기억")>
    Public Property RememberBrowser As Boolean

    Public Property RememberMe As Boolean
End Class

Public Class ForgotViewModel
    <Required>
    <Display(Name:="전자 메일")>
    Public Property Email As String
End Class

Public Class LoginViewModel
    <Required>
    <Display(Name:="전자 메일")>
    <EmailAddress>
    Public Property Email As String

    <Required>
    <DataType(DataType.Password)>
    <Display(Name:="암호")>
    Public Property Password As String

    <Display(Name:="사용자 이름 및 암호 저장")>
    Public Property RememberMe As Boolean
End Class

Public Class RegisterViewModel
    <Required>
    <EmailAddress>
    <Display(Name:="전자 메일")>
    Public Property Email As String

    <Required>
    <StringLength(100, ErrorMessage:="{0}은(는) {2}자 이상이어야 합니다.", MinimumLength:=6)>
    <DataType(DataType.Password)>
    <Display(Name:="암호")>
    Public Property Password As String

    <DataType(DataType.Password)>
    <Display(Name:="암호 확인")>
    <Compare("Password", ErrorMessage:="암호와 확인 암호가 일치하지 않습니다.")>
    Public Property ConfirmPassword As String
End Class

Public Class ResetPasswordViewModel
    <Required>
    <EmailAddress>
    <Display(Name:="전자 메일")>
    Public Property Email() As String

    <Required>
    <StringLength(100, ErrorMessage:="{0}은(는) {2}자 이상이어야 합니다.", MinimumLength:=6)>
    <DataType(DataType.Password)>
    <Display(Name:="암호")>
    Public Property Password() As String

    <DataType(DataType.Password)>
    <Display(Name:="암호 확인")>
    <Compare("Password", ErrorMessage:="암호와 확인 암호가 일치하지 않습니다.")>
    Public Property ConfirmPassword() As String

    Public Property Code() As String
End Class

Public Class ForgotPasswordViewModel
    <Required>
    <EmailAddress>
    <Display(Name:="전자 메일")>
    Public Property Email() As String
End Class
