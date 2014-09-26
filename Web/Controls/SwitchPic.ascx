<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SwitchPic.ascx.cs" Inherits="Maticsoft.Web.Controls.SwitchPic" %>
<script src="jquery.js" type="text/javascript"></script>
    <script type="text/javascript">
    $(document).ready(function() {
		   var currentIndex = 0;
            var DEMO; //��������
            var currentID = 0; //ȡ������·��Ķ���ID
            var pictureID = 0; //����ID
            $("#ifocus_piclist li").eq(0).show(); //Ĭ��
            autoScroll();
            $("#ifocus_btn li").hover(function() {
                StopScrolll();
                $("#ifocus_btn li").removeClass("current")//���е�liȥ����ǰ����ʽ������������ʽ
                $(this).addClass("current"); //����������ϵ�ǰ����ʽȥ����������ʽ
                currentID = $(this).attr("id"); //ȡ��ǰԪ�ص�ID
                pictureID = currentID.substring(currentID.length - 1); //ȡ���һ���ַ�
                $("#ifocus_piclist li").eq(pictureID).fadeIn("slow"); //������ʾ
                $("#ifocus_piclist li").not($("#ifocus_piclist li")[pictureID]).hide(); //����������ȫ������
                $("#ifocus_tx li").hide();
                $("#ifocus_tx li").eq(pictureID).show();
 
            }, function() {
                //������뿪�����ʱ���õ�ǰ�Ķ����ID�Ա����������Զ�ʱ����ͬ��
                currentID = $(this).attr("id"); //ȡ��ǰԪ�ص�ID
                pictureID = currentID.substring(currentID.length - 1); //ȡ���һ���ַ�
                currentIndex = pictureID;
                autoScroll();
            });
            //�Զ�����
            function autoScroll() {
                $("#ifocus_btn li:last").removeClass("current");
                $("#ifocus_tx li:last").hide();
                $("#ifocus_btn li").eq(currentIndex).addClass("current");
                $("#ifocus_btn li").eq(currentIndex - 1).removeClass("current");
                $("#ifocus_tx li").eq(currentIndex).show();
                $("#ifocus_tx li").eq(currentIndex - 1).hide();
                $("#ifocus_piclist li").eq(currentIndex).fadeIn("slow");
                $("#ifocus_piclist li").eq(currentIndex - 1).hide();
                currentIndex++; currentIndex = currentIndex >= 3 ? 0 : currentIndex;
                DEMO = setTimeout(autoScroll, 2000);
            }
            function StopScrolll()//������ƶ������������ʱ��ֹͣ�Զ�����
            {
                clearTimeout(DEMO);
            }
	});
    </script>

<style type="text/css">
<!--
body {
	background-color: #FFFFFF;
}
-->
</style>



 <!-- ͼƬ���� ��ʼ -->
 <div id="ifocus" >
        <div id="ifocus_pic">
            <div id="ifocus_piclist" style="left:0; top:0;">
                <ul>
                    <li><a href="<%= strid[0] %>" target="_blank"><img src="upload/img/<%=strimg[0] %>" alt="<%= strtitle[0]%>"  width="237" height="343" border="0"/></a></li>
                    <li><a href="<%= strid[1] %>" target="_blank"><img src="upload/img/<%=strimg[1] %>" alt="<%= strtitle[0]%>"  width="237" height="343" border="0"/></a></li>
                    <li><a href="<%= strid[2] %>" target="_blank"><img src="upload/img/<%=strimg[2] %>" alt="<%= strtitle[0]%>"  width="237" height="343" border="0"/></a></li>
                </ul>
            </div>
            <div id="ifocus_opdiv"></div>
            <div id="ifocus_tx">
                <ul>
                    <li class="current"><%= strtitle[0]%></li>
                    <li class="normal"><%= strtitle[1]%></li>
                    <li class="normal"><%= strtitle[2]%></li>
                </ul>
            </div>
        </div>
        <div id="ifocus_btn">
            <ul>
                <li class="current" id="p0"><img src="upload/img/<%=strimg[0] %>" alt=""   width="96" height="65" border="0"/></li>
                <li class="normal" id="p1"><img src="upload/img/<%=strimg[1] %>" alt="" width="96" height="65" border="0"/></li>
                <li class="normal" id="p2"><img src="upload/img/<%=strimg[2] %>" alt="" width="96" height="65" border="0" /></li>
            </ul>
        </div>
</div>	   
<!-- ͼƬ���� ���� -->