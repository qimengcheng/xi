using System;
using System.Data;
using System.Data.SqlClient;
using EquipmentMangementAjax.DBUtility;

/// <summary>
///ProSeriesInfo_ProTypeD 的摘要说明
/// </summary>
namespace EquipmentMangementAjax.SQLServer
{
    public class ProSeriesInfo_ProTypeD : IProSeriesInfo_ProType
    {
        public ProSeriesInfo_ProTypeD()
        { }

        public DataSet SList_ProSeries()//检索所有产品系列
        {

            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_SList_ProSeries", null);

        }

        public DataSet S_PBCraftInfo(Guid pBC_ID)//检索某个工序
        {
            SqlParameter para = new SqlParameter("@PBC_ID", pBC_ID);
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_PBCraftInfo", para);

        }

        public DataSet S_PR_Name()//检索工艺路线名称
        {

            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_PR_Name", null);

        }
        public DataSet S_BOM_Name()//检索BOM名称
        {

            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_BOM_Name", null);

        }

        public void I_ProSeries(ProSeriesInfo_ProTypeInfo proSeriesInfo_ProTypeInfo)//插入新的产品系列
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@PS_Name", SqlDbType.VarChar, 60);
            parm[0].Value = proSeriesInfo_ProTypeInfo.PS_Name;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_ProSeries", parm);
        }

        public DataSet S_ProSeries(string pS_Name)//模糊检索产品系列
        {
            SqlParameter para = new SqlParameter("@PS_Name", pS_Name);
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_ProSeries", para);

        }

        public DataSet S_ProSeries_Name(string pS_Name)//检索特定产品系列名称的产品系列
        {
            SqlParameter para = new SqlParameter("@PS_Name", pS_Name);
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_ProSeries_Name", para);

        }

