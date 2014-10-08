/* ==============================================================================
 * 类名称：ProSeriesInfo_ProErrorTypeL 
 * 类的作用描述:BLL层的类，封装了底层有关于数据库访问类的,主要负责对当前的页面的请求进行逻辑处理
 * 创建人：bush2582
 * 创建时间：1/9/2014 10:26
 * 修改人：
 * 修改时间：
 * 修改备注：
 * @version 1.0
 * ==============================================================================*/
using System;
using System.Data;

/// <summary>
/// 这个文件具体给出了页面的业务逻辑的处理方法。
/// </summary>
public class ProcessCraftMgtL : BLLMatchNumber
{
   

    /* ===================================数据成员定义区=========================================*/


    //工厂模式，创建一个数据DAL用来访问数据库
    private static readonly IProcessCraftMgt mProcessCraftMgt = DALFactory.CreateIProcessCraftMgt();
    

    private string StrCondition; //条件标志，通过这个来选择查询的模式查询的模式一共支持以下的几种模式：
                                 // 1、状态1下使用模糊查询，通过参数PBC_Name（工艺名称）查询记录
                                 // 2、状态2下使用精确的查询，通过参数PBC_Name（工艺名称）查询记录
                                 // 3、状态3下使用精确的查询，通过参数PBC_Name（工艺名称）和@PBC_Time（预警天数）查询
                                 // 4、状态4下使用精确的查询，通过参数@PBC_Time（预警天数）查询
                                 // 5、状态5下使用精确的查询，通过参数PBC_PassRate（合格率参考标准）查询
                                 // 6、状态6下罗列所有的工艺信息
                                 // 7、查询是否在更新状态下有和数据库中其他的记录有相同名字
    private const string StrMode1_S_PBC_Name = "1";//状态1下使用模糊查询
    private const string StrMode2_AS_PBC_Name = "2";//状态2下使用精确的查询
    private const string SrtMode3_AS_PBC_Name_PBC_Time = "3";//状态3下使用精确的查询
    private const string StrMode4_AS_PBC_Time="4";//状态4下使用精确的查询
    private const string StrMode5_AS_PBC_PassRate="5";//状态5下使用精确的查询
    private const string StrMode6_S_ALL = "6";//select all
    private const string StrMode7_S_ALL = "7";//查询是否在更新状态下有和数据库中其他的记录有相同名字
    /* =======================================================================================*/

    /* ===================================方法定义区===========================================*/

    /// <summary>
    /// 函数名：GetSearchMode
    /// 作者：bush2582
    /// 作用：根据传入的参数获取当前应该采取哪种
    /// </summary>
    /// <param name="InfoWantToSearch"></param>
    /// <returns></returns>
    private string GetSearchMode(ProcessCraftMgtInfo InfoWantToSearch)
    {
        if (InfoWantToSearch.CraftName!=""&&InfoWantToSearch.CraftWaringDay!="0")//如果要被搜索的工序名称不为空且预警天数不为空
        {
            return SrtMode3_AS_PBC_Name_PBC_Time;
        }
        else if (InfoWantToSearch.CraftName == "" && InfoWantToSearch.CraftWaringDay != "0")//如果工艺名称为空，预警天数不为空
        {
            return StrMode4_AS_PBC_Time;
        }
        else if (InfoWantToSearch.CraftName != "" && InfoWantToSearch.CraftWaringDay == "0")//如果工艺名称不为空，预警天数为空
        {
            
            return StrMode1_S_PBC_Name;
        }
        else
        {
            return null;
        }
    }



    /// <summary> 
    /// 函数名:SList_Craft
    /// 作者:bush2582
    /// 作用:通过调用数据访问层函数，返回所有的工序 即select all
    /// 日期：2014年1月15日
    /// </summary> 
    public DataSet SList_Craft()
    {
        return mProcessCraftMgt.SList_Craft();
    }

    /// <summary>
    /// 函数名：S_Craft
    /// 作者：bush2582
    /// 作用：根据条件查询信息
    /// 日期：2014年1月15日
    /// </summary>
    /// <param name="InfoWantToSearch">要被搜索的信息</param>
    /// <param name="condition">条件选项</param>
    /// <returns>记录集</returns>
    public DataSet S_Craft(ProcessCraftMgtInfo InfoWantToSearch)
    {
        return mProcessCraftMgt.S_Craft(InfoWantToSearch, GetSearchMode(InfoWantToSearch));
    }

    /// <summary>
    /// 函数名：I_Craft
    /// 作者：bush2582
    /// 作用：插入一条新的记录，并检查页面传入的参数是否符合要求
    /// 返回值：bool 如果参数错误或则插入已有的相同的数据，返回失败
    /// </summary>
    /// <param name="InfoWantInert">要被插入的信息</param>
    /// <returns>返回是否成功</returns>
    public bool I_Craft(ProcessCraftMgtInfo InfoWantInert)
    {
        //判断当前的工序名字，工序预警天数不能为空，或则是否工艺的参考参数太长，或则合格率不是数字
        if (InfoWantInert.CraftName=="" || InfoWantInert.CraftWaringDay=="0"
            || InfoWantInert.CraftParameter.Length > 200 || base.IsMatchDecimal(InfoWantInert.CraftPassRate, 0, 1) == false
            )//注：这里有不需要用正则表达式对CraftPassRate和CraftWaringDay进行是否是数字的判断，因为在html前台已经判断过了
        {
            return false;
        }
        else
        {
            return mProcessCraftMgt.I_Craft(InfoWantInert);
        }
        
    }

    /// <summary>
    /// 函数名：U_Craft
    /// 作者：bush2582
    /// 作用：根据信息更新数据库中的一条记录
    /// 返回值：是否成功
    /// </summary>
    /// <param name="InfoWantUpdata"></param>
    /// <returns></returns>
    public bool U_Craft(ProcessCraftMgtInfo InfoWantUpdata)
    {
       
        if ( base.IsMatchInt(InfoWantUpdata.CraftWaringDay,0,10)==false)//判定是否是整数且是否是符合上下界
        {
            return false;
        }
        else if (InfoWantUpdata.CraftParameter.Length > 200)//判定长度
        {
            return false;
        }
        else if (base.IsMatchDecimal(InfoWantUpdata.CraftPassRate, 0, 1) == false)//判定是否是小数数且是否是符合上下界
        {
            return false;
        }
        else if (mProcessCraftMgt.S_Craft(InfoWantUpdata, StrMode7_S_ALL).Tables[0].Rows.Count>0)//如果要被跟新到数据库中的工序名字和数据库中已有的工序名称一样，则返回失败
        {
            return false;
        }
        else
        {
            mProcessCraftMgt.U_Craft(InfoWantUpdata);
            return true;
        }
        
        
    }

    /// <summary>
    /// 函数名：D_Craft
    /// 作者：bush2582
    /// 作用：删除一条工序记录，且删除对应的不良品记录
    /// 返回是否成功
    /// 参数：工序ID
    /// </summary>
    /// <param name="CraftID">工序ID</param>
    /// <returns></returns>
    public bool D_Craft(Guid CraftID)
    {
        return mProcessCraftMgt.D_Craft(CraftID);
    }

	public ProcessCraftMgtL()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    /* =======================================================================================*/
}