using System;
using System.Data;
using System.Data.SqlClient;
//using System.Collections.Generic;
using EquipmentMangementAjax.DBUtility;

/// <summary>
///MaterialBasicDataD 的摘要说明
/// </summary>
/// 
namespace EquipmentMangementAjax.SQLServer
{
    public class MaterialBasicDataD : IMaterialBasicData
    {
        public MaterialBasicDataD()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        //通过Gridview点选物料类型去查看具体的物料名称
        public DataSet Select_MaterialBasicDataForGridview(Guid MaterialTypeID)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@IMMt_MaterialTypeID", SqlDbType.UniqueIdentifier);
            para[0].Value = MaterialTypeID;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_IMMaterialBasicData_Gridview", para);

        }

        //修改物料类型
        public void Update_MaterialType(Guid MaterialTypeID, string MaterialType, string Statement)
        {
            SqlParameter[] para = new SqlParameter[3];
            para[0] = new SqlParameter("@IMMt_MaterialTypeID", SqlDbType.UniqueIdentifier);
            para[0].Value = MaterialTypeID;
            para[1] = new SqlParameter("@IMMT_MaterialType", SqlDbType.VarChar, 50);
            para[1].Value = MaterialType;
            para[2] = new SqlParameter("@IMMT_Statement", SqlDbType.VarChar, 200);
            para[2].Value = Statement;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_IMMaterialType", para);
        }

        //下拉框搜索物料类型
        public DataSet Select_MaterialType()
        {
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_IMMaterialType");
        }

