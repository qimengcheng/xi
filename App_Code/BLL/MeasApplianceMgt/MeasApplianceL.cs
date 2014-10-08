using System;
using System.Data;

/// <summary>
///MeasApplianceL 的摘要说明
/// </summary>
public class MeasApplianceL
{
    private static readonly IMeasAppliance iMA = DALFactory.CreateMeasAppliance();
    public MeasApplianceL()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    public int Insert_MeasApplianceMan(MeasApplianceMan MA)
    {
        return iMA.Insert_MeasApplianceMan(MA);
    }
    public int Update_MeasApplianceMan(MeasApplianceMan MA)
    {
        return iMA.Update_MeasApplianceMan(MA);
    }
    public int Delete_MeasApplianceMan(Guid ID)
    {
        return iMA.Delete_MeasApplianceMan(ID);
    }
    public DataSet Select_MeasApplianceMan(string Condition)
    {
        return iMA.Select_MeasApplianceMan(Condition);
    }
    public DataSet SelectByID_MeasApplianceMan(Guid id)
    {
        return iMA.SelectByID_MeasApplianceMan(id);
    }
    public int Insert_MeasApplianceDetail(MeasApplianceDetail MA)
    {
        return iMA.Insert_MeasApplianceDetail(MA);
    }
    public int Update_MeasApplianceDetail(MeasApplianceDetail MA)
    {
        return iMA.Update_MeasApplianceDetail(MA);
    }
    public void Delete_MeasApplianceDetail(Guid ID)
    {
        iMA.Delete_MeasApplianceDetail(ID);
    }
    public DataSet Select_MeasApplianceDetail(Guid id)
    {
        return iMA.Select_MeasApplianceDetail(id);
    }
}