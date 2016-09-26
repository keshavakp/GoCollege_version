<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="CourseDetails.aspx.cs" Inherits="GoCollegeWebApp.CourseDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
    <br />
    <!--banner-->
    <div class="banner">

        <h2>
            <a href="#">Manage Academics</a>
            <i class="fa fa-angle-right"></i>
            <span>Course Details</span>
        </h2>
    </div>

    <br />

    <div id="divGridView" class="row" runat="server">
        <asp:DataGrid runat="server" >

        </asp:DataGrid>




    </div>

    <div class="row" id="divAdd" runat="server">

        <div class="col-md-12 form-group1 ">
            <label class="control-label">Course Name</label>
            <asp:TextBox ID="cName" runat="server" placeholder="Course Name" required=""></asp:TextBox>
        </div>

        <div class="col-md-12 form-group1 ">
            <label class="control-label">Course Short Name</label>
            <asp:TextBox ID="collgeEmail" runat="server" placeholder="Course Short Name" required=""></asp:TextBox>
        </div>

        <div class="col-md-12 form-group1 ">
            <label class="control-label">Total No.of Semsters</label>
            <asp:TextBox ID="collegePhone" runat="server" placeholder="Total No.of Semesters" required=""></asp:TextBox>
        </div>

        <div class="col-md-12 form-group ">
           <%-- <asp:Button ID="collegebtnSubmit" runat="server" Text="Submit" class="btn btn-primary" OnClick="collegebtnSubmit_Click" />--%>
            &nbsp

           <button type="reset" class="btn btn-default">Reset</button>
        </div>
        <div class="clearfix"></div>




    </div>

    
</asp:Content>
