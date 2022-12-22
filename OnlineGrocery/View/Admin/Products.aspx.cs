using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace OnlineGrocery.View.Admin
{
    public partial class Products : System.Web.UI.Page
    {
        Models.Functions Conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            Conn = new Models.Functions();
            GetCategories();
            ShowProducts(); 
        }
        public override void VerifyRenderingInServerForm(Control control)
        {

        }
        public void ShowProducts()
        {
            string Query = "SELECT * FROM ProductTable";
            ProductsGV.DataSource = Conn.getData(Query);
            ProductsGV.DataBind();
        }
        private void GetCategories()
        {
            String Query = "SELECT * FROM CategoryTable";
            CategoryCb.DataTextField = Conn.getData(Query).Columns["CatName"].ToString();
            CategoryCb.DataValueField = Conn.getData(Query).Columns["CatId"].ToString();
            CategoryCb.DataSource = Conn.getData(Query);
            CategoryCb.DataBind();  
        }
        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (PNameTb.Value == "" || CategoryCb.DataTextField == "" || PPrice.Value == "" || PQuantity.Value == "" || ExDate.Value == "")
                {
                    ErrMsg.InnerText = "Missing Data!!!";
                }
                else
                {
                    string PnameStr = PNameTb.Value.Trim();
                    string categoryStr = CategoryCb.SelectedValue;
                    string priceStr = PPrice.Value.Trim();
                    string quantityStr = PQuantity.Value.Trim();
                    string ExDateStr = ExDate.Value.Trim();

                    string Query = "INSERT INTO ProductTable VALUES('{0}','{1}',{2},{3},'{4}')";
                    Query = string.Format(Query, PnameStr, categoryStr, priceStr, quantityStr, ExDateStr);
                    Conn.setData(Query);
                    ShowProducts();
                    ErrMsg.InnerText = "Product Added!!!";

                }
            }
            catch (Exception ex)
            {
                ErrMsg.InnerText = ex.Message;
            }
        }

        protected void DeletingBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (PNameTb.Value == "")
                {
                    ErrMsg.InnerText = "Missing Data!!!";
                }
                else
                {
                    
                    string Query = "DELETE FROM ProductTable WHERE PrId = '{0}'";
                    Query = string.Format(Query, ProductsGV.SelectedRow.Cells[1].Text);
                    Conn.setData(Query);
                    ShowProducts();
                    ErrMsg.InnerText = "Product Deleted!!!";
                    PNameTb.Value = "";
                    CategoryCb.DataValueField= "";
                    PPrice.Value = "";
                    PQuantity.Value = "";
                    ExDate.Value = "";

                }
            }
            catch (Exception ex)
            {
                ErrMsg.InnerText = ex.Message;
            }
        }

        int key = 0;
        protected void ProductsGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            PNameTb.Value = ProductsGV.SelectedRow.Cells[2].Text;
            CategoryCb.SelectedValue = ProductsGV.SelectedRow.Cells[3].Text;
            PPrice.Value = ProductsGV.SelectedRow.Cells[4].Text;
            PQuantity.Value = ProductsGV.SelectedRow.Cells[5].Text;
            ExDate.Value = ProductsGV.SelectedRow.Cells[6].Text;
            if (PNameTb.Value == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(ProductsGV.SelectedRow.Cells[1].Text);

            }
        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (PNameTb.Value == "" || CategoryCb.DataTextField == "" || PPrice.Value == "" || PQuantity.Value == "")
                {
                    ErrMsg.InnerText = "Missing Data!!!";
                }
                else
                {
                    string PnameStr = PNameTb.Value;
                    string PCatStr = CategoryCb.SelectedValue;
                    string PriceStr = PPrice.Value;
                    string PQuantityStr = PQuantity.Value;
                    string ExDateStr = ExDate.Value;

                    string Query = "UPDATE ProductTable SET PrName='{0}', PrCat={1}, PrPrice={2},PrQty={3},PrExpDate='{4}' WHERE PrId = {5}";
                    Query = string.Format(Query, PnameStr, PCatStr,PriceStr,PQuantityStr,ExDateStr, ProductsGV.SelectedRow.Cells[1].Text);
                    Conn.setData(Query);
                    ShowProducts();
                    PNameTb.Value = "";
                    CategoryCb.DataValueField = "";
                    PPrice.Value = "";
                    PQuantity.Value = "";
                    ExDate.Value = "";
                    ErrMsg.InnerText = "Product Updated!!!";

                }
            }
            catch (Exception ex)
            {
                ErrMsg.InnerText = ex.Message;
            }
        }
    }
}