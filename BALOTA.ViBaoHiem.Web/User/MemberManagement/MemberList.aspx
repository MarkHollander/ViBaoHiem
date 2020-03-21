<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="MemberList.aspx.cs" Inherits="BALOTA.ViBaoHiem.Web.User.MemberManagement.MemberList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <%--<asp:DropDownList ID="MemberSearchDdl" runat="server" CssClass="custom" AutoPostBack="true">   
    </asp:DropDownList>--%>
    <section class="content">
        <div class="card">
            <div class="card-header">
                <h3 class="card-title">jsGrid</h3>
            </div>
            <!-- /.card-header -->
            <div class="card-body">
                <div id="jsGrid1"></div>
            </div>
            <!-- /.card-body -->
        </div>
        <!-- /.card -->
    </section>    
    <!-- jsGrid -->
    <script src="/plugins/jsgrid/demos/db.js"></script>
    <script src="/plugins/jsgrid/jsgrid.min.js"></script>
    <!-- AdminLTE App -->
    <script src="/dist/js/adminlte.min.js"></script>
    <!-- AdminLTE for demo purposes -->
    <script src="/dist/js/demo.js"></script>
    <!-- page script -->
    <script>
        $(document).ready(function () {            
            //$("#MemberSearchDdl").select2({
            //    placeholder: "Select a member",
            //    allowClear: true
            //});
            //let filter = $("#MemberSearchDdl").val();
            $("#jsGrid1").jsGrid({
                height: "100%",
                width: "100%",

                sorting: true,
                paging: true,
                autoload: true,
                pageSize: 10,
                pageButtonCount: 5,
                deleteConfirm: "Do you really want to delete your job listing?",
                controller: {
                    loadData: function () {
                        return $.ajax({
                            type: "GET",
                            url: "../MemberManagement/MemberList.aspx/MemberListLoadData"
                        }).done(function (response) {
                            console.log(response);                            
                        });
                    }
                },
                
                fields: [
                    { name: "Username", type: "text", width: 150, title: "Tên đại lý" },
                    { name: "FullName", type: "text", width: 150, title: "Tên đầy đủ" },
                    { name: "MemberBalance", type: "number", width: 200, title: "Số dư tài khoản" },
                    { name: "OwnerPackageCount", type: "number", width: 50, title: "Số gói" },
                    {
                        type: "control", width: 100, editButton: false, deleteButton: false, title: "Sửa thông tin đại lý",
                        itemTemplate: function (value, item) {
                            //var $result = jsGrid.fields.control.prototype.itemTemplate.apply(this, arguments);

                            var $customEditButton = $("<button>").attr({ class: "customGridEditbutton jsgrid-button jsgrid-edit-button" })
                                .click(function (e) {
                                    alert("ID: " + item.ActiveCode);
                                    e.stopPropagation();
                                });                           

                            return $("<div>").append($customEditButton);
                            //return $result.add($customButton);
                        }
                    },
                    {
                        type: "control", width: 100, editButton: false, deleteButton: false, title: "Xóa đại lý",
                        itemTemplate: function (value, item) {
                            //var $result = jsGrid.fields.control.prototype.itemTemplate.apply(this, arguments);

                            var $customDeleteButton = $("<button>").attr({ class: "customGridEditbutton jsgrid-button jsgrid-delete-button" })
                                .click(function (e) {
                                    alert("ID: " + item.ActiveCode);
                                    e.stopPropagation();
                                });
                            return $("<div>").append($customDeleteButton);                            
                        }
                    }
                ]
            });

            
            
        });
        
</script>

</asp:Content>
