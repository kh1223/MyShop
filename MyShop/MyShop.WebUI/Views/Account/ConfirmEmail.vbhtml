@Code
    ViewBag.Title = "전자 메일 확인"
End Code

<h2>@ViewBag.Title.</h2>
<div>
    <p>
        전자 메일을 확인해 주셔서 감사합니다. @Html.ActionLink("로그인하려면 여기를 클릭하십시오.", "Login", "Account", routeValues:=Nothing, htmlAttributes:=New With {Key .id = "loginLink"})
    </p>
</div>
