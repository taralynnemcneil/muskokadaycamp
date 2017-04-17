<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CamperAttendance.aspx.cs" Inherits="MuskokaCamp.Parent.CamperAttendence" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    

    <!-- ============= MAIN ============= -->
    <main class="container">

        <section class="tableTitle">
            <h2>Camper Attendance</h2>
            <h3>
                <span class="lblstrong pull-right">
                    <!-- Day of Week -->
                    <asp:Label ID="currentDate" runat="server"></asp:Label>, 
                    <!-- Month Day, Year -->
                    <asp:Label ID="currentDate2" runat="server"></asp:Label>
                </span>
            </h3>
        </section>

        <!-- Gridview Table -->
        <div class="table-responsive">
            <asp:GridView ID="grdCampers" runat="server" CssClass="table table-striped table-hover" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="camperID" HeaderText="ID" Visible="false" />
                    <asp:BoundField DataField="familyName" HeaderText="FAMILY NAME" HeaderStyle-CssClass="table-header" />
                    <asp:BoundField DataField="firstName" HeaderText="CAMPER NAME" HeaderStyle-CssClass="table-header" />
                    <asp:ButtonField HeaderText="Sign In" HeaderStyle-CssClass="table-header" Text="Sign In" />
                    <asp:ButtonField HeaderText="Sign Out" HeaderStyle-CssClass="table-header" Text="Sign Out" />
                </Columns>
            </asp:GridView>
        </div>
    </main>
    <!-- ============= END MAIN ============= -->
</asp:Content>
