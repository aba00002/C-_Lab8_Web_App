<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterCourse.aspx.cs" Inherits="Lab8.RegisterCourse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link rel="stylesheet" type="text/css" href="App_Themes/SiteStyles.css" />
</head>
<body class="body">
    <form id="form1" runat="server">
        <div>
            <h1>Registrations</h1>
            <br />

            Student:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="DrpDownRegistered" runat="server" CssClass="dropdown" OnSelectedIndexChanged="drpDownReg" AutoPostBack="true">
            </asp:DropDownList><asp:RequiredFieldValidator ID="RFRegisteredStudents" runat="server" ControlToValidate="DrpDownRegistered" ForeColor="red" Display="Dynamic" InitialValue=""
                ErrorMessage=" Must select one!"></asp:RequiredFieldValidator>

            <br />
            <asp:Label ID="Output" runat="server" ForeColor="Blue"></asp:Label>
            <br />
            <p>Following courses are currently available for registration</p>
            
            <asp:Label ID="Error" runat="server" ForeColor="Red"></asp:Label>
           
            <p>
                <asp:CheckBoxList ID="CheckBoxList1" runat="server">
                </asp:CheckBoxList>
            </p>
            <p>
                <asp:Button ID="Button1" runat="server" Text="Save" CssClass="button" OnClick="Button1_Click"/>
            </p>
            <p>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/AddStudent.aspx">Add Students</asp:HyperLink>
            </p>
            <p>&nbsp;</p>
        </div>
    </form>
</body>
</html>
