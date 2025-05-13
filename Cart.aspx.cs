using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string productID = Request.QueryString["productID"];
                if (!string.IsNullOrEmpty(productID))
                {
                    AddToCart(productID); // Lưu sản phẩm vào giỏ hàng
                }

                LoadCart(); // Hiển thị giỏ hàng
            }
        }
        private void LoadCart()
        {
            List<string> cart = Session["Cart"] as List<string>;
            if (cart != null && cart.Count > 0)
            {
                DataTable dt = new DataTable();
                string connStr = ConfigurationManager.ConnectionStrings["LaptopDB"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    string query = "SELECT ProductID, ProductName, Price, ImagePath FROM Products WHERE ProductID IN (" +
                                   string.Join(",", cart) + ")"; // Truy vấn sản phẩm theo giỏ hàng

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.Fill(dt);
                }

                rptCart.DataSource = dt;
                rptCart.DataBind();
            }
            else
            {
                Response.Write("<p>Giỏ hàng của bạn đang trống.</p>");
            }
        }

        private void AddToCart(string productID)
        {
            List<string> cart = Session["Cart"] as List<string>;
            if (cart == null)
            {
                cart = new List<string>();
            }

            cart.Add(productID);
            Session["Cart"] = cart; // Lưu giỏ hàng vào Session

            Response.Write("<script>alert('Đã thêm sản phẩm vào giỏ hàng!');</script>");
        }

        protected void btnCheckout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Checkout.aspx");
        }

    }
}
