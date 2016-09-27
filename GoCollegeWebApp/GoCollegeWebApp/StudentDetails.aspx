<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="StudentDetails.aspx.cs" Inherits="GoCollegeWebApp.StudentDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div id="divDataGrid" class="row text-center" style="padding-left:3em" runat="server">
        <asp:DataGrid Width="80%" BorderColor="White" ID="dgCourseDetails" runat="server"
            AutoGenerateColumns="False" OnPageIndexChanged="dgCourse_PageIndexChanged"
            AllowSorting="True" UseAccessibleHeader="True" PagerStyle-Mode="NumericPages"
            PagerStyle-Font-Bold="true" PagerStyle-CssClass="td_bd_1a" OnSelectedIndexChanged="dgCourseDetails_SelectedIndexChanged">
            <HeaderStyle CssClass="HeaderTextContent" />
            <ItemStyle CssClass="MainTextContent" />
            <AlternatingItemStyle CssClass="MainTextContent" />
            <Columns>
                <asp:TemplateColumn HeaderStyle-Wrap="false" HeaderStyle-ForeColor="black" HeaderText="USN" SortExpression="Course Name" HeaderStyle-CssClass="HeaderTextContent" ItemStyle-CssClass="MainTextContent">
                    <ItemTemplate>
                        <asp:Label ID="lblStudentUSN" Text='<%#Eval("StudentUSN")%>' runat="server" CssClass="lblColor"></asp:Label>
                        <asp:Label ID="lblHiddenColoumn" runat="server" Visible="false" ></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle Wrap="False" CssClass="HeaderTextContent" ForeColor="White"></HeaderStyle>

                    <ItemStyle CssClass="MainTextContent"></ItemStyle>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="Name" HeaderStyle-ForeColor="White" SortExpression="Language" HeaderStyle-CssClass="HeaderTextContent" ItemStyle-CssClass="MainTextContent" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblStudentName" Text='<%#Eval("StudentName")%>' CssClass="lblColor" runat="server"></asp:Label>
                    </ItemTemplate>

                    <HeaderStyle CssClass="HeaderTextContent" ForeColor="White"></HeaderStyle>

                    <ItemStyle HorizontalAlign="Center" CssClass="MainTextContent"></ItemStyle>
                </asp:TemplateColumn>

                <asp:TemplateColumn HeaderText="Mobile" HeaderStyle-ForeColor="White" SortExpression="Language" HeaderStyle-CssClass="HeaderTextContent" ItemStyle-CssClass="MainTextContent" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblCourseTotalSems" Text='<%#Eval("StudentMobile")%>' CssClass="lblColor" runat="server"></asp:Label>
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




</asp:Content>
