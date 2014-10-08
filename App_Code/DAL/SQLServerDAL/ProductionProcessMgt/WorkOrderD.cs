using System;
using System.Data;
using System.Data.SqlClient;
using EquipmentMangementAjax.DBUtility;

/// <summary>
///WorkOrderD 的摘要说明
/// </summary>
/// 
namespace EquipmentMangementAjax.SQLServer
{
    public class WorkOrderD : IWorkOrder
    {
        public WorkOrderD()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        public DataSet S_WorkOrder(string condition)//检索随工单主表
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@condition", SqlDbType.NVarChar, 2000);
            para[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_WorkOrder", para);

        }

        public DataSet S_ProType_BOM(string pT_Name)//显示某产品型号的BOM
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@PT_Name", SqlDbType.VarChar, 60);
            para[0].Value = pT_Name;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_ProType_BOM", para);

        }

        public DataSet S_WO_ProType_ProcessRoute(string pT_Name, int isrenzheng)//随工单生成中显示某产品型号的工艺路线
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@PT_Name", SqlDbType.VarChar, 60);
            para[0].Value = pT_Name;
            para[1] = new SqlParameter("@isrenzheng", SqlDbType.Int);
            para[1].Value = isrenzheng;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_WO_ProType_ProcessRoute", para);

        }

        public DataSet S_ProType_TestParameter(string pT_Name)//查询某产品型号的测试参数
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@PT_Name", SqlDbType.VarChar, 60);
            para[0].Value = pT_Name;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_ProType_TestParameter", para);

        }

        public void I_WorkOrder(WorkOrderInfo workOrderInfo,string code,string typecode)//新增随工单
        {
            SqlParameter[] para = new SqlParameter[11];
            para[0] = new SqlParameter("@code", SqlDbType.Char, 1);
            para[0].Value =code;
            para[1] = new SqlParameter("@WO_Type", SqlDbType.VarChar, 20);
            para[1].Value = workOrderInfo.WO_Type;
            para[2] = new SqlParameter("@WO_ProType", SqlDbType.VarChar, 60);
            para[2].Value = workOrderInfo.WO_ProType;
            para[3] = new SqlParameter("@WO_Level", SqlDbType.VarChar, 20);
            para[3].Value = workOrderInfo.WO_Level;
            para[4] = new SqlParameter("@WO_ChipNum", SqlDbType.VarChar, 30);
            para[4].Value = workOrderInfo.WO_ChipNum;
            para[5] = new SqlParameter("@WO_PNum", SqlDbType.Int);
            para[5].Value = workOrderInfo.WO_PNum;
            para[6] = new SqlParameter("@WO_Note", SqlDbType.VarChar, 200);
            para[6].Value = workOrderInfo.WO_Note;
            para[7] = new SqlParameter("@WO_People", SqlDbType.VarChar, 20);
            para[7].Value = workOrderInfo.WO_People;
            para[8] = new SqlParameter("@WO_OrderNum", SqlDbType.VarChar, 30);
            para[8].Value = workOrderInfo.WO_OrderNum;
            para[9] = new SqlParameter("@SMSO_ID", SqlDbType.UniqueIdentifier);
            para[9].Value = workOrderInfo.SMSO_ID;
			para[10] = new SqlParameter("@typecode", SqlDbType.VarChar,3);
            para[10].Value =typecode;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_WorkOrder", para);
        }

        public DataSet S_WO_SMSalesOrder(string condition)//增加随工单时检索订单号
        {

            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@condition", SqlDbType.VarChar, 2000);
            para[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_WO_SMSalesOrder", para);

        }
        public DataSet S_WOMBatchNum(Guid iMMBD_MaterialID, Guid wO_ID)//查看随工单批号信息
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@IMMBD_MaterialID", SqlDbType.UniqueIdentifier);
            para[0].Value = iMMBD_MaterialID;
            para[1] = new SqlParameter("@WO_ID", SqlDbType.UniqueIdentifier);
            para[1].Value = wO_ID;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_WOMBatchNum", para);

        }

        public DataSet S_WOMBatchNum_IMInventoryDetail( string condition)//查看某物料批号信息
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@condition", SqlDbType.VarChar,2000);
            para[0].Value = condition; 
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_WOMBatchNum_IMInventoryDetail", para);

        }
        public void I_WOMBatchNum(Guid iMMBD_MaterialID, Guid wO_ID, string wOMBN_BN)//新增随工单批号
        {
            SqlParameter[] para = new SqlParameter[3];
            para[0] = new SqlParameter("@IMMBD_MaterialID", SqlDbType.UniqueIdentifier);
            para[0].Value = iMMBD_MaterialID;
            para[1] = new SqlParameter("@WO_ID", SqlDbType.UniqueIdentifier);
            para[1].Value = wO_ID;
            para[2] = new SqlParameter("@WOMBN_BN", SqlDbType.VarChar, 30);
            para[2].Value = wOMBN_BN;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_WOMBatchNum", para);
        }
        public void D_WOMBatchNum(Guid wOMBN_ID)//删除随工单批号
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@WOMBN_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = wOMBN_ID;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_WOMBatchNum", para);
        }

        public void I_IMRequisitionMain_WorkOrder(Guid wO_ID, string pT_Name, string iMRM_Man, string iMRM_Depart)//分工序生成领料单
        {
            SqlParameter[] para = new SqlParameter[4];
            para[0] = new SqlParameter("@WO_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = wO_ID;
            para[1] = new SqlParameter("@PT_Name", SqlDbType.VarChar, 60);
            para[1].Value = pT_Name;
            para[2] = new SqlParameter("@IMRM_Man", SqlDbType.VarChar, 20);
            para[2].Value = iMRM_Man;
            para[3] = new SqlParameter("@IMRM_Depart", SqlDbType.VarChar, 100);
            para[3].Value = iMRM_Depart;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_IMRequisitionMain_WorkOrder", para);
        }
        public DataSet S_IMRequisitionMain_WorkOrder(Guid wO_ID)//查询分工序的领料单
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@WO_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = wO_ID;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_IMRequisitionMain_WorkOrder", para);

        }

        public DataSet s_protype_bom_wo(string ptName, decimal pNum)//显示随工单参考领料信息
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@PT_Name", SqlDbType.VarChar,60);
            para[0].Value = ptName;
            para[1] = new SqlParameter("@PNum", SqlDbType.Decimal);
            para[1].Value = pNum;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_s_protype_bom_wo", para);

        }

        public void I_IMRequisitionDetail_WorkOrder(Guid iMRM_RequisitionID, Guid iMMBD_MaterialID, decimal iMRD_StandardNum, decimal iMRD_ActualNum,string iMRD_WorkOrderNum)//新增领料单详细
        {
            SqlParameter[] para = new SqlParameter[5];
            para[0] = new SqlParameter("@IMRM_RequisitionID", SqlDbType.UniqueIdentifier);
            para[0].Value = iMRM_RequisitionID;
            para[1] = new SqlParameter("@IMMBD_MaterialID", SqlDbType.UniqueIdentifier);
            para[1].Value = iMMBD_MaterialID;
            para[2] = new SqlParameter("@IMRD_StandardNum", SqlDbType.Decimal);
            para[2].Value = iMRD_StandardNum;
            para[3] = new SqlParameter("@IMRD_ActualNum", SqlDbType.Decimal);
            para[3].Value = iMRD_ActualNum;
			para[4] = new SqlParameter("@IMRD_WorkOrderNum", SqlDbType.VarChar,100);
            para[4].Value = iMRD_WorkOrderNum;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_IMRequisitionDetail_WorkOrder", para);
        }
        public DataSet s_protype_bom_wo_craft(string ptName, decimal pNum, Guid iMRM_RequisitionID, string pbcname)//显示随工单的各工序的领料信息
        {
            SqlParameter[] para = new SqlParameter[4];
            para[0] = new SqlParameter("@PT_Name", SqlDbType.VarChar, 60);
            para[0].Value = ptName;
            para[1] = new SqlParameter("@PNum", SqlDbType.Decimal);
            para[1].Value = pNum;
            para[2] = new SqlParameter("@IMRM_RequisitionID", SqlDbType.UniqueIdentifier);
            para[2].Value = iMRM_RequisitionID;
            para[3] = new SqlParameter("@PBC_Name", SqlDbType.VarChar,60);
            para[3].Value = pbcname;

            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_s_protype_bom_wo_craft", para);

        }

        public DataSet s_imrequisitiondetail_ID_workorder(Guid iMRD_ID)//检索领料单详细记录以判重
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@IMRD_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = iMRD_ID;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_s_imrequisitiondetail_ID_workorder", para);

        }
        public void U_imrequisitiondetail_workorder(Guid iMRD_ID, decimal iMRD_ActualNum)//编辑领料单详细
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@IMRD_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = iMRD_ID;
            para[1] = new SqlParameter("@IMRD_ActualNum", SqlDbType.Decimal);
            para[1].Value = iMRD_ActualNum;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_imrequisitiondetail_workorder", para);
        }

        public void D_WorkOrder(Guid wO_ID)//删除随工单主表
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@WO_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = wO_ID;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_WorkOrder", para);
        }
    }
}
