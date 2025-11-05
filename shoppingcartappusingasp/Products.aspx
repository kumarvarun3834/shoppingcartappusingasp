<%@ Page Title="Products" Language="C#" MasterPageFile="~/Site1.Master"
    AutoEventWireup="true" CodeFile="Products.aspx.cs"
    Inherits="shoppingcartappusingasp.Products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Available Products</h2>

    <asp:Repeater ID="ProductList" runat="server" OnItemCommand="ProductList_ItemCommand" OnItemDataBound="ProductList_ItemDataBound">
    <ItemTemplate>
        <div class="product" style="margin-bottom:10px;">
            <strong><%# Eval("Name") %></strong> - ₹<%# Eval("Price") %>

            <asp:Button ID="AddBtn" runat="server" Text="Add to Cart" 
                        CommandName="AddToCart" CommandArgument='<%# Eval("ID") %>' />
            <asp:Button ID="RemoveBtn" runat="server" Text="Remove Item"
                        CommandName="RemoveFromCart" CommandArgument='<%# Eval("ID") %>' />

            Quantity: 
            <asp:Label ID="QtyLabel" runat="server" Text="0" />
        </div>
    </ItemTemplate>
</asp:Repeater>


<asp:Label ID="Label1" runat="server" ForeColor="Green" />


    <hr />
    <asp:Label ID="lblMessage" runat="server" ForeColor="Green" />
</asp:Content>

