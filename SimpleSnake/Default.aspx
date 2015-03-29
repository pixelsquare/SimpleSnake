<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SimpleSnake.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <%--            <asp:Button ID="btnRefresh" runat="server" onclick="btnRefresh_Click" 
                Text="Refresh" />--%><%--        <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem>UserID</asp:ListItem>
            <asp:ListItem>LastName</asp:ListItem>
            <asp:ListItem>FirstName</asp:ListItem>
            <asp:ListItem>MiddleName</asp:ListItem>
            <asp:ListItem>ContactNo</asp:ListItem>
            <asp:ListItem>Email</asp:ListItem>
            <asp:ListItem>UserName</asp:ListItem>
        </asp:DropDownList>--%>

         <div>

            <asp:TextBox ID="txtSearch" runat="server" Width="442px">Display all Players</asp:TextBox>
            <asp:Button ID="btnAllPlayers" runat="server" Text="Display" 
                onclick="btnAllPlayers_Click" />

         </div>   
         <div>

            <asp:TextBox ID="TextBox1" runat="server" Width="442px">Display only Steve Nash</asp:TextBox>
            <asp:Button ID="btnSteveNash" runat="server" onclick="btnSteveNash_Click1" 
                Text="Display" /> 

         </div>
         <div>

            <asp:TextBox ID="TextBox2" runat="server" Width="442px">Display All Players from Miami Heat</asp:TextBox>
            <asp:Button ID="btnMiamiHeat" runat="server" onclick="btnMiamiHeat_Click" 
                Text="Display" />

         </div>
         <div>

            <asp:TextBox ID="TextBox3" runat="server" Width="442px">Display All Players from Boston Celtics</asp:TextBox>
            <asp:Button ID="btnBostonCeltics" runat="server" 
                onclick="btnBostonCeltics_Click" Text="Display" />

         </div>

         <div>

            <asp:TextBox ID="TextBox4" runat="server" Width="442px">Display all Players where name starts with letter S or letter K</asp:TextBox>
            <asp:Button ID="btnNameSorK" runat="server" onclick="btnNameSorK_Click" 
                Text="Display" />

         </div>
         <div>
         
             <asp:TextBox ID="TextBox5" runat="server" Width="443px">Display all Players where Salary is greater than 40000 and less than 50000</asp:TextBox>
             <asp:Button ID="btnSalary" runat="server" onclick="btnSalary_Click" 
                 Text="Display" />
         
         </div>
         <div>
         
             <asp:TextBox ID="TextBox6" runat="server" Width="443px">Display Top 3 Players with the Highest Salary</asp:TextBox>
             <asp:Button ID="btnHighestSalary" runat="server" 
                 onclick="btnHighestSalary_Click" Text="Display" />
         
         </div>
         <div>

            <asp:GridView ID="dbGridView" runat="server" Width="449px">
            </asp:GridView>

        </div>

        <p>
            &nbsp;</p>
    </div>
</asp:Content>
