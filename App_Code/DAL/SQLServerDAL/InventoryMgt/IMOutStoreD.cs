using System;
using System.Data;
using System.Data.SqlClient;
using EquipmentMangementAjax.DBUtility;
/// <summary>
///IMOutStoreD 的摘要说明
/// </summary>

    public class IMOutStoreD
    {
        public IMOutStoreD()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        //查询领料单主表
        public DataSet Select_lingliaoMain(string condition)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 1000);
            para[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_IMRequisitionMain", para);
        }
        //删除领料单主表
        public void Delete_lingliaoMain(Guid ID)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@IMRM_RequisitionID", SqlDbType.UniqueIdentifier);
            para[0].Value = ID;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_IMRequisitionMain", para);
        }
        //查询物料
        public DataSet Select_IMIM_Mat(string condition)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 1000);
            para[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_IMInventoryMain_Mat", para);
        }
        //查询产品
        public DataSet Select_IMIM_PT(string condition)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 1000);
            para[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_IMInventoryMain_PT", para);
        }
        //插入领料单库存主表ID
        public void Insert_LingliaoDetail(Guid ID,Guid IMIM_ID)
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@IMRM_RequisitionID", SqlDbType.UniqueIdentifier);
            para[0].Value = ID;
            para[1] = new SqlParameter("@IMIM_ID", SqlDbType.UniqueIdentifier);
            para[1].Value = IMIM_ID;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_IMRequisitionDetail", para);
        }
        //检索领料单详细表
        public DataSet Select_IMRequisitionDetail(string condition)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 1000);
            para[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_IMRequisitionDetail", para);
        }
        //清空对应人的过渡表-用于汇总
        public void Delete_IMRD_SUM(string man)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Man", SqlDbType.VarChar, 20);
            para[0].Value = man;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Delete_IMRD_SUM", para);
        }
        //向过渡表插入数据
        public void Insert_IMRD_SUM(Guid ID,string man)
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@IMRM_RequisitionID", SqlDbType.UniqueIdentifier);
            para[0].Value = ID;
            para[1] = new SqlParameter("@Man", SqlDbType.VarChar,20);
            para[1].Value = man;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Insert_IMRD_SUM", para);
        }
        //查询汇总信息
        public DataSet Select_IMRD_SUM(string man)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Man", SqlDbType.VarChar,20);
            para[0].Value = man;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_IMRD_SUM", para);
        }
       
        //库存详细查询
        public DataSet Select_IMInventoryDetail(string condition)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 1000);
            para[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_IMInventoryDetail", para);
        }
        //库存主表混合查询
        public DataSet Select_IMInventoryMain(string condition)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 1000);
            para[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_IMInventoryMain", para);
        }
        //新建领料单
        public void Insert_LingliaoMain(string man,Guid StoreID,string  Depart)
        {
            SqlParameter[] para = new SqlParameter[3];
            para[0] = new SqlParameter("@IMRM_Man", SqlDbType.VarChar, 20);
            para[0].Value = man;
            para[1] = new SqlParameter("@IMS_StoreID", SqlDbType.UniqueIdentifier);
            para[1].Value = StoreID;
            para[2] = new SqlParameter("@IMRM_Depart", SqlDbType.VarChar,100);
            para[2].Value = Depart;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_LingliaoMain", para);
        }
        //库房下拉表
        public DataSet Select_IMStore()
        {
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_IMStore");
        }
        //审核领料单
        public void Update_LingliaoMain_Check(Guid RID,string Resutl,string opinion)
        {
            SqlParameter[] para = new SqlParameter[3];
            para[0] = new SqlParameter("@IMRM_RequisitionID", SqlDbType.UniqueIdentifier);
            para[0].Value = RID;
            para[1] = new SqlParameter("@IMRM_DepartMangCheckResult", SqlDbType.VarChar, 20);
            para[1].Value = Resutl;
            para[2] = new SqlParameter("@IMRM_DepartMangCheckOpinion", SqlDbType.VarChar, 200);
            para[2].Value = opinion;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_IMLingliaodanM", para);
        }
        //提交领料单详细
        public void Update_LingliaoDetail(Guid ID)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@IMRM_RequisitionID", SqlDbType.UniqueIdentifier);
            para[0].Value = ID;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_IMRequisitionDetail", para);
        }
        //查看审核结果
        public DataSet Select_IMRequisitionMain_CheckResult(Guid ID)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@IMRM_RequisitionID", SqlDbType.UniqueIdentifier);
            para[0].Value = ID;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_IMRequisitionMain_CheckResult", para);
        }
        //出库单主表检索
        public DataSet Select_IMOutM(string condition)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 1000);
            para[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_IMOutHouseMain", para);
        }
        //出库单详细查询
        public DataSet Select_IMOuthouseDetail(string condition)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 1000);
            para[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_IMOutHouseDetail", para);
        }
        //出库类别下拉框
        public DataSet Select_IMOuthouseSort(string condition )
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 1000);
            para[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_IMStorgeSortBasicData_Dropdownlist_Out",para);
        }
        //生成出库单主表
        public void Insert_OutM(Guid sortID,Guid StoreID,string man ,string company)
        {
            SqlParameter[] para = new SqlParameter[4];
            para[0] = new SqlParameter("@IMSSBD_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = sortID;
            para[1] = new SqlParameter("@IMS_StoreID", SqlDbType.UniqueIdentifier);
            para[1].Value = StoreID;
            para[2] = new SqlParameter("@IMOHM_MakeMan", SqlDbType.VarChar,20);
            para[2].Value = man;
            para[3] = new SqlParameter("@IMOHM_OutHouseCompany", SqlDbType.VarChar,50);
            para[3].Value = company;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_IMOutHouseMain", para);
        }
        //出库库房下拉单
        public DataSet Select_Store(string depart, string man)
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@IMS_ResponDepart", SqlDbType.VarChar, 100);
            para[0].Value = depart;
            para[1] = new SqlParameter("@IMS_ResponMan", SqlDbType.VarChar, 100);
            para[1].Value = man;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_IMStore_Dropdownlist", para);
        }
        //删除出库单主表
        public void Delete_OutM(Guid id)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@IMOHM_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = id;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_IMOutHouseMain", para);
        }
        //删除出库单详细表
        public void Delete_OutD(Guid id)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@IMOHD_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = id;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_IMOutHouseDetail", para);
        }
        //将库存ID插入到出库单
        public void Insert_IMOutD_Yiban(Guid IMID_ID,Guid IMOHM_ID,Decimal IMOHD_Num)
        {
            SqlParameter[] para = new SqlParameter[3];
            para[0] = new SqlParameter("@IMID_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = IMID_ID;
            para[1] = new SqlParameter("@IMOHM_ID", SqlDbType.UniqueIdentifier);
            para[1].Value = IMOHM_ID;
            para[2] = new SqlParameter("@IMOHD_Num", SqlDbType.Decimal,18);
            para[2].Value = IMOHD_Num;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_IMOutHouseDetail", para);
        }
        //将库存ID，领料单ID插入到出库单
        public void Insert_IMOutD_Lingliao(Guid IMID_ID, Guid IMOHM_ID, Decimal IMOHD_Num,string man)
        {
            SqlParameter[] para = new SqlParameter[4];
            para[0] = new SqlParameter("@IMID_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = IMID_ID;
            para[1] = new SqlParameter("@IMOHM_ID", SqlDbType.UniqueIdentifier);
            para[1].Value = IMOHM_ID;
            para[3] = new SqlParameter("@man", SqlDbType.VarChar,20);
            para[3].Value = man;
            para[2] = new SqlParameter("@IMOHD_Num", SqlDbType.Decimal, 18);
            para[2].Value = IMOHD_Num;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_IMOutHouseDetail_Lingliao", para);
        }
        //改变出库单主表的状态为待确认
        public void Update_IMOutM(Guid id)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@IMOHM_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = id;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_IMOutHouseMain", para);
        }
        //输入用户名密码，确认出库
        public void Update_IMOutM_IMIM(Guid id,string man)
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@IMOHM_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = id;
            para[1] = new SqlParameter("@IMOHM_TakeAwayMan", SqlDbType.VarChar,20);
            para[1].Value = man;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_IMOutHouseMain_querenchuku", para);
        }
        //删除领料单详细
        public void Delete_LingliaoD(Guid id)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@IMRD_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = id;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_LingliaoD", para);
        }
        //编辑领料单详细
        public void Update_LingliaoD(Guid id,decimal num,string remark)
        {
            SqlParameter[] para = new SqlParameter[3];
            para[0] = new SqlParameter("@IMRD_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = id;
            para[1] = new SqlParameter("@IMRD_ActualOutNum", SqlDbType.Decimal,18);
            para[1].Value = num;
            para[2] = new SqlParameter("@IMRD_Remark", SqlDbType.VarChar,400);
            para[2].Value = remark;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_LingliaoD", para);
        }
        //插入盘点表
        public void Insert_Pandian(Guid IMIM_ID,string man)
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@IMIM_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = IMIM_ID;
            para[1] = new SqlParameter("@IMC_CountMan", SqlDbType.VarChar,20);
            para[1].Value = man;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_IMCount", para);
        }
        //更新盘点表
        public void Update_Pandian(Guid IMC_ID, decimal IMC_ActualTotalNum)
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@IMC_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = IMC_ID;
            para[1] = new SqlParameter("@IMC_ActualTotalNum", SqlDbType.Decimal, 18);
            para[1].Value = IMC_ActualTotalNum;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_IMCount", para);
        }
        //查询盘点表
        public DataSet Select_Pandian(string condition)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Condition", SqlDbType.NVarChar,1000);
            para[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_IMCount", para);
        }
        //删除盘点表
       public void Delete_Pandian(Guid IMC_ID)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@IMC_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = IMC_ID;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_IMCount", para);
        }
          //生成销售出库的主表
        public void Insert_SalesOut_Main(Guid ID, string man,string company,string model,string modelnum)
        {
            SqlParameter[] para = new SqlParameter[5];
            para[0] = new SqlParameter("@IMS_StoreID", SqlDbType.UniqueIdentifier);
            para[0].Value = ID;
            para[1] = new SqlParameter("@man", SqlDbType.VarChar, 20);
            para[1].Value = man;
            para[2] = new SqlParameter("@IMOHM_OutHouseCompany", SqlDbType.VarChar, 100);
            para[2].Value = company;
            para[3] = new SqlParameter("@SMOD_TransModel", SqlDbType.VarChar, 100);
            para[3].Value = model;
            para[3] = new SqlParameter("@SMOD_TransNum", SqlDbType.VarChar, 20);
            para[3].Value = modelnum;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_IMXiaoshouchuku_main", para);
        }
        //清空销售出库的主表而生的临时表
        public void Delete_SalesOut_Temp( string man)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@man", SqlDbType.VarChar, 20);
            para[0].Value = man;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_IMXiaoshouchuku_main", para);
        }
        //销售出库，插入发货表
        public void Insert_SalesOut_Deliver(Guid id, string man)
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@SMSOD_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = id;
            para[1] = new SqlParameter("@man", SqlDbType.VarChar, 20);
            para[1].Value = man;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_IMOutHouseDetail_Xiaoshao", para);
        }
        //查询销售出库的详细库存表
        public DataSet Select_Xiashoukucun(string condition)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 1000);
            para[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_IMInventoryMain_Xiaoshou", para);
        }
        //将库存ID插入到出库单
        public void Insert_IMOutD_Xiaoshou(Guid IMID_ID, string man, Decimal IMOHD_Num,Guid PID,Guid Mid)
        {
            SqlParameter[] para = new SqlParameter[5];
            para[0] = new SqlParameter("@IMID_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = IMID_ID;
            para[1] = new SqlParameter("@man", SqlDbType.VarChar,20);
            para[1].Value = man;
            para[2] = new SqlParameter("@IMOHD_Num", SqlDbType.Decimal, 18);
            para[2].Value = IMOHD_Num;
            para[3] = new SqlParameter("@SMSOD_ID", SqlDbType.UniqueIdentifier);
            para[3].Value = PID;
            para[4] = new SqlParameter("@IMOHM_ID", SqlDbType.UniqueIdentifier);
            para[4].Value = Mid;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_IMOutHouseDetail_Xiaoshou", para);
        }
        //销售出库的提交详细库存表
        public void Update_IMOutHouseMain_Xiaoshou(string man)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@man", SqlDbType.VarChar, 20);
            para[0].Value = man;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_IMOutHouseMain_Xiaoshou", para);
        }
        //将选中的发货计划插入到中转表
        public void Insert_IMSalesOutTEMP(Guid id)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@SMDP_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = id;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_IM_SalesOutTemp", para);
        }
        //清空销售出库中转表
        public void Delete_IMSalesOutTEMP()
        {
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_IM_SalesOutTemp");
        }
        //销售出库的确认出库的时候插入发货单
        public void Insert_SMOrderDeliver_SalesOut(Guid id)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@IMOHM_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = id;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_SMOrderDeliver_SalesOut", para);
        }
        //销售出库的确认出库的时候插入发货单后更新物流方式
        public void Update_SMOrderDeliver_SalesOut(Guid id,string model,string num)
        {
            SqlParameter[] para = new SqlParameter[3];
            para[0] = new SqlParameter("@IMOHM_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = id;
            para[1] = new SqlParameter("@SMOD_TransModel", SqlDbType.VarChar,100);
            para[1].Value = model;
            para[2] = new SqlParameter("@SMOD_TransNum", SqlDbType.VarChar, 100);
            para[2].Value = num;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_SMOrderDeliver_SalesOut", para);
        }
        //查询有无相同批号的物料插入到同一个出库单中
        public DataSet Select_SameBatchNum(Guid IMID_ID,Guid OutMID)
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@IMID_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = IMID_ID;
            para[1] = new SqlParameter("@IMOHM_ID", SqlDbType.UniqueIdentifier);
            para[1].Value = OutMID;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_IMOuthouse_SameBatchNum", para);
        }
    }
