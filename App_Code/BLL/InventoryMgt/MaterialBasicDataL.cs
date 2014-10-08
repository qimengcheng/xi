using System;
using System.Data;

/// <summary>
///MaterialBasicDataL 的摘要说明
/// </summary>
public class MaterialBasicDataL
{

    private static readonly IMaterialBasicData mat = DALFactory.MaterialBasicData();
    public MaterialBasicDataL()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    //从表格点击查询物料
    public DataSet Select_MaterialBasicDataForGridview(Guid MaterialTypeID)
    {
        return mat.Select_MaterialBasicDataForGridview(MaterialTypeID);
    }
    //修改物料类型
    public void Update_MaterialType(Guid MaterialTypeID, string MaterialTypeName, string Statement)
    {
        mat.Update_MaterialType(MaterialTypeID, MaterialTypeName, Statement);
    }
    //下拉框筛选物料类别
    public DataSet Select_MaterialType()
    {
        return mat.Select_MaterialType();
    }
    //删除物料类别
    public void Delete_MaterialType(Guid MaterialTypeID)
    {
        mat.Delete_MaterialType(MaterialTypeID);
    }
    //筛选物料名称明细
    public DataSet Select_MaterialBasicData(string conditon)
    {
        return mat.Select_MaterialBasicData(conditon);
    }
    //新建物料类型
    public void Insert_MaterialType(string MaterialType, string Statement)
    {
        mat.Insert_MaterialType(MaterialType, Statement);
    }
    //新建物料名称明细
    public void Insert_MaterialBasicData(Guid MaterialTypeID, string MaterialName, string SpecificationModel, decimal SafeStock
        , int StorageDay, string Harmful, Guid Unit, string Comment, string Para, string code, int pianshu, decimal zhuanrate, decimal peiweight)
    {
        mat.Insert_MaterialBasicData(MaterialTypeID, MaterialName, SpecificationModel, SafeStock, StorageDay, Harmful, Unit, Comment, Para,code,pianshu,zhuanrate,peiweight);
    }
    //修改物料名称明细
    public void Update_MaterialBasicData(Guid MaterialID, Guid MaterialTypeID, string MaterialName, string SpecificationModel, decimal SafeStock
        , int StorageDay, string Harmful, Guid Unit, string Comment, string Para, decimal rate, string code, int pianshu, decimal zhuanrate, decimal peiweight)
    {
        mat.Update_MaterialBasicData(MaterialID, MaterialTypeID, MaterialName, SpecificationModel, SafeStock, StorageDay, Harmful, Unit, Comment, Para,rate,code,pianshu,zhuanrate,peiweight);
    }
    //删除物料名称明细
    public void Delete_MaterialBasicData(Guid MaterialID)
    {
        mat.Delete_MaterialBasicData(MaterialID);
    }

    //默认绑定物料类别表
    public DataSet Select_V_MaterialType()
    {
        return mat.Select_V_MaterialType();
    }
    //查询单条物料详细
    public DataSet Select_IMMaterialBasicData_One(Guid MaterialID)
    {
        return mat.Select_IMMaterialBasicData_One(MaterialID);
    }
    public int Select_IMMaterialTypeRepeat(string name)
    {
        return mat.Select_IMMaterialTypeRepeat(name);
    }
    public int Select_IMMaterialBasicRepeat(string name,string model)
    {
        return mat.Select_IMMaterialBasicRepeat(name,model);
    }
    public DataSet Select_MaterialTypeCondition(string condition)
    {
        return mat.Select_MaterialTypeCondition(condition);
    }
    public DataSet Select_Unit_Mat()
    {
        return mat.Select_Unit_Mat();
    }
}