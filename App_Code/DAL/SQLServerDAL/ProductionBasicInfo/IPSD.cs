using System;
using System.Data;
using System.Data.SqlClient;
using EquipmentMangementAjax.DBUtility;

/// <summary>
///IPSD 的摘要说明
/// </summary>
public class IPSD
{
	public IPSD()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    public DataSet S_IPSMain(string condition)
    {
        SqlParameter[] parm = new SqlParameter[1];
        parm[0] = new SqlParameter("@condition", SqlDbType.VarChar, 2000);
        parm[0].Value = condition;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_IPSMain", parm);

    }

    public void U_IPSMain(Guid IPSM_ID, string IPSM_Type)
    {
        SqlParameter[] parm = new SqlParameter[2];
        parm[0] = new SqlParameter("@IPSM_ID", SqlDbType.UniqueIdentifier);
        parm[0].Value = IPSM_ID;
        parm[1] = new SqlParameter("@IPSM_Type", SqlDbType.VarChar, 60);
        parm[1].Value = IPSM_Type;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
        CommandType.StoredProcedure, "Proc_U_IPSMain", parm);
    }

    public void I_IPSMain(string IPSM_Type)
    {
        SqlParameter[] parm = new SqlParameter[1];
        parm[0] = new SqlParameter("@IPSM_Type", SqlDbType.VarChar, 60);
        parm[0].Value = IPSM_Type;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
        CommandType.StoredProcedure, "Proc_I_IPSMain", parm);
    }

    public void D_IPSMain(Guid IPSM_ID)
    {
        SqlParameter[] parm = new SqlParameter[1];
        parm[0] = new SqlParameter("@IPSM_ID", SqlDbType.UniqueIdentifier);
        parm[0].Value = IPSM_ID;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
        CommandType.StoredProcedure, "Proc_D_IPSMain", parm);
    }

    public DataSet S_IPSDetail(Guid IPSM_ID)
    {
        SqlParameter[] parm = new SqlParameter[1];
        parm[0] = new SqlParameter("@IPSM_ID", SqlDbType.UniqueIdentifier);
        parm[0].Value = IPSM_ID;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_IPSDetail", parm);

    }

    public void U_IPSDetail(Guid IPSD_ID, string IPSD_Type)
    {
        SqlParameter[] parm = new SqlParameter[2];
        parm[0] = new SqlParameter("@IPSD_ID", SqlDbType.UniqueIdentifier);
        parm[0].Value = IPSD_ID;
        parm[1] = new SqlParameter("@IPSD_Type", SqlDbType.VarChar, 60);
        parm[1].Value = IPSD_Type;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
        CommandType.StoredProcedure, "Proc_U_IPSDetail", parm);
    }

    public void I_IPSDetail(Guid IPSM_ID, string IPSD_Type)
    {
        SqlParameter[] parm = new SqlParameter[2];
        parm[0] = new SqlParameter("@IPSM_ID", SqlDbType.UniqueIdentifier);
        parm[0].Value = IPSM_ID;
        parm[1] = new SqlParameter("@IPSD_Type", SqlDbType.VarChar, 60);
        parm[1].Value = IPSD_Type;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
        CommandType.StoredProcedure, "Proc_I_IPSDetail", parm);
    }

    public void D_IPSDetail(Guid IPSD_ID)
    {
        SqlParameter[] parm = new SqlParameter[1];
        parm[0] = new SqlParameter("@IPSD_ID", SqlDbType.UniqueIdentifier);
        parm[0].Value = IPSD_ID;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
        CommandType.StoredProcedure, "Proc_D_IPSDetail", parm);
    }

    public DataSet S_ProTypeIPS(Guid PT_ID)
    {
        SqlParameter[] parm = new SqlParameter[1];
        parm[0] = new SqlParameter("@PT_ID", SqlDbType.UniqueIdentifier);
        parm[0].Value = PT_ID;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_ProTypeIPS", parm);

    }

    public void I_ProTypeIPS(Guid PT_ID, Guid IPSM_ID, Guid IPSD_ID)
    {
        SqlParameter[] parm = new SqlParameter[3];
        parm[0] = new SqlParameter("@PT_ID", SqlDbType.UniqueIdentifier);
        parm[0].Value = PT_ID;
        parm[1] = new SqlParameter("@IPSM_ID", SqlDbType.UniqueIdentifier);
        parm[1].Value = IPSM_ID;
        parm[2] = new SqlParameter("@IPSD_ID", SqlDbType.UniqueIdentifier);
        parm[2].Value = IPSD_ID;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
        CommandType.StoredProcedure, "Proc_I_ProTypeIPS", parm);
    }

    public void D_ProTypeIPS(Guid PTIPS_ID)
    {
        SqlParameter[] parm = new SqlParameter[1];
        parm[0] = new SqlParameter("@PTIPS_ID", SqlDbType.UniqueIdentifier);
        parm[0].Value = PTIPS_ID;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
        CommandType.StoredProcedure, "Proc_D_ProTypeIPS", parm);
    }

    public void Copy_IPSMain(Guid PT_ID1, Guid PT_ID2)
    {
        SqlParameter[] parm = new SqlParameter[2];
        parm[0] = new SqlParameter("@PT_ID1", SqlDbType.UniqueIdentifier);
        parm[0].Value = PT_ID1;
        parm[1] = new SqlParameter("@PT_ID2", SqlDbType.UniqueIdentifier);
        parm[1].Value = PT_ID2;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
        CommandType.StoredProcedure, "Proc_Copy_IPSMain", parm);
    }
}