using System;
using System.Data;

/// <summary>
///WorkOrderL 的摘要说明
/// </summary>
public class WorkOrderL
{
    private static readonly IWorkOrder iwo = DALFactory.CreateWorkOrder();

    public WorkOrderL()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }
    public DataSet S_WorkOrder(string condition)//检索随工单主表
    {
        return iwo.S_WorkOrder(condition);
    }
    public DataSet S_ProType_BOM(string pT_Name)//显示某产品型号的BOM
    {
        return iwo.S_ProType_BOM(pT_Name);
    }
    public DataSet S_WO_ProType_ProcessRoute(string pT_Name, int isrenzheng)//随工单生成中显示某产品型号的工艺路线
    {
        return iwo.S_WO_ProType_ProcessRoute(pT_Name, isrenzheng);
    }
    public DataSet S_ProType_TestParameter(string pT_Name)//查询某产品型号的测试参数
    {
        return iwo.S_ProType_TestParameter(pT_Name);
    }
    public void I_WorkOrder(WorkOrderInfo workOrderInfo,string code,string typecode)//新增随工单
    {
        iwo.I_WorkOrder(workOrderInfo,code,typecode);
    }
    public DataSet S_WO_SMSalesOrder(string condition)//增加随工单时检索订单号
    {
        return iwo.S_WO_SMSalesOrder(condition);
    }
    public DataSet S_WOMBatchNum(Guid iMMBD_MaterialID, Guid wO_ID)//查看随工单批号信息
    {
        return iwo.S_WOMBatchNum(iMMBD_MaterialID, wO_ID);
    }
    public DataSet S_WOMBatchNum_IMInventoryDetail(string condition)//查看某物料批号信息
    {
        return iwo.S_WOMBatchNum_IMInventoryDetail(condition);
    }
    public void I_WOMBatchNum(Guid iMMBD_MaterialID, Guid wO_ID, string wOMBN_BN)//新增随工单批号
    {
        iwo.I_WOMBatchNum(iMMBD_MaterialID, wO_ID, wOMBN_BN);
    }
    public void D_WOMBatchNum(Guid wOMBN_ID)//删除随工单批号
    {
        iwo.D_WOMBatchNum(wOMBN_ID);

    }
    public void I_IMRequisitionMain_WorkOrder(Guid wO_ID, string pT_Name, string iMRM_Man, string iMRM_Depart)//分工序生成领料单
    {
        iwo.I_IMRequisitionMain_WorkOrder(wO_ID, pT_Name, iMRM_Man, iMRM_Depart);
    }
    public DataSet S_IMRequisitionMain_WorkOrder(Guid wO_ID)//查询分工序的领料单
    {
        return iwo.S_IMRequisitionMain_WorkOrder(wO_ID);
    }
    public DataSet s_protype_bom_wo(string ptName, decimal pNum)
    {

        return iwo.s_protype_bom_wo(ptName, pNum);
    }//显示随工单参考领料信息

           public void I_IMRequisitionDetail_WorkOrder(Guid iMRM_RequisitionID, Guid iMMBD_MaterialID, decimal iMRD_StandardNum, decimal iMRD_ActualNum,string iMRD_WorkOrderNum)//新增领料单详细

    {
        iwo.I_IMRequisitionDetail_WorkOrder(iMRM_RequisitionID, iMMBD_MaterialID, iMRD_StandardNum, iMRD_ActualNum,iMRD_WorkOrderNum);
    }
    public DataSet s_protype_bom_wo_craft(string ptName, decimal pNum, Guid iMRM_RequisitionID, string pbcname)//显示随工单的各工序的领料信息
    {
        return iwo.s_protype_bom_wo_craft(ptName, pNum, iMRM_RequisitionID,pbcname);
    }
    
    public DataSet s_imrequisitiondetail_ID_workorder(Guid iMRD_ID)//检索领料单详细记录以判重
    {
        return iwo.s_imrequisitiondetail_ID_workorder(iMRD_ID);
    }
    public void U_imrequisitiondetail_workorder(Guid iMRD_ID, decimal iMRD_ActualNum)//编辑领料单详细
    {
        iwo.U_imrequisitiondetail_workorder(iMRD_ID, iMRD_ActualNum);
    }
    public void D_WorkOrder(Guid wO_ID)//删除随工单主表
    {
        iwo.D_WorkOrder(wO_ID);
    }
}