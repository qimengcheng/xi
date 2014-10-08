using System;
using System.Data;

/// <summary>
///IMaterialBasicData 的摘要说明
/// </summary>
public interface IMaterialBasicData
{

    DataSet Select_MaterialBasicDataForGridview(Guid MaterialTypeID);
    void Update_MaterialType(Guid MaterialTypeID, string MaterialTypeName, string Statement);
    DataSet Select_MaterialType();
    void Delete_MaterialType(Guid MaterialTypeID);
    DataSet Select_MaterialBasicData(string conditon);
    void Insert_MaterialType(string MaterialType, string Statement);
    void Insert_MaterialBasicData(Guid MaterialTypeID, string MaterialName, string SpecificationModel, decimal SafeStock
        , int StorageDay, string Harmful, Guid Unit, string Comment, string Para, string code, int pianshu, decimal zhuanrate, decimal peiweight);
    void Update_MaterialBasicData(Guid MaterialID, Guid MaterialTypeID, string MaterialName, string SpecificationModel, decimal SafeStock
        , int StorageDay, string Harmful, Guid Unit, string Comment, string Para, decimal rate, string code, int pianshu, decimal zhuanrate, decimal peiweight);
    void Delete_MaterialBasicData(Guid MaterialID);
    DataSet Select_V_MaterialType();
    DataSet Select_IMMaterialBasicData_One(Guid MaterialID);
    int Select_IMMaterialTypeRepeat(string name);
    int Select_IMMaterialBasicRepeat(string name,string model);
    DataSet Select_MaterialTypeCondition(string condition);
    DataSet Select_Unit_Mat();
}

