using System;
using System.Collections.Generic;
using System.Data;

/// <summary>
///ExpAppSubmitL 的摘要说明
/// </summary>
public class ExpAppSubmitL
{
    private static readonly IExpAppSubmit EAS = DALFactory.CreateExpTestAppInfo();
    public ExpAppSubmitL()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    //新建实验申请
    public int Insert_ExpTestApp(ExpTestAppInfo et)
    {
        return EAS.Insert_ExpTestApp(et);
    }

    //修改实验申请单
    public void Update_ExpTestApp(ExpTestAppInfo et)
    {
        EAS.Update_ExpTestApp(et);
    }

    //修改实验申请列表状态
    public void Update_ExpTestApp_Status(Guid ETA_ExpID)
    {
        EAS.Update_ExpTestApp_Status(ETA_ExpID);
    }

    //申请时修改申请内容
    public void Update_ExpTestAppApp(ExpTestAppInfo et)
    {
        EAS.Update_ExpTestAppApp(et);
    }

    //实验审核时修改申请表
    public void Update_ExpTestAppAu(ExpTestAppInfo et)
    {
        EAS.Update_ExpTestAppAu(et);
    }

    //接收实验申请单时修改申请单
    public void Update_ExpTestAppAck(ExpTestAppInfo et)
    {
        EAS.Update_ExpTestAppAck(et);
    }

    //录入实验申请单时修改申请单
        public void Update_ExpTestAppRes(ExpTestAppInfo et)
    {
        EAS.Update_ExpTestAppRes(et);
    }

    //实验结果审批时修改申请单
        public void Update_ExpTestAppArl(ExpTestAppInfo et)
    {
        EAS.Update_ExpTestAppArl(et);
    }

    //修改实验申请单，conditiong方式
    public void Update_ExpTestApp1(string ETA_ExpID, string condition)
    {
        EAS.Update_ExpTestApp1(ETA_ExpID, condition);
    }

    //在申请页面GridView编辑，根据ID查询实验申请单，转为字符串？有误则查字符与数字转换
    public IList<ExpTestAppInfo> Search_ExpTestApp_ID(Guid ETA_ExpID)
    {
        return EAS.Search_ExpTestApp_ID(ETA_ExpID);
    }

    //模糊查询试验申请condition方式
    public DataSet Search_ExpTestApp_GridView1(string Condition)
    {
        return EAS.Search_ExpTestApp_GridView1(Condition);
    }

    //对组织机构中部门的检索，此处QZL处以写存储过程及数据层函数
    public DataSet Search_NETrainingItem_BDOrganizationSheet()
    {
        return EAS.Search_ExpTestApp_BDOrganizationSheet();
    }

    //删除
    public void Delete_ExpTestApp(Guid ID)
    {
        EAS.Delete_ExpTestApp(ID);
    }

    //新建实验各项目结果表
    public int Insert_ExpItemsRes(Guid EIR_ResDetailID, Guid ETA_ExpID, Guid EI_ExpItemID, int EIR_ItemAmount)
    {
        return EAS.Insert_ExpItemsRes(EIR_ResDetailID, ETA_ExpID, EI_ExpItemID, EIR_ItemAmount);
    }

    //修改实验各项目结果表
    public void Update_ExpItemsRes(Guid EIR_ResDetailID, int EIR_ItemAmount, int EIR_ItemAcceptance, string EIR_ItemRes, string EIR_Remaks)
    {
        EAS.Update_ExpItemsRes(EIR_ResDetailID, EIR_ItemAmount, EIR_ItemAcceptance, EIR_ItemRes, EIR_Remaks);
    }

    //根据申请单ID检索申请单的实验项目结果
    public DataSet Search_ExpItemsRes_ID(Guid ETA_ExpID)
    {
        return EAS.Search_ExpItemsRes_ID(ETA_ExpID);
    }

    //根据实验项目明细表ID查询实验项目明细表
    public IList<ExpTestAppInfo> Search_ExpItemsRes_ResID(Guid EIR_ResDetailID)
    {
        return EAS.Search_ExpItemsRes_ResID(EIR_ResDetailID);
    }

    //检查是否存在指定申请单的指定实验项目
    public int Search_CheckExpItem(Guid ETA_ExpID, Guid EI_ExpItemID)
    {
        return EAS.Search_CheckExpItem(ETA_ExpID, EI_ExpItemID);
    }

    //删除实验各项目结果表
    public void Delete_ExpItemsRes(Guid ID)
    {
        EAS.Delete_ExpItemsRes(ID);
    }

    //点击新增时生成空主表
    public void Insert_ExpTestApp_View()
    {
        EAS.Insert_ExpTestApp_View();
    }

    //点击新增时生成空主表
    public void Delete_ExpTestApp_View()
    {
        EAS.Delete_ExpTestApp_View();
    }

    //查询主表ID    
    public IList<ExpTestAppInfo> Search_ExpItemsRes_ResID()
    {
        return EAS.Search_ExpItemsRes_ResID();
    }
}