using System;
using System.Data;
using System.Data.SqlClient;
//using System.Collections.Generic;
using EquipmentMangementAjax.DBUtility;


/// <summary>
///SalesDeliverD 的摘要说明
/// </summary>

    public class SalesAfterD
    {
        public SalesAfterD()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        //查询投诉类别
        public DataSet Select_TousuSort(string condition)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 1000);
            para[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_CRMComplainSort", para);

        }
        //查询售后类别
        public DataSet Select_ShouhouSort(string condition)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 1000);
            para[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_CRMAfterSaleSort", para);

        }
        //新建投诉类别
        public void Insert_TousuSort(string name,string detail,string man)
        {
            SqlParameter[] para = new SqlParameter[3];
            para[0] = new SqlParameter("@CRMCS_Name", SqlDbType.VarChar,50);
            para[0].Value = name;
            para[1] = new SqlParameter("@CRMCS_Detail", SqlDbType.VarChar,400);
            para[1].Value = detail;
            para[2] = new SqlParameter("@CRMCS_Man", SqlDbType.VarChar, 20);
            para[2].Value = man;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_CRMComplainSort", para);
        }
        //编辑投诉类别
        public void Update_TousuSort(Guid id ,string name, string detail, string man)
        {
            SqlParameter[] para = new SqlParameter[4];
            para[0] = new SqlParameter("@CRMCS_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = id;
            para[1] = new SqlParameter("@CRMCS_Name", SqlDbType.VarChar, 50);
            para[1].Value = name;
            para[2] = new SqlParameter("@CRMCS_Detail", SqlDbType.VarChar, 400);
            para[2].Value = detail;
            para[3] = new SqlParameter("@SMOD_ID", SqlDbType.VarChar, 20);
            para[3].Value = man;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_CRMComplainSort", para);
        }
        //删除投诉类别
        public void Delete_TousuSort(Guid id)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@CRMCS_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = id;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_CRMComplainSort", para);
        }
        //新建售后类别
        public void Insert_ShouhouSort(string name, string detail, string man)
        {
            SqlParameter[] para = new SqlParameter[3];
            para[0] = new SqlParameter("@CRMASS_Name", SqlDbType.VarChar, 50);
            para[0].Value = name;
            para[1] = new SqlParameter("@CRMASS_Detail", SqlDbType.VarChar, 400);
            para[1].Value = detail;
            para[2] = new SqlParameter("@CRMASS_Man", SqlDbType.VarChar, 20);
            para[2].Value = man;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_CRMAfterSaleSort", para);
        }
        //编辑售后类别
        public void Update_ShouhouSort(Guid id, string name, string detail, string man)
        {
            SqlParameter[] para = new SqlParameter[4];
            para[0] = new SqlParameter("@CRMASS_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = id;
            para[1] = new SqlParameter("@CRMASS_Name", SqlDbType.VarChar, 50);
            para[1].Value = name;
            para[2] = new SqlParameter("@CRMASS_Detail", SqlDbType.VarChar, 400);
            para[2].Value = detail;
            para[3] = new SqlParameter("@CRMASS_Man", SqlDbType.VarChar, 20);
            para[3].Value = man;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_CRMAfterSaleSort", para);
        }
        //删除售后类别
        public void Delete_ShouhouSort(Guid id)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@CRMASS_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = id;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_CRMAfterSaleSort", para);
        }
        //删除客诉主表
        public void Delete_KesuMain(Guid id)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@CRMCCM_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = id;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_CRMCustomComplainMain", para);
        }
        //查询客诉主表
        public DataSet Select_ShouhouMain(string condition)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 1000);
            para[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_CRMCustomerComplaintMain", para);

        }
        //查询客诉详细表
        public DataSet Select_ShouhouDetail(Guid  condition)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@CRMCCM_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_CRMCustomerComplaintDetail", para);

        }
        //新建客诉详细表
        public void Insert_KesuMain(Guid Cid,Guid tousuID,int day,string remark,string man)
        {
            SqlParameter[] para = new SqlParameter[5];
            para[0] = new SqlParameter("@CRMCIF_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = Cid;
            //para[1] = new SqlParameter("@CRMASS_ID", SqlDbType.UniqueIdentifier);
            //para[1].Value = Shouhouid;
            para[1] = new SqlParameter("@CRMCS_ID", SqlDbType.UniqueIdentifier);
            para[1].Value = tousuID;
            para[2] = new SqlParameter("@CRMCCM_RequireFinishTime", SqlDbType.Int);
            para[2].Value = day;
            para[3] = new SqlParameter("@CRMCCM_Remark", SqlDbType.VarChar, 400);
            para[3].Value = remark;
            para[4] = new SqlParameter("@CRMCCM_InputMan", SqlDbType.VarChar, 20);
            para[4].Value = man;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_CRMCustomerComplaintMain", para);
        }
        //检索客户
        public DataSet Select_Kehu(string condition)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 1000);
            para[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_CRMCustomInfo_Shouhou", para);

        }
        //删除客诉详细
        public void Delete_Kesu_Detail(Guid id)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@CRMCCD_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = id;

            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_CRMCustomerComplaintDetail", para);
        }
        //录入分析结果
        public void Update_ShouhouDetail( Guid id,string result,Guid rid)
        {
            SqlParameter[] para = new SqlParameter[3];
            para[0] = new SqlParameter("@CRMCCD_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = id;
            para[1] = new SqlParameter("@CRMCCD_AnalysisResult", SqlDbType.VarChar,400);
            para[1].Value = result;
            para[2] = new SqlParameter("@CRMASS_ID", SqlDbType.UniqueIdentifier);
            para[2].Value = rid;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_CRMCustomerComplaintDetail", para);
        }
        //审核
        public void Update_ShouhouMain_Check(Guid id, string result,string man,string opinion)
        {
            SqlParameter[] para = new SqlParameter[4];
            para[0] = new SqlParameter("@CRMCCM_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = id;
            para[1] = new SqlParameter("@CRMCCM_CheckResult", SqlDbType.VarChar, 20);
            para[1].Value = result;
            para[2] = new SqlParameter("@CRMCCM_CheckMan", SqlDbType.VarChar,20);
            para[2].Value = man;
            para[3] = new SqlParameter("@CRMCCM_CheckOpinion", SqlDbType.VarChar, 400);
            para[3].Value = opinion;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_CRMCustomerComplaintMain_Check", para);
        }
        //查询订单表
        public DataSet Select_Dingdan(string condition)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Condition", SqlDbType.NVarChar,1000);
            para[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_SMSalesOrderDetail_Shouhou", para);
        }
        //新建客诉详细表
        public void Insert_KesuDetail(Guid id,Guid id1,string batchnum,int num,int losenum, string re,string condition)
        {
            SqlParameter[] para = new SqlParameter[7];
            para[0] = new SqlParameter("@SMSOD_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = id;
            para[1] = new SqlParameter("@CRMCCM_ID", SqlDbType.UniqueIdentifier);
            para[1].Value = id1;
            para[2] = new SqlParameter("@CRMCCD_BatchNum", SqlDbType.VarChar, 100);
            para[2].Value = batchnum;
            para[3] = new SqlParameter("@CRMCCD_OfferNum", SqlDbType.Int);
            para[3].Value = num;
            para[4] = new SqlParameter("@CRMCCD_LoseEfficacyNum", SqlDbType.Int);
            para[4].Value = losenum;
            para[5] = new SqlParameter("@CRMCCD_Return", SqlDbType.Char, 2);
            para[5].Value = re;
            para[6] = new SqlParameter("@CRMCCD_LoseEfficacyCondition", SqlDbType.VarChar, 400);
            para[6].Value = condition;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_CRMCustomerComplaintDetail", para);
        }
        //上传
        public void Update_KesuDetail(Guid id,string path)
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@CRMCCD_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = id;
            para[1] = new SqlParameter("@CRMCCD_AsscessPath", SqlDbType.VarChar,400);
            para[1].Value = path;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_CRMCustomerComplaintDetail_Upload", para);
        }



        //查询NOde 追踪环节基础表
        public DataSet Select_Node(string condition)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 1000);
            para[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_CRMCustomerComplainTrackNode", para);
        }
        //查询NOde 追踪环节表
        public DataSet Select_Track(string condition)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 1000);
            para[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_CRMCustomerComplainTrack", para);
        }
        //录入追踪环节
        public void Insert_Node(string name,string node)
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@CRMCTN_Name", SqlDbType.VarChar, 400);
            para[0].Value = name;
            para[1] = new SqlParameter("@CRMCTN_Note", SqlDbType.VarChar, 400);
            para[1].Value = node;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_CRMCustomTrackNode", para);
        }
        //修改追踪环节
        public void Update_Node(Guid id, string name, string node)
        {
            SqlParameter[] para = new SqlParameter[3];
            para[0] = new SqlParameter("@CRMCTN_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = id;
            para[1] = new SqlParameter("@CRMCTN_Name", SqlDbType.VarChar, 400);
            para[1].Value = name;
            para[2] = new SqlParameter("@CRMCTN_Note", SqlDbType.VarChar, 400);
            para[2].Value = node;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_CRMCustomTrackNode", para);
        }
        //删除追踪环节
        public void Delete_Node(Guid id)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@CRMCTN_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = id;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_CRMCustomTrackNode", para);
        }
         //录入追踪环节信息
        public void Insert_Track(Guid ccdID,Guid ctnID,string reason,string remark,string path,string upload,string man)
        {
            SqlParameter[] para = new SqlParameter[7];
            para[0] = new SqlParameter("@CRMCCD_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = ccdID;
            para[1] = new SqlParameter("@CRMCTN_ID", SqlDbType.UniqueIdentifier);
            para[1].Value = ctnID;
            para[2] = new SqlParameter("@CRMCCT_Reason", SqlDbType.VarChar, 400);
            para[2].Value = reason;
            para[3] = new SqlParameter("@CRMCCT_Remark", SqlDbType.VarChar,400);
            para[3].Value = remark;
            para[4] = new SqlParameter("@CRMCCT_Path", SqlDbType.VarChar, 100);
            para[4].Value = path;
            para[5] = new SqlParameter("@CRMCCT_Upload", SqlDbType.VarChar, 2);
            para[5].Value = upload;
            para[6] = new SqlParameter("@CRMCCT_Man", SqlDbType.VarChar,20);
            para[6].Value = man;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_CRMCustomerComplainTrack", para);
        }
        //修改追踪环节信息
        public void Update_Track(Guid ccdID, Guid ctnID, string reason, string remark, string path, string upload, string man,Guid mid)
        {
            SqlParameter[] para = new SqlParameter[8];
            para[0] = new SqlParameter("@CRMCCD_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = ccdID;
            para[1] = new SqlParameter("@CRMCTN_ID", SqlDbType.UniqueIdentifier);
            para[1].Value = ctnID;
            para[2] = new SqlParameter("@CRMCCT_Reason", SqlDbType.VarChar, 400);
            para[2].Value = reason;
            para[3] = new SqlParameter("@CRMCCT_Remark", SqlDbType.VarChar, 400);
            para[3].Value = remark;
            para[4] = new SqlParameter("@CRMCCT_Path", SqlDbType.VarChar, 100);
            para[4].Value = path;
            para[5] = new SqlParameter("@CRMCCT_Upload", SqlDbType.VarChar, 2);
            para[5].Value = upload;
            para[6] = new SqlParameter("@CRMCCT_Man", SqlDbType.VarChar, 20);
            para[6].Value = man;
            para[7] = new SqlParameter("@CRMCCT_ID", SqlDbType.UniqueIdentifier);
            para[7].Value = mid;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_CRMCustomerComplainTrack", para);
        }
        //客户信息，设定为常用联系人
        public void Update_Important(Guid id)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@id", SqlDbType.UniqueIdentifier);
            para[0].Value = id;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_CRMCustomerInfo_Important", para);
        }
    }
