<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="SendNotification.aspx.cs" Inherits="GoCollegeWebApp.SendNotification" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <br />
    <!--banner-->
    <div class="banner">

        <h2>
            <a href="index.html">Home</a>
            <i class="fa fa-angle-right"></i>
            <span>Send Notification</span>
        </h2>
    </div>

    <br />


    <div class="row">

        <div class="col-md-12 form-group1 ">
            <label class="control-label">To</label>
            <asp:DropDownList ID="ddlNotificationTo" runat="server">
                <asp:ListItem Text="----Select----" Value=""></asp:ListItem>
            </asp:DropDownList>
        </div>

        <div class="col-md-12 form-group1 ">
            <label class="control-label">Subject</label>
            <asp:TextBox ID="txtNotificationSubject" runat="server" placeholder="Subject" required=""></asp:TextBox>
        </div>

        <div class="col-md-12 form-group1 ">
            <label class="control-label">Notification Message</label>
            <asp:TextBox ID="txtNotificationMessage" runat="server" TextMode="multiline" Columns="100" Rows="10" placeholder="Message" required=""></asp:TextBox>
        </div>

        <div class="col-md-12 form-group ">
            <asp:Button ID="btnNotificationSubmit" runat="server" Text="Submit" class="btn btn-primary" OnClick="btnNotificationSubmit_Click" />
            &nbsp

           <button type="reset" class="btn btn-default">Reset</button>
        </div>
        <div class="col-md-12 form-group1 ">
            <asp:Label ID="lblErrorMsg" runat="server"></asp:Label>
        </div>

        <div class="clearfix"></div>

    </div>

</asp:Content>