        //删除物料类型
        public void Delete_MaterialType(Guid MaterialTypeID)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@IMMt_MaterialTypeID", SqlDbType.UniqueIdentifier);
            para[0].Value = MaterialTypeID;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_IMMaterialType", para);
        }

        //模糊查询物料名称
        public DataSet Select_MaterialBasicData(string condition)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 1000);
            //设置了错误
            para[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_IMMaterialBasicData", para);
        }

        //新建物料类别
        public void Insert_MaterialType(string MaterialType, string Statement)
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@IMMT_MaterialType", SqlDbType.VarChar, 50);
            para[0].Value = MaterialType;
            para[1] = new SqlParameter("@IMMT_Statement", SqlDbType.VarChar, 200);
            para[1].Value = Statement;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_IMMaterialType", para);
        }//新建物料类别结束

        //新建物料名称
        public void Insert_MaterialBasicData(Guid MaterialTypeID, string MaterialName, string SpecificationModel, decimal SafeStock
        , int StorageDay, string Harmful, Guid Unit, string Comment, string Para,string code,int pianshu,decimal zhuanrate,decimal peiweight)
        {
            SqlParameter[] para = new SqlParameter[13];
            para[0] = new SqlParameter("@IMMT_MaterialTypeID", SqlDbType.UniqueIdentifier);
            para[0].Value = MaterialTypeID;
            para[1] = new SqlParameter("@IMMBD_MaterialName", SqlDbType.VarChar, 100);
            para[1].Value = MaterialName;
            para[2] = new SqlParameter("@IMMBD_SpecificationModel", SqlDbType.VarChar, 100);
            para[2].Value = SpecificationModel;
            para[3] = new SqlParameter("@IMMBD_SafeStock", SqlDbType.Decimal);
            para[3].Value = SafeStock;
            para[4] = new SqlParameter("@IMMBD_StorageDay", SqlDbType.Int);
            para[4].Value = StorageDay;
            para[5] = new SqlParameter("@IMMBD_IsHarmful", SqlDbType.VarChar, 2);
            para[5].Value = Harmful;
            para[6] = new SqlParameter("@unitID", SqlDbType.UniqueIdentifier);
            para[6].Value = Unit;
            para[7] = new SqlParameter("@IMMBD_Comment", SqlDbType.VarChar, 200);
            para[7].Value = Comment;
            para[8] = new SqlParameter("@IMMBD_CharacterPara", SqlDbType.VarChar, 200);
            para[8].Value = Para;
            para[9] = new SqlParameter("@IMMBD_MaterialCode", SqlDbType.VarChar, 100);
            para[9].Value = code;
            para[10] = new SqlParameter("@IMMBD_SubNum", SqlDbType.Int);
            para[10].Value = pianshu;
            para[11] = new SqlParameter("@IMMBD_Usage", SqlDbType.Decimal,18);
            para[11].Value = zhuanrate;
            para[12] = new SqlParameter("@IMMBD_Weight", SqlDbType.Decimal, 18);
            para[12].Value = peiweight;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_IMMaterialBasicData", para);
        }

        //修改物料名称明细
        public void Update_MaterialBasicData(Guid MaterialID, Guid MaterialTypeID, string MaterialName, string SpecificationModel, decimal SafeStock
        , int StorageDay, string Harmful, Guid Unit, string Comment, string Para, decimal rate, string code, int pianshu, decimal zhuanrate, decimal peiweight)
        {
            SqlParameter[] para = new SqlParameter[15];
            para[0] = new SqlParameter("@IMMBD_MaterialID", SqlDbType.UniqueIdentifier);
            para[0].Value = MaterialID;
            para[1] = new SqlParameter("@IMMt_MaterialTypeID", SqlDbType.UniqueIdentifier);
            para[1].Value = MaterialTypeID;
            para[2] = new SqlParameter("@IMMBD_MaterialName", SqlDbType.VarChar, 100);
            para[2].Value = MaterialName;
            para[3] = new SqlParameter("@IMMBD_SpecificationModel", SqlDbType.VarChar, 100);
            para[3].Value = SpecificationModel;
            para[4] = new SqlParameter("@IMMBD_SafeStock", SqlDbType.Decimal);
            para[4].Value = SafeStock;
            para[5] = new SqlParameter("@IMMBD_StorageDay", SqlDbType.Int);
            para[5].Value = StorageDay;
            para[6] = new SqlParameter("@IMMBD_IsHarmful", SqlDbType.VarChar, 2);
            para[6].Value = Harmful;
            para[7] = new SqlParameter("@IMMBD_UnitOfMeasurement", SqlDbType.UniqueIdentifier);
            para[7].Value = Unit;
            para[8] = new SqlParameter("@IMMBD_Comment", SqlDbType.VarChar, 200);
            para[8].Value = Comment;
            para[9] = new SqlParameter("@IMMBD_CharacterPara", SqlDbType.VarChar, 200);
            para[9].Value = Para;
            para[10] = new SqlParameter("@rate", SqlDbType.Decimal,18);
            para[10].Value = rate;
            para[11] = new SqlParameter("@IMMBD_MaterialCode", SqlDbType.VarChar, 100);
            para[11].Value = code;
            para[12] = new SqlParameter("@IMMBD_SubNum", SqlDbType.Int);
            para[12].Value = pianshu;
            para[13] = new SqlParameter("@IMMBD_Usage", SqlDbType.Decimal, 18);
            para[13].Value = zhuanrate;
            para[14] = new SqlParameter("@IMMBD_Weight", SqlDbType.Decimal, 18);
            para[14].Value = peiweight;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_IMMaterialBasicData", para);
        }


        //删除物料名称明细
        public void Delete_MaterialBasicData(Guid MaterialID)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@IMMBD_MaterialID", SqlDbType.UniqueIdentifier);
            para[0].Value = MaterialID;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_IMMaterialBasicData", para);
        }

        //默认绑定物料类别，从视图搜索
        public DataSet Select_V_MaterialType()
        {

            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_V_InventoryType");
        }
        //查询单条物料明细
        public DataSet Select_IMMaterialBasicData_One(Guid MaterialID)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@IMMBD_MaterialID", SqlDbType.UniqueIdentifier);
            para[0].Value = MaterialID;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_IMMaterialBasicData_One", para);
        }
        //判断物料类别名称是否重复
        public int Select_IMMaterialTypeRepeat(string name)
        {
            SqlParameter[] para = new SqlParameter[2];
            para[1] = new SqlParameter("@name", SqlDbType.VarChar, 50);
            para[1].Value = name; 
            para[0] = new SqlParameter("@count", SqlDbType.Int);
            para[0].Direction = ParameterDirection.Output;
            int repeat= SqlHelper.ExecuteReturnQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_IMMaterialNameRepeat", para);
            return repeat;
        }
        //判断物料名称是否重复
        public int Select_IMMaterialBasicRepeat(string name,string model)
        {
            SqlParameter[] para = new SqlParameter[3];
            para[1] = new SqlParameter("@name", SqlDbType.VarChar, 100);
            para[1].Value = name;
            para[0] = new SqlParameter("@count", SqlDbType.Int);
            para[0].Direction = ParameterDirection.Output;
            para[2] = new SqlParameter("@model", SqlDbType.VarChar, 100);
            para[2].Value = model;
            return  SqlHelper.ExecuteReturnQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_IMMaterialBasicNameRepeat", para);
             
        }
        //检索物料类型表
        public DataSet Select_MaterialTypeCondition(string condition)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Condition", SqlDbType.NVarChar,1000);
            para[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_IMMaterialType_Condition", para);
        }
        //检索基本单位
        public DataSet Select_Unit_Mat()
        {
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_Unit_Mat");
        }

    }

}