using System;

/// <summary>
///NewEmpInfoAddInfo 的摘要说明
/// </summary>
public class NewEmpInfoAddInfo
{
    //新员工培训信息实体属性
    private Guid nETIMT_ID;
    private string nETIMT_Person;
    private DateTime nETIMT_Time;
    private string nETIMT_Remarks;
    private string nETIMT_State;//培训状态在其他页面也会同步更新


    //新员工选择的实体属性
    private Guid nETPCT_ID;
    private Guid hRDD_ID;
    private string nETPCT_FResult;//在培训结果录入时更新此字段
    private string hRDD_StaffNO;
    private string hRDD_Name;

    //培训项目选择的实体属性
    private Guid nETICT_ID;
    private Guid nETI_ID;
    private string _uMUI_UserID;//主讲人
    private string nETI_TraningCourse;
    private string nETI_TraningType;
    private DateTime nETICT_STime;
    private DateTime nETICT_ETime;
    private string nETICT_Place;

    private string bDOS_Code;
    private string nETICT_Person;
    private DateTime nETICT_Time;

    //新员工培训结果详情表
    private Guid nETEIRD_ID;
    private string nETEIRD_IsQualified;
    private string nETEIRD_Remark;


    public string NETICT_Place
    {
        get { return nETICT_Place; }
        set { nETICT_Place = value; }
    }
    public DateTime NETICT_ETime
    {
        get { return nETICT_ETime; }
        set { nETICT_ETime = value; }
    }
    public DateTime NETICT_STime
    {
        get { return nETICT_STime; }
        set { nETICT_STime = value; }
    }
    public string NETEIRD_Remark
    {
        get { return nETEIRD_Remark; }
        set { nETEIRD_Remark = value; }
    }

    public string NETEIRD_IsQualified
    {
        get { return nETEIRD_IsQualified; }
        set { nETEIRD_IsQualified = value; }
    }

    public Guid NETEIRD_ID
    {
        get { return nETEIRD_ID; }
        set { nETEIRD_ID = value; }
    }




    public string UMUI_UserID
    {
        get { return _uMUI_UserID; }
        set { _uMUI_UserID = value; }
    }

    public Guid NETIMT_ID
    {
        get { return nETIMT_ID; }
        set { nETIMT_ID = value; }
    }


    public string NETIMT_Person
    {
        get { return nETIMT_Person; }
        set { nETIMT_Person = value; }
    }


    public DateTime NETIMT_Time
    {
        get { return nETIMT_Time; }
        set { nETIMT_Time = value; }
    }


    public string NETIMT_Remarks
    {
        get { return nETIMT_Remarks; }
        set { nETIMT_Remarks = value; }
    }


    public string NETIMT_State
    {
        get { return nETIMT_State; }
        set { nETIMT_State = value; }
    }

    public Guid NETPCT_ID
    {
        get { return nETPCT_ID; }
        set { nETPCT_ID = value; }
    }

    public Guid HRDD_ID
    {
        get { return hRDD_ID; }
        set { hRDD_ID = value; }
    }

    public string NETPCT_FResult
    {
        get { return nETPCT_FResult; }
        set { nETPCT_FResult = value; }
    }

    public string HRDD_StaffNO
    {
        get { return hRDD_StaffNO; }
        set { hRDD_StaffNO = value; }
    }

    public string HRDD_Name
    {
        get { return hRDD_Name; }
        set { hRDD_Name = value; }
    }

    public Guid NETICT_ID
    {
        get { return nETICT_ID; }
        set { nETICT_ID = value; }
    }

    public Guid NETI_ID
    {
        get { return nETI_ID; }
        set { nETI_ID = value; }
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

    public string BDOS_Code
    {
        get { return bDOS_Code; }
        set { bDOS_Code = value; }
    }


    public string NETICT_Person
    {
        get { return nETICT_Person; }
        set { nETICT_Person = value; }
    }


    public DateTime NETICT_Time
    {
        get { return nETICT_Time; }
        set { nETICT_Time = value; }
    }

    private string nETPCT_Name;

    public string NETPCT_Name
    {
        get { return nETPCT_Name; }
        set { nETPCT_Name = value; }
    }
    private string nETPCT_Sex;

    public string NETPCT_Sex
    {
        get { return nETPCT_Sex; }
        set { nETPCT_Sex = value; }
    }

    private DateTime nETPCT_Date;

    public DateTime NETPCT_Date
    {
        get { return nETPCT_Date; }
        set { nETPCT_Date = value; }
    }
    public NewEmpInfoAddInfo()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }
    public NewEmpInfoAddInfo(string NETIMT_Person,DateTime NETIMT_Time,string NETIMT_Remarks)
    {
        nETIMT_Person = NETIMT_Person;
        nETIMT_Time = NETIMT_Time;
        nETIMT_Remarks = NETIMT_Remarks;
    }
}