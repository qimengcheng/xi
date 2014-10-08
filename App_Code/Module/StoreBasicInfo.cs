using System;

/// <summary>
///StoreBasic 的摘要说明
/// </summary>
public class StoreBasicInfo
{
    public StoreBasicInfo(){}


    public StoreBasicInfo(Guid _iMSSBD_ID, string _iMSSBD_Sort, string _iMSSBD_Name, string _iMSSBD_Detail
        , string _iMSSBD_Man, DateTime _iMSSBD_Time, Boolean _iMSSBD_IsDelete, Guid _iMS_StoreID, string _iMS_StoreName
        , string _iMS_ResponDepart, string _iMS_ResponMan, Boolean _iMS_IsDelete)
	{
        iMSSBD_ID = _iMSSBD_ID;
        iMSSBD_Sort = _iMSSBD_Sort;
        iMSSBD_Name = _iMSSBD_Name;
        iMSSBD_Detail = _iMSSBD_Detail;
        iMSSBD_Man = _iMSSBD_Man;
        iMSSBD_Time = _iMSSBD_Time;
        iMSSBD_IsDelete = _iMSSBD_IsDelete;
        iMS_StoreID = _iMS_StoreID;
        iMS_StoreName = _iMS_StoreName;
        iMS_ResponDepart = _iMS_ResponDepart;
        iMS_ResponMan = _iMS_ResponMan;
        iMS_IsDelete = _iMS_IsDelete;
	}

    private Guid iMSSBD_ID;//出入库类别ID
    public Guid IMSSBD_ID
    {
        get { return iMSSBD_ID; }
        set { iMSSBD_ID = value; }
    }
private int flag ;
    public int Flag
    {
        get { return flag; }
        set { flag = value; }
    }


    private string iMSSBD_Sort;//出入库类别
    public string IMSSBD_Sort
    {
        get { return iMSSBD_Sort; }
        set { iMSSBD_Sort = value; }
    }

    private string iMSSBD_Name;//类别名称
    public string IMSSBD_Name
    {
        get { return iMSSBD_Name; }
        set { iMSSBD_Name = value; }
    }

    private string iMSSBD_Detail;//类别具体描述
    public string IMSSBD_Detail
    {
        get { return iMSSBD_Detail; }
        set { iMSSBD_Detail = value; }
    }

    private string iMSSBD_Man;//类别制定人
    public string IMSSBD_Man
    {
        get { return iMSSBD_Man; }
        set { iMSSBD_Man = value; }
    }

    private DateTime iMSSBD_Time;//类别制定时间
    public DateTime IMSSBD_Time
    {
        get { return iMSSBD_Time; }
        set { iMSSBD_Time = value; }
    }

    private Boolean iMSSBD_IsDelete;//类型是否删除
    public Boolean IMSSBD_IsDelete
    {
        get { return iMSSBD_IsDelete; }
        set { iMSSBD_IsDelete = value; }
    }


    private Guid iMS_StoreID;//库房ID
    public Guid IMS_StoreID
    {
        get { return iMS_StoreID; }
        set { iMS_StoreID = value; }
    }

    private string iMS_StoreName;//库房名称
    public string IMS_StoreName
    {
        get { return iMS_StoreName; }
        set { iMS_StoreName = value; }
    }

    private string iMS_ResponDepart;//管理部门
    public string IMS_ResponDepart
    {
        get { return iMS_ResponDepart; }
        set { iMS_ResponDepart = value; }
    }

    private string iMS_ResponMan;//管理人员
    public string IMS_ResponMan
    {
        get { return iMS_ResponMan; }
        set { iMS_ResponMan = value; }
    }

    private Boolean iMS_IsDelete;//库房是否删除
    public Boolean IMS_IsDelete
    {
        get { return iMS_IsDelete; }
        set {iMS_IsDelete = value; }
    }
    private string iMSA_AreaName;//区域名称
    public string IMSA_AreaName
    {
        get { return iMSA_AreaName; }
        set { iMSA_AreaName = value; }
    }

    private string iMSA_Remark;//区域备注
    public string IMSA_Remark
    {
        get { return iMSA_Remark; }
        set { iMSA_Remark = value; }
    }

    private string iMSA_MakeMan;//区域添加人员
    public string IMSA_MakeMan
    {
        get { return iMSA_MakeMan; }
        set { iMSA_MakeMan = value; }
    }

    private Guid iMSA_AreaID;//区域ID
    public Guid IMSA_AreaID
    {
        get { return iMSA_AreaID; }
        set { iMSA_AreaID = value; }
    }
}