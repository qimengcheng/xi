using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
        //Session.Timeout = 60;
        if (Request.UserAgent.IndexOf("AppleWebKit") > 0)
        {
            Request.Browser.Adapters.Clear();
        }

        try
        {
            LabelUserName.Text = "欢迎" + Session["UserName"].ToString().Trim() + "(" + Session["UserId"].ToString().Trim() + ")登陆";
        }
        catch (Exception)
        {
            Response.Redirect("~/Default.aspx");


        }
        Session["time"] = DateTime.Now.ToString();
        Session.Timeout = 10;
        lblMinute.Value= Convert.ToString(Convert.ToInt32(Session.Timeout) * 1); //默认考试时间为30分钟
        lblTime.Value = "0";

        if (!IsPostBack)
        {
            Ini();
            try
            {
                this.LabelUserName.Text = "欢迎" + Session["UserName"].ToString().Trim() + "(" + Session["UserId"].ToString().Trim() + ")登陆";
            }
            catch (Exception)
            {
                Response.Redirect("~/Default.aspx");


            }

        }
        //判断是否具有校对、会签、审核、批准的权限11.16
        //this.BOM.Visible = false;

        //this.ItemManage.Visible = false;
        //this.Drawm.Visible = false;
        //this.SalesMonthPlanLook.Visible=false;
        //if (Session["UserRole"].ToString().Contains("销售月计划查看"))
        //{
        //   this.SalesMonthPlanLook.Visible = true;
        // }
        usermanage.Visible = false;
        zzjggl.Visible = false;
        if (Session["UserRole"].ToString().Contains("用户管理"))
        {
            usermanage.Visible = true;
        }
        
        if (Session["UserRole"].ToString().Contains("组织机构管理"))
        {
            zzjggl.Visible = true;
        }
  #region MCA
        MCALook.Visible = false;
        MCAEdit.Visible = false;
        MCADCheck.Visible = false;
        MCAMCheck.Visible = false;
        MCAPrice.Visible = false;
        if (Session["UserRole"].ToString().Contains("机械维修加工申请查看"))
        {
            MCALook.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("机械维修加工申请维护"))
        {
            MCAEdit.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("机械维修加工申请部门审核"))
        {
            MCADCheck.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("机械维修加工申请报价"))
        {
            MCAPrice.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("机械维修加工申请报价审核"))
        {
            MCAMCheck.Visible = true;
        }
        #endregion
        #region//yzg
		
		 if (Session["UserRole"].ToString().Contains("特殊产品申请"))
        {
            tscpsq.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("特殊产品制定"))
        {
            tscpzd.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("特殊产品会签"))
        {
            tscphq.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("特殊产品查看"))
        {
            tscpck.Visible = true;
        }
		
		
        if (Session["UserRole"].ToString().Contains("工艺基础信息维护"))
        {
            gongyijichu.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("工艺基础信息查看护"))
        {
            gongyijichu.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("工序维护"))
        {
            gongxu.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("BOM查看"))
        {
            bomchakan.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("BOM维护"))
        {
            bomweihu.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("工艺路线管理"))
        {
            prmgt.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("工艺路线查看"))
        {
            prlook.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("产品分档管理"))
        {
            proclass.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("产品分档查看"))
        {
            proclasslook.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("产品大型号管理"))
        {
            cpdxhgl.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("产品大型号查看"))
        {
            cpdxhck.Visible = true;
        }
		 if (Session["UserRole"].ToString().Contains("产品编码基础信息维护"))
        {
            cpbmjcxxwh.Visible = true;
        }

        if (Session["UserRole"].ToString().Contains("产品编码基础信息查看"))
        {
            cpbmjcxxck.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("产品测试参数基础维护"))
        {
            cpcscsjcwh.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("产品测试参数基础查看"))
        {
            cpcscsjcck.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("产品系列管理"))
        {
            cpxlwh.Visible = true;
        }

        if (Session["UserRole"].ToString().Contains("产品系列查看"))
        {
            cpxlck.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("产品型号维护"))
        {
            cpxhwh.Visible = true;
        }

        if (Session["UserRole"].ToString().Contains("产品型号查看"))
        {
            cpxhck.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("产品基础信息维护"))
        {
            cpjcxx.Visible = false;
        }

        if (Session["UserRole"].ToString().Contains("产品基础信息查看"))
        {
            cpxxck.Visible = false;
        }
        if (Session["UserRole"].ToString().Contains("超时原因选项维护"))
        {
            csyywh.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("异常原因现象选项维护"))
        {
            ycxxwh.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("产能核定基础信息维护"))
        {
            cnhdjcxxwh.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("产能核定基础信息查看"))
        {
            cnhdjcxxck.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("产能核定维护"))
        {
            cnhdwh.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("产能核定查看"))
        {
            cnhdck.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("生产月计划管理"))
        {
            scyjhgl.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("生产月计划审核"))
        {
            scyjhsh.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("生产月计划查看"))
        {
            scyjhck.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("模块生产月计划管理"))
        {
            A7.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("模块生产月计划审核"))
        {
            A8.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("模块生产月计划查看"))
        {
            A9.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("生产周计划管理"))
        {
            sczjhgl.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("生产周计划审核"))
        {
            sczjhsh.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("生产周计划查看"))
        {
            sczjhck.Visible = true;
        } if (Session["UserRole"].ToString().Contains("模块生产周计划管理"))
        {
            A10.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("模块生产周计划审核"))
        {
            A11.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("模块生产周计划查看"))
        {
            A12.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("材料月计划查看"))
        {
            clzjhck.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("材料月计划制定"))
        {
            clyjhzd.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("材料月计划审核"))
        {
            clyjhsh.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("材料周计划查看"))
        {
            cailzjhck.Visible = true;
        }

        if (Session["UserRole"].ToString().Contains("材料周计划制定"))
        {
            clzjhzd.Visible = true;
        }

        if (Session["UserRole"].ToString().Contains("材料周计划审核"))
        {
            clzjhsh.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("模块材料月计划查看"))
        {
            A1.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("模块材料月计划制定"))
        {
            A2.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("模块材料月计划审核"))
        {
            A3.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("模块材料周计划查看"))
        {
            A4.Visible = true;
        }

        if (Session["UserRole"].ToString().Contains("模块材料周计划制定"))
        {
            A5.Visible = true;
        }

        if (Session["UserRole"].ToString().Contains("模块材料周计划审核"))
        {
            A6.Visible = true;
        }
		if (Session["UserRole"].ToString().Contains("客户端操作员查看"))
        {
            khdczyck.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("客户端操作员管理"))
        {
            khdczygl.Visible = true;
        }

        if (Session["UserRole"].ToString().Contains("随工单生成"))
        {
            sgdsc.Visible = true;
        }
       
      if (Session["UserRole"].ToString().Contains("异常申报"))
        {
            ycsb.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("工程异常处理"))
        {
            gcyccl.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("生产异常处理"))
        {
            scyccl.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("品保异常处理"))
        {
            pbyccl.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("品保异常会签"))
        {
            pbychq.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("生产异常会签"))
        {
            scychq.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("工程异常会签"))
        {
            gcychq.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("主导部门跟踪"))
        {
            zdbmgz.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("异常查看"))
        {
            ycck.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("在制品维护"))
        {
            zzpwh.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("在制品查看"))
        {
            zzpck.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("随工单分单"))
        {
            sgdfd.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("随工单合单"))
        {
            sgdhd.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("工价系列维护"))
        {
            gjxlwh.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("工价系列查看"))
        {
            gjxlck.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("班组信息维护"))
        {
            bzxxwh.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("班组信息查看"))
        {
            bzxxck.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("装配计件维护"))
        {
            zpjjwh.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("装配计件查看"))
        {
            zpjjck.Visible = true;
        }
