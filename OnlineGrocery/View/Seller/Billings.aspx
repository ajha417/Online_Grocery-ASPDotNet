<%@ Page Title="" Language="C#" MasterPageFile="~/View/Seller/SellerMasterPage.Master" AutoEventWireup="true" CodeBehind="Billings.aspx.cs" Inherits="OnlineGrocery.View.Seller.Billings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javasricpt">
        function PrintPanel(){
         var PGrid = document.getElementById('<%=BillGV.ClientID %>');
         PGrid.border = 0;
         var Pwin = window.open('','PrintGrid','left=100,top=100,width=1024,height=768,tollbar=0,scrollbars=1,status=0,resizable=1');
        Pwin.document.write(PGrid.outerHTML);
        Pwin.document.close();
        Pwin.focus();
        Pwin.print();
        Pwin.close();
        
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Mybody" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-5">
                <div class="row"> 
                    <div class="row">
                    <div class="col">
                        <div class="mb-3">
                            <label for="PNameTb">Product Name</label>
                            <input type="text" class="form-control" id="PNameTb" runat="server" required="required">
                        </div>

                        <div class="mb-3">
                            <label for="PrPriceTb">Product Price</label>
                            <input type="text" class="form-control" id="PrPriceTb" runat="server" required="required">
                        </div>

                        <div class="mb-3">
                            <label for="PrQtyTb">Product Qty.</label>
                            <input type="text" class="form-control" id="PrQtyTb" runat="server" required="required">
                        </div>
                    </div>
                </div>
                    <div class="col">
                        <img src="../../Asset/Images/checkdollar.jpg" style="height:150px;width:150px"/>
                        <label runat="server" id="ErrMsg" class="text-danger"></label><br />
                        <asp:Button Text="Add To Bill" class="btn mt-3 btn-warning" runat="server" ID="AddToBill" OnClick="AddToBill_Click" />
                        <asp:Button Text="Reset" class="btn mt-3 btn-success" runat="server" ID="ResetBtn" />
                    </div>
                </div>
                <div class="row">
                    <div class="col">
                        <asp:GridView runat="server" ID="ProductsGV" class="table table-hover" AutoGenerateSelectButton="True" OnSelectedIndexChanged="ProductsGV_SelectedIndexChanged">

                        </asp:GridView>
                    </div>
                </div>
            </div>
            <div class="col-md-7">
                <div class="row">
                    <div class="col-3"></div>
                    <div class="col"><h1 class="text-warning pl-lg-2">Client Billing</h1></div>
                </div>
                <div class="row">
                    <asp:GridView ID="BillGV" runat="server" class="table" CellPadding="4" ForeColor="#333333" GridLines="None">
                        <AlternatingRowStyle BackColor="White" />
                        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                        <SortedAscendingCellStyle BackColor="#FDF5AC" />
                        <SortedAscendingHeaderStyle BackColor="#4D0000" />
                        <SortedDescendingCellStyle BackColor="#FCF6C0" />
                        <SortedDescendingHeaderStyle BackColor="#820000" />

                    </asp:GridView>
                </div>
                <div class="row">
                    <div class="col"></div>
                    <div class="col"><h3 id="grandTotalTb" class="text-danger" runat="server"></h3></div>
                    <div class="col d-grid"><input type="button" id="btnExport"  value="Print" /></div>
                </div>
                <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
                <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.22/pdfmake.min.js"></script>
                <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/html2canvas/0.4.1/html2canvas.min.js"></script>
                <script>
                    $("body").on("click", "#btnExport", function () {
                        html2canvas($('[id*=BillGV]')[0], {
                            onrendered: function (canvas) {
                                var data = canvas.toDataURL();
                                var docDefinition = {
                                    content: [{
                                        image: data,
                                        width: 500
                                    }]
                                };
                                pdfMake.createPdf(docDefinition).download("Table.pdf");
                            }
                        });
                    });

                </script>
            </div>
        </div>
    </div>
</asp:Content>
