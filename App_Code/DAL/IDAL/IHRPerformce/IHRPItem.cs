using System;
using System.Collections.Generic;
using System.Data;
/// <summary>
///IHRPItem 的摘要说明
/// </summary>
public interface IHRPItem
{
    int Insert_HRPerformceItem(HRPItemInfo hr);
    void Delete_HRPerformceItem(Guid ID);
    DataSet Search_HRPerformceItem(string condition);
    int Update_HRPerformceItem(HRPItemInfo hr);
    IList<HRPItemInfo> SearchByID_HRPItem(Guid HRPI_ItemID);
    DataSet Search_HRPerformceItem_HRPerformAssessType(string condition);
}