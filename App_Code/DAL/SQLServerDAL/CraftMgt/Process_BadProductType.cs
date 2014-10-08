/* ==============================================================================
 * 类名称：Process_BadProductType 
 * 类的作用描述:实现接口类IProcess_BadProductTypeInfo,提供具体的增删查改功能。为程序的数据访问层类
 * 创建人：bush2582
 * 创建时间：1/14/2014 0.39
 * 修改人：
 * 修改时间：
 * 修改备注：
 * @version 1.0
 * ==============================================================================*/
using System;
using System.Data;
using System.Data.SqlClient;
using EquipmentMangementAjax.DBUtility;


///<summary>
///这个文件提供了一个接口类，定义了有关的接口来访问BadProductTypeInfo表。其中定义的函数有
///1、DataSet SList_BadProductTypeInfo();作用:罗列出所有的不良品记录
///2、bool I_BadProductTypeInfo(Process_BadProductTypeInfo InfoWantInert);作用:插入一条新的记录，在表BadProductTypeInfo中
///3、DataSet S_BadProductTypeInfo(string InfoWantToSearch,int condition);作用:根据传入的参数，模糊查询表BadProductTypeInfo中的记录
///4、bool U_BadProductTypeInfo(Process_BadProductTypeInfo InfoWantUpdata);作用:根据传入的参数，更新表BadProductTypeInfo中指定的记录
///5、bool D_BadProductTypeInfo(Guid BadProductID);作用:根据传入的ID，将表BadProductTypeInfo中指定的记录的Delet属性置位，使其不再被检索或则查询出来
///</summary>
namespace EquipmentMangementAjax.SQLServer
{
    public class Process_BadProductType : IProcess_BadProductTypeInfo
    {
        /* ===================================数据成员定义区=========================================*/
        private int IntEffetiveLine;
        /* =======================================================================================*/

        /// <summary>
        /// 函数名：SList_BadProductTypeInfo
        /// 作用：罗列出所有的不良品记录
        /// 作者：bush2582
        /// 日期：2014年1月17号 
        /// </summary>
        /// <returns></returns>
        public DataSet SList_BadProductTypeInfo(Process_BadProductTypeInfo InfoWantSearch)
        {
            SqlParameter[] parm = new SqlParameter[5];

            //对应存储过程的Proc_SDUI_BadProductType的@PBC_ID参数
            parm[0] = new SqlParameter("@PBC_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = InfoWantSearch.CraftID;

            //对应存储过程的Proc_SDUI_BadProductType的@BPT_ID参数
            parm[1] = new SqlParameter("@BPT_ID", SqlDbType.UniqueIdentifier);
            parm[1].Value = Guid.Empty;

            //对应存储过程的Proc_SDUI_BadProductType的@BPT_Name参数
            parm[2] = new SqlParameter("@BPT_Name", SqlDbType.VarChar, 60);
            parm[2].Value = "";

            //对应存储过程的Proc_SDUI_BadProductType的@BPT_BLeve参数
            parm[3] = new SqlParameter("@BPT_BLevel", SqlDbType.VarChar, 60);
            parm[3].Value = "";

            //对应存储过程的Proc_SDUI_BadProductType的@Condition参数
            parm[4] = new SqlParameter("@Condition", SqlDbType.SmallInt);
            parm[4].Value = 1;

            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                                            CommandType.StoredProcedure,
                                            "Proc_SDUI_BadProductType", //调用数据库中的存储过程Proc_SDUI_BadProductType
                                            parm);//提供参数
        }

