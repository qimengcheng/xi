using System;
using System.Data;
using System.Data.SqlClient;
using EquipmentMangementAjax.DBUtility;

/// <summary>
/// DefectProduct 的摘要说明
/// </summary>
public class DefectProduct
{
    public SqlDataReader Query_DefectReason()
    {
        SqlParameter[] para =
        {
        };
        SqlDataReader ds = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_DefectReason", null);
        return ds;
    }

    public DataSet Query_DefectProduct(string type, string cra, string people, DateTime stime, DateTime etime,
        string state, string res)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@type", SqlDbType.VarChar, 60),
            new SqlParameter("@cra", SqlDbType.VarChar, 30),
            new SqlParameter("@people", SqlDbType.VarChar, 20),
            new SqlParameter("@stime", SqlDbType.DateTime),
            new SqlParameter("@etime", SqlDbType.DateTime),
            new SqlParameter("@state", SqlDbType.VarChar, 20),
            new SqlParameter("@res", SqlDbType.VarChar, 60),
        };

        para[0].Value = type;
        para[1].Value = cra;
        para[2].Value = people;
        para[3].Value = stime;
        para[4].Value = etime;
        para[5].Value = state != "所有类型" ? state : null;
        para[6].Value = res != "所有原因" ? res : null;




        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_DefectProduct", para);
        return ds;
    }
    public DataSet Query_DefectProduct()
    {
        SqlParameter[] para =
        {
            new SqlParameter("@type", SqlDbType.VarChar, 60),
            new SqlParameter("@cra", SqlDbType.VarChar, 30),
            new SqlParameter("@people", SqlDbType.VarChar, 20),
            new SqlParameter("@stime", SqlDbType.DateTime),
            new SqlParameter("@etime", SqlDbType.DateTime),
            new SqlParameter("@state", SqlDbType.VarChar, 20),
            new SqlParameter("@res", SqlDbType.VarChar, 60),
        };

        para[0].Value =null;
        para[1].Value = null;
        para[2].Value = null;
        para[3].Value = Convert.ToDateTime("1/1/1753 12:00:00 AM");
        para[4].Value = Convert.ToDateTime("12/31/9999 11:59:59 PM");
        para[5].Value = null;
        para[6].Value = null;




        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_DefectProduct", para);
        return ds;
    }
    public DataSet Query_DefectProduct(Guid ppGuid)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@ppid", SqlDbType.UniqueIdentifier),
        };
        para[0].Value = ppGuid;
        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_DefectProductByID", para);
        return ds;
    }
    #region 增加

    public int Insert_Defecttype(string opt)
    {

        SqlParameter[] para =
        {
            new SqlParameter("@opt", SqlDbType.VarChar, 60),
        };
        para[0].Value = opt;


        int ds = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_I_ProblemOption", para);

        return ds;


    }

    public Guid Insert_DefectProduct(Guid typeid, Guid craid, Guid poid, string depid, decimal num, string detail,
        string man)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@ppid", SqlDbType.UniqueIdentifier),
            new SqlParameter("@typeid", SqlDbType.UniqueIdentifier),
            new SqlParameter("@craid", SqlDbType.UniqueIdentifier),
            new SqlParameter("@poid", SqlDbType.UniqueIdentifier),
            new SqlParameter("@depid", SqlDbType.VarChar, 30),
            new SqlParameter("@num", SqlDbType.Decimal),
            new SqlParameter("@detail", SqlDbType.VarChar, 400),
            new SqlParameter("@man", SqlDbType.VarChar, 20),
        };
        para[0].Direction = ParameterDirection.Output;
        para[1].Value = typeid;
        para[2].Value = craid;
        para[3].Value = poid;
        para[4].Value = depid;
        para[5].Value = num;
        para[6].Value = detail;
        para[7].Value = man;
        Guid ds = SqlHelper.ExecuteReturnGuidQuery(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_I_ProblemProduct", para);
        return ds;
    }

    public int Insert_WorkOrder(Guid wo, Guid pp)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@woid", SqlDbType.UniqueIdentifier),
            new SqlParameter("@pp", SqlDbType.UniqueIdentifier)
        };
        para[0].Value = wo;
        para[1].Value = pp;


        int ds = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_I_WorkOrderforProblemProduct", para);

        return ds;
    }

    public int Insert_Result(Guid pp, string result)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@pp", SqlDbType.UniqueIdentifier),
            new SqlParameter("@res", SqlDbType.VarChar, 60)
        };
        para[0].Value = pp;
        para[1].Value = result;


        int ds = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_I_ProblemProduct_TrackResult", para);

        return ds;
    }

    public int Insert_DefectDep(Guid ppidGuid, string s)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@pp", SqlDbType.UniqueIdentifier),
            new SqlParameter("@dep", SqlDbType.VarChar, 60)
        };
        para[0].Value = ppidGuid;
        para[1].Value = s;


        int ds = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_I_PPDepSuggestion", para);

        return ds;
    }

    #endregion

    #region 查询

    public DataSet Query_ProType(string name)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@type", SqlDbType.VarChar, 60),
        };
        para[0].Value = name;
        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_ProType_S", para);
        return ds;
    }

    public DataSet Query_PBC(string name)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@name", SqlDbType.VarChar, 30),
        };
        para[0].Value = name;
        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_PBCraftInfoByName", para);
        return ds;
    }

    public DataSet Query_BDOS(string name)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@name", SqlDbType.VarChar, 30),
        };
        para[0].Value = name;
        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_BDOrganizationSheetByName", para);
        return ds;
    }

    public DataSet Query_DefectType(string name)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@name", SqlDbType.VarChar, 60),
        };
        para[0].Value = name;
        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_ProblemOption", para);
        return ds;
    }

    public DataSet Query_WorkOrder(string name)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@num", SqlDbType.VarChar, 60),
        };
        para[0].Value = name;
        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_WorkOrderForDefect", para);
        return ds;
    }

    public DataSet Query_ConnectedWorkOrder(Guid ppidGuid)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@ppid", SqlDbType.UniqueIdentifier),
        };
        para[0].Value = ppidGuid;
        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_WorkOrderforProblemProduct", para);
        return ds;
    }

    public string Get_Result(Guid pp)
    {
        SqlParameter[] para =
        {

            new SqlParameter("@res", SqlDbType.VarChar, 60),
            new SqlParameter("@pp", SqlDbType.UniqueIdentifier)
        };
        para[0].Direction = ParameterDirection.Output;
        para[1].Value = pp;


        string ds = SqlHelper.ExecuteStringReturnQuery(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_ProblemProduct_TrackResult", para);

        return ds;
    }
    public DataSet GetAuditSuggest(Guid p)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@ppid", SqlDbType.UniqueIdentifier),
        };
        para[0].Value = p;
        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_PPDepSuggestionALL", para);
        return ds;

    }

    #endregion

    #region 删除

    public int Delete_DefectProduct(Guid ppidGuid)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@ppid", SqlDbType.UniqueIdentifier),
        };
        para[0].Value = ppidGuid;
        int ds = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_D_ProblemProduct", para);
        return ds;
    }

    public int Delete_WorkOrder(Guid wo)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@woid", SqlDbType.UniqueIdentifier),

        };
        para[0].Value = wo;



        int ds = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_D_WorkOrderforProblemProduct", para);

        return ds;
    }

    #endregion

    #region 更新

    public int Update_DefectProduct(Guid pp, Guid type, Guid cra, Guid po, string dep, decimal num, string description,
        string p)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@ppid", SqlDbType.UniqueIdentifier),
            new SqlParameter("@typeid", SqlDbType.UniqueIdentifier),
            new SqlParameter("@craid", SqlDbType.UniqueIdentifier),
            new SqlParameter("@poid", SqlDbType.UniqueIdentifier),
            new SqlParameter("@depid", SqlDbType.VarChar, 30),
            new SqlParameter("@num", SqlDbType.Decimal),
            new SqlParameter("@detail", SqlDbType.VarChar, 400),
            new SqlParameter("@man", SqlDbType.VarChar, 20),
        };
        para[0].Value = pp;
        para[1].Value = type;
        para[2].Value = cra;
        para[3].Value = po;
        para[4].Value = dep;
        para[5].Value = num;
        para[6].Value = description;
        para[7].Value = p;
        int ds = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_U_ProblemProduct", para);
        return ds;
    }

    #endregion





    public int Update_State_Setup(Guid p)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@ppid", SqlDbType.UniqueIdentifier),
        };
        para[0].Value = p;
        int ds = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_U_ProblemProductStateSetUp", para);
        return ds;
    }
    public int Update_State_AuditPass(Guid p)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@ppid", SqlDbType.UniqueIdentifier),
        };
        para[0].Value = p;
        int ds = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_U_ProblemProductStatePass", para);
        return ds;
    }
    public int Update_State_AuditReject(Guid p)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@ppid", SqlDbType.UniqueIdentifier),
        };
        para[0].Value = p;
        int ds = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_U_ProblemProductStateReject", para);
        return ds;
    }

    public int ClearDefectDep(Guid pp)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@pp", SqlDbType.UniqueIdentifier),
        };
        para[0].Value = pp;
        int ds = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_D_PPDepSuggestion", para);
        return ds;
    }






    public SqlDataReader Query_CapableDep(Guid ppidGuid)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@ppid", SqlDbType.UniqueIdentifier),
        };
        para[0].Value = ppidGuid;
        SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_PPDepSuggestionCap", para);
        return dr;
    }
    public SqlDataReader Query_CapableDepDone(Guid ppidGuid)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@ppid", SqlDbType.UniqueIdentifier),
        };
        para[0].Value = ppidGuid;
        SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_PPDepSuggestionCapDone", para);
        return dr;
    }

    public int Update_DepView(Guid ppdsGuid,string man,string view)
    {        SqlParameter[] para =
        {
            new SqlParameter("@man", SqlDbType.VarChar,20),
            new SqlParameter("@ppds", SqlDbType.UniqueIdentifier),
            new SqlParameter("@view", SqlDbType.VarChar,400)
        };
         para[0].Value = man;
         para[1].Value = ppdsGuid;
         para[2].Value = view;
        int a = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_U_PPDepSuggestion", para);
        return a;
    }

   
}