using System;
using System.Data;

/// <summary>
///ProSeriesInfo_ProTypeL 的摘要说明
/// </summary>
public class ProSeriesInfo_ProTypeL
{
    private static readonly IProSeriesInfo_ProType pspt = DALFactory.CreateProSeriesInfo_ProType();
    public ProSeriesInfo_ProTypeL()
    { }
    public DataSet SList_ProSeries()//检索所有产品系列
    {

        return pspt.SList_ProSeries();

    }

    public DataSet S_PBCraftInfo(Guid pBC_ID)//检索某工序
    {

        return pspt.S_PBCraftInfo(pBC_ID);
    }

    public DataSet S_PR_Name()//检索工艺路线名称
    {
        return pspt.S_PR_Name();
    }
    public DataSet S_BOM_Name()//检索BOM名称
    {
        return pspt.S_BOM_Name();
    }

    public void I_ProSeries(ProSeriesInfo_ProTypeInfo proSeriesInfo_ProTypeInfo)//插入新的产品系列
    {
        pspt.I_ProSeries(proSeriesInfo_ProTypeInfo);
    }

    public DataSet S_ProSeries(string pS_Name)//模糊检索产品系列
    {
        return pspt.S_ProSeries(pS_Name);

    }

    public DataSet S_ProSeries_Name(string pS_Name)
    {
        return pspt.S_ProSeries_Name(pS_Name);

    }
    public void U_ProSeries(ProSeriesInfo_ProTypeInfo proSeriesInfo_ProTypeInfo)//编辑产品系列名称
    {
        pspt.U_ProSeries(proSeriesInfo_ProTypeInfo);
    }
    public int D_ProSeries(Guid pS_ID)//删除产品系列
    {
        return pspt.D_ProSeries(pS_ID);
    }
    public DataSet S_ProSeries_ProType(string condition)//查看一种产品系列所属产品型号
    {
        return pspt.S_ProSeries_ProType(condition);

    }
    public DataSet SPTName_ProSeries_ProType(Guid pS_ID, string pT_Name)//检索一种产品系列特定产品型号
    {
        return pspt.SPTName_ProSeries_ProType(pS_ID, pT_Name);
    }

    public void I_ProType(ProSeriesInfo_ProTypeInfo proSeriesInfo_ProTypeInfo)//新增产品型号
    {
        pspt.I_ProType(proSeriesInfo_ProTypeInfo);
    }
    public void I_ProType_new(ProSeriesInfo_ProTypeInfo proSeriesInfo_ProTypeInfo, string PT_Parameters, string PT_Code)//新增产品型号_新
    {
        pspt.I_ProType_new(proSeriesInfo_ProTypeInfo, PT_Parameters,PT_Code);
    }
    public void U_ProType(ProSeriesInfo_ProTypeInfo proSeriesInfo_ProTypeInfo)//编辑产品型号
    {
        pspt.U_ProType(proSeriesInfo_ProTypeInfo);
    }
    public void U_ProType_new(ProSeriesInfo_ProTypeInfo proSeriesInfo_ProTypeInfo, string PT_Parameters, string PT_Code)//编辑产品型号_新

    {
        pspt.U_ProType_new(proSeriesInfo_ProTypeInfo, PT_Parameters,PT_Code);
    }
    public int D_ProType(Guid pT_ID)//删除产品型号
    {
        return pspt.D_ProType(pT_ID);
    }
    public DataSet S_ProType_ProcessRoute(Guid pR_ID)//显示某产品型号的工艺路线
    {
        return pspt.S_ProType_ProcessRoute(pR_ID);
    }

    public void I_ProProcessParameter(ProSeriesInfo_ProTypeInfo proSeriesInfo_ProTypeInfo)//编辑产品某个工序的工艺参数
    {
        pspt.I_ProProcessParameter(proSeriesInfo_ProTypeInfo);
    }


    public void U_ProProcessParameter(ProSeriesInfo_ProTypeInfo proSeriesInfo_ProTypeInfo)//编辑产品某个工序的工艺参数
    {
        pspt.U_ProProcessParameter(proSeriesInfo_ProTypeInfo);
    }

