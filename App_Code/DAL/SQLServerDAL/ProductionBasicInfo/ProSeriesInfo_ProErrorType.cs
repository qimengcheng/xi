/* ==============================================================================
 * 类名称：ProSeriesInfo_ProErrorType 
 * 类的作用描述:实现接口类IProSeriesInfo_ProErrorType,提供具体的增删查改功能。为程序的数据访问层类
 * 创建人：bush2582
 * 创建时间：11/7/2013 14:20
 * 修改人：
 * 修改时间：
 * 修改备注：
 * @version 1.0
 * ==============================================================================*/
using System;
using System.Data;
using System.Data.SqlClient;
using EquipmentMangementAjax.DBUtility;

/// <summary>
/// 这个文件具体实现了IProSeriesInfo_ProErrorType这个接口，提供了具体对表ErrorPhenomenonOption的操做，主要的操作包括了
/// 1、SList_ProErrorSeries();作用:罗列出所有的异常原因选项
/// 2、I_ProErrorSeries(ProSeriesInfo_ProErrorSeriesInfo InfoWantInert);作用:插入一条新的记录，在表ErrorPhenomenonOption中
/// 3、S_ProErrorSeries(string InfoWantToSearch);作用:根据传入的参数，模糊查询表ErrorPhenomenonOption中的记录
/// 4、U_ProErrorSeries(ProSeriesInfo_ProErrorSeriesInfo InfoWantUpdata);作用:根据传入的参数，更新表ErrorPhenomenonOption中指定的记录
/// 5、bool D_ProErrorSeries(Guid ProErrorSeriesID);作用:根据传入的ID，将表ErrorPhenomenonOption中指定的记录的Delet属性置位，使其不再被检索或则查询出来
/// </summary>
namespace EquipmentMangementAjax.SQLServer
{
    public class ProSeriesInfo_ProErrorType:IProSeriesInfo_ProErrorType
    {
        /* ===================================数据成员定义区=========================================*/
        private int IntEffetiveLine;

        /* =======================================================================================*/





        /* ===================================方法定义区===========================================*/

 
        /// <summary> 
        /// 函数名:SList_ProErrorSeries
        /// 作者:bush2582
        /// 作用:查询并返回所有的异常选项
        /// 参数:无
        /// </summary> 
        public DataSet SList_ProErrorSeries()
        {
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                                        CommandType.StoredProcedure,
                                        "Proc_SList_ErrorSeries", //调用数据库中的存储过程Proc_SList_ErrorSeries
                                        null);
        }

        /// <summary> 
        /// 函数名:I_ProErrorSeries
        /// 作者:bush2582
        /// 作用:插入一个新的异常选项
        /// </summary> 
        /// <param name="ProSeriesInfo_ProErrorSeriesInfo">需要被插入到数据库中的一条记录</param>
        /// <returns>bool值 是否成功，若插入不成功返回false</returns>
        public bool I_ProErrorSeries(ProSeriesInfo_ProErrorSeriesInfo InfoWantInert)
        {
            
            SqlParameter[] parm = new SqlParameter[2];

            //对应数据库中存储过程Proc_I_ErrorSeries的参数ProcErrorName
            parm[0] = new SqlParameter("@ProcErrorName",SqlDbType.VarChar,60);
            parm[0].Value = InfoWantInert.ProErrorName;

            //对应数据库中存储过程Proc_I_ErrorSeries的参数ProcWarnDays
            parm[1] = new SqlParameter("@ProcWarnDays",SqlDbType.SmallInt);
            parm[1].Value = InfoWantInert.ProErrorWaringDay;

            IntEffetiveLine=SqlHelper.ExecuteNonQuery(
                SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure,
                "Proc_I_ErrorSeries",
                parm);

            //如果执行存储过程后，返回值为负，表示执行未成功。参见MSDN对SqlHelper.ExecuteNonQuery的说明
            //Update、Insert 和 Delete 语句返回受影响的行数
            if (IntEffetiveLine < 0)
            {
                return false; 
            }
            else
            {
                return true;
            }
        }



