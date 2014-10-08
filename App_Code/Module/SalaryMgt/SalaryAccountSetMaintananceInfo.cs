using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///SalaryAccountSetMaintananceInfo 的摘要说明
/// </summary>
public class SalaryAccountSetMaintananceInfo
{
    private Guid sAS_ASID;
    private string sAS_ASName;
    private bool sAS_IsDeleted;
    private Guid sIT_ItemID;
    private string sIT_Items;
    private decimal sIT_InitialValue;
    private string sIT_Formula;
    private bool sIT_IsDeleted;
    private bool sIT_IsFixed;
    private int sIT_Sort;
    private string sAS_Type;

    public string SAS_Type
    {
        get { return sAS_Type; }
        set { sAS_Type = value; }
    }

    public Guid SAS_ASID
    {
        get { return sAS_ASID; }
        set { sAS_ASID = value; }
    }
    

    public string SAS_ASName
    {
        get { return sAS_ASName; }
        set { sAS_ASName = value; }
    }
    

    public bool SAS_IsDeleted
    {
        get { return sAS_IsDeleted; }
        set { sAS_IsDeleted = value; }
    }

    

    public Guid SIT_ItemID
    {
        get { return sIT_ItemID; }
        set { sIT_ItemID = value; }
    }
    

    public string SIT_Items
    {
        get { return sIT_Items; }
        set { sIT_Items = value; }
    }
    

    public decimal SIT_InitialValue
    {
        get { return sIT_InitialValue; }
        set { sIT_InitialValue = value; }
    }

    

    public string SIT_Formula
    {
        get { return sIT_Formula; }
        set { sIT_Formula = value; }
    }
    

    public bool SIT_IsDeleted
    {
        get { return sIT_IsDeleted; }
        set { sIT_IsDeleted = value; }
    }
    

    public bool SIT_IsFixed
    {
        get { return sIT_IsFixed; }
        set { sIT_IsFixed = value; }
    }
    
    public int SIT_Sort
    {
        get { return sIT_Sort; }
        set { sIT_Sort = value; }
    }

	public SalaryAccountSetMaintananceInfo()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    public SalaryAccountSetMaintananceInfo(string _sIT_Items, decimal _sIT_InitialValue, string _sIT_Formula)
    {
        sIT_Items=_sIT_Items;
        sIT_InitialValue=_sIT_InitialValue;
        sIT_Formula = _sIT_Formula;
    }
}