using System;
using System.Data;
using System.Data.SqlClient;
//using System.Collections.Generic;
using EquipmentMangementAjax.DBUtility;

namespace EquipmentMangementAjax.SQLServer
{
    /// <summary>
    ///StoreBasic 的摘要说明
    /// </summary>
    public class StoreBasic:IStoreBasic
    {
        public StoreBasic()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        public DataSet SList_Imssd()//检索所有出入库类别
        {
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_IMSSD", null);
        }
        public DataSet I_IMssd_IN_OUT(string IN, string OUT)//检索出入库类别
        {
            SqlParameter[] parm = new SqlParameter[2];
            parm[0] = new SqlParameter("@IMSSbd_IN", SqlDbType.VarChar, 20);
            parm[0].Value = IN;
            parm[1] = new SqlParameter("@IMSSbd_OUT", SqlDbType.VarChar, 20);
            parm[1].Value = OUT;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_IMSSD_InOut", parm);
        }

        public DataSet SList_Istore()//检索所有库房
        {
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_IMStore", null);
        }

        public void U_IMssd(StoreBasicInfo storebasicinfo)//编辑出入库系列detail
        {
            SqlParameter[] parm = new SqlParameter[2];
            parm[0] = new SqlParameter("@IMSSbd_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = storebasicinfo.IMSSBD_ID;
            parm[1] = new SqlParameter("@IMSSbd_Detail", SqlDbType.VarChar, 200);
            parm[1].Value = storebasicinfo.IMSSBD_Detail;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_U_IMssBd", parm);
        }

        public void I_IMssd(StoreBasicInfo storebasicinfo)//新增入库类型
        {
            SqlParameter[] parm = new SqlParameter[4];
            parm[0] = new SqlParameter("@IMSSBD_Name", SqlDbType.VarChar, 50);
            parm[0].Value = storebasicinfo.IMSSBD_Name;
            parm[1] = new SqlParameter("@IMSSBD_Detail", SqlDbType.VarChar, 200);
            parm[1].Value = storebasicinfo.IMSSBD_Detail;
            parm[2] = new SqlParameter("@IMSSBD_Man", SqlDbType.VarChar, 20);
            parm[2].Value = storebasicinfo.IMSSBD_Man;
            parm[3] = new SqlParameter("@IMSSBD_Time", SqlDbType.Date);
            parm[3].Value = storebasicinfo.IMSSBD_Time;

            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_IMssd", parm);
        }
        public void I_IMssdOut(StoreBasicInfo storebasicinfo)//新增出库类型
        {
            SqlParameter[] parm = new SqlParameter[4];
            parm[0] = new SqlParameter("@IMSSBD_Name", SqlDbType.VarChar, 50);
            parm[0].Value = storebasicinfo.IMSSBD_Name;
            parm[1] = new SqlParameter("@IMSSBD_Detail", SqlDbType.VarChar, 200);
            parm[1].Value = storebasicinfo.IMSSBD_Detail;
            parm[2] = new SqlParameter("@IMSSBD_Man", SqlDbType.VarChar, 20);
            parm[2].Value = storebasicinfo.IMSSBD_Man;
            parm[3] = new SqlParameter("@IMSSBD_Time", SqlDbType.Date);
            parm[3].Value = storebasicinfo.IMSSBD_Time;

            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_IMssdOut", parm);
        }
        public DataSet SList_Imssd_Name(string SortName)//检索是否存在新增出，入库
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@IMSSBD_Name", SqlDbType.VarChar, 50);
            parm[0].Value = SortName;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_IMSSD_Name", parm);
        }
        public void D_IMssd(Guid IMssd_id)//删除出入库类别
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@IMSSBD_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = IMssd_id;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_D_IMssd", parm);

        }

        public DataSet SList_User_IMstore()//检索库房管理人员信息
        {
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_UserIMstore", null);
        }
        public DataSet SList_DROP_Depart()//绑定管理部门下拉
        {
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_DROPDepart", null);
        }

        public void I_IMstore_new(StoreBasicInfo storebasicinfo)//新增库房
        {
            SqlParameter[] parm = new SqlParameter[5];


            parm[0] = new SqlParameter("@IMS_StoreName", SqlDbType.VarChar, 50);
            parm[0].Value = storebasicinfo.IMS_StoreName;
            parm[1] = new SqlParameter("@IMS_ResponDepart", SqlDbType.VarChar, 100);
            parm[1].Value = storebasicinfo.IMS_ResponDepart;
            parm[2] = new SqlParameter("@IMS_ResponMan", SqlDbType.VarChar, 100);
            parm[2].Value = storebasicinfo.IMS_ResponMan;
            parm[3] = new SqlParameter("@Flag", SqlDbType.Decimal);
            parm[3].Value = storebasicinfo.Flag;
           parm[4] = new SqlParameter("@IMS_StoreID", SqlDbType.UniqueIdentifier);
            parm[4].Value = storebasicinfo.IMS_StoreID;

            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_IMStore_new", parm);
        }

