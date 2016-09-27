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

            <asp:LinkButton ID="lnkbtnAdd"  runat="server"  OnClick="lnkAddNewCourse">Add New</asp:LinkButton>      
            <asp:LinkButton ID="lnkbtnView" runat="server" OnClick="lnkViewAll">View All</asp:LinkButton>                          
           
        </h2>
    </div>

    <br />

    <div class="text-left">
        <asp:Label ID="errMsg" CssClass="errMsg" Text="" runat="server"> </asp:Label>
    </div>

    <div id="divDataGrid" class="row text-center" style="padding-left:3em" runat="server">
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
                        <asp:Label ID="lblCourseName" Text='<%#Eval("CourseName")%>' runat="server" CssClass="lblColor"></asp:Label>
                        <asp:Label ID="lblHiddenColoumn" runat="server" Visible="false" ></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle Wrap="False" CssClass="HeaderTextContent" ForeColor="White"></HeaderStyle>

                    <ItemStyle CssClass="MainTextContent"></ItemStyle>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="Short Name" HeaderStyle-ForeColor="White" SortExpression="Language" HeaderStyle-CssClass="HeaderTextContent" ItemStyle-CssClass="MainTextContent" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblCourseShortName" Text='<%#Eval("CourseShortName")%>' CssClass="lblColor" runat="server"></asp:Label>
                    </ItemTemplate>

                    <HeaderStyle CssClass="HeaderTextContent" ForeColor="White"></HeaderStyle>

                    <ItemStyle HorizontalAlign="Center" CssClass="MainTextContent"></ItemStyle>
                </asp:TemplateColumn>

                <asp:TemplateColumn HeaderText="Total Sems" HeaderStyle-ForeColor="White" SortExpression="Language" HeaderStyle-CssClass="HeaderTextContent" ItemStyle-CssClass="MainTextContent" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblCourseTotalSems" Text='<%#Eval("CourseTotalSems")%>' CssClass="lblColor" runat="server"></asp:Label>
                    </ItemTemplate>

                    <HeaderStyle CssClass="HeaderTextContent" ForeColor="White"></HeaderStyle>

                    <ItemStyle HorizontalAlign="Center" CssClass="MainTextContent"></ItemStyle>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="HeaderTextContent" ItemStyle-CssClass="MainTextContent">
                    <ItemTemplate>                        
                        <asp:LinkButton ID="lnkbtnEdit"  runat="server"  
                             CommandName='<%#DataBinder.Eval(Container.DataItem,"CourseID")%>'
                            OnCommand="btnEdit_Command" CausesValidation="false" class="lblColor">  <i class="fa fa-pencil-square-o"></i></asp:LinkButton>    
                    </ItemTemplate>
                    <HeaderStyle CssClass="HeaderTextContent"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center" CssClass="MainTextContent"></ItemStyle>
                </asp:TemplateColumn>

                 <asp:TemplateColumn HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="HeaderTextContent" ItemStyle-CssClass="MainTextContent">
                    <ItemTemplate>                                                
                        <asp:LinkButton ID="lnkbtnDelete"  runat="server" 
                             CommandName='<%#DataBinder.Eval(Container.DataItem,"CourseID")%>'
                            OnCommand="btnDelete_Command" CausesValidation="false" class="lblColor" OnClientClick="return confirm('Are you sure you want to delete this event?');">  <i class="fa fa-trash-o"></i></asp:LinkButton>    
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
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Enter in Number Format" ControlToValidate="cNoSems" Font-Size="Smaller" ForeColor="Red" ValidationExpression="[0-9]+"></asp:RegularExpressionValidator>
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
            <asp:Button ID="editcoursebtnSubmit" runat="server" Text="Update" class="btn btn-primary" OnClick="editcoursebtnSubmit_Click" />
            &nbsp

           <button type="reset" class="btn btn-default">Reset</button>
        </div>
        <div class="clearfix"></div>




    </div>

    <asp:HiddenField ID="hfcourseID" runat="server" />

</asp:Content>
