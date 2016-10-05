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
     <div id="divDataGrid" class="row text-center" style="" runat="server">
        <asp:DataGrid Width="100%" BorderColor="White" ID="dgSemestereDetails" runat="server"
            AutoGenerateColumns="False"
            AllowSorting="True" UseAccessibleHeader="True" PagerStyle-Mode="NumericPages"
            PagerStyle-Font-Bold="true" PagerStyle-CssClass="td_bd_1a">
            <HeaderStyle CssClass="HeaderTextContent" />
            <ItemStyle CssClass="MainTextContent" />
            <AlternatingItemStyle CssClass="MainTextContent" />
            <Columns>
                <asp:TemplateColumn HeaderStyle-Wrap="false" HeaderStyle-ForeColor="black" HeaderText="Course" SortExpression="FCode" HeaderStyle-CssClass="HeaderTextContent" ItemStyle-CssClass="MainTextContent">
                    <ItemTemplate>
                        <asp:Label ID="lblCourseName" Text='<%#Eval("CourseName")%>' runat="server" CssClass="lblColor"></asp:Label>
                        <asp:Label ID="lblCourseID" runat="server" Visible="false"></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle Wrap="False" CssClass="HeaderTextContent" ForeColor="White"></HeaderStyle>

                    <ItemStyle CssClass="MainTextContent"></ItemStyle>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="Sem Number" HeaderStyle-ForeColor="White" SortExpression="FacultyName" HeaderStyle-CssClass="HeaderTextContent" ItemStyle-CssClass="MainTextContent" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblSemNumber" Text='<%#Eval("SemNumber")%>' CssClass="lblColor" runat="server"></asp:Label>
                    </ItemTemplate>

                    <HeaderStyle CssClass="HeaderTextContent" ForeColor="White"></HeaderStyle>

                    <ItemStyle HorizontalAlign="Center" CssClass="MainTextContent"></ItemStyle>
                </asp:TemplateColumn>

                <asp:TemplateColumn HeaderText="Total Subjects" HeaderStyle-ForeColor="White" SortExpression="" HeaderStyle-CssClass="HeaderTextContent" ItemStyle-CssClass="MainTextContent" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblSemTotalSubjects" Text='<%#Eval("SemTotalSubjects")%>' CssClass="lblColor" runat="server"></asp:Label>
                    </ItemTemplate>

                    <HeaderStyle CssClass="HeaderTextContent" ForeColor="White"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center" CssClass="MainTextContent"></ItemStyle>
                </asp:TemplateColumn>

             
                <%-- Edit and Delete --%>
           <%--     <asp:TemplateColumn HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="HeaderTextContent" ItemStyle-CssClass="MainTextContent">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkbtnEdit" runat="server"
                            CommandName='<%#DataBinder.Eval(Container.DataItem,"SemID")%>'
                            OnCommand="btnSemestertEdit_Command" CausesValidation="false" class="lblColor">  <i class="fa fa-pencil-square-o"></i></asp:LinkButton>
                    </ItemTemplate>
                    <HeaderStyle CssClass="HeaderTextContent"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center" CssClass="MainTextContent"></ItemStyle>
                </asp:TemplateColumn>--%>

                <asp:TemplateColumn HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="HeaderTextContent" ItemStyle-CssClass="MainTextContent">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkbtnDelete" runat="server"
                            CommandName='<%#DataBinder.Eval(Container.DataItem,"SemID")%>'
                            OnCommand="btnSemesterDelete_Command" CausesValidation="false" class="lblColor" OnClientClick="return confirm('Are you sure you want to delete this event?');">  <i class="fa fa-trash-o"></i></asp:LinkButton>
                    </ItemTemplate>
                    <HeaderStyle CssClass="HeaderTextContent"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center" CssClass="MainTextContent"></ItemStyle>
                </asp:TemplateColumn>
            </Columns>

            <PagerStyle Mode="NumericPages" CssClass="td_bd_1a" Font-Bold="True"></PagerStyle>

            <SelectedItemStyle BackColor="Red" />
        </asp:DataGrid>


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


      <div class="row" id="divEdit" runat="server">

        <div class="col-md-12 form-group1 ">
            <label class="control-label">Semester Number</label>
            <asp:TextBox ID="txtEditSemNum" runat="server" placeholder="Semester Number" required="" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="clearfix"></div>

        <br />
        <div class="col-md-12 form-group1 ">
            <label class="control-label">Course</label>
            <asp:DropDownList CssClass="form-control" ID="ddlEditCourse" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlstudentSem_SelectedIndexChanged">
            </asp:DropDownList>
        </div>
        <div class="clearfix"></div>

        <br />

        <div class="col-md-12 form-group1 ">
            <label class="control-label">Semester Total Subjects</label>
            <asp:TextBox ID="txtEditSemTotalSubjects" runat="server" placeholder="Total Sujects" required="" CssClass="form-control"></asp:TextBox>

        </div>
        <div class="clearfix"></div>
        <br />

        <div class="col-md-12 form-group ">
            <asp:Button ID="Button1" runat="server" Text="Submit" class="btn btn-primary" OnClick="btnSemesterAddSubmit_Click" />
            &nbsp

           <button type="reset" class="btn btn-default">Reset</button>
        </div>
        <div class="clearfix"></div>

    </div>
</asp:Content>
