using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Collections;
using EquipmentMangementAjax.DBUtility;

/// <summary>
///ProductionProcessD 的摘要说明
/// </summary>
public class ProductionProcessD
{
    public ProductionProcessD()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }


    public bool S_WorkOrderCheck(string condition)//编辑随工单信息时检索重名随工单号
    {
        SqlParameter[] para = new SqlParameter[1];
        para[0] = new SqlParameter("@condition", SqlDbType.NVarChar, 2000);
        para[0].Value = condition;
        DataSet dataSet = SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_WorkOrderNumCheck", para);
        if (dataSet.Tables[0].Rows.Count > 0)
            return true;
        else
            return false;
    }

    public void CS_I__WOError_apply_NEW(Guid EPOD_ID, string WOE_Detail,string WOE_People,Guid WOD_ID,string WOE_ApplyDepartMent)//新增异常信息
    {
        SqlParameter[] para = new SqlParameter[5];
        para[0] = new SqlParameter("@EPOD_ID", SqlDbType.UniqueIdentifier);
        para[0].Value = EPOD_ID;
        para[1] = new SqlParameter("@WOE_Detail", SqlDbType.VarChar, 1000);
        para[1].Value = WOE_Detail;
        para[2] = new SqlParameter("@WOE_People", SqlDbType.VarChar, 20);
        para[2].Value = WOE_People;
        para[3] = new SqlParameter("@WOD_ID", SqlDbType.UniqueIdentifier);
        para[3].Value = WOD_ID;
        para[4] = new SqlParameter("@WOE_ApplyDepartMent", SqlDbType.VarChar, 100);
        para[4].Value = WOE_ApplyDepartMent;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "CS_Proc_I__WOError_apply_NEW", para);
    }


    public void U_WOError_I_PBC(Guid WO_ID, Guid WOD_ID, Guid PBC_ID, Guid WOE_ID, string Man,int jijian )//新增工序
    {
        SqlParameter[] para = new SqlParameter[6];
        para[0] = new SqlParameter("@WO_ID", SqlDbType.UniqueIdentifier);
        para[0].Value = WO_ID;
        para[1] = new SqlParameter("@WOD_ID", SqlDbType.UniqueIdentifier);
        para[1].Value = WOD_ID;
        para[2] = new SqlParameter("@PBC_ID", SqlDbType.UniqueIdentifier);
        para[2].Value = PBC_ID;
        para[3] = new SqlParameter("@WOE_ID", SqlDbType.UniqueIdentifier);
        para[3].Value = WOE_ID;
        para[4] = new SqlParameter("@Man", SqlDbType.VarChar, 20);
        para[4].Value = Man;
        para[5] = new SqlParameter("@WOD_IsNotJiJian", SqlDbType.Int);
        para[5].Value = jijian;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_WOError_I_PBC", para);
    }

    public void U_WOError_I_PBC_Normal(Guid WO_ID, Guid WOD_ID, Guid PBC_ID)//新增工序_普通
    {
        SqlParameter[] para = new SqlParameter[3];
        para[0] = new SqlParameter("@WO_ID", SqlDbType.UniqueIdentifier);
        para[0].Value = WO_ID;
        para[1] = new SqlParameter("@WOD_ID", SqlDbType.UniqueIdentifier);
        para[1].Value = WOD_ID;
        para[2] = new SqlParameter("@PBC_ID", SqlDbType.UniqueIdentifier);
        para[2].Value = PBC_ID;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_WOError_I_PBC_Normal", para);
    }

    public void U_WOError_D_PBC(Guid WOD_ID, Guid WOE_ID, string Man)//删除工序
    {
        SqlParameter[] para = new SqlParameter[3];
        para[0] = new SqlParameter("@WOD_ID", SqlDbType.UniqueIdentifier);
        para[0].Value = WOD_ID;
        para[1] = new SqlParameter("@WOE_ID", SqlDbType.UniqueIdentifier);
        para[1].Value = WOE_ID;
        para[2] = new SqlParameter("@Man", SqlDbType.VarChar,20);
        para[2].Value = Man;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_WOError_D_PBC", para);
    }

    public void U_WOError_D_PBC_Normal(Guid WOD_ID)//删除工序_普通
    {
        SqlParameter[] para = new SqlParameter[1];
        para[0] = new SqlParameter("@WOD_ID", SqlDbType.UniqueIdentifier);
        para[0].Value = WOD_ID;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_WOError_D_PBC_Normal", para);
    }

    public void U_WOError_Deal_NEW(Guid WOE_ID, string WOE_DealMan, string WOE_Dep, string WOE_Measure)//编辑异常材料处理信息_新
    {
        SqlParameter[] para = new SqlParameter[4];
        para[0] = new SqlParameter("@WOE_ID ", SqlDbType.UniqueIdentifier);
        para[0].Value = WOE_ID;
        para[1] = new SqlParameter("@WOE_DealMan", SqlDbType.VarChar, 20);
        para[1].Value = WOE_DealMan;
        para[2] = new SqlParameter("@WOE_Dep", SqlDbType.VarChar, 60);
        para[2].Value = WOE_Dep;
        para[3] = new SqlParameter("@WOE_Measure", SqlDbType.VarChar, 1000);
        para[3].Value = WOE_Measure;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_WOError_Deal_NEW", para);
    }

    public DataSet S_WOError_new(Guid WOD_ID)//
    {
        SqlParameter[] para = new SqlParameter[1];
        para[0] = new SqlParameter("@WOD_ID", SqlDbType.UniqueIdentifier);
        para[0].Value = WOD_ID;
        return SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_WOError_new", para);

    }

    public DataSet S_WOError_I_PBC(Guid WOE_ID)//
    {
        SqlParameter[] para = new SqlParameter[1];
        para[0] = new SqlParameter("@WOE_ID", SqlDbType.UniqueIdentifier);
        para[0].Value = WOE_ID;
        return SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_WOError_I_PBC", para);

    }

    public DataSet S_WorkOrder_WO_Time()//
    {

        return SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_WorkOrder_WO_Time", null);

    }
    public DataSet S_ProType_For_WorkOrder(string condition)//
    {
        SqlParameter[] para = new SqlParameter[1];
        para[0] = new SqlParameter("@condition", SqlDbType.VarChar, 2000);
        para[0].Value = condition;
        return SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_ProType_For_WorkOrder", para);

    }

    public void I_WorkOrder_NEW(WorkOrderInfo workOrderInfo, string code, string typecode, Guid PT_ID, string WO_PrintWord, string WO_QiaoKe, string WO_YingJiao, int WO_FirstDay, string WO_PT_Code, string WO_PT_ChipType,string sn,int oem)//新增随工单
    {
        SqlParameter[] para = new SqlParameter[18];
        para[0] = new SqlParameter("@code", SqlDbType.Char, 1);
        para[0].Value = code;
        para[1] = new SqlParameter("@WO_Type", SqlDbType.VarChar, 20);
        para[1].Value = workOrderInfo.WO_Type;
        para[2] = new SqlParameter("@WO_ProType", SqlDbType.VarChar, 60);
        para[2].Value = workOrderInfo.WO_ProType;
        para[3] = new SqlParameter("@WO_PNum", SqlDbType.Int);
        para[3].Value = workOrderInfo.WO_PNum;
        para[4] = new SqlParameter("@WO_Note", SqlDbType.VarChar, 200);
        para[4].Value = workOrderInfo.WO_Note;
        para[5] = new SqlParameter("@WO_People", SqlDbType.VarChar, 20);
        para[5].Value = workOrderInfo.WO_People;
        para[6] = new SqlParameter("@WO_OrderNum", SqlDbType.VarChar, 30);
        para[6].Value = workOrderInfo.WO_OrderNum;
        para[7] = new SqlParameter("@SMSO_ID", SqlDbType.UniqueIdentifier);
        para[7].Value = workOrderInfo.SMSO_ID;
        para[8] = new SqlParameter("@typecode", SqlDbType.VarChar, 3);
        para[8].Value = typecode;
        para[9] = new SqlParameter("@PT_ID", SqlDbType.UniqueIdentifier);
        para[9].Value = PT_ID;
        para[10] = new SqlParameter("@WO_PrintWord", SqlDbType.VarChar, 2);
        para[10].Value = WO_PrintWord;
        para[11] = new SqlParameter("@WO_QiaoKe", SqlDbType.Char, 1);
        para[11].Value = WO_QiaoKe;
        para[12] = new SqlParameter("@WO_YingJiao", SqlDbType.Char, 2);
        para[12].Value = WO_YingJiao;
        para[13] = new SqlParameter("@WO_FirstDay", SqlDbType.Int);
        para[13].Value = WO_FirstDay;
        para[14] = new SqlParameter("@WO_PT_Code", SqlDbType.VarChar, 2000);
        para[14].Value = WO_PT_Code;
        para[15] = new SqlParameter("@WO_PT_ChipType", SqlDbType.VarChar, 6);
        para[15].Value = WO_PT_ChipType;
        para[16] = new SqlParameter("@WO_SN", SqlDbType.VarChar, 30);
        para[16].Value = sn;
        para[17] = new SqlParameter("@OEM", SqlDbType.Int);
        para[17].Value = oem;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_WorkOrder_NEW", para);
    }

    public void WorkOrder_Edit(WorkOrderInfo workOrderInfo, Guid PT_ID)//编辑随工单
    {
        SqlParameter[] para = new SqlParameter[10];
        para[0] = new SqlParameter("@WO_Time", SqlDbType.DateTime);
        para[0].Value = workOrderInfo.WO_Time;
        para[1] = new SqlParameter("@WO_Note", SqlDbType.VarChar, 200);
        para[1].Value = workOrderInfo.WO_Note;
        para[2] = new SqlParameter("@WO_People", SqlDbType.VarChar, 20);
        para[2].Value = workOrderInfo.WO_People;
        para[3] = new SqlParameter("@WO_ProType", SqlDbType.VarChar, 60);
        para[3].Value = workOrderInfo.WO_ProType;
        para[4] = new SqlParameter("@WO_Num", SqlDbType.VarChar, 30);
        para[4].Value = workOrderInfo.WO_Num;
        para[5] = new SqlParameter("@WO_OrderNum", SqlDbType.VarChar, 30);
        para[5].Value = workOrderInfo.WO_OrderNum;
        para[6] = new SqlParameter("@WO_SN", SqlDbType.VarChar, 30);
        para[6].Value = workOrderInfo.WO_SN;
        para[7] = new SqlParameter("@WO_ID", SqlDbType.UniqueIdentifier);
        para[7].Value = workOrderInfo.WO_ID;
        para[8] = new SqlParameter("@WO_PT_ID", SqlDbType.UniqueIdentifier);
        para[8].Value = PT_ID;
        para[9] = new SqlParameter("@SMSO_ID", SqlDbType.UniqueIdentifier);
        para[9].Value = workOrderInfo.SMSO_ID;

        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_WorkOrder_Edit", para);
    }
    public void I_WorkOrder_Devide_NEW(WorkOrderInfo workOrderInfo, Guid PT_ID, string sn, int num, Guid WOD_ID,int yuannum)//新增随工单
    {
        SqlParameter[] para = new SqlParameter[12];
        para[0] = new SqlParameter("@WO_ID", SqlDbType.UniqueIdentifier);
        para[0].Value = workOrderInfo.WO_ID;
        para[1] = new SqlParameter("@SMSO_ID", SqlDbType.UniqueIdentifier);
        para[1].Value = workOrderInfo.SMSO_ID;
        para[2] = new SqlParameter("@WO_Num", SqlDbType.VarChar, 30);
        para[2].Value = workOrderInfo.WO_Num;
        para[3] = new SqlParameter("@WO_ProType", SqlDbType.VarChar, 60);
        para[3].Value = workOrderInfo.WO_ProType;
        para[4] = new SqlParameter("@WO_OrderNum", SqlDbType.VarChar, 30);
        para[4].Value = workOrderInfo.WO_OrderNum;
        para[5] = new SqlParameter("@WO_SN", SqlDbType.VarChar, 30);
        para[5].Value = sn;
        para[6] = new SqlParameter("@WO_People", SqlDbType.VarChar, 20);
        para[6].Value = workOrderInfo.WO_People;
        para[7] = new SqlParameter("@WO_PT_ID", SqlDbType.UniqueIdentifier);
        para[7].Value = PT_ID;
        para[8] = new SqlParameter("@num", SqlDbType.Int);
        para[8].Value = num;
        para[9] = new SqlParameter("@WO_Note", SqlDbType.VarChar, 200);
        para[9].Value = workOrderInfo.WO_Note;
        para[10] = new SqlParameter("@WOD_ID", SqlDbType.UniqueIdentifier);
        para[10].Value = WOD_ID;
        para[11] = new SqlParameter("@yuannum", SqlDbType.Int);
        para[11].Value = yuannum;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_WorkOrder_Devide_NEW", para);
    }



    public void I_WorkOrder_Combine_NEW(string WO_FatherNum, string WO_ProType, string people, Guid PT_ID, string sn, int num, string type,string pihao, int WO_FirstDay,string PBC_ID)//新增随工单
    {
        SqlParameter[] para = new SqlParameter[10];
        para[0] = new SqlParameter("@WO_FatherNum", SqlDbType.VarChar,1000);
        para[0].Value = WO_FatherNum;
        para[1] = new SqlParameter("@WO_ProType", SqlDbType.VarChar,60);
        para[1].Value = WO_ProType;
        para[2] = new SqlParameter("@WO_SN", SqlDbType.VarChar, 30);
        para[2].Value = sn;
        para[3] = new SqlParameter("@WO_People", SqlDbType.VarChar, 20);
        para[3].Value = people;
        para[4] = new SqlParameter("@PT_ID", SqlDbType.UniqueIdentifier);
        para[4].Value = PT_ID;
        para[5] = new SqlParameter("@WO_PNum", SqlDbType.Int);
        para[5].Value = num;
        para[6] = new SqlParameter("@Type", SqlDbType.VarChar, 10);
        para[6].Value = type;
        para[7] = new SqlParameter("@pihao", SqlDbType.VarChar, 30);
        para[7].Value = pihao;
        para[8] = new SqlParameter("@WO_FirstDay", SqlDbType.Int);
        para[8].Value = WO_FirstDay;
        para[9] = new SqlParameter("@PBC_ID", SqlDbType.VarChar,2000);
        para[9].Value = PBC_ID;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_WorkOrder_Combine_NEW", para);
    }


    public DataSet S_IMRequisitionDetail_IMInventoryMain(Guid IMMBD_MaterialID)//查看领的材料有没有库存
    {
        SqlParameter[] para = new SqlParameter[1];
        para[0] = new SqlParameter("@IMMBD_MaterialID", SqlDbType.UniqueIdentifier);
        para[0].Value = IMMBD_MaterialID;
        return SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_IMRequisitionDetail_IMInventoryMain", para);

    }

    public DataSet S_WODetail_Check(Guid WO_ID)//查看随工单详细信息
    {
        SqlParameter[] para = new SqlParameter[1];
        para[0] = new SqlParameter("@WO_ID", SqlDbType.UniqueIdentifier);
        para[0].Value = WO_ID;
        return SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_WODetail_Check", para);

    }

    public DataSet S_WODetail_Check_ForPBC(Guid WO_ID,int m)//随工单详细查看,插入工序相关
    {
        SqlParameter[] para = new SqlParameter[2];
        para[0] = new SqlParameter("@WO_ID", SqlDbType.UniqueIdentifier);
        para[0].Value = WO_ID;
        para[1] = new SqlParameter("@m", SqlDbType.Int);
        para[1].Value = m;
        return SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_WODetail_Check_ForPBC", para);

    }

    public void U_WOError_HQ(Guid WOE_ID, string type, string hqman, string hqresult,string suggestion ,string hqdept)//会签
    {
        SqlParameter[] para = new SqlParameter[6];
        para[0] = new SqlParameter("@WOE_ID ", SqlDbType.UniqueIdentifier);
        para[0].Value = WOE_ID;
        para[1] = new SqlParameter("@type", SqlDbType.VarChar, 20);
        para[1].Value = type;
        para[2] = new SqlParameter("@hqman", SqlDbType.VarChar, 20);
        para[2].Value = hqman;
        para[3] = new SqlParameter("@hqresult", SqlDbType.VarChar, 20);
        para[3].Value = hqresult;
        para[4] = new SqlParameter("@suggestion", SqlDbType.VarChar, 400);
        para[4].Value = suggestion;
        para[5] = new SqlParameter("@hqdept", SqlDbType.VarChar, 60);
        para[5].Value = hqdept;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_WOError_HQ", para);
    }

    public void U_WOError_GZJA(Guid WOE_ID, string man, string result, string suggestion, string dept)//跟踪
    {
        SqlParameter[] para = new SqlParameter[5];
        para[0] = new SqlParameter("@WOE_ID ", SqlDbType.UniqueIdentifier);
        para[0].Value = WOE_ID;
        para[1] = new SqlParameter("@man", SqlDbType.VarChar, 20);
        para[1].Value = man;
        para[2] = new SqlParameter("@result", SqlDbType.VarChar, 20);
        para[2].Value = result;
        para[3] = new SqlParameter("@suggestion", SqlDbType.VarChar, 400);
        para[3].Value = suggestion;
        para[4] = new SqlParameter("@dept", SqlDbType.VarChar, 60);
        para[4].Value = dept;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_WOError_GZJA", para);
    }

    public void U_Zhuangpeijijian(Guid APD_ID, Guid LCS_ID)//跟踪
    {
        SqlParameter[] para = new SqlParameter[2];
        para[0] = new SqlParameter("@APD_ID ", SqlDbType.UniqueIdentifier);
        para[0].Value = APD_ID;
        para[1] = new SqlParameter("@LCS_ID", SqlDbType.UniqueIdentifier);
        para[1].Value = LCS_ID;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_Zhuangpeijijian", para);
    }

    public void U_Zhuangpeijijian_NEW(Guid APD_ID, Guid LCS_ID,int num)//跟踪
    {
        SqlParameter[] para = new SqlParameter[3];
        para[0] = new SqlParameter("@APD_ID ", SqlDbType.UniqueIdentifier);
        para[0].Value = APD_ID;
        para[1] = new SqlParameter("@LCS_ID", SqlDbType.UniqueIdentifier);
        para[1].Value = LCS_ID;
        para[2] = new SqlParameter("@num", SqlDbType.Int);
        para[2].Value = num;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_Zhuangpeijijian_NEW", para);
    }

    public DataSet S_WorkOrder_CombiningNum(string WO_FatherNum)//获取合单数量
    {
        SqlParameter[] para = new SqlParameter[1];
        para[0] = new SqlParameter("@WO_FatherNum", SqlDbType.VarChar,1000);
        para[0].Value = WO_FatherNum;
        return SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_WorkOrder_CombiningNum", para);

    }

    public DataSet S_Zhuangpeijijian_xiliesum(Guid APD_ID, Guid LCS_ID)//装配总数
    {
        SqlParameter[] para = new SqlParameter[2];
        para[0] = new SqlParameter("@APD_ID ", SqlDbType.UniqueIdentifier);
        para[0].Value = APD_ID;
        para[1] = new SqlParameter("@LCS_ID", SqlDbType.UniqueIdentifier);
        para[1].Value = LCS_ID;
        return SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
                  CommandType.StoredProcedure, "Proc_S_Zhuangpeijijian_xiliesum", para);
    }

    public void U_AssemblyTeamMember_Detail_LeiXing(Guid APD_ID, Guid LCS_ID, Guid ATM_Iterm_ID)//编辑装配计件修改计件类型
    {
        SqlParameter[] para = new SqlParameter[3];
        para[0] = new SqlParameter("@APD_ID ", SqlDbType.UniqueIdentifier);
        para[0].Value = APD_ID;
        para[1] = new SqlParameter("@LCS_ID", SqlDbType.UniqueIdentifier);
        para[1].Value = LCS_ID;
        para[2] = new SqlParameter("@ATM_Iterm_ID", SqlDbType.UniqueIdentifier);
        para[2].Value = ATM_Iterm_ID;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_AssemblyTeamMember_Detail_LeiXing", para);
    }

    public void U_AssemblyTeamMember_Detail_New(Guid ATM_ID, decimal ATM_LaborHour, Guid ATM_Iterm_ID)//编辑装配计件详情
    {
        SqlParameter[] para = new SqlParameter[3];
        para[0] = new SqlParameter("@ATM_ID ", SqlDbType.UniqueIdentifier);
        para[0].Value = ATM_ID;
        para[1] = new SqlParameter("@ATM_LaborHour", SqlDbType.Decimal);
        para[1].Value = ATM_LaborHour;
        para[2] = new SqlParameter("@ATM_Iterm_ID", SqlDbType.UniqueIdentifier);
        para[2].Value = ATM_Iterm_ID;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_AssemblyTeamMember_Detail_New", para);
    }

    public DataSet Proc_S_SalaryPieceworkItem_All(string condition)//计件项目
    {
        SqlParameter[] para = new SqlParameter[1];
        para[0] = new SqlParameter("@condition", SqlDbType.VarChar, 1000);
        para[0].Value = condition;
        return SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "CS_Proc_S_SalaryPieceworkItem_All", para);

    }
}