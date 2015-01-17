<%@ Page Language="C#" Async="true" AutoEventWireup="true" MasterPageFile="~/GitHubViewSite.Master" CodeBehind="Default.aspx.cs" Inherits="WebAppGitHubView.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2"
    ContentPlaceHolderID="default" runat="Server">
    <div class="staticData">
<%--        <asp:Login ID="Login1" ViewStateMode="Disabled" RenderOuterTable="false" runat="server">
            <LayoutTemplate>
                <p class="validation-summary-errors">
                    <asp:Literal runat="server" ID="FailureText" />
                </p>
                <fieldset>
                    <legend><h1>Login GitHub</h1></legend>
                    <ol>
                        <li>
                            <asp:Label runat="server" AssociatedControlID="UserName">Имя пользователя</asp:Label>
                            <asp:TextBox runat="server" ID="UserName" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName" EnableClientScript="true" CssClass="field-validation-error" ErrorMessage="Поле имени пользователя заполнять обязательно." />
                        </li>
                        <li>
                            <asp:Label runat="server" AssociatedControlID="Password">Пароль</asp:Label>
                            <asp:TextBox runat="server" ID="Password" TextMode="Password" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" EnableClientScript="true" CssClass="field-validation-error" ErrorMessage="Поле пароля заполнять обязательно." />
                        </li>
                    </ol>
                    <asp:Button runat="server" CommandName="Login" Text="Submit"  OnClick="text_Click"/>
                </fieldset>
            </LayoutTemplate>
        </asp:Login>--%>
        <h1 style="text-align: center">Login GitHub</h1>
        <input type="text" runat="server" id="text" name="" style="width: 150px;" />
        <input type="password" runat="server" id="password" name="" style="width: 150px" />
        <asp:Button ID="buttonSubmit" runat="server" Text="Submit"
            OnClick="text_Click"></asp:Button>
        <div class="image">
            <asp:Image ID="htmlImg" runat="server" Visible="false" />
        </div>
    </div>

    <script type="text/javascript">
        function cell_Click(th) {
            var x = th.id;
            var tr = th.parentNode.parentNode,
                nameRep = tr.getElementsByTagName("td")[1].innerHTML;
            var user = document.getElementById("default_text").value;
            //alert(x + "\n" + nameRep + "\n" + user);
            document.location.href = "Second.aspx" + "?name=" + nameRep + "&user=" + user;
        }
    </script>
    <div class="dynamicData">

        <asp:Table ID="tableRepos" runat="server" Visible="false">
        </asp:Table>
    </div>

</asp:Content>
