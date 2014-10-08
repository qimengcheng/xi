using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using EquipmentMangementAjax.DBUtility;

/// <summary>
///ExptTestD 的摘要说明
/// </summary>
namespace EquipmentMangementAjax.SQLServer
{
    public class ExpTestD : IExpTest
    {
        public ExpTestD()
        { }

        //检索样品类型
        public DataSet Search_ExpSampleType_GridView(string EST_SampleType)
        {
            SqlParameter parm = new SqlParameter("@EST_SampleType", EST_SampleType);
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_ExpSampleType_One", parm);

        }

        //检索样品类型，参数为ID
        public IList<ExpSampleType_ExpItems> Search_ExpSampleType_ID(Guid eST_SampleTypeID)
        {
            SqlParameter parm = new SqlParameter("@EST_SampleTypeID", eST_SampleTypeID);
            IList<ExpSampleType_ExpItems> expSampleType_ExpItems = new List<ExpSampleType_ExpItems>();
            SqlDataReader sdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_S_ExpSampleType", parm);
            while (sdr.Read())
            {
                expSampleType_ExpItems.Add(new ExpSampleType_ExpItems(sdr["EST_SampleType"] 
                    == DBNull.Value ? "" : sdr["EST_SampleType"].ToString()));
            }
            return expSampleType_ExpItems;
        }

        public int Insert_ExpSampleType(ExpSampleType_ExpItems expSampleType_ExpItems)//插入新的样品类型
        {
            SqlParameter[] parm = new SqlParameter[3];
            parm[0] = new SqlParameter("@EST_SampleTypeID", SqlDbType.UniqueIdentifier);
            parm[0].Value = expSampleType_ExpItems.EST_SampleTypeID;

            parm[1] = new SqlParameter("@EST_SampleType", SqlDbType.VarChar, 60);
            parm[1].Value = expSampleType_ExpItems.EST_SampleType;

            parm[2] = new SqlParameter("@EST_IsDeleted", SqlDbType.Bit);
            parm[2].Value = expSampleType_ExpItems.EST_IsDeleted;

            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_ExpSampleType", parm);
        }
        public int Update_ExpSampleType(ExpSampleType_ExpItems expSampleType_ExpItems)//修改样品类型
        {
            SqlParameter[] parm = new SqlParameter[2];
            parm[0] = new SqlParameter("@EST_SampleTypeID", SqlDbType.UniqueIdentifier);
            parm[0].Value = expSampleType_ExpItems.EST_SampleTypeID;

            parm[1] = new SqlParameter("@EST_SampleType", SqlDbType.VarChar, 60);
            parm[1].Value = expSampleType_ExpItems.EST_SampleType;

            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_U_ExpSampleType", parm);
        }
        public int Delete_ExpSampleType(Guid EST_SampleTypeID)//删除样品类型
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@EST_SampleTypeID", SqlDbType.UniqueIdentifier);
            parm[0].Value = EST_SampleTypeID;
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
              CommandType.StoredProcedure, "Proc_D_ExpSampleType", parm);
        }

        //检索实验项目，参数为ID
        public IList<ExpSampleType_ExpItems> Search_ExpItems_ID(Guid eST_SampleTypeID)
        {
            SqlParameter para = new SqlParameter("@EI_ExpItemID", eST_SampleTypeID);
            IList<ExpSampleType_ExpItems> expSampleType_ExpItems = new List<ExpSampleType_ExpItems>();
            SqlDataReader sdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_S_ExpItems", para);
            while (sdr.Read())
            {
                expSampleType_ExpItems.Add(new ExpSampleType_ExpItems(sdr["EI_ExpItem"] == DBNull.Value ? "" : sdr["EI_ExpItem"].ToString(),
                    sdr["EI_ExpCondtition"] == DBNull.Value ? "" : sdr["EI_ExpCondtition"].ToString(),
                   sdr["EI_ExpMethold"] == DBNull.Value ? "" : sdr["EI_ExpMethold"].ToString()));

            }
            return expSampleType_ExpItems;
        }

        //检索所有实验项目，默认显示
        public DataSet Search_ExpItems_Gridview(string EI_ExpItem, string EI_ExpCondtition, string EI_ExpMethold)
        {
            SqlParameter[] parm = new SqlParameter[3];
            parm[0] = new SqlParameter("@EI_ExpItem", SqlDbType.VarChar, 40);
            parm[0].Value = EI_ExpItem;
            parm[1] = new SqlParameter("@EI_ExpCondtition", SqlDbType.VarChar, 200);
            parm[1].Value = EI_ExpCondtition;
            parm[2] = new SqlParameter("@EI_ExpMethold", SqlDbType.VarChar, 200);
            parm[2].Value = EI_ExpMethold;
            return (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_ExpItems_One", parm);

        }

        public DataSet Search_ExpItems(ExpSampleType_ExpItems A)//模糊检索实验项目
        {
            SqlParameter[] parm = new SqlParameter[3];
            parm[0] = new SqlParameter("@EI_ExpItem", SqlDbType.VarChar,40);
            parm[0].Value = A.EI_ExpItem;
            parm[1] = new SqlParameter("@EI_ExpCondtition", SqlDbType.VarChar,200);
            parm[1].Value = A.EI_ExpCondtition;
            parm[2] = new SqlParameter("@EI_ExpMethold", SqlDbType.VarChar,200);
            parm[2].Value = A.EI_ExpMethold;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_ExpItems_One", parm);

        }

        public int Insert_ExpItems(ExpSampleType_ExpItems A)//插入新的实验项目
        {
            SqlParameter[] parm = new SqlParameter[3];
            parm[0] = new SqlParameter("@EI_ExpItem", SqlDbType.VarChar,40);
            parm[0].Value = A.EI_ExpItem;

            parm[1] = new SqlParameter("@EI_ExpCondtition", SqlDbType.VarChar, 200);
            parm[1].Value = A.EI_ExpCondtition;

            parm[2] = new SqlParameter("@EI_ExpMethold", SqlDbType.VarChar, 200);
            parm[2].Value = A.EI_ExpMethold;

            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_ExpItems", parm);
        }
        public int Update_ExpItems(ExpSampleType_ExpItems A)//修改实验项目
        {
            SqlParameter[] parm = new SqlParameter[4];
            parm[0] = new SqlParameter("@EI_ExpItemID", SqlDbType.UniqueIdentifier);
            parm[0].Value = A.EI_ExpItemID;

            parm[1] = new SqlParameter("@EI_ExpItem", SqlDbType.VarChar, 40);
            parm[1].Value = A.EI_ExpItem;

            parm[2] = new SqlParameter("@EI_ExpCondtition", SqlDbType.VarChar,200);
            parm[2].Value = A.EI_ExpCondtition;

            parm[3] = new SqlParameter("@EI_ExpMethold", SqlDbType.VarChar, 200);
            parm[3].Value = A.EI_ExpMethold;

            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_U_ExpItems", parm);
        }
        public int Delete_ExpItems(Guid EI_ExpItemID)//删除实验项目
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@EI_ExpItemID", SqlDbType.UniqueIdentifier);
            parm[0].Value = EI_ExpItemID;
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
              CommandType.StoredProcedure, "Proc_D_ExpItems", parm);
        }
    }
}

