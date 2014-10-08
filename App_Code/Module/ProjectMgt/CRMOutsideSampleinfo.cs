using System;

/// <summary>
///CRMOutsideSampleinfo 的摘要说明
/// </summary>
public class CRMOutsideSampleinfo
{
    private Guid cRMOS_ID;

    public Guid CRMOS_ID
    {
        get { return cRMOS_ID; }
        set { cRMOS_ID = value; }
    }
    private string cRMOS_Factory;

    public string CRMOS_Factory
    {
        get { return cRMOS_Factory; }
        set { cRMOS_Factory = value; }
    }
    private DateTime cRMOS_Time;

    public DateTime CRMOS_Time
    {
        get { return cRMOS_Time; }
        set { cRMOS_Time = value; }
    }
    private int cRMOS_AlertDay;

    public int CRMOS_AlertDay
    {
        get { return cRMOS_AlertDay; }
        set { cRMOS_AlertDay = value; }
    }
    private string cRMOS_AnalysisReport;

    public string CRMOS_AnalysisReport
    {
        get { return cRMOS_AnalysisReport; }
        set { cRMOS_AnalysisReport = value; }
    }
    private Decimal cRMOS_Num;

    public Decimal CRMOS_Num
    {
        get { return cRMOS_Num; }
        set { cRMOS_Num = value; }
    }
    private string cRMOS_Remark;

    public string CRMOS_Remark
    {
        get { return cRMOS_Remark; }
        set { cRMOS_Remark = value; }
    }
    private string cRMOS_State;

    public string CRMOS_State
    {
        get { return cRMOS_State; }
        set { cRMOS_State = value; }
    }
    private string cRMOS_AnalysisResult;

    public string CRMOS_AnalysisResult
    {
        get { return cRMOS_AnalysisResult; }
        set { cRMOS_AnalysisResult = value; }
    } 
	public CRMOutsideSampleinfo()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    public CRMOutsideSampleinfo(Guid _cRMOS_ID,string _cRMOS_Factory,DateTime _cRMOS_Time,int _cRMOS_AlertDay,
    string  _cRMOS_AnalysisReport,Decimal _cRMOS_Num,string _cRMOS_Remark,string _cRMOS_State,string _cRMOS_AnalysisResult)
    {
    cRMOS_ID=_cRMOS_ID;
    cRMOS_Factory=_cRMOS_Factory;
   cRMOS_Time=_cRMOS_Time;
   cRMOS_AlertDay=_cRMOS_AlertDay;
    cRMOS_AnalysisReport=_cRMOS_AnalysisReport;
    cRMOS_Num=_cRMOS_Num;
     cRMOS_Remark=_cRMOS_Remark;
  cRMOS_State=_cRMOS_State;
  cRMOS_AnalysisResult = _cRMOS_AnalysisResult; 
    }
}