        public DataSet SList_Imstore_Name(string IMS_StoreName)//检索是否存在库房
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@IMS_StoreName", SqlDbType.VarChar, 50);
            parm[0].Value = IMS_StoreName;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_IMStore_name", parm);
        }

        public void U_IMstore(StoreBasicInfo storebasicinfo)//更新库房
        {
            SqlParameter[] parm = new SqlParameter[3];
            parm[0] = new SqlParameter("@IMS_StoreID", SqlDbType.UniqueIdentifier);
            parm[0].Value = storebasicinfo.IMS_StoreID;
            parm[1] = new SqlParameter("@IMS_ResponDepart", SqlDbType.VarChar, 200);
            parm[1].Value = storebasicinfo.IMS_ResponDepart;
            parm[2] = new SqlParameter("@IMS_ResponMan", SqlDbType.VarChar, 200);
            parm[2].Value = storebasicinfo.IMS_ResponMan;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_U_IMStore", parm);
        }

        public DataSet SList_ImstoreManger(string condition)//检索库房管理人员
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@condition", SqlDbType.NVarChar, 1000);
            parm[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_IMstoreManger", parm);
        }

        public void D_IMstore(Guid IMS_Storeid)//删除出入库类别
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@IMS_StoreID", SqlDbType.UniqueIdentifier);
            parm[0].Value = IMS_Storeid;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_D_IMStore", parm);

        }

        public DataSet S_STOREareal(Guid guid_id)//检索区域
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@IMS_StoreID", SqlDbType.UniqueIdentifier);
            parm[0].Value = guid_id;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_STOREareal", parm);
        }

        public void I_IMstoreAreal(StoreBasicInfo storebasicinfo)//新增区域
        {
            SqlParameter[] parm = new SqlParameter[4];
            parm[0] = new SqlParameter("@IMS_StoreID", SqlDbType.UniqueIdentifier);
            parm[0].Value = storebasicinfo.IMS_StoreID;
            parm[1] = new SqlParameter("@IMSA_AreaName", SqlDbType.VarChar, 100);
            parm[1].Value = storebasicinfo.IMSA_AreaName;
            parm[2] = new SqlParameter("@IMSA_Remark", SqlDbType.VarChar, 400);
            parm[2].Value = storebasicinfo.IMSA_Remark;
            parm[3] = new SqlParameter("@IMSA_MakeMan", SqlDbType.VarChar, 20);
            parm[3].Value = storebasicinfo.IMSA_MakeMan;

            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_IMStore_Areal", parm);
        }

        public void D_IMstore_Areal(Guid IMSA_AreaID)//删除区域
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@IMSA_AreaID", SqlDbType.UniqueIdentifier);
            parm[0].Value = IMSA_AreaID;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_D_IMStore_Areal", parm);

        }

        public void U_IMstore_Areal(StoreBasicInfo storebasicinfo)//更新区域
        {
            SqlParameter[] parm = new SqlParameter[4];
            parm[0] = new SqlParameter("@IMSA_AreaID", SqlDbType.UniqueIdentifier);
            parm[0].Value = storebasicinfo.IMSA_AreaID;
            parm[1] = new SqlParameter("@IMSA_AreaName", SqlDbType.VarChar, 100);
            parm[1].Value = storebasicinfo.IMSA_AreaName;
            parm[2] = new SqlParameter("@IMSA_Remark", SqlDbType.VarChar, 400);
            parm[2].Value = storebasicinfo.IMSA_Remark;
            parm[3] = new SqlParameter("@IMSA_MakeMan", SqlDbType.VarChar, 20);
            parm[3].Value = storebasicinfo.IMSA_MakeMan;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_U_IMStore_Areal", parm);
        }
        public DataSet SList_Imstore_ArealName(string IMS_StoreArealName, Guid IMSTORE_ID)//检索是否存在区域
        {
            SqlParameter[] parm = new SqlParameter[2];
            parm[0] = new SqlParameter("@IMSA_AreaName", SqlDbType.VarChar, 100);
            parm[0].Value = IMS_StoreArealName;
            parm[1] = new SqlParameter("@IMS_StoreID", SqlDbType.UniqueIdentifier);
            parm[1].Value = IMSTORE_ID;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_IMStore_ArealName", parm);
        }

    }
}