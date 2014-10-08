<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     
    <script type="text/javascript" src="./JS/jquery-1.10.2.min.js"></script>
    <script type="text/javascript">
        $(document).ready(
            function ()
        {
            var i;
            i = parseInt(Math.random() * 34+1);
          
            $(".image").css("background", "url(./background/" + i + ".jpg)");
        

        }
        )
       

        function onFocusFun(element, elementValue) {
            if (element.value == elementValue) {
                element.value = "";
                element.style.color = "";
            }
        }
        function onblurFun(element, elementValue) {
            
            if(element.value==""||element.value.replace(/\s/g,"")=="")
            {
                element.style.color = "#808080";
                element.value = elementValue;
                element.type = "text";
            }

        }
        function passwordOnFocus(element, elementValue) {
            if (element.value == elementValue) {
                element.value = "";
                element.type = "password";
            }
        }
  

      



    

    </script>
    <style type="text/css">
        .image {
             background:url(./background/1.jpg) no-repeat; position:relative;TEXT-ALIGN: center;
                 max-width:1366px;  height:768px;border-radius:20px;box-shadow:   3px 3px 40px rgba(116, 191, 231,0.2),-3px -3px 40px rgba(116, 191, 231,0.2),-3px 3px 40px rgba(116, 191, 231,0.2),3px -3px 40px rgba(116, 191, 231,0.2) ;
        }
        .text_f{ height:36px; line-height:36px;outline:none; font-size:20px;width:280px; padding:0 5px;border:1px solid #0167ff; background:#fff; border-radius:2px; box-shadow:0 0 3px rgba(0,0,0,0.4); font-family:"微软雅黑"}
        .text{ height:36px; line-height:36px;outline:none; font-size:20px;width:280px;border:1px solid #c7c7c7; background:#f3f3f3; border-radius:2px; padding:0 5px; font-family:"微软雅黑"}
        .Button {
            filter: Alpha(opacity=70);
            font-family: 'Microsoft YaHei';
            background: rgba(255,255,255,0.7);
            border: 1px solid #74BFE7;
            cursor:pointer;
            box-shadow: 1px 0px 10px rgba(116, 191, 231,0.2),-1px 0px 10px rgba(116, 191, 231,0.2),0px 1px 10px rgba(116, 191, 231,0.2),0px -1px 10px rgba(116, 191, 231,0.2);
            padding: 2px;
            border-radius: 10px;
            color: #ffffff;
            font-size: 18px;
            -moz-animation: swing 0.5s;
            -webkit-animation: swing 0.5s;
            -o-animation: swing 0.5s;
            animation: swing 0.5s;
            /*animation:bounce  1s;
-moz-animation:bounce  1s;	
-webkit-animation:bounce  1s;	
-o-animation:bounce  1s;*/
        }
        .Button:hover{
            filter:Alpha(opacity=90);
    background:rgba(255,255,255,0.9);
        }
        @-webkit-keyframes swing{
    20%{-webkit-transform:rotate(15deg);}
    40%{-webkit-transform:rotate(-10deg);}
    60%{-webkit-transform:rotate(5deg);}
    80%{-webkit-transform:rotate(-5deg);}
    100%{-webkit-transform:rotate(0);}
}
@-moz-keyframes swing{
    20%{-moz-transform:rotate(15deg);}
    40%{-moz-transform:rotate(-10deg);}
    60%{-moz-transform:rotate(5deg);}
    80%{-moz-transform:rotate(-5deg);}
    100%{-moz-transform:rotate(0);}
}
@-ms-keyframes swing{
    20%{-ms-transform:rotate(15deg);}
    40%{-ms-transform:rotate(-10deg);}
    60%{-ms-transform:rotate(5deg);}
    80%{-ms-transform:rotate(-5deg);}
    100%{-ms-transform:rotate(0);}
}
@keyframes swing{
    20%{transform:rotate(15deg);}
    40%{transform:rotate(-10deg);}
    60%{transform:rotate(5deg);}
    80%{transform:rotate(-5deg);}
    100%{transform:rotate(0);}
}
        p {
            position: relative;
            padding: 4px;
           
            text-align:center;
            font-size: 18px;
            /*-webkit-text-shadow: 1px 0 2px rgba(240,240,240,0.7), 0 1px 2px rgba(240,240,240,0.7), 0 -1px 2px rgba(240,240,240,0.7), -1px 0 2px rgba(240,240,240,0.7);
            text-shadow: 1px 0 2px rgba(240,240,240,0.7), 0 1px 2px rgba(240,240,240,0.7), 0 -1px 2px rgba(240,240,240,0.7), -1px 0 2px rgba(240,240,240,0.7);*/
            top: 0px;
            left: 1px;
            height: 30px;
            line-height:20px
        }

        .ie {
            filter: Dropshadow(offx = 1, offy = 0, color = #cacaca) Dropshadow(offx = 0, offy = 1, color = #cacaca) Dropshadow(offx = 0, offy = -1, color = #cacaca) Dropshadow(offx = -1, offy = 0, color = #cacaca);
          
        }
        .btn{ border-style: none;
            border-color: inherit;
            border-width: medium;
            height:38px; width:142px;margin-left:160px; 
font-size:14px; color:#fff; font-weight:400; background:url(./images/login_btn.jpg); font-size:20px; font-family:"微软雅黑";
        }
.btn:hover{ background-position:0 -38px;}
        .textbox {background-color:#f3f3f3; height:36px; line-height:36px;outline:none; font-size:20px;width:280px; padding:0 5px;border:1px solid #eeeeee; background:#fff; border-radius:2px; box-shadow:0 0 3px rgba(0,0,0,0.4);
            margin-left: 19px;
        }

        .auto-style19 {
            width: 372px;
        }
               
       
        .auto-style22 {
            width: 384px;
        }
               
       
        .auto-style25 {
            height: 44px;
            font-size: 16px;
        }
        .auto-style30 {
            width: 16px;
        }
               
       
        </style>
    <script type="text/javascript">
        // 下面是用递归写的，一定要加在网页末端，注意背景图片地址，自己根据情况改

        //function change() {
        //    var myDate = new Date();
        //    // 每天换背景图片
        //    flag = myDate.getDate();        //获取当前日(1-31)
        //    // 这句注释可以去掉看看效果，每分钟换一张图片，因为一天时间太长了不便于调试
        //    //flag = myDate.getMinutes();   //获取当前分钟数(0-59)

        //    var img1 = document.getElementById('kk');
        //    //比如你有三张背景图，1.jpg,2.jpg和3.jpg，
        //    //判断时间中的日：1-31，或者1-30（还有其他的闰 年就不举例了）和3的余数
        //    //然后加1，因为余数范围0-2
        //    // 你的描述有点隐晦，你有几张图片轮换，什么时候显示，可以根据时间设定flag规则
        //    flag = flag % 3 + 1;
        //    img1.style.background = "url(../background/" + flag + ".jpg)";;
        //    // 注意函数格式：function(){函数名}
        //    window.setTimeout(function () { change() }, 1000);//每隔一秒判断一次系统时间
        //}
        //change();

</script>
</head>
<body  style="margin: auto ;TEXT-ALIGN: center;position:relative; font-family:'Microsoft YaHei';font-size: 24px;color:#202020" >
    <form id="form1" runat="server">
        <div style="background-color:#F5F5F5;border-bottom:1px solid #e7e7e7;">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/images/login.jpg" />
        </div>
    <div class="image" id="ima" style="max-width:800px; max-height:500px;TEXT-ALIGN: center;margin: auto;margin-top:30px;">
    
        <table style="width: 100%; height: 428px;">
            <tr>
                <td class="auto-style19" ></td>
                <td class="auto-style22"></td>
                <td></td>
            </tr>
            <tr>
                <td class="auto-style19" ></td>
                <td class="auto-style22">
                    <table style="width:333px; background-color:#ffffff;filter: Blur(direction=135);text-align:justify;border-radius:20px; height: 225px;filter:Alpha(opacity=100);background:rgba(255,255,255,1)">
                        <tr>
                            <td style="text-align:left;padding-left:40px;" class="auto-style25" colspan="2" >用户登录</td>
                        </tr>
                        <tr>
                            <td class="auto-style30" ></td>
                            <td>
                              <asp:textbox ID="TxtUserID"  class="textbox" ForeColor="Gray"  Value="用户名"  runat="server" Height="30px" Width="250px" Font-Names="微软雅黑" Font-Size="Large"  OnOnBlur="TxtUserID_OnBlur" BackColor="#EEEEEE"></asp:textbox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                    ControlToValidate="TxtUserID" ErrorMessage="*" ForeColor="#FF3300" Height="30px"></asp:RequiredFieldValidator>
                              
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style30"></td>
                            <td>
                                <div id="pass">
                   <asp:TextBox ID="TxtUserPassword" class="textbox" runat="server"  Height="30px" Width="250px" Font-Names="微软雅黑" Font-Size="Large"  BackColor="#EEEEEE" TextMode="Password" ></asp:TextBox>
                                    
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                        ControlToValidate="TxtUserPassword" ErrorMessage="*" Height="30px"></asp:RequiredFieldValidator></div>
                                                            </td>
                        </tr>
                        
                            
                                <tr>
                                    <td class="auto-style30">
                                        </td>
                                    
                                </tr>
                                <tr>
                                    <td class="auto-style30"></td>
                                    <td>
                                        <asp:Button ID="Button1" runat="server" CssClass="btn"
                                            OnClick="btnSubmit_Click" Text="登录" Width="120px" />
                                    </td>
                                    
                                </tr>
                        <tr>
                            <td class="auto-style30">

                            </td>
                        </tr>
                            
                        
                    </table>
                </td>
                <td></td>
            </tr>
            <tr>
                <td class="auto-style19">&nbsp;</td>
                <td class="auto-style22">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    
    </div>
        <div style="margin-top:10px;font-size:12px;">©2013 乐山希尔电子有限公司</div>
    </form>
    
</body>
</html>
