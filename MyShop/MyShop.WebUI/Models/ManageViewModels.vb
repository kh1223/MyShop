Imports System.ComponentModel.DataAnnotations
Imports Microsoft.AspNet.Identity
Imports Microsoft.Owin.Security

Public Class IndexViewModel
    Public Property HasPassword As Boolean
    Public Property Logins As IList(Of UserLoginInfo)
    Public Property PhoneNumber As String
    Public Property TwoFactor As Boolean
    Public Property BrowserRemembered As Boolean
End Class

Public Class ManageLoginsViewModel
    Public Property CurrentLogins As IList(Of UserLoginInfo)
    Public Property OtherLogins As IList(Of AuthenticationDescription)
End Class

Public Class FactorViewModel
    Public Property Purpose As String
End Class

Public Class SetPasswordViewModel
    <Required>
    <StringLength(100, ErrorMessage:="{0}은(는) {2}자 이상이어야 합니다.", MinimumLength:=6)>
    <DataType(DataType.Password)>
    <Display(Name:="새 암호")>
    Public Property NewPassword As String

    <DataType(DataType.Password)>
    <Display(Name:="새 암호 확인")>
    <Compare("NewPassword", ErrorMessage:="새 암호와 확인 암호가 일치하지 않습니다.")>
    Public Property ConfirmPassword As String
End Class

Public Class ChangePasswordViewModel
    <Required>
    <DataType(DataType.Password)>
    <Display(Name:="현재 암호")>
    Public Property OldPassword As String

    <Required>
    <StringLength(100, ErrorMessage:="{0}은(는) {2}자 이상이어야 합니다.", MinimumLength:=6)>
    <DataType(DataType.Password)>
    <Display(Name:="새 암호")>
    Public Property NewPassword As String

    <DataType(DataType.Password)>
    <Display(Name:="새 암호 확인")>
    <Compare("NewPassword", ErrorMessage:="새 암호와 확인 암호가 일치하지 않습니다.")>
    Public Property ConfirmPassword As String
End Class

Public Class AddPhoneNumberViewModel
    <Required>
    <Phone>
    <Display(Name:="전화 번호")>
    Public Property Number As String
End Class

Public Class VerifyPhoneNumberViewModel
    <Required>
    <Display(Name:="코드")>
    Public Property Code As String

    <Required>
    <Phone>
    <Display(Name:="전화 번호")>
    Public Property PhoneNumber As String
End Class

Public Class ConfigureTwoFactorViewModel
    Public Property SelectedProvider As String
    Public Property Providers As ICollection(Of System.Web.Mvc.SelectListItem)
End Class