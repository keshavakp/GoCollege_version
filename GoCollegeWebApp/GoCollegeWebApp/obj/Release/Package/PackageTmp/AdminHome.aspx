<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AdminHome.aspx.cs" Inherits="GoCollegeWebApp.AdminHome" %>

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
            <span>Menu</span>
        </h2>
    </div>
    
    <div class="clearfix">
    </div>
    <div class="row">

        <div class="col-lg-4">


            <a href="SendNotification.aspx" class="">
                <div class="banner1">
                    <%--<i class="fa fa-envelope"></i>--%>
                    <span>Notifications</span>
                </div>
            </a>


            <a href="#" class="">
                <div class="banner1">
                    <%--<i class="fa fa-envelope"></i>--%>
                    <span>Internals</span>
                </div>
            </a>
            <a href="#" class="">
                <div class="banner1">
                    <%--<i class="fa fa-envelope"></i>--%>
                    <span>Syllabus Copy</span>
                </div>
            </a>

        </div>

        <div class="col-lg-4">
            <a href="StudentAttendence.aspx" class="">
                <div class="banner1">
                    <%--<i class="fa fa-envelope"></i>--%>
                    <span>Attendence</span>
                </div>
            </a>


            <a href="#" class="">
                <div class="banner1">
                    <%--<i class="fa fa-envelope"></i>--%>
                    <span>Notes</span>
                </div>
            </a>

             <a href="#" class="">
                <div class="banner1">
                    <%--<i class="fa fa-envelope"></i>--%>
                    <span>Events</span>
                </div>
            </a>
        </div>

        <div class="col-lg-4">
               <a href="#" class="">
                <div class="banner1">
                    <%--<i class="fa fa-envelope"></i>--%>
                    <span>Time Table</span>
                </div>
            </a>


            <a href="#" class="">
                <div class="banner1">
                    <%--<i class="fa fa-envelope"></i>--%>
                    <span>Question Papers</span>
                </div>
            </a>

             <a href="#" class="">
                <div class="banner1">
                    <%--<i class="fa fa-envelope"></i>--%>
                    <span>Create ID's</span>
                </div>
            </a>
        </div>



    </div>




</asp:Content>
