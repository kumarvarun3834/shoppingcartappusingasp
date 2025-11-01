<%@ Page Title="Products" Language="C#" MasterPageFile="~/Site1.Master"
    AutoEventWireup="true" CodeFile="Products.aspx.cs"
    Inherits="shoppingcartappusingasp.Products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Available Products</h2>

    <asp:Repeater ID="ProductList" runat="server" OnItemCommand="ProductList_ItemCommand">
        <ItemTemplate>
            <div class="product" style="margin-bottom:10px;">
                <strong><%# Eval("Name") %></strong> - ₹<%# Eval("Price") %>
                <asp:Button ID="AddToCartBtn" runat="server" Text="Add to Cart"
                    CommandName="AddToCart" CommandArgument='<%# Eval("ID") %>' />
            </div>
        </ItemTemplate>
    </asp:Repeater>

    <hr />
    <asp:Label ID="lblMessage" runat="server" ForeColor="Green" />
</asp:Content>

