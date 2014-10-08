using System;
using System.Data;
using DALOverTime;
using EntityOfOverTime;
/// <summary>
///OverTimeOption 的摘要说明
/// </summary>
namespace BLLOverTime
{
    public class OverTimeOption
    {
        public OverTimeOption()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
/// <summary>
/// 函数名:BindOverTime
/// 作用:绑定超时原因选项
/// 作者:开济
/// </summary>
/// <returns>超时原因选项数据</returns>
        public static DataSet BindOverTime()//
        {
            return new DOverTimeOption().DisplayOverTime();   
        }
/// <summary>
/// 函数名:UpdateOverTime
/// 作用:更新超时原因选项
/// 作者:开济
/// </summary>
/// <param name="info">超时原因选项更新信息</param>
/// <returns>更新成功与否</returns>
        public static bool UpdateOverTime(ModuleOfOverTime info)
        {
            return new DOverTimeOption().UpdateOverTime(info); 
        }
/// <summary>
/// 函数名:DeleteOverTime
/// 作用:删除超时原因选项
/// 作者:开济
/// </summary>
/// <param name="id">超时原因选项id</param>
/// <returns>删除成功与否</returns>
        public static bool DeleteOverTime(Guid id)
        {
            return new DOverTimeOption().DeleteOverTime(id);
        }
/// <summary>
/// 函数名:AddOverTime
/// 作用:添加超时原因选项
/// 作者:开济
/// </summary>
/// <param name="name">添加超时原因选项</param>
/// <returns>添加成功与否</returns>
        public static bool AddOverTime(string name)
        {
            return new DOverTimeOption().NewOverTime(name);
        }
/// <summary>
/// 函数名:SearchOverTime
/// 作用:搜索超时原因选项
/// 作者:开济
/// </summary>
/// <param name="name">超时原因选项</param>
/// <returns>超时原因选项数据</returns>
        public static DataSet SearchOverTime(string name)
        {
            return new DOverTimeOption().SearchOverTime(name);
        }
/// <summary>
/// 函数名:SearchSameOverTime
/// 作用:搜索同名超时原因选项
/// 作者:开济
/// </summary>
/// <param name="name">新增超时的原因选项</param>
/// <returns>是否有同名的超时原因选项</returns>
        public static bool SearchSameOverTime(string name)
        {
            DOverTimeOption overTime = new DOverTimeOption();
            DataSet set = new DataSet();
            set = overTime.SearchSameOverTime(name);
            if (set.Tables[0].Rows.Count == 0)
            {
                return true;
            }
            else
            {
                return false;            
            }
        }



        //详细
        public static DataSet S_OverTimeOptionDetail(string OTO_ID, string condition)//查询选项详细项目
        {
            return new DOverTimeOption().S_OverTimeOptionDetail( OTO_ID, condition);
        }
        public static void U_OverTimeOptionDetail(Guid OTOD_ID, string OTOD_Name, Guid PBC_ID)//编辑选项详细项目
        {
            new DOverTimeOption().U_OverTimeOptionDetail(OTOD_ID, OTOD_Name, PBC_ID);
        }
        public static void I_OverTimeOptionDetail(Guid OTO_ID, string OTOD_Name, Guid PBC_ID)//新建选项详细项目
        {
            new DOverTimeOption().I_OverTimeOptionDetail( OTO_ID, OTOD_Name, PBC_ID);
        }
        public static void D_OverTimeOptionDetail(Guid OTOD_ID)//删除选项详细项目
        {
            new DOverTimeOption().D_OverTimeOptionDetail( OTOD_ID);
        }
    }

}