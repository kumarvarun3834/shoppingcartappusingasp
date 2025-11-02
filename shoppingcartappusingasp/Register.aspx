<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site1.Master"
    AutoEventWireup="true" CodeBehind="Register.aspx.cs"
    Inherits="shoppingcartappusingasp.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Create User</h2>
    <h3>Sign Up for Your New Account</h3>

    <asp:CreateUserWizard ID="CreateUserWizard1" runat="server"
        ContinueDestinationPageUrl="~/Home.aspx"
        OnCreatedUser="CreateUserWizard1_CreatedUser">
        <WizardSteps>
            <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server">
                <ContentTemplate>
                    <table>
                        <tr>
                            <td>Username:</td>
                            <td><asp:TextBox ID="UserName" runat="server" /></td>
                        </tr>
                        <tr>
                            <td>Password:</td>
                            <td><asp:TextBox ID="Password" runat="server" TextMode="Password" /></td>
                        </tr>
                        <tr>
                            <td>Confirm Password:</td>
                            <td><asp:TextBox ID="ConfirmPassword" runat="server" TextMode="Password" /></td>
                        </tr>
                        <tr>
                            <td>Email:</td>
                            <td><asp:TextBox ID="Email" runat="server" /></td>
                        </tr>
                        <tr>
                            <td>Role:</td>
                            <td>
                                <asp:RadioButtonList ID="RoleList" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Text="Merchant" Value="merchant"></asp:ListItem>
                                    <asp:ListItem Text="User" Value="user" Selected="True"></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                    </table>
                    <asp:Button ID="StepNextButton" runat="server"
                        CommandName="MoveNext" Text="Create Account" />
                </ContentTemplate>
            </asp:CreateUserWizardStep>

            <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server">
                <ContentTemplate>
                    <h3>Account Created Successfully!</h3>
                    <asp:HyperLink ID="ContinueLink" runat="server"
                        NavigateUrl="~/Login.aspx">Go to Login</asp:HyperLink>
                </ContentTemplate>
            </asp:CompleteWizardStep>
        </WizardSteps>
    </asp:CreateUserWizard>
</asp:Content>
