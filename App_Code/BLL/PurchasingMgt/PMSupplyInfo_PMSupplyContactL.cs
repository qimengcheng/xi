using System;
using System.Data;

/// <summary>
///PMSupplyInfo_PMSupplyContactD 的摘要说明
/// </summary>
public class PMSupplyInfo_PMSupplyContactL
{
    private static readonly IPMSupplyInfo_PMSupplyContact Supply = DALFactory.CreatePMSupplyInfo_PMSupplyContact();
	public PMSupplyInfo_PMSupplyContactL()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    public void InsertPMSupplyInfo(string PMSI_SupplyName, string PMSI_SupplySort, string PMSI_SupplyRemark, int PMSI_PaymentTime)
    {
        Supply.InsertPMSupplyInfo(PMSI_SupplyName, PMSI_SupplySort, PMSI_SupplyRemark, PMSI_PaymentTime);
    }
    public void InsertPMSupplyContact(Guid PMSI_ID,string PMSC_Name, string PMSC_Position, string PMSC_TelephoneNum, string PMSC_PhoneNum, string PMSC_FaxNum, string PMSC_Email, string PMSC_QQ)
    {
        Supply.InsertPMSupplyContact(PMSI_ID,PMSC_Name, PMSC_Position, PMSC_TelephoneNum, PMSC_PhoneNum, PMSC_FaxNum, PMSC_Email, PMSC_QQ);
    }
    public void UpdatePMSupplyInfo(Guid PMSI_ID, string PMSI_SupplyName, string PMSI_SupplySort, string PMSI_SupplyRemark, int PMSI_PaymentTime)
    {
        Supply.UpdatePMSupplyInfo( PMSI_ID, PMSI_SupplyName,  PMSI_SupplySort, PMSI_SupplyRemark,  PMSI_PaymentTime);
    }
    public void UpdatePMSupplyContact(Guid PMSC_ID,string PMSC_Name, string PMSC_Position, string PMSC_TelephoneNum, string PMSC_PhoneNum, string PMSC_FaxNum, string PMSC_Email, string PMSC_QQ)
    {
         Supply.UpdatePMSupplyContact(  PMSC_ID,PMSC_Name, PMSC_Position,  PMSC_TelephoneNum,  PMSC_PhoneNum,  PMSC_FaxNum,  PMSC_Email,  PMSC_QQ);
    }
    public DataSet SelectPMSupplyContact_One(Guid PMSC_ID)
    {
        return Supply.SelectPMSupplyContact_One(PMSC_ID);
    }
    public DataSet SelectPMSupplyInfo(string condition)
    {
        return Supply.SelectPMSupplyInfo(condition);
    }
    public DataSet SelectPMSupply_One(Guid PMSI_ID)
    {
        return Supply.SelectPMSupply_One(PMSI_ID);
    }
    public DataSet SelectPMSupplyContact(Guid PMSI_ID)
    {
        return Supply.SelectPMSupplyContact(PMSI_ID);
    }
    public DataSet SelectPMSupply_Same(string PMSI_SupplyName)
    {
        return Supply.SelectPMSupply_Same(PMSI_SupplyName);
    }
    public DataSet SelectPMSupplyContact_Same(string PMSC_Name)
    {
        return Supply.SelectPMSupplyContact_Same(PMSC_Name);
    }
    public int DeletePMSupplyInfo(Guid _PMSI_ID)
    {
        return Supply.DeletePMSupplyInfo(_PMSI_ID);
    }
    public int DeletePMSupplyContact(Guid _PMSC_ID)
    {
        return Supply.DeletePMSupplyContact(_PMSC_ID);
    }

    //public IList<PMSupplyInfo_PMSupplyContact> GetSupplyKind()
    //{
    //    return Supply.GetSupplyKind();
    //}

}