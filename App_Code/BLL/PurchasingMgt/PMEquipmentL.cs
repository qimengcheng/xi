using System.Data;

/// <summary>
///PMEquipmentL 的摘要说明
/// </summary>
public class PMEquipmentL
{
    private static readonly IPMEquipment PMP = DALFactory.CreatePMEquipment();
	public PMEquipmentL()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    public DataSet SelectPMEquipmentApply(string condition)
    {
        return PMP.SelectPMEquipmentApply(condition);
    }
    public void InsertPMEquipmentApply(PMEquipmentinfo pMEquipmentinfo)
    {
        PMP.InsertPMEquipmentApply(pMEquipmentinfo);
    }
    public void UpdatePMEquipmentApply(PMEquipmentinfo pMEquipmentinfo)
    {
        PMP.UpdatePMEquipmentApply(pMEquipmentinfo);
    }
    public void UpdatePMEA_ApplyDepartCheck(PMEquipmentinfo pMEquipmentinfo)
    {
        PMP.UpdatePMEA_ApplyDepartCheck(pMEquipmentinfo);
    }
    public void UpdatePMEA_PDCheck(PMEquipmentinfo pMEquipmentinfo)
    {
        PMP.UpdatePMEA_PDCheck(pMEquipmentinfo);
    }
    public void UpdatePMEA_EDDCheck(PMEquipmentinfo pMEquipmentinfo)
    {
        PMP.UpdatePMEA_EDDCheck(pMEquipmentinfo);
    }
    public void UpdatePMEA_EDCheck(PMEquipmentinfo pMEquipmentinfo)
    {
        PMP.UpdatePMEA_EDCheck(pMEquipmentinfo);
    }
    public void UpdatePMEA_QACheck(PMEquipmentinfo pMEquipmentinfo)
    {
        PMP.UpdatePMEA_QACheck(pMEquipmentinfo);
    }
    public void UpdatePMEA_DMCheck(PMEquipmentinfo pMEquipmentinfo)
    {
        PMP.UpdatePMEA_DMCheck(pMEquipmentinfo);
    }
    public void UpdatePMEA_GMCheck(PMEquipmentinfo pMEquipmentinfo)
    {
        PMP.UpdatePMEA_GMCheck(pMEquipmentinfo);
    }
    public void InsertPMPurchaseOrder_Equipment(PMEquipmentinfo pMEquipmentinfo)
    {
        PMP.InsertPMPurchaseOrder_Equipment(pMEquipmentinfo);
    }
    public void InsertPMPurchaseOrderDetail_Equipment(PMEquipmentinfo pMEquipmentinfo)
    {
        PMP.InsertPMPurchaseOrderDetail_Equipment(pMEquipmentinfo);
    }
    public DataSet SelectPMSI_SDepart_Equipment(PMEquipmentinfo pMEquipmentinfo)
    {
        return PMP.SelectPMSI_SDepart_Equipment(pMEquipmentinfo);
    }
    public void InsertPMEquipmentCheckAccept(PMEquipmentinfo pMEquipmentinfo)
    {
        PMP.InsertPMEquipmentCheckAccept(pMEquipmentinfo);
    }
    public void UpdatePMECA_EDDCheck(PMEquipmentinfo pMEquipmentinfo)
    {
        PMP.UpdatePMECA_EDDCheck(pMEquipmentinfo);
    }
    public void UpdatePMECA_PDCheck(PMEquipmentinfo pMEquipmentinfo)
    {
        PMP.UpdatePMECA_PDCheck(pMEquipmentinfo);
    }
    public void UpdatePMECA_EDCheck(PMEquipmentinfo pMEquipmentinfo)
    {
        PMP.UpdatePMECA_EDCheck(pMEquipmentinfo);
    }
    public void UpdatePMECA_QACheck(PMEquipmentinfo pMEquipmentinfo)
    {
        PMP.UpdatePMECA_QACheck(pMEquipmentinfo);
    }
    public DataSet SelectPMESupply(PMEquipmentinfo pMEquipmentinfo)
    { 
   return PMP.SelectPMESupply(pMEquipmentinfo);
    }
    public DataSet SelectPMEMaterial(string condition)
    { 
    return PMP.SelectPMEMaterial(condition);
    
    }
    public DataSet SelectPMEquipmentCheckAccept(PMEquipmentinfo pMEquipmentinfo)
    {
        return PMP.SelectPMEquipmentCheckAccept(pMEquipmentinfo);
    }
    public DataSet SelectPMEquipmentCheckAccept_One(PMEquipmentinfo pMEquipmentinfo)
    {
        return PMP.SelectPMEquipmentCheckAccept_One(pMEquipmentinfo);
    }
    public DataSet SelectEquipment_Cost(PMEquipmentinfo pMEquipmentinfo)
    {
        return PMP.SelectEquipment_Cost(pMEquipmentinfo);
    }
    public void UpdatePMEquipmentCheckAccept(PMEquipmentinfo pMEquipmentinfo)
    {
        PMP.UpdatePMEquipmentCheckAccept(pMEquipmentinfo);
    }
    public DataSet SelectPMEquipmentApplyCountersign_One(PMEquipmentinfo pMEquipmentinfo)
    {
        return PMP.SelectPMEquipmentApplyCountersign_One(pMEquipmentinfo);
    }
    public DataSet SelectPMEquipmentApplyCountersign(PMEquipmentinfo pMEquipmentinfo)
    {
        return PMP.SelectPMEquipmentApplyCountersign(pMEquipmentinfo);
    }
    public void UpdatePMEquipmentApplyCountersign(PMEquipmentinfo pMEquipmentinfo)
    {
        PMP.UpdatePMEquipmentApplyCountersign(pMEquipmentinfo);
    }
    public void InsertPMEquipmentApplyCountersign(PMEquipmentinfo pMEquipmentinfo)
    {
        PMP.InsertPMEquipmentApplyCountersign(pMEquipmentinfo);
    }
    public void UpdatePMEquipmentApply_State(PMEquipmentinfo pMEquipmentinfo)
    {
        PMP.UpdatePMEquipmentApply_State(pMEquipmentinfo);
    }
    public void UpdatePMEquipmentPrice(PMEquipmentinfo pMEquipmentinfo)
    {
        PMP.UpdatePMEquipmentPrice(pMEquipmentinfo);
    }
    public void DeletePMEquipmentApplyCountersign(PMEquipmentinfo pMEquipmentinfo)
    {
        PMP.DeletePMEquipmentApplyCountersign(pMEquipmentinfo);
    }
    public DataSet SelectPMEquipmentApplyCountersign_Same(string condition)
    {
      return  PMP.SelectPMEquipmentApplyCountersign_Same(condition);
    }
    }