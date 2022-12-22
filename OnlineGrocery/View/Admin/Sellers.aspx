<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="Sellers.aspx.cs" Inherits="OnlineGrocery.View.Admin.Sellers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Mybody" runat="server">
     <div class="container-fluid">
        <div class="row">
            <div class="col-md-4"></div>
            <div class="col-md-8"><img src="../../Asset/Images/vegfood.jpg" style="height:50px;width:50px"/>
                <h3 class="text-success">Manage Categories</h3>
            </div>
        </div>
        <div class="row">
            <div class="col-md-4">
                <h2 class="text-success">Seller Details</h2>
                
                   <div class="form-group">
                        <label for="Sname">Seller Name</label>
                        <input type="text" class="form-control" id="Sname" runat="server">
    
                    </div>
                    <div class="form-group">
                        <label for="Semail">Seller Email</label>
                        <input type="email" class="form-control" id="Semail" runat="server">
    
                    </div>
                    <div class="form-group">
                        <label for="SPass">Seller Password</label>
                        <input type="password" class="form-control" id="SPass" runat="server">
    
                    </div>
                    <div class="form-group">
                        <label for="SPhone">Seller Phhone</label>
                        <input type="text" class="form-control" id="SPhone" runat="server">
    
                    </div>
                <div class="form-group">
                        <label for="SAddress">Seller Address</label>
                        <input type="text" class="form-control" id="SAddress" runat="server">
    
                    </div>

                <label id="ErrMsg" runat="server" class="text-danger"></label> <br />                
                <asp:Button Text="  Update   " class="btn mt-3 btn-warning" runat="server" ID="EditBtn" OnClick="EditBtn_Click" />
                <asp:Button Text="  Save  " class="btn mt-3 btn-success" runat="server" ID="SaveBtn" OnClick="SaveBtn_Click" />
                <asp:Button Text="  Delete  " class="btn mt-3 btn-danger" runat="server" ID="DeleteBtn" OnClick="DeleteBtn_Click" />
                   
                
            </div> 
            <div class="col-md-8">

                <!--table here-->
                <asp:GridView runat="server" class="table table-hover" ID="SellerGV" AutoGenerateSelectButton="True" OnSelectedIndexChanged="SellerGV_SelectedIndexChanged">

                </asp:GridView>

            </div>
        </div>
    </div>
</asp:Content>
