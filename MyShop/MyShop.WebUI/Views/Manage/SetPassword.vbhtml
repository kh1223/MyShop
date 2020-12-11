@ModelType SetPasswordViewModel
@Code
    ViewBag.Title = "암호 만들기"
End Code

<h2>@ViewBag.Title.</h2>
<p class="text-info">
    이 사이트에 대한 로컬 사용자 이름/암호가 없습니다. 외부 로그인 없이
    로그인할 수 있도록 로컬 계정을 추가합니다.
</p>

@Using Html.BeginForm("SetPassword", "Manage", FormMethod.Post, New With { .class = "form-horizontal", .role = "form" })
    @Html.AntiForgeryToken()
    @<text>
    <h4>로컬 로그인 만들기</h4>
    <hr />
    @Html.ValidationSummary("", New With { .class = "text-danger" })
    <div class="form-group">
        @Html.LabelFor(Function(m) m.NewPassword, New With {.class = "col-md-2 control-label"})
        <div class="col-md-10">
            @Html.PasswordFor(Function(m) m.NewPassword, New With {.class = "form-control"})
        </div>
    </div>
    <div class="form-group">
        @Html.LabelFor(Function(m) m.ConfirmPassword, New With { .class = "col-md-2 control-label" })
        <div class="col-md-10">
            @Html.PasswordFor(Function(m) m.ConfirmPassword, New With { .class = "form-control" })
        </div>
    </div>
    <div class="form-group">
        <div class="col-md-offset-2 col-md-10">
            <input type="submit" value="암호 설정" class="btn btn-default" />
        </div>
    </div>
    </text>
End Using
@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section