/* ==============================================================================
 * 类名称：Process_BadProductTypeL 
 * 类的作用描述:BLL层的类，封装了底层有关于数据库访问类的,主要负责对当前的页面的请求进行逻辑处理
 * 创建人：bush2582
 * 创建时间：1/17/2014 10:26
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
public class Process_BadProductTypeL:BLLMatchNumber
{
    /* ===================================数据成员定义区=========================================*/
    private static readonly IProcess_BadProductTypeInfo mProcess_BadProductTypeInfo = DALFactory.CreateIProcess_BadProductTypeInfo();
    /* =======================================================================================*/

    /* ===================================方法定义区===========================================*/

    /// <summary>
    /// 函数名：SList_BadProductTypeInfo
    /// 作者：bush2582
    /// 作用：罗列出所有的不良品记录
    /// </summary>
    /// <param name="InfoWantSearch">需要被检索的信息</param>
    /// <returns>记录集</returns>
    public DataSet SList_BadProduct(Process_BadProductTypeInfo InfoWantSearch)
    {
        return mProcess_BadProductTypeInfo.SList_BadProductTypeInfo(InfoWantSearch);
    }

    /// <summary>
    /// 函数名：I_BadProduct
    /// 作者：bush2582
    /// 作用：添加一条记录到数据库中
    /// 返回值：是否插入成功 可能因为不良品的名称一样，不能插入导致失败
    /// </summary>
    /// <param name="InfoWantInert"></param>
    /// <returns></returns>
    public bool I_BadProduct(Process_BadProductTypeInfo InfoWantInsert)
    {
        if (InfoWantInsert.BadProductName=="")//如果不良品名称为空返回错误
        {
            return false;
        }
        else if (InfoWantInsert.BadProductBLevel=="")//如果严重程度为空，返回错误
        {
            return false;
        }
        else if (mProcess_BadProductTypeInfo.I_BadProductTypeInfo(InfoWantInsert)==false)//如果数据库中已有重名的不良品类型，返回错误
        {
            return false;
        }
        else
        {
            return true;
        }

    }

    /// <summary>
    /// 函数名：U_BadProductTypeInfo
    /// 作者：bush2582
    /// 作用：根据传入的参数，更新表BadProductTypeInfo中指定的记录
    /// 返回是否成功
    /// 日期：2014年1月17号
    /// </summary>
    /// <param name="InfoWantUpdata">要被更新的信息</param>
    /// <returns></returns>
    public bool U_BadProductTypeInfo(Process_BadProductTypeInfo InfoWantUpdata)
    {
        if (InfoWantUpdata.BadProductName=="")//如果不良品名称为空
        {
            return false;
        }
        else if (InfoWantUpdata.BadProductBLevel=="")//如果不良品的严重程度为空
        {
            return false;
        }
        else if (mProcess_BadProductTypeInfo.S_BadProductTypeInfo(InfoWantUpdata,"2").Tables[0].Rows.Count>0)//如果数据库中已存在相同的不良品名字
        {
            return false;
        }
        else
        {
            mProcess_BadProductTypeInfo.U_BadProductTypeInfo(InfoWantUpdata);//更新数据
            return true;
        }
    }

    /// <summary>
    /// 函数名：D_BadProductTypeInfo
    /// 作者：bush2582
    /// 作用：删除数据库中的一条不良品记录
    /// 返回是否成功
    /// </summary>
    /// <param name="BadProductID"></param>
    /// <returns></returns>
    public bool D_BadProductTypeInfo(Guid BadProductID)
    {
        return mProcess_BadProductTypeInfo.D_BadProductTypeInfo(BadProductID);
    }
	public Process_BadProductTypeL()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    /* =======================================================================================*/
}