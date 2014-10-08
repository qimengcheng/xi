using System;
using System.Data;
using System.Data.SqlClient;
using EquipmentMangementAjax.DBUtility;

public class ProSpecialD
{
    public int InsertProType_Special(string PT_SpecialNeed, string PT_Note, string PT_SpecialTypeMan, string PT_SAccNum, string PT_SAccName, string PT_SAccPath)
    {
        SqlParameter[] para =
        {   
        new SqlParameter("@PT_SpecialNeed", SqlDbType.VarChar,2000),
    new SqlParameter("@PT_Note",SqlDbType.VarChar,400),
    new SqlParameter("@PT_SpecialTypeMan",SqlDbType.VarChar,20),
    new SqlParameter("@PT_SAccNum", SqlDbType.VarChar, 100),
        
   new SqlParameter("@PT_SAccName", SqlDbType.VarChar, 100),
        
   new SqlParameter("@PT_SAccPath", SqlDbType.VarChar, 100),
        


    };

        para[0].Value = PT_SpecialNeed;
        para[1].Value = PT_Note;
        para[2].Value = PT_SpecialTypeMan;
        para[3].Value = PT_SAccNum;
        para[4].Value = PT_SAccName;
       para[5].Value = PT_SAccPath;
        int ds = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_ProType_Special", para);
        return ds;

    }
    public DataSet SelectProType_Special(string condition)
    {
        SqlParameter para = new SqlParameter("@Condition", condition);
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_ProType_Special", para);
    }
    public int InsertPTCountersign(Guid PT_ID, string PTC_Dep)
    {
        SqlParameter[] para ={
                        new SqlParameter("@PT_ID",SqlDbType.UniqueIdentifier),
                        new SqlParameter("@PTC_Dep",SqlDbType.VarChar,20),  
                        };
        para[0].Value = PT_ID;
        para[1].Value = PTC_Dep;
        return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_PTCountersign", para);
    }
    public int UpdatePTCountersign(Guid PTC_ID, string PTC_Man, string PTC_State, string PTC_Suggestion)
    {
        SqlParameter[] para =
                    {
    new SqlParameter("@PTC_ID",SqlDbType.UniqueIdentifier),
    new SqlParameter ("@PTC_Man",SqlDbType.VarChar,20),
    new SqlParameter ("@PTC_State",SqlDbType.VarChar,20),
    new SqlParameter ("@PTC_Suggestion",SqlDbType.VarChar,400),
                    };
        para[0].Value = PTC_ID;
        para[1].Value = PTC_Man;
        para[2].Value = PTC_State;
        para[3].Value = PTC_Suggestion;
        return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_PTCountersign", para);
    }
    public DataSet SelectPTCountersign(string condition)
    {
        SqlParameter para = new SqlParameter("@Condition", condition);
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_PTCountersign", para);
    }
    //改变申请单状态
    public int UpdatePTCSate(Guid PT_ID, string PT_CSate)
    {
        SqlParameter[] para =
                    {
    new SqlParameter("@PT_ID",SqlDbType.UniqueIdentifier),
    new SqlParameter ("@PT_CSate",SqlDbType.VarChar,20),
   
                    };
        para[0].Value = PT_ID;
        para[1].Value = PT_CSate;

        return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_PT_CSate", para);
    }
    public int UpdateProType_Special(Guid PT_ID, string PT_SpecialNeed, string PT_Note, string PT_SAccNum, string PT_SAccName, string PT_SAccPath)
    {
        SqlParameter[] para =
                    {
            new SqlParameter("@PT_ID",SqlDbType.UniqueIdentifier),
            new SqlParameter ("@PT_SpecialNeed",SqlDbType.VarChar,2000),
            new SqlParameter ("@PT_Note",SqlDbType.VarChar,400),
            new SqlParameter("@PT_SAccNum", SqlDbType.VarChar, 100),
        
            new SqlParameter("@PT_SAccName", SqlDbType.VarChar, 100),
        
            new SqlParameter("@PT_SAccPath", SqlDbType.VarChar, 100),
                    };
        para[0].Value = PT_ID;
        para[1].Value = PT_SpecialNeed;
        para[2].Value = PT_Note;
        para[3].Value = PT_SAccNum;
        para[4].Value = PT_SAccName;
        para[5].Value = PT_SAccPath;

        return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_ProType_Special", para);
    }

    public int DeleteProType_Special(Guid PT_ID)
    {
        SqlParameter[] para =
                    {
            new SqlParameter("@PT_ID",SqlDbType.UniqueIdentifier),
                    };
        para[0].Value = PT_ID;
        return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_ProType_Special", para);
    }
    public int DeletePTCountersign(Guid PTC_ID)
    {
        SqlParameter[] para =
                    {
            new SqlParameter("@PTC_ID",SqlDbType.UniqueIdentifier),
                    };
        para[0].Value = PTC_ID;
        return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_PTCountersign", para);
    }
    //public void UpdateProType_SAcc(Guid PT_ID, string PT_SAccNum, string PT_SAccName, string PT_SAccPath)
    //{
    //    SqlParameter[] parm = new SqlParameter[4];
    //    parm[0] = new SqlParameter("@PT_ID", SqlDbType.UniqueIdentifier);
    //    parm[0].Value = PT_ID;
    //    parm[1] = new SqlParameter("@PT_SAccNum", SqlDbType.VarChar, 100);
    //    parm[1].Value = PT_SAccNum;
    //    parm[2] = new SqlParameter("@PT_SAccName", SqlDbType.VarChar, 100);
    //    parm[2].Value = PT_SAccName;
    //    parm[3] = new SqlParameter("@PT_SAccPath", SqlDbType.VarChar, 100);
    //    parm[3].Value = PT_SAccPath;
    //    SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_ProType_SAcc", parm);
    //}
    public void UpdateProType_MAcc(Guid PT_ID, string PT_MAccNum, string PT_MAccName, string PT_MAccPath)
    {
        SqlParameter[] parm = new SqlParameter[4];
        parm[0] = new SqlParameter("@PT_ID", SqlDbType.UniqueIdentifier);
        parm[0].Value = PT_ID;
        parm[1] = new SqlParameter("@PT_MAccNum", SqlDbType.VarChar, 100);
        parm[1].Value = PT_MAccNum;
        parm[2] = new SqlParameter("@PT_MAccName", SqlDbType.VarChar, 100);
        parm[2].Value = PT_MAccName;
        parm[3] = new SqlParameter("@PT_MAccPath", SqlDbType.VarChar, 100);
        parm[3].Value = PT_MAccPath;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_ProType_MAcc", parm);
    }
}
