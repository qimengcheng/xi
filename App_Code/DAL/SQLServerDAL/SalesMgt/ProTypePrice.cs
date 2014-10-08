using System;
using System.Data;
using System.Data.SqlClient;
//using System.Collections.Generic;
using EquipmentMangementAjax.DBUtility;
/// <summary>
///SalesDeliverD 的摘要说明
/// </summary>

    public class ProTypePrice
    {
        public ProTypePrice()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        //查询产品表
        public DataSet Select_PTPrice(string condition)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 1000);
            para[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_ProTypePrice", para);

        }
        //查询产品修改历史
        public DataSet Select_PTPriceH(Guid id)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@id", SqlDbType.UniqueIdentifier);
            para[0].Value = id;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_ProTypePriceH", para);

        }
        //修改产品类型
        public void Insert_change(Guid  id,string man,decimal num)
        {
            SqlParameter[] para = new SqlParameter[3];
            para[0] = new SqlParameter("@PT_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = id;
            para[1] = new SqlParameter("@man", SqlDbType.VarChar,20);
            para[1].Value = man;
            para[2] = new SqlParameter("@num", SqlDbType.Decimal,18);
            para[2].Value = num;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_ProTypePrice", para);
        }
        //查询业务员表
        public DataSet Select_SalesMan(string condition)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@condition", SqlDbType.NVarChar, 1000);
            para[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_SMSalesMan", para);

        }
        //查询业务员表是否重复
        public DataSet Select_SalesManSame(string name)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@name", SqlDbType.VarChar, 20);
            para[0].Value = name;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_SMSalesMan_Same", para);

        }
        //删除业务员
        public void Delete_SalesMan(Guid id)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@SMSM_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = id;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_SMSalesMan", para);
        }
        //删除业务员类别
        public void Delete_SalesManSort(Guid id)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@id", SqlDbType.UniqueIdentifier);
            para[0].Value = id;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_SMSalesManSort", para);
        }
        //新增业务员
        public void Insert_SalesMan(string id,Guid mid)
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@name", SqlDbType.VarChar,20);
            para[0].Value = id;
            para[1] = new SqlParameter("@mid", SqlDbType.UniqueIdentifier);
            para[1].Value = mid;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_SMSalseMan", para);
        }
        //新增业务员leibie
        public void Insert_SalesManSort(string name,string note)
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@name", SqlDbType.VarChar,40);
            para[0].Value = name;
            para[1] = new SqlParameter("@note", SqlDbType.VarChar, 400);
            para[1].Value = note;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_SMSalseManSort", para);
        }
        //修改业务员
        public int Update_SalesMan(Guid id,string name,Guid sid)
        {
            SqlParameter[] para = new SqlParameter[4];
            para[0] = new SqlParameter("@count", SqlDbType.Int);
            para[0].Direction = ParameterDirection.Output;
            para[1] = new SqlParameter("@SMSM_ID", SqlDbType.UniqueIdentifier);
            para[1].Value = id;
            para[2] = new SqlParameter("@name", SqlDbType.VarChar, 20);
            para[2].Value = name;
            para[3] = new SqlParameter("@mid", SqlDbType.UniqueIdentifier);
            para[3].Value = sid;
            return (int)SqlHelper.ExecuteReturnQuery(SqlHelper.ConnectionStringLocalTransaction,
             CommandType.StoredProcedure, "Proc_U_SMSalesMan", para);
            
        }
        //修改业务员类别
        public int Update_SalesManSort(Guid id, string name,string note)
        {
            SqlParameter[] para = new SqlParameter[4];
            para[0] = new SqlParameter("@count", SqlDbType.Int);
            para[0].Direction = ParameterDirection.Output;
            para[1] = new SqlParameter("@id", SqlDbType.UniqueIdentifier);
            para[1].Value = id;
            para[2] = new SqlParameter("@name", SqlDbType.VarChar, 40);
            para[2].Value = name;
            para[3] = new SqlParameter("@note", SqlDbType.VarChar, 400);
            para[3].Value = note;
            return (int)SqlHelper.ExecuteReturnQuery(SqlHelper.ConnectionStringLocalTransaction,
             CommandType.StoredProcedure, "Proc_U_SMSalesManSort", para);

        }
        //查询业务员类别
        public DataSet Select_SalesManSort(string condition)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@condition", SqlDbType.NVarChar, 1000);
            para[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_SMSalesManSort", para);

        }
        //查询相同的价格账期
        public DataSet Select_SameCustomPTPrice(Guid id,Guid id2)
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@id", SqlDbType.UniqueIdentifier);
            para[0].Value = id;
            para[1] = new SqlParameter("@id1", SqlDbType.UniqueIdentifier);
            para[1].Value = id2;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_SMSameCustomPTPrice", para);

        }
        //查询产品系列
        public DataSet Select_PS()
        {
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_PS");
        }
        //更新订单详细的发货状态为发货完成
        public void Update_Order_ADel(Guid id, string man)
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@id", SqlDbType.UniqueIdentifier);
            para[0].Value = id;
            para[1] = new SqlParameter("@man", SqlDbType.VarChar, 20);
            para[1].Value = man;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_SMSalesOrderDetail_Over", para);

        }
        //建立认证随工单
        public void I_WorkOrder_NEW(WorkOrderInfo workOrderInfo, string code, string typecode, Guid PT_ID, string WO_PrintWord, string WO_QiaoKe, string WO_YingJiao, int WO_FirstDay, string WO_PT_Code, string WO_PT_ChipType, string sn, int oem, Guid InID)//新增随工单
        {
            SqlParameter[] para = new SqlParameter[19];
            para[0] = new SqlParameter("@code", SqlDbType.Char, 1);
            para[0].Value = code;
            para[1] = new SqlParameter("@WO_Type", SqlDbType.VarChar, 20);
            para[1].Value = workOrderInfo.WO_Type;
            para[2] = new SqlParameter("@WO_ProType", SqlDbType.VarChar, 60);
            para[2].Value = workOrderInfo.WO_ProType;
            para[3] = new SqlParameter("@WO_PNum", SqlDbType.Int);
            para[3].Value = workOrderInfo.WO_PNum;
            para[4] = new SqlParameter("@WO_Note", SqlDbType.VarChar, 200);
            para[4].Value = workOrderInfo.WO_Note;
            para[5] = new SqlParameter("@WO_People", SqlDbType.VarChar, 20);
            para[5].Value = workOrderInfo.WO_People;
            para[6] = new SqlParameter("@WO_OrderNum", SqlDbType.VarChar, 30);
            para[6].Value = workOrderInfo.WO_OrderNum;
            para[7] = new SqlParameter("@SMSO_ID", SqlDbType.UniqueIdentifier);
            para[7].Value = workOrderInfo.SMSO_ID;
            para[8] = new SqlParameter("@typecode", SqlDbType.VarChar, 4);
            para[8].Value = typecode;
            para[9] = new SqlParameter("@PT_ID", SqlDbType.UniqueIdentifier);
            para[9].Value = PT_ID;
            para[10] = new SqlParameter("@WO_PrintWord", SqlDbType.VarChar, 2);
            para[10].Value = WO_PrintWord;
            para[11] = new SqlParameter("@WO_QiaoKe", SqlDbType.Char, 1);
            para[11].Value = WO_QiaoKe;
            para[12] = new SqlParameter("@WO_YingJiao", SqlDbType.Char, 2);
            para[12].Value = WO_YingJiao;
            para[13] = new SqlParameter("@WO_FirstDay", SqlDbType.Int);
            para[13].Value = WO_FirstDay;
            para[14] = new SqlParameter("@WO_PT_Code", SqlDbType.VarChar, 2000);
            para[14].Value = WO_PT_Code;
            para[15] = new SqlParameter("@WO_PT_ChipType", SqlDbType.VarChar, 6);
            para[15].Value = WO_PT_ChipType;
            para[16] = new SqlParameter("@WO_SN", SqlDbType.VarChar, 30);
            para[16].Value = sn;
            para[17] = new SqlParameter("@OEM", SqlDbType.Int);
            para[17].Value = oem;
            para[18] = new SqlParameter("@InStoreDetailID", SqlDbType.UniqueIdentifier);
            para[18].Value = InID;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_WorkOrder_NEW_IQC", para);
        }
        //模糊查询销售订单单价和数量是否已经填写完毕主表
        public DataSet Select_SalesOrderPrice(Guid id)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@id", SqlDbType.UniqueIdentifier);
            para[0].Value = id;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_SMOrderPrice", para);
        }
        //去除
        public void Update_PMPurchasingApply_Qu(Guid id, string man)
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@id", SqlDbType.UniqueIdentifier);
            para[0].Value = id;
            para[1] = new SqlParameter("@man", SqlDbType.VarChar, 20);
            para[1].Value = man;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_PMPurchaseApplyDetail_Chou", para);

        }
        //查询产品表
        public DataSet Select_CRMSort()
        {

            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_CRMSort");

        }
    }

