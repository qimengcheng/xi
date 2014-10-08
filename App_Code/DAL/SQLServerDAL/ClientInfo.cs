using System;
using System.Data;
using System.Data.SqlClient;
//using System.Collections.Generic;
using EquipmentMangementAjax.DBUtility;



    /// <summary>
    ///ClientInfo 的摘要说明
    /// </summary>
    public class ClientInfo
    {
        public ClientInfo()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        public DataSet SList_CRMCustomerInfoBind()//检索所有客户信息
        {
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_CRMCustomerInfoBind", null);
        }
        public DataSet SList_CRMCustomerContact(Guid CRMCIF_ID)//检索客户联系方式
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@CRMCIF_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = CRMCIF_ID;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_CRMCustomerContact", parm);
        }
        public void U_CRMCustomerInfo(Guid CRMCIF_ID,string CRMCIF_Name, string CRMRBI_Name, string CRMCSBD_Name, string CRMCIF_Address, string CRMCIF_BinTag,string man)//修改客户信息
        {
            SqlParameter[] parm = new SqlParameter[7];
            parm[0] = new SqlParameter("@CRMCIF_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = CRMCIF_ID;
            parm[1] = new SqlParameter("@CRMCIF_Name", SqlDbType.VarChar, 100);
            parm[1].Value = CRMCIF_Name;
            parm[2] = new SqlParameter("@CRMRBI_Name", SqlDbType.VarChar, 100);
            parm[2].Value = CRMRBI_Name;
            parm[3] = new SqlParameter("@CRMCSBD_Name", SqlDbType.VarChar, 100);
            parm[3].Value = CRMCSBD_Name;
            parm[4] = new SqlParameter("@CRMCIF_Address", SqlDbType.VarChar, 100);
            parm[4].Value = CRMCIF_Address;
            parm[5] = new SqlParameter("@CRMCIF_BinTag", SqlDbType.VarChar, 2);
            parm[5].Value = CRMCIF_BinTag;
            parm[6] = new SqlParameter("@man", SqlDbType.VarChar, 20);
            parm[6].Value = man;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_CRMCustomerInfo", parm);
        }
        public void I_CRMCustomerInfo(string CRMCIF_Name, string CRMRBI_Name, string CRMCSBD_Name, string CRMCIF_Address, string CRMCIF_BinTag,string man)//新增客户信息
        {
            SqlParameter[] parm = new SqlParameter[6];
            parm[0] = new SqlParameter("@CRMCIF_Name", SqlDbType.VarChar, 100);
            parm[0].Value = CRMCIF_Name;
            parm[1] = new SqlParameter("@CRMRBI_Name", SqlDbType.VarChar, 100);
            parm[1].Value = CRMRBI_Name;
            parm[2] = new SqlParameter("@CRMCSBD_Name", SqlDbType.VarChar, 100);
            parm[2].Value = CRMCSBD_Name;
            parm[3] = new SqlParameter("@CRMCIF_Address", SqlDbType.VarChar, 100);
            parm[3].Value = CRMCIF_Address;
            parm[4] = new SqlParameter("@CRMCIF_BinTag", SqlDbType.VarChar, 2);
            parm[4].Value = CRMCIF_BinTag;
            parm[5] = new SqlParameter("@man", SqlDbType.VarChar, 20);
            parm[5].Value = man;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_CRMCustomerInfo", parm);
        }


        public DataSet SList_CRMRegionBasicInfoDrop()//绑定区域信息
        {
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_CRMRegionBasicInfoDrop", null);
        }

        public DataSet SList_CRMCustomerSortBasicDataDrop()//绑定客户类别信息
        {
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_CRMCustomerSortBasicDataDrop", null);
        }

        public void Proc_D_CRMCustomerInfo(Guid CRMCIF_ID)//删除客户
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@CRMCIF_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = CRMCIF_ID;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_CRMCustomerInfo", parm);
      
        }
        public void I_CRMCustomerContact(Guid CRMCIF_ID, string CRMCC_Name, string CRMCC_Position, string CRMCC_PhoneNum, string CRMCC_TelePhoneNum, string CRMCC_FaxNum, string CRMCC_Email, string CRMCC_QQ)//新建客户联系方式
        {
            SqlParameter[] parm = new SqlParameter[8];
            parm[0] = new SqlParameter("@CRMCIF_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = CRMCIF_ID;
            parm[1] = new SqlParameter("@CRMCC_Name", SqlDbType.VarChar, 50);
            parm[1].Value = CRMCC_Name;
            parm[2] = new SqlParameter("@CRMCC_Position", SqlDbType.VarChar, 50);
            parm[2].Value = CRMCC_Position;
            parm[3] = new SqlParameter("@CRMCC_PhoneNum", SqlDbType.VarChar, 50);
            parm[3].Value = CRMCC_PhoneNum;
            parm[4] = new SqlParameter("@CRMCC_TelePhoneNum", SqlDbType.VarChar, 20);
            parm[4].Value = CRMCC_TelePhoneNum;
            parm[5] = new SqlParameter("@CRMCC_FaxNum", SqlDbType.VarChar, 50);
            parm[5].Value = CRMCC_FaxNum;
            parm[6] = new SqlParameter("@CRMCC_Email", SqlDbType.VarChar, 50);
            parm[6].Value = CRMCC_Email;
            parm[7] = new SqlParameter("@CRMCC_QQ", SqlDbType.VarChar, 50);
            parm[7].Value = CRMCC_QQ;

            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_CRMCustomerContact", parm);
        }

        public void Proc_U_CRMCustomerContact(Guid CRMCC_ID, Guid CRMCIF_ID, string CRMCC_Name, string CRMCC_Position, string CRMCC_PhoneNum, string CRMCC_TelePhoneNum, string CRMCC_FaxNum, string CRMCC_Email, string CRMCC_QQ)//修改客户联系方式
        {
            SqlParameter[] parm = new SqlParameter[9];
            parm[0] = new SqlParameter("@CRMCC_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = CRMCC_ID;
            parm[1] = new SqlParameter("@CRMCIF_ID", SqlDbType.UniqueIdentifier);
            parm[1].Value = CRMCIF_ID;
            parm[2] = new SqlParameter("@CRMCC_Name", SqlDbType.VarChar, 50);
            parm[2].Value = CRMCC_Name;
            parm[3] = new SqlParameter("@CRMCC_Position", SqlDbType.VarChar, 50);
            parm[3].Value = CRMCC_Position;
            parm[4] = new SqlParameter("@CRMCC_PhoneNum", SqlDbType.VarChar, 50);
            parm[4].Value = CRMCC_PhoneNum;
            parm[5] = new SqlParameter("@CRMCC_TelePhoneNum", SqlDbType.VarChar, 20);
            parm[5].Value = CRMCC_TelePhoneNum;
            parm[6] = new SqlParameter("@CRMCC_FaxNum", SqlDbType.VarChar, 50);
            parm[6].Value = CRMCC_FaxNum;
            parm[7] = new SqlParameter("@CRMCC_Email", SqlDbType.VarChar, 50);
            parm[7].Value = CRMCC_Email;
            parm[8] = new SqlParameter("@CRMCC_QQ", SqlDbType.VarChar, 50);
            parm[8].Value = CRMCC_QQ;

            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_CRMCustomerContact", parm);
        }

        public void Proc_D_CRMCustomerContact(Guid CRMCC_ID)//删除客户联系方式
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@CRMCC_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = CRMCC_ID;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_CRMCustomerContact", parm);

        }

        public DataSet SList_CRMCustomerBinTagDetail(Guid CRMCIF_ID)//检索客户物料标签
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@CRMCIF_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = CRMCIF_ID;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_CRMCustomerBinTagDetail", parm);
        }

        public DataSet S_SearchClientInfo(string CRMCIF_Name, string CRMRBI_Name, string CRMCSBD_Name, string CRMCIF_BinTag)//条件检索客户信息
        {
            SqlParameter[] parm = new SqlParameter[4];
            parm[0] = new SqlParameter("@CRMCIF_Name", SqlDbType.VarChar, 100);
            parm[0].Value = CRMCIF_Name;
            parm[1] = new SqlParameter("@CRMRBI_Name", SqlDbType.VarChar, 100);
            parm[1].Value = CRMRBI_Name;
            parm[2] = new SqlParameter("@CRMCSBD_Name", SqlDbType.VarChar, 100);
            parm[2].Value = CRMCSBD_Name;
            parm[3] = new SqlParameter("@CRMCIF_BinTag", SqlDbType.VarChar, 10);
            parm[3].Value = CRMCIF_BinTag;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Pro_S_SearchClientInfo", parm);

        }

 public void I_CRMCustomerBinTagDetail(Guid CRMCIF_ID, string Label_Product, string Label_Name, string Label_Number)//新增客户物料标签
        {
            SqlParameter[] parm = new SqlParameter[4];
            parm[0] = new SqlParameter("@CRMCIF_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = CRMCIF_ID;
            parm[1] = new SqlParameter("@Label_Product", SqlDbType.VarChar, 60);
            parm[1].Value = Label_Product;
            parm[2] = new SqlParameter("@Label_Name", SqlDbType.VarChar, 60);
            parm[2].Value = Label_Name;
            parm[3] = new SqlParameter("@Label_Number", SqlDbType.VarChar, 60);
            parm[3].Value = Label_Number;


            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_CRMCustomerBinTagDetail", parm);
        }

        public void Proc_U_CRMCustomerBinTagDetail(Guid CRMCBTD_ID, string ChanLabelPro, string ChanLabelWu, string ChanLabelWuName)//修改客户物料标签 
        {
            SqlParameter[] parm = new SqlParameter[4];
            parm[0] = new SqlParameter("@CRMCBTD_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = CRMCBTD_ID;
            parm[1] = new SqlParameter("@ChanLabelPro", SqlDbType.VarChar, 60);
            parm[1].Value = ChanLabelPro;
            parm[2] = new SqlParameter("@ChanLabelWu", SqlDbType.VarChar, 60);
            parm[2].Value = ChanLabelWu;
            parm[3] = new SqlParameter("@ChanLabelWuName", SqlDbType.VarChar, 60);
            parm[3].Value = ChanLabelWuName;


            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_CRMCustomerBinTagDetail", parm);
        }

        public void Proc_D_CRMCustomerBinTagDetail(Guid CRMCBTD_ID)//删除客户物料标签
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@CRMCBTD_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = CRMCBTD_ID;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_CRMCustomerBinTagDetail", parm);

        }


    }


