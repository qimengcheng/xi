using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using EquipmentMangementAjax.DBUtility;
using System.Data.SqlClient;

/// <summary>
///SalaryPieceworkItemMaintananceD 的摘要说明
/// </summary>
namespace EquipmentMangementAjax.SQLServer
{
    public class SalaryPieceworkItemMaintananceD : ISalaryPieceworkItemMaintanance
    {
        public SalaryPieceworkItemMaintananceD()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        public int Insert_SalaryPieceworkItem(SalaryPieceworkItemMaintananceInfo sPIMI)
        {
            return (int)SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_SalaryPieceworkItem",
                new SqlParameter("@SPI_ID", sPIMI.SPI_ID), new SqlParameter("@SPS_ID", sPIMI.SPS_ID),
                new SqlParameter("@PBC_ID", sPIMI.PBC_ID), new SqlParameter("@SPI_Name", sPIMI.SPI_Name), new SqlParameter("@SPI_UnitPrice", sPIMI.SPI_UnitPrice),
                new SqlParameter("@SPI_IsDeleted", sPIMI.SPI_IsDeleted));
        }//新增计件项目

        public int Update_SalaryPieceworkItem(SalaryPieceworkItemMaintananceInfo sPIMI)
        {
            return (int)SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_SalaryPieceworkItem",
                new SqlParameter("@SPI_ID", sPIMI.SPI_ID), new SqlParameter("@SPS_ID", sPIMI.SPS_ID),
                new SqlParameter("@PBC_ID", sPIMI.PBC_ID), new SqlParameter("@SPI_Name", sPIMI.SPI_Name), new SqlParameter("@SPI_UnitPrice", sPIMI.SPI_UnitPrice));

        }//编辑计件项目

        public int Delete_SalaryPieceworkItem(Guid ID)
        {
            return (int)SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_SalaryPieceworkItem",
                new SqlParameter("@SPI_ID", ID));
        }//删除计件项目

        public DataSet SearchByCondition_SalaryPieceworkItem(string Condition)
        {
            return (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_S_SalaryPieceworkItem", new SqlParameter("@condition", Condition));
        }//根据condition检索计件项目

        public DataSet SearchByCondition_QZL_ProType(string Condition)
        {
            return (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_S_QZL_ProType", new SqlParameter("@condition", Condition));
        }//根据condition检索产品型号

        public IList<SalaryPieceworkItemMaintananceInfo> SearchByID_SalaryPieceworkItem(Guid SPI_ID)
        {
            SqlParameter para = new SqlParameter("@SPI_ID", SPI_ID);
            IList<SalaryPieceworkItemMaintananceInfo> sSPIMI = new List<SalaryPieceworkItemMaintananceInfo>();
            SqlDataReader sdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_S_ByID_SalaryPieceworkItem", para);
            while (sdr.Read())
            {
                sSPIMI.Add(new SalaryPieceworkItemMaintananceInfo(sdr["PBC_Name"] == DBNull.Value ? "" : sdr["PBC_Name"].ToString(),
                    new Guid(sdr["PBC_ID"].ToString()), sdr["SPI_Type"] == DBNull.Value ? "" : sdr["SPI_Type"].ToString(), sdr["SPI_UnitPrice"] == DBNull.Value ? 0 : (decimal)sdr["SPI_UnitPrice"]));

            }
            return sSPIMI;
        }////根据ID检索计件项目,用于取出数据进行编辑

        public int Insert_SalaryPieceItemChangeRecord(SalaryPieceworkItemMaintananceInfo sPIMI)
        {
            return (int)SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_SalaryPieceItemChangeRecord",
                new SqlParameter("@SPI_ID", sPIMI.SPI_ID), new SqlParameter("@SPICR_FormerPrice", sPIMI.SPICR_FormerPrice),
                new SqlParameter("@SPICR_NewPrice", sPIMI.SPICR_NewPrice), new SqlParameter("@SPICR_OpPerson", sPIMI.SPICR_OpPerson),
                new SqlParameter("@SPICR_ExecDate", sPIMI.SPICR_ExecDate));
        }//新增计件历史单价

        public DataSet SearchSalaryPieceItemChangeRecord(Guid SPI_ID)
        {
            return (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_S_SalaryPieceItemChangeRecord", new SqlParameter("@SPI_ID", SPI_ID));
        }//

       ///
       /// 为Dropdownlist绑定工序 与计时项目维护的绑定工序共用
       /// 
    }
}