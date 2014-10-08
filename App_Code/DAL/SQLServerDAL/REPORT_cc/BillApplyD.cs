using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using EquipmentMangementAjax.DBUtility;

/// <summary>
/// BillApplyD 的摘要说明
/// </summary>
public class BillApplyD
{
    public DataSet SelectBillApply(string condition)
    {
        SqlParameter para = new SqlParameter("@Condition", condition);
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_BillApply", para);
    }
    public DataSet SelectBillApply_Biaoji(string condition)
    {
        SqlParameter para = new SqlParameter("@Condition", condition);
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_BillApply_Biaoji", para);
    }
    public void UpdateBillApply(Guid SMOD_ID)
    {
       SqlParameter para = new SqlParameter("@SMOD_ID", SMOD_ID);
       SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_BillApply", para);
    }
    public void UpdateBillApply_Delete(Guid SMOD_ID)
    {
        SqlParameter para = new SqlParameter("@SMOD_ID", SMOD_ID);
        SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_BillApply_Delete", para);
    }
    public DataSet SelectPersonnelTransferEachMonthC(int year, int month)
    {
        SqlParameter[] parm = new SqlParameter[2];

        parm[0] = new SqlParameter("@year", SqlDbType.SmallInt);
        parm[0].Value = year;
        parm[1] = new SqlParameter("@month", SqlDbType.TinyInt);
        parm[1].Value = month;

        return SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
                   CommandType.StoredProcedure, "Proc_S_PersonnelTransferEachMonth", parm);
    }
    public DataSet SelectMidLeaderPerform(int year)
    {
        SqlParameter[] parm = new SqlParameter[1];

        parm[0] = new SqlParameter("@year", SqlDbType.SmallInt);
        parm[0].Value = year;
        

        return SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
                   CommandType.StoredProcedure, "Proc_S_MidLeaderPerform", parm);
    }
    public DataSet SelectWIP_BadPro_Series(string date1,string date2,string sj,string sx)
    {
        SqlParameter[] parm = new SqlParameter[4];

        parm[0] = new SqlParameter("@date1", SqlDbType.VarChar,100);
        parm[0].Value = date1;
        parm[1] = new SqlParameter("@date2", SqlDbType.VarChar, 100);
        parm[1].Value = date2;
        parm[2] = new SqlParameter("@sj", SqlDbType.VarChar, 100);
        parm[2].Value = sj;
        parm[3] = new SqlParameter("@sx", SqlDbType.VarChar, 100);
        parm[3].Value = sx;

        return SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
                   CommandType.StoredProcedure, "Report_Proc_S_WIP_BadPro_Series", parm);
    }

    public DataSet SelectZZPPC_CWB(string condition)
    {
        SqlParameter para = new SqlParameter("@condition", condition);
     return  SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Report_Proc_S_ZZPPC_CWB", para);
    }

    public void InsertTakeInventory(string TI_Man, string TI_ReMark)
    {
        SqlParameter[] parm = new SqlParameter[2];

        parm[0] = new SqlParameter("@TI_Man", SqlDbType.VarChar, 60);
        parm[0].Value = TI_Man;
        parm[1] = new SqlParameter("@TI_ReMark", SqlDbType.VarChar, 1000);
        parm[1].Value = TI_ReMark;
       
      SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
                   CommandType.StoredProcedure, "Proc_I_TakeInventory ", parm);
    }

    public void InsertTakeInventoryDetail(Guid TI_ID, string TID_StyleName, string TID_ProName, int TID_Num, string TID_WO_Num)
    {
        SqlParameter[] parm = new SqlParameter[5];

        parm[0] = new SqlParameter("@TI_ID", SqlDbType.UniqueIdentifier);
        parm[0].Value = TI_ID;
        parm[1] = new SqlParameter("@TID_StyleName", SqlDbType.VarChar,60);
        parm[1].Value = TID_StyleName;
        parm[2] = new SqlParameter("@TID_ProName", SqlDbType.VarChar, 60);
        parm[2].Value = TID_ProName;
        parm[3] = new SqlParameter("@TID_Num", SqlDbType.Int);
        parm[3].Value = TID_Num;
        parm[4] = new SqlParameter("@TID_WO_Num", SqlDbType.VarChar,8000);
        parm[4].Value = TID_WO_Num;
        SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
                   CommandType.StoredProcedure, "Proc_I_TakeInventoryDetail", parm);
    }

    public void DeleteTakeInventory(Guid TI_ID)
    {
        SqlParameter[] parm = new SqlParameter[1];

        parm[0] = new SqlParameter("@TI_ID", SqlDbType.UniqueIdentifier);
        parm[0].Value = TI_ID;
      
        SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
                     CommandType.StoredProcedure, "Proc_D_TakeInventory ", parm);
    }

    public DataSet SelectTakeInventory(string condition)
    {
        SqlParameter[] parm = new SqlParameter[1];

        parm[0] = new SqlParameter("@condition", SqlDbType.NVarChar,1000);
        parm[0].Value = condition;

     return   SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
                     CommandType.StoredProcedure, "Proc_S_TakeInventory ", parm);
    }
    public DataSet SelectTakeInventoryDetail(string condition)
    {
        SqlParameter[] parm = new SqlParameter[1];

        parm[0] = new SqlParameter("@condition", SqlDbType.NVarChar, 1000);
        parm[0].Value = condition;

        return SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
                        CommandType.StoredProcedure, "Proc_S_TakeInventoryDetail ", parm);
    }
    public void UpdateTakeInventory(Guid TI_ID,string TI_ReMark)
    {
        SqlParameter[] parm = new SqlParameter[2];

        parm[0] = new SqlParameter("@TI_ID", SqlDbType.UniqueIdentifier);
        parm[0].Value =TI_ID;
        parm[1] = new SqlParameter("@TI_ReMark", SqlDbType.VarChar,1000);
        parm[1].Value = TI_ReMark;
        SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
                        CommandType.StoredProcedure, "Proc_U_TakeInventory ", parm);
    }
}