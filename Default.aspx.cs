using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static WebApplication1.Cart;

namespace WebApplication1
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                LoadProducts();
            }

        }
        private void LoadProducts()
        {
            try
            {
                string connStr = ConfigurationManager.ConnectionStrings["LaptopDB"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open(); // Mở kết nối kiểm tra lỗi

                    // Cập nhật truy vấn để lấy ProductID
                    string query = "SELECT ProductID, ProductName, Price, ImagePath FROM Products";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    rptProducts.DataSource = dt;
                    rptProducts.DataBind();
                }
            }
            catch (Exception ex)
            {
                Response.Write("Lỗi kết nối hoặc truy vấn: " + ex.Message);
            }
        }

        protected void btnBuy_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string selectedProductID = btn.CommandArgument; // Lấy ProductID từ nút "Mua ngay"

            Response.Write("<script>alert('ProductID đang gửi: " + selectedProductID + "');</script>"); // Kiểm tra giá trị

            if (Session["UserID"] == null)
            {
                string currentUrl = Request.Url.ToString();
                Response.Redirect("Login.aspx?returnUrl=" + Server.UrlEncode(currentUrl));
            }
            else
            {
                Response.Redirect("Cart.aspx?productID=" + selectedProductID);
            }
        }





    }
}