    public DataSet S_ProProcessParameter(Guid pT_ID, Guid pBC_ID)//查询产品某个工序的工艺参数
    {
        return pspt.S_ProProcessParameter(pT_ID, pBC_ID);
    }
    public void I_ProMainSeries(string pMS_Name)//新增产品大型号
    {
        pspt.I_ProMainSeries(pMS_Name);
    }
    public void U_ProMainSeries(Guid pMS_ID, string pMS_Name)//编辑产品大型号
    {
        pspt.U_ProMainSeries(pMS_ID, pMS_Name);
    }
    public void D_ProMainSeries(Guid pMS_ID)//删除产品大型号
    {
        pspt.D_ProMainSeries(pMS_ID);
    }

    public DataSet S_ProMainSeries(string condition)//查询产品大型号
    {
        return pspt.S_ProMainSeries(condition);
    }

    public void U_Protype_ProMainSeries(Guid pMS_ID, Guid pT_ID)//为产品型号添加产品大型号
    {
        pspt.U_Protype_ProMainSeries(pMS_ID, pT_ID);
    }

    public void D_Protype_ProMainSeries(Guid pT_ID)//删除产品型号的产品大型号
    {
        pspt.D_Protype_ProMainSeries( pT_ID);
    }

    public DataSet S_Protype_ProMainSeries(string condition)//检索待选产品型号
    {
        return pspt.S_Protype_ProMainSeries(condition);
    }
    public DataSet S_ProMainSeries_Protype(string condition)//检索所属产品型号
    {
        return pspt.S_ProMainSeries_Protype(condition);
    }
    public DataSet S_ProType_new(string condition)//检索所属产品型号

    {
        return pspt.S_ProType_new(condition);
    }
    public DataSet S_ProType_WorkOrder(string PT_Name)//检查随工单里是否有该产品型号名称
    {
        return pspt.S_ProType_WorkOrder(PT_Name);
    }
    public DataSet S_PTCB()//产品编码属性检索
    {
        return pspt.S_PTCB();
    }
    public DataSet S_PTCB_Detail(string condition, string PTCB_Section)//检索产品编码详情

    {
        return pspt.S_PTCB_Detail(condition, PTCB_Section);
    }
    public void D_PTCB_Detail(Guid PTCB_ID)//删除产品编码详情
    {
        pspt.D_PTCB_Detail(PTCB_ID);
    }
    public void I_PTCB_Detail(int PTCB_Section, string PTCB_Code, string PTCB_Detail)//新增产品编码详情

    {
        pspt.I_PTCB_Detail(PTCB_Section, PTCB_Code, PTCB_Detail);
    }
    public void U_PTCB_Detail(Guid PTCB_ID, string PTCB_Code, string PTCB_Detail)//编辑产品编码详情

    {
        pspt.U_PTCB_Detail(PTCB_ID, PTCB_Code, PTCB_Detail);
    }
    public void U_Protype_ProSeries(Guid pS_ID, Guid pT_ID)//为产品型号添加产品系列

    {
        pspt.U_Protype_ProSeries(pS_ID, pT_ID);
    }
    public void D_Protype_ProSeries(Guid pT_ID)//删除产品型号的产品系列

    {
        pspt.D_Protype_ProSeries(pT_ID);
    }
    public DataSet S_Protype_ProSeries_ForChose(string condition)//检索待选产品型号

    {

        return pspt.S_Protype_ProSeries_ForChose(condition);
    }
    public DataSet S_ErrorPhenomenonOptionDetail(string EPO_ID, string condition)//查询异常选项详细项目
    {
       return  pspt.S_ErrorPhenomenonOptionDetail(EPO_ID,condition);
    }
    public void U_ErrorPhenomenonOptionDetail(Guid EPOD_ID, string EPOD_Name, Guid PBC_ID)//编辑异常选项详细项目

    {
         pspt.U_ErrorPhenomenonOptionDetail(EPOD_ID, EPOD_Name,  PBC_ID);
    }
    public void I_ErrorPhenomenonOptionDetail(Guid EPO_ID, string EPOD_Name, Guid PBC_ID)//新建异常选项详细项目

    {
        pspt.I_ErrorPhenomenonOptionDetail(EPO_ID, EPOD_Name, PBC_ID);
    }
    public void D_ErrorPhenomenonOptionDetail(Guid EPOD_ID)//删除异常选项详细项目

    {
        pspt.D_ErrorPhenomenonOptionDetail(EPOD_ID);
    }
}