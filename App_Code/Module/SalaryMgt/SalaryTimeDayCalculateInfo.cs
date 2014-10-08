using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///SalaryTimeDayCalculateInfo 的摘要说明
/// </summary>
public class SalaryTimeDayCalculateInfo
{
    //计时计件日核算表
    private Guid wTP_ID;
    private DateTime wTP_Date;

    //员工计时日工资主表
    private Guid sTPDW_ID;
    private DateTime sTPDW_Date;

    //计时日工资统计审核表
    private Guid sTSA_ID;
    private DateTime sTSA_Date;
    private string sTSA_Auditor;
    private DateTime sTSA_AuTime;
    private string sTSA_AuSugg;
    private string sTSA_AuRes;
    private string sPSA_Auditor;
    private DateTime sPSA_AuTime;
    private string sPSA_AuSugg;
    private string sPSA_AuRes;

    private string pT_Auditor;

    public string PT_Auditor
    {
        get { return pT_Auditor; }
        set { pT_Auditor = value; }
    }
    private DateTime pT_AuTime;

    public DateTime PT_AuTime
    {
        get { return pT_AuTime; }
        set { pT_AuTime = value; }
    }
    private string pT_AuSugg;

    public string PT_AuSugg
    {
        get { return pT_AuSugg; }
        set { pT_AuSugg = value; }
    }
    private string pT_AuRes;

    public string PT_AuRes
    {
        get { return pT_AuRes; }
        set { pT_AuRes = value; }
    }

    private string pP_Auditor;

    public string PP_Auditor
    {
        get { return pP_Auditor; }
        set { pP_Auditor = value; }
    }
    private DateTime pP_AuTime;

    public DateTime PP_AuTime
    {
        get { return pP_AuTime; }
        set { pP_AuTime = value; }
    }
    private string pP_AuSugg;

    public string PP_AuSugg
    {
        get { return pP_AuSugg; }
        set { pP_AuSugg = value; }
    }
    private string pP_AuRes;

    public string PP_AuRes
    {
        get { return pP_AuRes; }
        set { pP_AuRes = value; }
    }

    public string SPSA_Auditor
    {
        get { return sPSA_Auditor; }
        set { sPSA_Auditor = value; }
    }
    

    public DateTime SPSA_AuTime
    {
        get { return sPSA_AuTime; }
        set { sPSA_AuTime = value; }
    }
    

    public string SPSA_AuSugg
    {
        get { return sPSA_AuSugg; }
        set { sPSA_AuSugg = value; }
    }
    

    public string SPSA_AuRes
    {
        get { return sPSA_AuRes; }
        set { sPSA_AuRes = value; }
    }

    public string STSA_AuRes
    {
        get { return sTSA_AuRes; }
        set { sTSA_AuRes = value; }
    }

    public string STSA_AuSugg
    {
        get { return sTSA_AuSugg; }
        set { sTSA_AuSugg = value; }
    }

    public DateTime STSA_AuTime
    {
        get { return sTSA_AuTime; }
        set { sTSA_AuTime = value; }
    }

    public string STSA_Auditor
    {
        get { return sTSA_Auditor; }
        set { sTSA_Auditor = value; }
    }

    public DateTime STSA_Date
    {
        get { return sTSA_Date; }
        set { sTSA_Date = value; }
    }

    public Guid STSA_ID
    {
        get { return sTSA_ID; }
        set { sTSA_ID = value; }
    }

    public DateTime STPDW_Date
    {
        get { return sTPDW_Date; }
        set { sTPDW_Date = value; }
    }

    public Guid STPDW_ID
    {
        get { return sTPDW_ID; }
        set { sTPDW_ID = value; }
    }

    public DateTime WTP_Date
    {
        get { return wTP_Date; }
        set { wTP_Date = value; }
    }

    public Guid WTP_ID
    {
        get { return wTP_ID; }
        set { wTP_ID = value; }
    }



	public SalaryTimeDayCalculateInfo()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
}