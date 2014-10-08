using System;
using System.Data;

/// <summary>
///ProStoreBasic 的摘要说明
/// </summary>
public class ProStoreBasic
{
    private static readonly IStoreBasic IMssd = DALFactory.StoreBasic();
    
    
    public ProStoreBasic()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    public DataSet SList_StoreBasic()//检索所有出入库类别
    {

        return IMssd.SList_Imssd();

    }
    public DataSet SList_IMssd_in_out(string IN,string OUT)//检索出，入库系列
    {

        return IMssd.I_IMssd_IN_OUT(IN ,OUT);

    }

    public DataSet SList_Istore()//检索所有库房
    {

        return IMssd.SList_Istore();

    }

    public void U_IMssd(StoreBasicInfo storebasicinfo)//编辑出入库系列detail
    {
         IMssd.U_IMssd(storebasicinfo);
    }

    public void I_IMssd(StoreBasicInfo storebasicinfo)//新增入库类型
    {
        IMssd.I_IMssd(storebasicinfo);
    }

    public void I_IMssdOut(StoreBasicInfo storebasicinfo)//新增出库类型
    {
        IMssd.I_IMssdOut(storebasicinfo);
    }


    public DataSet SList_IMssd_Name(string SortNAME)//检索是否存在新增出入库类型
    {

        return IMssd.SList_Imssd_Name(SortNAME);

    }
    public void D_IMssd(Guid IMssd_id)//删除出入库类别
    {
      IMssd.D_IMssd(IMssd_id);
    }
    public DataSet SList_User_IMstore()//检索库房管理人员信息
    {
        return IMssd.SList_User_IMstore();
    }

    public DataSet SList_DROP_Depart()//绑定管理部门下拉
    {
        return IMssd.SList_DROP_Depart();
    }

    public void I_IMstore_new(StoreBasicInfo storebasicinfo)//新增库房
    {
        IMssd.I_IMstore_new(storebasicinfo);
    }

    public DataSet SList_Imstore_Name(string IMS_StoreName)//检索是否存在库房
    {
        return IMssd.SList_Imstore_Name(IMS_StoreName);
    }
    public void U_IMstore(StoreBasicInfo storebasicinfo)//更新库房
    {
        IMssd.U_IMstore(storebasicinfo);
    }

    public DataSet SList_ImstoreManger(string condition)//检索库房管理人员
    {
        return IMssd.SList_ImstoreManger(condition);
    }
    public void D_IMstore(Guid IMS_Storeid)//删除出入库类别
    {
        IMssd.D_IMstore(IMS_Storeid);
    }
    public DataSet S_STOREareal(Guid guid_id)//检索区域
    {
        return IMssd.S_STOREareal(guid_id);
    }
    public void I_IMstoreAreal(StoreBasicInfo storebasicinfo)//新增区域
    {
        IMssd.I_IMstoreAreal(storebasicinfo);
    }
    public void D_IMstore_Areal(Guid IMSA_AreaID)//删除区域
    {
        IMssd.D_IMstore_Areal(IMSA_AreaID);
    }
    public void U_IMstore_Areal(StoreBasicInfo storebasicinfo)//更新区域
    {
        IMssd.U_IMstore_Areal(storebasicinfo);
    }
    public DataSet SList_Imstore_ArealName(string IMS_StoreArealName,Guid IMSTORE_ID)//检索是否存在区域
    {
        return IMssd.SList_Imstore_ArealName(IMS_StoreArealName,IMSTORE_ID);
    }
}