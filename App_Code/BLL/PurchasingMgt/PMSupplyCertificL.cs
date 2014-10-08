using System.Data;

/// <summary>
///PMSupplyCertificL 的摘要说明
/// </summary>
public class PMSupplyCertificL
{
    private static readonly IPMSupplyCertific PRMP = DALFactory.CreatePMSupplyCertific();
	public PMSupplyCertificL()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    public DataSet SelectPMSupplyCertificApply(string condition)
    {
        return PRMP.SelectPMSupplyCertificApply(condition);
    }
    public void InsertPMSupplyCertificApply(PMSupplyCertificinfo pMSupplyCertificinfo)
    {
        PRMP.InsertPMSupplyCertificApply(pMSupplyCertificinfo);
    }
    public void DeletePMSupplyCertificApply(PMSupplyCertificinfo pMSupplyCertificinfo)
    {
        PRMP.DeletePMSupplyCertificApply(pMSupplyCertificinfo);
    }
    public DataSet SelectPMSupplyCertificApply_One(PMSupplyCertificinfo pMSupplyCertificinfo)
    {
        return PRMP.SelectPMSupplyCertificApply_One(pMSupplyCertificinfo);
    }
    public void UpdatePMSupplyCertificApply(PMSupplyCertificinfo pMSupplyCertificinfo)
    {
        PRMP.UpdatePMSupplyCertificApply(pMSupplyCertificinfo);
    }
    public void InsertPMSupplyCertificInfo(PMSupplyCertificinfo pMSupplyCertificinfo)
    {
        PRMP.InsertPMSupplyCertificInfo(pMSupplyCertificinfo);
    }
    public void UpdatePMSupplyCertificInfo(PMSupplyCertificinfo pMSupplyCertificinfo)
    {
        PRMP.UpdatePMSupplyCertificInfo(pMSupplyCertificinfo);
    }
    public DataSet SelectPMSupplyCertificInfo(PMSupplyCertificinfo pMSupplyCertificinfo)
    {
        return PRMP.SelectPMSupplyCertificInfo(pMSupplyCertificinfo);
    }
    public DataSet SelectPMSupplyCertificInfo_One(PMSupplyCertificinfo pMSupplyCertificinfo)
    {
        return PRMP.SelectPMSupplyCertificInfo_One(pMSupplyCertificinfo);
    }
    public void DeletePMSupplyCertificInfo_One(PMSupplyCertificinfo pMSupplyCertificinfo)
    {
        PRMP.DeletePMSupplyCertificInfo_One(pMSupplyCertificinfo);
    }
    public void UpdatePMSCA_State(PMSupplyCertificinfo pMSupplyCertificinfo)
    {
        PRMP.UpdatePMSCA_State(pMSupplyCertificinfo);
    }
    public void InsertPMSCA_QASign(PMSupplyCertificinfo pMSupplyCertificinfo)
    {
       PRMP . InsertPMSCA_QASign(pMSupplyCertificinfo);
    }
    public void InsertPMSCA_PDSign(PMSupplyCertificinfo pMSupplyCertificinfo)
    {
        PRMP.InsertPMSCA_PDSign(pMSupplyCertificinfo);
    }
    public void InsertPMSCA_EDSign(PMSupplyCertificinfo pMSupplyCertificinfo)
    {
        PRMP.InsertPMSCA_EDSign(pMSupplyCertificinfo);
    }
    public void InsertPMSCA_DMCheck(PMSupplyCertificinfo pMSupplyCertificinfo)
    {
        PRMP.InsertPMSCA_DMCheck(pMSupplyCertificinfo);
    }
    public void InsertPMSCA_GMCheck(PMSupplyCertificinfo pMSupplyCertificinfo)
    {
        PRMP.InsertPMSCA_GMCheck(pMSupplyCertificinfo);
    }
    public void SelectPMSupply(PMSupplyCertificinfo pMSupplyCertificinfo)
    {
        PRMP.SelectPMSupply(pMSupplyCertificinfo);
    }
    public DataSet SelectPMSCA_DMCheckOpinion(PMSupplyCertificinfo pMSupplyCertificinfo)
    {
      return   PRMP.SelectPMSCA_DMCheckOpinion(pMSupplyCertificinfo);
    }
    public void InsertPMSupplyCertificApplyCountersign(PMSupplyCertificinfo pMSupplyCertificinfo)
    {
        PRMP.InsertPMSupplyCertificApplyCountersign(pMSupplyCertificinfo);
    }
    public void UpdatePMSupplyCertificApplyCountersign(PMSupplyCertificinfo pMSupplyCertificinfo)
    {
        PRMP.UpdatePMSupplyCertificApplyCountersign(pMSupplyCertificinfo);
    }
    public DataSet SelectPMSupplyCertificApplyCountersign(PMSupplyCertificinfo pMSupplyCertificinfo)
    {
        return PRMP.SelectPMSupplyCertificApplyCountersign(pMSupplyCertificinfo);
    }
    public DataSet SelectPMSCAC_Organization(string condition)
    {
        return PRMP.SelectPMSCAC_Organization(condition);
    }
    public DataSet SelectPMSupplyCertificApplyCountersign_One(PMSupplyCertificinfo pMSupplyCertificinfo)
    {
        return PRMP.SelectPMSupplyCertificApplyCountersign_One(pMSupplyCertificinfo);
    }
    public void DeletePMSupplyCertificApplyCountersign(PMSupplyCertificinfo pMSupplyCertificinfo)
    {
        PRMP.DeletePMSupplyCertificApplyCountersign(pMSupplyCertificinfo);
    }
}