/* ==============================================================================
 * 类名称：IProcessCraftMgt 
 * 类的作用描述:提供一个访问数据库share1023表中的PBCraftInfo的接口类
 * 创建人：bush2582
 * 创建时间：1/14/2013 22:51
 * 修改人：
 * 修改时间：
 * 修改备注：
 * @version 1.0
 * ==============================================================================*/
using System;
using System.Data;

///<summary>
///这个文件提供了一个接口类，定义了有关的接口来访问PBCraftInfo表。其中定义的函数有
///1、DataSet SList_Craft();作用:罗列出所有的工序
///2、bool I_Craft(ProcessCraftMgtInfo InfoWantInert);作用:插入一条新的记录，在表PBCraftInfo中
///3、DataSet S_Craft(string InfoWantToSearch,int condition);作用:根据传入的参数，模糊查询表PBCraftInfo中的记录
///4、bool U_Craft(ProcessCraftMgtInfo InfoWantUpdata);作用:根据传入的参数，更新表PBCraftInfo中指定的记录
///5、bool D_Craft(Guid CraftID);作用:根据传入的ID，将表PBCraftInfo中指定的记录的Delet属性置位，使其不再被检索或则查询出来
///</summary>
public interface IProcessCraftMgt
{
    /* ==================================================================
     * 函数名：SList_Craft 
     * 作者： bush2582
     * 日期： 1.14
     * 功能： 罗列出所有的工序
     * 输入参数：无
     * 返回值： DataSet
     * 修改记录：
     * ==================================================================*/
    DataSet SList_Craft();

    /* ==================================================================
     * 函数名：I_Craft 
     * 作者： bush2582
     * 日期： 1.14
     * 功能： 插入一条新的记录，在表PBCraftInfo中
     * 输入参数：
     *          1、ProcessCraftMgtInfo InfoWantInert：要被插入的信息
     * 返回值： bool 查看是否插入成功
     * 修改记录：
     * ==================================================================*/
    bool I_Craft(ProcessCraftMgtInfo InfoWantInert);

    /* ==================================================================
     * 函数名：S_Craft 
     * 作者： bush2582
     * 日期： 1.14
     * 功能： 根据传入的参数，模糊查询表PBCraftInfo中的记录
     * 输入参数：
     *          1、string InfoWantToSearch：搜索的条件
     *          2、string condition：指定搜索的模式
     * 返回值： DataSet 返回查询的记录集
     * 修改记录：
     * ==================================================================*/
    DataSet S_Craft(ProcessCraftMgtInfo InfoWantToSearch, string condition);

    /* ==================================================================
     * 函数名：U_Craft 
     * 作者： bush2582
     * 日期： 1.14
     * 功能： 根据传入的参数，更新表PBCraftInfo中指定的记录
     * 输入参数：
     *          1、ProcessCraftMgtInfo InfoWantUpdata：要被更新的信息
     * 返回值： bool 查看更新是否成功
     * 修改记录：
     * ==================================================================*/
    bool U_Craft(ProcessCraftMgtInfo InfoWantUpdata);

    /* ==================================================================
     * 函数名：D_Craft 
     * 作者： bush2582
     * 日期： 1.14
     * 功能： 根据传入的ID，将表PBCraftInfo中指定的记录的Delet属性置位，使其不再被检索或则查询出来
     * 输入参数：
     *          1、Guid CraftID：要被删除的信息的ID
     * 返回值： bool 查看更新是否成功
     * 修改记录：
     * ==================================================================*/
    bool D_Craft(Guid CraftID);
	
}