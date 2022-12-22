using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineGrocery.View.Admin
{
    public partial class Sellers : System.Web.UI.Page
    {
        Models.Functions Conn;

        protected void Page_Load(object sender, EventArgs e)
        {
            Conn = new Models.Functions();  
            ShowSellers();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            
        }
        public void ShowSellers()
        {
            string Query = "SELECT * FROM SellerTable";
            SellerGV.DataSource = Conn.getData(Query);
            SellerGV.DataBind();
        }
        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if(SPass.Value == "" || Semail.Value == "" || Sname.Value == "" || SPhone.Value == "" || SAddress.Value == "")
                {
                    ErrMsg.InnerText = "Missing Data!!!";
                }
                else
                {
                    string SNameStr = Sname.Value;
                    string SPhoneStr = SPhone.Value;
                    string SAddressStr = SAddress.Value;
                    string SEmailStr = Semail.Value;
                    string SPassStr = SPass.Value;

                    string Query = "INSERT INTO SellerTable VALUES('{0}','{1}','{2}','{3}','{4}')";
                    Query = string.Format(Query,SNameStr,SEmailStr,SPassStr,SPhoneStr,SAddressStr);
                    Conn.setData(Query);
                    ShowSellers();
                    ErrMsg.InnerText = "Seller Added!!!";

                }
            }
            catch (Exception ex) 
            {
                ErrMsg.InnerText = ex.Message;
            }
            
        }

        int key = 0;
        protected void SellerGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            Sname.Value = SellerGV.SelectedRow.Cells[2].Text;
            Semail.Value = SellerGV.SelectedRow.Cells[3].Text;
            SPass.Value = SellerGV.SelectedRow.Cells[4].Text;
            SPhone.Value = SellerGV.SelectedRow.Cells[5].Text;
            SAddress.Value = SellerGV.SelectedRow.Cells[6].Text;
            if(Sname.Value == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(SellerGV.SelectedRow.Cells[1].Text);

            }
        }

        protected void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (SPass.Value == "" || Semail.Value == "" || Sname.Value == "" || SPhone.Value == "" || SAddress.Value == "")
                {
                    ErrMsg.InnerText = "Missing Data!!!";
                }
                else
                {
                    string SNameStr = Sname.Value;
                    string SPhoneStr = SPhone.Value;
                    string SAddressStr = SAddress.Value;
                    string SEmailStr = Semail.Value;
                    string SPassStr = SPass.Value;

                    string Query = "UPDATE SellerTable SET SellName='{0}', SellEmail='{1}', SellPassword='{2}',SellPhone = '{3}',SellAddress = '{4}' WHERE SelId = '{5}'";
                    Query = string.Format(Query, SNameStr, SEmailStr, SPassStr, SPhoneStr, SAddressStr, SellerGV.SelectedRow.Cells[1].Text);
                    Conn.setData(Query);
                    ShowSellers();
                    ErrMsg.InnerText = "Seller Updated!!!";

                }
            }
            catch (Exception ex)
            {
                ErrMsg.InnerText = ex.Message;
            }
        }

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (Sname.Value == "")
                {
                    ErrMsg.InnerText = "Missing Data!!!";
                }
                else
                {
                    string SNameStr = Sname.Value;
                    string Query = "DELETE FROM SellerTable WHERE SelId = '{0}'";
                    Query = string.Format(Query, SellerGV.SelectedRow.Cells[1].Text);
                    Conn.setData(Query);
                    ShowSellers();
                    ErrMsg.InnerText = "Seller Deleted!!!";
                    


                }
            }
            catch (Exception ex)
            {
                ErrMsg.InnerText = ex.Message;
            }
        }
    }
}