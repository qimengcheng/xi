using System;

/// <summary>
/// 这个文件定义了一个对应于MeasApplianceMan表的类，在这个类中用类的属性对应了表中的属性。
/// 提供了如下的属性：
///                 1、MAM_EquipID:对应于表中的MAM_EquipID
///                 2、MAM_EquipName:对应于表中的MAM_EquipName
///                 3、MAM_ManuCode:对应于表中的MAM_ManuCode
///                 4、MAM_Location:对应于表中的MAM_Location
///                 5、MAM_ToDate:对应于表中的MAM_ToDate
///                 6、MAM_OAccuracy:对应于表中的MAM_OAccuracy
///                 7、MAM_IAccuracy:对应于表中的MAM_IAccuracy
///                 8、MAM_Period:对应于表中的MAM_Period
///                 9、MAM_ToBeTestDate:对应于表中的MAM_ToBeTestDate
///                 10、MAM_RemindDays:对应于表中的MAM_RemindDays
/// </summary>
public class MeasApplianceMan
{
    /* =================================数据成员定义区========================================*/

    /// <summary>
    /// 对应于MeasApplianceMan的MAM_EquipID
    /// </summary>
    private Guid GuMAM_EquipID;

    /// <summary>
    /// 对应于MeasApplianceMan的MAM_EquipName
    /// </summary>
    private string StrMAM_EquipName;

    /// <summary>
    /// 对应于MeasApplianceMan的MAM_ManuCode
    /// </summary>
    private string StrMAM_ManuCode;

    /// <summary>
    /// 对应于MeasApplianceMan的MAM_Location
    /// </summary>
    private string StrMAM_Location;

    /// <summary>
    /// 对应于MeasApplianceMan的MAM_ToDate
    /// </summary>
    private DateTime DatMAM_ToDate;

    /// <summary>
    /// 对应于MeasApplianceMan的MAM_OAccuracy
    /// </summary>
    private string StrMAM_OAccuracy;

    /// <summary>
    /// 对应于MeasApplianceMan的MAM_IAccuracy
    /// </summary>
    private string StrMAM_IAccuracy;

    /// <summary>
    /// 对应于MeasApplianceMan的MAM_Period
    /// </summary>
    private int IntMAM_Period;

    /// <summary>
    /// 对应于MeasApplianceMan的MAM_ToBeTestDate
    /// </summary>
    private DateTime DatMAM_ToBeTestDate;

    /// <summary>
    /// 对应于MeasApplianceMan的MAM_RemindDays
    /// </summary>
    private int IntMAM_RemindDays;

    private string StrMAM_EquipType;
    private string StrMAM_ManuName;
    private string StrMAM_Isunused;
    /* =======================================================================================*/



    /* ===================================属性定义区===========================================*/
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

    public string MAM_EquipName
    {
        get { return StrMAM_EquipName; }
        set { StrMAM_EquipName = value;}
    }

    public string MAM_ManuCode
    {
        get { return StrMAM_ManuCode; }
        set { StrMAM_ManuCode = value; }
    }

    public string MAM_Location
    {
        get { return StrMAM_Location; }
        set { StrMAM_Location = value; }
    }

    public DateTime MAM_ToDate
    {
        get { return DatMAM_ToDate; }
        set { DatMAM_ToDate = value; }
    }

    public string MAM_OAccuracy
    {
        get { return StrMAM_OAccuracy; }
        set { StrMAM_OAccuracy = value; }
    }

    public string MAM_IAccuracy
    {
        get { return StrMAM_IAccuracy; }
        set { StrMAM_IAccuracy = value; }
    }

    public int MAM_Period
    {
        get { return IntMAM_Period; }
        set { IntMAM_Period = value; }
    }

    public DateTime MAM_ToBeTestDate
    {
        get { return DatMAM_ToBeTestDate; }
        set { DatMAM_ToBeTestDate = value; }
    }

    public int MAM_RemindDays
    {
        get { return IntMAM_RemindDays; }
        set { IntMAM_RemindDays = value; }
    }


    public string MAM_EquipType
    {
        get { return StrMAM_EquipType; }
        set { StrMAM_EquipType = value; }
    }
    public string MAM_ManuName
    {
        get { return StrMAM_ManuName; }
        set { StrMAM_ManuName = value; }
    }
    public string MAM_Isunused
    {
        get { return StrMAM_Isunused; }
        set { StrMAM_Isunused = value; }
    }
    /* =======================================================================================*/
    //public MeasApplianceMan(Guid MAM_EquipID,
    //                        string MAM_EquipName,
    //                        string MAM_ManuCode, 
    //                        string MAM_Location,
    //                        DateTime MAM_ToDate,
    //                        string MAM_OAccuracy,
    //                        string MAM_IAccuracy,
    //                        int MAM_Period,
    //                        DateTime MAM_ToBeTestDate,
    //                        int MAM_RemindDays
    //                        )	
    //{
    //    GuMAM_EquipID = MAM_EquipID;
    //    StrMAM_EquipName = MAM_EquipName;
    //    StrMAM_ManuCode = MAM_ManuCode; 
    //    StrMAM_Location = MAM_Location;
    //    DatMAM_ToDate = MAM_ToDate;
    //    StrMAM_OAccuracy = MAM_OAccuracy;
    //    StrMAM_IAccuracy = MAM_IAccuracy;
    //    IntMAM_Period = MAM_Period;
    //    DatMAM_ToBeTestDate = MAM_ToBeTestDate;
    //    IntMAM_RemindDays = MAM_RemindDays;
    //}
    public MeasApplianceMan(
                            )
    {
       
    }
}