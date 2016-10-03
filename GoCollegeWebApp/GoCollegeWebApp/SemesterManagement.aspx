<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="SemesterManagement.aspx.cs" Inherits="GoCollegeWebApp.SemesterManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <br />
    <!--banner-->
    <div class="banner">

        <h2>
            <a href="#">Home</a>
            <i class="fa fa-angle-right"></i>
            <span>Semester Management</span>

            <asp:LinkButton ID="lnkbtnAdd" runat="server" OnClick="lnkAddNewSemester">Add New</asp:LinkButton>
            <asp:LinkButton ID="lnkbtnView" runat="server" OnClick="lnkViewAll">View All</asp:LinkButton>

        </h2>
    </div>
    <br />

    <div class="text-left">
        <asp:Label ID="errMsg" CssClass="errMsg" Text="" runat="server"> </asp:Label>
    </div>


    <div class="row" id="divAdd" runat="server">

        <div class="col-md-12 form-group1 ">
            <label class="control-label">Semester Number</label>
            <asp:TextBox ID="txtsemeNum" runat="server" placeholder="Semester Number" required="" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="clearfix"></div>

        <br />
        <div class="col-md-12 form-group1 ">
            <label class="control-label">Course</label>
            <asp:DropDownList CssClass="form-control" ID="ddlCourse" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlstudentSem_SelectedIndexChanged">
            </asp:DropDownList>
        </div>
        <div class="clearfix"></div>

        <br />

        <div class="col-md-12 form-group1 ">
            <label class="control-label">Semester Total Subjects</label>
            <asp:TextBox ID="txtsemTotalSubjects" runat="server" placeholder="Total Sujects" required="" CssClass="form-control"></asp:TextBox>

        </div>
        <div class="clearfix"></div>
        <br />

        <div class="col-md-12 form-group ">
            <asp:Button ID="btnSemesterAdd" runat="server" Text="Submit" class="btn btn-primary" OnClick="btnSemesterAddSubmit_Click" />
            &nbsp

           <button type="reset" class="btn btn-default">Reset</button>
        </div>
        <div class="clearfix"></div>

    </div>

</asp:Content>
