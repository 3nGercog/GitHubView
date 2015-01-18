<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/GitHubViewSite.Master" CodeBehind="List.aspx.cs" ClientIDMode="Static" Inherits="WebAppGitHubView.List" %>

<asp:Content ID="ContentListHead" runat="server" ContentPlaceHolderID="head">
</asp:Content>
<asp:Content ID="ContentListBody" ContentPlaceHolderID="default" runat="server" >
    <div class="listVoid">
    </div>
    <div class="listButton">
        <ul class="bt">
            <li>
                <input id="btAdd" class="list_button_inline" type="button" runat="server" value="ADD" />
            </li>
            <li>
                <input id="btRemove" class="list_button_inline" type="button" runat="server" value="REMOVE" />
            </li>
            <li>
                <input id="btEdit" class="list_button_inline" type="button" runat="server" value="EDIT" />
            </li>
        </ul>
    </div>
    <div class="list_text">
        <input type="text" id="tb_url" runat="server" />
    </div>
    <div class="listVoid"></div>
    <div>

    </div>
</asp:Content>
