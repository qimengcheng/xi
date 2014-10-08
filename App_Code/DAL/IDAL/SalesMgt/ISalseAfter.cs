using System;
using System.Data;

/// <summary>
///ISalseAfter 的摘要说明
/// </summary>
public interface ISalseAfter
{
    //public ISalseDeliver()
    //{
    //    //
    //    //TODO: 在此处添加构造函数逻辑
    //    //
    //}
         void Insert_KesuDetail(Guid id,Guid id1,string batchnum,int num,int losenum, string re,string condition);
         DataSet Select_Dingdan(string condition);
         void Update_ShouhouMain_Check(Guid id, string result,string man,string opinion);
         void Update_ShouhouDetail( Guid id,string result);
         void Delete_Kesu_Detail(Guid id);
         DataSet Select_Kehu(string condition);
         void Insert_KesuMain(Guid Cid, Guid Shouhouid, Guid tousuID, int day, string remark, string man);
         DataSet Select_ShouhouDetail(Guid  condition);
         DataSet Select_ShouhouMain(string  condition);
         void Delete_TousuSort(Guid id);
         void Update_ShouhouSort(Guid id, string name, string detail, string man);
         void Insert_ShouhouSort(string name, string detail, string man);
         void Delete_ShouhouSort(Guid id);
         void Update_TousuSort(Guid id ,string name, string detail, string man);
         void Insert_TousuSort(string name,string detail,string man);
         DataSet Select_ShouhouSort(string condition);
         DataSet Select_TousuSort(string condition);
         void Delete_KesuMain(Guid id);
         void Update_KesuDetail(Guid id, string path);
}