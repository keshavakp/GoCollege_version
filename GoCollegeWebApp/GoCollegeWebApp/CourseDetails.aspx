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

    <div id="divDataGrid" class="row" runat="server">
        <asp:DataGrid Width="80%" BorderColor="White" ID="dgCourseDetails" runat="server"
            AutoGenerateColumns="False" OnPageIndexChanged="dgCourse_PageIndexChanged"
            AllowSorting="True" UseAccessibleHeader="True" PagerStyle-Mode="NumericPages"
            PagerStyle-Font-Bold="true" PagerStyle-CssClass="td_bd_1a" OnSelectedIndexChanged="dgCourseDetails_SelectedIndexChanged">
            <HeaderStyle CssClass="HeaderTextContent" />
            <ItemStyle CssClass="MainTextContent" />
            <AlternatingItemStyle CssClass="MainTextContent" />
            <Columns>
                <asp:TemplateColumn HeaderStyle-Wrap="false" HeaderStyle-ForeColor="black" HeaderText="Film" SortExpression="Course Name" HeaderStyle-CssClass="HeaderTextContent" ItemStyle-CssClass="MainTextContent">
                    <ItemTemplate>
                        <asp:Label ID="lblFilmName" Text='<%#Eval("CourseName")%>' runat="server"></asp:Label>
                        <asp:Label ID="lblHiddenColoumn" runat="server" Visible="false"></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle Wrap="False" CssClass="HeaderTextContent" ForeColor="White"></HeaderStyle>

                    <ItemStyle CssClass="MainTextContent"></ItemStyle>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="Short Name" HeaderStyle-ForeColor="White" SortExpression="Language" HeaderStyle-CssClass="HeaderTextContent" ItemStyle-CssClass="MainTextContent" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblLanguage" Text='<%#Eval("CourseShortName")%>' runat="server"></asp:Label>
                    </ItemTemplate>

                    <HeaderStyle CssClass="HeaderTextContent" ForeColor="White"></HeaderStyle>

                    <ItemStyle HorizontalAlign="Center" CssClass="MainTextContent"></ItemStyle>
                </asp:TemplateColumn>

                <asp:TemplateColumn HeaderText="Language" HeaderStyle-ForeColor="White" SortExpression="Language" HeaderStyle-CssClass="HeaderTextContent" ItemStyle-CssClass="MainTextContent" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblLanguage" Text='<%#Eval("CourseTotalSems")%>' runat="server"></asp:Label>
                    </ItemTemplate>

                    <HeaderStyle CssClass="HeaderTextContent" ForeColor="White"></HeaderStyle>

                    <ItemStyle HorizontalAlign="Center" CssClass="MainTextContent"></ItemStyle>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="HeaderTextContent" ItemStyle-CssClass="MainTextContent">
                    <ItemTemplate>
                        <asp:HyperLink ID="btnEdith" runat="server" CommandName='<%#DataBinder.Eval(Container.DataItem,"CourseID")%>'
                            OnCommand="btnEdit_Command" CausesValidation="false" class="btn btn-danger">
                              <i class="fa fa-trash-o fa-lg"></i>
                              Edit</asp:HyperLink>
                    </ItemTemplate>

                    <HeaderStyle CssClass="HeaderTextContent"></HeaderStyle>

                    <ItemStyle HorizontalAlign="Center" CssClass="MainTextContent"></ItemStyle>
                </asp:TemplateColumn>
            </Columns>

            <PagerStyle Mode="NumericPages" CssClass="td_bd_1a" Font-Bold="True"></PagerStyle>

            <SelectedItemStyle BackColor="Red" />
        </asp:DataGrid>


    </div>


    <div class="text-center">
        <asp:Label ID="errMsg" CssClass="errMsg" Text="" runat="server"> </asp:Label>
    </div>
    <div class="row" id="divAdd" runat="server">

        <div class="col-md-12 form-group1 ">
            <label class="control-label">Course Name</label>
            <asp:TextBox ID="cName" runat="server" placeholder="Course Name" required=""></asp:TextBox>
        </div>

        <div class="col-md-12 form-group1 ">
            <label class="control-label">Course Short Name</label>
            <asp:TextBox ID="cShortName" runat="server" placeholder="Course Short Name" required=""></asp:TextBox>
        </div>

        <div class="col-md-12 form-group1 ">
            <label class="control-label">Total No.of Semsters</label>
            <asp:TextBox ID="cNoSems" runat="server" placeholder="Total No.of Semesters" required=""></asp:TextBox>
        </div>

        <div class="col-md-12 form-group ">
            <asp:Button ID="coursebtnSubmit" runat="server" Text="Submit" class="btn btn-primary" OnClick="coursebtnSubmit_Click" />
            &nbsp

           <button type="reset" class="btn btn-default">Reset</button>
        </div>
        <div class="clearfix"></div>




    </div>

    <div class="row" id="divEdit" runat="server">

        <div class="col-md-12 form-group1 ">
            <label class="control-label">Course Name</label>
            <asp:TextBox ID="editcName" runat="server" placeholder="Course Name" required=""></asp:TextBox>
        </div>

        <div class="col-md-12 form-group1 ">
            <label class="control-label">Course Short Name</label>
            <asp:TextBox ID="editcShortName" runat="server" placeholder="Course Short Name" required=""></asp:TextBox>
        </div>

        <div class="col-md-12 form-group1 ">
            <label class="control-label">Total No.of Semsters</label>
            <asp:TextBox ID="editcTotalSems" runat="server" placeholder="Total No.of Semesters" required=""></asp:TextBox>
        </div>

        <div class="col-md-12 form-group ">
            <asp:Button ID="editcoursebtnSubmit" runat="server" Text="Submit" class="btn btn-primary" OnClick="editcoursebtnSubmit_Click" />
            &nbsp

           <button type="reset" class="btn btn-default">Reset</button>
        </div>
        <div class="clearfix"></div>




    </div>


</asp:Content>
