using System;
using System.Data;
using System.Data.SqlClient;
using EquipmentMangementAjax.DBUtility;

/// <summary>
///CMProcessRoute 的摘要说明
/// </summary>
namespace EquipmentMangementAjax.SQLServer
{
    public class CMProcessRouteD:ICMProcessRoute
    {
        public CMProcessRouteD()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        public DataSet S_ProcessRoute_Doc(string condition)//检索工艺文件列表
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@condition", SqlDbType.NVarChar, 2000);
            para[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_ProcessRoute_Doc", para);

        }
        public DataSet S_ProcessRoute(Guid cDA_ID)//检索某工艺文件列表所属工艺路线
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@CDA_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = cDA_ID;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_ProcessRoute", para);

        }
        public DataSet S_ProcessRoute_PRDetail(Guid pR_ID)//检索某工艺路线所属工序
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@PR_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = pR_ID;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_ProcessRoute_PRDetail", para);

        }
        public void I_ProcessRoute(CMProcessRouteInfo cMProcessRouteInfo)//新增工艺路线
        {
            SqlParameter[] parm = new SqlParameter[4];
            parm[0] = new SqlParameter("@CDA_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = cMProcessRouteInfo.CDA_ID;
            parm[1] = new SqlParameter("@PR_Special", SqlDbType.Char, 2);
            parm[1].Value = cMProcessRouteInfo.PR_Special;
            parm[2] = new SqlParameter("@PR_Name", SqlDbType.VarChar, 50);
            parm[2].Value = cMProcessRouteInfo.PR_Name;
            parm[3] = new SqlParameter("@PR_WritePeople", SqlDbType.VarChar, 20);
            parm[3].Value = cMProcessRouteInfo.PR_WritePeople;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_ProcessRoute", parm);
        }
        public void U_ProcessRoute(CMProcessRouteInfo cMProcessRouteInfo)//编辑工艺路线
        {
            SqlParameter[] parm = new SqlParameter[4];
            parm[0] = new SqlParameter("@PR_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = cMProcessRouteInfo.PR_ID;
            parm[1] = new SqlParameter("@PR_Special", SqlDbType.Char, 2);
            parm[1].Value = cMProcessRouteInfo.PR_Special;
            parm[2] = new SqlParameter("@PR_Name", SqlDbType.VarChar, 50);
            parm[2].Value = cMProcessRouteInfo.PR_Name;
            parm[3] = new SqlParameter("@PR_WritePeople", SqlDbType.VarChar, 20);
            parm[3].Value = cMProcessRouteInfo.PR_WritePeople;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_ProcessRoute", parm);
        }
        public void D_ProcessRoute(CMProcessRouteInfo cMProcessRouteInfo)//删除工艺路线
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@PR_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = cMProcessRouteInfo.PR_ID;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_ProcessRoute", parm);
        }
        public void U_ProcessRoute_PRDetail(CMProcessRouteInfo cMProcessRouteInfo)//编辑某工艺路线所属工序
        {
            SqlParameter[] parm = new SqlParameter[5];
            parm[0] = new SqlParameter("@PRD_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = cMProcessRouteInfo.PRD_ID;
            parm[1] = new SqlParameter("@PRD_Order", SqlDbType.TinyInt);
            parm[1].Value = cMProcessRouteInfo.PRD_Order;
            parm[2] = new SqlParameter("@PRD_Doc", SqlDbType.VarChar, 50);
            parm[2].Value = cMProcessRouteInfo.PRD_Doc;
            parm[3] = new SqlParameter("@PRD_Way", SqlDbType.VarChar, 50);
            parm[3].Value = cMProcessRouteInfo.PRD_Way;
            parm[4] = new SqlParameter("@PRD_Note", SqlDbType.VarChar, 400);
            parm[4].Value = cMProcessRouteInfo.PRD_Note;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_ProcessRoute_PRDetail", parm);

        }
        public void D_ProcessRoute_PRDetail(CMProcessRouteInfo cMProcessRouteInfo)//删除工艺路线所属工序
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@PRD_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = cMProcessRouteInfo.PRD_ID;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_ProcessRoute_PRDetail", parm);
        }

        public DataSet S_ProcessRoute_PBCraftInfo(Guid pR_ID)//检索某工艺路线所属工序
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@PR_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = pR_ID;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_ProcessRoute_PBCraftInfo", para);

        }

        public void I_PRDetail_PBCraftInfo(Guid prid, Guid pbcid)//将工序新增至工艺路线详细
        {
            SqlParameter[] parm = new SqlParameter[2];
            parm[0] = new SqlParameter("@PR_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = prid;
            parm[1] = new SqlParameter("@PBC_ID", SqlDbType.UniqueIdentifier);
            parm[1].Value = pbcid;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_PRDetail_PBCraftInfo", parm);
        }
        public void I_CopyPRDetail(Guid prid1, Guid prid2)//插入某个工艺路线的所有工序
        {
            SqlParameter[] parm = new SqlParameter[2];
            parm[0] = new SqlParameter("@PR_ID1", SqlDbType.UniqueIdentifier);
            parm[0].Value = prid1;
            parm[1] = new SqlParameter("@PR_ID2", SqlDbType.UniqueIdentifier);
            parm[1].Value = prid2;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_CopyPRDetail", parm);
        }
    }
}