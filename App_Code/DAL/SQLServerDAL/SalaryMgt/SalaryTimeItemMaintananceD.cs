using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EquipmentMangementAjax.DBUtility;
using System.Data.SqlClient;
using System.Data;

/// <summary>
///SalaryTimeItemMaintananceD 的摘要说明
/// </summary>
namespace EquipmentMangementAjax.SQLServer
{
    public class SalaryTimeItemMaintananceD : ISalaryTimeItemMaintanance
    {
        public SalaryTimeItemMaintananceD()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        public int Insert_SalaryTimeItem(SalaryTimeItemMaintananceInfo sTIMI)
        {
            return (int)SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_SalaryTimeItem",
                new SqlParameter("@STI_ID", sTIMI.STI_ID), new SqlParameter("@PBC_ID", sTIMI.PBC_ID),
                new SqlParameter("@STI_Name", sTIMI.STI_Name), new SqlParameter("@STI_UnitPrice", sTIMI.STI_UnitPrice),
                new SqlParameter("@STI_IsDeleted", sTIMI.STI_IsDeleted));
        }//新增计时项目

        public int Update_SalaryTimeItem(SalaryTimeItemMaintananceInfo sTIMI)
        {
            return (int)SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_SalaryTimeItem",
                new SqlParameter("@STI_ID", sTIMI.STI_ID), new SqlParameter("@PBC_ID", sTIMI.PBC_ID),
                new SqlParameter("@STI_Name", sTIMI.STI_Name), new SqlParameter("@STI_UnitPrice", sTIMI.STI_UnitPrice));

        }//编辑计时项目

        public int Insert_SalaryTimeItemRecord(SalaryTimeItemChangeRecordInfo sTIMI)
        {
            return (int)SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_SalaryTimeItemChangeRecord",
                new SqlParameter("@STI_ID", sTIMI.STI_ID), new SqlParameter("@STICR_FormerPrice", sTIMI.STICR_FormerPrice),
                new SqlParameter("@STICR_NewPrice", sTIMI.STICR_NewPrice), new SqlParameter("@STICR_OpPerson", sTIMI.STICR_OpPerson), new SqlParameter("@STICR_ExecDate", sTIMI.STICR_ExecDate));

        }//更改计时工价
        public int Delete_SalaryTimeItem(Guid ID)
        {
            return (int)SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_SalaryTimeItem",
                new SqlParameter("@STI_ID", ID));
        }//对工资账套进行假删除

        public DataSet SearchByCondition_SalaryTimeItem(string Condition)
        {
            return (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_S_SalaryTimeItem", new SqlParameter("@condition", Condition));
        }//根据condition检索计时项目
        public DataSet Search_SalaryTimeItemHistory(Guid ID)
        {
            return (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_S_SalaryTimeItemHistory", new SqlParameter("@STI_ID", ID)); 
        }//绑定历史计时工价
        public IList<SalaryTimeItemMaintananceInfo> SearchByID_SalaryTimeItem(Guid STI_ID)
        {
            SqlParameter para = new SqlParameter("@STI_ID", STI_ID);
            IList<SalaryTimeItemMaintananceInfo> sASMI = new List<SalaryTimeItemMaintananceInfo>();
            SqlDataReader sdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_S_ByID_SalaryTimeItem", para);
            while (sdr.Read())
            {
                sASMI.Add(new SalaryTimeItemMaintananceInfo(new Guid(sdr["PBC_ID"].ToString()),
                   sdr["STI_Name"] == DBNull.Value ? "" : sdr["STI_Name"].ToString(), sdr["STI_UnitPrice"] == DBNull.Value ? 0 : (decimal)sdr["STI_UnitPrice"]));

            }
            return sASMI;
        }////根据ID检索计时项目,用于取出数据进行编辑

        public DataSet SearchCraftForDdl_SalaryTimeItem()
        {
            return (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_S_ForDdl_PBCraftInfo");
        }//为Dropdownlist绑定工序
    }
}