﻿@Code
    ViewBag.Title = "암호 확인 재설정"
End Code

<hgroup class="title">
    <h1>@ViewBag.Title.</h1>
</hgroup>
<div>
    <p>
        암호가 재설정되었습니다. @Html.ActionLink("로그인하려면 여기를 클릭하십시오.", "Login", "Account", routeValues:=Nothing, htmlAttributes:=New With {Key .id = "loginLink"})
    </p>
</div>
