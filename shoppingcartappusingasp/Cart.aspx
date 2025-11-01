<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="shoppingcartappusingasp.Cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Your Shopping Cart</h2>

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CssClass="table">
        <Columns>
            <asp:BoundField DataField="ProductID" HeaderText="Product ID" />
            <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
            <asp:BoundField DataField="Price" HeaderText="Price (₹)" DataFormatString="{0:N2}" />
            <asp:BoundField DataField="Total" HeaderText="Total (₹)" DataFormatString="{0:N2}" />
        </Columns>
    </asp:GridView>

    <br />
    <asp:Label ID="lblTotal" runat="server" Font-Bold="true" ForeColor="Green" />
</asp:Content>
