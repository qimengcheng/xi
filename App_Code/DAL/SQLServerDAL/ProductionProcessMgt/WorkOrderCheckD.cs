using System;
using System.Data;
using System.Data.SqlClient;
using EquipmentMangementAjax.DBUtility;

/// <summary>
///WorkOrderCheckD 的摘要说明
/// </summary>

namespace EquipmentMangementAjax.SQLServer
{
    public class WorkOrderCheckD : IWorkOrderCheck
    {
        public WorkOrderCheckD()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        public DataSet S_WODetail_Num(Guid wOD_ID)//在制品查看显示随工单在某工序的数量信息
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@WOD_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = wOD_ID;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_WODetail_Num", para);

        }

        public DataSet S_WorkOrderDetail_Equipment(Guid wOD_ID)//在制品查看显示随工单某工序的设备信息
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@WOD_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = wOD_ID;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_WorkOrderDetail_Equipment", para);

        }

        public DataSet S_WorkOrder_WOMBatchNum(Guid wO_ID)//在制品查看显示随工单批号信息
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@WO_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = wO_ID;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_WorkOrder_WOMBatchNum", para);

        }

        public DataSet S_WorkOrderDetail_BadProduct(Guid wOD_ID)//在制品查看显示随工单某工序的不良品信息
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@WOD_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = wOD_ID;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_WorkOrderDetail_BadProduct", para);

        }

        public DataSet S_WorkOrderDetail_Level(Guid wOD_ID)//在制品查看显示随工单某工序的分档信息
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@WOD_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = wOD_ID;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_WorkOrderDetail_Level", para);

        }

        public DataSet S_WorkOrderDetail_OperatorInfo(Guid wOD_ID)//在制品查看显示随工单作业员信息
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@WOD_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = wOD_ID;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_WorkOrderDetail_OperatorInfo", para);

        }

        public DataSet S_WorkOrderDetail_OTime(Guid oI_ID)//在制品查看显示作业员计时信息
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@OI_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = oI_ID;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_WorkOrderDetail_OTime", para);

        }

        public DataSet S_WorkOrderDetail_Overtime(Guid wOD_ID)//在制品显示随工单超时原因表
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@WOD_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = wOD_ID;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_WorkOrderDetail_Overtime", para);

        }

        public void I_WorkOrder_Devide(Guid wO_ID, string wO_Num, string wO_ProType, int wO_PNum, string wO_Note, string wO_People)//随工单分单
        {
            SqlParameter[] para = new SqlParameter[6];
            para[0] = new SqlParameter("@WO_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = wO_ID;
            para[1] = new SqlParameter("@WO_Num", SqlDbType.VarChar, 30);
            para[1].Value = wO_Num;
            para[2] = new SqlParameter("@WO_ProType", SqlDbType.VarChar, 60);
            para[2].Value = wO_ProType;
            para[3] = new SqlParameter("@WO_PNum", SqlDbType.Int);
            para[3].Value = wO_PNum;
            para[4] = new SqlParameter("@WO_Note", SqlDbType.VarChar, 200);
            para[4].Value = wO_Note;
            para[5] = new SqlParameter("@WO_People", SqlDbType.VarChar, 20);
            para[5].Value = wO_People;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_WorkOrder_Devide", para);
        }

        public DataSet S_WorkOrder_Devide(string wO_Num)//随工单分单查询
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@WO_Num", SqlDbType.VarChar, 30);
            para[0].Value = wO_Num;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_WorkOrder_Devide", para);

        }

        public void D_WorkOrder_Devide(string wO_Num)//随工单删除分单
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@WO_Num", SqlDbType.VarChar, 30);
            para[0].Value = wO_Num;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_WorkOrder_Devide", para);
        }

        public void U_WorkOrder_Devide(Guid wO_ID, int wO_PNum, string wO_Note)//编辑随工单分单计划数量
        {
            SqlParameter[] para = new SqlParameter[3];
            para[0] = new SqlParameter("@WO_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = wO_ID;
            para[1] = new SqlParameter("@WO_PNum", SqlDbType.Int);
            para[1].Value = wO_PNum;
            para[2] = new SqlParameter("@WO_Note", SqlDbType.VarChar, 200);
            para[2].Value = wO_Note;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_WorkOrder_Devide", para);
        }

        public void I_WorkOrder_Combine(string wO_Num, string wO_FatherNum, string wO_ProType, string wO_OrderNum, string wO_SN, string wO_Level, string wO_ChipNum, int wO_PNum, string wO_Note, string wO_People, string idstring)//随工单合单
        {
            SqlParameter[] para = new SqlParameter[11];
            para[0] = new SqlParameter("@WO_Num", SqlDbType.VarChar,30);
            para[0].Value = wO_Num;
            para[1] = new SqlParameter("@WO_FatherNum", SqlDbType.VarChar, 1000);
            para[1].Value = wO_FatherNum;
            para[2] = new SqlParameter("@WO_ProType", SqlDbType.VarChar, 60);
            para[2].Value = wO_ProType;
            para[3] = new SqlParameter("@WO_OrderNum", SqlDbType.VarChar,30);
            para[3].Value = wO_OrderNum;
            para[4] = new SqlParameter("@WO_SN", SqlDbType.VarChar, 30);
            para[4].Value = wO_SN;
            para[5] = new SqlParameter("@WO_Level", SqlDbType.VarChar, 20);
            para[5].Value = wO_Level;
            para[6] = new SqlParameter("@WO_ChipNum", SqlDbType.VarChar, 30);
            para[6].Value = wO_ChipNum;
            para[7] = new SqlParameter("@WO_PNum", SqlDbType.Int);
            para[7].Value = wO_PNum;
            para[8] = new SqlParameter("@WO_Note", SqlDbType.VarChar, 200);
            para[8].Value = wO_Note;
            para[9] = new SqlParameter("@WO_People", SqlDbType.VarChar, 20);
            para[9].Value = wO_People;
            para[10] = new SqlParameter("@idstring", SqlDbType.VarChar, 8000);
            para[10].Value = idstring;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_WorkOrder_Combine", para);
        }
    }
}