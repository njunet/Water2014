<%@ Page Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Maticsoft.Web.Index1" Title="江苏技术师范学院科技产业处" %>

<%@ Register Src="Controls/ShowInIndex.ascx" TagName="ShowInIndex" TagPrefix="uc4" %>

<%@ Register Src="Controls/SwitchPic.ascx" TagName="SwitchPic" TagPrefix="uc3" %>
<%@ Register Src="Controls/NewsList_left.ascx" TagName="NewsList_left" TagPrefix="uc2" %>
<%@ Register Src="Controls/NewsList.ascx" TagName="NewsList" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<table width="990" border="0" align="center" cellpadding="0" cellspacing="10" bgcolor="#FFFFFF">
  <tr>
    <td width="220" valign="top"><table border="0" cellpadding="0" cellspacing="0" class="index_left">
      <tr>
        <td height="47" background="images/index0.jpg"><div class="more"><a href="main.aspx?classid=9">更多</a>...</div></td>
      </tr>
      <tr>
        <td valign="top" background="images/index_left_bj1.jpg">
        <ul>
        
       <%-- 通知公告--%>
      <%--记录条数 栏目ID MyintTop="4" MyClassId="4"--%>
          <uc2:NewsList_left id="NewsList_left1" runat="server" MyintTop="5" MyClassId="9">
                </uc2:NewsList_left>
               </ul>
          </td>
      </tr>
    </table>
    <table border="0" cellpadding="0" cellspacing="0" class="index_left">
      <tr>
        <td height="47" background="images/index1.jpg">&nbsp;</td>
      </tr>
      <tr>
        <td height="80" background="images/index_left_bj1.jpg">
        
        <table width="200" height="61" border="0" align="center" cellpadding="0" cellspacing="0">
          <tr>
            <td width="150" height="30"><input name="oa_user" type="text" class="index_left_input_user" id="oa_user" size="12"  value="请输入OA用户名" onclick="this.value=''"  style="font-size:12px"/></td>
            <td width="50" rowspan="2"><input type="image" name="imageField" id="imageField" src="images/login1.jpg" /></td>
          </tr>
          <tr>
            <td><input name="oa_pass" type="password" class="index_left_input_pass" id="oa_pass" size="12" /></td>
            </tr>
        </table>
        
        </td>
      </tr>
      
    </table>
      <table border="0" cellpadding="0" cellspacing="0" class="index_left">
        <tr>
          <td height="47" background="images/index3.jpg"><div class="more"><a href="main.aspx?classid=4">更多</a>...</div></td>
        </tr>
        <tr>
          <td valign="top" background="images/index_left_bj1.jpg">
          <ul>  
          
             <%-- 科技简报--%>
      <%--记录条数 栏目ID 标题长度  MyintTop="4" MyClassId="4"  MyTitleLenth="8"--%>
             
                <uc2:NewsList_left ID="NewsList_left2" runat="server" MyintTop="4" MyTitleLenth="12" MyClassId="4" />
                
          </ul></td>
        </tr>
      </table>
      <table border="0" cellpadding="0" cellspacing="0" class="index_left">
        <tr>
          <td height="47" background="images/index4.jpg"><div class="more"><a href="main.aspx?classid=6">更多</a>...</div></td>
        </tr>
        <tr>
          <td valign="top" background="images/index_left_bj1.jpg" style="padding-left:10px; padding-bottom:10px">
          <span class="guider"><a href="main.aspx?classid=16">项目管理</a></span>
          <span class="guider"><a href="main.aspx?classid=17">成果管理</a></span>
          <span class="guider"><a href="main.aspx?classid=18">专利申请</a></span>
          <span class="guider"><a href="main.aspx?classid=19">横向合作</a></span>
          <span class="guider"><a href="main.aspx?classid=20">经费管理</a></span></td>
        </tr>
      </table>
      
