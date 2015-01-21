<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/GitHubViewSite.Master" CodeBehind="List.aspx.cs" ClientIDMode="Static" Inherits="WebAppGitHubView.List" %>

<asp:Content ID="ContentListHead" runat="server" ContentPlaceHolderID="head">
    <script src="Scripts/uri.js"></script>
</asp:Content>

<asp:Content ID="ContentListBody" ContentPlaceHolderID="default" runat="server" >
    <div class="listVoid">
    </div>
    <div class="listButton">
        <ul class="bt">
            <li>
                <%--<input id="btAdd" class="list_button_inline" type="button" runat="server" value="ADD" onclick="btAdd_Click"/>--%>
                <asp:Button ID="btAdd" CssClass="list_button_inline" Text="ADD" runat="server" OnClick="btAdd_Click" />
            </li>
            <li>
                <%--<input id="btRemove" class="list_button_inline" type="button" runat="server" value="REMOVE" />--%>
                <asp:Button ID="btRemove" CssClass="list_button_inline" Text="REMOVE" runat="server" OnClick="btRemove_Click" />
            </li>
            <li>
                <%--<input id="btEdit" class="list_button_inline" type="button" runat="server" value="EDIT" />--%>
                <asp:Button ID="btEdit" CssClass="list_button_inline" Text="EDIT" runat="server" OnClick="btEdit_Click" />
            </li>
            <li>
                <input id="btHelp" class="list_button_inline" type="button" runat="server" value="HELP" onclick="help_Click()" />
                <%--<asp:Button ID="btHelp" CssClass="list_button_inline" Text="HELP" runat="server" OnClick="btHelp_Click"/>--%>
            </li>
        </ul>
    </div>
    <div class="list_text">
        <input type="text" id="tb_url" runat="server" />
        <br />
        <asp:Label ID="message" CssClass="validation_error" Text="" runat="server" />
        <br />
        <asp:RegularExpressionValidator CssClass="validation" ID="regUrl" ErrorMessage="This expression does not validate."
             ControlToValidate="tb_url" ValidationExpression="^(ht|f)tp(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&amp;%\$#_]*)?$" runat="server" />
    </div>
    <div class="listVoid"></div>
    <script type="text/javascript">

        function help_Click() {
            document.location.href = "Help.aspx";
        }
        function cell_list_Click(th) {
            var id = th.getElementsByTagName("td")[0].innerHTML;
            var url = th.getElementsByTagName("td")[1].innerHTML;
            
            var textB = document.getElementById("tb_url");
            var hdF = document.getElementById("hdField").valueOf();
            hdF.value = id;
            var parser = document.createElement('a');
            //alert(id + "\n" + url);
            parser.href = url;

            <%--<% HttpUtility.JavaScriptStringEncode(url); %>
            var encode = encodeURIComponent(url);
            alert(encode);
            var decode = decodeURIComponent(encode);
            alert(decode);--%>

            if (textB.disabled) {
                document.location.href = "Show.aspx" + "?pn=" + parser.pathname;
            }
            else {
                textB.value = url;
            }
        }
        

    </script>
    <div class="list_table_urls">
        <asp:SqlDataSource ID="SqlDataSourceUrl" runat="server" ></asp:SqlDataSource>
        <asp:GridView ID="GridViewUrl" runat="server" AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="6" CellSpacing="2" DataKeyNames="Id">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                <asp:BoundField DataField="Url" HeaderText="Url" SortExpression="Url" />
            </Columns>
            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
            <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
            <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FFF1D4" />
            <SortedAscendingHeaderStyle BackColor="#B95C30" />
            <SortedDescendingCellStyle BackColor="#F1E5CE" />
            <SortedDescendingHeaderStyle BackColor="#93451F" />
        </asp:GridView>
        <asp:HiddenField ID="hdField" runat="server" Value=""/>
    </div>
</asp:Content>
