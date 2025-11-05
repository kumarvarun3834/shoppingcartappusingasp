<%@ Page Title="Products" Language="C#" MasterPageFile="~/Site1.Master"
    AutoEventWireup="true" CodeFile="Products.aspx.cs"
    Inherits="shoppingcartappusingasp.Products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 style="margin-bottom: 20px;">Available Products</h2>
    <style>
        .btn {
            padding: 6px 12px;
            border: none;
            border-radius: 5px;
            cursor: pointer;
                }
        .btn-primary { background-color: #007bff; color: white; }
        .btn-danger { background-color: #dc3545; color: white; }
        .product-card:hover { box-shadow: 0 0 8px rgba(0,0,0,0.15); }
    </style>


    <asp:Repeater ID="ProductList" runat="server" 
                  OnItemCommand="ProductList_ItemCommand" 
                  OnItemDataBound="ProductList_ItemDataBound">
        <ItemTemplate>
            <div class="product-card" 
                 style="border:1px solid #ddd; border-radius:8px; padding:15px; 
                        background:#fff8dc; margin-bottom:15px; box-shadow:0 0 6px rgba(0,0,0,0.1);">
                
                <h3 style="margin:0 0 8px 0; font-weight:600;">
                    <%# Eval("Name") %>
                </h3>
                <p style="margin:0 0 10px 0; font-size:16px;">
                    ₹<%# Eval("Price") %>
                </p>

                <div style="display:flex; align-items:center; gap:10px;">
                    <asp:Button ID="AddBtn" runat="server" Text="Add to Cart" 
                                CommandName="AddToCart" 
                                CommandArgument='<%# Eval("ID") %>'
                                CssClass="btn btn-primary" />

                    <asp:Button ID="RemoveBtn" runat="server" Text="Remove" 
                                CommandName="RemoveFromCart" 
                                CommandArgument='<%# Eval("ID") %>'
                                CssClass="btn btn-danger" />

                    <asp:Label ID="QtyLabel" runat="server" Text="0" 
                               Style="font-weight:bold; color:#333;" />
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>

    <asp:Label ID="lblMessage" runat="server" ForeColor="Green" />
</asp:Content>

