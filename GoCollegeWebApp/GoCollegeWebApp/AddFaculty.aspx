<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AddFaculty.aspx.cs" Inherits="GoCollegeWebApp.AddFaculty" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!--banner-->
    <div class="banner">

        <h2>
            <a href="#">Home</a>
            <i class="fa fa-angle-right"></i>
            <span>Faculty Management</span>

            <asp:LinkButton ID="lnkbtnAdd" runat="server" OnClick="lnkAddNewFaculty">Add New</asp:LinkButton>
            <asp:LinkButton ID="lnkbtnView" runat="server" OnClick="lnkViewAll">View All</asp:LinkButton>

        </h2>
    </div>

    <br />

    <div class="text-left">
        <asp:Label ID="errMsg" CssClass="errMsg" Text="" runat="server"> </asp:Label>
    </div>

    <div id="divDataGrid" class="row text-center" style="" runat="server">
        <asp:DataGrid Width="100%" BorderColor="White" ID="dgFacultyDetails" runat="server"
            AutoGenerateColumns="False"
            AllowSorting="True" UseAccessibleHeader="True" PagerStyle-Mode="NumericPages"
            PagerStyle-Font-Bold="true" PagerStyle-CssClass="td_bd_1a">
            <HeaderStyle CssClass="HeaderTextContent" />
            <ItemStyle CssClass="MainTextContent" />
            <AlternatingItemStyle CssClass="MainTextContent" />
            <Columns>
                <asp:TemplateColumn HeaderStyle-Wrap="false" HeaderStyle-ForeColor="black" HeaderText="Facult yCode" SortExpression="FCode" HeaderStyle-CssClass="HeaderTextContent" ItemStyle-CssClass="MainTextContent">
                    <ItemTemplate>
                        <asp:Label ID="lblFacultyCode" Text='<%#Eval("FacultyCode")%>' runat="server" CssClass="lblColor"></asp:Label>
                        <asp:Label ID="lblHiddenColoumn" runat="server" Visible="false"></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle Wrap="False" CssClass="HeaderTextContent" ForeColor="White"></HeaderStyle>

                    <ItemStyle CssClass="MainTextContent"></ItemStyle>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="Name" HeaderStyle-ForeColor="White" SortExpression="FacultyName" HeaderStyle-CssClass="HeaderTextContent" ItemStyle-CssClass="MainTextContent" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblFacultyName" Text='<%#Eval("FacultyName")%>' CssClass="lblColor" runat="server"></asp:Label>
                    </ItemTemplate>

                    <HeaderStyle CssClass="HeaderTextContent" ForeColor="White"></HeaderStyle>

                    <ItemStyle HorizontalAlign="Center" CssClass="MainTextContent"></ItemStyle>
                </asp:TemplateColumn>

                <asp:TemplateColumn HeaderText="Mobile" HeaderStyle-ForeColor="White" SortExpression="FacultyMobile" HeaderStyle-CssClass="HeaderTextContent" ItemStyle-CssClass="MainTextContent" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblFacultyMobile" Text='<%#Eval("FacultyMobile")%>' CssClass="lblColor" runat="server"></asp:Label>
                    </ItemTemplate>

                    <HeaderStyle CssClass="HeaderTextContent" ForeColor="White"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center" CssClass="MainTextContent"></ItemStyle>
                </asp:TemplateColumn>

                <asp:TemplateColumn HeaderText="Email" HeaderStyle-ForeColor="White" SortExpression="EmailID" HeaderStyle-CssClass="HeaderTextContent" ItemStyle-CssClass="MainTextContent" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblFacultyEmail" Text='<%#Eval("FacultyEmail")%>' CssClass="lblColor" runat="server"></asp:Label>
                    </ItemTemplate>

                    <HeaderStyle CssClass="HeaderTextContent" ForeColor="White"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center" CssClass="MainTextContent"></ItemStyle>
                </asp:TemplateColumn>

                <asp:TemplateColumn HeaderText="Address" HeaderStyle-ForeColor="White" SortExpression="FacultyAddress" HeaderStyle-CssClass="HeaderTextContent" ItemStyle-CssClass="MainTextContent" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblFacultyAddress" Text='<%#Eval("FacultyAddress")%>' CssClass="lblColor" runat="server"></asp:Label>
                    </ItemTemplate>

                    <HeaderStyle CssClass="HeaderTextContent" ForeColor="White"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center" CssClass="MainTextContent"></ItemStyle>
                </asp:TemplateColumn>

                <%-- Edit and Delete --%>
                <asp:TemplateColumn HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="HeaderTextContent" ItemStyle-CssClass="MainTextContent">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkbtnEdit" runat="server"
                            CommandName='<%#DataBinder.Eval(Container.DataItem,"FacultyID")%>'
                            OnCommand="btnFacultytEdit_Command" CausesValidation="false" class="lblColor">  <i class="fa fa-pencil-square-o"></i></asp:LinkButton>
                    </ItemTemplate>
                    <HeaderStyle CssClass="HeaderTextContent"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center" CssClass="MainTextContent"></ItemStyle>
                </asp:TemplateColumn>

                <asp:TemplateColumn HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="HeaderTextContent" ItemStyle-CssClass="MainTextContent">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkbtnDelete" runat="server"
                            CommandName='<%#DataBinder.Eval(Container.DataItem,"FacultyID")%>'
                            OnCommand="btnFacultyDelete_Command" CausesValidation="false" class="lblColor" OnClientClick="return confirm('Are you sure you want to delete this event?');">  <i class="fa fa-trash-o"></i></asp:LinkButton>
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
            <label class="control-label">Employee Code</label>
            <asp:TextBox ID="txtFacultyCode" runat="server" placeholder="Student USN" required="" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="clearfix"></div>

        <br />
        <div class="col-md-12 form-group1 ">
            <label class="control-label">Faculty Password</label>
            <asp:TextBox ID="txtFacultyPassword" TextMode="Password" runat="server" placeholder="Faculty Password" required="" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="clearfix"></div>
        <br />
        <div class="col-md-12 form-group ">
            <asp:Button ID="btnFacultyAdd" runat="server" Text="Submit" class="btn btn-primary" OnClick="btnFacultyAddSubmit_Click" />
            &nbsp

           <button type="reset" class="btn btn-default">Reset</button>
        </div>
        <div class="clearfix"></div>
    </div>

    <div class="row" id="divEdit" runat="server">
        <div class="col-md-12 form-group1 ">
            <label class="control-label">Faculty Code</label>
            <asp:TextBox ID="txteditFacultyCode" runat="server" placeholder="Faculty Code" required="" CssClass="form-control"></asp:TextBox>
            <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Enter Valid USN" ControlToValidate="txtstudentUSN" Font-Size="Smaller" ForeColor="Red" ValidationExpression="[0-9]+"></asp:RegularExpressionValidator>--%>
        </div>
        <div class="clearfix"></div>

        <div class="col-md-12 form-group1 ">
            <label class="control-label">Faculty Name</label>
            <asp:TextBox ID="txteditFacultyName" runat="server" placeholder="Faculty Name" required="" CssClass="form-control"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegExpstudentName" runat="server" ErrorMessage="Enter Valid Name" ControlToValidate="txteditStudentName" Font-Size="Smaller" ForeColor="Red" ValidationExpression="[A-za-z]+[]*[A-Za-z]*[]*[A-Za-z]*[]*[A-Za-z]*[]*[A-Za-z]*"></asp:RegularExpressionValidator>
        </div>
        <div class="clearfix"></div>

        <div class="col-md-12 form-group1 ">
            <label class="control-label">Faculty Mobile</label>
            <asp:TextBox ID="txteditFacultyMobile" runat="server" placeholder="Faculty Mobile" required="" CssClass="form-control"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Enter Valid Mobile Number" ControlToValidate="txteditStudentMobile" Font-Size="Smaller" ForeColor="Red" ValidationExpression="[0-9]{10}"></asp:RegularExpressionValidator>
        </div>
        <div class="clearfix"></div>

        <div class="col-md-12 form-group1 ">
            <label class="control-label">Faculty Email</label>
            <asp:TextBox ID="txteditFacultyEmail" runat="server" placeholder="Faculty Mobile" required="" CssClass="form-control"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegExpStudentEmail" runat="server" ErrorMessage="Enter Valid Email Address" ControlToValidate="txteditStudentEmail" Font-Size="Smaller" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        </div>


        <div class="col-md-12 form-group1 ">
            <label class="control-label">Faculty Address</label>
            <asp:TextBox ID="txteditFacultyAddress" runat="server" TextMode="MultiLine" placeholder="Student Address" required="" CssClass="form-control"></asp:TextBox>
        </div>


        <div class="col-md-12 form-group ">
            <asp:Button ID="btneditUpdate" runat="server" Text="Submit" class="btn btn-primary" OnClick="btneditUpdate_Click" />
            &nbsp

           <button type="reset" class="btn btn-default">Reset</button>
        </div>
        <div class="clearfix"></div>
    </div>

    <asp:Label ID="hffacultyID" Visible="false" runat="server"></asp:Label>
    <%--<asp:HiddenField  />--%>
</asp:Content>