/*         if (Session["UserRole"].ToString().Contains("计时计件日核算制定"))
        {
            jsjjrhs.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("计时计件日核算审核"))
        {
            jsjjrhssh.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("计时计件日核算查看"))
        {
            jsjjrck.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("生产计时日提报制定"))
        {
            scjsrtb.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("生产计时日提报查看"))
        {
            scjsrtbck.Visible = true;
        }
		 */
		 if (Session["UserRole"].ToString().Contains("生产无关非固定计时查看"))
        {
            scwgfgdjsck.Visible = true;
        }
		 if (Session["UserRole"].ToString().Contains("生产无关非固定计时提报"))
        {
            scwgfgdjstb.Visible = true;
        }
		 if (Session["UserRole"].ToString().Contains("生产无关非固定计时初步审核"))
        {
            scwgfgdjscs.Visible = true;
        }
		 if (Session["UserRole"].ToString().Contains("生产无关非固定计时人事审核"))
        {
            scwgfgdjsrs.Visible = true;
        }
		 if (Session["UserRole"].ToString().Contains("生产无关非固定计时财务审核"))
        {
            scwgfgdjscw.Visible = true;
        }
		
		 if (Session["UserRole"].ToString().Contains("生产无关固定计时查看"))
        {
            scwggdjsck.Visible = true;
        }
		 if (Session["UserRole"].ToString().Contains("生产无关固定计时提报"))
        {
            scwggdjstb.Visible = true;
        }
		 if (Session["UserRole"].ToString().Contains("生产无关固定计时初步审核"))
        {
            scwggdjscs.Visible = true;
        }
		 if (Session["UserRole"].ToString().Contains("生产无关固定计时人事审核"))
        {
            scwggdjsrs.Visible = true;
        }
		 if (Session["UserRole"].ToString().Contains("生产无关固定计时财务审核"))
        {
            scwggdjscw.Visible = true;
        }

		 if (Session["UserRole"].ToString().Contains("非装配计件项目财务审核"))
         {
             jjxmcwsh.Visible = true;
         }
         if (Session["UserRole"].ToString().Contains("非装配计件项目审核查看"))
         {
             jjxmshck.Visible = true;
         }
		  if (Session["UserRole"].ToString().Contains("装配计件项目财务审核"))
         {
             jjxmcwshzpsh.Visible = true;
         }
         if (Session["UserRole"].ToString().Contains("装配计件项目审核查看"))
         {
             jjxmcwshzplook.Visible = true;
         }
		  if (Session["UserRole"].ToString().Contains("生产相关计时信息财务审核"))
         {
             jsxmsh.Visible = true;
         }
         if (Session["UserRole"].ToString().Contains("生产相关计时信息审核查看"))
         {
             jsxmck.Visible = true;
         }
		
		   if (Session["UserRole"].ToString().Contains("计件补录提报"))
         {
             jjblzd.Visible = true;
         }
		    if (Session["UserRole"].ToString().Contains("计件补录审核"))
         {
             jjblsh.Visible = true;
         }
		    if (Session["UserRole"].ToString().Contains("计件补录查看"))
         {
             jjblck.Visible = true;
         }
		    if (Session["UserRole"].ToString().Contains("计时补录提报"))
         {
             jsbltb.Visible = true;
         }   if (Session["UserRole"].ToString().Contains("计时补录审核"))
         {
             jsblsh.Visible = true;
         }
		    if (Session["UserRole"].ToString().Contains("计时补录查看"))
         {
             jsblck.Visible = true;
         }
		
		
		
		
		
		
		
		
        //if (Session["UserRole"].ToString().Contains("问题产品查看"))
        //{
        //    wtcpck.Visible = true;
        //}
        //if (Session["UserRole"].ToString().Contains("问题产品管理"))
        //{
        //    wtcpgl.Visible = true;
        //}
        //if (Session["UserRole"].ToString().Contains("问题产品跟踪"))
        //{
        //    wtcpgz.Visible = true;
        //}
      
        if (Session["UserRole"].ToString().Contains("加工订单跟踪制定"))
        {
            jgddgzzd.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("加工订单跟踪会签"))
        {
            jgddgzhq.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("加工订单跟踪"))
        {
            jgddgz.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("模板管理"))
        {
            mbgl.Visible = true;
        }
        #endregion

        #region 生产计划跟踪
        if (Session["UserRole"].ToString().Contains("生产计划跟踪"))
        {
            scjhgz.Visible = true;
        }
        #endregion


        #region 销售管理
        this.SalesMonthPlanLook.Visible = false;
        this.SalesMonthPlanEdit.Visible = false;
        this.SalesMonthPlanSign.Visible = false;
        this.SalesMonthPlanCheck.Visible = false;
        this.SalesMonthPlanCheckNew.Visible = false;
        //月计划
        if (Session["UserRole"].ToString().Contains("销售月计划查看"))
        {
            this.SalesMonthPlanLook.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("销售月计划维护"))
        {
            this.SalesMonthPlanEdit.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("销售月计划会签"))
        {
            this.SalesMonthPlanSign.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("销售月计划审核"))
        {
            this.SalesMonthPlanCheck.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("新增销售月计划审核"))
        {
            this.SalesMonthPlanCheckNew.Visible = true;
        }
        //周计划
        this.SalesWeekPlanLook.Visible = false;
        this.SalesWeekPlanEdit.Visible = false;
        this.SalesWeekPlanSign.Visible = false;
        if (Session["UserRole"].ToString().Contains("销售周计划查看"))
        {
            this.SalesWeekPlanLook.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("销售周计划维护"))
        {
            this.SalesWeekPlanEdit.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("销售周计划会签"))
        {
            this.SalesWeekPlanSign.Visible = true;
        }
        //销售订单
        this.SalesOrderLook.Visible = false;
        this.SalesOrderEdit.Visible = false;
        if (Session["UserRole"].ToString().Contains("销售订单查看"))
        {
            this.SalesOrderLook.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("销售订单维护"))
        {
            this.SalesOrderEdit.Visible = true;
        }
        //销售发货计划
        this.SalesPlanLook.Visible = false;
        this.SalesPlanEdit.Visible = false;
        this.SalesLook.Visible = false;
        this.SalesResult.Visible = false;
        this.SalesMangement.Visible = false;

        if (Session["UserRole"].ToString().Contains("销售发货计划查看"))
        {
            this.SalesPlanLook.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("销售发货计划维护"))
        {
            this.SalesPlanEdit.Visible = true;
        }

        if (Session["UserRole"].ToString().Contains("销售退货查看"))
        {
            this.SalesLook.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("销售退货处理结果维护"))
        {
            this.SalesResult.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("销售收货退货管理"))
        {
            this.SalesMangement.Visible = true;
        }
        SalesResultReason.Visible = false;
        if (Session["UserRole"].ToString().Contains("退货原因基础数据"))
        {
            this.SalesResultReason.Visible = true;
        }
        //价格账期维护
        this.SalesPriceLook.Visible = false;
        this.SalesPriceEdit.Visible = false;
        this.SalesPriceApplyEdit.Visible = false;
        this.SalesPriceApplyLook.Visible = false;
        this.SalesPriceApplyCheck.Visible = false;
        ProTypePrice.Visible = false;
   if (Session["UserRole"].ToString().Contains("产品底价录入"))
        {
            ProTypePrice.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("价格账期查看"))
        {
            this.SalesPriceLook.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("价格账期维护"))
        {
            this.SalesPriceEdit.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("价格账期申请审批"))
        {
            this.SalesPriceApplyEdit.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("价格账期申请查看"))
        {
            this.SalesPriceApplyLook.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("价格账期申请审核"))
        {
            this.SalesPriceApplyCheck.Visible = true;
        }
        //回款开票
        this.SalesPayBillLook.Visible = false;
        this.SalesPayBillEdit.Visible = false;
        this.SalesPayBillAdmin.Visible = false;
        if (Session["UserRole"].ToString().Contains("销售回款开票查看"))
        {
            this.SalesPayBillLook.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("销售回款开票维护"))
        {
            this.SalesPayBillEdit.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("客户初始金额维护"))
        {
            this.SalesPayBillAdmin.Visible = true;
        }
        //售后
        this.SalesTousuSortLook.Visible = false;
        this.SalesTousuSortEdit.Visible = false;
        this.SalesAfterSortLook.Visible = false;
        this.SalesAfterSortEdit.Visible = false;
        this.SalesAfterMainLook.Visible = false;
        this.SalesAfterMainEdit.Visible = false;
        this.SalesAfterAnalysis.Visible = false;
        this.SalesAfterCheck.Visible = false;
        if (Session["UserRole"].ToString().Contains("投诉类别查看"))
        {
            this.SalesTousuSortLook.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("投诉类别维护"))
        {
            this.SalesTousuSortEdit.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("售后类别查看"))
        {
            this.SalesAfterSortLook.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("售后类别维护"))
        {
            this.SalesAfterSortEdit.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("客诉主表查看"))
        {
            this.SalesAfterMainLook.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("客诉主表维护"))
        {
            this.SalesAfterMainEdit.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("客诉分析结果录入"))
        {
            this.SalesAfterAnalysis.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("客诉分析结果审核"))
        {
            this.SalesAfterCheck.Visible = true;
        }
		 SalesAfterTrackLook.Visible = false;
        SalesAfterNodeEdit.Visible = false;
        SalesAfterTrackEdit.Visible = false;
        if (Session["UserRole"].ToString().Contains("客诉追踪信息查看"))
        {
            this.SalesAfterTrackLook.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("客诉追踪信息录入"))
        {
            this.SalesAfterTrackEdit.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("客诉追踪环节设置"))
        {
            this.SalesAfterNodeEdit.Visible = true;
        }
		WailaiLook.Visible=false;
		WailaiEdit.Visible=false;
		WailaiCheck.Visible=false;
		WailaiAnalysis.Visible=false;
		if (Session["UserRole"].ToString().Contains("外来样品查看"))
        {
            this.WailaiLook.Visible = true;
        }if (Session["UserRole"].ToString().Contains("外来样品维护"))
        {
            this.WailaiEdit.Visible = true;
        }if (Session["UserRole"].ToString().Contains("外来样品审核"))
        {
            this.WailaiCheck.Visible = true;
        }if (Session["UserRole"].ToString().Contains("外来样品分析"))
        {
            this.WailaiAnalysis.Visible = true;
        }

        SalesMan.Visible = false;
        SalesManSort.Visible = false;
        if (Session["UserRole"].ToString().Contains("销售业务员管理"))
        {
            SalesMan.Visible = true;
        }

        if (Session["UserRole"].ToString().Contains("业务员类别管理"))
        {
            SalesManSort.Visible = true;
        }
	 SalesPlanApplyEdit.Visible = false;
        SalesPlanApplyCheck.Visible = false;
        if (Session["UserRole"].ToString().Contains("特殊发货申请查看"))
        {
            SalesPlanApplyEdit.Visible = true;
        }

        if (Session["UserRole"].ToString().Contains("特殊发货申请审核"))
        {
            SalesPlanApplyCheck.Visible = true;
        }
