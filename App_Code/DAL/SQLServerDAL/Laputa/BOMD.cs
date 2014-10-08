using System;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using EquipmentMangementAjax.DBUtility;

/// <summary>
/// BOM 的摘要说明
/// </summary>
public class BOM
{
    public BOM()
    {
        //
        // TODO: 在此处添加构造函数逻辑@name varchar(60)=null,
        //
    }
    #region 查询
    public DataSet Query_ControlledDocApp(string name, string appnum, string num, string editionnum, DateTime stime, DateTime etime, string type, string ctype, string state, string people,int latest)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@name", SqlDbType.VarChar,60),
            new SqlParameter("@appnum", SqlDbType.VarChar,20),
            new SqlParameter("@num", SqlDbType.VarChar,50),
            new  SqlParameter("@editionnum", SqlDbType.VarChar,8),
            new   SqlParameter("@stime", SqlDbType.DateTime), 
            new   SqlParameter("@etime", SqlDbType.DateTime), 
            new  SqlParameter("@type", SqlDbType.VarChar,20),
            new   SqlParameter("@ctype", SqlDbType.VarChar,20), 
            new   SqlParameter("@state", SqlDbType.VarChar,20),  
            new   SqlParameter("@people", SqlDbType.VarChar,20),
            new   SqlParameter("@latest", SqlDbType.Int)
        };

        para[0].Value = name;
        para[1].Value = appnum;
        para[2].Value = num;
        para[3].Value = editionnum;
        para[4].Value = stime;
        para[5].Value = etime;
        para[6].Value = type;
        para[7].Value = ctype;
        para[8].Value = state;
        para[9].Value = people;
        para[10].Value = latest;
        foreach (SqlParameter i in para.Where(i => i.Value.ToString() == ""))
        {
            i.Value = null;
        }
        para[7].Value = ctype != "所有类型" ? ctype : null;
       
       
        

        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_ControlledDocApp", para);
        return ds;
    }
    public DataSet Query_ControlledDocApp()
    {
        SqlParameter[] para =
        {
            new SqlParameter("@name", SqlDbType.VarChar,60),
            new SqlParameter("@appnum", SqlDbType.VarChar,20),
            new SqlParameter("@num", SqlDbType.VarChar,50),
            new  SqlParameter("@editionnum", SqlDbType.VarChar,8),
            new   SqlParameter("@stime", SqlDbType.DateTime), 
            new   SqlParameter("@etime", SqlDbType.DateTime), 
            new  SqlParameter("@type", SqlDbType.VarChar,20),
            new   SqlParameter("@ctype", SqlDbType.VarChar,20), 
            new   SqlParameter("@state", SqlDbType.VarChar,20),  
            new   SqlParameter("@people", SqlDbType.VarChar,20)
        };
        para[0].Value = null;
        para[1].Value = null;
        para[2].Value = null;
        para[3].Value = null;
        para[4].Value = null;
        para[5].Value = null;
        para[6].Value = null;
        para[7].Value = null;
        para[8].Value = null;

        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_ControlledDocApp", para);
        return ds;
    }

    public DataSet Query_BOM(Guid id)
    {

        SqlParameter[] para =
        {
            new SqlParameter("@id", SqlDbType.UniqueIdentifier)
        };
        para[0].Value = id;



        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_BOM", para);

        return ds;


    }
    public DataSet Query_BOMDetail(Guid id)
    {

        SqlParameter[] para =
        {
            new SqlParameter("@id", SqlDbType.UniqueIdentifier)
        };
        para[0].Value = id;



        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_BOMDetail", para);

        return ds;


    }
    public DataSet Query_BOMDetailHistory(Guid id)
    {

        SqlParameter[] para =
        {
            new SqlParameter("@id", SqlDbType.UniqueIdentifier)
        };
        para[0].Value = id;



        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_BOMDetailHistory", para);

        return ds;


    }
    public DataSet Query_PBC(string name)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@name", SqlDbType.VarChar,30)
        };
        para[0].Value = name;
        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_PBCraftInfoByName", para);
        return ds;
    }
    public Guid Query_PBCID(string name)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@craid", SqlDbType.UniqueIdentifier),
            new SqlParameter("@name", SqlDbType.VarChar,30)
        };
        para[0].Direction= ParameterDirection.Output;
        para[1].Value = name;
        Guid ds = SqlHelper.ExecuteReturnGuidQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_PBCraftInfoByNameV2", para);
        return ds;
    }
    public DefaultUnit Query_DefaultUnitID(Guid mid)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@default", SqlDbType.UniqueIdentifier),
            new SqlParameter("@name", SqlDbType.VarChar,20),
            new SqlParameter("@mid", SqlDbType.UniqueIdentifier)
        };
        para[0].Direction = ParameterDirection.Output;
        para[1].Direction = ParameterDirection.Output;
        para[2].Value = mid;

        DefaultUnit ds = SqlHelper.ExecuteReturnGuidandNameQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_DefaultUnitID", para);
        return ds;
    }
    public DataSet Query_Unit(string name)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@name", SqlDbType.VarChar,20)
        };
        para[0].Value = name;
        
        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_Unit",para);
        return ds;
    }
    public SqlDataReader Query_MUnit(Guid mid)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@mid", SqlDbType.UniqueIdentifier)
        };
        para[0].Value = mid;
        SqlDataReader ds = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_MUnit", para);
        return ds;
    }
    public DataSet Query_Material(string name, string model)
    {

        SqlParameter[] para =
        {
            new SqlParameter("@name", SqlDbType.VarChar,100),
            new  SqlParameter("@model", SqlDbType.VarChar,100)
        };
        para[0].Value = name;
        para[1].Value = model;



        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_PMPDetail_Mo", para);

        return ds;


    }
    public DataSet SeachBom(string bomname)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@bomname", SqlDbType.VarChar,60)
        };
        para[0].Value = bomname;

        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_BOMByName", para);

        return ds;

    }
    #endregion
    #region 增加
     public int Insert_BOM(Guid id,string name,string special,string people)
    {

        SqlParameter[] para =
        {
            new SqlParameter("@id", SqlDbType.UniqueIdentifier),
            new SqlParameter("@name", SqlDbType.VarChar,60),
            new SqlParameter("@special", SqlDbType.Char,2),
            new SqlParameter("@people", SqlDbType.VarChar,10)
        };
        para[0].Value = id;
        para[1].Value = name;
        para[2].Value = special;
        para[3].Value = people;



        int ds = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_BOM", para);

        return ds;


    }
     public int Insert_BOMDetail(Guid id, Guid pid, Guid uid, Guid mid, decimal use, decimal ruse, string note,string man)
     {

         SqlParameter[] para =  
        {
            new SqlParameter("@id", SqlDbType.UniqueIdentifier),
            new SqlParameter("@pid", SqlDbType.UniqueIdentifier),
            new SqlParameter("@uid", SqlDbType.UniqueIdentifier),
            new SqlParameter("@mid", SqlDbType.UniqueIdentifier),
            new SqlParameter("@use", SqlDbType.Decimal),
            new SqlParameter("@ruse", SqlDbType.Decimal), 
            new SqlParameter("@note", SqlDbType.VarChar,30),
             new SqlParameter("@man", SqlDbType.VarChar,20), 
      

        };
         para[0].Value = id;
         para[1].Value = pid;
         para[2].Value = uid;
         para[3].Value = mid;
         para[4].Value = use;
         para[5].Value = ruse;
         para[6].Value = note;
         para[7].Value = man;



         int ds = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_BOMDetail", para);

         return ds;


     }
     public int Insert_BOMDetailMate(Guid id, Guid mateid, Guid pid, Guid uid, Guid mid, decimal use, decimal ruse, string note, string fuse, Guid fuseGuid,string man)
     {

         SqlParameter[] para =
        {
            new SqlParameter("@id", SqlDbType.UniqueIdentifier),
            new SqlParameter("@mateid", SqlDbType.UniqueIdentifier),
             new SqlParameter("@pid", SqlDbType.UniqueIdentifier),
            new SqlParameter("@uid", SqlDbType.UniqueIdentifier),
            new SqlParameter("@mid", SqlDbType.UniqueIdentifier),
            new SqlParameter("@use", SqlDbType.Decimal),
            new SqlParameter("@ruse", SqlDbType.Decimal), 
            new SqlParameter("@note", SqlDbType.VarChar,30),
             new SqlParameter("@fuse", SqlDbType.Char,2),
             new SqlParameter("@fuseid", SqlDbType.UniqueIdentifier),
             new SqlParameter("@man", SqlDbType.VarChar,20),
        };
         para[0].Value = id;
         para[1].Value = mateid; 
         para[2].Value = pid;
         para[3].Value = uid;
         para[4].Value = mid;
         para[5].Value = use;
         para[6].Value = ruse;
         para[7].Value = note;
         para[8].Value = fuse;
         if (fuseGuid!=Guid.Empty)
         {
             para[9].Value = fuseGuid;
         }
         para[10].Value = man;


         int ds = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_BOMDetailMate", para);

         return ds;


     }
     public int Insert_IMUnitChange(Guid mid, Guid uid, decimal rate)
    {

        SqlParameter[] para =
        {
            new SqlParameter("@mid", SqlDbType.UniqueIdentifier),
            new SqlParameter("@uid", SqlDbType.UniqueIdentifier),
            new SqlParameter("@rate", SqlDbType.Decimal)
        };
        para[0].Value = mid;
        para[1].Value = uid;
        para[2].Value = rate;





        int ds = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_IMUnitChange_BOM", para);

        return ds;


    }
    #endregion
    #region 更新

    public int Update_BOM(Guid id, string name, string special, string people)
    {

        SqlParameter[] para =
        {
            new SqlParameter("@id", SqlDbType.UniqueIdentifier),
            new SqlParameter("@name", SqlDbType.VarChar,60),
            new SqlParameter("@special", SqlDbType.Char,2),
            new SqlParameter("@people", SqlDbType.VarChar,10)
        };
        para[0].Value = id;
        para[1].Value = name;
        para[2].Value = special;
        para[3].Value = people;



        int ds = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_BOM", para);

        return ds;


    }   
    public int Update_BOMDetail(Guid id, Guid pid, Guid uid, Guid mid, decimal use, decimal ruse, string note,string man)
    {

        SqlParameter[] para =
        {
            new SqlParameter("@id", SqlDbType.UniqueIdentifier),
            new SqlParameter("@pid", SqlDbType.UniqueIdentifier),
            new SqlParameter("@uid", SqlDbType.UniqueIdentifier),
            new SqlParameter("@mid", SqlDbType.UniqueIdentifier),
            new SqlParameter("@use", SqlDbType.Decimal),
            new SqlParameter("@ruse", SqlDbType.Decimal), 
            new SqlParameter("@note", SqlDbType.VarChar,30),
              new SqlParameter("@man", SqlDbType.VarChar,20),
        };
        para[0].Value = id;
        para[1].Value = pid;
        para[2].Value = uid;
        para[3].Value = mid;
        para[4].Value = use;
        para[5].Value = ruse;
        para[6].Value = note;
        para[7].Value = man;
        int ds = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_BOMDetail", para);

        return ds;


    }
    public int Update_UnitChange(Guid ucid,decimal num)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@ucid", SqlDbType.UniqueIdentifier),
            new SqlParameter("@num", SqlDbType.Decimal),
          
        };
        para[0].Value = ucid;
        para[1].Value = num;

        int ds = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_IMUnitChange", para);

        return ds;
    }
    #endregion
    #region 删除
    public DataSet Delete_BOM(Guid id)
    {

        SqlParameter[] para =
        {
            new SqlParameter("@id", SqlDbType.UniqueIdentifier)
        };
        para[0].Value = id;

        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_BOM", para);

        return ds;


    }
    public DataSet Delete_BOMDetail(Guid id)
    {

        SqlParameter[] para =
        {
            new SqlParameter("@id", SqlDbType.UniqueIdentifier)
        };
        para[0].Value = id;




        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_BOMDetail", para);

        return ds;


    }
    #endregion

    public int Copybom(Guid id, Guid fromid,string man)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@id", SqlDbType.UniqueIdentifier),
            new SqlParameter("@fromid", SqlDbType.UniqueIdentifier),
              new SqlParameter("@man", SqlDbType.VarChar,20),
        };
        para[0].Value = id;
        para[1].Value = fromid;
        para[2].Value = man;
        int re = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_BOMDetail_Copy", para);
        return re;
    }

    public int Update_BOMDetailPercent(Guid bdid, decimal percent,string man)
    {

        SqlParameter[] para =
        {
            new SqlParameter("@bdid", SqlDbType.UniqueIdentifier),
            new SqlParameter("@percent", SqlDbType.Decimal),
        };
        para[0].Value = bdid;
        para[1].Value = percent;
        para[2].Value = man;




        int ds = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_U_BOMDetailPercent", para);
        return ds;
    }
        
    public DataSet   Query_MatePercent(Guid bdid)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@id", SqlDbType.UniqueIdentifier)
        };
        para[0].Value = bdid;

        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_BOMDetailMate", para);

        return ds;
    }   

    public DataSet Query_MAllUnit(Guid mid)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@mid", SqlDbType.UniqueIdentifier)
        };
        para[0].Value = mid;

        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_IMUnitChange", para);

        return ds;
    }

  
}