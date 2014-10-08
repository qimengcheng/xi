using System;

/// <summary>
///ModuleOfUnit 的摘要说明
/// </summary>
namespace EntityOfCraftBasicInfoMgt
{
    public class CraftBasicInfoMgt
    {
        public CraftBasicInfoMgt()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        private Guid unitId;

        public Guid UnitID
        {
            get { return unitId; }
            set { unitId = value; }
        }

        private string unitName;

        public string UnitName
        {
            get { return unitName; }
            set { unitName = value; }
        }

        private int unDeleted;

        public int UNDeleted
        {
            get { return unDeleted; }
            set { unDeleted = value; }
        }
    }
}