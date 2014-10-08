using System;
using System.Data;
using System.Data.SqlClient;
using EquipmentMangementAjax.DBUtility;
using EntityOfCraftBasicInfoMgt;
/// <summary>
///DALUnit 的摘要说明
/// </summary>

namespace DALCraftBasicInfoMgt
{
    public class DCraftBasicInfoMgt : ICraftBasicInfo
    {
        public DCraftBasicInfoMgt()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        /// <summary>
        /// 函数名:NewUnit
        /// 作用:新增用量单位
        /// 作者:开济
        /// </summary>
        /// <param name="name">添加用量单位</param>
        /// <returns>添加成功与否</returns>
        public bool NewUnit(string name)
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@UnitName", SqlDbType.VarChar, 20);
            parameters[0].Value = name;
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_Unit", parameters) > 0;
        }
        /// <summary>
        /// 函数名:SearchUnit
        /// 作用:模糊搜索用量单位
        /// 作者:开济
        /// </summary>
        /// <param name="name">用量单位</param>
        /// <returns>用量单位数据</returns>
        public DataSet SearchUnit(string name)//模糊检索超时原因
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@name", SqlDbType.VarChar, 20);
            parameters[0].Value = name;
            DataSet set = new DataSet();
            set = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_Unit", parameters);
            return set;
        }
        /// <summary>
        /// 函数名:UpdateUnit
        /// 作用:修改用量单位
        /// 作者:开济
        /// </summary>
        /// <param name="info">用量单位更新信息</param>
        /// <returns>更新成功与否</returns>
        public bool UpdateUnit(CraftBasicInfoMgt info)//修改超时原因
        {
            SqlParameter[] parmeters = new SqlParameter[2];
            parmeters[0] = new SqlParameter("@UnitID", SqlDbType.UniqueIdentifier);
            parmeters[0].Value = info.UnitID;
            parmeters[1] = new SqlParameter("@UnitName", SqlDbType.VarChar, 20);
            parmeters[1].Value = info.UnitName;
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_U_Unit", parmeters) > 0;
        }
        /// <summary>
        /// 函数名:DisplayUnit
        /// 作用:显示用量单位
        /// 作者:开济
        /// </summary>
        /// <returns>用量单位数据</returns>
        public DataSet DisplayUnit()
        {
            DataSet set = new DataSet();
            set = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                          CommandType.StoredProcedure, "Proc_SList_Unit", null);
            return set;
        }
        /// <summary>
        /// 函数名:DeleteUnit
        /// 作用:删除用量单位。并非真的物理删除，只是把deleted变为1
        /// 作者:开济
        /// </summary>
        /// <param name="id">用量单位id</param>
        /// <returns>删除成功与否</returns>
        public bool DeleteUnit(Guid id)
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@UnitID", SqlDbType.UniqueIdentifier);
            parameters[0].Value = id;
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
              CommandType.StoredProcedure, "Proc_D_Unit", parameters) > 0;
        }
        /// <summary>
        /// 函数名:SearchSameUnit
        /// 作用:搜索同名的用量单位，并返回数据集
        /// 作者:开济
        /// </summary>
        /// <param name="name">新增的用量单位名称</param>
        /// <returns></returns>
        public DataSet SearchSameUnit(string name)
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@UnitName", SqlDbType.VarChar, 20);
            parameters[0].Value = name;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_R_Unit", parameters);
        }
    }
}