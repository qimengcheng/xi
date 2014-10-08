using System;
using System.Data;
/// <summary>
///WorkOrderCheckL 的摘要说明
/// </summary>
public class WorkOrderCheckL
{
    private static readonly IWorkOrderCheck iwoc = DALFactory.CreateWorkOrderCheck();
	public WorkOrderCheckL()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    public DataSet S_WODetail_Num(Guid wOD_ID)//在制品查看显示随工单在某工序的数量信息

    {
        return iwoc.S_WODetail_Num(wOD_ID);
    }
    public DataSet S_WorkOrderDetail_Equipment(Guid wOD_ID)//在制品查看显示随工单某工序的设备信息

    {
        return iwoc.S_WorkOrderDetail_Equipment(wOD_ID);
    }
    public DataSet S_WorkOrder_WOMBatchNum(Guid wO_ID)//在制品查看显示随工单批号信息

    {
        return iwoc.S_WorkOrder_WOMBatchNum(wO_ID);
    }
    public DataSet S_WorkOrderDetail_BadProduct(Guid wOD_ID)//在制品查看显示随工单某工序的不良品信息
    {
        return iwoc.S_WorkOrderDetail_BadProduct(wOD_ID);
    }
    public DataSet S_WorkOrderDetail_Level(Guid wOD_ID)//在制品查看显示随工单某工序的分档信息
    {
        return iwoc.S_WorkOrderDetail_Level(wOD_ID);
    }

    public DataSet S_WorkOrderDetail_OperatorInfo(Guid wOD_ID)//在制品查看显示随工单作业员信息
    
    {
        return iwoc.S_WorkOrderDetail_OperatorInfo(wOD_ID);
    }
    public DataSet S_WorkOrderDetail_OTime(Guid oI_ID)//在制品查看显示作业员计时信息

    {
        return iwoc.S_WorkOrderDetail_OTime(oI_ID);
    }
    public DataSet S_WorkOrderDetail_Overtime(Guid wOD_ID)//在制品显示随工单超时原因表

    {
        return iwoc.S_WorkOrderDetail_Overtime(wOD_ID);
    }
    public void I_WorkOrder_Devide(Guid wO_ID, string wO_Num, string wO_ProType, int wO_PNum, string wO_Note, string wO_People)//随工单分单

    {
        iwoc.I_WorkOrder_Devide(wO_ID,wO_Num,wO_ProType,wO_PNum,wO_Note,wO_People);
    }
    public DataSet S_WorkOrder_Devide(string wO_Num)//随工单分单查询

    {
        return iwoc.S_WorkOrder_Devide(wO_Num);
    }
    public void D_WorkOrder_Devide(string wO_Num)//随工单删除分单
    {
        iwoc.D_WorkOrder_Devide(wO_Num);
    }
    public void U_WorkOrder_Devide(Guid wO_ID, int wO_PNum, string wO_Note)//编辑随工单分单计划数量

    {
        iwoc.U_WorkOrder_Devide(wO_ID, wO_PNum,wO_Note);
    }
    public void I_WorkOrder_Combine(string wO_Num, string wO_FatherNum, string wO_ProType, string wO_OrderNum, string wO_SN, string wO_Level, string wO_ChipNum, int wO_PNum, string wO_Note, string wO_People, string idstring)//随工单合单
    {
        iwoc.I_WorkOrder_Combine(wO_Num, wO_FatherNum, wO_ProType, wO_OrderNum, wO_SN, wO_Level, wO_ChipNum, wO_PNum, wO_Note, wO_People, idstring);
    }
}