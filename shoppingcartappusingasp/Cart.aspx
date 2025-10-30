<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="shoppingcartappusingasp.Cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Your Shopping Cart</h2>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="True" BorderWidth="1px" />
    <asp:Label ID="EmptyCartLabel" runat="server" Text="Your cart is empty." Visible="False" />
</asp:Content>
