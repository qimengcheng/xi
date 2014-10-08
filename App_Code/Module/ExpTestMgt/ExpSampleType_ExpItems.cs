using System;

/// <summary>
///ExpSampleTypeInfo 的摘要说明
/// </summary>
public class ExpSampleType_ExpItems
{
    private Guid eST_SampleTypeID;

    public Guid EST_SampleTypeID
    {
        get { return eST_SampleTypeID; }
        set { eST_SampleTypeID = value; }
    }
    private string eST_SampleType;

    public string EST_SampleType
    {
        get { return eST_SampleType; }
        set { eST_SampleType = value; }
    }
    private bool eST_IsDeleted;

    public bool EST_IsDeleted
    {
        get { return eST_IsDeleted; }
        set { eST_IsDeleted = value; }
    }
        private Guid eI_ExpItemID;

    public Guid EI_ExpItemID
    {
        get { return eI_ExpItemID; }
        set { eI_ExpItemID = value; }
    }
    
    private string eI_ExpItem;

    public string EI_ExpItem
    {
        get { return eI_ExpItem; }
        set { eI_ExpItem = value; }
    }


    private string eI_ExpCondtition;

    public string EI_ExpCondtition
    {
        get { return eI_ExpCondtition; }
        set { eI_ExpCondtition = value; }
    }
    private string eI_ExpMethold;

    public string EI_ExpMethold
    {
        get { return eI_ExpMethold; }
        set { eI_ExpMethold = value; }
    }
    private bool eI_IsDeleted;

    public bool EI_IsDeleted
    {
        get { return eI_IsDeleted; }
        set { eI_IsDeleted = value; }
    }

    public ExpSampleType_ExpItems(Guid _eI_ExpItemID, string _eI_ExpItem, 
        string _eI_ExpCondtition, string _eI_ExpMethold, bool  _eI_IsDeleted)
    {
        eI_ExpItemID = _eI_ExpItemID;
        eI_ExpItem = _eI_ExpItem;
        eI_ExpCondtition = _eI_ExpCondtition;
        eI_ExpMethold = _eI_ExpMethold;
        eI_IsDeleted = _eI_IsDeleted;    
    }
    public ExpSampleType_ExpItems(string _eI_ExpItem,string _eI_ExpCondtition, string _eI_ExpMethold)
    {
        eI_ExpItem = _eI_ExpItem;
        eI_ExpCondtition = _eI_ExpCondtition;
        eI_ExpMethold = _eI_ExpMethold;
    }
    public ExpSampleType_ExpItems(Guid _eST_SampleTypeID, string _eST_SampleType, bool _eST_IsDeleted)
    {
        eST_SampleTypeID = _eST_SampleTypeID;
        eST_SampleType = _eST_SampleType;
        eST_IsDeleted = _eST_IsDeleted;
    }
    public ExpSampleType_ExpItems(string _eST_SampleType)
    {
        eST_SampleType = _eST_SampleType;
    }
    public ExpSampleType_ExpItems()
    {

    }
}