<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="shoppingcartappusingasp.Products" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Available Products</h2>
    <asp:Repeater ID="ProductList" runat="server">
        <ItemTemplate>
            <div class="product">
                <strong><%# Eval("Name") %></strong> - ₹<%# Eval("Price") %>
                <asp:Button ID="AddToCartBtn" runat="server" Text="Add to Cart" />
            </div>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
