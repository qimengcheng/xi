using System;
using System.Data;

/// <summary>
///IClientBasic 的摘要说明
/// </summary>
public interface IClientBasic
{

    DataSet SList_CRMRegionBasicInfo();
    DataSet SList_CRMCustomerSortBasicData();
    void I_CRMRegionBasicInfo(string name, string detail);
    void U_CRMRegionBasicInfo(Guid id, string name, string detail);
    void D_CRMRegionBasicInfo(Guid id);//删除区域信息
    void I_CRMCustomerSortBasicData(string name, string detail);//新增客户类别
    void U_CRMCustomerSortBasicData(Guid id, string name, string detail);//修改客户类别
    void D_CRMCustomerSortBasicData(Guid id);//删除客户类别
    DataSet S_CRMRBI_CRMCIF(Guid id);//查询区域对应人员
    DataSet S_CRMRBISraech(string name);//查询特定区域
        DataSet S_CRMCusSort(string condition);
               void D_CRMCusSort(Guid id);
                   void I_CRMCusSort(string name,string note);
                   void U_CRMCusSort(Guid id, string name, string note);
                    DataSet S_CRMCusSort_Custome(Guid id);

        
        
}