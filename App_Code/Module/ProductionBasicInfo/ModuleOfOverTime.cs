using System;

/// <summary>
///ModuleOfOverTime 的摘要说明
/// </summary>
namespace EntityOfOverTime
{
    public class ModuleOfOverTime
    {
        public ModuleOfOverTime()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        private Guid otoId;

        public Guid OtoID
        {
            get { return otoId; }
            set { otoId = value; }
        }

        private string otoName;

        public string OtoName
        {
            get { return otoName; }
            set { otoName = value; }
        }

        private int otoDeleted;

        public int OtoDeleted
        {
            get { return otoDeleted; }
            set { otoDeleted = value; }
        }


    }
}