---

## 🛒 Steps in Developing a Web Application

### Example: *Shopping Cart Application using ASP.NET*

---

### **1. Requirement Analysis**

* Identify features needed:

  * Display products
  * User login/register
  * Add/remove items from cart
  * Checkout, billing, etc.
* Define roles: user, admin.

---

### **2. Design**

* Design the database tables:

  * `Users(UserID, Username, Password, Email)`
  * `Products(ProductID, Name, Price)`
  * `Cart(UserID, ProductID, Quantity, TotalPrice)`
* Plan the site layout and navigation.

---

### **3. Create the Project**

* In Visual Studio → **New ASP.NET Web Application**
* Add a **Master Page (`Site1.Master`)** to maintain a **common layout** (header, menu, footer).

  * Example:

    ```aspx
    <asp:Menu ID="MainMenu" runat="server">
        <Items>
            <asp:MenuItem Text="Home" NavigateUrl="~/Home.aspx" />
            <asp:MenuItem Text="Products" NavigateUrl="~/Products.aspx" />
            <asp:MenuItem Text="Cart" NavigateUrl="~/Cart.aspx" />
        </Items>
    </asp:Menu>
    ```
  * All pages (Home, Products, Cart) use this same Master Page for uniform look.

---

### **4. Apply Themes, Skins, and Styles**

* **Theme** → defines the overall appearance of the site.
  Create folder:

  ```
  App_Themes/Default/
  ```

  Inside add:

  * `Style.css` → global CSS rules
  * `Control.skin` → control-level appearance

  Example:

  ```css
  /* Style.css */
  body { font-family: Arial; background-color: #f5f5f5; }
  .header { background-color: #004aad; color: white; padding: 10px; }
  ```

  ```xml
  <!-- Control.skin -->
  <asp:Button runat="server" BackColor="#004aad" ForeColor="White" BorderStyle="None" />
  ```

  Apply it in `Web.config`:

  ```xml
  <pages theme="Default" />
  ```

---

### **5. Develop Individual Pages**

* **Register.aspx** – for new users
* **Login.aspx** – to authenticate
* **Products.aspx** – list items using Repeater or GridView
* **Cart.aspx** – display selected products from Session 

Each content page uses:

```aspx
<%@ Page MasterPageFile="~/Site1.Master" ... %>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">
   <!-- Page-specific content -->
</asp:Content>
```

---

### **6. Implement Business Logic**

* Use C# code-behind for:

  * Adding products to cart
  * Updating quantity
  * Managing sessions
  * Validating login/registration
  * Calculating total cost

---

### **7. Testing and Debugging**

* Test each module (registration, login, add to cart)
* Verify session handling and navigation
* Check consistent appearance with the applied theme

---

### **8. Deployment**

* Publish the web application to IIS or any ASP.NET hosting service
* Configure database connection strings on the server

---

### **🎯 Summary**

| Concept         | Purpose                                        | Example                      |
| --------------- | ---------------------------------------------- | ---------------------------- |
| **Master Page** | Common layout for all pages                    | `Site1.Master`               |
| **Themes**      | Define look and feel of site                   | `App_Themes/Default`         |
| **Skins**       | Set default style for ASP controls             | `Control.skin`               |
| **Styles**      | CSS used for design consistency                | `Style.css`                  |
| **Pages**       | Implement functionality (Home, Products, Cart) | `Products.aspx`, `Cart.aspx` |

---

### Access Membership system 
"C:\Windows\Microsoft.NET\Framework\v4.0.30319\aspnet_regsql.exe"
### Setup 
Use this in the aspnet_regsql wizard

When it asks Server name, enter:

".\SQLEXPRESS"


Authentication:

✅ Windows Authentication
