using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineGrocery.View
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Conn = new Models.Functions();
        }
        public static string SName;
        public static int SKey;
        public override void VerifyRenderingInServerForm(Control control)
        {
          
        }
        Models.Functions Conn;
        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            if (adminloginid.Checked == true)
            {
                if (EmailId.Value == "Admin@gmail.com" && UserPasswordTb.Value == "Admin@123")
                {
                    Response.Redirect("Admin/Sellers.aspx");
                }
                else
                {
                    InfoMsg.InnerText = "Invalid Admin!!!";
                }
            }
            else
            {
                String Query = "SELECT SelId,SellName,SellEmail,SellPassword FROM SellerTable WHERE SellEmail='{0}' AND SellPassword='{1}'";
                Query = string.Format(Query, EmailId.Value, UserPasswordTb.Value);
                DataTable dt = Conn.getData(Query);
                if (dt.Rows.Count == 0)
                {
                    InfoMsg.InnerText = "Invalid User!!!";
                }
                else
                {
                    SName = EmailId.Value;
                    SKey = Convert.ToInt32(dt.Rows[0][0].ToString());
                    Response.Redirect("Seller/Billings.aspx");
                }
            }
        }
    }
}