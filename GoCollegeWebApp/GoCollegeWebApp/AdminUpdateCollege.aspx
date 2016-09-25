<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminUpdateCollege.aspx.cs" Inherits="GoCollegeWebApp.AdminUpdateCollege" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>MYCampuz</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="keywords" content="GoCollege, Collge" />

    <script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); } </script>
    <link href="css/bootstrap.min.css" rel='stylesheet' type='text/css' />
    <!--<link href="css/bootstrap.css" rel='stylesheet' type='text/css' />-->
    <!-- Custom Theme files -->
    <link href="css/style.css" rel='stylesheet' type='text/css' />
    <link href="css/font-awesome.css" rel="stylesheet">
    <script src="js/jquery.min.js"> </script>
    <script src="js/bootstrap.min.js"> </script>

    <!-- Mainly scripts -->
    <script src="js/jquery.metisMenu.js"></script>
    <script src="js/jquery.slimscroll.min.js"></script>
    <!-- Custom and plugin javascript -->
    <link href="css/custom.css" rel="stylesheet">
    <script src="js/custom.js"></script>
    <script src="js/screenfull.js"></script>
    <script>
        $(function () {
            $('#supported').text('Supported/allowed: ' + !!screenfull.enabled);

            if (!screenfull.enabled) {
                return false;
            }



            $('#toggle').click(function () {
                screenfull.toggle($('#container')[0]);
            });



        });


    </script>

    <script type="text/ecmascript">
        function resetAll() {
            document.getElementById("<%= txtCollegeName.ClientID %>").value = "";
        }
    </script>


    <!----->

</head>
<body>
  
    <div class="row">
        <div class="col-lg-2"></div>

        <div class="col-lg-8 ">

            <div class="validation-system">

                <div class="col-lg-2"></div>

                <div class="col-lg-8">

                    <div class="validation-form">
                        <!---->

                        <form id="adminEditDetails" runat="server">


                            <h2 class="text-center" style="color: #d95459">Welcome to MyCampuz</h2>

                            <h3 class="text-center">Update Your College Details </h3>

                            <div class="vali-form">

                                <div class="clearfix"></div>

                                <div class="text-center">
                                    <asp:Label ID="errMsg" CssClass="errMsg" Text="" runat="server"> </asp:Label>
                                </div>

                                 <div class="col-md-12 form-group1 ">
                                    <label class="control-label">College Code</label>
                                    <asp:TextBox ID="txtCollgeCode" runat="server" placeholder="College Name" required=""></asp:TextBox>
                                </div>

                                <div class="col-md-12 form-group1 ">
                                    <label class="control-label">College Name</label>
                                    <asp:TextBox ID="txtCollegeName" runat="server" placeholder="College Name" required=""></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="regexpName" runat="server" ErrorMessage="Enter Valid Name" ControlToValidate="txtCollegeName" ValidationExpression="[A-Za-z]+[ ]*[A-Za-z]*[ ]*[A-Za-z]*" Font-Size="Smaller" ForeColor="#FF3300"></asp:RegularExpressionValidator>
                                </div>

                                <div class="clearfix"></div>

                                <div class="col-md-12 form-group1 ">
                                    <label class="control-label">College Email</label>
                                    <asp:TextBox ID="txtCollegeEmail" CssClass="email-list1" runat="server" placeholder="Collge Email" required=""></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="regexpEmail" runat="server" ErrorMessage="Enter Valid Email Address" ControlToValidate="txtCollegeEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Font-Size="Smaller" ForeColor="#FF3300"></asp:RegularExpressionValidator>

                                </div>

                                   <div class="clearfix"></div>
                                <div class="col-md-12 form-group1 ">
                                    <label class="control-label">Phone Number</label>
                                    <asp:TextBox ID="txtCollegePhone" runat="server" placeholder="Phone Number" required=""></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Enter Valid Mobile Number" ControlToValidate="txtCollegePhone" ValidationExpression="[0-9]{10}" Font-Size="Smaller" ForeColor="#FF3300"></asp:RegularExpressionValidator>

                                </div>

                                <div class="clearfix"></div>
                                <div class="col-md-12 form-group1 ">
                                    <label class="control-label">Mobile Number</label>
                                    <asp:TextBox ID="txtCollgeMobile" runat="server" placeholder="Mobile Number" required="" MaxLength="10"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="regexpMobile" runat="server" ErrorMessage="Enter Valid Mobile Number" ControlToValidate="txtCollgeMobile" ValidationExpression="[0-9]{10}" Font-Size="Smaller" ForeColor="#FF3300"></asp:RegularExpressionValidator>

                                </div>
                                <div class="clearfix"></div>


                               <div class="clearfix"></div>
                                <div class="col-md-12 form-group1 ">
                                    <label class="control-label">College Address</label>
                                    <asp:TextBox ID="txtCollegeAddress" runat="server" placeholder="Collge Full Address" required=""></asp:TextBox>
                                </div>
                                <div class="clearfix"></div>

                              <br />
                                <div class="col-md-12 form-group ">
                                    <asp:Button ID="btnCollegeUpdate" runat="server" Text="Submit" class="btn btn-primary" OnClick="btnUpdateCollege_Click" />
                                    &nbsp

                                <button type="reset" class="btn btn-default" onclick="return resetAll()">Reset</button>

                                </div>
                                <div class="clearfix"></div>
                            </div>
                        </form>

                        <!---->
                    </div>

                </div>
                <div class="col-lg-2"></div>


            </div>
        </div>
        <div class="col-lg-2"></div>

    </div>
    <%--// JS--%>
    <script src="js/jquery.nicescroll.js"></script>
    <script src="js/scripts.js"></script>

</body>
</html>
