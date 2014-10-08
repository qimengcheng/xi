using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///SalaryTimeItemMaintananceInfo 的摘要说明
/// </summary>
public class SalaryTimeItemMaintananceInfo
{
    public SalaryTimeItemMaintananceInfo()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }
    private Guid sTI_ID;

    private Guid pBC_ID;

    private string sTI_Name;

    private decimal sTI_UnitPrice;

    private bool sTI_IsDeleted;

    private string pBC_Name;


    public Guid STI_ID
    {
        get { return sTI_ID; }
        set { sTI_ID = value; }
    }

    public Guid PBC_ID
    {
        get { return pBC_ID; }
        set { pBC_ID = value; }
    }

    public string STI_Name
    {
        get { return sTI_Name; }
        set { sTI_Name = value; }
    }

    public decimal STI_UnitPrice
    {
        get { return sTI_UnitPrice; }
        set
        {
            if (value >= 0)
                sTI_UnitPrice = value;
        }
    }

    public bool STI_IsDeleted
    {
        get { return sTI_IsDeleted; }
        set { sTI_IsDeleted = value; }
    }

    public string PBC_Name
    {
        get { return pBC_Name; }
        set { pBC_Name = value; }
    }
    public SalaryTimeItemMaintananceInfo(Guid _pBC_ID, string _sTI_Name, decimal _sTI_UnitPrice)
    {
        pBC_ID = _pBC_ID;
        sTI_Name = _sTI_Name;
        sTI_UnitPrice = _sTI_UnitPrice;
    }
}

/// <summary>
///SalaryTimeItemChangeRecordInfo 的摘要说明
/// </summary>
public class SalaryTimeItemChangeRecordInfo
{
    public SalaryTimeItemChangeRecordInfo()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    private Guid sTI_ID;

    public Guid STI_ID
    {
        get { return sTI_ID; }
        set { sTI_ID = value; }
    }
    
    private Guid sTICR_ID;

    public Guid STICR_ID
    {
        get { return sTICR_ID; }
        set { sTICR_ID = value; }
    }

    private decimal sTICR_FormerPrice;

    public decimal STICR_FormerPrice
    {
        get { return sTICR_FormerPrice; }
        set { sTICR_FormerPrice = value; }
    }

    private decimal sTICR_NewPrice;

    public decimal STICR_NewPrice
    {
        get { return sTICR_NewPrice; }
        set { sTICR_NewPrice = value; }
    }

    private DateTime sTICR_OpTime;

    public DateTime STICR_OpTime
    {
        get { return sTICR_OpTime; }
        set { sTICR_OpTime = value; }
    }

    private string sTICR_OpPerson;

    public string STICR_OpPerson
    {
        get { return sTICR_OpPerson; }
        set { sTICR_OpPerson = value; }
    }

    private DateTime sTICR_ExecDate;

    public DateTime STICR_ExecDate
    {
        get { return sTICR_ExecDate; }
        set { sTICR_ExecDate = value; }
    }
    
}