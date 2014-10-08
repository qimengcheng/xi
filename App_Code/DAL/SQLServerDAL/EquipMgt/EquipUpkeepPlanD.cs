using System;
using System.Data;
using System.Data.SqlClient;
using EquipmentMangementAjax.DBUtility;

/// <summary>
///EquipUpkeepPlanD 的摘要说明
/// </summary>
namespace EquipmentMangementAjax.SQLServer
{
    public class EquipUpkeepPlanD : IEquipUpkeepPlan
    {
        public EquipUpkeepPlanD()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
 //查询保养计划
        public DataSet Search_EquipUpkeepPlan(string condition)
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@condition", SqlDbType.NVarChar, 1000);
            parm[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_EquipUpkeepPlan", parm);
        }
//删除保养计划
        public int Delete_EquipUpkeepPlan(Guid EUP_ID)
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@EUP_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = EUP_ID;
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,CommandType.StoredProcedure, "Proc_D_EquipUpkeepPlan", parm);
        }
//增加保养计划时，首先查询并选择设备台账
        public DataSet Search_InsertEquipUpkeepPlan_Inf(string ETT_Type, string EN_EquipName, string EMT_Type, string EI_No)
        {
            SqlParameter[] parm = new SqlParameter[4];
            parm[0] = new SqlParameter("@ETT_Type", SqlDbType.VarChar, 20);
            parm[0].Value = ETT_Type;
            parm[1] = new SqlParameter("@EN_EquipName", SqlDbType.VarChar, 40);
            parm[1].Value = EN_EquipName;
            parm[2] = new SqlParameter("@EMT_Type", SqlDbType.VarChar, 20);
            parm[2].Value = EMT_Type;
            parm[3] = new SqlParameter("@EI_No", SqlDbType.VarChar, 20);
            parm[3].Value = EI_No;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_InsertEquipUpkeepPlan_Inf", parm);
        }
