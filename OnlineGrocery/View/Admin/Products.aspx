<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="OnlineGrocery.View.Admin.Products" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Mybody" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-4"></div>
            <div class="col-md-8"><br /><img src="../../Asset/Images/vegfood.jpg" style="height:50px;width:50px"/>
                <h3 class="text-success">Manage Products</h3>
            </div>
        </div>
        <div class="row">
            <div class="col-md-4">
                <h2 class="text-success">Product Details</h2>
                
                   <div class="form-group">
                        <label for="PNameTb">Product Name</label>
                        <input type="text" class="form-control" id="PNameTb" runat="server">
                    </div>
    
                    <div class="form-group">
                        <label for="CategoryDb">Product Category</label>
                        <asp:DropDownList ID="CategoryCb" class="form-control" runat="server"></asp:DropDownList>
                    </div>

    
                    <div class="form-group">
                        <label for="PPrice">Product Price</label>
                        <input type="text" class="form-control" id="PPrice" runat="server">
     
                    </div>
                <div class="form-group">
                        <label for="PQuantity">Product Quantity</label>
                        <input type="text" class="form-control" id="PQuantity" runat="server">
    
                    </div>
                <div class="form-group">
                        <label for="ExDate">Expriry Date:</label>
                        <input type="date" class="form-control" id="ExDate" runat="server">
    
                    </div>
                <label runat="server" id="ErrMsg" class="text-danger"></label><br />
                <asp:Button Text="  Edit  " class="btn mt-3 btn-warning" runat="server" ID="UpdateBtn" OnClick="UpdateBtn_Click" />
                <asp:Button Text="  Save  " class="btn mt-3 btn-success" runat="server" ID="SaveBtn" OnClick="SaveBtn_Click" />
                <asp:Button Text="  Delete  " class="btn mt-3 btn-danger" runat="server" ID="DeletingBtn" OnClick="DeletingBtn_Click" />
                   
                
            </div> 
            <div class="col-md-8">

                <!--table here-->
                <asp:GridView runat="server" ID="ProductsGV" class="table table-hover" AutoGenerateSelectButton="True" OnSelectedIndexChanged="ProductsGV_SelectedIndexChanged">

                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
