using System;
using System.Collections.Generic;
using EquipmentMangementAjax.DBUtility;
using System.Data.SqlClient;
using System.Data;

/// <summary>
///ExpAppSubmitD 的摘要说明
/// </summary>
namespace EquipmentMangementAjax.SQLServer
{
    public class ExpAppSubmitD : IExpAppSubmit
    {
	    public ExpAppSubmitD()
	    {
		    //
		    //TODO: 在此处添加构造函数逻辑
		    //
	    }

        //新建实验申请
        public int Insert_ExpTestApp(ExpTestAppInfo et)
        {
            return (int)SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_ExpTestApp",
                     new SqlParameter("@ETA_ExpID", et.ETA_ExpID), new SqlParameter("@EST_SampleType", et.EST_SampleType),
                     new SqlParameter("@ETA_ProIdentify", et.ETA_ProIdentify),
                     new SqlParameter("@ETA_SamNum", et.ETA_SamNum), new SqlParameter("@ETA_Units", et.ETA_Units),
                     new SqlParameter("@ETA_AppPer", et.ETA_AppPer), new SqlParameter("@ETA_ExpAppNO", et.ETA_ExpAppNO), 
                     new SqlParameter("@ETA_AppDep", et.ETA_AppDep), new SqlParameter("@ETA_AppStatus", et.ETA_AppStatus),
                     new SqlParameter("@ETA_EmergDegree", et.ETA_EmergDegree), new SqlParameter("@ETA_Remaks", et.ETA_Remaks)); 
        }

