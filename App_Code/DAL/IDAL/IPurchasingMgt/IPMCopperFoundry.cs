using System.Data;

/// <summary>
///IPMCopperFoundry 的摘要说明
/// </summary>
public interface IPMCopperFoundry
{
    DataSet SelectPMCopperFoundry(string condition);
    void InsertPMCopperFoundry(PMCopperFoundryinfo pMCopperFoundryinfo);
    void UpdatePMCopperFoundry(PMCopperFoundryinfo pMCopperFoundryinfo);
    DataSet SelectPMCopperIn(PMCopperFoundryinfo pMCopperFoundryinfo);
    DataSet SelectPMCopperReturn(PMCopperFoundryinfo pMCopperFoundryinfo);
    DataSet SelectPMCopperProcess(PMCopperFoundryinfo pMCopperFoundryinfo);
    void InsertPMCopperIn(PMCopperFoundryinfo pMCopperFoundryinfo);
    void InsertPMCopperReturn(PMCopperFoundryinfo pMCopperFoundryinfo);
    void InsertPMCopperProcess(PMCopperFoundryinfo pMCopperFoundryinfo);
    void UpdatePMCopperIn(PMCopperFoundryinfo pMCopperFoundryinfo);
    void UpdatePMCopperReturn(PMCopperFoundryinfo pMCopperFoundryinfo);
    void UpdatePMCopperProcess(PMCopperFoundryinfo pMCopperFoundryinfo);
    void DeletePMCopperProcess(PMCopperFoundryinfo pMCopperFoundryinfo);
    void DeletePMCopperIn(PMCopperFoundryinfo pMCopperFoundryinfo);
    void DeletePMCopperReturn(PMCopperFoundryinfo pMCopperFoundryinfo);

}