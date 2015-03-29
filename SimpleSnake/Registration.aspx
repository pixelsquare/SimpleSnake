<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="SimpleSnake.Registration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="UsersID" DataSourceID="SqlDataSource1" BackColor="White" 
            BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
            ForeColor="Black" GridLines="Horizontal" 
            onselectedindexchanged="GridView1_SelectedIndexChanged">
            <Columns>
                <asp:CommandField ShowSelectButton="True" ShowDeleteButton="True" />
                <asp:BoundField DataField="UsersID" HeaderText="UsersID" InsertVisible="False" 
                    ReadOnly="True" SortExpression="UsersID" />
                <asp:BoundField DataField="LastName" HeaderText="LastName" 
                    SortExpression="LastName" />
                <asp:BoundField DataField="MiddleName" HeaderText="MiddleName" 
                    SortExpression="MiddleName" />
                <asp:BoundField DataField="FirstName" HeaderText="FirstName" 
                    SortExpression="FirstName" />
                <asp:BoundField DataField="ContactNo" HeaderText="ContactNo" 
                    SortExpression="ContactNo" />
                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                <asp:BoundField DataField="UserName" HeaderText="UserName" 
                    SortExpression="UserName" />
                <asp:BoundField DataField="LastPasswordUpdate" HeaderText="LastPasswordUpdate" 
                    SortExpression="LastPasswordUpdate" />
            </Columns>
            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#242121" />
            </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:GanzonaConnectionString %>" 
            DeleteCommand="DELETE FROM [Users] WHERE [UsersID] = @UsersID" 
            InsertCommand="INSERT INTO [Users] ([LastName], [MiddleName], [FirstName], [ContactNo], [Email], [UserName], [LastPasswordUpdate]) VALUES (@LastName, @MiddleName, @FirstName, @ContactNo, @Email, @UserName, @LastPasswordUpdate)" 
            SelectCommand="SELECT [UsersID], [LastName], [MiddleName], [FirstName], [ContactNo], [Email], [UserName], [LastPasswordUpdate] FROM [Users]" 
            
            UpdateCommand="UPDATE [Users] SET [LastName] = @LastName, [MiddleName] = @MiddleName, [FirstName] = @FirstName, [ContactNo] = @ContactNo, [Email] = @Email, [UserName] = @UserName, [LastPasswordUpdate] = @LastPasswordUpdate WHERE [UsersID] = @UsersID">
            <DeleteParameters>
                <asp:Parameter Name="UsersID" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="LastName" Type="String" />
                <asp:Parameter Name="MiddleName" Type="String" />
                <asp:Parameter Name="FirstName" Type="String" />
                <asp:Parameter Name="ContactNo" Type="String" />
                <asp:Parameter Name="Email" Type="String" />
                <asp:Parameter Name="UserName" Type="String" />
                <asp:Parameter Name="LastPasswordUpdate" Type="DateTime" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="LastName" Type="String" />
                <asp:Parameter Name="MiddleName" Type="String" />
                <asp:Parameter Name="FirstName" Type="String" />
                <asp:Parameter Name="ContactNo" Type="String" />
                <asp:Parameter Name="Email" Type="String" />
                <asp:Parameter Name="UserName" Type="String" />
                <asp:Parameter Name="LastPasswordUpdate" Type="DateTime" />
                <asp:Parameter Name="UsersID" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>

<table>
    <tr>
        <td class="style1">
            Registration Form</td>
            <td> &nbsp;</td>
    </tr>
    <tr>
        <td class = "style1">
            Last Name:</td>

        <td>
            <asp:Textbox ID="txtLastName" runat="server" width="227px"></asp:Textbox>
        </td>
        <td> &nbsp;</td>
    </tr>

    <tr>
        <td class = "style1">
            First Name:</td>

        <td>
            <asp:Textbox ID="txtFirstName" runat="server" width="227px"></asp:Textbox>
        </td>
        <td> &nbsp;</td>
    </tr>

    <tr>
        <td class = "style1">
            Middle Name:</td>

        <td>
            <asp:Textbox ID="txtMiddleName" runat="server" width="227px"></asp:Textbox>
        </td>
        <td> &nbsp;</td>
    </tr>

        <tr>
        <td class = "style1">
            Contact #:</td>

        <td>
            <asp:Textbox ID="txtContactNo" runat="server" width="227px"></asp:Textbox>
        </td>
        <td> &nbsp;</td>
    </tr>

        <tr>
        <td class = "style1">
            E-Mail Address:</td>

        <td>
            <asp:Textbox ID="txtEmailAddress" runat="server" width="227px"></asp:Textbox>
        </td>
        <td> &nbsp;</td>
    </tr>

        <tr>
        <td class = "style1">
            Username:</td>

        <td>
            <asp:Textbox ID="txtUsername" runat="server" width="227px"></asp:Textbox>
        </td>
        <td> &nbsp;</td>
    </tr>

        <tr>
        <td class = "style1">
            Password:</td>

        <td>
            <asp:Textbox ID="txtPassword" runat="server" width="227px"></asp:Textbox>
        </td>
        <td> &nbsp;</td>
    </tr>

    <tr>
        <td>
            <asp:TextBox ID="txtIDNo" runat="server" Enabled="False"></asp:TextBox>
        </td>
        <td class="style1">
            <asp:Button ID="btnSubmit" runat="server" Width="100px" Text="Submit" 
                onclick="btnSubmit_Click"></asp:button>
            </td>

         <td class="style1">
            <asp:Label ID="txtVerifySubmit" runat="server" Text="Label"></asp:Label>
            </td>
    </tr>

<%--    <tr>
        <td class="style1">
            &nbsp;</td>
    </tr>--%>
</table>

</asp:Content>
