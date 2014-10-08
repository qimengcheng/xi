using System;

/// <summary>
///CRMNewCustormDevelopinfo 的摘要说明
/// </summary>
public class CRMNewCustormDevelopinfo
{
    private Guid cRMCIF_ID;

    public Guid CRMCIF_ID
    {
        get { return cRMCIF_ID; }
        set { cRMCIF_ID = value; }
    }
    private Guid cRMRBI_ID;

    public Guid CRMRBI_ID
    {
        get { return cRMRBI_ID; }
        set { cRMRBI_ID = value; }
    }
    private Guid cRMCSBD_ID;

    public Guid CRMCSBD_ID
    {
        get { return cRMCSBD_ID; }
        set { cRMCSBD_ID = value; }
    }
    private string cRMCIF_Name;

    public string CRMCIF_Name
    {
        get { return cRMCIF_Name; }
        set { cRMCIF_Name = value; }
    }
    private string cRMCIF_Address;

    public string CRMCIF_Address
    {
        get { return cRMCIF_Address; }
        set { cRMCIF_Address = value; }
    }
    private string cRMCIF_BinTag;

    public string CRMCIF_BinTag
    {
        get { return cRMCIF_BinTag; }
        set { cRMCIF_BinTag = value; }
    }
    private bool cRMCIF_IsDelete;

    public bool CRMCIF_IsDelete
    {
        get { return cRMCIF_IsDelete; }
        set { cRMCIF_IsDelete = value; }
    }

    private string cRMCSBD_Name;

    public string CRMCSBD_Name
    {
        get { return cRMCSBD_Name; }
        set { cRMCSBD_Name = value; }
    }
    private string cRMCSBD_Explain;

    public string CRMCSBD_Explain
    {
        get { return cRMCSBD_Explain; }
        set { cRMCSBD_Explain = value; }
    }
    private bool cRMCSBD_IsDelete;

    public bool CRMCSBD_IsDelete
    {
        get { return cRMCSBD_IsDelete; }
        set { cRMCSBD_IsDelete = value; }
    }

    private Guid cRMNCD_ID;

    public Guid CRMNCD_ID
    {
        get { return cRMNCD_ID; }
        set { cRMNCD_ID = value; }
    }
    private string cRMNCD_DevelopState;

    public string CRMNCD_DevelopState
    {
        get { return cRMNCD_DevelopState; }
        set { cRMNCD_DevelopState = value; }
    }
    private string cRMNCD_DetailCondition;

    public string CRMNCD_DetailCondition
    {
        get { return cRMNCD_DetailCondition; }
        set { cRMNCD_DetailCondition = value; }
    }
    private DateTime cRMNCD_Time;

    public DateTime CRMNCD_Time
    {
        get { return cRMNCD_Time; }
        set { cRMNCD_Time = value; }
    }
    private string cRMNCD_Man;

    public string CRMNCD_Man
    {
        get { return cRMNCD_Man; }
        set { cRMNCD_Man = value; }
    }

    private string cRMRBI_Name;

    public string CRMRBI_Name
    {
        get { return cRMRBI_Name; }
        set { cRMRBI_Name = value; }
    }
    private string cRMRBI_Explain;

    public string CRMRBI_Explain
    {
        get { return cRMRBI_Explain; }
        set { cRMRBI_Explain = value; }
    }
    private bool cRMRBI_IsDelete;

    public bool CRMRBI_IsDelete
    {
        get { return cRMRBI_IsDelete; }
        set { cRMRBI_IsDelete = value; }
    }




	public CRMNewCustormDevelopinfo()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    public CRMNewCustormDevelopinfo( Guid _cRMCIF_ID,Guid _cRMRBI_ID,Guid _cRMCSBD_ID,string _cRMCIF_Name,
          string _cRMCIF_Address,string _cRMCIF_BinTag, bool _cRMCIF_IsDelete, string _cRMCSBD_Name,string _cRMCSBD_Explain,bool _cRMCSBD_IsDelete,
         Guid _cRMNCD_ID,string _cRMNCD_DevelopState,string _cRMNCD_DetailCondition,DateTime _cRMNCD_Time,string _cRMNCD_Man,string _cRMRBI_Name, string _cRMRBI_Explain,
     bool _cRMRBI_IsDelete)
    {
    cRMCIF_ID=_cRMCIF_ID;
    cRMRBI_ID=_cRMRBI_ID;
    cRMCSBD_ID=_cRMCSBD_ID;
    cRMCIF_Name=_cRMCIF_Name;
    cRMCIF_Address=_cRMCIF_Address;
     cRMCIF_BinTag=_cRMCIF_BinTag;
    cRMCIF_IsDelete=_cRMCIF_IsDelete;

    cRMCSBD_Name=_cRMCSBD_Name;
    cRMCSBD_Explain=_cRMCSBD_Explain;
    cRMCSBD_IsDelete=_cRMCSBD_IsDelete;

    cRMNCD_ID=_cRMNCD_ID;
    cRMNCD_DevelopState=_cRMNCD_DevelopState;
     cRMNCD_DetailCondition=_cRMNCD_DetailCondition;
    cRMNCD_Time=_cRMNCD_Time;
    cRMNCD_Man=_cRMNCD_Man;

  cRMRBI_Name=_cRMRBI_Name; 
   cRMRBI_Explain=_cRMRBI_Explain;
   cRMRBI_IsDelete = _cRMRBI_IsDelete;
    }
}