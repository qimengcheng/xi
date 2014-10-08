using System;
using System.Data;
using System.Data.SqlClient;
using EquipmentMangementAjax.DBUtility;
using EntityOfOverTime;
/// <summary>
///DOverTimeOption 的摘要说明
/// </summary>
namespace DALOverTime
{
    public class DOverTimeOption : IOverTimeOption
    {
        public DOverTimeOption()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
/// <summary>
/// 函数名:NewOverTime
/// 作用:新增超时原因选项
/// 作者:开济
/// </summary>
/// <param name="name">添加超时原因选项</param>
/// <returns>添加成功与否</returns>
        public bool NewOverTime(string name)
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@OTOName", SqlDbType.VarChar, 30);
            parameters[0].Value = name;
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_OverTimeOption", parameters) > 0;
        }
/// <summary>
/// 函数名:SearchOverTime
/// 作用:模糊搜索超时原因选项
/// 作者:开济
/// </summary>
/// <param name="name">超时原因选项</param>
/// <returns>超时原因选项数据</returns>
        public DataSet SearchOverTime(string name)//模糊检索超时原因
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@OTOName", SqlDbType.VarChar, 30);
            parameters[0].Value = name;
            DataSet set = new DataSet();
            set = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_OverTimeOption", parameters);
            return set;
        }
/// <summary>
/// 函数名:UpdateOverTime
/// 作用:修改超时原因选项
/// 作者:开济
/// </summary>
/// <param name="info">超时原因选项更新信息</param>
/// <returns>更新成功与否</returns>
        public bool UpdateOverTime(ModuleOfOverTime info)//修改超时原因
        {
            SqlParameter[] parmeters = new SqlParameter[2];
            parmeters[0] = new SqlParameter("@OTOID", SqlDbType.UniqueIdentifier);
            parmeters[0].Value = info.OtoID;
            parmeters[1] = new SqlParameter("@OTOName", SqlDbType.VarChar, 30);
            parmeters[1].Value = info.OtoName;
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_U_OverTimeOption", parmeters) > 0;
        }
/// <summary>
/// 函数名:DisplayOverTime
/// 作用:显示超时原因选项
/// 作者:开济
/// </summary>
/// <returns>超时原因选项数据</returns>
        public DataSet DisplayOverTime()
        {
            DataSet set = new DataSet();
            set = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                          CommandType.StoredProcedure, "Proc_SList_OverTimeOption", null);
            return set;
        }
/// <summary>
/// 函数名:DeleteOverTime
/// 作用:删除超时原因选项。并非真的物理删除，只是把deleted变为1
/// 作者:开济
/// </summary>
/// <param name="id">超时原因选项id</param>
/// <returns>删除成功与否</returns>
        public bool DeleteOverTime(Guid id)
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@OTOID", SqlDbType.UniqueIdentifier);
            parameters[0].Value = id;
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
              CommandType.StoredProcedure, "Proc_D_OverTimeOption", parameters) > 0;
        }
/// <summary>
/// 函数名:SearchSameOverTime
/// 作用:搜索同名的超时原因选项，并返回数据集
/// 作者:开济
/// </summary>
/// <param name="name">新增的超时原因名称</param>
/// <returns></returns>
        public DataSet SearchSameOverTime(string name)
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@OTOName", SqlDbType.VarChar, 30);
            parameters[0].Value = name;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_R_OverTimeOption", parameters);
        }

   //详细表
        public DataSet S_OverTimeOptionDetail(string OTO_ID, string condition)//查询选项详细项目
        {
            SqlParameter[] parm = new SqlParameter[2];
            parm[0] = new SqlParameter("@OTO_ID", SqlDbType.VarChar, 100);
            parm[0].Value = OTO_ID;
            parm[1] = new SqlParameter("@condition", SqlDbType.VarChar, 1000);
            parm[1].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
              CommandType.StoredProcedure, "Proc_S_OverTimeOptionDetail", parm);
        }

        public void U_OverTimeOptionDetail(Guid OTOD_ID, string OTOD_Name, Guid PBC_ID)//编辑选项详细项目
        {
            SqlParameter[] parm = new SqlParameter[3];
            parm[0] = new SqlParameter("@OTOD_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = OTOD_ID;
            parm[1] = new SqlParameter("@OTOD_Name", SqlDbType.VarChar, 60);
            parm[1].Value = OTOD_Name;
            parm[2] = new SqlParameter("@PBC_ID", SqlDbType.UniqueIdentifier);
            parm[2].Value = PBC_ID;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_U_OverTimeOptionDetail", parm);
        }
        public void I_OverTimeOptionDetail(Guid OTO_ID, string OTOD_Name, Guid PBC_ID)//新建选项详细项目
        {
            SqlParameter[] parm = new SqlParameter[3];
            parm[0] = new SqlParameter("@OTO_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = OTO_ID;
            parm[1] = new SqlParameter("@OTOD_Name", SqlDbType.VarChar, 60);
            parm[1].Value = OTOD_Name;
            parm[2] = new SqlParameter("@PBC_ID", SqlDbType.UniqueIdentifier);
            parm[2].Value = PBC_ID;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_I_OverTimeOptionDetail", parm);
        }

        public void D_OverTimeOptionDetail(Guid OTOD_ID)//删除选项详细项目
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@OTOD_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = OTOD_ID;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_D_OverTimeOptionDetail", parm);
        }
    }

}