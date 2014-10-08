using System.Data;

/// <summary>
///ICRMOutsideSample 的摘要说明
/// </summary>
public interface ICRMOutsideSample
{
    DataSet SelectCRMOutsideSample(string condition);
    void InsertCRMOutsideSample(CRMOutsideSampleinfo cRMOutsideSampleinfo);
    void UpdateCRMOutsideSample(CRMOutsideSampleinfo cRMOutsideSampleinfo);
    void DeleteCRMOutsideSample(CRMOutsideSampleinfo cRMOutsideSampleinfo);
    void UpdateCRMOutsideSample_Analysis(CRMOutsideSampleinfo cRMOutsideSampleinfo);

}