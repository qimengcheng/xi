using System;
using System.Data;

/// <summary>
///IWorkOrder 的摘要说明
/// </summary>
public interface IWorkOrder
{
    DataSet S_WorkOrder(string condition);
    DataSet S_ProType_BOM(string pT_Name);//显示某产品型号的BOM
    DataSet S_WO_ProType_ProcessRoute(string pT_Name, int isrenzheng);//随工单生成中显示某产品型号的工艺路线
    DataSet S_ProType_TestParameter(string pT_Name);//查询某产品型号的测试参数
    void I_WorkOrder(WorkOrderInfo workOrderInfo,string code,string typecode);//新增随工单
    DataSet S_WO_SMSalesOrder(string condition);//增加随工单时检索订单号
    DataSet S_WOMBatchNum(Guid iMMBD_MaterialID, Guid wO_ID);//查看随工单批号信息
    DataSet S_WOMBatchNum_IMInventoryDetail(string condition);//查看某物料批号信息
    void I_WOMBatchNum(Guid iMMBD_MaterialID, Guid wO_ID, string wOMBN_BN);//新增随工单批号
    void D_WOMBatchNum(Guid wOMBN_ID);//删除随工单批号
    void I_IMRequisitionMain_WorkOrder(Guid wO_ID, string pT_Name, string iMRM_Man, string iMRM_Depart);//分工序生成领料单
    DataSet S_IMRequisitionMain_WorkOrder(Guid wO_ID);//查询分工序的领料单
    DataSet s_protype_bom_wo(string ptName, decimal pNum);//显示随工单参考领料信息
    void I_IMRequisitionDetail_WorkOrder(Guid iMRM_RequisitionID, Guid iMMBD_MaterialID, decimal iMRD_StandardNum, decimal iMRD_ActualNum,string iMRD_WorkOrderNum);//新增领料单详细
    DataSet s_protype_bom_wo_craft(string ptName, decimal pNum, Guid iMRM_RequisitionID, string pbcname);//显示随工单的各工序的领料信息
    DataSet s_imrequisitiondetail_ID_workorder(Guid iMRD_ID);//检索领料单详细记录以判重
    void U_imrequisitiondetail_workorder(Guid iMRD_ID, decimal iMRD_ActualNum);//编辑领料单详细
    void D_WorkOrder(Guid wO_ID);//删除随工单主表


}