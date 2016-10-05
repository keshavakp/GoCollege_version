<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="StudentAttendence.aspx.cs" Inherits="GoCollegeWebApp.StudentAttendence" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--banner-->

    <%--  <div class="banner">
        <h2>
            <a href="#">Home</a>
            <i class="fa fa-angle-right"></i>
            <span>Student Attendence</span>
           <%-- <asp:LinkButton ID="lnkbtnAdd" runat="server" OnClick="lnkAddNewFaculty">Add New</asp:LinkButton>
            <asp:LinkButton ID="lnkbtnView" runat="server" OnClick="lnkViewAll">View All</asp:LinkButton>
        </h2>
    
    </div>--%>

    <div class="text-left">
        <asp:Label ID="errMsg" CssClass="errMsg" Text="" runat="server"> </asp:Label>
    </div>


    <div class="row">

        <div class="col-lg-3">
            <label class="control-label">From Date</label>
            <asp:TextBox ID="txtFrmDate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
        </div>

        <div class="col-lg-2">
            <label class="control-label">Course</label>
            <asp:DropDownList CssClass="form-control" ID="ddlstudentCourse" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlstudentCourse_SelectedIndexChanged">
            </asp:DropDownList>
        </div>
        <div class="col-lg-2">
            <label class="control-label">Semester</label>
            <asp:DropDownList CssClass="form-control" ID="ddlstudentSemester" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlstudentSem_SelectedIndexChanged">
            </asp:DropDownList>

        </div>
        <div class="col-lg-3">
            <label class="control-label">Subject</label>
            <asp:DropDownList CssClass="form-control" ID="ddlSubject" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlstudentSubject_SelectedIndexChanged">
            </asp:DropDownList>

        </div>
        <div class="col-lg-2">
            <label class="control-label">Section</label>
            <asp:DropDownList CssClass="form-control" ID="ddlSection" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlstudentSection_SelectedIndexChanged">
            </asp:DropDownList>

        </div>
    </div>

    <div class="row">

        <div class="col-lg-3">
            <label class="control-label">To Date</label>
            <asp:TextBox ID="txtToDate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
        </div>
    </div>


    <br />

    <div id="divDataGrid" class="row text-center" style="" runat="server">
        <asp:DataGrid Width="100%" BorderColor="White" ID="dgStudentAttendenceDetails" runat="server"
            AutoGenerateColumns="False"
            AllowSorting="True" UseAccessibleHeader="True" PagerStyle-Mode="NumericPages"
            PagerStyle-Font-Bold="true" PagerStyle-CssClass="td_bd_1a">
            <HeaderStyle CssClass="HeaderTextContent" />
            <ItemStyle CssClass="MainTextContent" />
            <AlternatingItemStyle CssClass="MainTextContent" />
            <Columns>

                <asp:TemplateColumn HeaderStyle-Wrap="false" HeaderStyle-ForeColor="black" HeaderText="USN" SortExpression="FCode" HeaderStyle-CssClass="HeaderTextContent" ItemStyle-CssClass="MainTextContent">
                    <ItemTemplate>
                        <asp:Label ID="lblstudentUSN" Text='<%#Eval("StudentUSN")%>' runat="server" CssClass="lblColor"></asp:Label>
                        <asp:Label ID="lblstdID" runat="server" Visible="false"></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle Wrap="False" CssClass="HeaderTextContent" ForeColor="White"></HeaderStyle>

                    <ItemStyle CssClass="MainTextContent"></ItemStyle>
                </asp:TemplateColumn>

                <asp:TemplateColumn HeaderText="Student Name" HeaderStyle-ForeColor="White" SortExpression="StuentName" HeaderStyle-CssClass="HeaderTextContent" ItemStyle-CssClass="MainTextContent" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblstdName" Text='<%#Eval("StudentName")%>' CssClass="lblColor" runat="server"></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle CssClass="HeaderTextContent" ForeColor="White"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center" CssClass="MainTextContent"></ItemStyle>
                </asp:TemplateColumn>


                <asp:TemplateColumn HeaderStyle-Wrap="false" HeaderStyle-ForeColor="black" HeaderText="Attended" SortExpression="FCode" HeaderStyle-CssClass="HeaderTextContent" ItemStyle-CssClass="MainTextContent">
                    <ItemTemplate>
                        <asp:Label ID="lblCourseName" Text='<%#Eval("Attended")%>' runat="server" CssClass="lblColor"></asp:Label>
                        <asp:Label ID="lblCourseID" runat="server" Visible="false"></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle Wrap="False" CssClass="HeaderTextContent" ForeColor="White"></HeaderStyle>

                    <ItemStyle CssClass="MainTextContent"></ItemStyle>
                </asp:TemplateColumn>



                <%--    <asp:TemplateColumn HeaderText="Total Subjects" HeaderStyle-ForeColor="White" SortExpression="" HeaderStyle-CssClass="HeaderTextContent" ItemStyle-CssClass="MainTextContent" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblSemTotalSubjects" Text='<%#Eval("SemTotalSubjects")%>' CssClass="lblColor" runat="server"></asp:Label>
                    </ItemTemplate>

                    <HeaderStyle CssClass="HeaderTextContent" ForeColor="White"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center" CssClass="MainTextContent"></ItemStyle>
                </asp:TemplateColumn>--%>


                <%-- Edit and Delete --%>
                <%--                <asp:TemplateColumn HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="HeaderTextContent" ItemStyle-CssClass="MainTextContent">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkbtnEdit" runat="server"
                            CommandName='<%#DataBinder.Eval(Container.DataItem,"SemID")%>'
                            OnCommand="btnSemestertEdit_Command" CausesValidation="false" class="lblColor">  <i class="fa fa-pencil-square-o"></i></asp:LinkButton>
                    </ItemTemplate>
                    <HeaderStyle CssClass="HeaderTextContent"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center" CssClass="MainTextContent"></ItemStyle>
                </asp:TemplateColumn>

                <asp:TemplateColumn HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="HeaderTextContent" ItemStyle-CssClass="MainTextContent">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkbtnDelete" runat="server"
                            CommandName='<%#DataBinder.Eval(Container.DataItem,"SemID")%>'
                            OnCommand="btnSemesterDelete_Command" CausesValidation="false" class="lblColor" OnClientClick="return confirm('Are you sure you want to delete this event?');">  <i class="fa fa-trash-o"></i></asp:LinkButton>
                    </ItemTemplate>
                    <HeaderStyle CssClass="HeaderTextContent"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center" CssClass="MainTextContent"></ItemStyle>
                </asp:TemplateColumn>--%>
            </Columns>

            <PagerStyle Mode="NumericPages" CssClass="td_bd_1a" Font-Bold="True"></PagerStyle>

            <SelectedItemStyle BackColor="Red" />
        </asp:DataGrid>


    </div>


</asp:Content>