        /// <summary> 
        /// 函数名:S_ProErrorSeries
        /// 作者:bush2582
        /// 作用:模糊查询异常选项
        /// </summary> 
        /// <param name="string InfoWantToSearch">需要被模糊查询的字段</param>
        /// <returns>DataSet</returns>
        public DataSet S_ProErrorSeries(string InfoWantToSearch)
        {
            SqlParameter para = new SqlParameter("@ProcErrorName", InfoWantToSearch);
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                                        CommandType.StoredProcedure,
                                        "Proc_S_ErrorSeries",//调用数据库中的Proc_S_ErrorSeries存储过程
                                        para);
        }


        /// <summary> 
        /// 函数名:U_ProErrorSeriesWarnDays
        /// 作者:bush2582
        /// 作用:更新异常选项的预警天数
        /// </summary> 
        /// <param name="string InfoWantToSearch">需要被跟新到数据库中的一条记录</param>
        /// <returns>bool是否成功执行</returns>
        public bool U_ProErrorSeriesWarnDays(ProSeriesInfo_ProErrorSeriesInfo InfoWantUpdata)
        {
            SqlParameter[] parm = new SqlParameter[2];
            parm[0] = new SqlParameter("@ErrorSeriesID", SqlDbType.UniqueIdentifier);
            parm[0].Value = InfoWantUpdata.ProErrorID;
            parm[1] = new SqlParameter("@ErrorSeriesWarnDays", SqlDbType.VarChar, 60);
            parm[1].Value = InfoWantUpdata.ProErrorWaringDay;

            IntEffetiveLine = SqlHelper.ExecuteNonQuery(
                SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure,
                "Proc_U_ErrorSeriesWarnDays",
                 parm);
            //如果执行存储过程后，返回值为负，表示执行未成功。参见MSDN对SqlHelper.ExecuteNonQuery的说明
            //Update、Insert 和 Delete 语句返回受影响的行数
            if (IntEffetiveLine < 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary> 
        /// 函数名:U_ProErrorSeriesName
        /// 作者:bush2582
        /// 作用:更新异常选项的名称
        /// </summary> 
        /// <param name="string InfoWantToSearch">需要被跟新到数据库中的一条记录</param>
        /// <returns>bool是否成功执行</returns>
        public bool U_ProErrorSeriesName(ProSeriesInfo_ProErrorSeriesInfo InfoWantUpdata)
        {
            SqlParameter[] parm = new SqlParameter[2];
            parm[0] = new SqlParameter("@ErrorSeriesID", SqlDbType.UniqueIdentifier);
            parm[0].Value = InfoWantUpdata.ProErrorID;
            parm[1] = new SqlParameter("@ErrorSeriesNewName", SqlDbType.VarChar, 60);
            parm[1].Value = InfoWantUpdata.ProErrorName;

            IntEffetiveLine = SqlHelper.ExecuteNonQuery(
                SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure,
                "Proc_U_ErrorSeriesName",
                 parm);
            //如果执行存储过程后，返回值为负，表示执行未成功。参见MSDN对SqlHelper.ExecuteNonQuery的说明
            //Update、Insert 和 Delete 语句返回受影响的行数
            if (IntEffetiveLine < 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        /// <summary> 
        /// 函数名:D_ProErrorSeries
        /// 作者:bush2582
        /// 作用:将一条异常原因选项置为删除状态
        /// </summary> 
        /// <param name="Guid ProErrorSeriesID">需要被置位的异常的ID</param>
        /// <returns>bool是否成功执行</returns>
        public bool D_ProErrorSeries(Guid ProErrorSeriesID)
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@ErrorSeriesID", SqlDbType.UniqueIdentifier);
            parm[0].Value = ProErrorSeriesID;
            IntEffetiveLine=SqlHelper.ExecuteNonQuery(
                                            SqlHelper.ConnectionStringLocalTransaction,
                                            CommandType.StoredProcedure,
                                            "Proc_D_ErrorSeries", 
                                            parm);
            //如果执行存储过程后，返回值为负，表示执行未成功。参见MSDN对SqlHelper.ExecuteNonQuery的说明
            //Update、Insert 和 Delete 语句返回受影响的行数
            if (IntEffetiveLine < 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        /// <summary> 
        /// 函数名:S_ErrorSeriesAccurate
        /// 作者:bush2582
        /// 作用:精确查询异常选项
        /// </summary> 
        /// <param name="string InfoWantToSearch">需要被精确查询的字段</param>
        /// <returns>DataSet</returns>
        public DataSet S_ErrorSeriesAccurate(ProSeriesInfo_ProErrorSeriesInfo InfoWantToSearch)
        {
            SqlParameter[] parm = new SqlParameter[2];
            parm[0] = new SqlParameter("@ProcErrorName", SqlDbType.VarChar, 60);
            parm[0].Value = InfoWantToSearch.ProErrorName;

            parm[1] = new SqlParameter("@ErrorSeriesID", SqlDbType.UniqueIdentifier);
            parm[1].Value = InfoWantToSearch.ProErrorID;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                                        CommandType.StoredProcedure,
                                        "Proc_S_ErrorSeriesAccurate",//调用数据库中的Proc_S_ErrorSeriesAccurate存储过程
                                        parm);
        }

        public ProSeriesInfo_ProErrorType()
        {
            IntEffetiveLine = 0;
        }
        /* =======================================================================================*/
    }
}
