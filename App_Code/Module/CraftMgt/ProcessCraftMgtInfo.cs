/* ==============================================================================
 * 类名称：ProcessCraftMgtInfo 
 * 类的作用描述:将数据库中PBCraftInfo表中的属性在这个类中反应。
 * 创建人：bush2582
 * 创建时间：1/14/2014 20:38
 * 修改人：
 * 修改时间：
 * 修改备注：
 * @version 1.0
 * ==============================================================================*/
using System;

/// <summary>
/// 这个文件定义了一个对应于PBCraftInfo表的类，在这个类中用类的属性对应了表中的属性。
/// 提供了如下的属性：
///                 1、CraftID:对应于表中的PBC_ID
///                 2、CraftName:对应于表中的PBC_Name
///                 3、CraftWaringDay:对应于表中的PBC_Time
///                 4、CraftPassRate:对应于表中的PBC_PassRate
///                 5、CraftParameter:对应于表中的PBC_Parameter
///                 6、CraftDeleted:对应于表中的PBC_Deleted
/// </summary>
public class ProcessCraftMgtInfo
{
    /* =================================数据成员定义区========================================*/

    /// <summary>
    /// 对应于PBCraftInfo的PBC_ID
    /// </summary>
    private Guid GuCraftID;

    /// <summary>
    /// 对应于PBCraftInfo的PBC_Name
    /// </summary>
    private string StrCraftName;

    /// <summary>
    /// 对应于PBCraftInfo的PBC_Time
    /// </summary>
    private string StrCraftWaringDay;


    /// <summary>
    /// 对应于PBCraftInfo的PBC_PassRate
    /// </summary>
    private string StrCraftPassRate;

    /// <summary>
    /// 对应于PBCraftInfo的PBC_Parameter
    /// </summary>
    private string StrCraftParameter;

    /// <summary>
    /// 对应于PBCraftInfo的PBC_Deleted
    /// </summary>
    private string StrCraftDeleted;
    /* =======================================================================================*/


    /* ===================================属性定义区===========================================*/
    public Guid CraftID
    {
        get { return GuCraftID; }

        //要求输入的值不能为空
        set
        {
            if (value.ToString() != "")
            {
                GuCraftID = value;
            }
            else
            {
                ;//这里当输入为空的时候处理的函数还未编写
            }
        }
    }

    public string CraftName
    {
        get { return StrCraftName; }
        set
        {
            if (value != "")
            {
                StrCraftName = value;
            }
            else
            {
                ;//这里当输入为空的时候处理的函数还未编写
            }
        }
    }

    public string CraftWaringDay
    {
        get { return StrCraftWaringDay; }
        set
        {
            if (value != "")
            {
                StrCraftWaringDay = value;
            }
            else
            {
                ;//这里当输入为空的时候处理的函数还未编写
            }
        }
    }

    public string CraftPassRate
    {
        get { return StrCraftPassRate; }
        set
        {
            if (value != "")
            {
                StrCraftPassRate = value;
            }
            else
            {
                ;//这里当输入为空的时候处理的函数还未编写
            }
        }
    }

    public string CraftParameter
    {
        get { return StrCraftParameter; }
        set
        {
            if (value != "")
            {
                StrCraftParameter = value;
            }
            else
            {
                ;//这里当输入为空的时候处理的函数还未编写
            }
        }
    }

    public string CraftDeleted
    {
        get { return StrCraftDeleted; }
        set
        {
            if (value != "")
            {
                StrCraftDeleted = value;
            }
            else
            {
                ;//这里当输入为空的时候处理的函数还未编写
            }
        }
    }
    /* =======================================================================================*/


    /* ===================================方法定义区===========================================*/

    /// <summary>
    /// 函数名：ResetParameter
    /// 作用：重置这个类的成员的值
    /// 作者：bush2582
    /// </summary>
    public void ResetParameter()
    {
        GuCraftID = Guid.Empty;
        StrCraftName = "";
        StrCraftWaringDay = "0";
        StrCraftPassRate = "0";
        StrCraftParameter = "0";
        StrCraftDeleted = "0";
    }



    /// <summary>
    /// 函数名：ProcessCraftMgtInfo
    /// 作者：bush2582
    /// 作用:ProSeriesInfo_ProErrorSeriesInfo 构造函数 
    /// note：
    ///     1、CraftID:对应于表中的PBC_ID
    ///     2、CraftName:对应于表中的PBC_Name
    ///     3、CraftWaringDay:对应于表中的PBC_Time
    ///     4、CraftPassRate:对应于表中的PBC_PassRate
    ///     5、CraftParameter:对应于表中的PBC_Parameter
    ///     6、CraftDeleted:对应于表中的PBC_Deleted
    /// </summary>
    /// <param name="CraftID">工序ID</param>
    /// <param name="CraftName">工序名称</param>
    /// <param name="CraftWaringDay">预警天数</param>
    /// <param name="CraftPassRate">合格率参考标准</param>
    /// <param name="CraftParameter">工艺参数参考</param>
    /// <param name="CraftDeleted">是否删除</param>
    public ProcessCraftMgtInfo( Guid CraftID,
                                string CraftName,
                                string CraftWaringDay,
                                string CraftPassRate,
                                string CraftParameter,
                                string CraftDeleted
                              )
	{
        //初始化这个类的成员
        GuCraftID = CraftID;
        StrCraftName = CraftName;
        StrCraftWaringDay = CraftWaringDay;
        StrCraftPassRate = CraftPassRate;
        StrCraftParameter = CraftParameter;
        StrCraftDeleted = CraftDeleted;
	}
    /* =======================================================================================*/
}