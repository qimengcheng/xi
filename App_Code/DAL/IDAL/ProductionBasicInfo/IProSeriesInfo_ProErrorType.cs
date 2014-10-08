/* ==============================================================================
 * 类名称：IProSeriesInfo_ProErrorType 
 * 类的作用描述:提供一个访问数据库share1023表中的ErrorPhenomenonOption的接口类
 * 创建人：bush2582
 * 创建时间：11/1/2013 16:18
 * 修改人：
 * 修改时间：
 * 修改备注：
 * @version 1.0
 * ==============================================================================*/
using System;
using System.Data;

///<summary>
///这个文件提供了一个接口类，定义了有关的接口来访问ErrorPhenomenonOption表。其中定义的函数有
///1、SList_ProErrorSeries();作用:罗列出所有的异常原因选项
///2、I_ProErrorSeries(ProSeriesInfo_ProErrorSeriesInfo InfoWantInert);作用:插入一条新的记录，在表ErrorPhenomenonOption中
///3、S_ProErrorSeries(string InfoWantToSearch);作用:根据传入的参数，模糊查询表ErrorPhenomenonOption中的记录
///4、U_ProErrorSeries(ProSeriesInfo_ProErrorSeriesInfo InfoWantUpdata);作用:根据传入的参数，更新表ErrorPhenomenonOption中指定的记录
///5、bool D_ProErrorSeries(Guid ProErrorSeriesID);作用:根据传入的ID，将表ErrorPhenomenonOption中指定的记录的Delet属性置位，使其不再被检索或则查询出来
///</summary>
public interface IProSeriesInfo_ProErrorType
{

    /* ==================================================================
     * 函数名：SList_ProErrorSeries 
     * 作者： bush2582
     * 日期： 11.1
     * 功能： 罗列出所有的异常原因选项
     * 输入参数：无
     * 返回值： DataSet
     * 修改记录：
     * ==================================================================*/
    DataSet SList_ProErrorSeries();

    /* ==================================================================
     * 函数名：I_ProErrorSeries 
     * 作者： bush2582
     * 日期： 11.2
     * 功能： 插入一条新的记录，在表ErrorPhenomenonOption中
     * 输入参数：
     *          1、ProSeriesInfo_ProErrorSeriesInfo InfoWantInert:需要被插入的记录的对应的类
     * 返回值：bool值是否成功
     * 修改记录：
     *==================================================================*/
    bool I_ProErrorSeries(ProSeriesInfo_ProErrorSeriesInfo InfoWantInert);

    /* ==================================================================
     * 函数名：S_ProErrorSeries 
     * 作者： bush2582
     * 日期： 11.2
     * 功能： 根据传入的参数，模糊查询表ErrorPhenomenonOption中的记录
     * 输入参数：
     *          1、string InfoWantToSearch:需要检索的信息
     * 返回值：DataSet
     * 修改记录：
     *==================================================================*/
    DataSet S_ProErrorSeries(string InfoWantToSearch);

    /* ==================================================================
     * 函数名：U_ProErrorSeriesWarnDays 
     * 作者： bush2582
     * 日期： 11.17
     * 功能： 根据传入的参数，更新表ErrorPhenomenonOption中指定的记录的预警天数
     * 输入参数：
     *          1、ProSeriesInfo_ProErrorSeriesInfo InfoWantUpdata:需要被更新到数据库中的信息
     * 返回值：是否成功
     * 修改记录：
     *==================================================================*/
    bool U_ProErrorSeriesWarnDays(ProSeriesInfo_ProErrorSeriesInfo InfoWantUpdata);

    /* ==================================================================
     * 函数名：U_ProErrorSeriesName 
     * 作者： bush2582
     * 日期： 11.17
     * 功能： 根据传入的参数，更新表ErrorPhenomenonOption中指定的记录的名称
     * 输入参数：
     *          1、ProSeriesInfo_ProErrorSeriesInfo InfoWantUpdata:需要被更新到数据库中的信息
     * 返回值：是否成功
     * 修改记录：
     *==================================================================*/
    bool U_ProErrorSeriesName(ProSeriesInfo_ProErrorSeriesInfo InfoWantUpdata);

    /* ==================================================================
     * 函数名：D_ProErrorSeries 
     * 作者： bush2582
     * 日期： 11.2
     * 功能： 根据传入的ID，将表ErrorPhenomenonOption中指定的记录的Delet属性置位，使其不再被检索或则查询出来
     * 输入参数：
     *          1、Guid ProErrorSeriesID:需要被操作的记录的ID
     * 返回值：是否成功
     * 修改记录：
     *==================================================================*/
    bool D_ProErrorSeries(Guid ProErrorSeriesID);


    /* ==================================================================
     * 函数名：S_ErrorSeriesAccurate 
     * 作者： bush2582
     * 日期： 11.2
     * 功能： 根据传入的参数，精确查询表ErrorPhenomenonOption中的记录
     * 输入参数：
     *          1、ProSeriesInfo_ProErrorSeriesInfo InfoWantToSearch:需要检索的信息
     * 返回值：DataSet
     * 修改记录：
     *==================================================================*/
    DataSet S_ErrorSeriesAccurate(ProSeriesInfo_ProErrorSeriesInfo InfoWantToSearch);
}