using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Collections;
using EquipmentMangementAjax.DBUtility;

/// <summary>
/// Class1 的摘要说明
/// </summary>
public class WMPD
{
    public WMPD()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
    #region 增加
    public int Insert_PWPDetail(Guid id, Guid mid, decimal num)
    {
        SqlParameter[] para = new SqlParameter[]{
                new SqlParameter("@id", SqlDbType.UniqueIdentifier),
                    new  SqlParameter("@mid", SqlDbType.UniqueIdentifier),
          new  SqlParameter("@num", SqlDbType.Decimal),    };
        para[0].Value = id;
        para[1].Value = mid;
        para[2].Value = num;


        return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_PWPDetail_M", para);



    }
    public Guid Insert_PWP(Guid swid, int year, int month, string man, string makedate, DateTime? startdate, DateTime? enddate, int linenum)
    {
        SqlParameter[] para = new SqlParameter[]{
            new  SqlParameter("@pwpid", SqlDbType.UniqueIdentifier),
                    new  SqlParameter("@swid", SqlDbType.UniqueIdentifier),
          new  SqlParameter("@year", SqlDbType.SmallInt),
         new   SqlParameter("@month", SqlDbType.TinyInt), 
        new   SqlParameter("@man", SqlDbType.VarChar,20),  
        new   SqlParameter("@makedate", SqlDbType.Date), 
        new   SqlParameter("@startdate", SqlDbType.Date), 
        new   SqlParameter("@enddate", SqlDbType.Date),
         new   SqlParameter("@linenum", SqlDbType.Int),
        };
        para[0].Direction = ParameterDirection.Output;
        para[1].Value = swid;
        para[2].Value = year;
        para[3].Value = month;
        para[4].Value = man;
        para[5].Value = makedate;
        para[6].Value = DBNull.Value;
        para[7].Value = DBNull.Value;
        para[8].Value = linenum;
        Guid returnid = SqlHelper.ExecuteReturnGuidQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_PWP_M", para);
        return returnid;





    }
    
    #endregion
    #region 查询
    public PWPAudit Query_Audit(Guid id)
    {
        SqlParameter[] para = new SqlParameter[]{
                new SqlParameter("@PWP_ID", SqlDbType.UniqueIdentifier),
                    new  SqlParameter("@PWP_MFDepSignSuggestion", SqlDbType.VarChar,400),
          new  SqlParameter("@PWP_MFDepSignMan", SqlDbType.VarChar,20),
         new   SqlParameter("@PWP_MFDepSignTime", SqlDbType.DateTime), 
        new   SqlParameter("@PWP_MFDepSignResult", SqlDbType.VarChar,20),  
        new   SqlParameter("@PWP_MBossSignSuggestion", SqlDbType.VarChar,400), 
        new SqlParameter("@PWP_MBossSignMan", SqlDbType.VarChar,20),
        new  SqlParameter("@PWP_MBossSignTime", SqlDbType.DateTime),
          new  SqlParameter("@PWP_MBossSignResult", SqlDbType.VarChar,20),
         new   SqlParameter("@PWP_MPDepSignSuggestion", SqlDbType.VarChar,400), 
        new   SqlParameter("@PWP_MPDepSignMan", SqlDbType.VarChar,20),  
        new   SqlParameter("@PWP_MPDepSignTime", SqlDbType.DateTime),
        new   SqlParameter("@PWP_MPDepSignResult", SqlDbType.VarChar,20),};
        para[0].Value = id;
        para[1].Direction = ParameterDirection.Output;
        para[2].Direction = ParameterDirection.Output;
        para[3].Direction = ParameterDirection.Output;
        para[4].Direction = ParameterDirection.Output;
        para[5].Direction = ParameterDirection.Output;
        para[6].Direction = ParameterDirection.Output;
        para[7].Direction = ParameterDirection.Output;
        para[8].Direction = ParameterDirection.Output;
        para[9].Direction = ParameterDirection.Output;
        para[10].Direction = ParameterDirection.Output;
        para[11].Direction = ParameterDirection.Output;
        para[12].Direction = ParameterDirection.Output;
        PWPAudit au = SqlHelper.ExecuteReturnPWPAuditQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_PWPAudit", para);
        return au;





    }



    public DataSet Query_WPlan(int year, int month, int week, string state, int linenum)
    {

        SqlParameter[] para = new SqlParameter[]{
                new SqlParameter("@year", SqlDbType.SmallInt),
                    new  SqlParameter("@month", SqlDbType.TinyInt),
                    new  SqlParameter("@week", SqlDbType.TinyInt),
          new  SqlParameter("@state", SqlDbType.VarChar, 30),
           new  SqlParameter("@linenum", SqlDbType.Int),
      };
        if (year == 999)
        {
            para[0].Value = null;
        }
        else
        {
            para[0].Value = year;
        }
        if (month == 999)
        {
            para[1].Value = null;
        }
        else
        {
            para[1].Value = month;
        }
        if (week == 999)
        {
            para[2].Value = null;
        }
        else
        {
            para[2].Value = week;
        }
        if (state == "null")
        {
            para[3].Value = null;

        }
        else
        {
            para[3].Value = state;
        }

        para[4].Value = linenum;


        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_PWP_M", para);

        return ds;


    }
    public DataSet Query_WPlan(int linenum)
    {

        SqlParameter[] para = new SqlParameter[]{
                   new SqlParameter("@year", SqlDbType.Int),
                    new  SqlParameter("@month", SqlDbType.Int),
                    new  SqlParameter("@week", SqlDbType.Int),
          new  SqlParameter("@state", SqlDbType.VarChar, 30),
          new  SqlParameter("@linenum", SqlDbType.Int),
      };
        para[0].Value = null;
        para[1].Value = null;
        para[2].Value = null;
        para[3].Value = null;
        para[4].Value = linenum;


        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_PWP_M", para);

        return ds;


    }
    public DataSet Query_Material(string name, string model)
    {

        SqlParameter[] para = new SqlParameter[]{
                new SqlParameter("@name", SqlDbType.VarChar,100),
          new  SqlParameter("@model", SqlDbType.VarChar,100),
      };
        para[0].Value = name;
        para[1].Value = model;



        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_PMPDetail_Mo", para);

        return ds;


    }


