<%@ Page Language="C#" EnableSessionState="ReadOnly" MasterPageFile="~/GitHubViewSite.Master" AutoEventWireup="true" Async="true" CodeBehind="Second.aspx.cs" Inherits="WebAppGitHubView.Second" %>
<%@ PreviousPageType VirtualPath="~/Default.aspx" %>

<asp:Content ID="Content3" ContentPlaceHolderID="head" Runat="Server"></asp:Content>
<asp:Content ID="Content4" 
  ContentPlaceHolderID="default" Runat="Server">
    <div id="commitInfo" runat="server">
        <h1 id="h1" style="text-align:center; color:blue" runat="server"></h1>
<%--        <asp:BulletedList ID="BulletedList1" BorderStyle="Dashed" BorderColor="Window" runat="server">
            <asp:ListItem Text="text" Selected="True" />
        </asp:BulletedList>--%>
    </div>
</asp:Content>
