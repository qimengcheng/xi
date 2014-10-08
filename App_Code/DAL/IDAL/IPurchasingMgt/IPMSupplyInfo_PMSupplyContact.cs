using System;
using System.Data;

/// <summary>
///IPMSupplyInfo_PMSupplyContact 的摘要说明
/// </summary>
public interface IPMSupplyInfo_PMSupplyContact
{
    void InsertPMSupplyInfo(string PMSI_SupplyName, string PMSI_SupplySort, string PMSI_SupplyRemark, int PMSI_PaymentTime);
    void InsertPMSupplyContact(Guid PMSI_ID,string PMSC_Name, string PMSC_Position, string PMSC_TelephoneNum, string PMSC_PhoneNum, string PMSC_FaxNum, string PMSC_Email, string PMSC_QQ);
    void UpdatePMSupplyInfo(Guid PMSI_ID, string PMSI_SupplyName, string PMSI_SupplySort, string PMSI_SupplyRemark, int PMSI_PaymentTime);
    void UpdatePMSupplyContact(Guid PMSC_ID, string PMSC_Name, string PMSC_Position, string PMSC_TelephoneNum, string PMSC_PhoneNum, string PMSC_FaxNum, string PMSC_Email, string PMSC_QQ);
    DataSet SelectPMSupplyInfo(string condition);
    DataSet SelectPMSupply_One(Guid PMSI_ID);
    DataSet SelectPMSupplyContact(Guid PMSI_ID);
    DataSet SelectPMSupply_Same(string PMSI_SupplyName);
    DataSet SelectPMSupplyContact_One(Guid PMSC_ID);
    DataSet SelectPMSupplyContact_Same(string PMSC_Name);
    int DeletePMSupplyInfo(Guid _PMSI_ID);
    int DeletePMSupplyContact(Guid _PMSC_ID);
    //IList<PMSupplyInfo_PMSupplyContact> GetSupplyKind();

}