TotalDeliverPlan.Visible = false;
 if (Session["UserRole"].ToString().Contains("发货计划统计"))
        {
            TotalDeliverPlan.Visible = true;
        }
        #endregion
        #region 客户关系管理

        this.CB1.Visible = false;
        this.A13.Visible = false;
        this.A14.Visible = false;
        this.A15.Visible = false;
        this.CI2.Visible = false;
        this.A19.Visible = false;
        SortSee1.Visible = false;
        SortMange1.Visible = false;
      
        //this.PP_MApply.Visible = false;
        this.PP_MCheck_MFG.Visible = false;

        if (Session["UserRole"].ToString().Contains("客户区域基础数据查看"))
        {
            this.CB1.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("客户区域基础数据维护"))
        {
            this.A13.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("客户类别基础数据查看"))
        {
            this.A14.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("客户类别基础数据维护"))
        {
            this.A15.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("客户信息查看"))
        {
            this.CI2.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("客户信息维护"))
        {
            this.A19.Visible = true;
        }

        if (Session["UserRole"].ToString().Contains("公司样品查看"))
        {
            this.gsypck.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("公司样品管理"))
        {
            this.PP_WIPControl.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("客户领域基础数据维护"))
        {
            this.SortMange1.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("客户领域基础数据查看"))
        {
            this.SortSee1.Visible = true;
        }


        #endregion
        #region 库存管理
        //物料基础数据
        this.IMMaterialBasicSearch.Visible = false;
        this.IMMaterialBasicEdit.Visible = false;
        if (Session["UserRole"].ToString().Contains("物料基础数据查看"))
        {
            this.IMMaterialBasicSearch.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("物料基础数据维护"))
        {
            this.IMMaterialBasicEdit.Visible = true;
        }
        //入库
        this.INSLook.Visible = false;
        this.PurINS.Visible = false;
        this.PTINS.Visible = false;
        this.REINS.Visible = false;
        this.OtherINS.Visible = false;
        if (Session["UserRole"].ToString().Contains("入库单查询"))
        {
            this.INSLook.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("采购入库"))
        {
            this.PurINS.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("成品入库"))
        {
            this.PTINS.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("退货入库"))
        {
            this.REINS.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("铜材代工入库"))
        {
            copperinstore.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("其他入库"))
        {
            this.OtherINS.Visible = true;
        }
        //出库
        this.OutLook.Visible = false;
        this.OutEdit.Visible = false;
        this.LingliaoLook.Visible = false;
        this.LingliaoEdit.Visible = false;
        this.LingliaoCheck.Visible = false;
        this.SalesOut.Visible = false;
        this.LingliaoOut.Visible = false;

        if (Session["UserRole"].ToString().Contains("出库单查看"))
        {
            this.OutLook.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("出库单维护"))
        {
            this.OutEdit.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("领料单查看"))
        {
            this.LingliaoLook.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("领料单维护"))
        {
            this.LingliaoEdit.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("领料单审核"))
        {
            this.LingliaoCheck.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("销售出库"))
        {
            this.SalesOut.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("领料出库"))
        {
            this.LingliaoOut.Visible = true;
        }
        //else
        this.InventoryLook.Visible = false;
        this.PandianLook.Visible = false;
        this.Pandian.Visible = false;
        this.BaofeiApply.Visible = false;
        this.BaofeiAnalysis.Visible = false;
        this.BaofeiCheck.Visible = false;
        this.BaofeiZhixing.Visible = false;
        this.BaofeiLook.Visible = false;
        this.DiaoboLook.Visible = false;
        this.DiaoboOut.Visible = false;
        this.DiaoboLIn.Visible = false;
        if (Session["UserRole"].ToString().Contains("库存查看"))
        {
            this.InventoryLook.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("库存盘点查看"))
        {
            this.PandianLook.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("库存盘点维护"))
        {
            this.Pandian.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("库存报废申请"))
        {
            this.BaofeiApply.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("库存报废分析"))
        {
            this.BaofeiAnalysis.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("库存报废审核"))
        {
            this.BaofeiCheck.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("库存报废执行"))
        {
            this.BaofeiZhixing.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("库存报废申请查看"))
        {
            this.BaofeiLook.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("调拨查询"))
        {
            this.DiaoboLook.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("调出管理"))
        {
            this.DiaoboOut.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("调入管理"))
        {
            this.DiaoboLIn.Visible = true;
        }
        //zm 库存基础数据
        this.SB1.Visible = false;
        this.SB2.Visible = false;
        this.SB3.Visible = false;
        this.SB4.Visible = false;
        this.SB5.Visible = false;
        if (Session["UserRole"].ToString().Contains("库房出入库类别查看"))
        {
            this.SB1.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("库房出入库类别维护"))
        {
            this.SB2.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("库房基础数据查看"))
        {
            this.SB3.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("库房区域查看"))
        {
            this.SB4.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("库房基础数据维护"))
        {
            this.SB5.Visible = true;
        }
        #endregion

        #region 进料检验
        this.Item.Visible = false;
        this.Certification.Visible = false;
        this.IQCMgt.Visible = false;
        this.IQCAuMgt.Visible = false;
        this.IQCAuMgtReview.Visible = false;
        if (Session["UserRole"].ToString().Contains("进料检验检验项目维护"))
        {
            this.Item.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("进料检验检验项目查看"))
        {
            this.Item.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("认证信息维护"))
        {
            this.Certification.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("进料检验维护"))
        {
            this.IQCMgt.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("进料检验审核"))
        {
            this.IQCAuMgt.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("进料检验结果查看"))
        {
            this.IQCAuMgtReview.Visible = true;
        }

        #endregion

        #region 实验测试管理
        this.Item1.Visible = false;
        this.Sample.Visible = false;
        this.Submit.Visible = false;
        this.AppAu.Visible = false;
        this.AppAck.Visible = false;
        this.AppRes.Visible = false;
        this.AppArl.Visible = false;
        this.AppView.Visible = false;

        if (Session["UserRole"].ToString().Contains("实验项目维护"))
        {
            this.Item1.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("样品类型维护"))
        {
            this.Sample.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("实验申请提交"))
        {
            this.Submit.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("实验申请审核"))
        {
            this.AppAu.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("实验申请接收"))
        {
            this.AppAck.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("实验结果录入"))
        {
            this.AppRes.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("实验结果审批"))
        {
            this.AppArl.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("实验进度追踪"))
        {
            this.AppView.Visible = true;
        }
        #endregion

        #region 计量器具管理
        this.MeasAppliance.Visible = false;
        if (Session["UserRole"].ToString().Contains("计量器具维护"))
        {
            this.MeasAppliance.Visible = true;
        }
        this.MeasApplianceLook.Visible = false;
        if (Session["UserRole"].ToString().Contains("计量器具查看"))
        {
            this.MeasApplianceLook.Visible = true;
        }
        #endregion

        #region 型式实验管理CC
        this.Typetest.Visible = false;
        this.Typetestlook.Visible = false;
        if (Session["UserRole"].ToString().Contains("型式实验管理"))
        {
            this.Typetest.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("型式实验查看"))
        {
            this.Typetestlook.Visible = true;
        }
        #endregion 型式实验管理CC

        #region 设备管理权限CC
        this.EMType.Visible = false;
        this.EMName.Visible = false;
        this.EMInf.Visible = false;
        this.EMApp.Visible = false;
        this.EMApproval.Visible = false;
        this.EMDeal.Visible = false;
        this.EMLook.Visible = false;
        this.EMItem.Visible = false;
        this.EMMake.Visible = false;
        this.EMGen.Visible = false;
        this.EMDealP.Visible = false;
        this.EMLookP.Visible = false;
        this.EMHis.Visible = false;
        this.EMWxApp.Visible = false;
        this.EMWxAck.Visible = false;
        this.EMCnDeal.Visible = false;
        this.EMWxCheck.Visible = false;
        this.EMWxLook.Visible = false;
        this.EMCcApp.Visible = false;
        this.EMCcExpect.Visible = false;
        this.EMCcFinan.Visible = false;
        this.EMCcConfirmor.Visible = false;
        this.EMCcAct.Visible = false;
        this.EMCcFinanConfirmor.Visible = false;
        this.EMCcLook.Visible = false;
        this.EMStar.Visible = false;
        this.EMLookInf.Visible = false;
        this.EMAllow.Visible = false;
        this.EMNameLook.Visible = false;

        if (Session["UserRole"].ToString().Contains("设备基础信息查看"))
        {
            this.EMNameLook.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("设备报废批准"))
        {
            this.EMAllow.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("设备台账查看"))
        {
            this.EMLookInf.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("设备保养开始确认"))
        {
            this.EMStar.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("设备类型管理"))
        {
            this.EMType.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("设备基础信息管理"))
        {
            this.EMName.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("设备台账管理"))
        {
            this.EMInf.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("设备报废申请"))
        {
            this.EMApp.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("设备报废审批"))
        {
            this.EMApproval.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("设备报废处理"))
        {
            this.EMDeal.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("设备报废情况查看"))
        {
            this.EMLook.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("设备保养项目管理"))
        {
            this.EMItem.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("设备保养计划制定"))
        {
            this.EMMake.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("设备保养计划生成"))
        {
            this.EMGen.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("设备保养情况记录"))
        {
            this.EMDealP.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("设备保养计划查看"))
        {
            this.EMLookP.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("设备保养历史记录查看"))
        {
            this.EMHis.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("设备故障维修申请"))
        {
            this.EMWxApp.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("设备故障维修确认"))
        {
            this.EMWxAck.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("设备故障维修情况记录"))
        {
            this.EMCnDeal.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("设备故障维修验收"))
        {
            this.EMWxCheck.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("设备故障维修查看"))
        {
            this.EMWxLook.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("出厂维修审批"))
        {
            this.EMCcApp.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("出厂维修预算"))
        {
            this.EMCcExpect.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("出厂维修财务审核"))
        {
            this.EMCcFinan.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("出厂维修出厂确认"))
        {
            this.EMCcConfirmor.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("出厂维修回厂信息完善"))
        {
            this.EMCcAct.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("出厂维修财务确认"))
        {
            this.EMCcFinanConfirmor.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("出厂维修查看"))
        {
            this.EMCcLook.Visible = true;
        }
        #endregion

        #region 受控文件管理CC
        this.BasicCode.Visible = false;
        this.ControlDocApp.Visible = false;
        this.ControlDocSpecil.Visible = false;
        this.ControlDocAu.Visible = false;
        this.ControlDocSign.Visible = false;
        this.ControlDocApprov.Visible = false;
        this.ControlDocLook.Visible = false;
        //this.ControlDocDown.Visible = false;
        this.BasicLook.Visible = false;
        //this.ControlDocDownlook.Visible = false;
        this.ControlDocIn.Visible = false;

        if (Session["UserRole"].ToString().Contains("受控文件录入"))
        {
            this.ControlDocIn.Visible = true;
        }
        //if (Session["UserRole"].ToString().Contains("受控文件查阅"))
        //{
        //    this.ControlDocDownlook.Visible = true;
        //}
        if (Session["UserRole"].ToString().Contains("受控文件基础数据查看"))
        {
            this.BasicLook.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("受控文件基础数据维护"))
        {
            this.BasicCode.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("受控文件申请"))
        {
            this.ControlDocApp.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("分发特殊文件编号"))
        {
            this.ControlDocSpecil.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("受控文件主管审核"))
        {
            this.ControlDocAu.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("受控文件会签"))
        {
            this.ControlDocSign.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("受控文件审批"))
        {
            this.ControlDocApprov.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("受控文件申请查看"))
        {
            this.ControlDocLook.Visible = true;
        }
        //if (Session["UserRole"].ToString().Contains("受控文件下载"))
        //{
        //    this.ControlDocDown.Visible = true;
        //}
        #endregion 受控文件管理

        #region HSF
        if (Session["UserRole"].ToString().Contains("有毒成分基础数据维护"))
        {
            hsfelement.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("物料有毒成分项目维护"))
        {
            hsfmaterialelement.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("有毒物质管理"))
        {
            hsf.Visible = true;
        }
