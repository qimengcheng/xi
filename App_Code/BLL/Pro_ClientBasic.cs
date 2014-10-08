using System;
using System.Data;

/// <summary>
///ClientBasic 的摘要说明
/// </summary>
public class Pro_ClientBasic
{
    private static readonly IClientBasic IClient = DALFactory.ClientBasic();
    
    
    public Pro_ClientBasic()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    public DataSet SList_CRMRegionBasicInfo()//检索所有出入库类别
    {

        return IClient.SList_CRMRegionBasicInfo();

    }

    public DataSet SList_CRMCustomerSortBasicData()//检索所有出入库类别
    {

        return IClient.SList_CRMCustomerSortBasicData();

    }

    public void I_CRMRegionBasicInfo(string name, string detail)//新增区域信息
    {
         IClient.I_CRMRegionBasicInfo(name, detail);

    }

    public void U_CRMRegionBasicInfo(Guid id, string name, string detail)//修改区域信息
    {
        IClient.U_CRMRegionBasicInfo(id, name, detail);
    }
    public void D_CRMRegionBasicInfo(Guid id)//删除区域信息
    {
        IClient.D_CRMRegionBasicInfo(id);
    }
    public void I_CRMCustomerSortBasicData(string name, string detail)//新增客户类别
    {
        IClient.I_CRMCustomerSortBasicData(name, detail);
    }
    public void U_CRMCustomerSortBasicData(Guid id, string name, string detail)//修改客户类别
    {
        IClient.U_CRMCustomerSortBasicData(id, name, detail);
    }
    public void D_CRMCustomerSortBasicData(Guid id)//删除客户类别
    {
        IClient.D_CRMCustomerSortBasicData(id);
    }
    public DataSet S_CRMRBI_CRMCIF(Guid id)//查询区域对应人员
    {
        return IClient.S_CRMRBI_CRMCIF(id);
    }
    public DataSet S_CRMRBISraech(string name)//查询特定区域
    {
        return IClient.S_CRMRBISraech(name);
    }
       public DataSet S_CRMCusSort(string condition)
       {
        return IClient.S_CRMCusSort(condition);
       }
              public void D_CRMCusSort(Guid id)
              {
                IClient.D_CRMCusSort(id);
              }
                  public void I_CRMCusSort(string name,string note)
                  {
                  IClient.I_CRMCusSort(name,note);
                  }
                  public void U_CRMCusSort(Guid id, string name, string note)
                  {
                      IClient.U_CRMCusSort(id, name, note);
                  }
                  public DataSet S_CRMCusSort_Custome(Guid id)
                  {
                      return IClient.S_CRMCusSort_Custome(id);
                  }
}