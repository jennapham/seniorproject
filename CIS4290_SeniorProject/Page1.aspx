<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Page1.aspx.cs" Inherits="CIS4290_SeniorProject.Page1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
	<style type="text/css">
		#TextArea1 {
			height: 183px;
			width: 393px;
		}
	</style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        	<asp:Label ID="Label1" runat="server" Text="Please select a form type and upload your file."></asp:Label>
			<br />
        	<br />

        	<asp:DropDownList ID="DropDownList1" runat="server" TabIndex="0">
				<asp:ListItem Text="TEST" Value="0"></asp:ListItem>
				<asp:ListItem Text="ACORD 25" Value="1"></asp:ListItem>
				<asp:ListItem Text="W9" Value="2"></asp:ListItem>
			</asp:DropDownList>

        	<asp:FileUpload ID="FileUpload1" runat="server" />
        	<br />
        	<br />
        	<asp:Label ID="Label2" runat="server" Text="Please select a file type."></asp:Label>
        	<br />
			<asp:RadioButton ID="RadioButton1" runat="server" Text="PDF" GroupName="FileTypeRadioGroup" />
			<br />
			<asp:RadioButton ID="RadioButton2" runat="server" Text="Image" GroupName="FileTypeRadioGroup" />
			<br />
			<br />
			<asp:Button ID="UploadButton" Text="Upload" runat="server" OnClick="UploadButton_Click" />
			<br />
			<br />
			<asp:TextBox id="TextBox1" TextMode="multiline" runat="server" ReadOnly="True" Height="420px" Width="811px" />

        </div>
    </form>
</body>
</html>
