using System;
using System.Data;

/// <summary>
///IWorkOrderCheck 的摘要说明
/// </summary>
public interface IWorkOrderCheck
{
    DataSet S_WODetail_Num(Guid wOD_ID);//在制品查看显示随工单在某工序的数量信息
    DataSet S_WorkOrderDetail_Equipment(Guid wOD_ID);//在制品查看显示随工单某工序的设备信息
    DataSet S_WorkOrder_WOMBatchNum(Guid wO_ID);//在制品查看显示随工单批号信息
    DataSet S_WorkOrderDetail_BadProduct(Guid wOD_ID);//在制品查看显示随工单某工序的不良品信息
    DataSet S_WorkOrderDetail_Level(Guid wOD_ID);//在制品查看显示随工单某工序的分档信息
    DataSet S_WorkOrderDetail_OperatorInfo(Guid wOD_ID);//在制品查看显示随工单作业员信息
    DataSet S_WorkOrderDetail_OTime(Guid oI_ID);//在制品查看显示作业员计时信息
    DataSet S_WorkOrderDetail_Overtime(Guid wOD_ID);//在制品显示随工单超时原因表
    void I_WorkOrder_Devide(Guid wO_ID, string wO_Num, string wO_ProType, int wO_PNum, string wO_Note, string wO_People);//随工单分单
    DataSet S_WorkOrder_Devide(string wO_Num);//随工单分单查询
    void D_WorkOrder_Devide(string wO_Num);//随工单删除分单
    void U_WorkOrder_Devide(Guid wO_ID, int wO_PNum, string wO_Note);//编辑随工单分单计划数量
    void I_WorkOrder_Combine(string wO_Num, string wO_FatherNum, string wO_ProType, string wO_OrderNum, string wO_SN, string wO_Level, string wO_ChipNum, int wO_PNum, string wO_Note, string wO_People, string idstring);//随工单合单

}