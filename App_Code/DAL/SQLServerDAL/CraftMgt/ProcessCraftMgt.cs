/* ==============================================================================
 * 类名称：ProcessCraftMgt 
 * 类的作用描述:实现接口类IProcessCraftMgt,提供具体的增删查改功能。为程序的数据访问层类
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
///这个文件提供了一个接口类，定义了有关的接口来访问PBCraftInfo表。其中定义的函数有
///1、DataSet SList_Craft();作用:罗列出所有的工序
///2、bool I_Craft(ProcessCraftMgtInfo InfoWantInert);作用:插入一条新的记录，在表PBCraftInfo中
///3、DataSet S_Craft(string InfoWantToSearch,int condition);作用:根据传入的参数，模糊查询表PBCraftInfo中的记录
///4、bool U_Craft(ProcessCraftMgtInfo InfoWantUpdata);作用:根据传入的参数，更新表PBCraftInfo中指定的记录
///5、bool D_Craft(Guid CraftID);作用:根据传入的ID，将表PBCraftInfo中指定的记录的Delet属性置位，使其不再被检索或则查询出来
///</summary>
namespace EquipmentMangementAjax.SQLServer
{
    public class ProcessCraftMgt:IProcessCraftMgt
    {

        /* ===================================数据成员定义区=========================================*/
        private int IntEffetiveLine;
        /* =======================================================================================*/

        /* ===================================方法定义区===========================================*/

        /// <summary>
        /// 函数名：SList_Craft
        /// 作者：bush2582
        /// 日期：2014年1月14日
        /// 参数：无
        /// 返回值：DataSet：查询到的记录集
        /// </summary>
        /// <returns>DataSet查询到的记录集</returns>
        public DataSet SList_Craft()
        {
            SqlParameter[] parm = new SqlParameter[6];

            //对应存储过程的Proc_S_PBCraftInfo_Condition的@PBC_ID参数
            parm[0] = new SqlParameter("@PBC_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = Guid.Empty;

            //对应存储过程的Proc_S_PBCraftInfo_Condition的@PBC_Name参数
            parm[1] = new SqlParameter("@PBC_Name", SqlDbType.VarChar, 60);
            parm[1].Value = "";

            //对应存储过程的Proc_S_PBCraftInfo_Condition的@PBC_Time参数
            parm[2] = new SqlParameter("@PBC_Time", SqlDbType.SmallInt);
            parm[2].Value = "0";

            //对应存储过程的Proc_S_PBCraftInfo_Condition的@PBC_PassRate参数
            parm[3] = new SqlParameter("@PBC_PassRate", SqlDbType.Decimal);
            parm[3].Value = "0";

            //对应存储过程的Proc_S_PBCraftInfo_Condition的@PBC_Parameter参数
            parm[4] = new SqlParameter("@PBC_Parameter", SqlDbType.VarChar, 200);
            parm[4].Value = "0";

            //对应存储过程的Proc_S_PBCraftInfo_Condition的@Condition参数
            parm[5] = new SqlParameter("@Condition", SqlDbType.SmallInt);
            parm[5].Value = "6";//在这个存储过程下，模式6是罗列所有的工序信息，不需要传入其他的信息，只要选择模式5即可

            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                                        CommandType.StoredProcedure,
                                        "Proc_S_PBCraftInfo_Condition", //调用数据库中的存储过程Proc_S_PBCraftInfo_Condition
                                        parm);//提供参数
        }

        /// <summary>
        /// 函数名：I_Craft
        /// 作者：bush2582
        /// 日期：2014年1月14日
        /// 作用：插入一条记录
        /// 参数：ProcessCraftMgtInfo InfoWantInert：要被插入的信息
        /// 返回值：bool 是否插入成功,重复插入相同的工序到数据库中会导致失败
        /// </summary>
        /// <param name="InfoWantInert">要被插入的信息</param>
        /// <returns>表是否插入成功</returns>
        public bool I_Craft(ProcessCraftMgtInfo InfoWantInert)
        {
            SqlParameter[] parm = new SqlParameter[5];

            //对应存储过程的Proc_S_PBCraftInfo_Condition的@PBC_Name参数
            parm[0] = new SqlParameter("@PBC_Name", SqlDbType.VarChar, 60);
            parm[0].Value = InfoWantInert.CraftName;

            //对应存储过程的Proc_S_PBCraftInfo_Condition的@PBC_Time参数
            parm[1] = new SqlParameter("@PBC_Time", SqlDbType.SmallInt);
            parm[1].Value = InfoWantInert.CraftWaringDay;

            //对应存储过程的Proc_S_PBCraftInfo_Condition的@PBC_PassRate参数
            parm[2] = new SqlParameter("@PBC_PassRate", SqlDbType.Decimal);
            parm[2].Value = InfoWantInert.CraftPassRate;

            //对应存储过程的Proc_S_PBCraftInfo_Condition的@PBC_Parameter参数
            parm[3] = new SqlParameter("@PBC_Parameter", SqlDbType.VarChar,200);
            parm[3].Value = InfoWantInert.CraftParameter;

            //对应存储过程的Proc_S_PBCraftInfo_Condition返回的值
            parm[4] = new SqlParameter("@return", SqlDbType.SmallInt);
            parm[4].Direction = ParameterDirection.ReturnValue;

            IntEffetiveLine = SqlHelper.ExecuteNonQuery(
               SqlHelper.ConnectionStringLocalTransaction,
               CommandType.StoredProcedure,
               "Proc_I_PBCraftInfo",//调用存储过程
               parm);//提供参数
            //如果执行存储过程后，返回值为负，表示执行未成功。参见MSDN对SqlHelper.ExecuteNonQuery的说明
            //Update、Insert 和 Delete 语句返回受影响的行数
            //也有可能是数据库中已经存在相同名字的工序，则插入失败,存储过程返回1表示失败
            if (IntEffetiveLine < 0 || parm[4].Value.ToString()=="1")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 函数名：S_Craft
        /// 作者：bush2582
        /// 作用：根据传入的条件项，选择查询的模式一共支持以下的几种模式：
        /// 1、状态1下使用模糊查询，通过参数PBC_Name（工艺名称）查询记录
        /// 2、状态2下使用精确的查询，通过参数PBC_Name（工艺名称）查询记录
        /// 3、状态3下使用精确的查询，通过参数PBC_Name（工艺名称）和@PBC_Time（预警天数）查询
        /// 4、状态4下使用精确的查询，通过参数PBC_PassRate（合格率参考标准）查询
        /// 6、状态6下罗列所有的工艺信息
        /// 7、查询是否在更新状态下有和数据库中其他的记录有相同名字
        /// 日期：2014年1月14日
        /// </summary>
        /// <param name="InfoWantToSearch">要被检索的信息</param>
        /// <param name="condition">选择检索模式</param>
        /// <returns>记录集</returns>
        public DataSet S_Craft(ProcessCraftMgtInfo InfoWantToSearch, string  condition)
        {
            SqlParameter[] parm = new SqlParameter[6];

            //对应存储过程的Proc_S_PBCraftInfo_Condition的@PBC_ID参数
            parm[0] = new SqlParameter("@PBC_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = InfoWantToSearch.CraftID;

            //对应存储过程的Proc_S_PBCraftInfo_Condition的@PBC_Name参数
            parm[1] = new SqlParameter("@PBC_Name", SqlDbType.VarChar, 60);
            parm[1].Value = InfoWantToSearch.CraftName;

            //对应存储过程的Proc_S_PBCraftInfo_Condition的@PBC_Time参数
            parm[2] = new SqlParameter("@PBC_Time", SqlDbType.SmallInt);
            parm[2].Value = Convert.ToInt32(InfoWantToSearch.CraftWaringDay);

            //对应存储过程的Proc_S_PBCraftInfo_Condition的@PBC_PassRate参数
            parm[3] = new SqlParameter("@PBC_PassRate", SqlDbType.Decimal,18);
            parm[3].Value = Convert.ToDecimal(InfoWantToSearch.CraftPassRate);

            //对应存储过程的Proc_S_PBCraftInfo_Condition的@PBC_Parameter参数
            parm[4] = new SqlParameter("@PBC_Parameter", SqlDbType.VarChar, 200);
            parm[4].Value = InfoWantToSearch.CraftParameter;

            //对应存储过程的Proc_S_PBCraftInfo_Condition的@Condition参数
            parm[5] = new SqlParameter("@Condition", SqlDbType.SmallInt);
            parm[5].Value = Convert.ToInt32(condition);//选择查询模式，看是支持哪种查询模式

            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                                        CommandType.StoredProcedure,
                                        "Proc_S_PBCraftInfo_Condition", //调用数据库中的存储过程Proc_S_PBCraftInfo_Condition
                                        parm);//提供参数
        }


        /// <summary>
        /// 函数名：U_Craft
        /// 作者：bush2582
        /// 作用：根据传入的参数更新一条记录
        /// 参数：ProcessCraftMgtInfo InfoWantUpdata：要被更新的参数
        /// 日期：2014年1月14日
        /// </summary>
        /// <param name="InfoWantUpdata">要被更新的参数</param>
        /// <returns>是否成功</returns>
        public bool U_Craft(ProcessCraftMgtInfo InfoWantUpdata)
        {
            SqlParameter[] parm = new SqlParameter[5];

            //对应存储过程的Proc_S_PBCraftInfo_Condition的@PBC_ID参数
            parm[0] = new SqlParameter("@PBC_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = InfoWantUpdata.CraftID;

            //对应存储过程的Proc_S_PBCraftInfo_Condition的@PBC_Name参数
            parm[1] = new SqlParameter("@PBC_Name", SqlDbType.VarChar, 60);
            parm[1].Value = InfoWantUpdata.CraftName;

            //对应存储过程的Proc_S_PBCraftInfo_Condition的@PBC_Time参数
            parm[2] = new SqlParameter("@PBC_Time", SqlDbType.SmallInt);
            parm[2].Value = Convert.ToInt32(InfoWantUpdata.CraftWaringDay);

            //对应存储过程的Proc_S_PBCraftInfo_Condition的@PBC_PassRate参数
            parm[3] = new SqlParameter("@PBC_PassRate", SqlDbType.Decimal);
            parm[3].Value = Convert.ToDecimal(InfoWantUpdata.CraftPassRate);

            //对应存储过程的Proc_S_PBCraftInfo_Condition的@PBC_Parameter参数
            parm[4] = new SqlParameter("@PBC_Parameter", SqlDbType.VarChar,200);
            parm[4].Value = InfoWantUpdata.CraftParameter;

            IntEffetiveLine = SqlHelper.ExecuteNonQuery(
                SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure,
                "Proc_U_PBCraftInfo",
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
        /// 函数名：D_Craft
        /// 作者：bush2582
        /// 作用：删除数据库中的一条工序记录，并且将该工序的不良品记录一概删除
        /// 返回值：是否成功
        /// 参数：工序ID
        /// </summary>
        /// <param name="CraftID"></param>
        /// <returns></returns>
        public bool D_Craft(Guid CraftID)
        {
            SqlParameter[] parm = new SqlParameter[1];

            //对应存储过程的Proc_D_PBCraftInfo的@PBC_ID参数
            parm[0] = new SqlParameter("@PBC_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = CraftID;

            IntEffetiveLine = SqlHelper.ExecuteNonQuery(
                SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure,
                "Proc_D_PBCraftInfo",
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


        public ProcessCraftMgt()
        {
            IntEffetiveLine = 0;
        }
        /* =======================================================================================*/
    }
}