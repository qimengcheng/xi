using System;
using System.Data;

/// <summary>
///IStoreBasic 的摘要说明
/// </summary>
public interface IStoreBasic
{
    DataSet SList_Imssd();//查询全部出入库类别
    DataSet I_IMssd_IN_OUT(string IN, string OUT);//检索出入库类别
    DataSet SList_Istore();//查询全部库房
    void U_IMssd(StoreBasicInfo storebasicinfo);//更新出入库类别detail
    void I_IMssd(StoreBasicInfo storebasicinfo);//新增入库类别
    void I_IMssdOut(StoreBasicInfo storebasicinfo);//新增出库类别
    DataSet SList_Imssd_Name(string SortName);//查询是否存在新增入库
    void D_IMssd(Guid IMssd_id);//删除出入库类别
    DataSet SList_User_IMstore();//检索库房管理人员信息
    DataSet SList_DROP_Depart();//绑定管理部门下拉
    void I_IMstore_new(StoreBasicInfo storebasicinfo);//新增库房
    DataSet SList_Imstore_Name(string IMS_StoreName);//检查是否存在相同库房名称
    void U_IMstore(StoreBasicInfo storebasicinfo);//更新库房
    DataSet SList_ImstoreManger(string condition);//检索库房管理人员
    void D_IMstore(Guid IMS_Storeid);//删除出入库类别
    DataSet S_STOREareal(Guid guid_id);//检索区域  
    void I_IMstoreAreal(StoreBasicInfo storebasicinfo);//新增区域
    void D_IMstore_Areal(Guid IMSA_AreaID);//删除区域
    void U_IMstore_Areal(StoreBasicInfo storebasicinfo);//更新区域
    DataSet SList_Imstore_ArealName(string IMS_StoreArealName, Guid IMSTORE_ID);//检索是否存在区域
    
        
     
        
       
          
}