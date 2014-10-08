using System.Data;
/// <summary>
///IPMEquipment 的摘要说明
/// </summary>
public interface IPMEquipment
{
    DataSet SelectPMEquipmentApply(string condition);
    void InsertPMEquipmentApply(PMEquipmentinfo pMEquipmentinfo);
    void UpdatePMEquipmentApply(PMEquipmentinfo pMEquipmentinfo);
    void UpdatePMEA_ApplyDepartCheck(PMEquipmentinfo pMEquipmentinfo);
    void UpdatePMEA_PDCheck(PMEquipmentinfo pMEquipmentinfo);
    void UpdatePMEA_EDDCheck(PMEquipmentinfo pMEquipmentinfo);
    void UpdatePMEA_EDCheck(PMEquipmentinfo pMEquipmentinfo);
    void UpdatePMEA_QACheck(PMEquipmentinfo pMEquipmentinfo);
    void UpdatePMEA_DMCheck(PMEquipmentinfo pMEquipmentinfo);
    void UpdatePMEA_GMCheck(PMEquipmentinfo pMEquipmentinfo);
    void InsertPMPurchaseOrder_Equipment(PMEquipmentinfo pMEquipmentinfo);
    void InsertPMPurchaseOrderDetail_Equipment(PMEquipmentinfo pMEquipmentinfo);
    DataSet SelectPMSI_SDepart_Equipment(PMEquipmentinfo pMEquipmentinfo);
    void InsertPMEquipmentCheckAccept(PMEquipmentinfo pMEquipmentinfo);
    void UpdatePMECA_EDDCheck(PMEquipmentinfo pMEquipmentinfo);
    void UpdatePMECA_PDCheck(PMEquipmentinfo pMEquipmentinfo);
    void UpdatePMECA_EDCheck(PMEquipmentinfo pMEquipmentinfo);
    void UpdatePMECA_QACheck(PMEquipmentinfo pMEquipmentinfo);
    DataSet SelectPMESupply(PMEquipmentinfo pMEquipmentinfo);
    DataSet SelectPMEMaterial(string condition);
    DataSet SelectPMEquipmentCheckAccept(PMEquipmentinfo pMEquipmentinfo);
    DataSet SelectPMEquipmentCheckAccept_One(PMEquipmentinfo pMEquipmentinfo);
    DataSet SelectEquipment_Cost(PMEquipmentinfo pMEquipmentinfo);
    void UpdatePMEquipmentCheckAccept(PMEquipmentinfo pMEquipmentinfo);
    void InsertPMEquipmentApplyCountersign(PMEquipmentinfo pMEquipmentinfo);
    void UpdatePMEquipmentApplyCountersign(PMEquipmentinfo pMEquipmentinfo);
    DataSet SelectPMEquipmentApplyCountersign(PMEquipmentinfo pMEquipmentinfo);
    DataSet SelectPMEquipmentApplyCountersign_One(PMEquipmentinfo pMEquipmentinfo);
    void UpdatePMEquipmentApply_State(PMEquipmentinfo pMEquipmentinfo);
    void UpdatePMEquipmentPrice(PMEquipmentinfo pMEquipmentinfo);
    void DeletePMEquipmentApplyCountersign(PMEquipmentinfo pMEquipmentinfo);
    DataSet SelectPMEquipmentApplyCountersign_Same(string condition);
}