    public DataSet Query_WPlanDetail(Guid id)
    {

        SqlParameter[] para = new SqlParameter[]{
                new SqlParameter("@id", SqlDbType.UniqueIdentifier),
      };
        para[0].Value = id;



        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_PWPDetail_M", para);

        return ds;


    }
    public DataSet Query_WPlanDetailFlash(Guid id)
    {

        SqlParameter[] para = new SqlParameter[]{
                new SqlParameter("@id", SqlDbType.UniqueIdentifier),
      };
        para[0].Value = id;



        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_PWPDetail_M_Flash", para);

        return ds;


    }
    public DataSet Query_WPlanDetail(Guid id,DateTime dt)
    {

        SqlParameter[] para = {
                new SqlParameter("@id", SqlDbType.UniqueIdentifier){Value = id},
                new SqlParameter("@begindate", SqlDbType.Date){Value = dt}
      };
 



        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_PWPDetail_M", para);

        return ds;


    }
    public DataSet Query_WPlanDetail_Type(int year, int month, int week, Guid mid,Guid mwpid)
    {
        SqlParameter[] para = new SqlParameter[]{
                new SqlParameter("@year", SqlDbType.SmallInt),
                new SqlParameter("@month", SqlDbType.TinyInt),
                new SqlParameter("@week", SqlDbType.TinyInt),
                new SqlParameter("@mid", SqlDbType.UniqueIdentifier),
                new SqlParameter("@mwpid", SqlDbType.UniqueIdentifier),
      };
        para[0].Value = year;
        para[1].Value = month;
        para[2].Value = week;
        para[3].Value = mid;
        para[4].Value = mwpid;





        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_PWP_M_Type", para);

        return ds;
    }
    #endregion
    #region 更新
    public int Update_PWPAudit(Guid id, string man, DateTime time, string su, string res, string role)
    {
        SqlParameter[] para = new SqlParameter[]{
                new SqlParameter("@id", SqlDbType.UniqueIdentifier),
                    new  SqlParameter("@man", SqlDbType.VarChar, 20),
          new  SqlParameter("@time", SqlDbType.DateTime),
         new   SqlParameter("@su", SqlDbType.VarChar, 400),    
        new  SqlParameter("@res", SqlDbType.VarChar, 20),
         new   SqlParameter("@role", SqlDbType.VarChar, 20), };
        para[0].Value = id;
        para[1].Value = man;
        para[2].Value = time;
        para[3].Value = su;
        para[4].Value = res;
        para[5].Value = role;





        return SqlHelper.ExecuteNonQuery(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_PWPAudit", para);


    }
    public int UpdatePWPDetail(Guid pwpid, Guid mid, decimal num,string note)
    {
        SqlParameter[] para = new SqlParameter[]{
                new SqlParameter("@id", SqlDbType.UniqueIdentifier),
                    new  SqlParameter("@mid", SqlDbType.UniqueIdentifier),
          new  SqlParameter("@num", SqlDbType.Decimal),   
        new  SqlParameter("@note", SqlDbType.VarChar,400)   };
        para[0].Value = pwpid;
        para[1].Value = mid;
        para[2].Value = num;
        para[3].Value = note;


        return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_PWPDetail_M", para);
    }
    public int Update_MWP(Guid pwpid, DateTime startdate, DateTime enddate)
    {
        SqlParameter[] para = new SqlParameter[] 
            {
                new SqlParameter("@PWP_ID",SqlDbType.UniqueIdentifier),
                 new SqlParameter("@startdate",SqlDbType.Date),
                new SqlParameter("@enddate",SqlDbType.Date),    
  
             };

        para[0].Value = pwpid;
        para[1].Value = startdate;
        para[2].Value = enddate;
        int flag = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_PWP_State_M", para);
        return flag;
    }

    public int UpdatePlanState(Guid pwpid)
    {
        SqlParameter[] para = new SqlParameter[] 
            {
                new SqlParameter("@pwpid",SqlDbType.UniqueIdentifier),
   
  
             };

        para[0].Value = pwpid;

        int flag = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_PWPDetail_PlanState", para);
        return flag;
    }
    #endregion
 
  
   
    public int GetYear()
    {
        SqlParameter[] para = new SqlParameter[] 
            {
                new SqlParameter("@year",SqlDbType.Int),

    
  
             };

        para[0].Direction = ParameterDirection.Output;
        int flag = SqlHelper.ExecuteReturnQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_GetMYear", para);
        return flag;
    }







  
}