using System;
using System.Data;

/// <summary>
///定义了有关的接口来访问MeasApplianceDetail,MeasApplianceMan表
/// </summary>
public interface IMeasAppliance
{
//计量器具信息管理
    //根据传入参数查找计量器具信息
    DataSet Select_MeasApplianceMan(string Condition);
    //添加计量器具信息
    int Insert_MeasApplianceMan(MeasApplianceMan MAM_Equipinfo);
    //编辑计量器具信息
    int Update_MeasApplianceMan(MeasApplianceMan MAM_Equipinfo);
    //删除计量器具信息
    int Delete_MeasApplianceMan(Guid MAM_EquipID);
    //根据ID查找计量器具信息
    DataSet SelectByID_MeasApplianceMan(Guid MAM_EquipID);
//检验结果管理
    //查找检验结果
    DataSet Select_MeasApplianceDetail(Guid MAM_EquipID);
    //添加检验结果
    int Insert_MeasApplianceDetail(MeasApplianceDetail MAD_Detailinfo);
    //编辑检验结果
    int Update_MeasApplianceDetail(MeasApplianceDetail MAD_Detailinfo);
    //删除检验结果
    int Delete_MeasApplianceDetail(Guid MAD_DetailID);
}