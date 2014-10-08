using System;
using System.Collections.Generic;
using System.Data;

/// <summary>
///IExpAppSubmit 的摘要说明
/// </summary>
public interface IExpAppSubmit
{
    //新建实验申请
    int Insert_ExpTestApp(ExpTestAppInfo et);

    //修改实验申请单
    void Update_ExpTestApp(ExpTestAppInfo et);

    //修改实验申请列表状态
    void Update_ExpTestApp_Status(Guid ETA_ExpID);

    //申请时修改申请内容
    void Update_ExpTestAppApp(ExpTestAppInfo et);

    //实验审核时修改申请表
    void Update_ExpTestAppAu(ExpTestAppInfo et);

    //接收实验申请单时修改申请单
    void Update_ExpTestAppAck(ExpTestAppInfo et);

     //录入实验申请单时修改申请单
    void Update_ExpTestAppRes(ExpTestAppInfo et);

    //实验结果审批时修改申请单
    void Update_ExpTestAppArl(ExpTestAppInfo et);

    //在申请页面GridView编辑，根据ID查询实验申请单，转为字符串？有误则查字符与数字转换
    IList<ExpTestAppInfo> Search_ExpTestApp_ID(Guid ETA_ExpID);

    //模糊查询试验申请condition方式
    DataSet Search_ExpTestApp_GridView1(string Condition);

    //对组织机构中部门的检索，此处QZL处以写存储过程及数据层函数
    DataSet Search_ExpTestApp_BDOrganizationSheet();

    //删除
    void Delete_ExpTestApp(Guid ID);

    //新建实验各项目结果表
    int Insert_ExpItemsRes(Guid EIR_ResDetailID, Guid ETA_ExpID, Guid EI_ExpItemID, int EIR_ItemAmount);

    //修改实验各项目结果表
    void Update_ExpItemsRes(Guid EIR_ResDetailID, int EIR_ItemAmount, int EIR_ItemAcceptance, string EIR_ItemRes, string EIR_Remaks);

    //修改实验申请单，conditiong方式
    void Update_ExpTestApp1(string ETA_ExpID, string condition);

    //根据申请单ID检索申请单的实验项目结果
    DataSet Search_ExpItemsRes_ID(Guid ETA_ExpID);

    //根据实验项目明细表ID查询实验项目明细表
    IList<ExpTestAppInfo> Search_ExpItemsRes_ResID(Guid EIR_ResDetailID);

    //检查是否存在指定申请单的指定实验项目
    int Search_CheckExpItem(Guid ETA_ExpID, Guid EI_ExpItemID);

    //删除实验各项目结果表
    void Delete_ExpItemsRes(Guid ID);

    //点击新增时生成空主表
    void Insert_ExpTestApp_View();

    //点击新增时生成空主表
    void Delete_ExpTestApp_View();

    //查询主表ID    
    IList<ExpTestAppInfo> Search_ExpItemsRes_ResID();
}