@ModelType ExternalLoginConfirmationViewModel
@Code
    ViewBag.Title = "등록"
End Code

<h2>@ViewBag.Title.</h2>
<h3>@ViewBag.LoginProvider 계정을 연결합니다.</h3>

@Using Html.BeginForm("ExternalLoginConfirmation", "Account", New With { .ReturnUrl = ViewBag.ReturnUrl }, FormMethod.Post, New With {.class = "form-horizontal", .role = "form"})
    @Html.AntiForgeryToken()

    @<text>
    <h4>연결 양식</h4>
    <hr />
    @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
    <p class="text-info">
        사용자가 <strong>@ViewBag.LoginProvider</strong>(으)로 인증되었습니다.
        아래에 이 사이트의 사용자 이름을 입력하고 [등록] 단추를 클릭하여 로그인을
        마칩니다.
    </p>
    <div class="form-group">
        @Html.LabelFor(Function(m) m.Email, New With {.class = "col-md-2 control-label"})
        <div class="col-md-10">
            @Html.TextBoxFor(Function(m) m.Email, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(m) m.Email, "", New With {.class = "text-danger"})
        </div>
    </div>
    <div class="form-group">
        <div class="col-md-offset-2 col-md-10">
            <input type="submit" class="btn btn-default" value="등록" />
        </div>
    </div>
    </text>
End Using

@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section
