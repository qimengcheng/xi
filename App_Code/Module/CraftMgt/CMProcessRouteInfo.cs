using System;

/// <summary>
///CMProcessRouteInfo 的摘要说明
/// </summary>
public class CMProcessRouteInfo
{
    private Guid pR_ID;

    public Guid PR_ID
    {
        get { return pR_ID; }
        set { pR_ID = value; }
    }
    private Guid cDA_ID;

    public Guid CDA_ID
    {
        get { return cDA_ID; }
        set { cDA_ID = value; }
    }
    private string pR_Special;

    public string PR_Special
    {
        get { return pR_Special; }
        set { pR_Special = value; }
    }
    private string pR_Name;

    public string PR_Name
    {
        get { return pR_Name; }
        set { pR_Name = value; }
    }
    private string pR_WritePeople;

    public string PR_WritePeople
    {
        get { return pR_WritePeople; }
        set { pR_WritePeople = value; }
    }

    private Guid pRD_ID;

    public Guid PRD_ID
    {
        get { return pRD_ID; }
        set { pRD_ID = value; }
    }

    private Int16 pRD_Order;

    public Int16 PRD_Order
    {
        get { return pRD_Order; }
        set { pRD_Order = value; }
    }
    private string pRD_Doc;

    public string PRD_Doc
    {
        get { return pRD_Doc; }
        set { pRD_Doc = value; }
    }
    private string pRD_Way;

    public string PRD_Way
    {
        get { return pRD_Way; }
        set { pRD_Way = value; }
    }
    private string pRD_Note;

    public string PRD_Note
    {
        get { return pRD_Note; }
        set { pRD_Note = value; }
    }



    public CMProcessRouteInfo()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }
    public CMProcessRouteInfo(Guid _pRD_ID, Int16 _pRD_Order, string _pRD_Doc, string _pRD_Way,string _pRD_Note, Guid _pR_ID, Guid _cDA_ID, string _pR_Special, string _pR_Name, string _pR_WritePeople)
    {
        pRD_ID = _pRD_ID;
        pRD_Order = _pRD_Order;
        PRD_Doc = _pRD_Doc;
        pRD_Way = _pRD_Way;
        pRD_Note = _pRD_Note;
        PR_ID = _pR_ID;
        cDA_ID = _cDA_ID;
        pR_Special = _pR_Special;
        pR_Name = _pR_Name;
        PR_WritePeople = _pR_WritePeople;
    }
}