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
    public partial class Categories : System.Web.UI.Page
    {
        Models.Functions Conn; 
        protected void Page_Load(object sender, EventArgs e)
        {
            Conn = new Models.Functions();
            ShowCategories();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            
        }
        public void ShowCategories()
        {
            string Query = "SELECT * FROM CategoryTable";
            CategoriesGV.DataSource= Conn.getData(Query);
            CategoriesGV.DataBind();    
        }

        protected void addBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (Cname.Value == "" || CRemarks.Value == "")
                {
                    ErrMsg.InnerText = "Missing Data!!!";
                }
                else
                {
                    string CNameStr = Cname.Value;
                    string CRemarksStr = CRemarks.Value;
                    
                    string Query = "INSERT INTO CategoryTable VALUES('{0}','{1}')";
                    Query = string.Format(Query, CNameStr, CRemarksStr);
                    Conn.setData(Query);
                    ShowCategories();
                    ErrMsg.InnerText = "Cateogory Added!!!";

                }
            }
            catch (Exception ex)
            {
                ErrMsg.InnerText = ex.Message;
            }
        }

        protected void updatesBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (Cname.Value == "" || CRemarks.Value == "")
                {
                    ErrMsg.InnerText = "Missing Data!!!";
                }
                else
                {
                    string CnameStr = Cname.Value;
                    string CRemarksStr = CRemarks.Value;
                    
                    string Query = "UPDATE CategoryTable SET CatName='{0}', CatDesctiption='{1}' WHERE CatId = '{2}'";
                    Query = string.Format(Query, CnameStr,CRemarksStr, CategoriesGV.SelectedRow.Cells[1].Text);
                    Conn.setData(Query);
                    ShowCategories();
                    Cname.Value = "";
                    CRemarks.Value = "";
                    ErrMsg.InnerText = "Category Updated!!!";

                }
            }
            catch (Exception ex)
            {
                ErrMsg.InnerText = ex.Message;
            }
        }

        protected void deletesBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (Cname.Value == "")
                {
                    ErrMsg.InnerText = "Missing Data!!!";
                }
                else
                {
                    string CnameStr = Cname.Value;
                    string Query = "DELETE FROM CategoryTable WHERE CatId = '{0}'";
                    Query = string.Format(Query, CategoriesGV.SelectedRow.Cells[1].Text);
                    Conn.setData(Query);
                    ShowCategories();
                    ErrMsg.InnerText = "Category Deleted!!!";
                    Cname.Value = "";
                    CRemarks.Value = "";


                }
            }
            catch (Exception ex)
            {
                ErrMsg.InnerText = ex.Message;
            }
        }

        int key = 0;
        protected void CategoriesGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cname.Value = CategoriesGV.SelectedRow.Cells[2].Text;
            CRemarks.Value = CategoriesGV.SelectedRow.Cells[3].Text;
            
            if (Cname.Value == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(CategoriesGV.SelectedRow.Cells[1].Text);

            }
        }
    }
}