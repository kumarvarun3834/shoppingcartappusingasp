<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="shoppingcartappusingasp.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<h2>Login</h2>
    <asp:Login ID="Login1" runat="server" 
        DestinationPageUrl="~/Home.aspx" 
        FailureText="Invalid username or password."
        TitleText="Please enter your credentials" 
        BackColor="#f8f8f8" BorderColor="#ccc" BorderPadding="4"
        BorderStyle="Solid" BorderWidth="1px" Width="300px" />
</asp:Content>
