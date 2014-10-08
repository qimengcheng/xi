using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EquipmentMangementAjax.DBUtility;
using System.Data.SqlClient;
using System.Data;

/// <summary>
///SalaryAccountSetMaintananceD 的摘要说明
/// </summary>
namespace EquipmentMangementAjax.SQLServer
{
    public class SalaryAccountSetMaintananceD : ISalaryAccountSetMaintanancecs
    {
        public SalaryAccountSetMaintananceD()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        public int Insert_SalaryAccountSet(SalaryAccountSetMaintananceInfo ssm)
        {
            return (int)SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_SalaryAccountSet",
                new SqlParameter("@SAS_ASID", ssm.SAS_ASID), new SqlParameter("@SAS_ASName", ssm.SAS_ASName), new SqlParameter("@SAS_Type", ssm.SAS_Type),
                new SqlParameter("@SAS_IsDeleted", ssm.SAS_IsDeleted));
        }//新增账套，ssm是module的实例对象


        public int Update_SalaryAccountSet(SalaryAccountSetMaintananceInfo ssm)
        {
            return (int)SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Pro_U_SalaryAccountSet",
                new SqlParameter("@SAS_ASID", ssm.SAS_ASID), new SqlParameter("@SAS_ASName", ssm.SAS_ASName),new SqlParameter("@SAS_Type", ssm.SAS_Type));

        }//编辑账套，ssm是module的实例对象

        public int Delete_SalaryAccountSet(Guid ID)
        {
            return (int)SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Pro_D_SalaryAccountSet",
                new SqlParameter("@SAS_ASID", ID));
        }//对工资账套进行假删除

        public DataSet Search_SalaryAccountSet(string Condition)
        {
            return (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Pro_S_SalaryAccountSet", new SqlParameter("@condition", Condition));
        }//查询工资账套

        public int Delete_SalaryAccountSet_HRDDetail(Guid ID)
        {
            return (int)SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_SalaryAccountSet_HRDDetail",
                new SqlParameter("@HRDD_ID", ID));
        }//对工资账套中的员工进行假删除

        public int Insert_SalaryAccountSet_HRDDetail(Guid HRDD_ID, Guid SAS_ASID)
        {
            return (int)SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_SalaryAccountSet_HRDDetail",
                new SqlParameter("@HRDD_ID", HRDD_ID), new SqlParameter("@SAS_ASID", SAS_ASID));
        }//新增工资账套中的员工

        public int Insert_SalaryItemTable(SalaryAccountSetMaintananceInfo ssm)
        {
            return (int)SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_SalaryItemTable",
                new SqlParameter("@SAS_ASID", ssm.SAS_ASID), new SqlParameter("@SIT_ItemID", ssm.SIT_ItemID),
                new SqlParameter("@SIT_Items", ssm.SIT_Items), new SqlParameter("@SIT_InitialValue", ssm.SIT_InitialValue),
                new SqlParameter("@SIT_Formula", ssm.SIT_Formula), new SqlParameter("@SIT_IsDeleted", ssm.SIT_IsDeleted));
        }//新增工资项目，ssm是module的实例对象

        public void Update_YanZhengGongShi(Guid guid,string str)
        {
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_YanZhengGongShi",
                new SqlParameter("@SAS_ASID", guid), new SqlParameter("@SIT_Formula", str));
        }//薪资管理，薪资账套维护，维护工资项目，校验公式的格式

        public DataSet Search_SalaryItemTable(string Condition)
        {
            return (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_S_SalaryItemTable", new SqlParameter("@condition", Condition));
        }//检索某个账套下的工资项目

        public IList<SalaryAccountSetMaintananceInfo> SearchByID_SalaryItemTable(Guid SIT_ItemID)
        {
            SqlParameter para = new SqlParameter("@SIT_ItemID", SIT_ItemID);
            IList<SalaryAccountSetMaintananceInfo> sASMI = new List<SalaryAccountSetMaintananceInfo>();
            SqlDataReader sdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_SByID_SalaryItemTable", para);
            while (sdr.Read())
            {
                sASMI.Add(new SalaryAccountSetMaintananceInfo(sdr["SIT_Items"] == DBNull.Value ? "" : sdr["SIT_Items"].ToString(),
                   sdr["SIT_InitialValue"] == DBNull.Value ? 0 : (decimal)sdr["SIT_InitialValue"],
                   sdr["SIT_Formula"] == DBNull.Value ? "" : sdr["SIT_Formula"].ToString()));

            }
            return sASMI;
        }//根据ID检索某个账套下的工资项目,用于取出数据进行编辑

        public DataSet Search_FromOtherSet_SalaryItemTable(Guid SAS_ASID)
        {
            return (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_S_FromOtherSet_SalaryItemTable", new SqlParameter("@SAS_ASID", SAS_ASID));
        }//用于选择其他账套中已有的工资项目

        public int Update_SalaryItemTable(SalaryAccountSetMaintananceInfo ssm)
        {
            return (int)SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_SalaryItemTable",
                new SqlParameter("@SAS_ASID", ssm.SAS_ASID), new SqlParameter("@SIT_ItemID", ssm.SIT_ItemID),
                new SqlParameter("@SIT_Items", ssm.SIT_Items), new SqlParameter("@SIT_InitialValue", ssm.SIT_InitialValue),
                new SqlParameter("@SIT_Formula", ssm.SIT_Formula));

        }//编辑某个账套下的工资项目，ssm是module的实例对象

        public int Delete_SalaryItemTable(Guid SIT_ItemID)
        {
            return (int)SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_SalaryItemTable",
                new SqlParameter("@SIT_ItemID", SIT_ItemID));
        }//删除某个账套下的工资项目

        public DataSet Search_AllSalaryItems_SalaryItemTable(string condition)
        {
            return (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_S_AllSalaryItems_SalaryItemTable", new SqlParameter("@conditon", condition));
        }//检索所有账套下全部的工资项目（不重复）

        public DataSet Search_AllSalaryItems_SalaryItemTable(Guid g1,Guid g2)
        {
            return (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_S_ExceptOne_SalaryItemTable", new SqlParameter("@SIT_ItemID", g1), new SqlParameter("@SAS_ASID", g2));
        }//检索该账套下其他全部的工资项目(除去正在编辑的项目)
    }
}