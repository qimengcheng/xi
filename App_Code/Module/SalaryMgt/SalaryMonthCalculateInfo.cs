using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///SalaryAccountSetMaintananceInfo 的摘要说明
/// </summary>
public class SalaryMonthCalculateInfo
{
    //薪资员工薪资详情表SalaryEmpWageDetail
    private Guid sEWD_ID;

    public Guid SEWD_ID
    {
        get { return sEWD_ID; }
        set { sEWD_ID = value; }
    }
    private Guid hRDD_ID;

    public Guid HRDD_ID
    {
        get { return hRDD_ID; }
        set { hRDD_ID = value; }
    }
    private string sEWD_Item;

    public string SEWD_Item
    {
        get { return sEWD_Item; }
        set { sEWD_Item = value; }
    }
    private decimal sEWD_ItemWage;

    public decimal SEWD_ItemWage
    {
        get { return sEWD_ItemWage; }
        set { sEWD_ItemWage = value; }
    }
    private DateTime sEWD_StartDate;

    public DateTime SEWD_StartDate
    {
        get { return sEWD_StartDate; }
        set { sEWD_StartDate = value; }
    }
    private DateTime sEWD_EndDate;

    public DateTime SEWD_EndDate
    {
        get { return sEWD_EndDate; }
        set { sEWD_EndDate = value; }
    }
    private int sEWD_Year;

    public int SEWD_Year
    {
        get { return sEWD_Year; }
        set { sEWD_Year = value; }
    }
    private int sEWD_Month;

    public int SEWD_Month
    {
        get { return sEWD_Month; }
        set { sEWD_Month = value; }
    }

    //薪资月度结算表SalaryMonCalculate
    private Guid sMC_ID;

    public Guid SMC_ID
    {
        get { return sMC_ID; }
        set { sMC_ID = value; }
    }

    private decimal sMC_TotalWage;

    public decimal SMC_TotalWage
    {
        get { return sMC_TotalWage; }
        set { sMC_TotalWage = value; }
    }
    private string sMC_State;

    public string SMC_State
    {
        get { return sMC_State; }
        set { sMC_State = value; }
    }

    private string sMC_Auditor;

    public string SMC_Auditor
    {
        get { return sMC_Auditor; }
        set { sMC_Auditor = value; }
    }
    private DateTime sMC_AuTime;

    public DateTime SMC_AuTime
    {
        get { return sMC_AuTime; }
        set { sMC_AuTime = value; }
    }
    private string sMC_AuSugg;

    public string SMC_AuSugg
    {
        get { return sMC_AuSugg; }
        set { sMC_AuSugg = value; }
    }

    private string sMC_AuRes;

    public string SMC_AuRes
    {
        get { return sMC_AuRes; }
        set { sMC_AuRes = value; }
    }
    private int sMC_Year;

    public int SMC_Year
    {
        get { return sMC_Year; }
        set { sMC_Year = value; }
    }
    private int sMC_Month;

    public int SMC_Month
    {
        get { return sMC_Month; }
        set { sMC_Month = value; }
    }

    private DateTime sMC_StartDate;

    public DateTime SMC_StartDate
    {
        get { return sMC_StartDate; }
        set { sMC_StartDate = value; }
    }
    private DateTime sMC_EndDate;

    public DateTime SMC_EndDate
    {
        get { return sMC_EndDate; }
        set { sMC_EndDate = value; }
    }

    private string sMC_Person;

    public string SMC_Person
    {
        get { return sMC_Person; }
        set { sMC_Person = value; }
    }
    private Guid sDBT_ID;

    public Guid SDBT_ID
    {
        get { return sDBT_ID; }
        set { sDBT_ID = value; }
    }
    private string sDBT_Dep;

    public string SDBT_Dep
    {
        get { return sDBT_Dep; }
        set { sDBT_Dep = value; }
    }

    private string sDBT_Post;

    public string SDBT_Post
    {
        get { return sDBT_Post; }
        set { sDBT_Post = value; }
    }
	public SalaryMonthCalculateInfo()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

}