using System;
using System.Data;
using System.Collections.Generic;

/// <summary>
///UMModelInfo 的摘要说明
/// </summary>
public interface IUMModelInfo
{
    void InsertUMModelInfo(UMModelInfoinfo umii);
    string CheckUMModelInfo(Guid PMPK_ID, string UMMI_ModelName);
    IList<UMModelInfoinfo> SearchModelName(Guid PMPK_ID);
    DataSet SelectModelInfoByModelID(Guid ModelID);
}