<%--      材料催交--%>       
<table border="0" cellpadding="0" cellspacing="0" class="index_left">
        <tr>
          <td height="47" ><a title="材料催交" href="MaterialIndex.aspx" target="_blank"><img src="images/index_clcj.jpg" alt="材料催交" style="border:0px;" width="215" /></a></td>
        </tr>
       
      </table>
      
      
      </td>
    <td width="510" valign="top"><table width="510" height="280" border="0" cellpadding="0" cellspacing="0" bgcolor="#E4EDF4">
      <tr>
        <td align="center" valign="top" background="images/index_center_2.jpg"><img src="images/index_center_1.jpg" width="510" height="11" /></td>
      </tr>
      <tr>
        <td align="center" valign="top" background="images/index_center_2.jpg">
            <uc3:SwitchPic id="SwitchPic1" runat="server">
            </uc3:SwitchPic><%--        <iframe scrolling="No" src="pic_focus.htm" height="260" width="490" vspace="0" frameborder="0" allowtransparency="1"></iframe>
--%></td>
      </tr>
      <tr>
        <td valign="top" align="center"><img src="images/index_center_3.jpg" width="510" height="13" /></td>
      </tr>
    </table>
      <table width="510" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td height="54" valign="bottom" background="images/index_center_news.jpg">
