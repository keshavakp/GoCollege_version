<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="EditCollege.aspx.cs" Inherits="GoCollegeWebApp.EditCollege" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />
    <!--banner-->
    <div class="banner">

        <h2>
            <a href="index.html">Home</a>
            <i class="fa fa-angle-right"></i>
            <span>Edit College Details</span>
        </h2>
    </div>

    <br />


    <div class="row">

        <div class="col-md-12 form-group1 ">
            <label class="control-label">Name</label>
            <asp:TextBox ID="collegeName" runat="server" placeholder="Firstname" required=""></asp:TextBox>
        </div>

        <div class="col-md-12 form-group1 ">
            <label class="control-label">Email</label>
            <asp:TextBox ID="collgeEmail" runat="server" placeholder="College Email Address" required=""></asp:TextBox>
        </div>

        <div class="col-md-12 form-group1 ">
            <label class="control-label">Phone Number</label>
            <asp:TextBox ID="collegePhone" runat="server" placeholder="Phone Number" required=""></asp:TextBox>
        </div>


        <div class="col-md-12 form-group1 ">
            <label class="control-label">Mobile Number</label>
            <asp:TextBox ID="collegeMobile" runat="server" placeholder="Mobile Number" required=""></asp:TextBox>
        </div>

        <div class="col-md-12 form-group1 ">
            <label class="control-label">Address</label>
            <asp:TextBox ID="collegeAddress" TextMode="MultiLine" runat="server" placeholder="Full Address" required=""></asp:TextBox>
        </div>

        <div class="col-md-12 form-group ">
            <asp:Button ID="collegebtnSubmit" runat="server" Text="Submit" class="btn btn-primary" OnClick="collegebtnSubmit_Click" />
            &nbsp

           <button type="reset" class="btn btn-default">Reset</button>
        </div>
        <div class="clearfix"></div>




    </div>



</asp:Content>
