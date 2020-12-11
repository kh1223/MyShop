@ModelType IndexViewModel
@Code
    ViewBag.Title = "관리"
End Code

<h2>@ViewBag.Title.</h2>

<p class="text-success">@ViewBag.StatusMessage</p>
<div>
    <h4>계정 설정 변경</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>암호:</dt>
        <dd>
            [
            @If Model.HasPassword Then
                @Html.ActionLink("암호 변경", "ChangePassword")
            Else
                @Html.ActionLink("만들기", "SetPassword")
            End If
            ]
        </dd>
        <dt>외부 로그인:</dt>
        <dd>
            @Model.Logins.Count [
            @Html.ActionLink("관리", "ManageLogins") ]
        </dd>
        @*
            2단계 인증 시스템에서는 두 번째 확인 단계로 전화 번호를 사용할 수 있습니다.
             
             SMS를 사용하여 2단계 인증을 지원하도록 이 ASP.NET 애플리케이션을 설정하는 방법에 대한
                자세한 내용은 <a href="https://go.microsoft.com/fwlink/?LinkId=403804">이 문서</a>를 참조하세요.
             
             2단계 인증을 설정한 후에는 다음 블록의 주석 처리를 제거하세요.
        *@
        @* 
            <dt>전화 번호:</dt>
            <dd>
                @(If(Model.PhoneNumber, "None"))
                @If (Model.PhoneNumber <> Nothing) Then
                    @<br />
                    @<text>[&nbsp;&nbsp;@Html.ActionLink("Change", "AddPhoneNumber")&nbsp;&nbsp;]</text>
                    @Using Html.BeginForm("RemovePhoneNumber", "Manage", FormMethod.Post, New With {.class = "form-horizontal", .role = "form"})
                        @Html.AntiForgeryToken
                        @<text>[<input type="submit" value="제거" class="btn-link" />]</text>
                    End Using
                Else
                    @<text>[&nbsp;&nbsp;@Html.ActionLink("Add", "AddPhoneNumber") &nbsp;&nbsp;]</text>
                End If
            </dd>
        *@
        <dt>2단계 인증:</dt>
        <dd>
            <p>
                구성된 2단계 인증 공급자가 없습니다. 2단계 인증을 지원하도록 이 ASP.NET 애플리케이션을 설정하는 방법에 대한 자세한 내용은
                <a href="https://go.microsoft.com/fwlink/?LinkId=403804">이 문서</a>를 참조하세요.
            </p>
            @*
                @If Model.TwoFactor Then
                    @Using Html.BeginForm("DisableTwoFactorAuthentication", "Manage", FormMethod.Post, New With { .class = "form-horizontal", .role = "form" })
                      @Html.AntiForgeryToken()
                      @<text>
                      사용
                      <input type="submit" value="사용 안 함" class="btn btn-link" />
                      </text>
                    End Using
                Else
                    @Using Html.BeginForm("EnableTwoFactorAuthentication", "Manage", FormMethod.Post, New With { .class = "form-horizontal", .role = "form" })
                      @Html.AntiForgeryToken()
                      @<text>
                      사용 안 함
                      <input type="submit" value="사용" class="btn btn-link" />
                      </text>
                    End Using
                End If
	     *@
        </dd>
    </dl>
</div>
