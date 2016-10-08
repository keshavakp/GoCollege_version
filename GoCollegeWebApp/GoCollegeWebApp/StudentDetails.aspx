<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="StudentDetails.aspx.cs" Inherits="GoCollegeWebApp.StudentDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />
    <!--banner-->
    <div class="banner">

        <h2>
            <a href="#">Home</a>
            <i class="fa fa-angle-right"></i>
            <span>Student Details</span>

            <asp:LinkButton ID="lnkbtnAdd" runat="server" OnClick="lnkAddNewStudent">Add New</asp:LinkButton>
            <asp:LinkButton ID="lnkbtnView" runat="server" OnClick="lnkViewAll">View All</asp:LinkButton>

        </h2>
    </div>

    <br />

    <div class="text-left">
        <asp:Label ID="errMsg" CssClass="errMsg" Text="" runat="server"> </asp:Label>
    </div>

    <%--OnSelectedIndexChanged="dgCourseDetails_SelectedIndexChanged"--%>
    <%-- OnPageIndexChanged="dgCourse_PageIndexChanged"--%>
    <div id="divDataGrid" class="row text-center" style="" runat="server">
        <asp:DataGrid Width="100%" BorderColor="White" ID="dgStudentDetails" runat="server"
            AutoGenerateColumns="False"
            AllowSorting="True" UseAccessibleHeader="True" PagerStyle-Mode="NumericPages"
            PagerStyle-Font-Bold="true" PagerStyle-CssClass="td_bd_1a">
            <HeaderStyle CssClass="HeaderTextContent" />
            <ItemStyle CssClass="MainTextContent" />
            <AlternatingItemStyle CssClass="MainTextContent" />
            <Columns>
                <asp:TemplateColumn HeaderStyle-Wrap="false" HeaderStyle-ForeColor="black" HeaderText="USN" SortExpression="USNNum" HeaderStyle-CssClass="HeaderTextContent" ItemStyle-CssClass="MainTextContent">
                    <ItemTemplate>
                        <asp:Label ID="lblStudentUSN" Text='<%#Eval("StudentUSN")%>' runat="server" CssClass="lblColor"></asp:Label>
                        <asp:Label ID="lblHiddenColoumn" runat="server" Visible="false"></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle Wrap="False" CssClass="HeaderTextContent" ForeColor="White"></HeaderStyle>

                    <ItemStyle CssClass="MainTextContent"></ItemStyle>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="Name" HeaderStyle-ForeColor="White" SortExpression="StudName" HeaderStyle-CssClass="HeaderTextContent" ItemStyle-CssClass="MainTextContent" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblStudentName" Text='<%#Eval("StudentName")%>' CssClass="lblColor" runat="server"></asp:Label>
                    </ItemTemplate>

                    <HeaderStyle CssClass="HeaderTextContent" ForeColor="White"></HeaderStyle>

                    <ItemStyle HorizontalAlign="Center" CssClass="MainTextContent"></ItemStyle>
                </asp:TemplateColumn>


                <asp:TemplateColumn HeaderText="Course" HeaderStyle-ForeColor="White" SortExpression="StuentName" HeaderStyle-CssClass="HeaderTextContent" ItemStyle-CssClass="MainTextContent" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblStudentCourse" Text='<%#Eval("CourseShortName")%>' CssClass="lblColor" runat="server"></asp:Label>
                    </ItemTemplate>

                    <HeaderStyle CssClass="HeaderTextContent" ForeColor="White"></HeaderStyle>

                    <ItemStyle HorizontalAlign="Center" CssClass="MainTextContent"></ItemStyle>
                </asp:TemplateColumn>

                <asp:TemplateColumn HeaderText="Sem" HeaderStyle-ForeColor="White" SortExpression="StuentName" HeaderStyle-CssClass="HeaderTextContent" ItemStyle-CssClass="MainTextContent" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblStudentSem" Text='<%#Eval("SemNumber")%>' CssClass="lblColor" runat="server"></asp:Label>
                    </ItemTemplate>

                    <HeaderStyle CssClass="HeaderTextContent" ForeColor="White"></HeaderStyle>

                    <ItemStyle HorizontalAlign="Center" CssClass="MainTextContent"></ItemStyle>
                </asp:TemplateColumn>

                <asp:TemplateColumn HeaderText="Mobile" HeaderStyle-ForeColor="White" SortExpression="MobileNum" HeaderStyle-CssClass="HeaderTextContent" ItemStyle-CssClass="MainTextContent" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblStudentMobile" Text='<%#Eval("StudentMobile")%>' CssClass="lblColor" runat="server"></asp:Label>
                    </ItemTemplate>

                    <HeaderStyle CssClass="HeaderTextContent" ForeColor="White"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center" CssClass="MainTextContent"></ItemStyle>
                </asp:TemplateColumn>

                <asp:TemplateColumn HeaderText="Email" HeaderStyle-ForeColor="White" SortExpression="EmailID" HeaderStyle-CssClass="HeaderTextContent" ItemStyle-CssClass="MainTextContent" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblStudentEmail" Text='<%#Eval("StudentEmail")%>' CssClass="lblColor" runat="server"></asp:Label>
                    </ItemTemplate>

                    <HeaderStyle CssClass="HeaderTextContent" ForeColor="White"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center" CssClass="MainTextContent"></ItemStyle>
                </asp:TemplateColumn>

                <asp:TemplateColumn HeaderText="Address" HeaderStyle-ForeColor="White" SortExpression="StudAddress" HeaderStyle-CssClass="HeaderTextContent" ItemStyle-CssClass="MainTextContent" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblStudentAddress" Text='<%#Eval("StudentAddress")%>' CssClass="lblColor" runat="server"></asp:Label>
                    </ItemTemplate>

                    <HeaderStyle CssClass="HeaderTextContent" ForeColor="White"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center" CssClass="MainTextContent"></ItemStyle>
                </asp:TemplateColumn>

                <%--<asp:TemplateColumn HeaderText="Course" HeaderStyle-ForeColor="White" SortExpression="Language" HeaderStyle-CssClass="HeaderTextContent" ItemStyle-CssClass="MainTextContent" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblStudentCourse" Text='<%#Eval("StudentCourse")%>' CssClass="lblColor" runat="server"></asp:Label>
                    </ItemTemplate>

                    <HeaderStyle CssClass="HeaderTextContent" ForeColor="White"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center" CssClass="MainTextContent"></ItemStyle>
                </asp:TemplateColumn>

                <asp:TemplateColumn HeaderText="Semester" HeaderStyle-ForeColor="White" SortExpression="Language" HeaderStyle-CssClass="HeaderTextContent" ItemStyle-CssClass="MainTextContent" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblStudentSem" Text='<%#Eval("StudentSem")%>' CssClass="lblColor" runat="server"></asp:Label>
                    </ItemTemplate>

                    <HeaderStyle CssClass="HeaderTextContent" ForeColor="White"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center" CssClass="MainTextContent"></ItemStyle>
                </asp:TemplateColumn>--%>



                <%-- Edit and Delete --%>
                <asp:TemplateColumn HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="HeaderTextContent" ItemStyle-CssClass="MainTextContent">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkbtnEdit" runat="server"
                            CommandName='<%#DataBinder.Eval(Container.DataItem,"StudentID")%>'
                            OnCommand="btnStudentEdit_Command" CausesValidation="false" class="lblColor">  <i class="fa fa-pencil-square-o"></i></asp:LinkButton>
                    </ItemTemplate>
                    <HeaderStyle CssClass="HeaderTextContent"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center" CssClass="MainTextContent"></ItemStyle>
                </asp:TemplateColumn>

                <asp:TemplateColumn HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="HeaderTextContent" ItemStyle-CssClass="MainTextContent">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkbtnDelete" runat="server"
                            CommandName='<%#DataBinder.Eval(Container.DataItem,"StudentID")%>'
                            OnCommand="btnStudentDelete_Command" CausesValidation="false" class="lblColor" OnClientClick="return confirm('Are you sure you want to delete this event?');">  <i class="fa fa-trash-o"></i></asp:LinkButton>
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
            <label class="control-label">USN</label>
            <asp:TextBox ID="txtstudentUSN" runat="server" placeholder="Student USN" required="" CssClass="form-control"></asp:TextBox>
            <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Enter Valid USN" ControlToValidate="txtstudentUSN" Font-Size="Smaller" ForeColor="Red" ValidationExpression="[0-9]+"></asp:RegularExpressionValidator>--%>
        </div>
        <div class="clearfix"></div>

        <br />

        <div class="col-md-12 form-group1 ">
            <label class="control-label">Course</label>
            <asp:DropDownList CssClass="form-control" ID="ddlstudentCourse" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlstudentSem_SelectedIndexChanged">
            </asp:DropDownList>
        </div>
        <div class="clearfix"></div>

        <br />

        <div class="col-md-12 form-group1 ">
            <label class="control-label">Semester</label>
            <asp:DropDownList ID="ddlstudentSemester" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>
        <div class="clearfix"></div>
        <br />


        <div class="col-md-12 form-group1 ">
            <label class="control-label">Student Password</label>
            <asp:TextBox ID="txtstudentPassword" TextMode="Password" runat="server" placeholder="Student Password" required="" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="clearfix"></div>
        <br />
        <div class="col-md-12 form-group ">
            <asp:Button ID="btnStudentAdd" runat="server" Text="Submit" class="btn btn-primary" OnClick="btnStudentAddSubmit_Click" />
            &nbsp

           <button type="reset" class="btn btn-default">Reset</button>
        </div>
        <div class="clearfix"></div>

    </div>


    <div class="row" id="divEdit" runat="server">
        <div class="col-md-12 form-group1 ">
            <label class="control-label">USN</label>
            <asp:TextBox ID="txteditStudentUSN" runat="server" placeholder="Student USN" required="" CssClass="form-control"></asp:TextBox>
            <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Enter Valid USN" ControlToValidate="txtstudentUSN" Font-Size="Smaller" ForeColor="Red" ValidationExpression="[0-9]+"></asp:RegularExpressionValidator>--%>
        </div>
        <div class="clearfix"></div>

        <div class="col-md-12 form-group1 ">
            <label class="control-label">Student Name</label>
            <asp:TextBox ID="txteditStudentName" runat="server" placeholder="Student Name" required="" CssClass="form-control"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegExpstudentName" runat="server" ErrorMessage="Enter Valid Name" ControlToValidate="txteditStudentName" Font-Size="Smaller" ForeColor="Red" ValidationExpression="[A-za-z]+[]*[A-Za-z]*[]*[A-Za-z]*[]*[A-Za-z]*[]*[A-Za-z]*"></asp:RegularExpressionValidator>
        </div>
        <div class="clearfix"></div>

        <div class="col-md-12 form-group1 ">
            <label class="control-label">Course</label>
            <asp:DropDownList runat="server" ID="ddleditStudentCourse" CssClass="form-control"></asp:DropDownList>
        </div>
        <div class="clearfix"></div>


        <div class="col-md-12 form-group1 ">
            <label class="control-label">Semester</label>
            <asp:DropDownList runat="server" ID="ddltxtStudentSemester" CssClass="form-control"></asp:DropDownList>
        </div>
        <div class="clearfix"></div>

        <div class="col-md-12 form-group1 ">
            <label class="control-label">Student Mobile</label>
            <asp:TextBox ID="txteditStudentMobile" runat="server" placeholder="Student Mobile" required="" CssClass="form-control"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Enter Valid Mobile Number" ControlToValidate="txteditStudentMobile" Font-Size="Smaller" ForeColor="Red" ValidationExpression="[0-9]{10}"></asp:RegularExpressionValidator>
        </div>
        <div class="clearfix"></div>

        <div class="col-md-12 form-group1 ">
            <label class="control-label">Student Email</label>
            <asp:TextBox ID="txteditStudentEmail" runat="server" placeholder="Student Mobile" required="" CssClass="form-control"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegExpStudentEmail" runat="server" ErrorMessage="Enter Valid Email Address" ControlToValidate="txteditStudentEmail" Font-Size="Smaller" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        </div>


        <div class="col-md-12 form-group1 ">
            <label class="control-label">Student Address</label>
            <asp:TextBox ID="txteditStudentAddress" runat="server" TextMode="MultiLine" placeholder="Student Address" required="" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="col-md-12 form-group ">
            <asp:Button ID="btneditUpdate" runat="server" Text="Submit" class="btn btn-primary" OnClick="btneditUpdate_Click" />
            &nbsp

           <button type="reset" class="btn btn-default">Reset</button>
        </div>
        <div class="clearfix"></div>






        <div class="clearfix"></div>
    </div>
</asp:Content>
