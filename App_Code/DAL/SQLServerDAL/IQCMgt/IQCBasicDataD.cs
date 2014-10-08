using System;
using System.Collections.Generic;
using EquipmentMangementAjax.DBUtility;
using System.Data.SqlClient;
using System.Data;

/// <summary>
///IQCBasicDataD 的摘要说明
/// </summary>

    public class IQCBasicDataD 
    {
        public IQCBasicDataD()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        //模糊查询物料基础信息用于维护进料检验
        public DataSet Search_IMMaterialBasicData_IQC(string Condition)
        {
            SqlParameter para = new SqlParameter("@Condition", Condition);

            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
              CommandType.StoredProcedure, "Proc_S_IMMaterialBasicData_IQC", para);
        }

        //新增物料到进料检验
        public int Insert_IMMaterialBasicData_IQC(Guid IMMBD_MaterialID)
        {
            SqlParameter para = new SqlParameter("@IMMBD_MaterialID", IMMBD_MaterialID);

            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
              CommandType.StoredProcedure, "Proc_I_IMMaterialBasicData_IQC", para);
        }

        //从进料检验删除物料
        public int Delete_IMMaterialBasicData_IQC(Guid IMMBD_MaterialID)
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@IMMBD_MaterialID", SqlDbType.UniqueIdentifier);
            parm[0].Value = IMMBD_MaterialID;
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
              CommandType.StoredProcedure, "Proc_D_IMMaterialBasicData_IQC", parm);
        }

        //查询进料检验物料的检验项目Grid
        public DataSet Search_IQCItemsTable(Guid IMMBD_MaterialID)
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@IMMBD_MaterialID", SqlDbType.UniqueIdentifier);
            parm[0].Value = IMMBD_MaterialID;
            return (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_IQCItemsTable", parm);
        }

        //模糊查询进料检验物料的检验项目Grid
        public DataSet Search_IQCItemsTable_M(string Condition)
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@Condition", SqlDbType.NVarChar,1000);
            parm[0].Value = Condition;
            return (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_IQCItemsTable_M", parm);
        }

        //查询进料检验物料的检验项目（by 项目ID）用于编辑
        public IList<IQCBasicDataInfo> Search_IQCItemsTable_ID(Guid IQCIT_ID)
        {
            SqlParameter parm = new SqlParameter("@IQCIT_ID", IQCIT_ID);
            IList<IQCBasicDataInfo> IQC = new List<IQCBasicDataInfo>();
            SqlDataReader sdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_S_IQCItemsTable_ID", parm);
            while (sdr.Read())
            {
                IQC.Add(new IQCBasicDataInfo(
                   (Guid)sdr["IQCIT_ID"],
                   (Guid)sdr["IMMBD_MaterialID"],
                   sdr["IQCIT_Items"] == DBNull.Value ? "" : sdr["IQCIT_Items"].ToString(),
                   sdr["IQCIT_NeedValue"] == DBNull.Value ? "" : sdr["IQCIT_NeedValue"].ToString()));
            }
            return IQC;
        }

        //新增进料检验物料的检验项目
        public int Insert_IQCItemsTable(IQCBasicDataInfo A)
        {
            SqlParameter[] parm = new SqlParameter[3];
            parm[0] = new SqlParameter("@IMMBD_MaterialID", SqlDbType.UniqueIdentifier);
            parm[0].Value = A.IMMBD_MaterialID;

            parm[1] = new SqlParameter("@IQCIT_Items", SqlDbType.VarChar, 80);
            parm[1].Value = A.IQCIT_Items;

            parm[2] = new SqlParameter("@IQCIT_NeedValue", SqlDbType.Char, 2);
            parm[2].Value = A.IQCIT_NeedValue;

            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_I_IQCItemsTable", parm);
        }

        //修改进料检验物料的检验项目
        public int Update_IQCItemsTable(IQCBasicDataInfo A)
        {
            SqlParameter[] parm = new SqlParameter[4];
            parm[0] = new SqlParameter("@IQCIT_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = A.IQCIT_ID;

            parm[1] = new SqlParameter("@IMMBD_MaterialID", SqlDbType.UniqueIdentifier);
            parm[1].Value = A.IMMBD_MaterialID;

            parm[2] = new SqlParameter("@IQCIT_Items", SqlDbType.VarChar, 80);
            parm[2].Value = A.IQCIT_Items;

            parm[3] = new SqlParameter("@IQCIT_NeedValue", SqlDbType.Char, 2);
            parm[3].Value = A.IQCIT_NeedValue;

            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_U_IQCItemsTable", parm);
        }

        //删除进料检验的检验项目
        public int Delete_IQCItemsTable(Guid IQCIT_ID)
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@IQCIT_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = IQCIT_ID;
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
              CommandType.StoredProcedure, "Proc_D_IQCItemsTable", parm);
        }

        //查询进料检验的检验项目的检验标准
        public DataSet Search_IQCStandardTable(Guid IQCIT_ID)
        {
            SqlParameter parm = new SqlParameter("@IQCIT_ID", IQCIT_ID);
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "PROC_S_IQCStandardTable", parm);
        }

        //查询进料检验的检验项目的检验标准用于编辑（by ID）
        public IList<IQCBasicDataInfo> Search_IQCStandardTable_ID(Guid IQCST_ID)
        {
            SqlParameter parm = new SqlParameter("@IQCST_ID", IQCST_ID);
            IList<IQCBasicDataInfo> IQC = new List<IQCBasicDataInfo>();
            SqlDataReader sdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_S_IQCStandardTable_ID", parm);
            while (sdr.Read())
            {
                IQC.Add(new IQCBasicDataInfo(
                   (Guid)sdr["IQCST_ID"],
                   sdr["IQCIT_Standard"] == DBNull.Value ? "" : sdr["IQCIT_Standard"].ToString(),
                   (Guid)sdr["IQCIT_ID"],
                   sdr["IQCIT_Remarks"] == DBNull.Value ? "" : sdr["IQCIT_Remarks"].ToString()));
            }
            return IQC;
        }

        //模糊查询进料检验的检验项目的检验标准
        public DataSet Search_IQCStandardTable_M(Guid IQCIT_ID, string IQCIT_Standard, string IQCIT_Remarks)
        {
            SqlParameter[] parm = new SqlParameter[3];
            parm[0] = new SqlParameter("@IQCIT_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = IQCIT_ID;
            parm[1] = new SqlParameter("@IQCIT_Standard", SqlDbType.VarChar,400);
            parm[1].Value = IQCIT_Standard;
            parm[2] = new SqlParameter("@IQCIT_Remarks", SqlDbType.VarChar, 200);
            parm[2].Value = IQCIT_Remarks;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "PROC_S_IQCStandardTable_M", parm);
        }

        //新增进料检验物料的检验项目的检验标准
        public int Insert_IQCStandardTable(IQCBasicDataInfo BDI)
        {
            SqlParameter[] parm = new SqlParameter[3];
            parm[0] = new SqlParameter("@IQCIT_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = BDI.IQCIT_ID;

            parm[1] = new SqlParameter("@IQCIT_Standard", SqlDbType.VarChar, 400);
            parm[1].Value = BDI.IQCIT_Standard;

            parm[2] = new SqlParameter("@IQCIT_Remarks", SqlDbType.VarChar, 200);
            parm[2].Value = BDI.IQCIT_Remarks;

            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_I_IQCStandardTable", parm);
        }

        //修改进料检验物料的检验项目的检验标准
        public int Update_IQCStandardTable(IQCBasicDataInfo BDI)
        {
            SqlParameter[] parm = new SqlParameter[4];
            parm[0] = new SqlParameter("@IQCST_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = BDI.IQCST_ID;

            parm[1] = new SqlParameter("@IQCIT_ID", SqlDbType.UniqueIdentifier);
            parm[1].Value = BDI.IQCIT_ID;

            parm[2] = new SqlParameter("@IQCIT_Standard", SqlDbType.VarChar, 400);
            parm[2].Value = BDI.IQCIT_Standard;

            parm[3] = new SqlParameter("@IQCIT_Remarks", SqlDbType.VarChar, 200);
            parm[3].Value = BDI.IQCIT_Remarks;

            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_U_IQCStandardTable", parm);
        }

        //删除进料检验的检验项目
        public int Delete_IQCStandardTable(Guid IQCST_ID)
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@IQCST_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = IQCST_ID;
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
              CommandType.StoredProcedure, "Proc_D_IQCStandardTable", parm);
        }

        //模糊查询产品型号用于维护认证信息(认证)
        public DataSet Search_ProType_RZ(string PS_Name, string PT_Name )
        {
            SqlParameter[] parm = new SqlParameter[2];
            parm[0] = new SqlParameter("@PS_Name", SqlDbType.VarChar, 60);
            parm[0].Value = PS_Name;
            parm[1] = new SqlParameter("@PT_Name", SqlDbType.VarChar, 60);
            parm[1].Value = PT_Name;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_ProType_RZ", parm);
        }

        //模糊查询产品型号用于维护认证信息(其他)
        public DataSet Search_ProType_QT(string PS_Name, string PT_Name)
        {
            SqlParameter[] parm = new SqlParameter[2];
            parm[0] = new SqlParameter("@PS_Name", SqlDbType.VarChar, 60);
            parm[0].Value = PS_Name;
            parm[1] = new SqlParameter("@PT_Name", SqlDbType.VarChar, 60);
            parm[1].Value = PT_Name;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_ProType_QT", parm);
        }

        //增加产品认证型号
        public int Insert_ProType_RZ(Guid PT_ID)
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@PT_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = PT_ID;
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
              CommandType.StoredProcedure, "Proc_I_ProType_RZ", parm);
        }

        //删除产品认证型号
        public int Delete_ProType_RZ(Guid PT_ID)
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@PT_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = PT_ID;
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
              CommandType.StoredProcedure, "Proc_D_ProType_RZ", parm);
        }

        //认证工序查看
        public DataSet Search_PRDetail_RZ(Guid PT_ID)
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@PT_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = PT_ID;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Prco_S_PRDetail_RZ", parm);
        }

        //ID查询产品型号用于界面显示
        public IList<IQCBasicDataInfo> Search_ProType_ID(Guid PT_ID)
        {
            SqlParameter parm = new SqlParameter("@PT_ID", PT_ID);
            IList<IQCBasicDataInfo> IQC = new List<IQCBasicDataInfo>();
            SqlDataReader sdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_S_ProType_ID", parm);
            while (sdr.Read())
            {
                IQC.Add(new IQCBasicDataInfo(sdr["PT_Name"] == DBNull.Value ? "" : sdr["PT_Name"].ToString()));
            }
            return IQC;
        }

        //认证工艺路线工序查看
        public DataSet Search_PRDetail_RZR(Guid PT_ID)
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@PT_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = PT_ID;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Prco_S_PRDetail_RZR", parm);
        }

        //该产品型号实际工序查看
        public DataSet Search_PRDetail_SJ(Guid PT_ID)
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@PT_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = PT_ID;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Prco_S_PRDetail_SJ", parm);
        }

        //该产品型号实际工序模糊检索
        public DataSet Search_PRDetail_SJM(string PT_ID, string Condition)
        {
            SqlParameter[] parm = new SqlParameter[2];
            parm[0] = new SqlParameter("@PT_ID", SqlDbType.VarChar,50);
            parm[0].Value = PT_ID;
            parm[1] = new SqlParameter("@Condition", SqlDbType.NVarChar,1000);
            parm[1].Value = Condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Prco_S_PRDetail_SJM", parm);
        }

        //认证工艺路线工序添加
        public int Insert_PRDetail_RZR(Guid PRD_ID)
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@PRD_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = PRD_ID;
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
              CommandType.StoredProcedure, "Prco_I_PRDetail_RZR", parm);
        }

        //认证工艺路线工序修改
        public int Update_PRDetail_RZR(Guid PRD_ID, int PRD_RouteOrder)
        {
            SqlParameter[] parm = new SqlParameter[2];
            parm[0] = new SqlParameter("@PRD_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = PRD_ID;
            parm[1] = new SqlParameter("@PRD_RouteOrder", SqlDbType.TinyInt);
            parm[1].Value = PRD_RouteOrder;
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
              CommandType.StoredProcedure, "Proc_U_PRDetail_RZR", parm);
        }

        //认证工序添加
        public int Insert_PRDetail_RZ(Guid PRD_ID)
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@PRD_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = PRD_ID;
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
              CommandType.StoredProcedure, "Prco_I_PRDetail_RZ", parm);
        }

        //认证工序修改
        public int Update_PRDetail_RZ(Guid PRD_ID, int PRD_RenZhengOrder)
        {
            SqlParameter[] parm = new SqlParameter[2];
            parm[0] = new SqlParameter("@PRD_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = PRD_ID;
            parm[1] = new SqlParameter("@PRD_RenZhengOrder", SqlDbType.TinyInt);
            parm[1].Value = PRD_RenZhengOrder;
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
              CommandType.StoredProcedure, "Proc_U_PRDetail_RZ", parm);
        }

        //认证工艺路线工序删除
        public int Delete_PRDetail_RZR(Guid PRD_ID)
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@PRD_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = PRD_ID;
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
              CommandType.StoredProcedure, "Prco_D_PRDetail_RZR", parm);
        }

        //认证工序删除
        public int Delete_PRDetail_RZ(Guid PRD_ID)
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@PRD_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = PRD_ID;
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
              CommandType.StoredProcedure, "Prco_D_PRDetail_RZ", parm);
        }

        //查询入库明细中需要进料检验的物料用于默认绑定
        public DataSet Search_IMInStoreDetail_IQC(string Condition)
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 1000);
            parm[0].Value = Condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Prco_S_IMInStoreDetail_IQC", parm);
        }

        //查询待审核物料用于审核
        public DataSet Search_IMInStoreDetail_Au(string Condition)
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 1000);
            parm[0].Value = Condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Prco_S_IMInStoreDetail_Au", parm);
        }

        //查询入库明细中需要进料检验的物料的信息用于新增检验单时查看
        public IList<IQCBasicDataInfo> Search_IMInStoreDetail_New(string Condition)
        {
            SqlParameter parm = new SqlParameter("@Condition", Condition);
            IList<IQCBasicDataInfo> IQC = new List<IQCBasicDataInfo>();
            SqlDataReader sdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Prco_S_IMInStoreDetail_IQC", parm);
            while (sdr.Read())
            {
                IQC.Add(new IQCBasicDataInfo(
                   (Guid)sdr["IMISD_ID"],
                   (Guid)sdr["IMMBD_MaterialID"],
                   sdr["IMISM_InStoreNum"] == DBNull.Value ? "" : sdr["IMISM_InStoreNum"].ToString(),
                   sdr["IMMT_MaterialType"] == DBNull.Value ? "" : sdr["IMMT_MaterialType"].ToString(),
                   sdr["IMMBD_MaterialName"] == DBNull.Value ? "" : sdr["IMMBD_MaterialName"].ToString(),
                   sdr["IMMBD_MaterialCode"] == DBNull.Value ? "" : sdr["IMMBD_MaterialCode"].ToString(),
                   sdr["IMMBD_SpecificationModel"] == DBNull.Value ? "" : sdr["IMMBD_SpecificationModel"].ToString(),
                   sdr["PMSI_SupplyName"] == DBNull.Value ? "" : sdr["PMSI_SupplyName"].ToString(),
                   sdr["IMIDS_ActualArrNum"] == DBNull.Value ? 0 : Convert.ToDecimal( sdr["IMIDS_ActualArrNum"].ToString()),
                   sdr["UnitName"] == DBNull.Value ? "" : sdr["UnitName"].ToString(),
                   Convert.ToDateTime( sdr["IMISM_InStoreTime"].ToString())));
            }
            return IQC;
        }

        //查询待审核物料的检验详情用于显示
        public IList<IQCBasicDataInfo> Search_IMInStoreDetail_ViewAu(string Condition)
        {
            SqlParameter parm = new SqlParameter("@Condition", Condition);
            IList<IQCBasicDataInfo> IQC = new List<IQCBasicDataInfo>();
            SqlDataReader sdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Prco_S_IMInStoreDetail_Au", parm);
            while (sdr.Read())
            {
                IQC.Add(new IQCBasicDataInfo(
                   (Guid)sdr["IMISD_ID"],
                   (Guid)sdr["IQCDT_ID"],
                   (Guid)sdr["IMMBD_MaterialID"],
                   sdr["IMMT_MaterialType"] == DBNull.Value ? "" : sdr["IMMT_MaterialType"].ToString(),
                   sdr["IMMBD_MaterialName"] == DBNull.Value ? "" : sdr["IMMBD_MaterialName"].ToString(),
                   sdr["IMMBD_MaterialCode"] == DBNull.Value ? "" : sdr["IMMBD_MaterialCode"].ToString(),
                   sdr["IMMBD_SpecificationModel"] == DBNull.Value ? "" : sdr["IMMBD_SpecificationModel"].ToString(),
                   sdr["PMSI_SupplyName"] == DBNull.Value ? "" : sdr["PMSI_SupplyName"].ToString(),
                   sdr["IMIDS_ActualArrNum"] == DBNull.Value ? 0 : Convert.ToDecimal(sdr["IMIDS_ActualArrNum"].ToString()),
                   sdr["UnitName"] == DBNull.Value ? "" : sdr["UnitName"].ToString(),
                   Convert.ToDateTime(sdr["IMISM_InStoreTime"].ToString()),
                    sdr["IQCDT_Op"] == DBNull.Value ? "" : sdr["IQCDT_Op"].ToString()));
            }
            return IQC;
        }

        //新增检验单及检验值
        public int Insert_IQCDetailTable(Guid IMISD_ID, Guid IMMBD_MaterialID)
        {
            SqlParameter[] parm = new SqlParameter[2];
            parm[0] = new SqlParameter("@IMISD_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = IMISD_ID;
            parm[1] = new SqlParameter("@IMMBD_MaterialID", SqlDbType.UniqueIdentifier);
            parm[1].Value = IMMBD_MaterialID;
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
              CommandType.StoredProcedure, "Proc_I_IQCDetailTable", parm);
        }

        //查询检验详情表
        public IList<IQCBasicDataInfo> Search_IQCDetailTable(Guid IQCDT_ID)
        {
            SqlParameter parm = new SqlParameter("@IQCDT_ID", IQCDT_ID);
            IList<IQCBasicDataInfo> IQC = new List<IQCBasicDataInfo>();
            SqlDataReader sdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_S_IQCDetailTable", parm);
            while (sdr.Read())
            {
                IQC.Add(new IQCBasicDataInfo(
                   sdr["IQCDT_Input"] == DBNull.Value ? 0 : Convert.ToDecimal(sdr["IQCDT_Input"].ToString()),
                   sdr["IQCDT_TestPer"] == DBNull.Value ? "" : sdr["IQCDT_TestPer"].ToString(),
                   Convert.ToDateTime(sdr["IQCDT_TestTime"].ToString()),
                   sdr["IQCDT_Description"] == DBNull.Value ? "" : sdr["IQCDT_Description"].ToString(),
                   sdr["IQCDT_Result"] == DBNull.Value ? "" : sdr["IQCDT_Result"].ToString()     ));
            }
            return IQC;
        }

        //质检员判定检验合格
        public int Update_IMInStoreDetail_IQC(IQCBasicDataInfo et, string op)
        {
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Prco_U_IMInStoreDetail_IQC",
                new SqlParameter("@IMISD_ID", et.IMISD_ID), 
                new SqlParameter("@IMMBD_MaterialID", et.IMMBD_MaterialID),
                new SqlParameter("@IMIDS_QA", et.IMIDS_QA), new SqlParameter("@IQCDT_Result", et.IQCDT_Result),
                new SqlParameter("@IQCDT_Input", et.IQCDT_Input), new SqlParameter("@IQCDT_TestPer", et.IQCDT_TestPer),
                 new SqlParameter("@IQCDT_Description", et.IQCDT_Description), new SqlParameter("@State", et.State),
                  new SqlParameter("@IQCDT_Op", op));
        }

        //审核人审核检验结果
        public int Update_IMInStoreDetail_IQCAU(IQCBasicDataInfo et)
        {
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_IMInStoreDetail_IQCAU",
                new SqlParameter("@IMISD_ID", et.IMISD_ID), new SqlParameter("@IMMBD_MaterialID", et.IMMBD_MaterialID),
                new SqlParameter("@IQCDT_ID", et.IQCDT_ID),
                new SqlParameter("@IMIDS_QA", et.IMIDS_QA), new SqlParameter("@IQCDT_Result", et.IQCDT_Result),
                new SqlParameter("@IQCDT_Auditor", et.IQCDT_Auditor), new SqlParameter("@IQCDT_AResult", et.IQCDT_AResult),
                 new SqlParameter("@IQCDT_ASugg", et.IQCDT_ASugg), new SqlParameter("@IQCDT_DownDetail", et.IQCDT_DownDetail));
        }

        //查询检验标准用于录入时的显示
        public DataSet Search_IQCStandardTable_Grid(Guid IQCIT_ID, Guid IMISD_ID)
        {
            SqlParameter[] parm = new SqlParameter[2];
            parm[0] = new SqlParameter("@IQCIT_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = IQCIT_ID;
            parm[1] = new SqlParameter("@IMISD_ID", SqlDbType.UniqueIdentifier);
            parm[1].Value = IMISD_ID;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Prco_S_IQCStandardTable_Grid", parm);
        }

        //录入某项检验项目的某项检验标准
        public int Insert_IQCStandardValue(Guid IQCDT_ID, string QCSV_Value, string QCSV_Result,Guid IQCST_ID)
        {
            SqlParameter[] parm = new SqlParameter[4];
            parm[0] = new SqlParameter("@IQCDT_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = IQCDT_ID;
            parm[1] = new SqlParameter("@QCSV_Value", SqlDbType.VarChar, 100);
            parm[1].Value = QCSV_Value;
            parm[2] = new SqlParameter("@QCSV_Result", SqlDbType.VarChar, 10);
            parm[2].Value = QCSV_Result;
            parm[3] = new SqlParameter("@IQCST_ID", SqlDbType.UniqueIdentifier);
            parm[3].Value = IQCST_ID;
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
              CommandType.StoredProcedure, "Proc_I_IQCStandardValue", parm);
        }

        //新增认证信息
        public int Insert_WorkOrder_IQC(IQCBasicDataInfo IQC)
        {
            return (int)SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_WorkOrder_IQC",
                     new SqlParameter("@code", IQC.Code), new SqlParameter("@WO_Type", IQC.WO_Type),
                     new SqlParameter("@WO_ProType", IQC.WO_ProType), new SqlParameter("@WO_Level", IQC.WO_Level),
                     new SqlParameter("@WO_ChipNum", IQC.WO_ChipNum), new SqlParameter("@WO_PNum", IQC.WO_PNum),
                     new SqlParameter("@WO_Note", IQC.WO_Note),
                     new SqlParameter("@WO_People", IQC.WO_People),
                      new SqlParameter("@IMISD_ID", IQC.IMISD_ID)); 
        }

        //查询检验详情审核结果
        public IList<IQCBasicDataInfo> Search_IQCDetailTable_Au(Guid IQCDT_ID)
        {
            SqlParameter parm = new SqlParameter("@IQCDT_ID", IQCDT_ID);
            IList<IQCBasicDataInfo> IQC = new List<IQCBasicDataInfo>();
            SqlDataReader sdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_S_IQCDetailTable_Au", parm);
            while (sdr.Read())
            {
                IQC.Add(new IQCBasicDataInfo(
                   sdr["IQCDT_Auditor"] == DBNull.Value ? "" : sdr["IQCDT_Auditor"].ToString(),
                   //Convert.ToDateTime(sdr["IQCDT_ATime"].ToString()),
                   sdr["IQCDT_ATime"] == DBNull.Value ? Convert.ToDateTime("1900-01-01 00:00") : Convert.ToDateTime(sdr["IQCDT_ATime"].ToString()),
                   sdr["IQCDT_AResult"] == DBNull.Value ? "" : sdr["IQCDT_AResult"].ToString(),
                   sdr["IQCDT_ASugg"] == DBNull.Value ? "" : sdr["IQCDT_ASugg"].ToString(),
                   sdr["IQCDT_DownDetail"] == DBNull.Value ? "" : sdr["IQCDT_DownDetail"].ToString(),
                   Convert.ToInt32(sdr["WO_IsShengchan"].ToString()),
                   sdr["WO_Level"] == DBNull.Value ? "" : sdr["WO_Level"].ToString()));
            }
            return IQC;
        }

        //选择是否继续生产认证样品
        public int Update_WorkOrder_IQC(IQCBasicDataInfo et)
        {
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_WorkOrder_IQC",
                new SqlParameter("@State", et.State), new SqlParameter("@IQCDT_ID", et.IQCDT_ID),
                new SqlParameter("@WO_Level", et.WO_Level));
        }
        //查询需要的随工单
        public DataSet Search_WorkOrder(Guid IMISD_ID)
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@id", SqlDbType.UniqueIdentifier);
            parm[0].Value = IMISD_ID;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_IQC_WO_QAItem", parm);
        }
        //检验单审核驳回
        public int Update_IQCDT_Refuse(Guid id,string op)
        {
            SqlParameter[] parm = new SqlParameter[2];
            parm[0] = new SqlParameter("@id", SqlDbType.UniqueIdentifier);
            parm[0].Value = id;
            parm[1] = new SqlParameter("@op", SqlDbType.VarChar,400);
            parm[1].Value = op;
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
              CommandType.StoredProcedure, "Proc_U_IQCDT_Refuse", parm);
        }
        //重新录入检验结果
        public int Update_IQCDT_Result(Guid id, string result,string op,string op1)
        {
            SqlParameter[] parm = new SqlParameter[4];
            parm[0] = new SqlParameter("@id", SqlDbType.UniqueIdentifier);
            parm[0].Value = id;
            parm[1] = new SqlParameter("@result", SqlDbType.VarChar, 100);
            parm[1].Value = result;
            parm[2] = new SqlParameter("@op", SqlDbType.VarChar,400);
            parm[2].Value = op;
            parm[3] = new SqlParameter("@op_t", SqlDbType.VarChar, 400);
            parm[3].Value = op1;
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
              CommandType.StoredProcedure, "Proc_U_IQCDT_Result", parm);
        }
    }
