<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="shoppingcartappusingasp.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Welcome to Shopping Cart App</h2>
    <p>Browse products and add them to your cart easily.</p>
    <asp:Button ID="ViewProductsBtn" runat="server" Text="View Products" PostBackUrl="~/Products.aspx" />
</asp:Content>
