<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="WebApplication1.Checkout" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Thanh toán đơn hàng</title>
    <style>
        .checkout-container {
            width: 80%;
            margin: 20px auto;
            padding: 20px;
            border: 1px solid #ccc;
            border-radius: 5px;
        }
        .checkout-item {
            padding: 10px;
            border-bottom: 1px solid #ddd;
        }
        .btn-submit {
            margin-top: 15px;
            padding: 10px;
            background-color: #007bff;
            color: white;
            border: none;
            cursor: pointer;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="checkout-container">
            <h2>Thông tin đơn hàng</h2>
            <asp:Repeater ID="rptCheckout" runat="server">
                <ItemTemplate>
                    <div class="checkout-item">
                        <p><strong>Sản phẩm ID:</strong> <%# Eval("ProductID") %></p>
                    </div>
                </ItemTemplate>
            </asp:Repeater>

            <h3>Thông tin khách hàng</h3>
            <asp:TextBox ID="txtName" runat="server" placeholder="Họ và tên" CssClass="input-field" />
            <asp:TextBox ID="txtPhone" runat="server" placeholder="Số điện thoại" CssClass="input-field" />
            <asp:TextBox ID="txtAddress" runat="server" placeholder="Địa chỉ giao hàng" CssClass="input-field" />

            <asp:Button ID="btnSubmit" runat="server" Text="Xác nhận thanh toán" CssClass="btn-submit" OnClick="btnSubmit_Click" />
        </div>
    </form>
</body>
</html>