        public void U_ProSeries(ProSeriesInfo_ProTypeInfo proSeriesInfo_ProTypeInfo)//编辑产品系列名称
        {
            SqlParameter[] parm = new SqlParameter[2];
            parm[0] = new SqlParameter("@PS_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = proSeriesInfo_ProTypeInfo.PS_ID;
            parm[1] = new SqlParameter("@PS_Name", SqlDbType.VarChar, 60);
            parm[1].Value = proSeriesInfo_ProTypeInfo.PS_Name;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_U_ProSeries", parm);
        }
        public int D_ProSeries(Guid pS_ID)//删除产品系列
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@PS_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = pS_ID;
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
              CommandType.StoredProcedure, "Proc_D_ProSeries", parm);
        }
        public DataSet S_ProSeries_ProType(string condition)//查看一种产品系列所属产品型号
        {
            SqlParameter [] para = new SqlParameter[1];
         
            para[0] = new SqlParameter("@condition", SqlDbType.NVarChar,2000);
            para[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_ProSeries_ProType", para);

        }
        public DataSet SPTName_ProSeries_ProType(Guid pS_ID, string pT_Name)//检索一种产品系列特定产品型号
        {
            SqlParameter[] parm = new SqlParameter[2];
            parm[0] = new SqlParameter("@PS_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = pS_ID;
            parm[0] = new SqlParameter("@PT_Name", SqlDbType.UniqueIdentifier);
            parm[0].Value = pT_Name;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
              CommandType.StoredProcedure, "Proc_SPTName_ProSeries_ProType", parm);
        }

        public void I_ProType(ProSeriesInfo_ProTypeInfo proSeriesInfo_ProTypeInfo)//新增产品型号
        {
            SqlParameter[] parm = new SqlParameter[6];
            parm[0] = new SqlParameter("@PS_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = proSeriesInfo_ProTypeInfo.PS_ID;
            parm[1] = new SqlParameter("@PT_Name", SqlDbType.VarChar, 60);
            parm[1].Value = proSeriesInfo_ProTypeInfo.PT_Name;
            parm[2] = new SqlParameter("@PT_Special", SqlDbType.Char, 2);
            parm[2].Value = proSeriesInfo_ProTypeInfo.PT_Special;
            parm[3] = new SqlParameter("@BOM_ID", SqlDbType.UniqueIdentifier);
            parm[3].Value = proSeriesInfo_ProTypeInfo.BOM_ID;
            parm[4] = new SqlParameter("@PR_ID", SqlDbType.UniqueIdentifier);
            parm[4].Value = proSeriesInfo_ProTypeInfo.PR_ID;
            parm[5] = new SqlParameter("@PT_Man", SqlDbType.VarChar,20);
            parm[5].Value = proSeriesInfo_ProTypeInfo.PT_Man;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_ProType", parm);
        }

        public void I_ProType_new(ProSeriesInfo_ProTypeInfo proSeriesInfo_ProTypeInfo, string PT_Parameters, string PT_Code)//新增产品型号_新
        {
            SqlParameter[] parm = new SqlParameter[9];
            parm[0] = new SqlParameter("@PS_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = proSeriesInfo_ProTypeInfo.PS_ID;
            parm[1] = new SqlParameter("@PT_Name", SqlDbType.VarChar, 60);
            parm[1].Value = proSeriesInfo_ProTypeInfo.PT_Name;
            parm[2] = new SqlParameter("@PT_Special", SqlDbType.Char, 2);
            parm[2].Value = proSeriesInfo_ProTypeInfo.PT_Special;
            parm[3] = new SqlParameter("@BOM_ID", SqlDbType.UniqueIdentifier);
            parm[3].Value = proSeriesInfo_ProTypeInfo.BOM_ID;
            parm[4] = new SqlParameter("@PR_ID", SqlDbType.UniqueIdentifier);
            parm[4].Value = proSeriesInfo_ProTypeInfo.PR_ID;
            parm[5] = new SqlParameter("@PT_Man", SqlDbType.VarChar, 20);
            parm[5].Value = proSeriesInfo_ProTypeInfo.PT_Man;
            parm[6] = new SqlParameter("@PT_Parameters", SqlDbType.VarChar,400);
            parm[6].Value = PT_Parameters;
            parm[7] = new SqlParameter("@PT_Code", SqlDbType.VarChar, 30);
            parm[7].Value = PT_Code;
            parm[8] = new SqlParameter("@PT_Note", SqlDbType.VarChar, 400);
            parm[8].Value = proSeriesInfo_ProTypeInfo.PT_Note;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_ProType_new", parm);
        }


        public void U_ProType(ProSeriesInfo_ProTypeInfo proSeriesInfo_ProTypeInfo)//编辑产品型号
        {
            SqlParameter[] parm = new SqlParameter[7];
            parm[0] = new SqlParameter("@PS_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = proSeriesInfo_ProTypeInfo.PS_ID;
            parm[1] = new SqlParameter("@PT_Name", SqlDbType.VarChar, 60);
            parm[1].Value = proSeriesInfo_ProTypeInfo.PT_Name;
            parm[2] = new SqlParameter("@PT_Special", SqlDbType.Char, 2);
            parm[2].Value = proSeriesInfo_ProTypeInfo.PT_Special;
            parm[3] = new SqlParameter("@BOM_ID", SqlDbType.UniqueIdentifier);
            parm[3].Value = proSeriesInfo_ProTypeInfo.BOM_ID;
            parm[4] = new SqlParameter("@PR_ID", SqlDbType.UniqueIdentifier);
            parm[4].Value = proSeriesInfo_ProTypeInfo.PR_ID;
            parm[5] = new SqlParameter("@PT_ID", SqlDbType.UniqueIdentifier);
            parm[5].Value = proSeriesInfo_ProTypeInfo.PT_ID;
            parm[6] = new SqlParameter("@PT_Man", SqlDbType.VarChar, 20);
            parm[6].Value = proSeriesInfo_ProTypeInfo.PT_Man;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_U_ProType", parm);
        }
        public void U_ProType_new(ProSeriesInfo_ProTypeInfo proSeriesInfo_ProTypeInfo, string PT_Parameters, string PT_Code)//编辑产品型号_新
        {
            SqlParameter[] parm = new SqlParameter[10];
            parm[0] = new SqlParameter("@PS_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = proSeriesInfo_ProTypeInfo.PS_ID;
            parm[1] = new SqlParameter("@PT_Name", SqlDbType.VarChar, 60);
            parm[1].Value = proSeriesInfo_ProTypeInfo.PT_Name;
            parm[2] = new SqlParameter("@PT_Special", SqlDbType.Char, 2);
            parm[2].Value = proSeriesInfo_ProTypeInfo.PT_Special;
            parm[3] = new SqlParameter("@BOM_ID", SqlDbType.UniqueIdentifier);
            parm[3].Value = proSeriesInfo_ProTypeInfo.BOM_ID;
            parm[4] = new SqlParameter("@PR_ID", SqlDbType.UniqueIdentifier);
            parm[4].Value = proSeriesInfo_ProTypeInfo.PR_ID;
            parm[5] = new SqlParameter("@PT_ID", SqlDbType.UniqueIdentifier);
            parm[5].Value = proSeriesInfo_ProTypeInfo.PT_ID;
            parm[6] = new SqlParameter("@PT_Man", SqlDbType.VarChar, 20);
            parm[6].Value = proSeriesInfo_ProTypeInfo.PT_Man;
            parm[7] = new SqlParameter("@PT_Parameters", SqlDbType.VarChar, 400);
            parm[7].Value = PT_Parameters;
            parm[8] = new SqlParameter("@PT_Code", SqlDbType.VarChar, 30);
            parm[8].Value = PT_Code;
            parm[9] = new SqlParameter("@PT_Note", SqlDbType.VarChar, 400);
            parm[9].Value = proSeriesInfo_ProTypeInfo.PT_Note;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_U_ProType_new", parm);
        }
        public int D_ProType(Guid pT_ID)//删除产品型号
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@PT_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = pT_ID;
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
              CommandType.StoredProcedure, "Proc_D_ProType", parm);
        }
        public DataSet S_ProType_ProcessRoute(Guid pR_ID)//显示某产品型号的工艺路线
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@PR_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = pR_ID;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
              CommandType.StoredProcedure, "Proc_S_ProType_ProcessRoute", parm);
        }

        public void I_ProProcessParameter(ProSeriesInfo_ProTypeInfo proSeriesInfo_ProTypeInfo)//制定产品某个工序的工艺参数
        {
            SqlParameter[] parm = new SqlParameter[5];
            parm[0] = new SqlParameter("@PT_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = proSeriesInfo_ProTypeInfo.PT_ID;
            parm[1] = new SqlParameter("@PBC_ID", SqlDbType.UniqueIdentifier);
            parm[1].Value = proSeriesInfo_ProTypeInfo.PBC_ID;
            parm[2] = new SqlParameter("@PPP_Note", SqlDbType.VarChar, 200);
            parm[2].Value = proSeriesInfo_ProTypeInfo.PPP_Note;
            parm[3] = new SqlParameter("@PPP_Parameter", SqlDbType.VarChar, 200);
            parm[3].Value = proSeriesInfo_ProTypeInfo.PPP_Parameter;
            parm[4] = new SqlParameter("@PPP_PassRate", SqlDbType.Decimal);
            parm[4].Value = proSeriesInfo_ProTypeInfo.PPP_PassRate;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_I_ProProcessParameter", parm);
        }


        public void U_ProProcessParameter(ProSeriesInfo_ProTypeInfo proSeriesInfo_ProTypeInfo)//编辑产品某个工序的工艺参数
        {
            SqlParameter[] parm = new SqlParameter[5];
            parm[0] = new SqlParameter("@PT_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = proSeriesInfo_ProTypeInfo.PT_ID;
            parm[1] = new SqlParameter("@PBC_ID", SqlDbType.UniqueIdentifier);
            parm[1].Value = proSeriesInfo_ProTypeInfo.PBC_ID;
            parm[2] = new SqlParameter("@PPP_Note", SqlDbType.VarChar, 200);
            parm[2].Value = proSeriesInfo_ProTypeInfo.PPP_Note;
            parm[3] = new SqlParameter("@PPP_Parameter", SqlDbType.VarChar, 200);
            parm[3].Value = proSeriesInfo_ProTypeInfo.PPP_Parameter;
            parm[4] = new SqlParameter("@PPP_PassRate", SqlDbType.Decimal);
            parm[4].Value = proSeriesInfo_ProTypeInfo.PPP_PassRate;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_U_ProProcessParameter", parm);
        }

        public DataSet S_ProProcessParameter(Guid pT_ID, Guid pBC_ID)//查询产品某个工序的工艺参数
        {
            SqlParameter[] parm = new SqlParameter[2];
            parm[0] = new SqlParameter("@PT_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = pT_ID;
            parm[1] = new SqlParameter("@PBC_ID", SqlDbType.UniqueIdentifier);
            parm[1].Value = pBC_ID;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
              CommandType.StoredProcedure, "Proc_S_ProProcessParameter", parm);
        }

        public void I_ProMainSeries(string pMS_Name)//新增产品大型号
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@PMS_Name", SqlDbType.VarChar, 60);
            parm[0].Value = pMS_Name;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_I_ProMainSeries", parm);
        }
        public void U_ProMainSeries(Guid pMS_ID, string pMS_Name)//编辑产品大型号
        {
            SqlParameter[] parm = new SqlParameter[2];
            parm[0] = new SqlParameter("@PMS_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = pMS_ID;
            parm[1] = new SqlParameter("@PMS_Name", SqlDbType.VarChar, 60);
            parm[1].Value = pMS_Name;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_U_ProMainSeries", parm);
        }
        public void D_ProMainSeries(Guid pMS_ID)//删除产品大型号
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@PMS_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = pMS_ID;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_D_ProMainSeries", parm);
        }

        public DataSet S_ProMainSeries(string condition)//查询产品大型号
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@condition", SqlDbType.VarChar,1000);
            parm[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
              CommandType.StoredProcedure, "Proc_S_ProMainSeries", parm);
        }

        public void U_Protype_ProMainSeries(Guid pMS_ID, Guid pT_ID)//为产品型号添加产品大型号
        {
            SqlParameter[] parm = new SqlParameter[2];
            parm[0] = new SqlParameter("@PMS_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = pMS_ID;
            parm[1] = new SqlParameter("@PT_ID", SqlDbType.UniqueIdentifier);
            parm[1].Value = pT_ID;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_U_Protype_ProMainSeries", parm);
        }

        public void D_Protype_ProMainSeries(Guid pT_ID)//删除产品型号的产品大型号
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@PT_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = pT_ID;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_D_Protype_ProMainSeries", parm);
        }

        public DataSet S_Protype_ProMainSeries(string condition)//检索待选产品型号
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@condition", SqlDbType.VarChar, 1000);
            parm[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
              CommandType.StoredProcedure, "Proc_S_Protype_ProMainSeries", parm);
        }


        public DataSet S_ProMainSeries_Protype(string condition)//检索所属产品型号
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@condition", SqlDbType.VarChar, 1000);
            parm[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
              CommandType.StoredProcedure, "Proc_S_ProMainSeries_Protype", parm);
        }

        public DataSet S_ProType_new(string condition)//检索所属产品型号
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@condition", SqlDbType.NVarChar, 1000);
            parm[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
              CommandType.StoredProcedure, "Proc_S_ProType_new", parm);
        }
        public DataSet S_ProType_WorkOrder(string PT_Name)//检查随工单里是否有该产品型号名称
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@PT_Name", SqlDbType.VarChar,60);
            parm[0].Value = PT_Name;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
              CommandType.StoredProcedure, "Proc_S_ProType_WorkOrder", parm);
        }
        public DataSet S_PTCB()//产品编码属性检索
        {
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
              CommandType.StoredProcedure, "Proc_S_PTCB", null);
        }

        public DataSet S_PTCB_Detail(string condition, string PTCB_Section)//检索产品编码详情
        {
            SqlParameter[] parm = new SqlParameter[2];
            parm[0] = new SqlParameter("@condition", SqlDbType.VarChar, 1000);
            parm[0].Value = condition;
            parm[1] = new SqlParameter("@PTCB_Section", SqlDbType.VarChar, 10);
            parm[1].Value = PTCB_Section;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
              CommandType.StoredProcedure, "Proc_S_PTCB_Detail", parm);
        }

        public void D_PTCB_Detail(Guid PTCB_ID)//删除产品编码详情
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@PTCB_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = PTCB_ID;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_D_PTCB_Detail", parm);
        }

        public void I_PTCB_Detail(int PTCB_Section, string PTCB_Code, string PTCB_Detail)//新增产品编码详情
        {
            SqlParameter[] parm = new SqlParameter[3];
            parm[0] = new SqlParameter("@PTCB_Section", SqlDbType.Int);
            parm[0].Value = PTCB_Section;
            parm[1] = new SqlParameter("@PTCB_Code", SqlDbType.VarChar,10);
            parm[1].Value = PTCB_Code;
            parm[2] = new SqlParameter("@PTCB_Detail", SqlDbType.VarChar,60);
            parm[2].Value = PTCB_Detail;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_I_PTCB_Detail", parm);
        }
        public void U_PTCB_Detail(Guid PTCB_ID, string PTCB_Code, string PTCB_Detail)//编辑产品编码详情
        {
            SqlParameter[] parm = new SqlParameter[3];
            parm[0] = new SqlParameter("@PTCB_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = PTCB_ID;
            parm[1] = new SqlParameter("@PTCB_Code", SqlDbType.VarChar, 10);
            parm[1].Value = PTCB_Code;
            parm[2] = new SqlParameter("@PTCB_Detail", SqlDbType.VarChar, 60);
            parm[2].Value = PTCB_Detail;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_U_PTCB_Detail", parm);
        }

        public void U_Protype_ProSeries(Guid pS_ID, Guid pT_ID)//为产品型号添加产品系列
        {
            SqlParameter[] parm = new SqlParameter[2];
            parm[0] = new SqlParameter("@PS_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = pS_ID;
            parm[1] = new SqlParameter("@PT_ID", SqlDbType.UniqueIdentifier);
            parm[1].Value = pT_ID;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_U_Protype_ProSeries", parm);
        }

        public void D_Protype_ProSeries(Guid pT_ID)//删除产品型号的产品系列
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@PT_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = pT_ID;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_D_Protype_ProSeries", parm);
        }

        public DataSet S_Protype_ProSeries_ForChose(string condition)//检索待选产品型号
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@condition", SqlDbType.VarChar, 1000);
            parm[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
              CommandType.StoredProcedure, "Proc_S_Protype_ProSeries_ForChose", parm);
        }

        public DataSet S_ErrorPhenomenonOptionDetail(string EPO_ID,string  condition)//查询异常选项详细项目
        {
            SqlParameter[] parm = new SqlParameter[2];
            parm[0] = new SqlParameter("@EPO_ID", SqlDbType.VarChar,100);
            parm[0].Value = EPO_ID;
            parm[1] = new SqlParameter("@condition", SqlDbType.VarChar, 1000);
            parm[1].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
              CommandType.StoredProcedure, "Proc_S_ErrorPhenomenonOptionDetail", parm);
        }

        public void U_ErrorPhenomenonOptionDetail(Guid EPOD_ID, string EPOD_Name,Guid PBC_ID)//编辑异常选项详细项目
        {
            SqlParameter[] parm = new SqlParameter[3];
            parm[0] = new SqlParameter("@EPOD_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = EPOD_ID;
            parm[1] = new SqlParameter("@EPOD_Name", SqlDbType.VarChar,60);
            parm[1].Value = EPOD_Name;
            parm[2] = new SqlParameter("@PBC_ID", SqlDbType.UniqueIdentifier);
            parm[2].Value = PBC_ID;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_U_ErrorPhenomenonOptionDetail", parm);
        }
        public void I_ErrorPhenomenonOptionDetail(Guid EPO_ID, string EPOD_Name, Guid PBC_ID)//新建异常选项详细项目
        {
            SqlParameter[] parm = new SqlParameter[3];
            parm[0] = new SqlParameter("@EPO_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = EPO_ID;
            parm[1] = new SqlParameter("@EPOD_Name", SqlDbType.VarChar, 60);
            parm[1].Value = EPOD_Name;
            parm[2] = new SqlParameter("@PBC_ID", SqlDbType.UniqueIdentifier);
            parm[2].Value = PBC_ID;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_I_ErrorPhenomenonOptionDetail", parm);
        }

        public void D_ErrorPhenomenonOptionDetail(Guid EPOD_ID)//删除异常选项详细项目
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@EPOD_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = EPOD_ID;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_D_ErrorPhenomenonOptionDetail", parm);
        }
    }
}