<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="OnlineGrocery.View.Admin.Categories" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Mybody" runat="server">
        <div class="container-fluid">
        <div class="row">
            <div class="col-md-4"></div>
            <div class="col-md-8"><br /><img src="../../Asset/Images/vegfood.jpg" style="height:50px;width:50px"/>
                <h3 class="text-success">Manage Categories</h3>
            </div>
        </div>
        <div class="row">
            <div class="col-md-4">
                <h2 class="text-success">Category Details</h2>
                
                   <div class="form-group">
                        <label for="Cname">Category Name</label>
                        <input type="text" class="form-control" id="Cname" runat="server">
    
                    </div>
                    <div class="form-group">
                        <label for="CRemarks">Category Remarks</label>
                        <input type="text" class="form-control" id="CRemarks" runat="server">
    
                    </div>
                <label id="ErrMsg" runat="server" class="text-danger"></label>
                <br />                     
                <asp:Button Text="  Update    " class="btn mt-3 btn-warning" runat="server" ID="updatesBtn" OnClick="updatesBtn_Click" />
                <asp:Button Text="  Add   " class="btn mt-3 btn-success" runat="server" ID="addBtn" OnClick="addBtn_Click" />
                <asp:Button Text="  Delete  " class="btn mt-3 btn-danger" runat="server" ID="deletesBtn" OnClick="deletesBtn_Click" />
                   
                
            </div> 
            <div class="col-md-8">

                <!--table here-->
                <asp:GridView runat="server" class="table table-hover" ID="CategoriesGV" AutoGenerateSelectButton="True" OnSelectedIndexChanged="CategoriesGV_SelectedIndexChanged">

                </asp:GridView>

            </div>
        </div>
    </div>
</asp:Content>
