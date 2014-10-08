using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///SalaryIndividualIncomeInfo 的摘要说明
/// </summary>
public class SalaryIndividualIncomeInfo
{
    private Guid sIIT_ID;
    private int sIIT_Min;
    private int sIIT_Max;
    private int sIIT_Rate;
    private int sIIT_Deduction;

    public int SIIT_Deduction
    {
        get { return sIIT_Deduction; }
        set { sIIT_Deduction = value; }
    }

    public int SIIT_Rate
    {
        get { return sIIT_Rate; }
        set { sIIT_Rate = value; }
    }

    public int SIIT_Max
    {
        get { return sIIT_Max; }
        set { sIIT_Max = value; }
    }

    public int SIIT_Min
    {
        get { return sIIT_Min; }
        set { sIIT_Min = value; }
    }

    public Guid SIIT_ID
    {
        get { return sIIT_ID; }
        set { sIIT_ID = value; }
    }

	public SalaryIndividualIncomeInfo()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
}