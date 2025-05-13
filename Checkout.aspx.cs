using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Checkout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCheckout();
            }
        }

        private void LoadCheckout()
        {
            List<string> cart = Session["Cart"] as List<string>;
            if (cart != null && cart.Count > 0)
            {
                rptCheckout.DataSource = cart.ConvertAll(productID => new { ProductID = productID });
                rptCheckout.DataBind();
            }
            else
            {
                Response.Write("<p>Không có sản phẩm nào để thanh toán.</p>");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string customerName = txtName.Text;
            string customerPhone = txtPhone.Text;
            string customerAddress = txtAddress.Text;

            if (!string.IsNullOrEmpty(customerName) && !string.IsNullOrEmpty(customerPhone) && !string.IsNullOrEmpty(customerAddress))
            {
                // Xử lý lưu đơn hàng vào database (Giả lập)
                Response.Write("<script>alert('Đơn hàng của bạn đã được ghi nhận!');</script>");

                // Xóa giỏ hàng sau khi thanh toán
                Session["Cart"] = null;

                Response.Redirect("Default.aspx"); // Quay lại trang chính sau khi hoàn tất đơn hàng
            }
            else
            {
                Response.Write("<script>alert('Vui lòng nhập đầy đủ thông tin để thanh toán.');</script>");
            }
        }
    }
}
