using System;
using System.Data;

/// <summary>
///IIMInStore 的摘要说明
/// </summary>
public interface IIMInStore
{
    DataSet Select_InStoreMain(string condition);
    DataSet Select_InStoreDelete(string condition);
    void Update_InStoreMain(Guid ID, string Company, string ResponseMan);
    void Delete_InStoreMain(Guid ID);
    void Insert_IMInStoreMain(Guid sortID, Guid StoreID, string company, string man, string responman);
    DataSet Select_IMInStoreSort(string condition);
    DataSet Select_Area(Guid StoreID);
    DataSet Select_Store(string depart, string man);
    void Update_InStoreDetail(Guid MainID, string BatchName, string level, decimal shouldarr, decimal actualarr, decimal perweight, decimal totalweight, Guid area);
    void Insert_InStoreDetail(Guid MainID, int sort, Guid ID, string BatchName, string level, decimal shouldarr, decimal actualarr, decimal perweight, decimal totalweight, Guid area);
    DataSet Select_InStoreDetail_MaterialBasic(string condition);
    DataSet Select_InStoreDetail(string condition);
    DataSet Select_MatType();
    void Update_IMInStore_InventoryMain_Detail(Guid ID);
    DataSet Select_Purchase(string condition);
    void Insert_IMInStoreDetail_Purchase(Guid PD_ID, Guid ISM_ID);
    DataSet Select_Return(string condition);
    void Insert_IMInStoreDetail_Return(Guid PD_ID, Guid ISM_ID);
    DataSet Select_Suigongdan(string condition);
    void Insert_IMInStoreDetail_Suigongdan(Guid PD_ID, Guid ISM_ID);
    void Delete_IMInStoreDetail_Return(Guid ISD_ID);
    void Delete_IMInStoreDetail(Guid ISD_ID);
    void Update_IMInstroeDetail_PMPurchaseOrderDetail_ActualNum(Guid imism_ID);
    void Update_IMInstroeDetail_State_Detail(Guid IMISM_ID);
    void Update_IMInstroeDetail_PMPurchaseOrderDetail_ChangeNum(Guid imisd_ID);
     void Update_IMInstroeMain_WorkOrder(Guid imism_ID);
}