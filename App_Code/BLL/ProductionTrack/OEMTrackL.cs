using System;
using System.Data;

/// <summary>
///OEMTrackL 的摘要说明
/// </summary>
public class OEMTrackL
{
    private static readonly IOEMTrack it = DALFactory.CreateOEMTrack();

    public OEMTrackL()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }
    public DataSet S_OEMOrderTrack(string condition)
    {
        return it.S_OEMOrderTrack(condition);
    }
    public void I_OEMOrderTrack(Guid sMSOD_ID, string oEMOT_Note, DateTime oEMOT_PDate, DateTime oEMOT_RPDate, DateTime oEMOT_RDeliverytDate)//加工订单跟踪主表制定
    {
        it.I_OEMOrderTrack(sMSOD_ID, oEMOT_Note, oEMOT_PDate, oEMOT_RPDate, oEMOT_RDeliverytDate);
    }
    public void U_OEMOrderTrack(Guid oEMOT_ID, string oEMOT_Note, DateTime oEMOT_PDate, DateTime oEMOT_RPDate, DateTime oEMOT_RDeliverytDate)//加工订单跟踪主编辑
    {
        it.U_OEMOrderTrack(oEMOT_ID, oEMOT_Note, oEMOT_PDate, oEMOT_RPDate, oEMOT_RDeliverytDate);
    }
    public DataSet S_PMMInventory(string condition)//生产线盘存主表检索
    {
      return  it.S_PMMInventory(condition);
    }
    public void D_PMMInventory(Guid pMMI_ID)//生产线盘存主表删除
    {
        it.D_PMMInventory(pMMI_ID);
    }
    public void I_PMMInventory(Guid pBC_ID, DateTime pMMI_Date, string pMMI_Man)//生产线盘存主表删除

    {
        it.I_PMMInventory(pBC_ID, pMMI_Date, pMMI_Man);
    }
}