        /// <summary>
        /// 函数名：I_BadProductTypeInfo
        /// 作用：插入一条新的记录，在表BadProductTypeInfo中
        /// 作者：bush2582
        /// 日期：2014年1月17号 
        /// 返回值是否插入成功
        /// </summary>
        /// <param name="InfoWantInert">要被插入的信息</param>
        /// <returns>返回是否成功</returns>
        public bool I_BadProductTypeInfo(Process_BadProductTypeInfo InfoWantInert)
        {
            SqlParameter[] parm = new SqlParameter[6];

            //对应存储过程的Proc_SDUI_BadProductType的@PBC_ID参数
            parm[0] = new SqlParameter("@PBC_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = InfoWantInert.CraftID;

            //对应存储过程的Proc_SDUI_BadProductType的@BPT_ID参数
            parm[1] = new SqlParameter("@BPT_ID", SqlDbType.UniqueIdentifier);
            parm[1].Value = Guid.Empty;

            //对应存储过程的Proc_SDUI_BadProductType的@BPT_Name参数
            parm[2] = new SqlParameter("@BPT_Name", SqlDbType.VarChar, 60);
            parm[2].Value = InfoWantInert.BadProductName;

            //对应存储过程的Proc_SDUI_BadProductType的@BPT_BLeve参数
            parm[3] = new SqlParameter("@BPT_BLevel", SqlDbType.VarChar, 60);
            parm[3].Value = InfoWantInert.BadProductBLevel;

            //对应存储过程的Proc_SDUI_BadProductType的@Condition参数
            parm[4] = new SqlParameter("@Condition", SqlDbType.SmallInt);
            parm[4].Value = "5";

            //对应存储过程的Proc_SDUI_BadProductType返回的值
            parm[5] = new SqlParameter("@return", SqlDbType.SmallInt);
            parm[5].Direction = ParameterDirection.ReturnValue;

            IntEffetiveLine = SqlHelper.ExecuteNonQuery(
                  SqlHelper.ConnectionStringLocalTransaction,
                  CommandType.StoredProcedure,
                  "Proc_SDUI_BadProductType",//调用存储过程
                  parm);//提供参数
            //如果执行存储过程后，返回值为负，表示执行未成功。参见MSDN对SqlHelper.ExecuteNonQuery的说明
            //Update、Insert 和 Delete 语句返回受影响的行数
            //也有可能是数据库中已经存在相同名字的不良品名称，则插入失败,存储过程返回1表示失败
            if (IntEffetiveLine < 0 || parm[5].Value.ToString() == "1")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 函数名：S_BadProductTypeInfo
        /// 作者：bush2582
        /// 作用：根据传入的条件项，选择查询的模式一共支持以下的几种模式：
        /// 1、状态1下查询某个工序下的不良品类型
        /// 2、状态2下查询是否在更新状态下有和数据库中其他的记录有相同名字
        /// 3、状态3下进行更新数据库记录的工作
        /// 4、状态4下删除一个不良品记录
        /// 5、状态5下插入一条新的记录到数据库中
        /// 日期：2014年1月17号 
        /// </summary>
        /// <param name="InfoWantToSearch">要检索的信息</param>
        /// <param name="condition">检索条件</param>
        /// <returns>返回记录集</returns>
        public DataSet S_BadProductTypeInfo(Process_BadProductTypeInfo InfoWantToSearch, string condition)
        {
            SqlParameter[] parm = new SqlParameter[5];

            //对应存储过程的Proc_SDUI_BadProductType的@PBC_ID参数
            parm[0] = new SqlParameter("@PBC_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = InfoWantToSearch.CraftID;

            //对应存储过程的Proc_SDUI_BadProductType的@BPT_ID参数
            parm[1] = new SqlParameter("@BPT_ID", SqlDbType.UniqueIdentifier);
            parm[1].Value = InfoWantToSearch.BadProductID;

            //对应存储过程的Proc_SDUI_BadProductType的@BPT_Name参数
            parm[2] = new SqlParameter("@BPT_Name", SqlDbType.VarChar, 60);
            parm[2].Value = InfoWantToSearch.BadProductName;

            //对应存储过程的Proc_SDUI_BadProductType的@BPT_BLeve参数
            parm[3] = new SqlParameter("@BPT_BLevel", SqlDbType.VarChar, 60);
            parm[3].Value = InfoWantToSearch.BadProductBLevel;

            //对应存储过程的Proc_SDUI_BadProductType的@Condition参数
            parm[4] = new SqlParameter("@Condition", SqlDbType.SmallInt);
            parm[4].Value = Convert.ToInt32(condition); ;

            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                                            CommandType.StoredProcedure,
                                            "Proc_SDUI_BadProductType", //调用数据库中的存储过程Proc_SDUI_BadProductType
                                            parm);//提供参数
        }

        /// <summary>
        /// 函数名：U_BadProductTypeInfo
        /// 作用：根据传入的参数，更新表BadProductTypeInfo中指定的记录
        /// 作者：bush2582
        /// 返回是否成功
        /// 日期：2014年1月17号
        /// </summary>
        /// <param name="InfoWantUpdata">要被更新的信息</param>
        /// <returns></returns>
        public bool U_BadProductTypeInfo(Process_BadProductTypeInfo InfoWantUpdata)
        {
            SqlParameter[] parm = new SqlParameter[5];

            //对应存储过程的Proc_SDUI_BadProductType的@PBC_ID参数
            parm[0] = new SqlParameter("@PBC_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = InfoWantUpdata.CraftID;

            //对应存储过程的Proc_SDUI_BadProductType的@BPT_ID参数
            parm[1] = new SqlParameter("@BPT_ID", SqlDbType.UniqueIdentifier);
            parm[1].Value = InfoWantUpdata.BadProductID;

            //对应存储过程的Proc_SDUI_BadProductType的@BPT_Name参数
            parm[2] = new SqlParameter("@BPT_Name", SqlDbType.VarChar, 60);
            parm[2].Value = InfoWantUpdata.BadProductName;

            //对应存储过程的Proc_SDUI_BadProductType的@BPT_BLeve参数
            parm[3] = new SqlParameter("@BPT_BLevel", SqlDbType.VarChar, 60);
            parm[3].Value = InfoWantUpdata.BadProductBLevel;

            //对应存储过程的Proc_SDUI_BadProductType的@Condition参数
            parm[4] = new SqlParameter("@Condition", SqlDbType.SmallInt);
            parm[4].Value = "3";

            IntEffetiveLine = SqlHelper.ExecuteNonQuery(
                  SqlHelper.ConnectionStringLocalTransaction,
                  CommandType.StoredProcedure,
                  "Proc_SDUI_BadProductType",//调用存储过程
                  parm);//提供参数
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
        /// 函数名：D_BadProductTypeInfo
        /// 作者：bush2582
        /// 作用：根据传入的ID，将表BadProductTypeInfo中指定的记录的Delet属性置位，使其不再被检索或则查询出来
        /// 参数：Guid BadProductID 要被删除的ID
        /// 日期：2014年1月17号
        /// </summary>
        /// <param name="BadProductID">要被删除的不良品记录ID</param>
        /// <returns>是否成功</returns>
        public bool D_BadProductTypeInfo(Guid BadProductID)
        {
            SqlParameter[] parm = new SqlParameter[5];

            //对应存储过程的Proc_SDUI_BadProductType的@PBC_ID参数
            parm[0] = new SqlParameter("@PBC_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = Guid.Empty;

            //对应存储过程的Proc_SDUI_BadProductType的@BPT_ID参数
            parm[1] = new SqlParameter("@BPT_ID", SqlDbType.UniqueIdentifier);
            parm[1].Value = BadProductID;

            //对应存储过程的Proc_SDUI_BadProductType的@BPT_Name参数
            parm[2] = new SqlParameter("@BPT_Name", SqlDbType.VarChar, 60);
            parm[2].Value = "";

            //对应存储过程的Proc_SDUI_BadProductType的@BPT_BLeve参数
            parm[3] = new SqlParameter("@BPT_BLevel", SqlDbType.VarChar, 60);
            parm[3].Value = "";

            //对应存储过程的Proc_SDUI_BadProductType的@Condition参数
            parm[4] = new SqlParameter("@Condition", SqlDbType.SmallInt);
            parm[4].Value = "4";

            IntEffetiveLine = SqlHelper.ExecuteNonQuery(
                  SqlHelper.ConnectionStringLocalTransaction,
                  CommandType.StoredProcedure,
                  "Proc_SDUI_BadProductType",//调用存储过程
                  parm);//提供参数
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

        public Process_BadProductType()
        {
            IntEffetiveLine = 0;
        }
    }
}