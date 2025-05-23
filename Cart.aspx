<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="WebApplication1.Cart" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Giỏ hàng của bạn</title>
    <style>
        .cart-container {
            width: 80%;
            margin: 20px auto;
            padding: 20px;
            border: 1px solid #ccc;
            border-radius: 5px;
        }
        .cart-item {
            display: flex;
            align-items: center;
            padding: 10px;
            border-bottom: 1px solid #ddd;
        }
        .cart-item img {
            width: 80px;
            height: 80px;
            margin-right: 15px;
        }
        .btn-checkout {
            margin-top: 15px;
            padding: 10px;
            background-color: #28a745;
            color: white;
            border: none;
            cursor: pointer;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="cart-container">
            <h2>Giỏ hàng của bạn</h2>
            <asp:Repeater ID="rptCart" runat="server">
                <ItemTemplate> 
                    <div class="cart-item">
                        <img src='<%# Eval("ImagePath") %>' alt='<%# Eval("ProductName") %>' />
                        <div>
                            <p><strong><%# Eval("ProductName") %></strong></p>
                            <p>Giá: <%# string.Format("{0:#,0} Đ", Eval("Price")) %></p>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <asp:Button ID="btnCheckout" runat="server" Text="Thanh toán" CssClass="btn-checkout" OnClick="btnCheckout_Click" />
        </div>
    </form>
</body>
</html>
