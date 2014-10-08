/* ==============================================================================
 * 类名称：Process_BadProductTypeInfo 
 * 类的作用描述:将数据库中BadProductType表中的属性在这个类中反应。
 * 创建人：bush2582
 * 创建时间：1/16/2014 17:04
 * 修改人：
 * 修改时间：
 * 修改备注：
 * @version 1.0
 * ==============================================================================*/
using System;

/// <summary>
/// 这个文件定义了一个对应于BadProductType表的类，在这个类中用类的属性对应了表中的属性。
/// 提供了如下的属性：
///                 1、CraftID:对应于表中的PBC_ID
///                 2、BadProductID：对应于表中的BPT_ID
///                 2、BadProductName:对应于表中的BPT_Name
///                 3、BadProductBLevel:对应于表中的BPT_BLevel
///                 4、BadProductDeleted:对应于表中的BPT_Deleted
/// </summary>
public class Process_BadProductTypeInfo
{
    /* =================================数据成员定义区========================================*/

    /// <summary>
    /// 对应于BadProductType的PBC_ID
    /// </summary>
    private Guid GuCraftID;

    /// <summary>
    /// 对应于BadProductType的PBC_ID
    /// </summary>
    private Guid GuBadProductID;

    /// <summary>
    /// 对应于BadProductType的BPT_Name
    /// </summary>
    private string StrBadProductName;

    /// <summary>
    /// 对应于BadProductType的BPT_BLevel
    /// </summary>
    private string StrBadProductBLevel;

    /// <summary>
    /// 对应于BadProductType的BPT_Deleted
    /// </summary>
    private string StrBadProductDeleted;
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

    public Guid BadProductID
    {
        get { return GuBadProductID; }

        //要求输入的值不能为空
        set
        {
            if (value.ToString() != "")
            {
                GuBadProductID = value;
            }
            else
            {
                ;//这里当输入为空的时候处理的函数还未编写
            }
        }
    }

    public string BadProductName
    {
        get { return StrBadProductName; }
        set
        {
            if (value != "")
            {
                StrBadProductName = value;
            }
            else
            {
                ;//这里当输入为空的时候处理的函数还未编写
            }
        }
    }

    public string BadProductBLevel
    {
        get { return StrBadProductBLevel; }
        set
        {
            if (value != "")
            {
                StrBadProductBLevel = value;
            }
            else
            {
                ;//这里当输入为空的时候处理的函数还未编写
            }
        }
    }

    public string BadProductDeleted
    {
        get { return StrBadProductBLevel; }
        set
        {
            if (value != "")
            {
                StrBadProductBLevel = value;
            }
            else
            {
                ;//这里当输入为空的时候处理的函数还未编写
            }
        }
    }

    /// <summary>
    /// 函数名：ResetParameter
    /// 作用：重置这个类的成员的值
    /// 作者：bush2582
    /// </summary>
    public void ResetParameter()
    {
        GuCraftID = Guid.Empty; ;
        GuBadProductID = Guid.Empty; ;
        StrBadProductName = "";
        StrBadProductBLevel = "";
        StrBadProductDeleted ="";
    }


    /// <summary>
    /// 函数名：Process_BadProductTypeInfo
    /// 作者：bush2582
    /// 作用:Process_BadProductTypeInfo 构造函数 
    /// note：
    ///     1、CraftID:对应于表中的PBC_ID
    ///     2、BadProductID:对应于表中的PBC_ID
    ///     3、BadProductName:对应于表中的BPT_Name
    ///     4、BadProductBLevel:对应于表中的BPT_BLevel
    ///     5、BadProductDeleted:对应于表中的BPT_Deleted
    /// </summary>
    /// <param name="CraftID">工序ID</param>
    /// <param name="BadProductID">不良品ID</param>
    /// <param name="BadProductName">不良品名称</param>
    /// <param name="BadProductBLevel">严重程度</param>
    /// <param name="BadProductDeleted">是否删除</param>
	public Process_BadProductTypeInfo(  Guid CraftID,
                                        Guid BadProductID,
                                        string BadProductName,
                                        string BadProductBLevel,
                                        string BadProductDeleted
                                        )
	{
        GuCraftID = CraftID;
        GuBadProductID = BadProductID;
        StrBadProductName = BadProductBLevel;
        StrBadProductBLevel = BadProductBLevel;
        StrBadProductDeleted = BadProductDeleted;
	}

    /* =======================================================================================*/
}