<%--          <div class="more"><a href="#">更多</a>...</div>
--%>          <table  border="0" align="left" cellpadding="0" cellspacing="0">
              <tr>
                <td width="60" height="26">&nbsp;</td>
                <td  height="26" class="td_border_1" id="grid_1_1" onmouseover="switch_c('grid_1_',1,2)"><div align="center"><a href="http://210.29.192.55/main.aspx?classid=12">科技新闻</a></div></td>
                <td height="26" class="td_border_2" id="grid_1_2" onmouseover="switch_c('grid_1_',2,2)"><div align="center"><a href="http://210.29.192.55/main.aspx?classid=13">学术动态</a></div></td>
                
           <%--     
                <td height="26" class="td_border_2" id="grid_1_3" onmouseover="switch_c('grid_1_',3,5)"><div align="center">专利申请</div></td>
                <td  height="26" class="td_border_2" id="grid_1_4" onmouseover="switch_c('grid_1_',4,5)"><div align="center">横向合作</div></td>
            <td  height="26" class="td_border_2" id="grid_1_5" onmouseover="switch_c('grid_1_',5,5)"><div align="center">经费管理</div></td>
         
              --%>   
              </tr>
          </table>
          </td>
        </tr>
        <tr>
          <td height="195" valign="top" class="td_text">
          <ul id="grid_1_c_1">
           <uc1:NewsList id="NewsList1" runat="server" MyClassId="12" MyintTop="7" MyTitleLenth="28"></uc1:NewsList>
          
           </ul>
          <ul id="grid_1_c_2" style="display:none">
               <uc1:NewsList id="NewsList2" runat="server" MyClassId="13" MyintTop="7" MyTitleLenth="28"></uc1:NewsList>
          </ul>
          
         <%-- <ul id="grid_1_c_3" style="display:none">
               <uc1:NewsList id="NewsList3" runat="server" MyClassId="18" MyintTop="5" MyTitleLenth="18"></uc1:NewsList>
          </ul>
          <ul id="grid_1_c_4" style="display:none">
               <uc1:NewsList id="NewsList4" runat="server" MyClassId="19" MyintTop="5" MyTitleLenth="18"></uc1:NewsList>
          </ul>
          
            <ul id="Ul1" style="display:none">
               <uc1:NewsList id="NewsList7" runat="server" MyClassId="20" MyintTop="5" MyTitleLenth="18"></uc1:NewsList>
          </ul>--%>
          
          </td>
        </tr>
      </table>
      <table width="510" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td height="54" valign="bottom" background="images/index_center_notice.jpg">
          <table  border="0" align="left" cellpadding="0" cellspacing="0">
            <tr>
              <td width="60" height="26">&nbsp;</td>
              <td width="100" height="26" class="td_border_1" id="grid_2_1"  onmouseover="switch_d('grid_2_',1,2)"><div align="center"><a href="http://210.29.192.55/main.aspx?classid=14">校内政策</a></div></td>
              <td width="100" height="26" class="td_border_2" id="grid_2_2" onmouseover="switch_d('grid_2_',2,2)"><div align="center"><a href="http://210.29.192.55/main.aspx?classid=15">校外政策</a></div></td>
              <td width="100" height="26"><div align="center"></div></td>
            </tr>
          </table>
          <div class="more"></div></td>
        </tr>
        <tr>
          <td height="156" valign="top" class="td_text">
          <ul id="grid_2_d_1" >
               <uc1:NewsList id="NewsList5" runat="server" MyClassId="14" MyintTop="5" MyTitleLenth="28"></uc1:NewsList>
               </ul>
           <ul id="grid_2_d_2"  style="display:none">
               <uc1:NewsList id="NewsList6" runat="server" MyClassId="15" MyintTop="5" MyTitleLenth="28"></uc1:NewsList>
          </ul></td>
        </tr>
      </table>
      </td>
    <td width="220" valign="top"><table border="0" cellpadding="0" cellspacing="0" style="margin-bottom:10px">
    
      <tr>
        <td height="70" background="images/search1.jpg" style="width: 218px">
                <iframe scrolling="No" src="search.html" height="70px" width="218px" vspace="0" frameborder="0" allowtransparency="1"></iframe>

     
        </td>
      </tr>
    </table>
      <table border="0" cellpadding="0" cellspacing="0" class="index_right">
      <tr>
        <td height="44" background="images/index5.jpg">&nbsp;</td>
      </tr>
      <tr>
        <td height="63" background="images/index_left_bj1.jpg">
                        <iframe scrolling="No" src="maillogin.htm" height="63px" width="215" vspace="0" frameborder="0" allowtransparency="1"></iframe>

        
        </td>
      </tr>
    </table>
      <a href="http://210.29.192.55:9123/" target="_blank"><img src="images/index2.jpg" width="218" height="48" border="0" class="index_left" /></a>
      <a href="http://159.226.244.14/portal/index.asp" target="_blank"><img src="images/index6.jpg" width="218" height="56" border="0" class="index_right" /></a>
      <table border="0" cellpadding="0" cellspacing="0" class="index_right">
        <tr>
          <td height="47" background="images/index7.jpg">&nbsp;</td>
        </tr>
        <tr>
          <td background="images/index_left_bj1.jpg"><ul>
           
            <li> 处长办公室：0519-86953080(3080)</li>
            <li>副处长办公室：0519-86953082(3082)</li>
            <li>项目管理科：0519-86953088(3088)</li>
            <li>成果管理科：0519-86953089(3089)</li>
          </ul></td>
        </tr>
      </table>
      <table border="0" cellpadding="0" cellspacing="0" class="index_right">
        <tr>
          <td height="47" background="images/index8.jpg">&nbsp;</td>
        </tr>
        <tr>
          <td height="118" valign="top" background="images/index_left_bj1.jpg" style="padding-left:10px; padding-bottom:10px">
            <span class="guider"><a href="news.aspx?id=177" target="_blank" >校内链接</a></span>
           <span class="guider"><a href="news.aspx?id=139" target="_blank" >校际链接</a></span>
           <span class="guider"><a href="news.aspx?id=137" target="_blank" >行业协会</a></span>
           <span class="guider"><a href="news.aspx?id=135" target="_blank" >纵向链接</a></span></td>
        </tr>
      </table>
      <div>      &nbsp;开户行:建设银行常州市怀德支行<br />
          &nbsp;帐号:50432001628836052503595
      </div>
      </td>
  </tr>
</table>




</asp:Content>