//增加保养计划时，查看上次各保养项目详情
        public DataSet Search_InsertEquipUpkeepPlan_Last(Guid EN_ID, Guid EI_ID)
        {
            SqlParameter[] parm = new SqlParameter[2];
            parm[0] = new SqlParameter("@EN_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = EN_ID;
            parm[1] = new SqlParameter("@EI_ID", SqlDbType.UniqueIdentifier);
            parm[1].Value = EI_ID;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_InsertEquipUpkeepPlan_Last", parm);
        }
//在已选择的设备台账下,增加保养计划
        public void Insert_EquipUpkeepPlan_plan(Guid EI_ID, string EUP_UpkeepPer, decimal EUP_ExpectTime, string EUP_Class, DateTime EUP_PDate, string EUP_PPerson,
            DateTime EUP_MakingTime, string EUP_State)
        {
            SqlParameter[] parm = new SqlParameter[8];
            parm[0] = new SqlParameter("@EI_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = EI_ID;
            parm[1] = new SqlParameter("@EUP_UpkeepPer", SqlDbType.VarChar, 20);
            parm[1].Value = EUP_UpkeepPer;
            parm[2] = new SqlParameter("@EUP_ExpectTime", SqlDbType.Decimal);
            parm[2].Value = EUP_ExpectTime;
            parm[3] = new SqlParameter("@EUP_Class", SqlDbType.VarChar, 20);
            parm[3].Value = EUP_Class;
            parm[4] = new SqlParameter("@EUP_PDate", SqlDbType.DateTime);
            parm[4].Value = EUP_PDate;
            parm[5] = new SqlParameter("@EUP_PPerson", SqlDbType.VarChar, 20);
            parm[5].Value = EUP_PPerson;
            parm[6] = new SqlParameter("@EUP_MakingTime", SqlDbType.DateTime);
            parm[6].Value = EUP_MakingTime;
            parm[7] = new SqlParameter("@EUP_State", SqlDbType.VarChar, 20);
            parm[7].Value = EUP_State;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_EquipUpkeepPlan_plan", parm);
        }
//增加保养计划后,增加该计划的保养项目
        public void Insert_EquipUpkeepPlan_item(Guid EUI_ID,Guid EUP_ID)
        {
            SqlParameter[] parm = new SqlParameter[2];
            parm[0] = new SqlParameter("@EUI_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = EUI_ID;
            parm[1] = new SqlParameter("@EUP_ID", SqlDbType.UniqueIdentifier);
            parm[1].Value = EUP_ID;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_EquipUpkeepPlan_item", parm);
        }
//增加保养计划后,删除该计划的保养项目
        public int Delete_EquipUpkeepPlan_item(Guid EUD_ID)
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@EUD_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = EUD_ID;
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_EquipUpkeepPlan_item", parm);
        }
//查询保养计划时,显示该设备已选择的保养项目
        public DataSet Search_EquipUpkeepPlan_Item(string condition)
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@condition", SqlDbType.NVarChar, 1000);
            parm[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_EquipUpkeepPlan_Item", parm);
        }    
//修改/编辑保养计划
        public void Update_EquipUpkeepPlan_ZD(Guid EUP_ID, string EUP_UpkeepPer, decimal EUP_ExpectTime, string EUP_Class, DateTime EUP_PDate, string EUP_PPerson,
             DateTime EUP_MakingTime, string EUP_State)
        {
            SqlParameter[] parm = new SqlParameter[8];
            parm[0] = new SqlParameter("@EUP_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = EUP_ID;
            parm[1] = new SqlParameter("@EUP_UpkeepPer", SqlDbType.VarChar, 20);
            parm[1].Value = EUP_UpkeepPer;
            parm[2] = new SqlParameter("@EUP_ExpectTime", SqlDbType.Decimal);
            parm[2].Value = EUP_ExpectTime;
            parm[3] = new SqlParameter("@EUP_Class", SqlDbType.VarChar, 20);
            parm[3].Value = EUP_Class;
            parm[4] = new SqlParameter("@EUP_PDate", SqlDbType.DateTime);
            parm[4].Value = EUP_PDate;
            parm[5] = new SqlParameter("@EUP_PPerson", SqlDbType.VarChar, 20);
            parm[5].Value = EUP_PPerson;
            parm[6] = new SqlParameter("@EUP_MakingTime", SqlDbType.DateTime);
            parm[6].Value = EUP_MakingTime;
            parm[7] = new SqlParameter("@EUP_State", SqlDbType.VarChar, 20);
            parm[7].Value = EUP_State;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,CommandType.StoredProcedure, "Proc_U_EquipUpkeepPlan_ZD", parm);
        }
//生成保养计划
        public void Update_EquipUpkeepPlan_SC(Guid EUP_ID, string EUP_UpkeepPer, decimal EUP_ExpectTime, string EUP_Class, DateTime EUP_PDate, string EUP_PPerson,
             DateTime EUP_MakingTime, string EUP_State, string EUP_GeneratePer, DateTime EUP_GenerateTime)
        {
            SqlParameter[] parm = new SqlParameter[10];
            parm[0] = new SqlParameter("@EUP_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = EUP_ID;
            parm[1] = new SqlParameter("@EUP_UpkeepPer", SqlDbType.VarChar, 20);
            parm[1].Value = EUP_UpkeepPer;
            parm[2] = new SqlParameter("@EUP_ExpectTime", SqlDbType.Decimal);
            parm[2].Value = EUP_ExpectTime;
            parm[3] = new SqlParameter("@EUP_Class", SqlDbType.VarChar, 20);
            parm[3].Value = EUP_Class;
            parm[4] = new SqlParameter("@EUP_PDate", SqlDbType.DateTime);
            parm[4].Value = EUP_PDate;
            parm[5] = new SqlParameter("@EUP_PPerson", SqlDbType.VarChar, 20);
            parm[5].Value = EUP_PPerson;
            parm[6] = new SqlParameter("@EUP_MakingTime", SqlDbType.DateTime);
            parm[6].Value = EUP_MakingTime;
            parm[7] = new SqlParameter("@EUP_State", SqlDbType.VarChar, 20);
            parm[7].Value = EUP_State;
            parm[8] = new SqlParameter("@EUP_GeneratePer", SqlDbType.VarChar, 20);
            parm[8].Value = EUP_GeneratePer;
            parm[9] = new SqlParameter("@EUP_GenerateTime", SqlDbType.DateTime);
            parm[9].Value = EUP_GenerateTime;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_EquipUpkeepPlan_SC", parm);
        }
//填写保养记录的时候，显示已选择的备件
        public DataSet Search_EquipUpkeepPlan_Sparedone(string condition)
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@condition", SqlDbType.NVarChar, 1000);
            parm[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_UpdateEquipUpkeepPlan_Sparedone", parm);
        }
//填写保养记录的时候，显示该型号设备全部可选的备件，也可精确查找某个备件
        public DataSet Search_EquipUpkeepPlan_Spare(string condition)
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@condition", SqlDbType.NVarChar, 1000);
            parm[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_UpdateEquipUpkeepPlan_Spare", parm);
        }
//填写保养记录的时候，增加备件
        public void Insert_EquipUpkeepPlan_Spare(Guid EFUS_ID, Guid EUP_ID,int EMSAUS_UseAmount)
        {
            SqlParameter[] parm = new SqlParameter[3];
            parm[0] = new SqlParameter("@EFUS_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = EFUS_ID;
            parm[1] = new SqlParameter("@EUP_ID", SqlDbType.UniqueIdentifier);
            parm[1].Value = EUP_ID;
            parm[2] = new SqlParameter("@EMSAUS_UseAmount", SqlDbType.Int);
            parm[2].Value = EMSAUS_UseAmount;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_EquipUpkeepPlan_Spare", parm);
        }
//填写保养记录的时候，删除已选的某个备件
        public int Delete_EquipUpkeepPlan_Spare(Guid EMSAUS_ID)
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@EMSAUS_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = EMSAUS_ID;
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_EquipUpkeepPlan_Spare", parm);
        }
//记录保养情况
        public void Update_EquipUpkeepPlan_JL(Guid EUP_ID, string EUP_ActPer, string EUP_OutPContents, DateTime EUP_UStartT, DateTime EUP_UEndT, string EUP_Remarks, string EUP_State)
        {
            SqlParameter[] parm = new SqlParameter[7];
            parm[0] = new SqlParameter("@EUP_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = EUP_ID;
            parm[1] = new SqlParameter("@EUP_ActPer", SqlDbType.VarChar, 20);
            parm[1].Value = EUP_ActPer;
            parm[2] = new SqlParameter("@EUP_OutPContents", SqlDbType.VarChar, 200);
            parm[2].Value = EUP_OutPContents;
            parm[3] = new SqlParameter("@EUP_UStartT", SqlDbType.DateTime);
            parm[3].Value = EUP_UStartT;
            parm[4] = new SqlParameter("@EUP_UEndT", SqlDbType.DateTime);
            parm[4].Value = EUP_UEndT;
            parm[5] = new SqlParameter("@EUP_Remarks", SqlDbType.VarChar, 400);
            parm[5].Value = EUP_Remarks;
            parm[6] = new SqlParameter("@EUP_State", SqlDbType.VarChar, 20);
            parm[6].Value = EUP_State;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_EquipUpkeepPlan_JL", parm);
        }
    }
}