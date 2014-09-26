<%@ Page language="c#" Codebehind="Login.aspx.cs" AutoEventWireup="True" Inherits="Maticsoft.Web.Admin.Login" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD runat="server">	
		<title>:系统登录</title>		
		<LINK href="../images/login.css" type="text/css" rel="stylesheet">
		<script language="javascript" type="text/javascript">
		    function ChangeCode() {

		        var date = new Date();
		        var myImg = document.getElementById("ImageCheck");
		        var GUID = document.getElementById("lblGUID");

		        if (GUID != null) {
		            if (GUID.innerHTML != "" && GUID.innerHTML != null) {
		                myImg.src = "ValidateCode.aspx?GUID=" + GUID.innerHTML + "&flag=" + date.getMilliseconds()

		            }
		        }
		        return false;
		    }
</script>

    <script  language="javascript" type="text/javascript">
        function return_back() {
            //alert('test');
            window.history.back();
        }
        </script>
<script type="text/javascript" src="Common.js" charset="gb2312"></script>

 
	    <style type="text/css">
            .style1
            {
                height: 65px;
            }
        </style>
 
	</HEAD>
	<body MS_POSITIONING="GridLayout" leftMargin="0" topMargin="0" marginheight="0" marginwidth="0">
    
		<form id="Form1" method="post" runat="server">
			<FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体">
			</FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体">
			</FONT><FONT face="宋体"></FONT>
			<br>
			<br>
			<br>
			<br>
			<br>
			<TABLE width="620" border="0" align="center" cellPadding="0" cellSpacing="0">
				<TBODY>
					<TR>
						<TD width="620"><IMG height="11" src="../images/login_p_img02.gif" width="650"></TD>
					</TR>
					<TR>
						<TD align="center" background="../images/login_p_img03.gif">
                        <br>
									<TABLE cellSpacing="0" cellPadding="0" border="0" 
                                style="background-image:url('../images/member_t04.JPG'); height: 62px; width: 245px;">
											<TBODY>
												<%--<TR>
													<TD width="245" align="center" valign="middle" class="style1"></TD>                                                    
												</TR>--%>
                                                <img src="../images/logo.jpg" align="middle"/>
											</TBODY>
										</TABLE>
                            <br>
							<table width="570" border="0" cellspacing="0" cellpadding="0">
								
								<tr>
									<td><img src="../images/a_te01.gif" width="570" height="3"></td>
								</tr>
								<tr>
									<td align="center" background="../images/a_te02.gif"><table width="520" border="0" cellspacing="0" cellpadding="0">
											<tr>
												<td width="123" height="120"><IMG height="95" src="../images/login_p_img05.gif" width="123" border="0"></td>
												<td align="left">
												
												<TABLE cellSpacing="0" cellPadding="0" border="0">
														
															<TR>
																<TD vAlign="bottom" width="250" height="25" vAlign="top">
																	用户名 ： <INPUT class="nemo01" tabIndex="1" maxLength="22" size="22" name="user" id="txtUsername"
																		runat="server" onkeypress="return focusNext('txtPass', event,1,this,null)">
                                                                </TD>
																<TD width="80" rowSpan="3" align="right" vAlign="middle">
                                                                <asp:ImageButton id="btnLogin" runat="server" ImageUrl="../images/login_p_img11.gif" ></asp:ImageButton>
                                                                    
                                                                </TD>
															</TR>
															<TR>
																<TD vAlign="bottom" height="12">
																	密&nbsp;&nbsp;码 ： <INPUT name="user" type="password" class="nemo01" tabIndex="1" size="22" maxLength="22"
																		id="txtPass" runat="server" onkeypress="return focusNext('CheckCode', event,2,this,'txtUsername')">																</TD>
															</TR>
															<TR>
															  <TD vAlign="bottom" height="13"><table width="100%%" height="25" border="0" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                  <td width="80%" align="left">
                                                                        验证码 ：
                                                                        <input class="nemo01" id="CheckCode" tabindex="3" maxlength="22" size="11" name="user"
                                                                            runat="server">
                                                                  </td>
                                                                  <td width="30%" align="left"><a   id="A2" href=""  onclick="ChangeCode();return false;"><asp:Image  ID="ImageCheck" runat="server" ImageUrl="ValidateCode.aspx?GUID=GUID" ImageAlign="AbsMiddle"  ToolTip="看不清，换一个"></asp:Image></a></td>
                                                                </tr>
                                                              </table></TD>
												  </TR>
																										
													</TABLE>
												
												
													<br>
													<asp:Label id="lblMsg" runat="server" BackColor="Transparent" ForeColor="Red"></asp:Label>
												</td>
                                                <td align="right"><IMG height="50" src="../images/back.jpg" width="50" height="100" border="0" OnClick="return_back()" alt="返回" />
                                                </td>
											</tr>
										</table>
									</td>
								</tr>
								<tr>
									<td><img src="../images/a_te01.gif" width="570" height="3"></td>
								</tr>
								<tr>
									<td><table width="100%" border="0" cellspacing="0" cellpadding="0">
											<tr>
												<td height="70" align="center">
													江苏省环境监测中心  南京大学
												</td>
											</tr>
										</table>
									</td>
								</tr>
							</table>
						</TD>
					</TR>
					<TR>
						<TD><IMG height="11" src="../images/login_p_img04.gif" width="650"></TD>
					</TR>
				</TBODY>
			</TABLE>
			<br>
		</form>        
	</body>
</HTML>