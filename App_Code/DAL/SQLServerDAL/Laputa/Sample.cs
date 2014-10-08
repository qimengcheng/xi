using System;
using System.Data;
using System.Data.SqlClient;
using EquipmentMangementAjax.DBUtility;

/// <summary>
///     BOM 的摘要说明
/// </summary>
public class Sample
{
    #region 查询

    public DataSet Query_Sample(string consumer, string makeman, string type, DateTime begindate, DateTime enddate,
        string promaker, string state)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@consumer", SqlDbType.VarChar, 100),
            new SqlParameter("@makeman", SqlDbType.VarChar, 20),
            new SqlParameter("@type", SqlDbType.VarChar, 60),
            new SqlParameter("@begindate", SqlDbType.DateTime),
            new SqlParameter("@enddate", SqlDbType.DateTime),
            new SqlParameter("@promaker", SqlDbType.VarChar, 60),
            new SqlParameter("@state", SqlDbType.VarChar, 20)
        };

        para[0].Value = consumer;
        para[1].Value = makeman;
        para[2].Value = type;
        para[3].Value = begindate;
        para[4].Value = enddate;
        para[5].Value = promaker;
        if (state == "所有状态")
        {
            para[6].Value = null;
        }
        else
        {
            para[6].Value = state;
        }

        //foreach (SqlParameter i in para)
        //{
        //    if (i.Value.ToString() == "")
        //    {
        //        i.Value = null;
        //    }
        //}


        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_CRMCompanySample", para);
        return ds;
    }

    public DataSet Query_Sample()
    {
        SqlParameter[] para =
        {
            new SqlParameter("@consumer", SqlDbType.VarChar, 60),
            new SqlParameter("@makeman", SqlDbType.VarChar, 20),
            new SqlParameter("@type", SqlDbType.VarChar, 50),
            new SqlParameter("@begindate", SqlDbType.VarChar, 8),
            new SqlParameter("@enddate", SqlDbType.DateTime),
            new SqlParameter("@promaker", SqlDbType.DateTime),
            new SqlParameter("@state", SqlDbType.VarChar, 20)
        };
        para[0].Value = null;
        para[1].Value = null;
        para[2].Value = null;
        para[3].Value = null;
        para[4].Value = null;
        para[5].Value = null;


        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_CRMCompanySample", para);
        return ds;
    }

    public DataSet Query_ProType(string name)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@type", SqlDbType.VarChar, 60)
        };
        para[0].Value = name;
        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_ProType_S", para);
        return ds;
    }

    public DataSet Query_Track(Guid id)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@sampleid", SqlDbType.UniqueIdentifier)
        };
        para[0].Value = id;


        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_CRMCompanySampleSchedule", para);

        return ds;
    }


    public DataSet Query_Workorder(string num)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@num", SqlDbType.VarChar, 30)
        };
        para[0].Value = num;


        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_WorkOrderForSample", para);

        return ds;
    }

    public DataSet Query_InStoreNum(string num)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@num", SqlDbType.VarChar, 30)
        };
        para[0].Value = num;


        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_IMInStoreMainForSample", para);

        return ds;
    }

    public DataSet Query_BDOS(string name)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@name", SqlDbType.VarChar, 30)
        };
        para[0].Value = name;
        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_BDOrganizationSheetByName", para);
        return ds;
    }

    public DataSet Query_Client(string name)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@name", SqlDbType.VarChar, 100)
        };
        para[0].Value = name;
        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_CRMCustomerInfo", para);
        return ds;
    }

    #endregion

    #region 增加

    public int Insert_BOM(Guid id, string name, string special, string people)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@id", SqlDbType.UniqueIdentifier),
            new SqlParameter("@name", SqlDbType.VarChar, 60),
            new SqlParameter("@special", SqlDbType.Char, 2),
            new SqlParameter("@people", SqlDbType.VarChar, 10)
        };
        para[0].Value = id;
        para[1].Value = name;
        para[2].Value = special;
        para[3].Value = people;


        int ds = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_I_BOM", para);

        return ds;
    }

    public int Insert_CRMCompanySample(string cname,string ccode, string bdcode, Guid typeid, decimal num, string note,
        string maker, string appdep)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@consumername", SqlDbType.VarChar, 60){Value = cname},
            new SqlParameter("@consumercode", SqlDbType.VarChar, 20){Value = ccode},
            new SqlParameter("@bdcode", SqlDbType.VarChar, 60){Value = bdcode},
            new SqlParameter("@typeid", SqlDbType.UniqueIdentifier){Value = typeid},
            new SqlParameter("@num", SqlDbType.Decimal){Value = num},
            new SqlParameter("@note", SqlDbType.VarChar, 400){Value = note},
            new SqlParameter("@maker", SqlDbType.VarChar, 20){Value = maker},
            new SqlParameter("@Appdep", SqlDbType.VarChar, 20){Value = appdep},
        };
        int ds = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_I_CRMCompanySample", para);

        return ds;
    }

    public int Insert_CRMCompanySampleSchedule(Guid sid, string name, string note, string man, string result, string url)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@Sampleid", SqlDbType.UniqueIdentifier),
            new SqlParameter("@Name", SqlDbType.VarChar, 60),
            new SqlParameter("@note", SqlDbType.VarChar, 60),
            new SqlParameter("@Man", SqlDbType.VarChar, 20),
            new SqlParameter("@Result", SqlDbType.VarChar, 20),
            new SqlParameter("@Url", SqlDbType.VarChar, 100)
        };
        para[0].Value = sid;
        para[1].Value = name;
        para[2].Value = note;
        para[3].Value = man;
        para[4].Value = result;
        para[5].Value = url;


        int ds = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_I_CRMCompanySampleSchedule", para);

        return ds;
    }

    #endregion

    #region 更新

    public int Update_CRMCompanySample(Guid sampleid, string cname, string ccode, string bdcode, Guid typeid,
        decimal num, string note, string maker, string appdep)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@sampleid", SqlDbType.UniqueIdentifier){Value = sampleid},
            new SqlParameter("@consumername", SqlDbType.VarChar, 60){Value = cname},
            new SqlParameter("@consumercode", SqlDbType.VarChar, 20){Value = ccode},
            new SqlParameter("@bdcode", SqlDbType.VarChar, 60){Value = bdcode},
            new SqlParameter("@typeid", SqlDbType.UniqueIdentifier){Value = typeid},
            new SqlParameter("@num", SqlDbType.Decimal){Value = num},
            new SqlParameter("@note", SqlDbType.VarChar, 400){Value = note},
            new SqlParameter("@maker", SqlDbType.VarChar, 20){Value = maker},
            new SqlParameter("@appdep", SqlDbType.VarChar, 20){Value = appdep},
        };
   
        
        int ds = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_U_CRMCompanySample", para);

        return ds;
    }

    public int Update_CRMCompanySampleAudit(Guid sampleid, string note, string result)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@sampleid", SqlDbType.UniqueIdentifier),
            new SqlParameter("@auditnote", SqlDbType.VarChar, 100),
            new SqlParameter("@result", SqlDbType.VarChar, 10)
        };
        para[0].Value = sampleid;
        para[1].Value = note;
        para[2].Value = result;
        int ds = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_U_CRMCompanySampleAudit", para);

        return ds;
    }

    public int Update_CRMCompanySampleSuperAudit(Guid sampleid, string note, string result)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@sampleid", SqlDbType.UniqueIdentifier),
            new SqlParameter("@superauditnote", SqlDbType.VarChar, 100),
            new SqlParameter("@result", SqlDbType.VarChar, 10)
        };
        para[0].Value = sampleid;
        para[1].Value = note;
        para[2].Value = result;
        int ds = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_U_CRMCompanySampleSuperAudit", para);

        return ds;
    }

    public int Update_CRMCompanySampleSchedule(Guid sid, string man)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@cssid", SqlDbType.UniqueIdentifier),
            new SqlParameter("@WorkOrderNum", SqlDbType.VarChar, 100),
            new SqlParameter("@ChipBatchNum", SqlDbType.VarChar, 100),
            new SqlParameter("@TestNum", SqlDbType.VarChar, 100),
            new SqlParameter("@InNum", SqlDbType.Decimal),
            new SqlParameter("@OutNum", SqlDbType.Decimal),
            new SqlParameter("@Man", SqlDbType.VarChar, 20),
            new SqlParameter("@ruku", SqlDbType.VarChar, 30)
        };
        para[0].Value = sid;


        int ds = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_U_CRMCompanySampleSchedule", para);

        return ds;
    }

    public DataSet Update_BOMDetail(Guid id, Guid pid, Guid uid, Guid mid, decimal use, decimal ruse, string note)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@id", SqlDbType.UniqueIdentifier),
            new SqlParameter("@pid", SqlDbType.UniqueIdentifier),
            new SqlParameter("@uid", SqlDbType.UniqueIdentifier),
            new SqlParameter("@mid", SqlDbType.UniqueIdentifier),
            new SqlParameter("@use", SqlDbType.Decimal),
            new SqlParameter("@ruse", SqlDbType.Decimal),
            new SqlParameter("@note", SqlDbType.VarChar, 30)
        };
        para[0].Value = id;
        para[1].Value = pid;
        para[2].Value = uid;
        para[3].Value = uid;
        para[4].Value = use;
        para[5].Value = ruse;
        para[6].Value = note;
        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_U_BOMDetail", para);

        return ds;
    }


    public int Update_CRMCompanySampleShiyong(Guid id,string op,string man)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@id", SqlDbType.UniqueIdentifier),
            new SqlParameter("@op", SqlDbType.VarChar, 400),
            new SqlParameter("@man", SqlDbType.VarChar, 20)
        };
        para[0].Value = id;
        para[1].Value = op;
        para[2].Value = man;
        int ds = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_I_CRMCompanySampleSchedule_Shiyong", para);

        return ds;
    }
    #endregion

    #region 删除

    public DataSet Delete_Sample(Guid id)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@sampleid", SqlDbType.UniqueIdentifier)
        };
        para[0].Value = id;

        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_D_CRMCompanySample", para);

        return ds;
    }

    public DataSet Delete_BOMDetail(Guid id)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@id", SqlDbType.UniqueIdentifier)
        };
        para[0].Value = id;


        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_D_BOMDetail", para);

        return ds;
    }

    #endregion
}