        //修改实验申请单
        public void Update_ExpTestApp(ExpTestAppInfo et)
        {
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_ExpTestApp",
                new SqlParameter("@ETA_ExpID", et.ETA_ExpID), new SqlParameter("@EST_SampleType", et.EST_SampleType),
                new SqlParameter("@ETA_ExpAppNO", et.ETA_ExpAppNO), new SqlParameter("@ETA_ProIdentify", et.ETA_ProIdentify),
                new SqlParameter("@ETA_SamNum", et.ETA_SamNum), new SqlParameter("@ETA_Units", et.ETA_Units),
                new SqlParameter("@ETA_AppPer", et.ETA_AppPer), new SqlParameter("@ETA_AppTime", et.ETA_AppTime),
                new SqlParameter("@ETA_AppDep", et.ETA_AppDep), new SqlParameter("@ETA_AppStatus", et.ETA_AppStatus),
                new SqlParameter("@ETA_EmergDegree", et.ETA_EmergDegree), new SqlParameter("@ETA_Remaks", et.ETA_Remaks),
                new SqlParameter("@ETA_Auditor", et.ETA_Auditor), new SqlParameter("@ETA_AuTime", et.ETA_AuTime),
                new SqlParameter("@ETA_AuSugg", et.ETA_AuSugg), new SqlParameter("@ETA_AuRes", et.ETA_AuRes),
                new SqlParameter("@ETA_AckPer", et.ETA_AckPer), new SqlParameter("@ETA_AckTime", et.ETA_AckTime),
                new SqlParameter("@ETA_EstimateT", et.ETA_EstimateT), new SqlParameter("@ETA_ExpPer", et.ETA_ExpPer),
                new SqlParameter("@ETA_ActFinishT", et.ETA_ActFinishT), new SqlParameter("@ETA_ExpRes", et.ETA_ExpRes),
                new SqlParameter("@ETA_ResInstruction", et.ETA_ResInstruction), new SqlParameter("@ETA_Approver", et.ETA_Approver),
                new SqlParameter("@ETA_ApprovalT", et.ETA_ApprovalT), new SqlParameter("@ETA_ApprovalSugg", et.ETA_ApprovalSugg),
                new SqlParameter("@ETA_ApprovalRes", et.ETA_ApprovalRes));
        }

        //申请时修改申请内容
        public void Update_ExpTestAppApp(ExpTestAppInfo et)
        {
            SqlParameter[] para = new SqlParameter[11];

            para[0] = new SqlParameter("@ETA_ExpID", SqlDbType.UniqueIdentifier);
            para[0].Value = et.ETA_ExpID;
            para[1] = new SqlParameter("@EST_SampleType", SqlDbType.VarChar, 50);
            para[1].Value = et.EST_SampleType;
            para[2] = new SqlParameter("@ETA_ExpAppNO", SqlDbType.VarChar, 30);
            para[2].Value = et.ETA_ExpAppNO;
            para[3] = new SqlParameter("@ETA_ProIdentify", SqlDbType.VarChar, 40);
            para[3].Value = et.ETA_ProIdentify;
            para[4] = new SqlParameter("@ETA_SamNum", SqlDbType.Int);
            para[4].Value = et.ETA_SamNum;
            para[5] = new SqlParameter("@ETA_Units", SqlDbType.VarChar,10);
            para[5].Value = et.ETA_Units;
            para[6] = new SqlParameter("@ETA_AppPer", SqlDbType.VarChar, 20);
            para[6].Value = et.ETA_AppPer;
            para[7] = new SqlParameter("@ETA_AppDep", SqlDbType.VarChar, 50);
            para[7].Value = et.ETA_AppDep;
            para[8] = new SqlParameter("@ETA_AppStatus", SqlDbType.VarChar, 10);
            para[8].Value = et.ETA_AppStatus;
            para[9] = new SqlParameter("@ETA_EmergDegree", SqlDbType.VarChar, 20);
            para[9].Value = et.ETA_EmergDegree;
            para[10] = new SqlParameter("@ETA_Remaks", SqlDbType.VarChar, 400);
            para[10].Value = et.ETA_Remaks;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
              CommandType.StoredProcedure, "Proc_U_ExpTestAppApp", para);
        }

        //修改实验申请列表状态
        public void Update_ExpTestApp_Status(Guid ETA_ExpID)
        {
            SqlParameter[] para = new SqlParameter[1];

            para[0] = new SqlParameter("@ETA_ExpID", SqlDbType.UniqueIdentifier);
            para[0].Value = ETA_ExpID;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
              CommandType.StoredProcedure, "Proc_U_ExpTestApp_Status", para);
        }

        //实验审核时修改申请表
        public void Update_ExpTestAppAu(ExpTestAppInfo et)
        {
            SqlParameter[] para = new SqlParameter[5];

            para[0] = new SqlParameter("@ETA_ExpID", SqlDbType.UniqueIdentifier);
            para[0].Value = et.ETA_ExpID;
            para[1] = new SqlParameter("@ETA_AppStatus", SqlDbType.VarChar, 10);
            para[1].Value = et.ETA_AppStatus;
            para[2] = new SqlParameter("@ETA_Auditor", SqlDbType.VarChar, 20);
            para[2].Value = et.ETA_Auditor;
            para[3] = new SqlParameter("@ETA_AuSugg", SqlDbType.VarChar, 400);
            para[3].Value = et.ETA_AuSugg;
            para[4] = new SqlParameter("@ETA_AuRes", SqlDbType.VarChar, 20);
            para[4].Value = et.ETA_AuRes;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
              CommandType.StoredProcedure, "Proc_U_ExpTestAppAu", para);
        }

        //接收申请单时修改申请单
        public void Update_ExpTestAppAck(ExpTestAppInfo et)
        {
            SqlParameter[] para = new SqlParameter[4];

            para[0] = new SqlParameter("@ETA_ExpID", SqlDbType.UniqueIdentifier);
            para[0].Value = et.ETA_ExpID;
            para[1] = new SqlParameter("@ETA_AppStatus", SqlDbType.VarChar, 10);
            para[1].Value = et.ETA_AppStatus;
            para[2] = new SqlParameter("@ETA_AckPer", SqlDbType.VarChar, 20);
            para[2].Value = et.ETA_AckPer;
            para[3] = new SqlParameter("@ETA_EstimateT", SqlDbType.DateTime);
            para[3].Value = et.ETA_EstimateT;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
              CommandType.StoredProcedure, "Proc_U_ExpTestAppAck", para);
        }

        //录入实验申请单时修改申请单
        public void Update_ExpTestAppRes(ExpTestAppInfo et)
        {
            SqlParameter[] para = new SqlParameter[5];

            para[0] = new SqlParameter("@ETA_ExpID", SqlDbType.UniqueIdentifier);
            para[0].Value = et.ETA_ExpID;
            para[1] = new SqlParameter("@ETA_AppStatus", SqlDbType.VarChar, 10);
            para[1].Value = et.ETA_AppStatus;
            para[2] = new SqlParameter("@ETA_ExpPer", SqlDbType.VarChar, 20);
            para[2].Value = et.ETA_ExpPer;
            para[3] = new SqlParameter("@ETA_ExpRes", SqlDbType.VarChar, 20);
            para[3].Value = et.ETA_ExpRes;
            para[4] = new SqlParameter("@ETA_ResInstruction", SqlDbType.VarChar, 400);
            para[4].Value = et.ETA_ResInstruction;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
              CommandType.StoredProcedure, "Proc_U_ExpTestAppRes", para);
        }

        //实验结果审批时修改申请单
        public void Update_ExpTestAppArl(ExpTestAppInfo et)
        {
            SqlParameter[] para = new SqlParameter[5];

            para[0] = new SqlParameter("@ETA_ExpID", SqlDbType.UniqueIdentifier);
            para[0].Value = et.ETA_ExpID;
            para[1] = new SqlParameter("@ETA_AppStatus", SqlDbType.VarChar, 10);
            para[1].Value = et.ETA_AppStatus;
            para[2] = new SqlParameter("@ETA_Approver", SqlDbType.VarChar, 20);
            para[2].Value = et.ETA_Approver;
            para[3] = new SqlParameter("@ETA_ApprovalSugg", SqlDbType.VarChar,400);
            para[3].Value = et.ETA_ApprovalSugg;
            para[4] = new SqlParameter("@ETA_ApprovalRes", SqlDbType.VarChar, 20);
            para[4].Value = et.ETA_ApprovalRes;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
              CommandType.StoredProcedure, "Proc_U_ExpTestAppArl", para);
        }

        //修改实验申请单，conditiong方式
        public void Update_ExpTestApp1(string ETA_ExpID, string condition)
        {
            SqlParameter[] para = new SqlParameter[2];

            para[0] = new SqlParameter("@ETA_ExpID", SqlDbType.VarChar, 40);
            para[0].Value = ETA_ExpID;
            para[1] = new SqlParameter("@condition", SqlDbType.VarChar, 2000);
            para[1].Value = condition;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
              CommandType.StoredProcedure, "Proc_U_ExpTestApp1", para);
        }

        //在申请页面GridView编辑，根据ID查询实验申请单，转为字符串？有误则查字符与数字转换
        public IList<ExpTestAppInfo> Search_ExpTestApp_ID(Guid ETA_ExpID)
        {
            SqlParameter parm = new SqlParameter("@ETA_ExpID", ETA_ExpID);
            IList<ExpTestAppInfo> expTestAppInfo = new List<ExpTestAppInfo>();
            SqlDataReader sdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_S_ExpTestApp", parm);
            while (sdr.Read())
            {
                expTestAppInfo.Add(new ExpTestAppInfo(
                   sdr["EST_SampleType"] == DBNull.Value ? "" : sdr["EST_SampleType"].ToString(),
                   sdr["EST_SampleType"] == DBNull.Value ? (new Guid()) : (Guid)sdr["EST_SampleTypeID"],
                   sdr["ETA_ExpAppNO"] == DBNull.Value ? "" : sdr["ETA_ExpAppNO"].ToString(),
                   sdr["ETA_ProIdentify"] == DBNull.Value ? "" : sdr["ETA_ProIdentify"].ToString(),
                   sdr["ETA_SamNum"] == DBNull.Value ? 0 : Convert.ToInt32(sdr["ETA_SamNum"].ToString()),
                   sdr["ETA_Units"] == DBNull.Value ? "" : sdr["ETA_Units"].ToString(),
                   sdr["ETA_AppPer"] == DBNull.Value ? "" : sdr["ETA_AppPer"].ToString(),
                   sdr["ETA_AppTime"] == DBNull.Value ? Convert.ToDateTime("1900-01-01 00:00") : Convert.ToDateTime(sdr["ETA_AppTime"].ToString()),
                   sdr["BDOS_Code"] == DBNull.Value ? "" : sdr["BDOS_Code"].ToString(),
                   sdr["ETA_AppStatus"] == DBNull.Value ? "" : sdr["ETA_AppStatus"].ToString(),
                   sdr["ETA_EmergDegree"] == DBNull.Value ? "" : sdr["ETA_EmergDegree"].ToString(),
                   sdr["ETA_Remaks"] == DBNull.Value ? "" : sdr["ETA_Remaks"].ToString(),
                   sdr["ETA_Auditor"] == DBNull.Value ? "" : sdr["ETA_Auditor"].ToString(),
                   sdr["ETA_AuTime"] == DBNull.Value ? Convert.ToDateTime("1900-01-01 00:00") : Convert.ToDateTime(sdr["ETA_AuTime"].ToString()),
                   sdr["ETA_AuSugg"] == DBNull.Value ? "" : sdr["ETA_AuSugg"].ToString(),
                   sdr["ETA_AuRes"] == DBNull.Value ? "" : sdr["ETA_AuRes"].ToString(),
                   sdr["ETA_AckPer"] == DBNull.Value ? "" : sdr["ETA_AckPer"].ToString(),
                   sdr["ETA_AckTime"] == DBNull.Value ? Convert.ToDateTime("1900-01-01 00:00") : Convert.ToDateTime(sdr["ETA_AckTime"].ToString()),
                   sdr["ETA_EstimateT"] == DBNull.Value ? Convert.ToDateTime("1900-01-01 00:00") : Convert.ToDateTime(sdr["ETA_EstimateT"].ToString()),
                   sdr["ETA_ExpPer"] == DBNull.Value ? "" : sdr["ETA_ExpPer"].ToString(),
                   sdr["ETA_ActFinishT"] == DBNull.Value ? Convert.ToDateTime("1900-01-01 00:00") : Convert.ToDateTime(sdr["ETA_ActFinishT"].ToString()),
                   sdr["ETA_ExpRes"] == DBNull.Value ? "" : sdr["ETA_ExpRes"].ToString(),
                   sdr["ETA_ResInstruction"] == DBNull.Value ? "" : sdr["ETA_ResInstruction"].ToString(),
                   sdr["ETA_Approver"] == DBNull.Value ? "" : sdr["ETA_Approver"].ToString(),
                   sdr["ETA_ApprovalT"] == DBNull.Value ? Convert.ToDateTime("1900-01-01 00:00") : Convert.ToDateTime(sdr["ETA_ApprovalT"].ToString()),
                   sdr["ETA_ApprovalSugg"] == DBNull.Value ? "" : sdr["ETA_ApprovalSugg"].ToString(),
                   sdr["ETA_ApprovalRes"] == DBNull.Value ? "" : sdr["ETA_ApprovalRes"].ToString()));
            }
            return expTestAppInfo;
        }

        //模糊查询试验申请condition方式
        public DataSet Search_ExpTestApp_GridView1(string Condition)
        {
            SqlParameter[] para = new SqlParameter[1];

            para[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 1000);
            para[0].Value = Condition;

            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
              CommandType.StoredProcedure, "Proc_S_ExpTestApp_Gridview1", para);
        }

        //对组织机构中部门的检索，此处QZL处已写存储过程及数据层函数
        public DataSet Search_ExpTestApp_BDOrganizationSheet()
        {
            return (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_S_BDOrganizationSheet");
        }

        //删除实验申请
        public void Delete_ExpTestApp(Guid ID)
        {
            SqlParameter para=new SqlParameter("@ETA_ExpID",ID);
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_ExpTestApp", para);
        }

        //新建实验各项目结果表
        public int Insert_ExpItemsRes(Guid EIR_ResDetailID,Guid ETA_ExpID,Guid EI_ExpItemID,int EIR_ItemAmount)
        {
            return (int)SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_ExpItemsRes",
                     new SqlParameter("@EIR_ResDetailID", EIR_ResDetailID), new SqlParameter("@ETA_ExpID", ETA_ExpID),
                     new SqlParameter("@EI_ExpItemID", EI_ExpItemID), new SqlParameter("@EIR_ItemAmount", EIR_ItemAmount));
        }

        //修改实验各项目结果表
        public void Update_ExpItemsRes(Guid EIR_ResDetailID, int EIR_ItemAmount, int EIR_ItemAcceptance, string EIR_ItemRes, string EIR_Remaks)
        {
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_ExpItemsRes",
                new SqlParameter("@EIR_ResDetailID", EIR_ResDetailID),
                new SqlParameter("@EIR_ItemAmount", EIR_ItemAmount), new SqlParameter("@EIR_ItemAcceptance", EIR_ItemAcceptance),
                new SqlParameter("@EIR_ItemRes", EIR_ItemRes), new SqlParameter("@EIR_Remaks", EIR_Remaks));
        }

        //根据申请单ID检索申请单的实验项目结果
        public DataSet Search_ExpItemsRes_ID(Guid ETA_ExpID)
        {
            SqlParameter para = new SqlParameter("@ETA_ExpID", ETA_ExpID);
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
              CommandType.StoredProcedure, "Proc_S_ExpItemsRes_ID", para);
        }

        //根据实验项目明细表ID查询实验项目明细表        
        public IList<ExpTestAppInfo> Search_ExpItemsRes_ResID(Guid EIR_ResDetailID)
        {
            SqlParameter parm = new SqlParameter("@EIR_ResDetailID", EIR_ResDetailID);
            IList<ExpTestAppInfo> ItemRes = new List<ExpTestAppInfo>();
            SqlDataReader sdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_S_ExpItemsRes_ResID", parm);
            while (sdr.Read())
            {
                ItemRes.Add(new ExpTestAppInfo((Guid)sdr["EIR_ResDetailID"], (Guid)sdr["EI_ExpItemID"],
                    sdr["EIR_ItemAmount"] == DBNull.Value ? 0 : Convert.ToInt32(sdr["EIR_ItemAmount"].ToString()),
                   sdr["EIR_ItemAcceptance"] == DBNull.Value ? 0 :Convert.ToInt32( sdr["EIR_ItemAcceptance"].ToString()),
                   sdr["EIR_ItemRes"] == DBNull.Value ? "" : sdr["EIR_ItemRes"].ToString(),
                   sdr["EIR_Remaks"] == DBNull.Value ? "" : sdr["EIR_Remaks"].ToString()));
            }
            return ItemRes;
        }

        //检查是否存在指定申请单的指定实验项目，考虑到可能会在一次实验中做相同实验项目以对比，取消此判断
        public int Search_CheckExpItem(Guid ETA_ExpID, Guid EI_ExpItemID)
        {
            SqlParameter[] para = new SqlParameter[2];

            para[0] = new SqlParameter("@ETA_ExpID", ETA_ExpID);
            para[0] = new SqlParameter("@EI_ExpItemID", EI_ExpItemID);
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
              CommandType.StoredProcedure, "Proc_S_CheckExpItem", para);
        }

        //删除实验各项目结果表
        public void Delete_ExpItemsRes(Guid ID)
        {
            SqlParameter para = new SqlParameter("@EIR_ResDetailID", ID);
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_ExpItemsRes", para);
        }

        //点击新增时生成空主表
        public void Insert_ExpTestApp_View()
        {
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_ExpTestApp_View");
        }

        //删除不要的主表
        public void Delete_ExpTestApp_View()
        {
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_ExpTestApp_View");
        }

        //查询主表ID    
        public IList<ExpTestAppInfo> Search_ExpItemsRes_ResID()
        {
            IList<ExpTestAppInfo> ItemRes = new List<ExpTestAppInfo>();
            SqlDataReader sdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_S_ExpTestApp_View");
            while (sdr.Read())
            {
                ItemRes.Add(new ExpTestAppInfo((Guid)sdr["ETA_ExpID"]));
            }
            return ItemRes;
        }

    }
}
