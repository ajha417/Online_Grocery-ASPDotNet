<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="OnlineGrocery.View.Admin.Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Mybody" runat="server">
  <!--  <h1>Dashboard</h1>  -->
    <div class="container-fluid">
        <div class="row" style="height:100px">
            <div class="col-md-3"></div>
            <div class="col-md-8">
                <div class="row mt-3">
                    <div class="col-1"><img src="../../Asset/Images/dashboard.png" class="rounded-4" style="height:50px;width:50px"/></div>
                    <div class="col-8"><h2 class="text-danger">Grocery DashBoard</h2></div>
                </div>
                

            </div>
            <div class="col-md-1"></div>
        </div>
        <div class = "row">
            <div class ="col-1">.</div>
            <div class="col-10">
                <div class="row">
                    <div class="col-md-3 bg-danger rounded-4">
                        <div class="row">
                            <div class="col-md-3"><img src="../../Asset/Images/clipboard.png" style="height:30px;width:30px"/></div>
                        <div class="col-md-5">
                            <h3 class="text-white">Products</h3>
                            <h1 class="text-white" runat="server" id="PNumTb">Num</h1>
                        </div> 
                        </div>
                    </div>
                    <div class="col-md-1 bg-light">
                        
                    </div>
                    <div class="col-md-3 bg-warning rounded-4">
                        <div class="row">
                            <div class="col-md-3"><img src="../../Asset/Images/catu.png"  style="height:30px;width:30px;/></div>
                        <div class="col-md-3">
                            <h3 class="text-white">Categories</h3>
                            <h1 class="text-white" runat="server" id="CatNumTb">Num</h1>
                        </div> 
                        </div>
                    </div>
                    <div class="col-md-1 bg-light">
                        
                    </div>
                    <div class="col-md-3 bg-dark rounded-4">
                        <div class="row">
                            <div class="col-md-3"><img src="../../Asset/Images/rupees.jpg" style="height:30px;width:30px"/></div>
                        <div class="col-md-5">
                            <h3 class="text-white">Finance</h3>
                            <h1 class="text-white" runat="server" id="FinanceNumTb">Num</h1>
                        </div> 
                        </div>
                    </div>
                    <div class="col-md-1 bg-light">
                        
                    </div>
                </div>
            </div>
            <div class ="col-1">.</div>
        </div>
        <div class="row mb-5 mt-5"></div>
        <div class = "row">
            <div class ="col-1">.</div>
            <div class="col-10">
                <div class="row">
                            <div class="col">
                                <div class="mb-3" style="width:240px">
                       <asp:DropDownList ID="SellerCb" class="form-control" runat="server" OnSelectedIndexChanged="SellerCb_SelectedIndexChanged"></asp:DropDownList>
                        
                    </div>
                 </div>
                            <div class="col"></div>
                            <div class="col"></div>
                        </div>
                <div class="row">
                    <div class="col-md-3 bg-info rounded-4">
                        
                        <div class="row">
                            <div class="col-md-3"><img src="../../Asset/Images/clipboard.png" style="height:30px;width:30px"/></div>
                        <div class="col-md-5">

                            <h6 class="text-white">Categories Amount</h6>
                            <h1 class="text-white" runat="server" id="CatAmtNumTb">Num</h1>
                        </div> 
                        </div>
                    </div>
                    <div class="col-md-1 bg-light">
                        
                    </div>
                    <div class="col-md-3 bg-secondary rounded-4">
                        <div class="row">
                            <div class="col-md-2"><img src="../../Asset/Images/catu.png"  style="height:30px;width:30px;/></div>
                        <div class="col-md-5">
                            <h6 class="text-white">Total Sells</h6>
                            <h1 class="text-white" runat="server" id="TotalSellsNumTb">Num</h1>
                        </div> 
                        </div>
                    </div>
                    <div class="col-md-1 bg-light">
                        
                    </div>
                    <div class="col-md-3 bg-success rounded-4">
                        <div class="row">
                            <div class="col-md-3"><img src="../../Asset/Images/rupees.jpg" style="height:30px;width:30px"/></div>
                        <div class="col-md-5">
                            <h6 class="text-white">Sellers</h6>
                            <h1 class="text-white" runat="server" id="SellersNumTb">Num</h1>
                        </div> 
                        </div>
                    </div>
                    <div class="col-md-1 bg-light">
                        
                    </div>
                </div>
            </div>
            <div class ="col-1">.</div>
        </div>
        </div>
        <div class="row mt-5">
            <div class="col-4"></div>
            <div class="col-4">
                <img src="../../Asset/Images/onlinegrocery.jpg" style="height:250px;width:500px" />
            </div>
            <div class="col-4"></div>
        </div>

    </div>
</asp:Content>

