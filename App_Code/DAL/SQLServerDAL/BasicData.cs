using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
//using System.Collections.Generic;
using EquipmentMangementAjax.DBUtility;

/// <summary>
///BasicData 的摘要说明
/// </summary>

namespace EquipmentMangementAjax.SQLServer
{
    public class BasicData:IBasicData 
    {
        public BasicData()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        public int Insert_BDOrganizationSheet(BDOrganizationSheet bDOrganizationSheet)
        {
            SqlParameter[] parm = new SqlParameter[3];
            parm[0] = new SqlParameter("@BDOS_Code", SqlDbType.VarChar, 60);
            parm[0].Value = bDOrganizationSheet.BDOS_Code ;
            parm[1] = new SqlParameter("@BDOS_Name", SqlDbType.VarChar, 100);
            parm[1].Value = bDOrganizationSheet.BDOS_Name ;
            parm[2] = new SqlParameter("@BDOS_Isdeleted", SqlDbType.Bit);
            parm[2].Value = bDOrganizationSheet.BDOS_Isdeleted ;
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_Insert_BDOrganizationSheet", parm);
        }
        public int Update_BDOrganizationSheet(BDOrganizationSheet bDOrganizationSheet)
        {
            SqlParameter[] parm = new SqlParameter[3];
            parm[0] = new SqlParameter("@BDOS_Code", SqlDbType.VarChar, 60);
            parm[0].Value = "";
            parm[1] = new SqlParameter("@BDOS_Name", SqlDbType.VarChar, 100);
            parm[1].Value = "233";
            parm[2] = new SqlParameter("@BDOS_Isdeleted", SqlDbType.Bit);
            parm[2].Value = 0;
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_Update_BDOrganizationSheet", parm);
        }
        public int Delete_BDOrganizationSheet(string bDOS_Code)
        {
            SqlParameter[] parm = new SqlParameter[3];
            parm[0] = new SqlParameter("@BDOS_Code", SqlDbType.VarChar, 60);
            parm[0].Value = "";
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_Delete_BDOrganizationSheet", parm);
        }
        public IList<BDOrganizationSheet> Select_BDOrganizationSheet(string condition)
        {
            SqlParameter para = new SqlParameter("@Condition",condition);
            IList<BDOrganizationSheet> Ibdos = new List<BDOrganizationSheet>();
            SqlDataReader sdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_Select_BDOrganizationSheet", para);
            while(sdr.Read())
            {
                Ibdos.Add(new BDOrganizationSheet(sdr["BDOS_Code"].ToString(), sdr["BDOS_Name"].ToString(),sdr["BDOS_Isdeleted"].ToString()=="0"?false:true ));
            }
            return Ibdos;
        }

        public int Update_SingleCol(string colname, string colvalue, string keyname, string keyvalue, string tabname)
        {
            SqlParameter[] parm = new SqlParameter[5];
            parm[0] = new SqlParameter("@ColumeName",SqlDbType.VarChar,255);
            parm[0].Value = colname;
            parm[1] = new SqlParameter("@ColumeValue", SqlDbType.VarChar, 255);
            parm[1].Value = "'"+colvalue+"'";
            parm[2] = new SqlParameter("@KeyName", SqlDbType.VarChar, 255);
            parm[2].Value = keyname;
            parm[3] = new SqlParameter("@KeyValue", SqlDbType.VarChar, 255);
            parm[3].Value = "'"+keyvalue+"'";
            parm[4] = new SqlParameter("@TableName", SqlDbType.VarChar, 255);
            parm[4].Value = tabname;
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_UpdateSingleCol", parm);
        }

        public string Select_SingleCol(string colname, string keyname, string keyvalue, string tabname)
        {
            SqlParameter[] parm = new SqlParameter[4];
            parm[0] = new SqlParameter("@ColumeName", SqlDbType.VarChar, 255);
            parm[0].Value = colname;
            parm[1] = new SqlParameter("@KeyName", SqlDbType.VarChar, 255);
            parm[1].Value = keyname;
            parm[2] = new SqlParameter("@KeyValue", SqlDbType.VarChar, 255);
            parm[2].Value = "'" + keyvalue + "'";
            parm[3] = new SqlParameter("@TableName", SqlDbType.VarChar, 255);
            parm[3].Value = tabname;
            string value = "";
            SqlDataReader sdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_SelectSingleCol", parm);
            if (sdr.Read())
            {
                value = sdr[0]==DBNull.Value?"":sdr[0].ToString();
            }
            return value;
        }
    }
}
