using System;
using System.Data;
using DALCraftBasicInfoMgt;
using EntityOfCraftBasicInfoMgt;
/// <summary>
///BLLBasicInfo 的摘要说明
/// </summary>
namespace BLLCraftBasicInfo
{
    public class BLLCraftBasicInfoMgt
    {
        public BLLCraftBasicInfoMgt()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        /// <summary>
        /// 函数名:BindUnit
        /// 作用:绑定用量单位
        /// 作者:开济
        /// </summary>
        /// <returns>用量单位数据</returns>
        public static DataSet BindUnit()//
        {
            return new DCraftBasicInfoMgt().DisplayUnit();
        }
        /// <summary>
        /// 函数名:UpdateUnit
        /// 作用:更新用量单位
        /// 作者:开济
        /// </summary>
        /// <param name="info">用量单位更新信息</param>
        /// <returns>更新成功与否</returns>
        public static bool UpdateUnit(CraftBasicInfoMgt info)
        {
            return new DCraftBasicInfoMgt().UpdateUnit(info);
        }
        /// <summary>
        /// 函数名:DeleteUnit
        /// 作用:删除用量单位
        /// 作者:开济
        /// </summary>
        /// <param name="id">用量单位id</param>
        /// <returns>删除成功与否</returns>
        public static bool DeleteUnit(Guid id)
        {
            return new DCraftBasicInfoMgt().DeleteUnit(id);
        }
        /// <summary>
        /// 函数名:AddUnit
        /// 作用:新增用量单位
        /// 作者:开济
        /// </summary>
        /// <param name="name">添加用量单位</param>
        /// <returns>添加成功与否</returns>
        public static bool AddUnit(string name)
        {
            return new DCraftBasicInfoMgt().NewUnit(name);
        }
        /// <summary>
        /// 函数名:SearchUnit
        /// 作用:搜索用量单位
        /// 作者:开济
        /// </summary>
        /// <param name="name">用量单位搜索字符</param>
        /// <returns>用量单位数据</returns>
        public static DataSet SearchUnit(string name)
        {
            return new DCraftBasicInfoMgt().SearchUnit(name);
        }
        /// <summary>
        /// 函数名:SearchSameUnit
        /// 作用:搜索同名用量单位
        /// 作者:开济
        /// </summary>
        /// <param name="name">新增用量单位</param>
        /// <returns>是否有同名的用量单位</returns>
        public static bool SearchSameUnit(string name)
        {
            DCraftBasicInfoMgt basicInfo = new DCraftBasicInfoMgt();
            DataSet set = new DataSet();
            set = basicInfo.SearchSameUnit(name);
            if (set.Tables[0].Rows.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}