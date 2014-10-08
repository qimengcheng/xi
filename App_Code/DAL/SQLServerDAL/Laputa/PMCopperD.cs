using System;
using System.Data;
using System.Data.SqlClient;
using EquipmentMangementAjax.DBUtility;

/// <summary>
/// PMCopperD 的摘要说明
/// </summary>
public class PMCopperD
{
    #region 查询

    public DataSet Query_Provider(string code, string name)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@code", SqlDbType.VarChar, 10),
            new SqlParameter("@name", SqlDbType.VarChar, 100),
        };
        para[0].Value = code == "" ? null : code;
        para[1].Value = name == "" ? null : name;
        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_PMProvider", para);
        return ds;
    }
    public DataSet Query_CopperReturn(Guid CopperID)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@PMCF_ID", SqlDbType.UniqueIdentifier),
         };
        para[0].Value = CopperID;
      
        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_PMCopperReturn", para);
        return ds;
    }
    public DataSet Query_CopperNG(Guid CopperID)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@PMCF_ID", SqlDbType.UniqueIdentifier),
         };
        para[0].Value = CopperID;

        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_PMCopperNG", para);
        return ds;
    }
    public DataSet Query_Copper(string name,string supplier,string code, DateTime stime,DateTime etime)
    {
        SqlParameter[] para =
        {
             new SqlParameter("@name", SqlDbType.VarChar, 200),
             new SqlParameter("@supplier", SqlDbType.VarChar, 100),
            new SqlParameter("@code", SqlDbType.VarChar, 10),
            new SqlParameter("@stime", SqlDbType.DateTime),
            new SqlParameter("@etime", SqlDbType.DateTime),

           
        };
        para[0].Value = code == "" ? code : null;
        para[1].Value = name == "" ? name : null;
        para[2].Value = supplier;
        para[3].Value = stime;
        para[4].Value = etime;
        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_PMCopper", para);
        return ds;
    }
    public DataSet Query_Copper()
    {
        SqlParameter[] para =
        {
             new SqlParameter("@name", SqlDbType.VarChar, 200),
             new SqlParameter("@supplier", SqlDbType.VarChar, 100),
            new SqlParameter("@code", SqlDbType.VarChar, 10),
            new SqlParameter("@stime", SqlDbType.DateTime),
            new SqlParameter("@etime", SqlDbType.DateTime),

           
        };
        para[0].Value = null;
        para[1].Value = null;
        para[2].Value = null;
        para[3].Value = Convert.ToDateTime("1/1/1753 12:00:00 AM");
        para[4].Value = Convert.ToDateTime("12/31/9999 11:59:59 PM");
        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_PMCopper", para);
        return ds;
       
    }
    public DataSet Query_Type(string type)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@type", SqlDbType.VarChar,20),
         }; 
        para[0].Value = type ;

        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_PMCopperMaterial", para);
        return ds;
    }

    #endregion
    #region 插入  
    public int Insert_PMCopper(Guid midGuid ,decimal amount, Guid pid,string batchnum,DateTime dateTime,decimal rate)  
    {

        SqlParameter[] para =
        {   
            new SqlParameter("@pid", SqlDbType.UniqueIdentifier),
                   new SqlParameter("@amount", SqlDbType.Decimal),
                   new SqlParameter("@mid", SqlDbType.UniqueIdentifier),
                   new SqlParameter("@batchnum", SqlDbType.VarChar, 20),
                   new SqlParameter("@date", SqlDbType.DateTime),
                   new SqlParameter("@rate", SqlDbType.Decimal),
        
        };
        para[0].Value = pid; 
        para[1].Value = amount;
        para[2].Value = midGuid;
        para[3].Value = batchnum;
        para[4].Value = dateTime;
        para[5].Value = rate;


        int ds = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_I_PMCopper", para);

        return ds;


    }

    #endregion

    #region 更新

    public int Update_BD(string code, string name, Int16 level, string father)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@name", SqlDbType.VarChar, 100),
            new SqlParameter("@level", SqlDbType.TinyInt),
            new SqlParameter("@father", SqlDbType.VarChar, 60),
            new SqlParameter("@code", SqlDbType.VarChar, 60)
        };
        para[0].Value = name;
        para[1].Value = level;
        para[2].Value = father;
        para[3].Value = code;



        int ds = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_U_BDOrganizationSheetMain", para);

        return ds;
    }
    public int Update_PMCopper(Guid copperid,Guid midGuid, decimal amount, Guid pid, string batchnum, DateTime dateTime, decimal rate)
    {

        SqlParameter[] para =   
        {    new SqlParameter("@copperid", SqlDbType.UniqueIdentifier),
            new SqlParameter("@pid", SqlDbType.UniqueIdentifier),
                   new SqlParameter("@amount", SqlDbType.Decimal),
                   new SqlParameter("@mid", SqlDbType.UniqueIdentifier),
                   new SqlParameter("@batchnum", SqlDbType.VarChar, 20),
                   new SqlParameter("@date", SqlDbType.DateTime),
                   new SqlParameter("@rate", SqlDbType.Decimal),
        
        };
        para[0].Value = copperid;
        para[1].Value = pid;
        para[2].Value = amount;
        para[3].Value = midGuid;
        para[4].Value = batchnum;
        para[5].Value = dateTime;
        para[6].Value = rate;


        int ds = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_U_PMCopper", para);

        return ds;


    }
    #endregion

    public int Insert_CopperReturn(decimal renum, Guid copperid,Guid pid, string note,string man,DateTime backDateTime)
    {
        SqlParameter[] para =
        {   
            
                   new SqlParameter("@renum", SqlDbType.Decimal),
                   new SqlParameter("@copperid", SqlDbType.UniqueIdentifier),
                   new SqlParameter("@pid", SqlDbType.UniqueIdentifier),
                  new SqlParameter("@note", SqlDbType.VarChar, 400),
                  new SqlParameter("@man", SqlDbType.VarChar, 20),
                   new SqlParameter("@date", SqlDbType.DateTime),
        };
        para[0].Value =renum;
        para[1].Value = copperid;
        para[2].Value = pid;
        para[3].Value = note;
        para[4].Value = man;
        para[5].Value = backDateTime;


        int ds = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_I_PMCopperReturn", para);

        return ds;
    }

    public int Insert_CopperNG(decimal renum, Guid copperid, Guid pid, string note, string man, DateTime backDateTime)
    {   
        SqlParameter[] para =
        {   
            
                   new SqlParameter("@ngnum", SqlDbType.Decimal),
                   new SqlParameter("@copperid", SqlDbType.UniqueIdentifier),
                   new SqlParameter("@pid", SqlDbType.UniqueIdentifier),
                  new SqlParameter("@note", SqlDbType.VarChar, 400),
                  new SqlParameter("@man", SqlDbType.VarChar, 20),
                     new SqlParameter("@date", SqlDbType.DateTime),
        };
        para[0].Value = renum;
        para[1].Value = copperid;
        para[2].Value = pid;
        para[3].Value = note;
        para[4].Value = man;
        para[5].Value = backDateTime;
        int ds = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
           "Proc_I_PMCopperNG", para);

        return ds;
    }

    #region 铜材入库    

    public void Update_InStoreDetail(Guid MainID, string BatchName, string level, decimal shouldarr, decimal actualarr,
        decimal perweight, decimal totalweight, Guid area,Guid copperid)
    {
        SqlParameter[] para = new SqlParameter[8];
        para[0] = new SqlParameter("@IMISD_ID", SqlDbType.UniqueIdentifier);
        para[0].Value = MainID;
        para[1] = new SqlParameter("@IMISD_BatchNum", SqlDbType.VarChar, 100);
        para[1].Value = BatchName;
        para[2] = new SqlParameter("@IMIDS_Level", SqlDbType.VarChar, 100);
        para[2].Value = level;
        para[3] = new SqlParameter("@IMISD_ShouldArrNum", SqlDbType.Decimal, 18);
        para[3].Value = shouldarr;
        para[4] = new SqlParameter("@IMIDS_ActualArrNum", SqlDbType.Decimal, 18);
        para[4].Value = actualarr;
        para[5] = new SqlParameter("@IMIDS_PerWeight", SqlDbType.Decimal, 18);
        para[5].Value = perweight;
        para[6] = new SqlParameter("@IMIDS_TotalWeight", SqlDbType.Decimal, 18);
        para[6].Value = totalweight;
        para[7] = new SqlParameter("@IMSA_AreaID", SqlDbType.UniqueIdentifier);
        para[7].Value = area;
        para[7] = new SqlParameter("@copperid", SqlDbType.UniqueIdentifier);
        para[7].Value = area;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_U_IMInStoreDetailCopper", para);
    }

    //新建入库详细表
    public void Insert_InStoreDetail(Guid MainID, Guid copperid, Guid ID, string BatchName, string level, decimal shouldarr,
        decimal actualarr, decimal perweight, decimal totalweight, Guid area)
    {
        SqlParameter[] para = new SqlParameter[10];
        para[0] = new SqlParameter("@IMISM_ID", SqlDbType.UniqueIdentifier);
        para[0].Value = MainID;
        para[1] = new SqlParameter("@copperid", SqlDbType.UniqueIdentifier);
        para[1].Value = copperid;
        para[2] = new SqlParameter("@ID", SqlDbType.UniqueIdentifier);
        para[2].Value = ID;
        para[4] = new SqlParameter("@IMIDS_Level", SqlDbType.VarChar, 100);
        para[4].Value = level;
        para[3] = new SqlParameter("@IMISD_BatchNum", SqlDbType.VarChar, 100);
        para[3].Value = BatchName;
        para[5] = new SqlParameter("@IMISD_ShouldArrNum", SqlDbType.Decimal, 18);
        para[5].Value = shouldarr;
        para[6] = new SqlParameter("@IMIDS_ActualArrNum", SqlDbType.Decimal, 18);
        para[6].Value = actualarr;
        para[7] = new SqlParameter("@IMIDS_PerWeight", SqlDbType.Decimal, 18);
        para[7].Value = perweight;
        para[8] = new SqlParameter("@IMIDS_TotalWeight", SqlDbType.Decimal, 18);
        para[8].Value = totalweight;
        para[9] = new SqlParameter("@IMSA_AreaID", SqlDbType.UniqueIdentifier);
        para[9].Value = area;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_I_IMInStoreDetailCopper", para);
    }

    #endregion

    public DataSet Query_CopperOEM(Guid CopperID)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@copperid", SqlDbType.UniqueIdentifier),
         };
        para[0].Value = CopperID;

        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_PMCopperOEM", para);
        return ds;
    }
}

