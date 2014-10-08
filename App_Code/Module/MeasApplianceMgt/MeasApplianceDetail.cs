using System;

/// <summary>
///这个文件定义了一个对应于MeasApplianceDetail表的类，在这个类中用类的属性对应了表中的属性。
/// 提供了如下的属性：
///                 1、MAD_DetailID:对应于表中的MAD_DetailID
///                 2、MAM_EquipID:对应于表中的MAM_EquipID
///                 3、MAD_TestNo:对应于表中的MAD_TestNo
///                 4、MAD_TestPer:对应于表中的MAD_TestPer
///                 5、MAD_TestTime:对应于表中的MAD_TestTime
///                 6、MAD_Result:对应于表中的MAD_Result
///                 7、MAD_Remarks:对应于表中的MAD_Remarks
/// </summary>
public class MeasApplianceDetail
{
    /* =================================数据成员定义区========================================*/

    /// <summary>
    /// 对应于MeasApplianceDetail的MAD_DetailID
    /// </summary>
    private Guid GuMAD_DetailID;

    /// <summary>
    /// 对应于MeasApplianceDetail的MAM_EquipID
    /// </summary>
    private Guid GuMAM_EquipID;

    /// <summary>
    /// 对应于MeasApplianceDetail的MAD_TestNo
    /// </summary>
    private string StrMAD_TestNo;

    /// <summary>
    /// 对应于MeasApplianceDetail的MAD_TestPer
    /// </summary>
    private string StrMAD_TestPer;

    /// <summary>
    /// 对应于MeasApplianceDetail的MAD_TestTime
    /// </summary>
    private DateTime DatMAD_TestTime;

    /// <summary>
    /// 对应于MeasApplianceDetail的MAD_Result
    /// </summary>
    private string StrMAD_Result;

    /// <summary>
    /// 对应于MeasApplianceDetail的MAD_Remarks
    /// </summary>
    private string StrMAD_Remarks;
     /* =======================================================================================*/



    /* ===================================属性定义区===========================================*/
    public Guid MAD_DetailID
    {
        get { return GuMAD_DetailID; }

        //要求输入的值不能为空
        set
        {
            if (value.ToString()!="")
            {
                GuMAD_DetailID = value;
            }
            else
            {
                ;//这里当输入为空的时候处理的函数还未编写
            }
        }
    }

        public Guid MAM_EquipID
    {
        get { return GuMAM_EquipID; }

        //要求输入的值不能为空
        set
        {
            if (value.ToString()!="")
            {
                GuMAM_EquipID = value;
            }
            else
            {
                ;//这里当输入为空的时候处理的函数还未编写
            }
        }
    }
    public string MAD_TestNo
    {
        get { return StrMAD_TestNo; }
        set { StrMAD_TestNo = value;}
    }

    public string MAD_TestPer
    {
        get { return StrMAD_TestPer; }
        set { StrMAD_TestPer = value; }
    }


    public DateTime MAD_TestTime
    {
        get { return DatMAD_TestTime; }
        set { DatMAD_TestTime = value; }
    }

    public string MAD_Result
    {
        get { return StrMAD_Result; }
        set { StrMAD_Result = value; }
    }

    public string MAD_Remarks
    {
        get { return StrMAD_Remarks; }
        set { StrMAD_Remarks = value; }
    }
    /* =======================================================================================*/
    //public MeasApplianceDetail(Guid MAD_DetailID,
    //                           Guid MAM_EquipID,
    //                           string MAD_TestNo,
    //                           string MAD_TestPer, 
    //                           DateTime MAD_TestTime,
    //                           string MAD_Result,
    //                           string MAD_Remarks)
    //{
    //    GuMAD_DetailID = MAD_DetailID;
    //    GuMAM_EquipID = MAM_EquipID;
    //    StrMAD_TestNo = MAD_TestNo;
    //    StrMAD_TestPer = MAD_TestPer; 
    //    DatMAD_TestTime = MAD_TestTime;
    //    StrMAD_Result = MAD_Result;
    //    StrMAD_Remarks = MAD_Remarks;
    //}
    public MeasApplianceDetail()
    { 
    }
}