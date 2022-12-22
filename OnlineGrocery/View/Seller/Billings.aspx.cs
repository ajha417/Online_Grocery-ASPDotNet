using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace OnlineGrocery.View.Seller
{
    public partial class Billings : System.Web.UI.Page
    {

        Models.Functions Conn;
        int Seller = Login.SKey;
        protected void Page_Load(object sender, EventArgs e)
        {
            Conn = new Models.Functions();
            ShowProducts();

            if (!this.IsPostBack)
            {
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[5]
                {
                    new DataColumn("ID"),
                    new DataColumn("Product"),
                    new DataColumn("Price"),
                    new DataColumn("Quantity"),
                    new DataColumn("Total")
                });
                ViewState["Bill"] = dt;
                this.DataBind();

            }
        }
        private void InsertBill()
        {
            try
            {
                
                    
                    string Query = "INSERT INTO BillTable VALUES('{0}','{1}',{2})";
                    Query = string.Format(Query, System.DateTime.Today, Seller, grandTotal);
                    Conn.setData(Query);
                    ErrMsg.InnerText = "Bill Inserted!!!";
                    

                
            }
            catch (Exception ex)
            {
                ErrMsg.InnerText = ex.Message;
            }
        }
        protected void BindGrid()
        {
            BillGV.DataSource = (DataTable)ViewState["Bill"];
            BillGV.DataBind();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {

        }
        public void ShowProducts()
        {
            string Query = "SELECT PrId as Id, Prname as Name,PrCat as Category,PrPrice as Price,PrQty as Quantity FROM ProductTable";
            ProductsGV.DataSource = Conn.getData(Query);
            ProductsGV.DataBind();
        }

        int key = 0;
        int stock = 0;
        protected void ProductsGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            PNameTb.Value = ProductsGV.SelectedRow.Cells[2].Text;
           // CategoryCb.SelectedValue = ProductsGV.SelectedRow.Cells[3].Text;
            PrPriceTb.Value = ProductsGV.SelectedRow.Cells[4].Text;

           stock = Convert.ToInt32(PrQtyTb.Value = ProductsGV.SelectedRow.Cells[5].Text);
            ErrMsg.InnerText = "Quantity Updated!!!";
            //  ExDate.Value = ProductsGV.SelectedRow.Cells[6].Text;
            if (PNameTb.Value == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(ProductsGV.SelectedRow.Cells[1].Text);

            }
        }

        public void updateStock()
        {
            int newQty;
            newQty = Convert.ToInt32(ProductsGV.SelectedRow.Cells[5].Text) + Convert.ToInt32(PrQtyTb.Value);

            string Query = "UPDATE ProductTable SET PrQty='{0}' WHERE PrId = {1}";
            Query = string.Format(Query,newQty,ProductsGV.SelectedRow.Cells[1].Text);
            Conn.setData(Query);
            ShowProducts();
            PNameTb.Value = "";
            ErrMsg.InnerText = "Quantity Updated!!!";
            
            
        }

        int grandTotal = 0;

        protected void AddToBill_Click(object sender, EventArgs e)
        {
            int total = Convert.ToInt32(PrQtyTb.Value) * Convert.ToInt32(PrPriceTb.Value);
            DataTable dt = (DataTable)ViewState["Bill"];
            dt.Rows.Add(BillGV.Rows.Count+1,
                PNameTb.Value.Trim(),
                PrPriceTb.Value.Trim(),
                PrQtyTb.Value.Trim(),
                total
                );
            ViewState["Bill"] = dt;
            this.BindGrid();
            //grandTotal = grandTotal + (Convert.ToInt32(PrQtyTb.Value) * Convert.ToInt32(PrPriceTb.Value));
         //   grandTotalTb.InnerText = "Rs." + grandTotal;
            updateStock();
            for(int i = 0; i <=BillGV.Rows.Count-1; i++)
            {
                grandTotal = grandTotal + Int32.Parse(BillGV.Rows[i].Cells[4].Text.ToString());
            }
            
            grandTotalTb.InnerHtml = "Rs." + grandTotal;
            PNameTb.Value = string.Empty;
            PrPriceTb.Value = string.Empty;
            PrQtyTb.Value = string.Empty;
        }
        
    }
}