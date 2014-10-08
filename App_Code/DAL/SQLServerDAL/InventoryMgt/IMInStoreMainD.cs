using System;
using System.Data;
using System.Data.SqlClient;
//using System.Collections.Generic;
using EquipmentMangementAjax.DBUtility;
/// <summary>
///IMInStoreMainD 的摘要说明
/// </summary>
// namespace EquipmentMangementAjax.SQLServer
//{
     public class IMInStoreMainD
     {
         public IMInStoreMainD()
         {
             //
             //TODO: 在此处添加构造函数逻辑
             //
         }
         //查询入库单主表
         public DataSet Select_InStoreMain(string condition )
         {
             SqlParameter[] para = new SqlParameter[1];
             para[0] = new SqlParameter("@Condition", SqlDbType.NVarChar,1000);
             para[0].Value =condition ;
             return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_IMInStoreMain", para);
         }
         //查询入库单详细表
         public DataSet Select_InStoreDelete(string condition)
         {
             SqlParameter[] para = new SqlParameter[1];
             para[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 1000);
             para[0].Value = condition;
             return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_IMInStoreDetail", para);
         }
         //修改入库单主表
         public void Update_InStoreMain(Guid ID, string Company, string ResponseMan)
         {
             SqlParameter[] para = new SqlParameter[3];
             para[0] = new SqlParameter("@IMISM_ID", SqlDbType.UniqueIdentifier);
             para[0].Value = ID;
             para[1] = new SqlParameter("@IMISM_InStoreCompany", SqlDbType.VarChar, 100);
             para[1].Value = Company;
             para[2] = new SqlParameter("@IMISM_ResponMan", SqlDbType.VarChar, 20);
             para[2].Value = ResponseMan;
             SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_IMInStoreMain", para);
         }
         //删除入库单主表
         public void Delete_InStoreMain(Guid ID)
         {
             SqlParameter[] para = new SqlParameter[1];
             para[0] = new SqlParameter("@IMISM_ID", SqlDbType.UniqueIdentifier);
             para[0].Value = ID;
             SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_IMInStoreMain", para);
         }
         //新增入库单主表
         public void Insert_IMInStoreMain(Guid sortID,Guid StoreID ,string company,string man ,string responman)
         {
             SqlParameter[] para = new SqlParameter[5];
             para[0] = new SqlParameter("@IMSSBD_ID", SqlDbType.UniqueIdentifier);
             para[0].Value = sortID;
             para[1] = new SqlParameter("@IMS_StoreID", SqlDbType.UniqueIdentifier);
             para[1].Value = StoreID;
             para[2] = new SqlParameter("@IMISM_InStoreCompany", SqlDbType.VarChar,100);
             para[2].Value = company;
             para[3] = new SqlParameter("@IMISM_MakeMan", SqlDbType.VarChar,100);
             para[3].Value = man;
             para[4] = new SqlParameter("@IMISM_ResponMan", SqlDbType.VarChar,100);
             para[4].Value = responman;
             SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_IMInStoreMain", para);
         }
         //入库类别下拉框
         public DataSet Select_IMInStoreSort(string condition)
         {
             SqlParameter[] para = new SqlParameter[1];
             para[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 1000);
             para[0].Value = condition;
             return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_IMStorgeSortBasicData_Dropdownlist",para);
         }
         //入库库房下拉单
         public DataSet Select_Store(string depart,string man)
         {
             SqlParameter[] para = new SqlParameter[2];
             para[0] = new SqlParameter("@IMS_ResponDepart", SqlDbType.VarChar, 100);
             para[0].Value = depart;
             para[1] = new SqlParameter("@IMS_ResponMan", SqlDbType.VarChar, 100);
             para[1].Value = man;
             return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_IMStore_Dropdownlist", para);
         }
         //库房区域下拉框
         public DataSet Select_Area(Guid StoreID)
         {
             SqlParameter[] para = new SqlParameter[1];
             para[0] = new SqlParameter("@IMS_StoreID", SqlDbType.UniqueIdentifier);
             para[0].Value = StoreID;
             return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_IMKuArea", para);
         }
         //入库详细表编辑
         public void Update_InStoreDetail(Guid MainID,string BatchName,string level,decimal shouldarr,decimal actualarr,decimal perweight,decimal totalweight ,Guid area)         
         {
             SqlParameter[] para = new SqlParameter[8];
             para[0] = new SqlParameter("@IMISD_ID", SqlDbType.UniqueIdentifier);
             para[0].Value = MainID;
             para[1] = new SqlParameter("@IMISD_BatchNum", SqlDbType.VarChar,100);
             para[1].Value = BatchName;
             para[2] = new SqlParameter("@IMIDS_Level", SqlDbType.VarChar, 100);
             para[2].Value = level;
             para[3] = new SqlParameter("@IMISD_ShouldArrNum", SqlDbType.Decimal,18);
             para[3].Value = shouldarr;
             para[4] = new SqlParameter("@IMIDS_ActualArrNum", SqlDbType.Decimal,18);
             para[4].Value = actualarr;
             para[5] = new SqlParameter("@IMIDS_PerWeight", SqlDbType.Decimal,18);
             para[5].Value = perweight;
             para[6] = new SqlParameter("@IMIDS_TotalWeight", SqlDbType.Decimal, 18);
             para[6].Value = totalweight;
             para[7] = new SqlParameter("@IMSA_AreaID", SqlDbType.UniqueIdentifier);
             para[7].Value = area;
             SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_IMInStoreDetail", para);
         }
         //新建入库详细表
         public void Insert_InStoreDetail(Guid MainID, int sort, Guid ID, string BatchName, string level, decimal shouldarr, decimal actualarr, decimal perweight, decimal totalweight, Guid area)
         {
             SqlParameter[] para = new SqlParameter[10];
             para[0] = new SqlParameter("@IMISM_ID", SqlDbType.UniqueIdentifier);
             para[0].Value = MainID;
             para[1] = new SqlParameter("@Sort", SqlDbType.Bit);
             para[1].Value = sort;
             para[2] = new SqlParameter("@ID", SqlDbType.UniqueIdentifier);
             para[2].Value = ID;
             para[4] = new SqlParameter("@IMIDS_Level", SqlDbType.VarChar, 100);
             para[4].Value = level;
             para[3] = new SqlParameter("@IMISD_BatchNum", SqlDbType.VarChar, 100);
             para[3].Value = BatchName;         
             para[5] = new SqlParameter("@IMISD_ShouldArrNum", SqlDbType.Decimal, 18);
             para[5].Value = shouldarr;
             para[6] = new SqlParameter("@IMIDS_ActualArrNum", SqlDbType.Decimal, 18);
             para[6].Value = actualarr;
             para[7] = new SqlParameter("@IMIDS_PerWeight", SqlDbType.Decimal, 18);
             para[7].Value = perweight;
             para[8] = new SqlParameter("@IMIDS_TotalWeight", SqlDbType.Decimal, 18);
             para[8].Value = totalweight;
             para[9] = new SqlParameter("@IMSA_AreaID", SqlDbType.UniqueIdentifier);
             para[9].Value = area;
             SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_IMInStoreDetail", para);
         }
        //检索物料
         public DataSet Select_InStoreDetail_MaterialBasic(string condition)
         {
             SqlParameter[] para = new SqlParameter[1];
             para[0] = new SqlParameter("@Condition", SqlDbType.NVarChar,1000);
             para[0].Value = condition;
             return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_IMInStoreDetail_MaterialBasic", para);
         }
         //检索产品
         public DataSet Select_InStoreDetail(string condition)
         {
             SqlParameter[] para = new SqlParameter[1];
             para[0] = new SqlParameter("@Condition", SqlDbType.NVarChar,1000);
             para[0].Value = condition;
             return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_IMInStoreDetail_PT", para);
         }
         //物料类型下拉框
         public DataSet Select_MatType( )
         {
           
             return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_IMMaterialType");
         }
         //采购入库的时候提交，对库存表进行操作，同时检查更新入库单的状态
         public void Update_IMInStore_InventoryMain_Detail(Guid ID)
         {   
            SqlParameter[] para = new SqlParameter[1];       
            para[0] = new SqlParameter("@IMISD_ID", SqlDbType.UniqueIdentifier );
            para[0].Value = ID;
            int repeat = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_IMInStore_InventoryMain_Detail", para);
         }
         //采购订单检索
         public DataSet Select_Purchase(string condition)
         {
             SqlParameter[] para = new SqlParameter[1];
             para[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 1000);
             para[0].Value = condition;
             return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_IMInStoreDetail_PurchaseOrderDetail",para);
         }
         //插入采购订单
         public void Insert_IMInStoreDetail_Purchase(Guid PD_ID,Guid ISM_ID)
         {
             SqlParameter[] para = new SqlParameter[2];
             para[0] = new SqlParameter("@PMPOD_PurchaseDetailID", SqlDbType.UniqueIdentifier);
             para[0].Value = PD_ID;
             para[1] = new SqlParameter("@IMISM_ID", SqlDbType.UniqueIdentifier);
             para[1].Value = ISM_ID;
             SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_IMInStoreDetail_caigou", para);
         }
         //退货单检索
         public DataSet Select_Return(string condition)
         {
             SqlParameter[] para = new SqlParameter[1];
             para[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 1000);
             para[0].Value = condition;
             return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_IMInStoreDetail_SMReturnChange", para);
         }
         //插入退货单
         public void Insert_IMInStoreDetail_Return(Guid PD_ID, Guid ISM_ID)
         {
             SqlParameter[] para = new SqlParameter[2];
             para[0] = new SqlParameter("@SMRC_ID", SqlDbType.UniqueIdentifier);
             para[0].Value = PD_ID;
             para[1] = new SqlParameter("@IMISM_ID", SqlDbType.UniqueIdentifier);
             para[1].Value = ISM_ID;
             SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_IMInStoreDetail_tuihuo", para);
         }
         //随工单单检索
         public DataSet Select_Suigongdan(string condition)
         {
             SqlParameter[] para = new SqlParameter[1];
             para[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 1000);
             para[0].Value = condition;
             return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_IMInStoreDetail_suigongdan", para);
         }
         //插入随工单
         public void Insert_IMInStoreDetail_Suigongdan(Guid PD_ID, Guid ISM_ID)
         {
             SqlParameter[] para = new SqlParameter[2];
             para[0] = new SqlParameter("@WO_ID", SqlDbType.UniqueIdentifier);
             para[0].Value = PD_ID;
             para[1] = new SqlParameter("@IMISM_ID", SqlDbType.UniqueIdentifier);
             para[1].Value = ISM_ID;
             SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_IMInStoreDetail_suigongdan", para);
         }
         //删除入库单详细表-退货入库
         public void Delete_IMInStoreDetail_Return(Guid ISD_ID)
         {
             SqlParameter[] para = new SqlParameter[1];
             para[0] = new SqlParameter("@IMISD_ID", SqlDbType.UniqueIdentifier);
             para[0].Value = ISD_ID;
             SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_IMInstoreDetail_tuihuo", para);
         }
         //直接删除入库单详细表
         public void Delete_IMInStoreDetail(Guid ISD_ID)
         {
             SqlParameter[] para = new SqlParameter[1];
             para[0] = new SqlParameter("@IMISD_ID", SqlDbType.UniqueIdentifier);
             para[0].Value = ISD_ID;
             SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_IMInstoreDetail", para);
         }
         //提交入库详细表的时候对采购订单进行回写
         public int Update_IMInstroeDetail_PMPurchaseOrderDetail_ActualNum(Guid imism_ID)
         {
             SqlParameter[] para = new SqlParameter[2];
             para[1] = new SqlParameter("@IMISM_ID", SqlDbType.UniqueIdentifier);
             para[1].Value = imism_ID;
             para[0] = new SqlParameter("@count", SqlDbType.Int);
             para[0].Direction =ParameterDirection.Output; ;
          return     SqlHelper.ExecuteReturnQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_IMInstoreDetail_PMPurchaseOrderDetail", para);
         }
         //入库单状态变为提交
         public void Update_IMInstroeDetail_State_Detail(Guid IMISM_ID)
         {
             SqlParameter[] para = new SqlParameter[1];
             para[0] = new SqlParameter("@IMISM_ID", SqlDbType.UniqueIdentifier);
             para[0].Value = IMISM_ID;
             SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_IMInStoreDetail_Tijiao", para);
         }
         //提交入库单的时候提交每个入库详细数据，对每个数据进行变更
         public void Update_IMInstroeDetail_PMPurchaseOrderDetail_ChangeNum(Guid imisd_ID)
         {
             SqlParameter[] para = new SqlParameter[1];
             para[0] = new SqlParameter("@IMISD_ID", SqlDbType.UniqueIdentifier);
             para[0].Value = imisd_ID;
             SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_IMInStore_InventoryMain_Detail_ChangeNum", para);
         }
         //成品入库的时候更新随工单的状态
         public void Update_IMInstroeMain_WorkOrder(Guid imism_ID)
         {
             SqlParameter[] para = new SqlParameter[1];
             para[0] = new SqlParameter("@IMISM_ID", SqlDbType.UniqueIdentifier);
             para[0].Value = imism_ID;
             SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_IMInStoreMain_WOState", para);
         }
         //冲账入库的时候，提交入库单的时候提交每个入库详细数据，对每个数据进行变更
         public void Update_IMInstroeDetail_PMPurchaseOrderDetail_ChangeNum_Two(Guid imisd_ID)
         {
             SqlParameter[] para = new SqlParameter[1];
             para[0] = new SqlParameter("@IMISD_ID", SqlDbType.UniqueIdentifier);
             para[0].Value = imisd_ID;
             SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_IMInStore_InventoryMain_Detail_ChangeNum_Two", para);
         }
         //抽检
         public void Update_Choujian(Guid id,decimal num)
         {
             SqlParameter[] para = new SqlParameter[2];
             para[0] = new SqlParameter("@id", SqlDbType.UniqueIdentifier);
             para[0].Value = id;
             para[1] = new SqlParameter("@num", SqlDbType.Decimal);
             para[1].Value = num;
             SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_IMISD_Chou", para);
         }
     }
//}