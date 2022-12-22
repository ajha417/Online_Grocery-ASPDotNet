using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineGrocery.View.Admin
{
    public partial class Dashboard : System.Web.UI.Page
    {
        Models.Functions Conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            Conn = new Models.Functions();
            GetProducts();  
            GetCategories();
            GetFinance();
            GetTotalSellers();
            GetSeller();
        }
        private void GetSeller()
        {
            String Query = "SELECT * FROM SellerTable";
            SellerCb.DataTextField = Conn.getData(Query).Columns["SellName"].ToString();
            SellerCb.DataValueField = Conn.getData(Query).Columns["SelId"].ToString();
            SellerCb.DataSource = Conn.getData(Query);
            SellerCb.DataBind();
        }
        private void GetProducts()
        {
            String Query = "SELECT Count(*) from ProductTable";
            PNumTb.InnerText = Conn.getData(Query).Rows[0][0].ToString();
            PNumTb.DataBind();
            
        }
        private void GetCategories()
        {
            String Query = "SELECT Count(*) from CategoryTable";
            CatNumTb.InnerText = Conn.getData(Query).Rows[0][0].ToString();
            CatNumTb.DataBind();

        }
        private void GetFinance()
        {
            String Query = "SELECT Sum(Amount) from BillTable";
            FinanceNumTb.InnerText = "Rs. "+Conn.getData(Query).Rows[0][0].ToString();
            FinanceNumTb.DataBind();

        }
        private void SumSellBySellaers()
        {
            String Query = "SELECT Sum(Amount) from BillTable WHERE Seller = "+SellerCb.DataValueField+"";
            TotalSellsNumTb.InnerText = "Rs. " + Conn.getData(Query).Rows[0][0].ToString();
            TotalSellsNumTb.DataBind();

        }
        private void GetCategoriesAmount()
        {
            String Query = "SELECT Count(*)  from ProductTable";
            PNumTb.InnerText = Conn.getData(Query).Columns["Number"].ToString();
            PNumTb.DataBind();

        }
        private void GetTotalSaleAmount()
        {
            String Query = "SELECT Count(*) as Number from ProductTable";
            PNumTb.InnerText = Conn.getData(Query).Columns["Number"].ToString();
            PNumTb.DataBind();

        }
        private void GetTotalSellers()
        {
            String Query = "SELECT Count(*) from SellerTable";
            SellersNumTb.InnerText = Conn.getData(Query).Rows[0][0].ToString();
            SellersNumTb.DataBind();

        }

        protected void SellerCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            SumSellBySellaers();
        }
    }
}