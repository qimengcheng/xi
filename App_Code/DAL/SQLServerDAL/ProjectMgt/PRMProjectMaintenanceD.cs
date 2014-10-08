using System.Data;
using System.Data.SqlClient;
using EquipmentMangementAjax.DBUtility;

/// <summary>
///PRMProjectMaintenanceD 的摘要说明
/// </summary>
namespace EquipmentMangementAjax.SQLServer
{
    public class PRMProjectMaintenanceD : IPRMProjectMaintenance
    {
        public PRMProjectMaintenanceD()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        //查询项目
        public DataSet SelectPRMProject_Maintenance(string condition)
        {
            SqlParameter parm = new SqlParameter("@Condition", condition);
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_PRMProject_Maintenance", parm);
        }
        //绑定项目进度
        public DataSet SelectPRMProject(PRMProjectinfo pRMProjectinfo)
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@PRMPS_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = pRMProjectinfo.PRMPS_ID;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                    CommandType.StoredProcedure, "Proc_S_PRMProject_Postpone", parm);
        }
        //延期设置
        public void InsertPRMProject_Postpone(PRMProjectinfo pRMProjectinfo)
        {
            SqlParameter[] parm = new SqlParameter[4];
            parm[0] = new SqlParameter("@PRMPS_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = pRMProjectinfo.PRMPS_ID;
            parm[1] = new SqlParameter("@PRMPS_RelayDay", SqlDbType.Int);
            parm[1].Value = pRMProjectinfo.PRMPS_RelayDay;
            parm[2] = new SqlParameter("@PRMPS_RelayReason", SqlDbType.VarChar, 400);
            parm[2].Value = pRMProjectinfo.PRMPS_RelayReason;
            parm[3] = new SqlParameter("@PRMPS_RelayMan", SqlDbType.VarChar, 50);
            parm[3].Value = pRMProjectinfo.PRMPS_RelayMan;
           
            SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                     CommandType.StoredProcedure, "Proc_I_PRMProject_Postpone", parm);
        }
        //填写进度
        public void InsertPRMProject_Schedule(PRMProjectinfo pRMProjectinfo)
        {
            SqlParameter[] parm = new SqlParameter[9];
            parm[0] = new SqlParameter("@PRMPS_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = pRMProjectinfo.PRMPS_ID;
            parm[1] = new SqlParameter("@PRMPS_ScheduleFinish", SqlDbType.Char, 2);
            parm[1].Value = pRMProjectinfo.PRMPS_ScheduleFinish;
            parm[2] = new SqlParameter("@PRMPS_ProcessCondition", SqlDbType.VarChar, 400);
            parm[2].Value = pRMProjectinfo.PRMPS_ProcessCondition;
            parm[3] = new SqlParameter("@PRMPS_WorkOrderNum", SqlDbType.VarChar, 100);
            parm[3].Value = pRMProjectinfo.PRMPS_WorkOrderNum;
            parm[4] = new SqlParameter("@PRMPS_Accessory", SqlDbType.Char, 2);
            parm[4].Value = pRMProjectinfo.PRMPS_Accessory;
            parm[5] = new SqlParameter("@PRMPS_ProcessMan", SqlDbType.VarChar, 20);
            parm[5].Value = pRMProjectinfo.PRMPS_ProcessMan;
            parm[6] = new SqlParameter("@PRMPS_AccessoryPath", SqlDbType.VarChar, 100);
            parm[6].Value = pRMProjectinfo.PRMPS_AccessoryPath;
            parm[7] = new SqlParameter("@PRMPS_AccNum", SqlDbType.VarChar, 100);
            parm[7].Value = pRMProjectinfo.PRMPS_AccNum;
            parm[8] = new SqlParameter("@PRMPS_AccName", SqlDbType.VarChar, 100);
            parm[8].Value = pRMProjectinfo.PRMPS_AccName;
            SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                     CommandType.StoredProcedure, "Proc_I_PRMProject_Schedule", parm);
        }
        //查询进度明细
        public DataSet SelectPRMProject_Schedule(PRMProjectinfo pRMProjectinfo)
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@PRMP_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = pRMProjectinfo.PRMP_ID;
           
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                       CommandType.StoredProcedure, "Proc_S_PRMProject_Schedule", parm);
        }
        //跟踪随工单
        public DataSet SelectPRMProject_WOrder_Protect(string condition)
        {
            SqlParameter parm = new SqlParameter("@Condition", condition);
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_PRMProject_WOrder_Protect", parm);
        }
        //查询随工单
        public DataSet SelectPRMProject_WOrder_One(string condition)
        {
            SqlParameter parm = new SqlParameter("@Condition", condition);
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_PRMProject_WOrder_One", parm);
        }
        //插入附件
        public void InsertPRMPS_Accessory(PRMProjectinfo pRMProjectinfo)
        {
            SqlParameter[] parm = new SqlParameter[4];
            parm[0] = new SqlParameter("@PRMPS_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = pRMProjectinfo.PRMPS_ID;
            parm[1] = new SqlParameter("@PRMPS_AccNum ", SqlDbType.VarChar ,100);
            parm[1].Value = pRMProjectinfo.PRMPS_AccNum;
            parm[2] = new SqlParameter("@PRMPS_AccName", SqlDbType.VarChar, 100);
            parm[2].Value = pRMProjectinfo.PRMPS_AccName;
            parm[3] = new SqlParameter("@PRMPS_Accessory", SqlDbType.Char ,2);
            parm[3].Value = pRMProjectinfo.PRMPS_Accessory;
            parm[4] = new SqlParameter("@PRMPS_AccessoryPath", SqlDbType.VarChar ,100);
            parm[4].Value = pRMProjectinfo.PRMPS_AccessoryPath;
           
            SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                     CommandType.StoredProcedure, "Proc_I_PRMPS_Accessory", parm);
        }
    
    }
}