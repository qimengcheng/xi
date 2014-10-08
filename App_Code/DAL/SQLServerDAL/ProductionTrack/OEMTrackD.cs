using System;
using System.Data;
using System.Data.SqlClient;
using EquipmentMangementAjax.DBUtility;
/// <summary>
///OEMTrackD 的摘要说明
/// </summary>
namespace EquipmentMangementAjax.SQLServer
{
    public class OEMTrackD : IOEMTrack
    {
        public OEMTrackD()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        public DataSet S_OEMOrderTrack(string condition)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Condition", SqlDbType.VarChar, 2000);
            para[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_OEMOrderTrack", para);

        }
        public void I_OEMOrderTrack(Guid sMSOD_ID, string oEMOT_Note, DateTime oEMOT_PDate, DateTime oEMOT_RPDate, DateTime oEMOT_RDeliverytDate)//加工订单跟踪主表制定
        {
            SqlParameter[] para = new SqlParameter[5];
            para[0] = new SqlParameter("@SMSOD_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = sMSOD_ID;
            para[1] = new SqlParameter("@OEMOT_Note", SqlDbType.VarChar, 200);
            para[1].Value = oEMOT_Note;
            para[2] = new SqlParameter("@OEMOT_PDate", SqlDbType.DateTime);
            para[2].Value = oEMOT_PDate;
            para[3] = new SqlParameter("@OEMOT_RPDate", SqlDbType.DateTime);
            para[3].Value = oEMOT_RPDate;
            para[4] = new SqlParameter("@OEMOT_RDeliverytDate", SqlDbType.DateTime);
            para[4].Value = oEMOT_RDeliverytDate;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_OEMOrderTrack", para);
        }
        public void U_OEMOrderTrack(Guid oEMOT_ID, string oEMOT_Note, DateTime oEMOT_PDate, DateTime oEMOT_RPDate, DateTime oEMOT_RDeliverytDate)//加工订单跟踪主编辑
        {
            SqlParameter[] para = new SqlParameter[5];
            para[0] = new SqlParameter("@OEMOT_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = oEMOT_ID;
            para[1] = new SqlParameter("@OEMOT_Note", SqlDbType.VarChar, 200);
            para[1].Value = oEMOT_Note;
            para[2] = new SqlParameter("@OEMOT_PDate", SqlDbType.DateTime);
            para[2].Value = oEMOT_PDate;
            para[3] = new SqlParameter("@OEMOT_RPDate", SqlDbType.DateTime);
            para[3].Value = oEMOT_RPDate;
            para[4] = new SqlParameter("@OEMOT_RDeliverytDate", SqlDbType.DateTime);
            para[4].Value = oEMOT_RDeliverytDate;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_OEMOrderTrack", para);
        }

        public DataSet S_PMMInventory(string condition)//生产线盘存主表检索
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Condition", SqlDbType.VarChar, 2000);
            para[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_PMMInventory", para);

        }


        public void D_PMMInventory(Guid pMMI_ID)//生产线盘存主表删除
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@PMMI_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = pMMI_ID;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_PMMInventory", para);
        }


        public void I_PMMInventory(Guid pBC_ID, DateTime pMMI_Date, string pMMI_Man)//生产线盘存主表删除
        {
            SqlParameter[] para = new SqlParameter[3];
            para[0] = new SqlParameter("@PBC_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = pBC_ID;
            para[1] = new SqlParameter("@PMMI_Date", SqlDbType.Date);
            para[1].Value = pMMI_Date;
            para[2] = new SqlParameter("@PMMI_Man", SqlDbType.VarChar,20);
            para[2].Value = pMMI_Man;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_PMMInventory", para);
        }
    }
}