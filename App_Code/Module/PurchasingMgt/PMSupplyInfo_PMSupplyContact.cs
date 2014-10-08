using System;

/// <summary>
///PMSupplyInfo_PMSupplyContact 的摘要说明
/// </summary>
public class PMSupplyInfo_PMSupplyContact
{
    private Guid pMSI_ID;
    private Guid pMSC_ID;
    private string pMSI_SupplyName;
    private string pMSI_SupplySort;
    private string pMSI_Remark;
    private bool pMSI_IsDelete;
    private string pMSC_Name;
    private string pMSC_Position;
    private string pMSC_TelephoneNum;
    private string pMSC_PhoneNum;
    private string pMSC_FaxNum;
    private string pMSC_Email;
    private string pMSC_QQ;
    private string pMSI_SupplyNum;
    private int pMSI_PaymentTime;

  

	public PMSupplyInfo_PMSupplyContact()
	{
		
	}
    public PMSupplyInfo_PMSupplyContact(string _pMSI_SupplyName, Guid _pMSI_ID)
    {
        pMSI_SupplyName = _pMSI_SupplyName;
        pMSI_ID = _pMSI_ID;
    }
    public PMSupplyInfo_PMSupplyContact(Guid _pMSI_ID, Guid _pMSC_ID, string _pMSI_SupplyName, string _pMSI_SupplySort, string _pMSI_Remark, bool _pMSI_IsDelete, string _pMSC_Name, string _pMSC_Position, string _pMSC_TelephoneNum, string _pMSC_PhoneNum, string _pMSC_FaxNum, string _pMSC_Email, string _pMSC_QQ, string _pMSI_SupplyNum)
    {
        pMSI_ID = _pMSI_ID;
        pMSC_ID = _pMSC_ID;
        pMSI_SupplyName = _pMSI_SupplyName;
        pMSI_SupplySort = _pMSI_SupplySort;
        pMSI_Remark = _pMSI_Remark;
        pMSI_IsDelete = _pMSI_IsDelete;
        pMSC_Name = _pMSC_Name;
        pMSC_Position = _pMSC_Position;
        pMSC_TelephoneNum = _pMSC_TelephoneNum;
        pMSC_PhoneNum=_pMSC_PhoneNum;
        pMSC_FaxNum = _pMSC_FaxNum;
        pMSC_Email = _pMSC_Email;
        pMSC_QQ = _pMSC_QQ;
        pMSI_SupplyNum = _pMSI_SupplyNum;
    }
    
    public Guid PMSI_ID
    {
        get { return pMSI_ID; }
        set { pMSI_ID = value; }
    }
    public Guid PMSC_ID
    {
        get { return pMSC_ID; }
        set { pMSC_ID = value; }
    }
    public string PMSI_SupplyName
       {
           get { return pMSI_SupplyName; }
           set { pMSI_SupplyName = value; }
       }
    public string PMSC_QQ
    {
        get { return pMSC_QQ; }
        set { pMSC_QQ = value; }
    }
    public string PMSC_Email
    {
        get { return pMSC_Email; }
        set { pMSC_Email = value; }
    }
    public string PMSC_FaxNum
    {
        get { return pMSC_FaxNum; }
        set { pMSC_FaxNum = value; }
    }
    public string PMSC_PhoneNum
    {
        get { return pMSC_PhoneNum; }
        set { pMSC_PhoneNum = value; }
    }
    public string PMSC_TelephoneNum
    {
        get { return pMSC_TelephoneNum; }
        set { pMSC_TelephoneNum = value; }
    }
    public string PMSC_Position
    {
        get { return pMSC_Position; }
        set { pMSC_Position = value; }
    }
    public string PMSC_Name
    {
        get { return pMSC_Name; }
        set { pMSC_Name = value; }
    }
    public bool PMSI_IsDelete
    {
        get { return pMSI_IsDelete; }
        set { pMSI_IsDelete = value; }
    }
    public string PMSI_Remark
    {
        get { return pMSI_Remark; }
        set { pMSI_Remark = value; }
    }
    public string PMSI_SupplySort
    {
        get { return pMSI_SupplySort; }
        set { pMSI_SupplySort = value; }
    }
    public string PMSI_SupplyNum
    {
        get { return pMSI_SupplyNum; }
        set { pMSI_SupplyNum = value; }
    }

    public int PMSI_PaymentTime
    {
        get { return pMSI_PaymentTime; }
        set { pMSI_PaymentTime = value; }
    }
}