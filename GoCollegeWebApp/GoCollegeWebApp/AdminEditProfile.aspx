<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AdminEditProfile.aspx.cs" Inherits="GoCollegeWebApp.AdminEditProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class=""></div>
    <!--banner-->

    <div class="banner">
        <h2>
            <a href="AdminHome.aspx">Home</a>
            <i class="fa fa-angle-right"></i>
            <span>Edit Profile</span>
        </h2>
    </div>



    <div class="row" id="divEditProfile" runat="server">

        <div class="col-md-12 form-group1 ">
            <label class="control-label">Name</label>
            <asp:TextBox ID="txtName" runat="server" placeholder="Student USN" required="" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="clearfix"></div>

        <br />
        <div class="col-md-12 form-group1 ">
            <label class="control-label">Email</label>
            <asp:TextBox ID="txtEmail" runat="server" placeholder="Student USN" required="" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="clearfix"></div>

        <br />

        <div class="col-md-12 form-group1 ">
            <label class="control-label">Mobile</label>
            <asp:TextBox ID="txtMobile" runat="server" placeholder="Student USN" required="" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="clearfix"></div>

        <br />
       <%-- <div class="col-md-12 form-group1 ">
            <label class="control-label">Old Password</label>
            <asp:TextBox ID="txtoldPassword" TextMode="Password" runat="server" placeholder="Faculty Password" required="" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="clearfix"></div>
        <br />


        <div class="col-md-12 form-group1 ">
            <label class="control-label">New Password</label>
            <asp:TextBox ID="txtNewPassword" TextMode="Password" runat="server" placeholder="Faculty Password" required="" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="clearfix"></div>
        <br />


        <div class="col-md-12 form-group1 ">
            <label class="control-label">Confirm New Password</label>
            <asp:TextBox ID="txtConfirmNewPassword" TextMode="Password" runat="server" placeholder="Faculty Password" required="" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="clearfix"></div>
        <br />--%>

        <div class="col-md-12 form-group ">
            <asp:Button ID="btnupdateProfile" runat="server" Text="Submit" class="btn btn-primary" OnClick="btnAdminUpdate_Click" />
            &nbsp

           <button type="reset" class="btn btn-default">Reset</button>
        </div>
        <div class="clearfix"></div>
    </div>

    <div class="row" id="divEdit" runat="server">
    </div>






</asp:Content>