if (Session["UserRole"].ToString().Contains("有毒物质报告到期查看"))
        {
            hsfdue.Visible = true;
        }
if (Session["UserRole"].ToString().Contains("有毒物质报告下载"))
        {
            hsfreportdownload.Visible = true;
        }
if (Session["UserRole"].ToString().Contains("有毒物质报表"))
{
    HSFInfo.Visible = true;
}
        #endregion
        #region//人事档案管理
        this.postLook.Visible = false;
        this.postMain.Visible = false;
        this.typeLook.Visible = false;
        this.typeMain.Visible = false;
        this.documentLook.Visible = false;
        this.documentMain.Visible = false;
        this.salaryLook.Visible = false;
        this.salaryMain.Visible = false;
        this.changeLook.Visible = false;
        this.changeMain.Visible = false;
        this.documentMain_Quit.Visible = false;
        this.rewardLook.Visible = false;
        this.rewardMain.Visible = false;

        if (Session["UserRole"].ToString().Contains("人员奖惩查看"))
        {
            this.rewardLook.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("人员奖惩管理"))
        {
            this.rewardMain.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("离职员工档案维护"))
        {
            this.documentMain_Quit.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("人事岗位查看"))
        {
            this.postLook.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("人事岗位维护"))
        {
            this.postMain.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("员工类型查看"))
        {
            this.typeLook.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("员工类型维护"))
        {
            this.typeMain.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("人事档案查看"))
        {
            this.documentLook.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("人事档案维护"))
        {
            this.documentMain.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("人员调薪记录查看"))
        {
            this.salaryLook.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("人员调薪管理"))
        {
            this.salaryMain.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("人事异动查看"))
        {
            this.changeLook.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("人事异动管理"))
        {
            this.changeMain.Visible = true;
        }
        #endregion

        #region//培训管理
        this.itemsLook.Visible = false;
        this.itemsMain.Visible = false;
        this.newEAddAdd.Visible = false;
        this.ScoreInput.Visible = false;
        this.LookResult.Visible = false;
        this.TraType.Visible = false;
        this.TraTYearLook.Visible = false;
        this.TraTYear.Visible = false;
        this.ItemMgt.Visible = false;
        this.MonthDetail.Visible = false;
        this.ResultInput.Visible = false;
        this.ResultReview.Visible = false;
        if (Session["UserRole"].ToString().Contains("新员工培训项目查看"))
        {
            this.itemsLook.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("新员工培训项目维护"))
        {
            this.itemsMain.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("新员工培训信息新建"))
        {
            this.newEAddAdd.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("新员工培训结果录入"))
        {
            this.ScoreInput.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("新员工培训结果查看"))
        {
            this.LookResult.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("培训类型维护"))
        {
            this.TraType.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("培训年度计划查看"))
        {
            this.TraTYearLook.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("培训年度计划维护"))
        {
            this.TraTYear.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("培训计划安排"))
        {
            this.ItemMgt.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("培训计划详情查看"))
        {
            this.MonthDetail.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("培训成绩录入"))
        {
            this.ResultInput.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("培训记录查看"))
        {
            this.ResultReview.Visible = true;
        }
		this.PersonDetail.Visible = false;
        if (Session["UserRole"].ToString().Contains("培训详情查询"))
        {
            this.PersonDetail.Visible = true;
        }
        #endregion

        #region//薪资管理
        this.Set.Visible = false;
        this.Time.Visible = false;
        this.Piecework.Visible = false;
        //this.TimeDayCalculate.Visible = false;
        //this.PieceDayCalculate.Visible = false;
        //this.TimeDayCheck.Visible = false;
        //this.PieceDayCheck.Visible = false;
        this.MonthCalculate.Visible = false;
        this.MonthAudit.Visible = false;
        this.Review.Visible = false;
        this.MonthSearch.Visible = false;
        this.PieceSeries.Visible = false;
        this.PieceworkLook.Visible = false;
        this.TimeLook.Visible = false;
        this.IndividualIncome.Visible = false;
        if (Session["UserRole"].ToString().Contains("计件项目查看"))
        {
            this.PieceworkLook.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("计时项目查看"))
        {
            this.TimeLook.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("计件系列维护"))
        {
            this.PieceSeries.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("薪资账套维护"))
        {
            this.Set.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("计时项目维护"))
        {
            this.Time.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("计件项目维护"))
        {
            this.Piecework.Visible = true;
        }
        //if (Session["UserRole"].ToString().Contains("计时工资日计算"))
        //{
        //    this.TimeDayCalculate.Visible = true;
        //}
        //if (Session["UserRole"].ToString().Contains("计件工资日计算"))
        //{
        //    this.PieceDayCalculate.Visible = true;
        //}
        //if (Session["UserRole"].ToString().Contains("计时工资日审核"))
        //{
        //    this.TimeDayCheck.Visible = true;
        //}
        //if (Session["UserRole"].ToString().Contains("计件工资日审核"))
        //{
        //    this.PieceDayCheck.Visible = true;
        //}
        if (Session["UserRole"].ToString().Contains("薪资月度结算"))
        {
            this.MonthCalculate.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("薪资月度审核"))
        {
            this.MonthAudit.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("薪资月度查看"))
        {
            this.MonthSearch.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("薪资个人查看"))
        {
            this.Review.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("个人所得税基础信息维护"))
        {
            this.IndividualIncome.Visible = true;
        }
        #endregion

        #region//绩效管理
        this.PerMainView.Visible = false;
        this.PerMain.Visible = false;
        this.PerInfoInput.Visible = false;
        this.PerAudit.Visible = false;
        this.PerReview.Visible = false;
        this.PerMAudit.Visible = false;
        if (Session["UserRole"].ToString().Contains("绩效考核经理考核"))
        {
            this.PerMAudit.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("绩效基础数据查看"))
        {
            this.PerMainView.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("绩效基础数据维护"))
        {
            this.PerMain.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("绩效考核信息录入"))
        {
            this.PerInfoInput.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("绩效考核结果审核"))
        {
            this.PerAudit.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("绩效考核结果查看"))
        {
            this.PerReview.Visible = true;
        }

        #endregion

        #region temp

        #endregion
        #region//HLL
        //this.PP_MApply.Visible = false;
        //if (Session["UserRole"].ToString().Contains("外送样品管理"))
        //{
        //    this.PP_MApply.Visible = true;
        //}
        this.PP_MCheck_MFG.Visible = false;
        if (Session["UserRole"].ToString().Contains("新客户开发管理"))
        {
            this.PP_MCheck_MFG.Visible = true;
        }
        this.ProjectSupply.Visible = false;
        this.PAccept.Visible = false;
        this.PMaterial.Visible = false;
        if (Session["UserRole"].ToString().Contains("项目申请管理"))
        {

            this.ProjectSupply.Visible = true;//项目申请

        }
        if (Session["UserRole"].ToString().Contains("项目材料维护"))
        {
            this.PMaterial.Visible = true;//材料维护
            this.PAccept.Visible = true;//项目验收报告提交
        }
        this.ProjectCheck.Visible = false;
        if (Session["UserRole"].ToString().Contains("项目审核"))
        {
            this.ProjectCheck.Visible = true;
        }
        //if (Session["UserRole"].ToString().Contains("项目申请管理"))
        //{
        //    this.PAccept.Visible = true;
        //}
        this.AcceptCheck.Visible = false;
        if (Session["UserRole"].ToString().Contains("项目验收审核"))
        {
            this.AcceptCheck.Visible = true;
        }
        this.Approval.Visible = false;
        if (Session["UserRole"].ToString().Contains("项目批准"))
        {
            this.Approval.Visible = true;
        }
        this.ScheduleLook.Visible = false;
        if (Session["UserRole"].ToString().Contains("项目进度查看"))
        {
            this.ScheduleLook.Visible = true;
        }
        this.Sarrange.Visible = false;
        if (Session["UserRole"].ToString().Contains("项目部门设置"))
        {
            this.Sarrange.Visible = true;
        }
        this.SSetting.Visible = false;
        if (Session["UserRole"].ToString().Contains("项目进度设置"))
        {
            this.SSetting.Visible = true;
        }
        this.Maintenance.Visible = false;
        if (Session["UserRole"].ToString().Contains("项目进度维护"))
        {
            this.Maintenance.Visible = true;
        }
        this.PSupply.Visible = false;
        if (Session["UserRole"].ToString().Contains("供应商信息维护"))
        {
            this.PSupply.Visible = true;
        }
        this.SLook.Visible = false;
        if (Session["UserRole"].ToString().Contains("供应商信息查看"))
        {
            this.SLook.Visible = true;
        }
        this.CertificApplyLook.Visible = false;
        if (Session["UserRole"].ToString().Contains("供应商认证申请查看"))
        {
            this.CertificApplyLook.Visible = true;
        }
        this.CertificApply.Visible = false;
        if (Session["UserRole"].ToString().Contains("供应商认证申请"))
        {
            this.CertificApply.Visible = true;
        }
        this.CertificEdit.Visible = false;
        if (Session["UserRole"].ToString().Contains("供应商认证制定"))
        {
            this.CertificEdit.Visible = true;
        }
        this.CertificSign.Visible = false;
        if (Session["UserRole"].ToString().Contains("供应商认证会签"))
        {
            this.CertificSign.Visible = true;
        }
        this.CertificPreCheck.Visible = false;
        if (Session["UserRole"].ToString().Contains("技术副总供应商认证审核"))
        {
            this.CertificPreCheck.Visible = true;
        }
        this.CertificCheck.Visible = false;
        if (Session["UserRole"].ToString().Contains("总经理供应商认证审核"))
        {
            this.CertificCheck.Visible = true;
        }
        this.PurchasingPlanLook.Visible = false;
        if (Session["UserRole"].ToString().Contains("采购计划查看"))
        {
            this.PurchasingPlanLook.Visible = true;
        }
        this.Chip.Visible = false;
        if (Session["UserRole"].ToString().Contains("芯片价格录入"))
        {
            this.Chip.Visible = true;
        }
        this.Other.Visible = false;
        if (Session["UserRole"].ToString().Contains("原材料价格录入"))
        {
            this.Other.Visible = true;
        }
        this.PurchasingPlanEdit.Visible = false;
        if (Session["UserRole"].ToString().Contains("采购计划维护"))
        {
            this.PurchasingPlanEdit.Visible = true;
        }
        this.PurchasingPlanCheck.Visible = false;
        if (Session["UserRole"].ToString().Contains("采购计划审核"))
        {
            this.PurchasingPlanCheck.Visible = true;
        }
        this.PurchasingPlanBuy.Visible = false;
        if (Session["UserRole"].ToString().Contains("采购计划执行"))
        {
            this.PurchasingPlanBuy.Visible = true;
        }
      
        this.ApplyRule.Visible = false;
        if (Session["UserRole"].ToString().Contains("采购申请规则制定"))
        {
            this.ApplyRule.Visible = true;
        }
        this.PMake.Visible = false;
        if (Session["UserRole"].ToString().Contains("采购申请制定"))
        {
            this.PMake.Visible = true;
        }
        this.MCheck.Visible = false;
        if (Session["UserRole"].ToString().Contains("采购申请审核") || Session["UserRole"].ToString().Contains("采购申请财务主管审核") || Session["UserRole"].ToString().Contains("采购申请财务总监审核") || Session["UserRole"].ToString().Contains("采购申请部门副总审核") || Session["UserRole"].ToString().Contains("采购申请技术副总审核") || Session["UserRole"].ToString().Contains("采购申请人事部审核"))
        {
            this.MCheck.Visible = true;
        }
        this.Emergency.Visible = false;
        if (Session["UserRole"].ToString().Contains("紧急采购申请"))
        {
            this.Emergency.Visible = true;
        }
        this.Maintain.Visible = false;
        if (Session["UserRole"].ToString().Contains("采购申请执行维护") || Session["UserRole"].ToString().Contains("采购申请单价填写"))
        {
            this.Maintain.Visible = true;
        }
        this.Order.Visible = false;
        if (Session["UserRole"].ToString().Contains("采购订单制定"))
        {
            this.Order.Visible = true;
        }
        this.Bill.Visible = false;
        if (Session["UserRole"].ToString().Contains("采购开票"))
        {
            this.Bill.Visible = true;
        }

      
        this.EMake.Visible = false;
        if (Session["UserRole"].ToString().Contains("采购设备申请制定"))
        {
            this.EMake.Visible = true;
        }
        this.ESupplyCheck.Visible = false;
        if (Session["UserRole"].ToString().Contains("总经理设备采购审核") || Session["UserRole"].ToString().Contains("技术副总设备采购审核") || Session["UserRole"].ToString().Contains("采购设备申请审核") || Session["UserRole"].ToString().Contains("设备采购财务总监审核"))
        {
            this.ESupplyCheck.Visible = true;
        }
        this.ESupplyPurchase.Visible = false;
        if (Session["UserRole"].ToString().Contains("设备采购制定"))
        {
            this.ESupplyPurchase.Visible = true;//设备采购
        }
        this.ESupplyTest.Visible = false;
        if (Session["UserRole"].ToString().Contains("设备采购调试"))
        {
            this.ESupplyTest.Visible = true;
        }
        this.EAcceptCheck.Visible = false;
        if (Session["UserRole"].ToString().Contains("设备采购验收审核"))
        {
            this.EAcceptCheck.Visible = true;
        }
        this.Foundry.Visible = false;
        if (Session["UserRole"].ToString().Contains("铜材代工"))
        {
            this.Foundry.Visible = true;
        }
        #endregion
        #region 采购付款
        if (Session["UserRole"].ToString().Contains("付款月计划查看"))
        {
            PaymentMonthPlanLook.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("付款月计划制定"))
        {
            PaymentMonthPlanMake.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("付款周计划查看"))
        {
            PaymentWeekPlanLook.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("付款周计划制定"))
        {
            PaymentWeekPlanMake.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("采购付款"))
        {
            PaymentPay.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("采购付款报表"))
        {
            PaymentReport.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("采购报表"))
        {
            PurchaseReport.Visible = true;
        }
        #endregion
        #region 合格率报表
        if (Session["UserRole"].ToString().Contains("工程部型号合格率报表"))
        {
            ProjectProType.Visible = true;
        } if (Session["UserRole"].ToString().Contains("工程部设备合格率报表"))
        {
            ProjectEquipment.Visible = true;
        } if (Session["UserRole"].ToString().Contains("工程部材料合格率报表"))
        {
            ProjectMaterial.Visible = true;
        } if (Session["UserRole"].ToString().Contains("工程部系列合格率报表"))
        {
            ProjectSeries.Visible = true;
        } if (Session["UserRole"].ToString().Contains("品保部合格率报表"))
        {
            QAMainSeries.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("孙总浇灌/塑封/模块合格率报表"))
        {
            SunType.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("孙总浇灌/塑封/模块年度合格率趋势报表"))
        {
            SunTypeYear.Visible = true;
        }

        if (Session["UserRole"].ToString().Contains("孙总浇灌/塑封/模块历年同月合格率趋势报表"))
        {
            SunTypeMonth.Visible = true;
        }

        if (Session["UserRole"].ToString().Contains("孙总大型号合格率报表"))
        {
            SunMainSeries.Visible = true;
        }

        if (Session["UserRole"].ToString().Contains("孙总大型号年度合格率报表"))
        {
            SunMainSeriesYear.Visible = true;
        }

        if (Session["UserRole"].ToString().Contains("孙总大型号历年同月合格率报表"))
        {
            SunMainSeriesMonth.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("孙总系列合格率报表"))
        {
            SunSeries.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("孙总系列年度合格率趋势报表"))
        {
            SunSeriesYear.Visible = true;
        }
        if (Session["UserRole"].ToString().Contains("孙总系列历年同月合格率趋势报表"))
        {
            SunSeriesMonth.Visible = true;
        }

        #endregion
        #region 随工单产品代码维护CC
        this.codeman.Visible = false;
        if (Session["UserRole"].ToString().Contains("随工单产品代码维护"))
        {
            this.codeman.Visible = true;
        }
        this.codelook.Visible = false;
        if (Session["UserRole"].ToString().Contains("随工单产品代码查看"))
        {
            this.codelook.Visible = true;
        }
        #endregion

        #region 生产计划部门会签CC
        this.scyjhhqbmgl.Visible = false;
        if (Session["UserRole"].ToString().Contains("生产月计划会签维护"))
        {
            this.scyjhhqbmgl.Visible = true;
        }
        this.sczjhhqbmgl.Visible = false;
        if (Session["UserRole"].ToString().Contains("生产周计划会签维护"))
        {
            this.sczjhhqbmgl.Visible = true;
        }
        this.mkyjhhqbmgl.Visible = false;
        if (Session["UserRole"].ToString().Contains("模块月计划会签维护"))
        {
            this.mkyjhhqbmgl.Visible = true;
        }
        this.mkzjhhqbmgl.Visible = false;
        if (Session["UserRole"].ToString().Contains("模块周计划会签维护"))
        {
            this.mkzjhhqbmgl.Visible = true;
        }
        #endregion

        #region 报表CC
        this.HRMan.Visible = false;
        if (Session["UserRole"].ToString().Contains("人员配置统计表"))
        {
            this.HRMan.Visible = true;
        }
        this.Spare.Visible = false;
        if (Session["UserRole"].ToString().Contains("备件领用统计表"))
        {
            this.Spare.Visible = true;
        }
		this.ControlledDocApp.Visible = false;
        if (Session["UserRole"].ToString().Contains("各部门受控文件一览表"))
        {
            this.ControlledDocApp.Visible = true;
        }

        this.ControlledDocAppHandout.Visible = false;
        if (Session["UserRole"].ToString().Contains("受控文件分发一览表"))
        {
            this.ControlledDocAppHandout.Visible = true;
        }

        this.EquipUpkeepPlan.Visible = false;
        if (Session["UserRole"].ToString().Contains("设备保养完成情况统计表"))
        {
            this.EquipUpkeepPlan.Visible = true;
        }
		
		this.IQCSum.Visible = false;
        if (Session["UserRole"].ToString().Contains("IQC检验汇总表"))
        {
            this.IQCSum.Visible = true;
        }

        this.EquipMaintenance.Visible = false;
        if (Session["UserRole"].ToString().Contains("设备台账故障停机统计表"))
        {
            this.EquipMaintenance.Visible = true;
        }
        this.StoreTotal.Visible = false;
        if (Session["UserRole"].ToString().Contains("库存明细账汇总表"))
        {
            this.StoreTotal.Visible = true;
        }
        this.EquipMaintenanceTotal.Visible = false;
        if (Session["UserRole"].ToString().Contains("设备故障停机统计总表"))
        {
            this.EquipMaintenanceTotal.Visible = true;
        }
        this.EquipOutput.Visible = false;
        if (Session["UserRole"].ToString().Contains("设备产量统计表"))
        {
            this.EquipOutput.Visible = true;
        }
		this.ExpTest.Visible = false;
        if (Session["UserRole"].ToString().Contains("实验数据统计表"))
        {
            this.ExpTest.Visible = true;
        }
        this.Equiptrend.Visible = false;
        if (Session["UserRole"].ToString().Contains("设备维修率和停机率统计表"))
        {
            this.Equiptrend.Visible = true;
        }
        this.CustomerComplaint.Visible = false;
        if (Session["UserRole"].ToString().Contains("客户投诉汇总表"))
        {
            this.CustomerComplaint.Visible = true;
        }
        this.SalesOrder.Visible = false;
        if (Session["UserRole"].ToString().Contains("订单完成情况统计表"))
        {
            this.SalesOrder.Visible = true;
        }
		
		this.OrderDeliver.Visible = false;
        if (Session["UserRole"].ToString().Contains("销售发货单"))
        {
            this.OrderDeliver.Visible = true;
        }
		this.OrderReturn.Visible = false;
        if (Session["UserRole"].ToString().Contains("销售退货单"))
        {
            this.OrderReturn.Visible = true;
        }

		this.CRMCompanySampleCount.Visible = false;
        if (Session["UserRole"].ToString().Contains("每月样品统计"))
        {
            this.CRMCompanySampleCount.Visible = true;
        }
		this.SalesMonthPlanFinisih.Visible = false;
        if (Session["UserRole"].ToString().Contains("每月销售计划完成情况统计"))
        {
            this.SalesMonthPlanFinisih.Visible = true;
        }

		this.CRMCustomerInfoBind_Condition.Visible = false;
        if (Session["UserRole"].ToString().Contains("客户档案汇总表"))
        {
            this.CRMCustomerInfoBind_Condition.Visible = true;
        }
		this.PRMProject_IsFinish.Visible = false;
        if (Session["UserRole"].ToString().Contains("项目完成情况汇总"))
        {
            this.PRMProject_IsFinish.Visible = true;
        }
		this.PMPurchaseApplyMaterial_Department.Visible = false;
        if (Session["UserRole"].ToString().Contains("采购申请物料数量汇总"))
        {
            this.PMPurchaseApplyMaterial_Department.Visible = true;
        }

		this.PMPurchaseApplyMaterial_Num.Visible = false;
        if (Session["UserRole"].ToString().Contains("采购申请部门申请情况汇总"))
        {
            this.PMPurchaseApplyMaterial_Num.Visible = true;
        }
		this.OfficeAppliance.Visible = false;
        if (Session["UserRole"].ToString().Contains("每月办公用品申请汇总"))
        {
            this.OfficeAppliance.Visible = true;
        }
		this.ProType.Visible = false;
        if (Session["UserRole"].ToString().Contains("产品型号说明表"))
        {
            this.ProType.Visible = true;
        }

        this.TimePerDayDetail.Visible = false;
        if (Session["UserRole"].ToString().Contains("计时信息详情表"))
        {
            this.TimePerDayDetail.Visible = true;
        }

        this.ATimeTotal.Visible = false;
        if (Session["UserRole"].ToString().Contains("计时信息阶段统计表"))
        {
            this.ATimeTotal.Visible = true;
        }
        this.APiecePerDayDetail.Visible = false;
        if (Session["UserRole"].ToString().Contains("计件信息详情表"))
        {
            this.APiecePerDayDetail.Visible = true;
        }
        this.APieceTotal.Visible = false;
        if (Session["UserRole"].ToString().Contains("计件信息阶段统计表"))
        {
            this.APieceTotal.Visible = true;
        }


		      this.ReturnPayDetail.Visible = false;
        if (Session["UserRole"].ToString().Contains("回款详细表"))
        {
            this.ReturnPayDetail.Visible = true;
        }
			this.ReturnPayPlan.Visible = false;
        if (Session["UserRole"].ToString().Contains("回款计划表"))
        {
            this.ReturnPayPlan.Visible = true;
        }

			this.NewCustomerSales.Visible = false;
        if (Session["UserRole"].ToString().Contains("新客户销售额汇总"))
        {
            this.NewCustomerSales.Visible = true;
        }
		
		this.SMDetailReport.Visible = false;
        if (Session["UserRole"].ToString().Contains("客户明细账"))
        {
            this.SMDetailReport.Visible = true;
        }
        this.SaleAnalysis.Visible = false;
        if (Session["UserRole"].ToString().Contains("销售分析表"))
        {
            this.SaleAnalysis.Visible = true;
        }
		this.SalesDetailGather.Visible = false;
        if (Session["UserRole"].ToString().Contains("销售明细汇总"))
        {
            this.SalesDetailGather.Visible = true;
        }
		this.BillApply.Visible = false;
        if (Session["UserRole"].ToString().Contains("开票申请汇总"))
        {
            this.BillApply.Visible = true;
        }
		
		this.ProductSum.Visible = false;
        if (Session["UserRole"].ToString().Contains("产品流量统计"))
        {
            this.ProductSum.Visible = true;
        }
        this.TotalIM.Visible = false;
        if (Session["UserRole"].ToString().Contains("库存统计报表"))
        {
            this.TotalIM.Visible = true;
        }
        this.SalesPerformance.Visible = false;
        if (Session["UserRole"].ToString().Contains("销售业绩一览表"))
        {
            this.SalesPerformance.Visible = true;
        }
        this.Reward.Visible = false;
        if (Session["UserRole"].ToString().Contains("人员奖惩表"))
        {
            this.Reward.Visible = true;
        }
        this.PersonnelChangeDetail.Visible = false;
        if (Session["UserRole"].ToString().Contains("人事异动报表"))
        {
            this.PersonnelChangeDetail.Visible = true;
        }
		
		this.QuitInfo.Visible = false;
        if (Session["UserRole"].ToString().Contains("离职日报表"))
        {
            this.QuitInfo.Visible = true;
        }
		this.WOError_Statistics.Visible = false;
        if (Session["UserRole"].ToString().Contains("异常统计表"))
        {
            this.WOError_Statistics.Visible = true;
        }
		
		this.RightTimeSM.Visible = false;
        if (Session["UserRole"].ToString().Contains("订单库存在制品一览表"))
        {
            this.RightTimeSM.Visible = true;
        }
		this.SalaryEachMonthAnalysis.Visible = false;
        if (Session["UserRole"].ToString().Contains("月度薪资分析表"))
        {
            this.SalaryEachMonthAnalysis.Visible = true;
        }
		this.SalaryYearCompare.Visible = false;
        if (Session["UserRole"].ToString().Contains("年度薪资对比表"))
        {
            this.SalaryYearCompare.Visible = true;
        }
		
		this.Chanliang.Visible = false;
        if (Session["UserRole"].ToString().Contains("工人计件产量报表"))
        {
            this.Chanliang.Visible = true;
        }
        this.PersonnelSalaryRecord.Visible = false;
        if (Session["UserRole"].ToString().Contains("人事调薪报表"))
        {
            this.PersonnelSalaryRecord.Visible = true;
        }
        this.SalaryDetailEachMonth.Visible = false;
        if (Session["UserRole"].ToString().Contains("每月薪资汇总表"))
        {
            this.SalaryDetailEachMonth.Visible = true;
        }
        this.PerformceDetail.Visible = false;
        if (Session["UserRole"].ToString().Contains("年度中层管理干部绩效考核统计表"))
        {
            this.PerformceDetail.Visible = true;
        }
        this.WIP_CJCLB.Visible = false;
        if (Session["UserRole"].ToString().Contains("生产工序产量汇总表"))
        {
            this.WIP_CJCLB.Visible = true;
        }
		
		this.TrainingEachMonthAnalysis.Visible = false;
        if (Session["UserRole"].ToString().Contains("培训月报表"))
        {
            this.TrainingEachMonthAnalysis.Visible = true;
        }
		this.WIP_PBC.Visible = false;
        if (Session["UserRole"].ToString().Contains("工序产量统计表"))
        {
            this.WIP_PBC.Visible = true;
        }
        this.PieceChage.Visible = false;
        if (Session["UserRole"].ToString().Contains("计件工价变动表"))
        {
            this.PieceChage.Visible = true;
        }
        this.TimeChage.Visible = false;
        if (Session["UserRole"].ToString().Contains("计时工价变动表"))
        {
            this.TimeChage.Visible = true;
        }
        this.SXJ_BLPLX.Visible = false;
        if (Session["UserRole"].ToString().Contains("不良品分类统计表"))
        {
            this.SXJ_BLPLX.Visible = true;
        }
        this.QuitCountPercent.Visible = false;
        if (Session["UserRole"].ToString().Contains("人员流失率年报表"))
        {
            this.QuitCountPercent.Visible = true;
        }
        this.QuitWorkAge.Visible = false;
        if (Session["UserRole"].ToString().Contains("人员流失工龄年报表"))
        {
            this.QuitWorkAge.Visible = true;
        }
        this.IPQCBad.Visible = false;
        if (Session["UserRole"].ToString().Contains("制程IPQC不良品汇总表"))
        {
            this.IPQCBad.Visible = true;
        }
        this.WIP_BadPro_BigType.Visible = false;
        if (Session["UserRole"].ToString().Contains("不同规格不良品统计表"))
        {
            this.WIP_BadPro_BigType.Visible = true;
        }

        this.WIP_BadPro_Series.Visible = false;
        if (Session["UserRole"].ToString().Contains("在制品不良汇总统计表（不同规格）"))
        {
            this.WIP_BadPro_Series.Visible = true;
        }
     this.PersonnelTransferEachMonth.Visible = false;
        if (Session["UserRole"].ToString().Contains("人事流动月报表"))
        {
            this.PersonnelTransferEachMonth.Visible = true;
        }
 
     this.MidLeaderPerform.Visible = false;
        if (Session["UserRole"].ToString().Contains("中干绩效考核表"))
        {
            this.MidLeaderPerform.Visible = true;
        }
        this.jsmxtj.Visible = false;
        if (Session["UserRole"].ToString().Contains("年度计时工资信息统计表"))
        {
            this.jsmxtj.Visible = true;
        }
        this.SalaryCountIn12Months.Visible = false;
        if (Session["UserRole"].ToString().Contains("年度薪资分析表"))
        {
            this.SalaryCountIn12Months.Visible = true;
        }
        this.WIP_CWTJ.Visible = false;
        if (Session["UserRole"].ToString().Contains("财务部在制品统计表"))
        {
            this.WIP_CWTJ.Visible = true;
        }

        this.TakeInventory.Visible = false;
        if (Session["UserRole"].ToString().Contains("财务部在制品盘存统计表"))
        {
            this.TakeInventory.Visible = true;
        }
        this.InOutStoreSum.Visible = false;
        if (Session["UserRole"].ToString().Contains("出入库发货统计表"))
        {
            this.InOutStoreSum.Visible = true;
        }
        this.InManufacturingSum.Visible = false;
        if (Session["UserRole"].ToString().Contains("在制品数量统计表"))
        {
            this.InManufacturingSum.Visible = true;
        }
        #endregion 报表CC
		
    }
    private void Ini()
    {
        if (Request.Cookies[".ASPXAUTH"] != null)
        {

            TreeNode tn0 = new TreeNode();
            tn0.SelectAction = TreeNodeSelectAction.Expand;
            tn0.Text = "测试";

            //tn0.ChildNodes.Add(new TreeNode("组织机构", "组织机构", null, "~/BasicDataMgt/BDOrganizationSheet.aspx", null));
            //tn0.ChildNodes.Add(new TreeNode("用户管理", "用户管理", null, "~/UserMgt/UMUserManagement.aspx", null));
            //tn0.ChildNodes.Add(new TreeNode("日历控件", "日历控件", null, "~/EquipMgt/EMEquipList.aspx", null));
            //tn0.ChildNodes.Add(new TreeNode("公告及短信", "公告及短信", null, "~/Other/WelcomePage.aspx", null));
            //this.TreeView1.Nodes.Add(tn0);

        }
    }
}




