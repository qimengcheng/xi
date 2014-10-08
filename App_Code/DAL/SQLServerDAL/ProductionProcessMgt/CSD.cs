using System;
using System.Data;
using System.Data.SqlClient;
using EquipmentMangementAjax.DBUtility;
/// <summary>
///CSD 的摘要说明
/// </summary>
public class CSD
{
	public CSD()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    public DataSet S_CSUser(string condition)//检索客户端操作员
    {
        SqlParameter[] para = new SqlParameter[1];
        para[0] = new SqlParameter("@condition", SqlDbType.VarChar, 1000);
        para[0].Value = condition;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_CSUser", para);

    }

    public DataSet CS_S_CSUser_PBCraftInfo(string HRDD_StaffNO)//检索客户端操作员可操作的工序
    {
        SqlParameter[] para = new SqlParameter[1];
        para[0] = new SqlParameter("@HRDD_StaffNO", SqlDbType.VarChar, 20);
        para[0].Value = HRDD_StaffNO;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "CS_Proc_S_CSUser_PBCraftInfo", para);

    }

    public void Cs_I_WorkOrderDetail_NEW(string pT_Name, string wO_Num, Guid pBC_ID, string wOD_WOState, int wOD_PNum, int WOD_InNum)//客户端工序开启
    {
        SqlParameter[] parm = new SqlParameter[6];
        parm[0] = new SqlParameter("@PT_Name", SqlDbType.VarChar, 60);
        parm[0].Value = pT_Name;
        parm[1] = new SqlParameter("@WO_Num", SqlDbType.VarChar, 30);
        parm[1].Value = wO_Num;
        parm[2] = new SqlParameter("@PBC_ID", SqlDbType.UniqueIdentifier);
        parm[2].Value = pBC_ID;
        parm[3] = new SqlParameter("@WOD_WOState", SqlDbType.VarChar, 60);
        parm[3].Value = wOD_WOState;
        parm[4] = new SqlParameter("@WOD_PNum", SqlDbType.Int);
        parm[4].Value = wOD_PNum;
        parm[5] = new SqlParameter("@WOD_InNum", SqlDbType.Int);
        parm[5].Value = WOD_InNum;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Cs_Proc_I_WorkOrderDetail_NEW", parm);
    }

    public DataSet Cs_s_workorder_Basic_New(string WO_Num, Guid pbcid)//客户端显示随工单基础信息
    {
        SqlParameter[] parm = new SqlParameter[2];
        parm[0] = new SqlParameter("@WO_Num", SqlDbType.VarChar, 30);
        parm[0].Value = WO_Num;
        parm[1] = new SqlParameter("@pbcid", SqlDbType.UniqueIdentifier);
        parm[1].Value = pbcid;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
        CommandType.StoredProcedure, "Cs_proc_s_workorder_Basic_New", parm);
    }


    public DataSet Cs_S_WODetail_EquipmentInf_New(string pbcname, int mojushebei, int allornot, string WO_Num, Guid pbcid)//客户端为随工单选择设备新
    {
        SqlParameter[] parm = new SqlParameter[5];
        parm[0] = new SqlParameter("@PBC_Name", SqlDbType.VarChar, 30);
        parm[0].Value = pbcname;
        parm[1] = new SqlParameter("@mojushebei", SqlDbType.Int);
        parm[1].Value = mojushebei;
        parm[2] = new SqlParameter("@allornot", SqlDbType.Int);
        parm[2].Value = allornot;
        parm[3] = new SqlParameter("@WO_Num", SqlDbType.VarChar, 30);
        parm[3].Value = WO_Num;
        parm[4] = new SqlParameter("@pbcid", SqlDbType.UniqueIdentifier);
        parm[4].Value = pbcid;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
        CommandType.StoredProcedure, "Cs_Proc_S_WODetail_EquipmentInf_New", parm);
    }

    public DataSet Cs_S_WODetail_EquipmentInf_New2(string pbcname, int mojushebei, int allornot, Guid WOD_ID)//客户端为随工单选择设备新
    {
        SqlParameter[] parm = new SqlParameter[4];
        parm[0] = new SqlParameter("@PBC_Name", SqlDbType.VarChar, 30);
        parm[0].Value = pbcname;
        parm[1] = new SqlParameter("@mojushebei", SqlDbType.Int);
        parm[1].Value = mojushebei;
        parm[2] = new SqlParameter("@allornot", SqlDbType.Int);
        parm[2].Value = allornot;
        parm[3] = new SqlParameter("@WOD_ID", SqlDbType.UniqueIdentifier);
        parm[3].Value = WOD_ID;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
        CommandType.StoredProcedure, "Cs_Proc_S_WODetail_EquipmentInf_New2", parm);
    }

    public DataSet Cs_S_WorkOrderDetail_Equipment_New(string WO_Num, Guid pbcid)//客户端显示随工单某工序的设备信息新
    {
        SqlParameter[] parm = new SqlParameter[2];
        parm[0] = new SqlParameter("@WO_Num", SqlDbType.VarChar, 30);
        parm[0].Value = WO_Num;
        parm[1] = new SqlParameter("@pbcid", SqlDbType.UniqueIdentifier);
        parm[1].Value = pbcid;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
        CommandType.StoredProcedure, "Cs_Proc_S_WorkOrderDetail_Equipment_New", parm);
    }

    public void Cs_I_WorkOrderDetail_Equipment_new(Guid EI_ID1, Guid EI_ID2, Guid pBC_ID, string WO_Num)//客户端随工单设备信息录入
    {
        SqlParameter[] parm = new SqlParameter[4];
        parm[0] = new SqlParameter("@EI_ID1", SqlDbType.UniqueIdentifier);
        parm[0].Value = EI_ID1;
        parm[1] = new SqlParameter("@EI_ID2", SqlDbType.UniqueIdentifier);
        parm[1].Value = EI_ID2;
        parm[2] = new SqlParameter("@PBC_ID", SqlDbType.UniqueIdentifier);
        parm[2].Value = pBC_ID;
        parm[3] = new SqlParameter("@WO_Num", SqlDbType.VarChar, 30);
        parm[3].Value = WO_Num;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Cs_Proc_I_WorkOrderDetail_Equipment_new", parm);
    }

    public void Cs_I_WorkOrderDetail_Equipment_new2(Guid EI_ID1, Guid EI_ID2, Guid WOD_ID)//客户端随工单设备信息录入
    {
        SqlParameter[] parm = new SqlParameter[3];
        parm[0] = new SqlParameter("@EI_ID1", SqlDbType.UniqueIdentifier);
        parm[0].Value = EI_ID1;
        parm[1] = new SqlParameter("@EI_ID2", SqlDbType.UniqueIdentifier);
        parm[1].Value = EI_ID2;
        parm[2] = new SqlParameter("@WOD_ID", SqlDbType.UniqueIdentifier);
        parm[2].Value = WOD_ID;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Cs_Proc_I_WorkOrderDetail_Equipment_new2", parm);
    }

    public DataSet Cs_S_WorkOrderDetail_OperatorInfo_New(string WO_Num, Guid pbcid)//客户端显示随工单作业员信息
    {
        SqlParameter[] parm = new SqlParameter[2];
        parm[0] = new SqlParameter("@WO_Num", SqlDbType.VarChar, 30);
        parm[0].Value = WO_Num;
        parm[1] = new SqlParameter("@pbcid", SqlDbType.UniqueIdentifier);
        parm[1].Value = pbcid;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
        CommandType.StoredProcedure, "Cs_Proc_S_WorkOrderDetail_OperatorInfo_New", parm);
    }


    public void CS_U_OperatorInfo_new(Guid OI_ID, int OI_ProNum, string OI_Type)//客户端随工单设备信息录入
    {
        SqlParameter[] parm = new SqlParameter[3];
        parm[0] = new SqlParameter("@OI_ID", SqlDbType.UniqueIdentifier);
        parm[0].Value = OI_ID;
        parm[1] = new SqlParameter("@OI_ProNum", SqlDbType.Int);
        parm[1].Value = OI_ProNum;
        parm[2] = new SqlParameter("@OI_Type", SqlDbType.VarChar, 20);
        parm[2].Value = OI_Type;

        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "CS_Proc_U_OperatorInfo_new", parm);
    }

    public void I_WODetail_Team(string WO_Num, Guid pbcid)//自动生成班组
    {
        SqlParameter[] parm = new SqlParameter[2];
        parm[0] = new SqlParameter("@WO_Num", SqlDbType.VarChar, 30);
        parm[0].Value = WO_Num;
        parm[1] = new SqlParameter("@pbcid", SqlDbType.UniqueIdentifier);
        parm[1].Value = pbcid;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
        CommandType.StoredProcedure, "Proc_I_WODetail_Team", parm);
    }


    public void CS_Proc_U_OTime_NEW(Guid OT_ID, int OT_Num, decimal OT_Time)//客户端随工单设备信息录入
    {
        SqlParameter[] parm = new SqlParameter[3];
        parm[0] = new SqlParameter("@OT_ID", SqlDbType.UniqueIdentifier);
        parm[0].Value = OT_ID;
        parm[1] = new SqlParameter("@OT_Num", SqlDbType.Int);
        parm[1].Value = OT_Num;
        parm[2] = new SqlParameter("@OT_Time", SqlDbType.Decimal);
        parm[2].Value = OT_Time;

        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "CS_Proc_U_OTime_NEW", parm);
    }
    public DataSet CS_Proc_S_WODetail_ZuiHouGongXu_NEW(string WO_Num, Guid pbcid)//查找判断工艺路线中最后一条工序
    {
        SqlParameter[] parm = new SqlParameter[2];
        parm[0] = new SqlParameter("@WO_Num", SqlDbType.VarChar, 30);
        parm[0].Value = WO_Num;
        parm[1] = new SqlParameter("@pbcid", SqlDbType.UniqueIdentifier);
        parm[1].Value = pbcid;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
        CommandType.StoredProcedure, "CS_Proc_S_WODetail_ZuiHouGongXu_NEW", parm);
    }

    public void Cs_Proc_U_WorkOrderDetail_Basic_NEW(Guid wOD_ID, int wOD_InNum, int wOD_QNum, decimal wOD_QRate, string WOD_Class)//客户端投入数、合格数信息录入
    {
        SqlParameter[] parm = new SqlParameter[5];
        parm[0] = new SqlParameter("@WOD_ID ", SqlDbType.UniqueIdentifier);
        parm[0].Value = wOD_ID;
        parm[1] = new SqlParameter("@WOD_InNum", SqlDbType.Int);
        parm[1].Value = wOD_InNum;
        parm[2] = new SqlParameter("@WOD_QNum", SqlDbType.Int);
        parm[2].Value = wOD_QNum;
        parm[3] = new SqlParameter("@WOD_QRate", SqlDbType.Decimal);
        parm[3].Value = wOD_QRate;
        parm[4] = new SqlParameter("@WOD_Class", SqlDbType.VarChar, 30);
        parm[4].Value = WOD_Class;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Cs_Proc_U_WorkOrderDetail_Basic_NEW", parm);
    }

    public void Cs_Proc_U_WorkOrderDetail_Basic_NEW2(Guid wOD_ID, int wOD_InNum, string WOD_Class, int WOD_PBCOrder)//客户端投入数、合格数信息录入
    {
        SqlParameter[] parm = new SqlParameter[4];
        parm[0] = new SqlParameter("@WOD_ID ", SqlDbType.UniqueIdentifier);
        parm[0].Value = wOD_ID;
        parm[1] = new SqlParameter("@WOD_InNum", SqlDbType.Int);
        parm[1].Value = wOD_InNum;
        parm[2] = new SqlParameter("@WOD_Class", SqlDbType.VarChar, 30);
        parm[2].Value = WOD_Class;
        parm[3] = new SqlParameter("@WOD_PBCOrder", SqlDbType.Int);
        parm[3].Value = WOD_PBCOrder;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Cs_Proc_U_WorkOrderDetail_Basic_NEW2", parm);
    }

    public DataSet CS_S_WODetail_WanGongKaiQi(string WO_Num, Guid pbcid)//判断工序是开启状态还是完工状态
    {
        SqlParameter[] parm = new SqlParameter[2];
        parm[0] = new SqlParameter("@WO_Num", SqlDbType.VarChar, 30);
        parm[0].Value = WO_Num;
        parm[1] = new SqlParameter("@pbcid", SqlDbType.UniqueIdentifier);
        parm[1].Value = pbcid;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
        CommandType.StoredProcedure, "CS_Proc_S_WODetail_WanGongKaiQi", parm);
    }

    public DataSet CS_S_WOMBatchNum_IMInventoryDetail_NEW(string condition, string pbcid, string WO_Num)//客户端查待选物料批号信息查看新
    {
        SqlParameter[] parm = new SqlParameter[3];
        parm[0] = new SqlParameter("@condition", SqlDbType.VarChar, 2000);
        parm[0].Value = condition;
        parm[1] = new SqlParameter("@PBC_ID", SqlDbType.VarChar, 100);
        parm[1].Value = pbcid;
        parm[2] = new SqlParameter("@WO_Num", SqlDbType.VarChar, 30);
        parm[2].Value = WO_Num;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
        CommandType.StoredProcedure, "CS_Proc_S_WOMBatchNum_IMInventoryDetail_NEW", parm);
    }
    public DataSet CS_S_WOMBatchNum_IMInventoryDetail_NEW2(string condition, string WO_Num)//客户端查待选物料批号信息查看新
    {
        SqlParameter[] parm = new SqlParameter[2];
        parm[0] = new SqlParameter("@condition", SqlDbType.VarChar, 2000);
        parm[0].Value = condition;
        parm[1] = new SqlParameter("@WO_Num", SqlDbType.VarChar, 30);
        parm[1].Value = WO_Num;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
        CommandType.StoredProcedure, "CS_Proc_S_WOMBatchNum_IMInventoryDetail_NEW2", parm);
    }

    public DataSet CS_S_WODetail_First(string WO_Num, Guid pbcid)//CS端查找判断工艺路线中第一条工序
    {
        SqlParameter[] parm = new SqlParameter[2];
        parm[0] = new SqlParameter("@WO_Num", SqlDbType.VarChar, 30);
        parm[0].Value = WO_Num;
        parm[1] = new SqlParameter("@pbcid", SqlDbType.UniqueIdentifier);
        parm[1].Value = pbcid;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
        CommandType.StoredProcedure, "CS_Proc_S_WODetail_First", parm);
    }

    public void U_OperatorInfo_junfen(string WO_Num, Guid pbcid, int OI_ProNum)//客户均分随工单作业员计件
    {
        SqlParameter[] parm = new SqlParameter[3];
        parm[0] = new SqlParameter("@WO_Num", SqlDbType.VarChar, 30);
        parm[0].Value = WO_Num;
        parm[1] = new SqlParameter("@pbcid", SqlDbType.UniqueIdentifier);
        parm[1].Value = pbcid;
        parm[2] = new SqlParameter("@OI_ProNum", SqlDbType.Int);
        parm[2].Value = OI_ProNum;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
        CommandType.StoredProcedure, "CS_Proc_U_OperatorInfo_junfen", parm);
    }


    public DataSet CS_S_WorkOrder_YouWu(string WO_Num)//
    {
        SqlParameter[] parm = new SqlParameter[1];
        parm[0] = new SqlParameter("@WO_Num", SqlDbType.VarChar, 30);
        parm[0].Value = WO_Num;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
        CommandType.StoredProcedure, "CS_Proc_S_WorkOrder_YouWu", parm);
    }
    public void CS_U_OperatorInfo_bufenjunfen(Guid OI_ID, int OI_ProNum)//客户部分均分随工单作业员计件
    {
        SqlParameter[] parm = new SqlParameter[2];
        parm[0] = new SqlParameter("@OI_ID", SqlDbType.UniqueIdentifier);
        parm[0].Value = OI_ID;
        parm[1] = new SqlParameter("@OI_ProNum", SqlDbType.Int);
        parm[1].Value = OI_ProNum;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "CS_Proc_U_OperatorInfo_bufenjunfen", parm);
    }

    public DataSet Cs_s_workorder_weiwangonggongxu_new(string WO_Num, string pbc_name)//判断是否有未完工的工序
    {
        SqlParameter[] parm = new SqlParameter[2];
        parm[0] = new SqlParameter("@WO_Num", SqlDbType.VarChar, 30);
        parm[0].Value = WO_Num;
        parm[1] = new SqlParameter("@pbc_name", SqlDbType.VarChar, 60);
        parm[1].Value = pbc_name;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
        CommandType.StoredProcedure, "Cs_proc_s_workorder_weiwangonggongxu_new", parm);
    }

    public DataSet CS_S_WODetail_haiyouweiwangong_NEW(string WO_Num, Guid pbcid)//CS端查找判断本工序前是否有未完工的工序
    {
        SqlParameter[] parm = new SqlParameter[2];
        parm[0] = new SqlParameter("@WO_Num", SqlDbType.VarChar, 30);
        parm[0].Value = WO_Num;
        parm[1] = new SqlParameter("@pbcid", SqlDbType.UniqueIdentifier);
        parm[1].Value = pbcid;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
        CommandType.StoredProcedure, "CS_Proc_S_WODetail_haiyouweiwangong_NEW", parm);
    }


    public DataSet CS_s_workorder(string wO_Num, string pbcname)//客户端扫描随工单信息
    {
        SqlParameter[] para = new SqlParameter[2];
        para[0] = new SqlParameter("@WO_Num", SqlDbType.VarChar, 30);
        para[0].Value = wO_Num;
        para[1] = new SqlParameter("@pbcname", SqlDbType.VarChar, 30);
        para[1].Value = pbcname;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Cs_proc_s_workorder", para);

    }
    public DataSet CS_S_WOMBatchNum(string wO_Num)//客户端扫描随工单信息
    {
        SqlParameter[] para = new SqlParameter[1];
        para[0] = new SqlParameter("@WO_Num", SqlDbType.VarChar, 30);
        para[0].Value = wO_Num;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Cs_Proc_S_WOMBatchNum", para);

    }
    public void CS_I_WorkOrderDetail(string wO_Num, string pBC_Name, string wOD_WOState, int wOD_PNum)//客户端工序开启
    {
        SqlParameter[] parm = new SqlParameter[4];
        parm[0] = new SqlParameter("@WO_Num", SqlDbType.VarChar, 30);
        parm[0].Value = wO_Num;
        parm[1] = new SqlParameter("@PBC_Name", SqlDbType.VarChar, 30);
        parm[1].Value = pBC_Name;
        parm[2] = new SqlParameter("@WOD_WOState", SqlDbType.VarChar, 20);
        parm[2].Value = wOD_WOState;
        parm[3] = new SqlParameter("@WOD_PNum", SqlDbType.Int);
        parm[3].Value = wOD_PNum;

        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Cs_Proc_I_WorkOrderDetail", parm);
    }
    public DataSet CS_S_WorkOrderDetail(string wO_Num, string pBC_name)//客户端扫描随工单信息
    {
        SqlParameter[] para = new SqlParameter[2];
        para[0] = new SqlParameter("@WO_Num", SqlDbType.VarChar, 30);
        para[0].Value = wO_Num;
        para[1] = new SqlParameter("@PBC_Name", SqlDbType.VarChar, 30);
        para[1].Value = pBC_name;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Cs_Proc_S_WorkOrderDetail", para);

    }
    public DataSet CS_S_WorkOrderDetail_HP(string condition)//领半成品信息
    {
        SqlParameter[] para = new SqlParameter[1];
        para[0] = new SqlParameter("@condition", SqlDbType.VarChar, 2000);
        para[0].Value = condition;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Cs_Proc_S_WorkOrderDetail_HP", para);

    }

    public void CS_i_semifinished(Guid wOD_ID, string sF_People, string sF_PBC)//客户端工序开启
    {
        SqlParameter[] parm = new SqlParameter[3];
        parm[0] = new SqlParameter("@WOD_ID", SqlDbType.UniqueIdentifier);
        parm[0].Value = wOD_ID;
        parm[1] = new SqlParameter("@SF_People", SqlDbType.VarChar, 20);
        parm[1].Value = sF_People;
        parm[2] = new SqlParameter("@SF_PBC", SqlDbType.VarChar, 30);
        parm[2].Value = sF_PBC;


        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "CS_proc_i_semifinished", parm);
    }
    public DataSet CS_S_semifinished_panchong(Guid wOD_ID)//领半成品判重
    {
        SqlParameter[] para = new SqlParameter[1];
        para[0] = new SqlParameter("@WOD_ID", SqlDbType.UniqueIdentifier);
        para[0].Value = wOD_ID;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "CS_proc_S_semifinished_panchong", para);

    }

    public void CS_I_WorkOrderDetail_BadProduct(string pBC_Name, string wO_Num, string wOBP_Type, int wOBP_Num)//客户端随工单不良品信息录入
    {
        SqlParameter[] parm = new SqlParameter[4];
        parm[0] = new SqlParameter("@PBC_Name", SqlDbType.VarChar, 30);
        parm[0].Value = pBC_Name;
        parm[1] = new SqlParameter("@WO_Num ", SqlDbType.VarChar, 30);
        parm[1].Value = wO_Num;
        parm[2] = new SqlParameter("@WOBP_Type", SqlDbType.VarChar, 30);
        parm[2].Value = wOBP_Type;
        parm[3] = new SqlParameter("@WOBP_Num", SqlDbType.Int);
        parm[3].Value = wOBP_Num;

        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Cs_Proc_I_WorkOrderDetail_BadProduct", parm);
    }

    public void CS_I_WorkOrderDetail_Equipment(Guid eI_ID, string pBC_Name, string wO_Num)//客户端随工单设备信息录入
    {
        SqlParameter[] parm = new SqlParameter[3];
        parm[0] = new SqlParameter("@EI_ID", SqlDbType.UniqueIdentifier);
        parm[0].Value = eI_ID;
        parm[1] = new SqlParameter("@PBC_Name ", SqlDbType.VarChar, 30);
        parm[1].Value = pBC_Name;
        parm[2] = new SqlParameter("@WO_Num", SqlDbType.VarChar, 30);
        parm[2].Value = wO_Num;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Cs_Proc_I_WorkOrderDetail_Equipment", parm);
    }

    public void CS_I_WorkOrderDetail_Level(string pBC_Name, string wO_Num, int wOL_Num, Guid pCI_ID)//客户端随工单分档信息录入
    {
        SqlParameter[] parm = new SqlParameter[3];
        parm[0] = new SqlParameter("@PBC_Name ", SqlDbType.VarChar, 30);
        parm[0].Value = pBC_Name;
        parm[1] = new SqlParameter("@WO_Num", SqlDbType.VarChar, 30);
        parm[1].Value = wO_Num;
        parm[2] = new SqlParameter("@WOL_Num", SqlDbType.Int);
        parm[2].Value = wOL_Num;
        parm[3] = new SqlParameter("@PCI_ID", SqlDbType.Int);
        parm[3].Value = pCI_ID;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "CS_Proc_I_WorkOrderDetail_Level", parm);
    }

    public DataSet CS_S_WorkOrderDetail_BadProduct(string wO_Num, string pBC_name)//客户端显示随工单某工序的不良品信息
    {
        SqlParameter[] para = new SqlParameter[2];
        para[0] = new SqlParameter("@WO_Num", SqlDbType.VarChar, 30);
        para[0].Value = wO_Num;
        para[1] = new SqlParameter("@PBC_Name", SqlDbType.VarChar, 30);
        para[1].Value = pBC_name;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Cs_Proc_S_WorkOrderDetail_BadProduct", para);

    }

    public DataSet CS_S_WorkOrderDetail_BadProduct2(Guid WOD_ID, Guid PBC_ID)//客户端显示随工单某工序的不良品信息
    {
        SqlParameter[] para = new SqlParameter[2];
        para[0] = new SqlParameter("@WOD_ID", SqlDbType.UniqueIdentifier);
        para[0].Value = WOD_ID;
        para[1] = new SqlParameter("@PBC_ID", SqlDbType.UniqueIdentifier);
        para[1].Value = PBC_ID;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Cs_Proc_S_WorkOrderDetail_BadProduct2", para);

    }
    public DataSet CS_S_WorkOrderDetail_Equipment(string wO_Num, string pBC_name)//客户端显示随工单某工序的设备信息
    {
        SqlParameter[] para = new SqlParameter[2];
        para[0] = new SqlParameter("@WO_Num", SqlDbType.VarChar, 30);
        para[0].Value = wO_Num;
        para[1] = new SqlParameter("@PBC_Name", SqlDbType.VarChar, 30);
        para[1].Value = pBC_name;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Cs_Proc_S_WorkOrderDetail_Equipment", para);

    }
    public DataSet CS_S_WorkOrderDetail_Level(string wO_Num, string pBC_name)//客户端显示随工单某工序的分档信息
    {
        SqlParameter[] para = new SqlParameter[2];
        para[0] = new SqlParameter("@WO_Num", SqlDbType.VarChar, 30);
        para[0].Value = wO_Num;
        para[1] = new SqlParameter("@PBC_Name", SqlDbType.VarChar, 30);
        para[1].Value = pBC_name;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Cs_Proc_S_WorkOrderDetail_Level", para);

    }
    public void CS_U_WorkOrderDetail_Basic(Guid wOD_ID, int wOD_InNum, int wOD_QNum, decimal wOD_QRate)//客户端投入数、合格数信息录入
    {
        SqlParameter[] parm = new SqlParameter[4];
        parm[0] = new SqlParameter("@WOD_ID ", SqlDbType.UniqueIdentifier);
        parm[0].Value = wOD_ID;
        parm[1] = new SqlParameter("@WOD_InNum", SqlDbType.Int);
        parm[1].Value = wOD_InNum;
        parm[2] = new SqlParameter("@WOD_QNum", SqlDbType.Int);
        parm[2].Value = wOD_QNum;
        parm[3] = new SqlParameter("@WOD_QRate", SqlDbType.Decimal);
        parm[3].Value = wOD_QRate;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Cs_Proc_U_WorkOrderDetail_Basic", parm);
    }
    public DataSet CS_S_WODetail_EquipmentInf(string condition)//客户端为随工单选择设备
    {
        SqlParameter[] para = new SqlParameter[1];
        para[0] = new SqlParameter("@condition", SqlDbType.VarChar, 2000);
        para[0].Value = condition;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Cs_Proc_S_WODetail_EquipmentInf", para);

    }
    public DataSet CS_S_WODetail_Equipment_panchong(Guid eI_ID, string pbcname, string wonum)//客户端为随工单选择设备
    {
        SqlParameter[] para = new SqlParameter[3];
        para[0] = new SqlParameter("@EI_ID", SqlDbType.UniqueIdentifier);
        para[0].Value = eI_ID;
        para[1] = new SqlParameter("@PBC_Name", SqlDbType.VarChar, 30);
        para[1].Value = pbcname;
        para[2] = new SqlParameter("@WO_Num", SqlDbType.VarChar, 30);
        para[2].Value = wonum;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "CS_Proc_S_WODetail_Equipment_panchong", para);

    }
    public void CS_D_WODetail_Equipment(Guid wOE_ID)//删除随工单设备信息
    {
        SqlParameter[] parm = new SqlParameter[1];
        parm[0] = new SqlParameter("@WOE_ID", SqlDbType.UniqueIdentifier);
        parm[0].Value = wOE_ID;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "CS_Proc_D_WODetail_Equipment", parm);
    }

    public DataSet CS_S_WOMBatchNum_IMInventoryDetail(string condition)//客户端查待选物料批号信息查看
    {
        SqlParameter[] para = new SqlParameter[1];
        para[0] = new SqlParameter("@condition", SqlDbType.VarChar, 2000);
        para[0].Value = condition;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "CS_Proc_S_WOMBatchNum_IMInventoryDetail", para);

    }
    public DataSet S_WorkOrderDetail_ErrorCheck(string condition, string pbcname)//客户端所在工序随工单列表
    {
        SqlParameter[] para = new SqlParameter[2];
        para[0] = new SqlParameter("@condition", SqlDbType.VarChar, 2000);
        para[0].Value = condition;
        para[1] = new SqlParameter("@PBC_Name", SqlDbType.VarChar, 30);
        para[1].Value = pbcname;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Cs_Proc_S_WorkOrderDetail_ErrorCheck", para);

    }


    public DataSet CS_S_S_WorkOrderDetail_Overtime(string wO_Num, string pBC_name)//客户端显示随工单超时原因表
    {
        SqlParameter[] para = new SqlParameter[2];
        para[0] = new SqlParameter("@WO_Num", SqlDbType.VarChar, 30);
        para[0].Value = wO_Num;
        para[1] = new SqlParameter("@PBC_Name", SqlDbType.VarChar, 30);
        para[1].Value = pBC_name;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Cs_Proc_S_WorkOrderDetail_Overtime", para);

    }
    public DataSet CS_S_OverTimeOption_OTO_Name()//客户端dropdownlist超时原因选项
    {

        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "CS_Proc_S_OverTimeOption_OTO_Name", null);

    }
    public void CS_I_WorkOrderDetail_WOOverTime(Guid oTO_ID, string pbcname, string wOOT_Detail, string wOOT_Error, string wOOT_People, string wO_Num)//客户端随工单超时信息录入
    {
        SqlParameter[] parm = new SqlParameter[6];
        parm[0] = new SqlParameter("@OTO_ID", SqlDbType.UniqueIdentifier);
        parm[0].Value = oTO_ID;
        parm[1] = new SqlParameter("@pbcname", SqlDbType.VarChar, 30);
        parm[1].Value = pbcname;
        parm[2] = new SqlParameter("@WOOT_Detail", SqlDbType.VarChar, 400);
        parm[2].Value = wOOT_Detail;
        parm[3] = new SqlParameter("@WOOT_Error", SqlDbType.Char, 2);
        parm[3].Value = wOOT_Error;
        parm[4] = new SqlParameter("@WOOT_People", SqlDbType.VarChar, 20);
        parm[4].Value = wOOT_People;
        parm[5] = new SqlParameter("@WO_Num", SqlDbType.VarChar, 30);
        parm[5].Value = wO_Num;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Cs_Proc_I_WorkOrderDetail_WOOverTime", parm);
    }

    public DataSet CS_S_WorkOrderDetail_WOError(string wO_Num, string pBC_name)//客户端显示随工单异常信息
    {
        SqlParameter[] para = new SqlParameter[2];
        para[0] = new SqlParameter("@WO_Num", SqlDbType.VarChar, 30);
        para[0].Value = wO_Num;
        para[1] = new SqlParameter("@PBC_Name", SqlDbType.VarChar, 30);
        para[1].Value = pBC_name;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Cs_Proc_S_WorkOrderDetail_WOError", para);

    }
    public DataSet CS_Proc_S_ErrorPhenomenonOption_EPO_Name()//客户端dropdownlist异常现象选项
    {

        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "CS_Proc_S_ErrorPhenomenonOption_EPO_Name", null);

    }

    public void CS_U__WOError_apply(Guid wOE_ID, Guid ePO_ID, string wOE_Detail, string wOE_QOption, string wOE_People)//客户端编辑异常申报信息
    {
        SqlParameter[] parm = new SqlParameter[5];
        parm[0] = new SqlParameter("@WOE_ID", SqlDbType.UniqueIdentifier);
        parm[0].Value = wOE_ID;
        parm[1] = new SqlParameter("@EPO_ID", SqlDbType.UniqueIdentifier);
        parm[1].Value = ePO_ID;
        parm[2] = new SqlParameter("@WOE_Detail", SqlDbType.VarChar, 400);
        parm[2].Value = wOE_Detail;
        parm[3] = new SqlParameter("@WOE_QOption", SqlDbType.VarChar, 30);
        parm[3].Value = wOE_QOption;
        parm[4] = new SqlParameter("@WOE_People", SqlDbType.VarChar, 20);
        parm[4].Value = wOE_People;

        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "CS_Proc_U__WOError_apply", parm);
    }
    public void CS_I__WOError_apply(Guid ePO_ID, string wOE_Detail, string wOE_QOption, string wOE_People, string pbcname, string wonum)//客户端新增异常申报信息
    {
        SqlParameter[] parm = new SqlParameter[6];
        parm[0] = new SqlParameter("@EPO_ID", SqlDbType.UniqueIdentifier);
        parm[0].Value = ePO_ID;
        parm[1] = new SqlParameter("@WOE_Detail", SqlDbType.VarChar, 400);
        parm[1].Value = wOE_Detail;
        parm[2] = new SqlParameter("@WOE_QOption", SqlDbType.VarChar, 30);
        parm[2].Value = wOE_QOption;
        parm[3] = new SqlParameter("@WOE_People", SqlDbType.VarChar, 20);
        parm[3].Value = wOE_People;
        parm[4] = new SqlParameter("@WO_Num", SqlDbType.VarChar, 30);
        parm[4].Value = wonum;
        parm[5] = new SqlParameter("@pbcname", SqlDbType.VarChar, 30);
        parm[5].Value = pbcname;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "CS_Proc_I__WOError_apply", parm);
    }
    public void CS_U__WOError_Recieve(Guid wOE_ID, string wOE_Type, string wOE_Dep, string wOE_NeedMQC, string wOE_Measure, string wOE_ReceivePeople)//客户端编辑异常申报信息
    {
        SqlParameter[] parm = new SqlParameter[6];
        parm[0] = new SqlParameter("@WOE_ID", SqlDbType.UniqueIdentifier);
        parm[0].Value = wOE_ID;
        parm[1] = new SqlParameter("@WOE_Type", SqlDbType.VarChar, 30);
        parm[1].Value = wOE_Type;
        parm[2] = new SqlParameter("@WOE_Dep", SqlDbType.VarChar, 60);
        parm[2].Value = wOE_Dep;
        parm[3] = new SqlParameter("@WOE_NeedMQC", SqlDbType.Char, 2);
        parm[3].Value = wOE_NeedMQC;
        parm[4] = new SqlParameter("@WOE_Measure", SqlDbType.VarChar, 400);
        parm[4].Value = wOE_Measure;
        parm[5] = new SqlParameter("@WOE_ReceivePeople", SqlDbType.VarChar, 20);
        parm[5].Value = wOE_ReceivePeople;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "CS_Proc_U__WOError_Recieve", parm);
    }

    public DataSet CS_S_WorkOrderDetail_Error_Recieve(string wO_Num, string pBC_name)//客户端显示随工单异常接受信息
    {
        SqlParameter[] para = new SqlParameter[2];
        para[0] = new SqlParameter("@WO_Num", SqlDbType.VarChar, 30);
        para[0].Value = wO_Num;
        para[1] = new SqlParameter("@PBC_Name", SqlDbType.VarChar, 30);
        para[1].Value = pBC_name;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Cs_Proc_S_WorkOrderDetail_Error_Recieve", para);

    }


    public void CS_U_WOOverTime(Guid wOOT_ID, Guid oTO_ID, string wOOT_Detail, string wOOT_Error, string wOOT_People)//客户端编辑超时信息
    {
        SqlParameter[] parm = new SqlParameter[5];
        parm[0] = new SqlParameter("@WOOT_ID", SqlDbType.UniqueIdentifier);
        parm[0].Value = wOOT_ID;
        parm[1] = new SqlParameter("@OTO_ID", SqlDbType.UniqueIdentifier);
        parm[1].Value = oTO_ID;
        parm[2] = new SqlParameter("@WOOT_Detail", SqlDbType.VarChar, 400);
        parm[2].Value = wOOT_Detail;
        parm[3] = new SqlParameter("@WOOT_Error", SqlDbType.Char, 2);
        parm[3].Value = wOOT_Error;
        parm[4] = new SqlParameter("@WOOT_People", SqlDbType.VarChar, 20);
        parm[4].Value = wOOT_People;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "CS_Proc_U_WOOverTime", parm);
    }

    public void CS_D_WOOverTime(Guid wOOT_ID)//客户端删除超时信息
    {
        SqlParameter[] parm = new SqlParameter[1];
        parm[0] = new SqlParameter("@WOOT_ID", SqlDbType.UniqueIdentifier);
        parm[0].Value = wOOT_ID;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "CS_Proc_D_WOOverTime", parm);
    }
    public void CS_D_WOError(Guid wOE_ID)//客户端删除异常信息
    {
        SqlParameter[] parm = new SqlParameter[1];
        parm[0] = new SqlParameter("@WOE_ID", SqlDbType.UniqueIdentifier);
        parm[0].Value = wOE_ID;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "CS_Proc_D_WOError", parm);
    }

    public void CS_I_WorkOrderDetail_WOMBatchNum(Guid iMMBD_MaterialID, string wO_Num, string wOMBN_BN)//客户端随工单批号信息录入
    {
        SqlParameter[] parm = new SqlParameter[3];
        parm[0] = new SqlParameter("@IMMBD_MaterialID", SqlDbType.UniqueIdentifier);
        parm[0].Value = iMMBD_MaterialID;
        parm[1] = new SqlParameter("@WO_Num", SqlDbType.VarChar, 30);
        parm[1].Value = wO_Num;
        parm[2] = new SqlParameter("@WOMBN_BN", SqlDbType.VarChar, 30);
        parm[2].Value = wOMBN_BN;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "CS_Proc_I_WorkOrderDetail_WOMBatchNum", parm);
    }

    public void CS_D_WODetail_WOMBatchNum(Guid wOMBN_ID)//客户端删除随工单批号信息
    {
        SqlParameter[] parm = new SqlParameter[1];
        parm[0] = new SqlParameter("@WOMBN_ID", SqlDbType.UniqueIdentifier);
        parm[0].Value = wOMBN_ID;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "CS_Proc_D_WODetail_WOMBatchNum", parm);
    }

    public void CS_I_WOBadPro(string wonum, string pbc_name, string wOBP_Type, int wOBP_Num)//客户端制定不良品信息
    {
        SqlParameter[] parm = new SqlParameter[4];
        parm[0] = new SqlParameter("@WO_Num", SqlDbType.VarChar, 30);
        parm[0].Value = wonum;
        parm[1] = new SqlParameter("@pbcname", SqlDbType.VarChar, 30);
        parm[1].Value = pbc_name;
        parm[2] = new SqlParameter("@WOBP_Type", SqlDbType.VarChar, 30);
        parm[2].Value = wOBP_Type;
        parm[3] = new SqlParameter("@WOBP_Num", SqlDbType.Int);
        parm[3].Value = wOBP_Num;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "CS_Proc_I_WOBadPro", parm);
    }

    public void CS_I_WOBadPro2(Guid wodid, string wOBP_Type, int wOBP_Num)//客户端制定不良品信息
    {
        SqlParameter[] parm = new SqlParameter[3];
        parm[0] = new SqlParameter("@wodid", SqlDbType.UniqueIdentifier);
        parm[0].Value = wodid;
        parm[1] = new SqlParameter("@WOBP_Type", SqlDbType.VarChar, 30);
        parm[1].Value = wOBP_Type;
        parm[2] = new SqlParameter("@WOBP_Num", SqlDbType.Int);
        parm[2].Value = wOBP_Num;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "CS_Proc_I_WOBadPro2", parm);
    }

    public DataSet CS_S_WOBadPro_panchong(string wOBP_Type, string pbcname, string wonum)//客户端不良品信息判重
    {
        SqlParameter[] para = new SqlParameter[3];
        para[0] = new SqlParameter("@WOBP_Type ", SqlDbType.VarChar, 30);
        para[0].Value = wOBP_Type;
        para[1] = new SqlParameter("@PBC_Name", SqlDbType.VarChar, 30);
        para[1].Value = pbcname;
        para[2] = new SqlParameter("@WO_Num", SqlDbType.VarChar, 30);
        para[2].Value = wonum;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "CS_Proc_S_WOBadPro_panchong", para);

    }

    public DataSet CS_S_WOBadPro_panchong2(string wOBP_Type, Guid WOD_ID)//客户端不良品信息判重
    {
        SqlParameter[] para = new SqlParameter[2];
        para[0] = new SqlParameter("@WOBP_Type ", SqlDbType.VarChar, 30);
        para[0].Value = wOBP_Type;
        para[1] = new SqlParameter("@WOD_ID", SqlDbType.UniqueIdentifier);
        para[1].Value = WOD_ID;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "CS_Proc_S_WOBadPro_panchong2", para);

    }

    public void CS_U_WOBadPro(Guid wOBP_ID, int wOBP_Num)//客户端编辑不良品信息
    {
        SqlParameter[] parm = new SqlParameter[2];
        parm[0] = new SqlParameter("@WOBP_ID", SqlDbType.UniqueIdentifier);
        parm[0].Value = wOBP_ID;
        parm[1] = new SqlParameter("@WOBP_Num", SqlDbType.Int);
        parm[1].Value = wOBP_Num;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "CS_Proc_U_WOBadPro", parm);
    }

    public void CS_U_WOLevel(Guid wOL_ID, int wOL_Num)//客户端编辑分档信息
    {
        SqlParameter[] parm = new SqlParameter[2];
        parm[0] = new SqlParameter("@WOL_ID", SqlDbType.UniqueIdentifier);
        parm[0].Value = wOL_ID;
        parm[1] = new SqlParameter("@WOL_Num", SqlDbType.Int);
        parm[1].Value = wOL_Num;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "CS_Proc_U_WOLevel", parm);
    }

    public DataSet CS_S_WOLevel_panchong(Guid pCI_ID, string pbcname, string wonum)//客户端分档信息判重
    {
        SqlParameter[] para = new SqlParameter[3];
        para[0] = new SqlParameter("@PCI_ID ", SqlDbType.UniqueIdentifier);
        para[0].Value = pCI_ID;
        para[1] = new SqlParameter("@PBC_Name", SqlDbType.VarChar, 30);
        para[1].Value = pbcname;
        para[2] = new SqlParameter("@WO_Num", SqlDbType.VarChar, 30);
        para[2].Value = wonum;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "CS_Proc_S_WOLevel_panchong", para);

    }

    public void CS_I_WOLevel(string wonum, string pbc_name, Guid pCI_ID, int wOL_Num)//客户端制定分档信息
    {
        SqlParameter[] parm = new SqlParameter[4];
        parm[0] = new SqlParameter("@WO_Num", SqlDbType.VarChar, 30);
        parm[0].Value = wonum;
        parm[1] = new SqlParameter("@pbcname", SqlDbType.VarChar, 30);
        parm[1].Value = pbc_name;
        parm[2] = new SqlParameter("@PCI_ID", SqlDbType.UniqueIdentifier);
        parm[2].Value = pCI_ID;
        parm[3] = new SqlParameter("@WOL_Num", SqlDbType.Int);
        parm[3].Value = wOL_Num;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "CS_Proc_I_WOLevel", parm);
    }

    public DataSet CS_S_WorkOrderDetail_OperatorInfo(string wO_Num, string pBC_name)//客户端显示随工单作业员信息
    {
        SqlParameter[] para = new SqlParameter[2];
        para[0] = new SqlParameter("@WO_Num", SqlDbType.VarChar, 30);
        para[0].Value = wO_Num;
        para[1] = new SqlParameter("@PBC_Name", SqlDbType.VarChar, 30);
        para[1].Value = pBC_name;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Cs_Proc_S_WorkOrderDetail_OperatorInfo", para);

    }

    public void CS_D_OperatorInfo(Guid oI_ID)//客户端删除作业员信息
    {
        SqlParameter[] parm = new SqlParameter[1];
        parm[0] = new SqlParameter("@OI_ID", SqlDbType.UniqueIdentifier);
        parm[0].Value = oI_ID;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "CS_Proc_D_OperatorInfo", parm);
    }


    public DataSet CS_S_WorkingTeam_Name()//客户端显示信息班组名称
    {

        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Cs_Proc_S_WorkingTeam_Name", null);

    }
    public DataSet CS_S_WorkingTeam_Name_zhuangpei()//客户端显示信息班组名称
    {

        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "CS_S_WorkingTeam_Name_zhuangpei", null);

    }

    public DataSet Cs_S_WorkTeamDetailList(string contition)//客户端显示信息班组名称
    {
        SqlParameter[] parm = new SqlParameter[1];
        parm[0] = new SqlParameter("@condition", SqlDbType.VarChar, 2000);
        parm[0].Value = contition;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Cs_Proc_S_WorkTeamDetailList", parm);

    }

    public DataSet CS_S_HRDDetail_people(string contition)//客户端显示所有待选员工
    {
        SqlParameter[] parm = new SqlParameter[1];
        parm[0] = new SqlParameter("@condition", SqlDbType.VarChar, 2000);
        parm[0].Value = contition;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Cs_Proc_S_HRDDetail_people", parm);

    }

    public void CS_I_WorkOrderDetail_OperatorInfo(string wonum, string pbc_name, Guid hRDD_ID)//客户端随工单作业员信息录入
    {
        SqlParameter[] parm = new SqlParameter[3];
        parm[0] = new SqlParameter("@WO_Num", SqlDbType.VarChar, 30);
        parm[0].Value = wonum;
        parm[1] = new SqlParameter("@PBC_Name", SqlDbType.VarChar, 30);
        parm[1].Value = pbc_name;
        parm[2] = new SqlParameter("@HRDD_ID", SqlDbType.UniqueIdentifier);
        parm[2].Value = hRDD_ID;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Cs_Proc_I_WorkOrderDetail_OperatorInfo", parm);
    }

    public void Cs_I_WorkOrderDetail_OperatorInfo_New(Guid WOD_ID, Guid hRDD_ID)//客户端随工单作业员信息录入
    {
        SqlParameter[] parm = new SqlParameter[2];
        parm[0] = new SqlParameter("@WOD_ID", SqlDbType.UniqueIdentifier);
        parm[0].Value = WOD_ID;
        parm[1] = new SqlParameter("@HRDD_ID", SqlDbType.UniqueIdentifier);
        parm[1].Value = hRDD_ID;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Cs_Proc_I_WorkOrderDetail_OperatorInfo_New", parm);
    }

    public void CS_U_OperatorInfo(Guid oI_ID, int oI_ProNum)//客户端计件信息
    {
        SqlParameter[] parm = new SqlParameter[2];
        parm[0] = new SqlParameter("@OI_ID", SqlDbType.UniqueIdentifier);
        parm[0].Value = oI_ID;
        parm[1] = new SqlParameter("@OI_ProNum", SqlDbType.Int);
        parm[1].Value = oI_ProNum;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "CS_Proc_U_OperatorInfo", parm);
    }


    public DataSet CS_S_WorkOrderDetail_OTime(Guid oI_ID)//客户端显示作业员计时信息
    {
        SqlParameter[] parm = new SqlParameter[1];
        parm[0] = new SqlParameter("@OI_ID", SqlDbType.UniqueIdentifier);
        parm[0].Value = oI_ID;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Cs_Proc_S_WorkOrderDetail_OTime", parm);

    }

    public DataSet CS_S_SalaryTimeItem_PBC_CraftInfo(string contition)//客户端显示某工序所有计时信息
    {
        SqlParameter[] parm = new SqlParameter[1];
        parm[0] = new SqlParameter("@condition", SqlDbType.VarChar, 2000);
        parm[0].Value = contition;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "CS_Proc_S_SalaryTimeItem_PBC_CraftInfo", parm);

    }

    public void CS_I_WorkOrderDetail_OTime(Guid oI_ID, Guid sTI_ID)//客户端随工单作业员计时录入
    {
        SqlParameter[] parm = new SqlParameter[2];
        parm[0] = new SqlParameter("@OI_ID", SqlDbType.UniqueIdentifier);
        parm[0].Value = oI_ID;
        parm[1] = new SqlParameter("@STI_ID", SqlDbType.UniqueIdentifier);
        parm[1].Value = sTI_ID;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Cs_Proc_I_WorkOrderDetail_OTime", parm);
    }

    public void CS_D_WODetail_OTime(Guid oT_ID)//删除某人的计时项目
    {
        SqlParameter[] parm = new SqlParameter[1];
        parm[0] = new SqlParameter("@OT_ID", SqlDbType.UniqueIdentifier);
        parm[0].Value = oT_ID;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "CS_Proc_D_WODetail_OTime", parm);
    }

    public void CS_U_OTime(Guid oT_ID, decimal oT_Time)//客户端编辑计时信息
    {
        SqlParameter[] parm = new SqlParameter[2];
        parm[0] = new SqlParameter("@OT_ID", SqlDbType.UniqueIdentifier);
        parm[0].Value = oT_ID;
        parm[1] = new SqlParameter("@OT_Time", SqlDbType.Decimal, 18);
        parm[1].Value = oT_Time;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "CS_Proc_U_OTime", parm);
    }
    public DataSet CS_S_WODetail__Num(string wO_Num, string pBC_name)//客户端显示随工单在某工序的数量信息
    {
        SqlParameter[] para = new SqlParameter[2];
        para[0] = new SqlParameter("@WO_Num", SqlDbType.VarChar, 30);
        para[0].Value = wO_Num;
        para[1] = new SqlParameter("@PBC_Name", SqlDbType.VarChar, 30);
        para[1].Value = pBC_name;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "CS_Proc_S_WODetail__Num", para);

    }
    public void CS_U_WorkOrderDetail_Finish(string wOD_WOState, string pbcname, string wonum, int zuihou)//客户端工序完工
    {
        SqlParameter[] para = new SqlParameter[4];
        para[0] = new SqlParameter("@WOD_WOState ", SqlDbType.VarChar, 60);
        para[0].Value = wOD_WOState;
        para[1] = new SqlParameter("@PBC_Name", SqlDbType.VarChar, 30);
        para[1].Value = pbcname;
        para[2] = new SqlParameter("@WO_Num", SqlDbType.VarChar, 30);
        para[2].Value = wonum;
        para[3] = new SqlParameter("@zuihou", SqlDbType.Int);
        para[3].Value = zuihou;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "CS_Proc_U_WorkOrderDetail_Finish", para);

    }

    public DataSet CS_S_WorkOrderDetail_FinishState(string pbcname, string wonum)//客户端工序完工状态判重
    {
        SqlParameter[] para = new SqlParameter[2];
        para[0] = new SqlParameter("@PBC_Name", SqlDbType.VarChar, 30);
        para[0].Value = pbcname;
        para[1] = new SqlParameter("@WO_Num", SqlDbType.VarChar, 30);
        para[1].Value = wonum;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "CS_Proc_S_WorkOrderDetail_FinishState", para);

    }

    public DataSet CS_S_SemiFinished(Guid wOD_ID)//查看某工序半成品领用信息
    {
        SqlParameter[] para = new SqlParameter[1];
        para[0] = new SqlParameter("@WOD_ID ", SqlDbType.UniqueIdentifier);
        para[0].Value = wOD_ID;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Cs_Proc_S_SemiFinished", para);

    }


    public void Cs_U_SemiFinished(Guid sF_ID, int num)//修改领用信息
    {
        SqlParameter[] para = new SqlParameter[2];
        para[0] = new SqlParameter("@SF_ID ", SqlDbType.UniqueIdentifier);
        para[0].Value = sF_ID;
        para[1] = new SqlParameter("@SF_Num", SqlDbType.Int);
        para[1].Value = num;

        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Cs_Proc_U_SemiFinished", para);

    }

    public void Cs_D_SemiFinished(Guid sF_ID)//删除领用信息
    {
        SqlParameter[] para = new SqlParameter[1];
        para[0] = new SqlParameter("@SF_ID ", SqlDbType.UniqueIdentifier);
        para[0].Value = sF_ID;


        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Cs_Proc_D_SemiFinished", para);

    }

    public void CS_I_SemiFinished2(Guid wodid, string people, string pbcname, int num)//新增领用信息
    {
        SqlParameter[] parm = new SqlParameter[4];
        parm[0] = new SqlParameter("@WOD_ID", SqlDbType.UniqueIdentifier);
        parm[0].Value = wodid;
        parm[1] = new SqlParameter("@SF_People", SqlDbType.VarChar, 20);
        parm[1].Value = people;
        parm[2] = new SqlParameter("@SF_PBC", SqlDbType.VarChar, 30);
        parm[2].Value = pbcname;
        parm[3] = new SqlParameter("@SF_Num", SqlDbType.Int);
        parm[3].Value = num;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Cs_Proc_I_SemiFinished2", parm);
    }

    public DataSet CS_S_WODetail_PanDuanDaiKaiQiDeGongXu(string wonum)//CS端查找判断工艺路线中待开启的工序
    {
        SqlParameter[] para = new SqlParameter[1];
        para[0] = new SqlParameter("@WO_Num ", SqlDbType.VarChar, 30);
        para[0].Value = wonum;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "CS_Proc_S_WODetail_PanDuanDaiKaiQiDeGongXu", para);

    }

    public DataSet CS_S_WODetail_WOError_Num(string pBC_Name, string womum)//返回CS端某工序返工次数
    {
        SqlParameter[] para = new SqlParameter[2];
        para[0] = new SqlParameter("@PBC_Name ", SqlDbType.VarChar, 30);
        para[0].Value = pBC_Name;
        para[1] = new SqlParameter("@WO_Num ", SqlDbType.VarChar, 30);
        para[1].Value = womum;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "CS_Proc_S_WODetail_WOError_Num", para);

    }

    public DataSet CS_S_WODetail_ExistOrNot(string pBC_Name, string womum)//CS端检查某工序在详细表中是否有了
    {
        SqlParameter[] para = new SqlParameter[2];
        para[0] = new SqlParameter("@PBC_Name ", SqlDbType.VarChar, 30);
        para[0].Value = pBC_Name;
        para[1] = new SqlParameter("@WO_Num ", SqlDbType.VarChar, 30);
        para[1].Value = womum;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "CS_Proc_S_WODetail_ExistOrNot", para);

    }
    public DataSet CS_S_WODetail_ShiFouZaiRenZhenGongXuZhong(string pBC_Name, string womum)//CS端查找判断检验的随工单是否在“认证工序”中
    {
        SqlParameter[] para = new SqlParameter[2];
        para[0] = new SqlParameter("@PBC_Name ", SqlDbType.VarChar, 30);
        para[0].Value = pBC_Name;
        para[1] = new SqlParameter("@WO_Num ", SqlDbType.VarChar, 30);
        para[1].Value = womum;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "CS_Proc_S_WODetail_ShiFouZaiRenZhenGongXuZhong", para);

    }

    public DataSet CS_S_WODetail_RenZhenGongXuDaiKaiQi(string womum)//CS端查找判断检验的随工单的待开启工序
    {
        SqlParameter[] para = new SqlParameter[1];
        para[0] = new SqlParameter("@WO_Num ", SqlDbType.VarChar, 30);
        para[0].Value = womum;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "CS_Proc_S_WODetail_RenZhenGongXuDaiKaiQi", para);

    }

    public DataSet CS_S_WODetail_ShiFouZaiRenZhenGongYiLuXianZhong(string pBC_Name, string womum)//CS端查找判断检验的随工单是否在“认证工艺路线”中
    {
        SqlParameter[] para = new SqlParameter[2];
        para[0] = new SqlParameter("@PBC_Name ", SqlDbType.VarChar, 30);
        para[0].Value = pBC_Name;
        para[1] = new SqlParameter("@WO_Num ", SqlDbType.VarChar, 30);
        para[1].Value = womum;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "CS_Proc_S_WODetail_ShiFouZaiRenZhenGongYiLuXianZhong", para);

    }
    public DataSet CS_S_WODetail_RenZhenGongYiLuXianDaiKaiQi(string womum)//CS端查找判断检验的随工单在认证工艺路线中的待开启工序
    {
        SqlParameter[] para = new SqlParameter[1];
        para[0] = new SqlParameter("@WO_Num ", SqlDbType.VarChar, 30);
        para[0].Value = womum;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "CS_Proc_S_WODetail_RenZhenGongYiLuXianDaiKaiQi", para);

    }

    public DataSet Cs_S_WorkOrderDetail_HeFa(string pBC_Name, string womum)//工序完工时检查输入信息是否合法,是否输入了投入数、合格数
    {
        SqlParameter[] para = new SqlParameter[2];
        para[0] = new SqlParameter("@pbcname ", SqlDbType.VarChar, 30);
        para[0].Value = pBC_Name;
        para[1] = new SqlParameter("@wonum ", SqlDbType.VarChar, 30);
        para[1].Value = womum;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Cs_Proc_S_WorkOrderDetail_HeFa", para);

    }

    public DataSet CS_S_WODetail_ZuiHouGongXu(string womum, int orrenzheng)//CS端查找判断工艺路线中最后一条工序
    {
        SqlParameter[] para = new SqlParameter[2];
        para[0] = new SqlParameter("@WO_Num ", SqlDbType.VarChar, 30);
        para[0].Value = womum;
        para[1] = new SqlParameter("@orrenzheng ", SqlDbType.Int);
        para[1].Value = orrenzheng;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "CS_Proc_S_WODetail_ZuiHouGongXu", para);

    }
    public DataSet Cs_S_WorkOrderDetail_PBCraftInfo(string pbcname)//CS查看当前工序的基础信息
    {
        SqlParameter[] para = new SqlParameter[1];
        para[0] = new SqlParameter("@pbcname ", SqlDbType.VarChar, 30);
        para[0].Value = pbcname;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Cs_Proc_S_WorkOrderDetail_PBCraftInfo", para);

    }

    public DataSet CS_S_WODetail_RenzhengHege(string womum)//认证时CS端是否认证合格继续生产
    {
        SqlParameter[] para = new SqlParameter[1];
        para[0] = new SqlParameter("@WO_Num ", SqlDbType.VarChar, 30);
        para[0].Value = womum;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "CS_Proc_S_WODetail_RenzhengHege", para);

    }

    public DataSet Cs_S_WorkOrderDetail_OperatorInfo_panding(Guid wOD_ID, Guid oI_ID)//客户端作业员数量判定
    {
        SqlParameter[] para = new SqlParameter[2];
        para[0] = new SqlParameter("@WOD_ID ", SqlDbType.UniqueIdentifier);
        para[0].Value = wOD_ID;
        para[1] = new SqlParameter("@OI_ID ", SqlDbType.UniqueIdentifier);
        para[1].Value = oI_ID;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Cs_Proc_S_WorkOrderDetail_OperatorInfo_panding", para);

    }

    public void CS_U_OverTime()//客户端超时触发
    {
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "CS_Proc_U_OverTime", null);

    }
    public DataSet Cs_s_workorder_weiwangonggongxu(string womum)//认证时CS客户端扫描随工单信息判断前面的工序是否有未完工的
    {
        SqlParameter[] para = new SqlParameter[1];
        para[0] = new SqlParameter("@WO_Num ", SqlDbType.VarChar, 30);
        para[0].Value = womum;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Cs_proc_s_workorder_weiwangonggongxu", para);

    }

    public DataSet Cs_Proc_S_WOError_HeFa(Guid wOE_ID)//异常申报删除判定，如果到异常接收那一步了则不能删除了
    {
        SqlParameter[] para = new SqlParameter[1];
        para[0] = new SqlParameter("@WOE_ID ", SqlDbType.UniqueIdentifier);
        para[0].Value = wOE_ID;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Cs_Proc_S_WOError_HeFa", para);

    }

    public DataSet CS_S_SalaryPieceworkItem_PBCraftInfo(Guid PBC_ID, string WO_Num)//客户端显示计件系列信息
    {
        SqlParameter[] parm = new SqlParameter[2];
        parm[0] = new SqlParameter("@PBC_ID ", SqlDbType.UniqueIdentifier);
        parm[0].Value = PBC_ID;
        parm[1] = new SqlParameter("@WO_Num", SqlDbType.VarChar, 30);
        parm[1].Value = WO_Num;
        return SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "CS_Proc_S_SalaryPieceworkItem_PBCraftInfo", parm);
    }

    public DataSet Cs_S_WorkOrderDetail_BadProduct_chouzoushuoming(string wO_Num, string pBC_name)//客户端显示随工单某工序的不良品信息
    {
        SqlParameter[] para = new SqlParameter[2];
        para[0] = new SqlParameter("@WO_Num", SqlDbType.VarChar, 30);
        para[0].Value = wO_Num;
        para[1] = new SqlParameter("@PBC_Name", SqlDbType.VarChar, 30);
        para[1].Value = pBC_name;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Cs_Proc_S_WorkOrderDetail_BadProduct_chouzoushuoming", para);

    }

    public void CS_I_WOBadPro_cz(string wonum, string pbc_name, string wOBP_Type, int wOBP_Num, string WOBP_Note)//客户端制定不良品信息
    {
        SqlParameter[] parm = new SqlParameter[5];
        parm[0] = new SqlParameter("@WO_Num", SqlDbType.VarChar, 30);
        parm[0].Value = wonum;
        parm[1] = new SqlParameter("@pbcname", SqlDbType.VarChar, 30);
        parm[1].Value = pbc_name;
        parm[2] = new SqlParameter("@WOBP_Type", SqlDbType.VarChar, 30);
        parm[2].Value = wOBP_Type;
        parm[3] = new SqlParameter("@WOBP_Num", SqlDbType.Int);
        parm[3].Value = wOBP_Num;
        parm[4] = new SqlParameter("@WOBP_Note", SqlDbType.VarChar, 400);
        parm[4].Value = WOBP_Note;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "CS_Proc_I_WOBadPro_cz", parm);
    }
    public void CS_U_WOBadPro_CZ(Guid wOBP_ID, int wOBP_Num, string WOBP_Note)//客户端编辑不良品信息
    {
        SqlParameter[] parm = new SqlParameter[3];
        parm[0] = new SqlParameter("@WOBP_ID", SqlDbType.UniqueIdentifier);
        parm[0].Value = wOBP_ID;
        parm[1] = new SqlParameter("@WOBP_Num", SqlDbType.Int);
        parm[1].Value = wOBP_Num;
        parm[2] = new SqlParameter("@WOBP_Note", SqlDbType.VarChar, 400);
        parm[2].Value = WOBP_Note;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "CS_Proc_U_WOBadPro_CZ", parm);
    }
    public void CS_U_OperatorInfo_new2(Guid OI_ID, int OI_ProNum, string OI_Type, Guid PieceItem_ID)//客户端随工单设备信息录入
    {
        SqlParameter[] parm = new SqlParameter[4];
        parm[0] = new SqlParameter("@OI_ID", SqlDbType.UniqueIdentifier);
        parm[0].Value = OI_ID;
        parm[1] = new SqlParameter("@OI_ProNum", SqlDbType.Int);
        parm[1].Value = OI_ProNum;
        parm[2] = new SqlParameter("@OI_Type", SqlDbType.VarChar, 20);
        parm[2].Value = OI_Type;
        parm[3] = new SqlParameter("@PieceItem_ID", SqlDbType.UniqueIdentifier);
        parm[3].Value = PieceItem_ID;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "CS_Proc_U_OperatorInfo_new2", parm);
    }

    public void CS_U_OperatorInfo_PieceItem_ID(Guid WOD_ID, string OI_Type, Guid PieceItem_ID)//
    {
        SqlParameter[] parm = new SqlParameter[3];
        parm[0] = new SqlParameter("@WOD_ID", SqlDbType.UniqueIdentifier);
        parm[0].Value = WOD_ID;
        parm[1] = new SqlParameter("@OI_Type", SqlDbType.VarChar, 20);
        parm[1].Value = OI_Type;
        parm[2] = new SqlParameter("@PieceItem_ID", SqlDbType.UniqueIdentifier);
        parm[2].Value = PieceItem_ID;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "CS_Proc_U_OperatorInfo_PieceItem_ID", parm);
    }

    public void CS_I_WOBadPro_cz2(Guid wodid, string wOBP_Type, int wOBP_Num,string WOBP_Note)//客户端制定不良品信息
    {
        SqlParameter[] parm = new SqlParameter[4];
        parm[0] = new SqlParameter("@wodid", SqlDbType.UniqueIdentifier);
        parm[0].Value = wodid;
        parm[1] = new SqlParameter("@WOBP_Type", SqlDbType.VarChar, 30);
        parm[1].Value = wOBP_Type;
        parm[2] = new SqlParameter("@WOBP_Num", SqlDbType.Int);
        parm[2].Value = wOBP_Num;
        parm[3] = new SqlParameter("@WOBP_Note", SqlDbType.VarChar,400);
        parm[3].Value = WOBP_Note;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "CS_Proc_I_WOBadPro_cz2", parm);
    }
}