/* ==============================================================================
 * 类名称：ProSeriesInfo_ProErrorSeriesInfo 
 * 类的作用描述:将数据库中ErrorPhenomenonOption表中的属性在这个类中反应。
 * 创建人：bush2582
 * 创建时间：11/1/2013 17:05
 * 修改人：
 * 修改时间：
 * 修改备注：
 * @version 1.0
 * ==============================================================================*/
using System;

/// <summary>
/// 这个文件定义了一个对应于ErrorPhenomenonOption表的类，在这个类中用类的属性对应了表中的属性。
/// 提供了如下的属性：
///                 1、ProErrorID:对应于表中的EPO_ID
///                 2、ProErrorName:对应于表中的EPO_Name
///                 3、ProErrorWaringDay:对应于表中的EPO_WarnDays
///                 4、ProErrorDeleted:对应于表中的EPO_Deleted
/// </summary>
public class ProSeriesInfo_ProErrorSeriesInfo
{
    /* =================================数据成员定义区========================================*/

    /// <summary>
    /// 对应于ErrorPhenomenonOption的EPO_ID
    /// </summary>
    private Guid GuProErrorID;

    /// <summary>
    /// 对应于ErrorPhenomenonOption的EPO_Name
    /// </summary>
    private string StrProErrorName;

    /// <summary>
    /// 对应于ErrorPhenomenonOption的EPO_WarnDay
    /// </summary>
    private string StrProErrorWaringDay;

    /// <summary>
    /// 对应于ErrorPhenomenonOption的EPO_Deleted
    /// </summary>
    private string StrProErrorDeleted;

    /* =======================================================================================*/




    /* ===================================属性定义区===========================================*/
    public Guid ProErrorID
    {
        get { return GuProErrorID; }

        //要求输入的值不能为空
        set
        {
            if (value.ToString()!="")
            {
                GuProErrorID = value;
            }
            else
            {
                ;//这里当输入为空的时候处理的函数还未编写
            }
        }
    }

    public string ProErrorName
    {
        get { return StrProErrorName; }
        set
        {
            if (value!="")
            {
                StrProErrorName = value;
            }
            else
            {
                ;//这里当输入为空的时候处理的函数还未编写
            }
        }
    }

    public string ProErrorWaringDay
    {
        get { return StrProErrorWaringDay; }
        set
        {
            if (value != "")
            {
                StrProErrorWaringDay = value;
            }
            else
            {
                ;//这里当输入为空的时候处理的函数还未编写
            }
        }
    }

    public string ProErrorDeleted
    {
        get { return StrProErrorDeleted; }
        set
        {
            if (value != "")
            {
                StrProErrorDeleted = value;
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
    /// name:ProSeriesInfo_ProErrorSeriesInfo
    /// Author:bush2582
    /// function:ProSeriesInfo_ProErrorSeriesInfo 构造函数 
    /// </summary> 
    /// <param name="ProErrorID">异常选项的ID</param> 
    /// <param name="ProErrorName">异常选型名称</param> 
    /// <param name="ProErrorWaringDay">异常预警天数</param> 
    /// <param name="ProErrorDeleted">异常是否不被显示</param> 
	public ProSeriesInfo_ProErrorSeriesInfo(Guid ProErrorID,
                                            string ProErrorName,
                                            string ProErrorWaringDay, 
                                            string ProErrorDeleted
                                            )
	{
        //初始化这个类的成员
        GuProErrorID = ProErrorID;
        StrProErrorName = ProErrorName;
        StrProErrorWaringDay = ProErrorWaringDay;
        StrProErrorDeleted = ProErrorDeleted;

	}
    /* =======================================================================================*/
}