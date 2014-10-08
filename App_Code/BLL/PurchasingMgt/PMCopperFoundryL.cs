using System.Data;

/// <summary>
///PMCopperFoundryL 的摘要说明
/// </summary>
public class PMCopperFoundryL
{
    private static readonly IPMCopperFoundry IPF = DALFactory.CreatePMCopperFoundry();
	public PMCopperFoundryL()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    public DataSet SelectPMCopperFoundry(string condition)
    {
        return IPF.SelectPMCopperFoundry(condition);
    }
    public void InsertPMCopperFoundry(PMCopperFoundryinfo pMCopperFoundryinfo)
    {
        IPF.InsertPMCopperFoundry(pMCopperFoundryinfo);
    }
    public void UpdatePMCopperFoundry(PMCopperFoundryinfo pMCopperFoundryinfo)
    {
        IPF.UpdatePMCopperFoundry(pMCopperFoundryinfo);
    }
    public DataSet SelectPMCopperIn(PMCopperFoundryinfo pMCopperFoundryinfo)
    {
       return  IPF.SelectPMCopperIn(pMCopperFoundryinfo);
    }
    public DataSet SelectPMCopperReturn(PMCopperFoundryinfo pMCopperFoundryinfo)
    {
       return  IPF.SelectPMCopperReturn(pMCopperFoundryinfo);
    }
    public DataSet SelectPMCopperProcess(PMCopperFoundryinfo pMCopperFoundryinfo)
    {
       return IPF.SelectPMCopperProcess(pMCopperFoundryinfo);
    }
    public void InsertPMCopperIn(PMCopperFoundryinfo pMCopperFoundryinfo)
    {
        IPF.InsertPMCopperIn(pMCopperFoundryinfo);
    }
    public void InsertPMCopperReturn(PMCopperFoundryinfo pMCopperFoundryinfo)
    {
        IPF.InsertPMCopperReturn(pMCopperFoundryinfo);
    }
    public void InsertPMCopperProcess(PMCopperFoundryinfo pMCopperFoundryinfo)
    {
        IPF.InsertPMCopperProcess(pMCopperFoundryinfo);
    }
    public void UpdatePMCopperIn(PMCopperFoundryinfo pMCopperFoundryinfo)
    {
        IPF.UpdatePMCopperIn(pMCopperFoundryinfo);
    }
    public void UpdatePMCopperReturn(PMCopperFoundryinfo pMCopperFoundryinfo)
    {
        IPF.UpdatePMCopperReturn(pMCopperFoundryinfo);
    }
    public void UpdatePMCopperProcess(PMCopperFoundryinfo pMCopperFoundryinfo)
    { 
    IPF.UpdatePMCopperProcess(pMCopperFoundryinfo);
    }
    public void DeletePMCopperProcess(PMCopperFoundryinfo pMCopperFoundryinfo)
    {
        IPF.DeletePMCopperProcess(pMCopperFoundryinfo);
    }
    public void DeletePMCopperIn(PMCopperFoundryinfo pMCopperFoundryinfo)
    {
        IPF.DeletePMCopperIn(pMCopperFoundryinfo);
    }
    public void DeletePMCopperReturn(PMCopperFoundryinfo pMCopperFoundryinfo)
    {
        IPF.DeletePMCopperReturn(pMCopperFoundryinfo);
    }
}