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
using System.Collections.Generic;
using System.Collections;

/// <summary>
/// 这个文件具体给出了页面的业务逻辑的处理方法。
/// </summary>
public class ProSeriesInfo_ProErrorTypeL:BLLMatchNumber
{
   
    /* ===================================数据成员定义区=========================================*/
   
 
    //工厂模式，创建一个数据DAL用来访问数据库
    private static readonly IProSeriesInfo_ProErrorType mProSeriesInfo_ProErrorType = DALFactory.CreateProSeriesInfo_ProErrorType();

    /* =======================================================================================*/

    /* ===================================方法定义区===========================================*/


    /// <summary> 
    /// 函数名:ProSeriesInfo_ProErrorTypeL
    /// 作者:bush2582
    /// 作用:构造函数
    /// </summary> 
	public ProSeriesInfo_ProErrorTypeL()
	{
	}

    /// <summary> 
    /// 函数名:ProSeriesInfo_ProErrorTypeL
    /// 作者:bush2582
    /// 作用:通过调用数据访问层函数，返回所有的异常选项 即select all
    /// </summary> 
    public DataSet SList_ProErrorSeries()
    {
        return mProSeriesInfo_ProErrorType.SList_ProErrorSeries();
    }

    /// <summary> 
    /// 函数名:UpData_ProErrorSeriesInfo
    /// 作者:bush2582
    /// 作用:通过调用数据访问层函数，更新异常的记录
    /// <param name="UpdataInfo">要被更新的记录</param>
    /// <returns>返回值：bool</returns>
    /// </summary> 
    public bool UpData_ProErrorSeriesInfo(ProSeriesInfo_ProErrorSeriesInfo UpdataInfo)
    {
        if (base.IsMatchInt(UpdataInfo.ProErrorWaringDay,0)==false || UpdataInfo.ProErrorName =="")//判断当前的预警天数和异常名称是否是符合条件的
        {
            return false;
        }
        else if (mProSeriesInfo_ProErrorType.S_ErrorSeriesAccurate(UpdataInfo).Tables[0].Rows.Count > 0)//防止重名
        {
            return false;
        }
        else
        {
            //调用DAL更新数据库的数据
            mProSeriesInfo_ProErrorType.U_ProErrorSeriesName(UpdataInfo);
            mProSeriesInfo_ProErrorType.U_ProErrorSeriesWarnDays(UpdataInfo);
            return true;
        }
        
    }

    /// <summary>
    /// 函数名：DeleteErrorOption
    /// 作者：bush2582
    /// 作用：删除一个异常选项的记录
    /// </summary>
    /// <param name="UpdataInfo">要被删除的记录</param>
    /// <returns>成功返回真，错误返回假</returns>
    public bool DeleteErrorOption(ProSeriesInfo_ProErrorSeriesInfo UpdataInfo)
    {
        if (mProSeriesInfo_ProErrorType.D_ProErrorSeries(UpdataInfo.ProErrorID))
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// 函数名：S_SearchErrorOption
    /// 作用：模糊查询需要的信息
    /// 作者：bush2582
    /// </summary>
    /// <param name="Info_Search">需要被检索的异常的信息</param>
    /// <returns>记录集</returns>
    public DataSet S_SearchErrorOption(string Info_Search)
    {
        return mProSeriesInfo_ProErrorType.S_ProErrorSeries(Info_Search);
    }

    /// <summary>
    /// 函数名：I_ErrorOption
    /// 作用：插入一条新的异常选项
    /// 作者：bush2582
    /// </summary>
    /// <param name="InsertInfo">需要被插入的异常的信息</param>
    /// <returns>是否成功</returns>
    public bool I_ErrorOption(ProSeriesInfo_ProErrorSeriesInfo InsertInfo)
    {
        if (InsertInfo.ProErrorName == "" ||base.IsMatchInt(InsertInfo.ProErrorWaringDay,0)==false)//检查异常预警天数和异常名称是否符合条件
        {
            return false;
        }
        else if (mProSeriesInfo_ProErrorType.S_ErrorSeriesAccurate(InsertInfo).Tables[0].Rows.Count > 0)//防止重名
        {
            return false;
        }
        else
        {
            mProSeriesInfo_ProErrorType.I_ProErrorSeries(InsertInfo);
            return true;
        }
        
    }
    /* =======================================================================================*/
}