using System;
using System.Data;
using System.Data.SqlClient;
using EquipmentMangementAjax.DBUtility;

/// <summary>
/// OEMTrackDD 的摘要说明
/// </summary>

    public class OEMTrackDD 
    {
        public OEMTrackDD()
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
        public DataSet S_OEMOrderTrack_One(string condition)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Condition", SqlDbType.VarChar, 2000);
            para[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_OEMOrderTrack_One", para);

        }
        public void I_OEMOrderTrack(Guid sMSOD_ID, string oEMOT_Note, DateTime oEMOT_PDate, DateTime oEMOT_RPDate, DateTime oEMOT_RDeliverytDate, string OEMOT_SNum, DateTime OEMOT_PInTime)//加工订单跟踪主表制定
        {
            SqlParameter[] para = new SqlParameter[7];
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
            para[5] = new SqlParameter("@OEMOT_SNum", SqlDbType.VarChar, 30);
            para[5].Value = OEMOT_SNum;
            para[6] = new SqlParameter("@OEMOT_PInTime", SqlDbType.Date);
            para[6].Value = OEMOT_PInTime;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_OEMOrderTrack", para);
        }
        public void U_OEMOrderTrack(Guid oEMOT_ID, string oEMOT_Note, DateTime oEMOT_PDate, DateTime oEMOT_RPDate, DateTime oEMOT_RDeliverytDate, string OEMOT_SNum, DateTime OEMOT_PInTime)//加工订单跟踪主编辑
        {
            SqlParameter[] para = new SqlParameter[7];
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
            para[5] = new SqlParameter("@OEMOT_SNum", SqlDbType.VarChar, 30);
            para[5].Value = OEMOT_SNum;
            para[6] = new SqlParameter("@OEMOT_PInTime", SqlDbType.Date);
            para[6].Value = OEMOT_PInTime;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_OEMOrderTrack", para);
        }

      
        //工程部会签
        public void U_OEMOrderTrack_EnDesign(Guid OEMOT_ID, string OEMOT_EnDepDirec, string OEMOT_EnDepReason, string OEMOT_EnDepMan)
        {
            SqlParameter[] para = new SqlParameter[4];
            para[0] = new SqlParameter("@OEMOT_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = OEMOT_ID;
            para[1] = new SqlParameter("@OEMOT_EnDepDirec", SqlDbType.Char, 2);
            para[1].Value = OEMOT_EnDepDirec;
            para[2] = new SqlParameter("@OEMOT_EnDepReason", SqlDbType.VarChar, 400);
            para[2].Value = OEMOT_EnDepReason;
            para[3] = new SqlParameter("@OEMOT_EnDepMan", SqlDbType.VarChar, 20);
            para[3].Value = OEMOT_EnDepMan;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_OEMOrderTrack_EnDesign", para);
        }
        //生产部会签
        public void U_OEMOrderTrack_PDesign(Guid OEMOT_ID, string OEMOT_PDepInDate, string OEMOT_PDepReason, string OEMOT_PDepMan)
        {
            SqlParameter[] para = new SqlParameter[4];
            para[0] = new SqlParameter("@OEMOT_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = OEMOT_ID;
            para[1] = new SqlParameter("@OEMOT_PDepInDate", SqlDbType.Char, 2);
            para[1].Value = OEMOT_PDepInDate;
            para[2] = new SqlParameter("@OEMOT_PDepReason", SqlDbType.VarChar, 400);
            para[2].Value = OEMOT_PDepReason;
            para[3] = new SqlParameter("@OEMOT_PDepMan", SqlDbType.VarChar, 20);
            para[3].Value = OEMOT_PDepMan;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_OEMOrderTrack_PDesign", para);
        }
        //品保部会签
        public void U_OEMOrderTrack_QDesign(Guid OEMOT_ID, string OEMOT_QDepQC, string OEMOT_QDepReason, string OEMOT_QDepMan)
        {
            SqlParameter[] para = new SqlParameter[4];
            para[0] = new SqlParameter("@OEMOT_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = OEMOT_ID;
            para[1] = new SqlParameter("@OEMOT_QDepQC", SqlDbType.Char, 2);
            para[1].Value = OEMOT_QDepQC;
            para[2] = new SqlParameter("@OEMOT_QDepReason", SqlDbType.VarChar, 400);
            para[2].Value = OEMOT_QDepReason;
            para[3] = new SqlParameter("@OEMOT_QDepMan", SqlDbType.VarChar, 20);
            para[3].Value = OEMOT_QDepMan;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_OEMOrderTrack_QDesign", para);
        }
        //销售部会签
        public void U_OEMOrderTrack_SalDesign(Guid OEMOT_ID, string OEMOT_SalDepSale, string OEMOT_SalDepReason, string OEMOT_SalDepMan)
        {
            SqlParameter[] para = new SqlParameter[4];
            para[0] = new SqlParameter("@OEMOT_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = OEMOT_ID;
            para[1] = new SqlParameter("@OEMOT_SalDepSale", SqlDbType.Char, 2);
            para[1].Value = OEMOT_SalDepSale;
            para[2] = new SqlParameter("@OEMOT_SalDepReason", SqlDbType.VarChar, 400);
            para[2].Value = OEMOT_SalDepReason;
            para[3] = new SqlParameter("@OEMOT_SalDepMan", SqlDbType.VarChar, 20);
            para[3].Value = OEMOT_SalDepMan;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_OEMOrderTrack_SalDesign", para);
        }
        //供应部会签
        public void U_OEMOrderTrack_SupDesign(Guid OEMOT_ID, string OEMOT_SupDepM, string OEMOT_SuDepReason, string OEMOT_SuDepMan)
        {
            SqlParameter[] para = new SqlParameter[4];
            para[0] = new SqlParameter("@OEMOT_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = OEMOT_ID;
            para[1] = new SqlParameter("@OEMOT_SupDepM", SqlDbType.Char, 2);
            para[1].Value = OEMOT_SupDepM;
            para[2] = new SqlParameter("@OEMOT_SuDepReason", SqlDbType.VarChar, 400);
            para[2].Value = OEMOT_SuDepReason;
            para[3] = new SqlParameter("@OEMOT_SuDepMan", SqlDbType.VarChar, 20);
            para[3].Value = OEMOT_SuDepMan;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_OEMOrderTrack_SupDesign", para);
        }
        //技术部会签
        public void U_OEMOrderTrack_TeDesign(Guid OEMOT_ID, string OEMOT_TeDepDirec, string OEMOT_TeDepReason, string OEMOT_TeDepMan)
        {
            SqlParameter[] para = new SqlParameter[4];
            para[0] = new SqlParameter("@OEMOT_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = OEMOT_ID;
            para[1] = new SqlParameter("@OEMOT_TeDepDirec", SqlDbType.Char, 2);
            para[1].Value = OEMOT_TeDepDirec;
            para[2] = new SqlParameter("@OEMOT_TeDepReason", SqlDbType.VarChar, 400);
            para[2].Value = OEMOT_TeDepReason;
            para[3] = new SqlParameter("@OEMOT_TeDepMan", SqlDbType.VarChar, 20);
            para[3].Value = OEMOT_TeDepMan;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_OEMOrderTrack_TeDesign", para);
        }


        //修改状态
        public void U_OEMOrderTrack_State(Guid OEMOT_ID, string OEMOT_State)
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@OEMOT_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = OEMOT_ID;
            para[1] = new SqlParameter("@OEMOT_State", SqlDbType.VarChar,20);
            para[1].Value = OEMOT_State;
           
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_OEMOrderTrack_State", para);
        }
    }
