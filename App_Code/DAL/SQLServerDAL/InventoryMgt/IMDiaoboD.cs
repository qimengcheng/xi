using System;
using System.Data;
using System.Data.SqlClient;
//using System.Collections.Generic;
using EquipmentMangementAjax.DBUtility;

/// <summary>
///IMDiaoboD 的摘要说明
/// </summary>
/// 
namespace EquipmentMangementAjax.SQLServer
{
    public class IMDiaoboD:IIMDiaobo
    {
        public IMDiaoboD()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        //查询调拨主表
        public DataSet Select_Allot(string condition)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 1000);
            para[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_IMAllot", para);
        }
        //查询全部库存表
        public DataSet Select_IMStoreALL()
        {

            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_IMStore_All");
        }
        //新建调拨单
        public void Insert_Allot(Guid outID,Guid inID,string man)
        {
            SqlParameter[] para = new SqlParameter[3];
            para[0] = new SqlParameter("@IMA_OutHouse", SqlDbType.UniqueIdentifier);
            para[0].Value = outID;
            para[1] = new SqlParameter("@IMA_InHouse", SqlDbType.UniqueIdentifier);
            para[1].Value = inID;
            para[2] = new SqlParameter("@IMA_OutHouseMang", SqlDbType.VarChar, 20);
            para[2].Value = man;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_IMAllot", para);
        }
        //提交调拨单
        public void Update_Allot(Guid ID)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@IMA_AllotID", SqlDbType.UniqueIdentifier);
            para[0].Value = ID;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_IMAllot", para);
        }
        //填写清点数量
        public void Update_AllotDetail(Guid AllotID, decimal num,Guid Aid)
        {
            SqlParameter[] para = new SqlParameter[3];
            para[0] = new SqlParameter("@IMAD_AllotID", SqlDbType.UniqueIdentifier);
            para[0].Value = AllotID;
            para[1] = new SqlParameter("@IMAD_ActualCountNum", SqlDbType.Decimal,18);
            para[1].Value = num;
            para[2] = new SqlParameter("@IMSA_AreaID", SqlDbType.UniqueIdentifier);
            para[2].Value = Aid;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_IMAllotDetail", para);
        }
        //查询调拨详细表
        public DataSet Select_AllotDetail(Guid id )
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@IMA_AllotID", SqlDbType.UniqueIdentifier);
            para[0].Value = id;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_IMAllotDetail", para);
        }
        //查询出现异常的数目
        public DataSet Select_AllotDetail_Count(Guid id)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@IMA_AllotID", SqlDbType.UniqueIdentifier);
            para[0].Value = id;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_IMAllotDetail_Count", para);
        }
        //调拨单接受异常
        public void Update_Allot_Yichang(Guid AllotID, string man,string result)
        {
            SqlParameter[] para = new SqlParameter[3];
            para[0] = new SqlParameter("@IMAllot_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = AllotID;
            para[1] = new SqlParameter("@IMA_InHouseMang", SqlDbType.VarChar,20);
            para[1].Value = man;
            para[2] = new SqlParameter("@IMA_AllotState", SqlDbType.VarChar, 20);
            para[2].Value = result;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_IMAllot_Yichang", para);
        }
        //调拨详细表插入库存ID
        public void Insert_AllotDetail(Guid AllotID,Guid imID,decimal num)
        {
            SqlParameter[] para = new SqlParameter[3];
            para[0] = new SqlParameter("@IMA_AllotID", SqlDbType.UniqueIdentifier);
            para[0].Value = AllotID;
            para[1] = new SqlParameter("@IMID_ID", SqlDbType.UniqueIdentifier);
            para[1].Value = imID;
            para[2] = new SqlParameter("@IMAD_AllotNum", SqlDbType.Decimal,18);
            para[2].Value = num;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_IMAllotDetail", para);
        }
        //查询库房区域
        public DataSet Select_Area(Guid id)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@IMS_StoreID", SqlDbType.UniqueIdentifier);
            para[0].Value = id;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_IMKuArea", para);
        }
        //查询库存主表
        public DataSet Select_IMIM_Pubian(string condition)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 1000);
            para[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_IMInventoryMain_Pubian", para);
        }
        //正常接受，更新库存数据
        public void Update_Allot_IMID(Guid AllotID)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@IMA_AllotID", SqlDbType.UniqueIdentifier);
            para[0].Value = AllotID;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_IMAllot_IMID", para);
        }
       
    }

}