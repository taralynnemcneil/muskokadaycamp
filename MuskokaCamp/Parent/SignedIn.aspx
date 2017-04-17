<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SignedIn.aspx.cs" Inherits="MuskokaCamp.Parent.SignedIn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
    <div class="header clearfix">

        <div class="col-md-8 pull-left" id="header-left">

            <div class="col-md-2 nopadd"><img src="../images/logo-white.png" class="img img-responsive logonav" /></div>
            <div class="col-md-8 header-caption"><h5 class="text-muted">MUSKOKA DISCOVERY CENTER<h3 class="text-muted">DAY CAMP PROGRAM</h3></h5></div>

        </div>
        <div class="col-md-4 pull-right">

            <div class="col-md-offset-2 col-md-5 header-caption right-border"><h5 class="text-muted">LOGGED IN AS:<h3 class="text-muted">PARENT</h3></h5></div>
            <div class="col-md-5 header-caption"><h4 class="text-muted"><img src="../images/logout-icon.png"><a href="../Default.aspx"> LOGOUT</a></h4></div>


        </div>


    </div>

    <div class="col-md-12 content">
	    <div class="row">
	    <div class="col-md-6 col-sm-12 col-xs-12"><span class="lblstrong pull-left">Camper Attendance</span></div>
	    <div class="col-md-6 col-sm-12 col-xs-12">
            <span class="lblstrong pull-right">  
                <asp:Label ID="currentDate" runat="server"></asp:Label> |
                <asp:Label ID="currentDate2" runat="server"></asp:Label>
	  	    </span>
	    </div>
	    </div>
        <br />
       

        <!-- Default panel contents -->
        <table class="col-md-12 table-header">
            <tr>
                <th class="col-md-4 table-item">Sign Out</th>
            </tr>
        </table>

        <div class="col-md-offset-3 padd-20 col-md-6">
            
                <div class="form-group">

                    <div class="col-md-6">
                        <asp:Label for="signedOutBy" runat="server" Text="Please Enter Your Name:"></asp:Label>
                    </div>
                    <div class="col-md-6">
                        <asp:TextBox ID="signedOutBy" CssClass="form-control" runat="server" />
                   </div>
                <div class="text-center">
                    <asp:Button ID="signout" runat="server" class="btn btn-primary" Text="Sign Out" OnClick="signout_Click" />
                </div>
              </div>
            
        </div>

    </div>
</div>

</asp:Content>
