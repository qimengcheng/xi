using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///SalaryPieceworkItemMaintananceInfo 的摘要说明
/// </summary>
public class SalaryPieceworkItemMaintananceInfo
{
    public SalaryPieceworkItemMaintananceInfo()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }
    private Guid sPI_ID;
    private Guid sPS_ID;

    public Guid SPS_ID
    {
        get { return sPS_ID; }
        set { sPS_ID = value; }
    }
    private string sPS_Name;

    public string SPS_Name
    {
        get { return sPS_Name; }
        set { sPS_Name = value; }
    }

    private Guid pBC_ID;
    private Decimal sPI_UnitPrice;
    private bool sPI_IsDeleted;
    private string pT_Name;
    private string pBC_Name;
    private string sPI_Name;

    public string SPI_Name
    {
        get { return sPI_Name; }
        set { sPI_Name = value; }
    }


    public Guid SPI_ID
    {
        get { return sPI_ID; }
        set { sPI_ID = value; }

    }

    public Guid PBC_ID
    {
        get { return pBC_ID; }
        set { pBC_ID = value; }
    }
    public Decimal SPI_UnitPrice
    {

        get
        {
            return sPI_UnitPrice;
        }
        set { sPI_UnitPrice = value; }
    }
    public bool SPI_IsDeleted
    {
        get { return sPI_IsDeleted; }
        set { sPI_IsDeleted = value; }
    }

    public string PT_Name
    {
        get { return pT_Name; }
        set { pT_Name = value; }
    }
    public string PBC_Name
    {
        get { return pBC_Name; }
        set { pBC_Name = value; }
    }

    private decimal sPICR_FormerPrice;

    public decimal SPICR_FormerPrice
    {
        get { return sPICR_FormerPrice; }
        set { sPICR_FormerPrice = value; }
    }

    private decimal sPICR_NewPrice;

    public decimal SPICR_NewPrice
    {
        get { return sPICR_NewPrice; }
        set { sPICR_NewPrice = value; }
    }

    private string sPICR_OpPerson;

    public string SPICR_OpPerson
    {
        get { return sPICR_OpPerson; }
        set { sPICR_OpPerson = value; }
    }

    private DateTime sPICR_ExecDate;

    public DateTime SPICR_ExecDate
    {
        get { return sPICR_ExecDate; }
        set { sPICR_ExecDate = value; }
    }
    public SalaryPieceworkItemMaintananceInfo(string _SPS_Name, Guid _PBC_ID, string _SPI_Name, decimal _SPI_UnitPrice)
    {
        sPS_Name = _SPS_Name;
        pBC_ID = _PBC_ID;
        sPI_Name = _SPI_Name;
        sPI_UnitPrice = _SPI_UnitPrice;
    }
}