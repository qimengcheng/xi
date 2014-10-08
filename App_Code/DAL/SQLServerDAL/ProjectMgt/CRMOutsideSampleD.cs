using System;
using System.Data;
using System.Data.SqlClient;
using EquipmentMangementAjax.DBUtility;


/// <summary>
///CRMOutsideSampleD 的摘要说明
/// </summary>

    public class CRMOutsideSampleD
    {
        public CRMOutsideSampleD()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        //查找外送样品表
        public DataSet SelectCRMOutsideSample(string condition)
        {
            SqlParameter parm = new SqlParameter("@Condition", condition);
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_CRMOutsideSample", parm);
        }
        public DataSet SelectBOS()
        {
           
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_BDOrganizationSheet");
        }
        //新增外送样品表
        public void InsertCRMOutsideSample(CRMOutsideSampleinfo cRMOutsideSampleinfo,string man)
        {
            SqlParameter[] parm = new SqlParameter[7];

            parm[0] = new SqlParameter("@CRMOS_Factory", SqlDbType.VarChar,100);
            parm[0].Value = cRMOutsideSampleinfo.CRMOS_Factory;
            parm[1] = new SqlParameter("@CRMOS_AlertDay", SqlDbType.SmallInt);
            parm[1].Value = cRMOutsideSampleinfo.CRMOS_AlertDay;
            parm[2] = new SqlParameter("@CRMOS_AnalysisReport", SqlDbType.VarChar, 10);
            parm[2].Value = cRMOutsideSampleinfo.CRMOS_AnalysisReport;
            parm[3] = new SqlParameter("@CRMOS_Num", SqlDbType.Decimal);
            parm[3].Value = cRMOutsideSampleinfo.CRMOS_Num;
            parm[4] = new SqlParameter("@CRMOS_Remark", SqlDbType.VarChar, 400);
            parm[4].Value = cRMOutsideSampleinfo.CRMOS_Remark;
            parm[5] = new SqlParameter("@CRMOS_State", SqlDbType.VarChar,20);
            parm[5].Value = cRMOutsideSampleinfo.CRMOS_State;
            parm[6] = new SqlParameter("@CRMOS_ApplyMan", SqlDbType.VarChar, 20);
            parm[6].Value = man;
            SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                     CommandType.StoredProcedure, "Proc_I_CRMOutsideSample", parm);
        }
        //修改外送样品表
        public void UpdateCRMOutsideSample(CRMOutsideSampleinfo cRMOutsideSampleinfo)
        {
            SqlParameter[] parm = new SqlParameter[6];

            parm[0] = new SqlParameter("@CRMOS_Factory", SqlDbType.VarChar, 100);
            parm[0].Value = cRMOutsideSampleinfo.CRMOS_Factory;
            parm[1] = new SqlParameter("@CRMOS_AlertDay", SqlDbType.SmallInt);
            parm[1].Value = cRMOutsideSampleinfo.CRMOS_AlertDay;
            parm[2] = new SqlParameter("@CRMOS_AnalysisReport", SqlDbType.VarChar, 10);
            parm[2].Value = cRMOutsideSampleinfo.CRMOS_AnalysisReport;
            parm[3] = new SqlParameter("@CRMOS_Num", SqlDbType.Decimal);
            parm[3].Value = cRMOutsideSampleinfo.CRMOS_Num;
            parm[4] = new SqlParameter("@CRMOS_Remark", SqlDbType.VarChar, 400);
            parm[4].Value = cRMOutsideSampleinfo.CRMOS_Remark;
            parm[5] = new SqlParameter("@CRMOS_ID", SqlDbType.UniqueIdentifier);
            parm[5].Value = cRMOutsideSampleinfo.CRMOS_ID;

            SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                     CommandType.StoredProcedure, "Proc_U_CRMOutsideSample", parm);
        }
              //删除外送样品表
        public void DeleteCRMOutsideSample(CRMOutsideSampleinfo cRMOutsideSampleinfo)
        {
            SqlParameter[] parm = new SqlParameter[1];

            parm[0] = new SqlParameter("@CRMOS_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = cRMOutsideSampleinfo.CRMOS_ID;
            SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                    CommandType.StoredProcedure, "Proc_D_CRMOutsideSample", parm);
        }
        //添加外送样品分析结论
        public void UpdateCRMOutsideSample_Analysis(CRMOutsideSampleinfo cRMOutsideSampleinfo,string man)
        {
            SqlParameter[] parm = new SqlParameter[4];

            parm[0] = new SqlParameter("@CRMOS_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = cRMOutsideSampleinfo.CRMOS_ID;
            parm[1] = new SqlParameter("@CRMOS_State", SqlDbType.VarChar,20);
            parm[1].Value = cRMOutsideSampleinfo.CRMOS_State;
            parm[2] = new SqlParameter("@CRMOS_AnalysisResult", SqlDbType.VarChar, 400);
            parm[2].Value = cRMOutsideSampleinfo.CRMOS_AnalysisResult;
            parm[3] = new SqlParameter("@CRMOS_AnalysisMan", SqlDbType.VarChar, 20);
            parm[3].Value = man;
            SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                    CommandType.StoredProcedure, "Proc_U_CRMOutsideSample_Analysis", parm);
        }
        //技术部长选发部门
        public void UpdateCRMOutsideSample_Check(Guid id ,string man,string state,string bos,string note)
        {
            SqlParameter[] parm = new SqlParameter[5];
            parm[0] = new SqlParameter("@CRMOS_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = id;
            parm[1] = new SqlParameter("@CRMOS_CheckMan", SqlDbType.VarChar, 20);
            parm[1].Value =man;
            parm[2] = new SqlParameter("@CRMOS_State", SqlDbType.VarChar, 20);
            parm[2].Value = state;
            parm[3] = new SqlParameter("@BDOS_Code", SqlDbType.VarChar, 60);
            parm[3].Value = bos;
            parm[4] = new SqlParameter("@CRMOS_CheckNote", SqlDbType.VarChar, 400);
            parm[4].Value = note;
            SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
             CommandType.StoredProcedure, "Proc_U_CRMOutsideSample_Check", parm);
        }
        //技术部长选发部门
        public void UpdateCRMOutsideSample_up(Guid id, string path)
        {
            SqlParameter[] parm = new SqlParameter[2];
            parm[0] = new SqlParameter("@CRMOS_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = id;
            parm[1] = new SqlParameter("@CRMOS_Path", SqlDbType.VarChar, 100);
            parm[1].Value = path;
            SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
             CommandType.StoredProcedure, "Proc_U_CRMOutsideSample_Upload", parm);
        }
    }
