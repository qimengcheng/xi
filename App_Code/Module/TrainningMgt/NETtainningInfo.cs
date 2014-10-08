using System;

/// <summary>
///NETtainningInfo 的摘要说明
/// </summary>
public class NETtainningInfo
{
    private Guid nETI_ID;
    private string bDOS_Code;
    private string nETI_TraningCourse;
    private string nETI_TraningType;
    private decimal nETI_CreditHours;
    private bool nETI_IsDeleted;
    private string bDOS_Name;

    public string BDOS_Name
    {
        get { return bDOS_Name; }
        set { bDOS_Name = value; }
    }

    public Guid NETI_ID
    {
        get { return nETI_ID; }
        set { nETI_ID = value; }
    }


    public string BDOS_Code
    {
        get { return bDOS_Code; }
        set { bDOS_Code = value; }
    }


    public string NETI_TraningCourse
    {
        get { return nETI_TraningCourse; }
        set { nETI_TraningCourse = value; }
    }


    public string NETI_TraningType
    {
        get { return nETI_TraningType; }
        set { nETI_TraningType = value; }
    }


    public decimal NETI_CreditHours
    {
        get { return nETI_CreditHours; }
        set { nETI_CreditHours = value; }
    }


    public bool NETI_IsDeleted
    {
        get { return nETI_IsDeleted; }
        set { nETI_IsDeleted = value; }
    }
    public NETtainningInfo()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }
    
    public NETtainningInfo(string _bDOS_Name, string _bDOS_Code, string _nETI_TraningCourse, string _nETI_TraningType, decimal _nETI_CreditHours)
    {
        bDOS_Name = _bDOS_Name;
        bDOS_Code = _bDOS_Code;
        nETI_TraningCourse = _nETI_TraningCourse;
        nETI_TraningType = _nETI_TraningType;
        nETI_CreditHours = _nETI_CreditHours;
        
    }
}