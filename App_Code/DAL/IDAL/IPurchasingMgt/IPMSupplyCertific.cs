using System.Data;

/// <summary>
///IPMSupplyCertific 的摘要说明
/// </summary>
public interface  IPMSupplyCertific
{
    DataSet SelectPMSupplyCertificApply(string condition);
    void InsertPMSupplyCertificApply(PMSupplyCertificinfo pMSupplyCertificinfo);
    void DeletePMSupplyCertificApply(PMSupplyCertificinfo pMSupplyCertificinfo);
    DataSet SelectPMSupplyCertificApply_One(PMSupplyCertificinfo pMSupplyCertificinfo);
    void UpdatePMSupplyCertificApply(PMSupplyCertificinfo pMSupplyCertificinfo);
    void InsertPMSupplyCertificInfo(PMSupplyCertificinfo pMSupplyCertificinfo);
    void UpdatePMSupplyCertificInfo(PMSupplyCertificinfo pMSupplyCertificinfo);
    DataSet SelectPMSupplyCertificInfo(PMSupplyCertificinfo pMSupplyCertificinfo);
    DataSet SelectPMSupplyCertificInfo_One(PMSupplyCertificinfo pMSupplyCertificinfo);
    void DeletePMSupplyCertificInfo_One(PMSupplyCertificinfo pMSupplyCertificinfo);
    void UpdatePMSCA_State(PMSupplyCertificinfo pMSupplyCertificinfo);
    void InsertPMSCA_QASign(PMSupplyCertificinfo pMSupplyCertificinfo);
    void InsertPMSCA_PDSign(PMSupplyCertificinfo pMSupplyCertificinfo);
    void InsertPMSCA_EDSign(PMSupplyCertificinfo pMSupplyCertificinfo);
    void InsertPMSCA_DMCheck(PMSupplyCertificinfo pMSupplyCertificinfo);
    void InsertPMSCA_GMCheck(PMSupplyCertificinfo pMSupplyCertificinfo);
    void SelectPMSupply(PMSupplyCertificinfo pMSupplyCertificinfo);
    DataSet SelectPMSCA_DMCheckOpinion(PMSupplyCertificinfo pMSupplyCertificinfo);
    void InsertPMSupplyCertificApplyCountersign(PMSupplyCertificinfo pMSupplyCertificinfo);
    void UpdatePMSupplyCertificApplyCountersign(PMSupplyCertificinfo pMSupplyCertificinfo);
    DataSet SelectPMSupplyCertificApplyCountersign(PMSupplyCertificinfo pMSupplyCertificinfo);
    DataSet SelectPMSCAC_Organization(string condition);
    DataSet SelectPMSupplyCertificApplyCountersign_One(PMSupplyCertificinfo pMSupplyCertificinfo);
    void DeletePMSupplyCertificApplyCountersign(PMSupplyCertificinfo pMSupplyCertificinfo);
}