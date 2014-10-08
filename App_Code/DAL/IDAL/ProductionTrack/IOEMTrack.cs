using System;
using System.Data;

/// <summary>
///IOEMTrack 的摘要说明
/// </summary>
public interface IOEMTrack
{
    DataSet S_OEMOrderTrack(string condition);
    void I_OEMOrderTrack(Guid sMSOD_ID, string oEMOT_Note, DateTime oEMOT_PDate, DateTime oEMOT_RPDate, DateTime oEMOT_RDeliverytDate);//加工订单跟踪主表制定
    void U_OEMOrderTrack(Guid oEMOT_ID, string oEMOT_Note, DateTime oEMOT_PDate, DateTime oEMOT_RPDate, DateTime oEMOT_RDeliverytDate);//加工订单跟踪主编辑
    DataSet S_PMMInventory(string condition);//生产线盘存主表检索
    void D_PMMInventory(Guid pMMI_ID);//生产线盘存主表删除
    void I_PMMInventory(Guid pBC_ID, DateTime pMMI_Date, string pMMI_Man);//生产线盘存主表删除

}