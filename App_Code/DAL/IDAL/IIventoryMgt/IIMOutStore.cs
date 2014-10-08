using System;
using System.Data;

/// <summary>
///IIMOutStore 的摘要说明
/// </summary>
public interface IIMOutStore
{
    DataSet Select_lingliaoMain(string condition);
    void Delete_lingliaoMain(Guid ID);
    DataSet Select_IMIM_Mat(string condition);
    DataSet Select_IMIM_PT(string condition);
    void Insert_LingliaoDetail(Guid ID, Guid IMIM_ID);
    void Insert_LingliaoMain(string man, Guid StoreID, string Depart);
    DataSet Select_IMInventoryDetail(string condition);
    DataSet Select_IMInventoryMain(string condition);
    DataSet Select_IMOuthouseDetail(string condition);
    DataSet Select_IMRD_SUM(string man);
    void Insert_IMRD_SUM(Guid ID, string man);
    void Delete_IMRD_SUM(string man);
    DataSet Select_IMRequisitionDetail(string condition);
    DataSet Select_IMStore();
    void Update_LingliaoMain_Check(Guid RID, string Resutl, string opinion);
    void Update_LingliaoDetail(Guid ID);
    DataSet Select_IMRequisitionMain_CheckResult(Guid ID);
    DataSet Select_IMOutM(string condition);
    DataSet Select_IMOuthouseSort(string condition);
    void Insert_OutM(Guid sortID, Guid StoreID, string man, string company);
    DataSet Select_Store(string depart, string man);
    void Delete_OutM(Guid id);
    void Delete_OutD(Guid id);
    void Insert_IMOutD_Yiban(Guid IMID_ID, Guid IMOHM_ID, Decimal IMOHD_Num);
     void Insert_IMOutD_Lingliao(Guid IMID_ID, Guid IMOHM_ID, Decimal IMOHD_Num, string man);
    void Update_IMOutM(Guid id);
    void Update_IMOutM_IMIM(Guid id, string man);
    void Delete_LingliaoD(Guid id);
    void Update_LingliaoD(Guid id, decimal num, string remark);
    void Insert_Pandian(Guid IMIM_ID, string man);
    void Update_Pandian(Guid IMC_ID, decimal IMC_ActualTotalNum);
    DataSet Select_Pandian(string condition);
    void Delete_Pandian(Guid IMC_ID);
    void Insert_SalesOut_Main(Guid ID, string man, string company, string model, string modelnum);
    void Delete_SalesOut_Temp(string man);
    void Insert_SalesOut_Deliver(Guid id, string man);
    DataSet Select_Xiashoukucun(string condition);
    void Insert_IMOutD_Xiaoshou(Guid IMID_ID, string man, Decimal IMOHD_Num,Guid PID,Guid Mid);
    void Update_IMOutHouseMain_Xiaoshou(string man);
      void Insert_IMSalesOutTEMP(Guid id);
      void Delete_IMSalesOutTEMP();
       void Insert_SMOrderDeliver_SalesOut(Guid id);
       void Update_SMOrderDeliver_SalesOut(Guid id, string model, string num);
}