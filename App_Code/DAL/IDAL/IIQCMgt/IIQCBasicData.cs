using System;
using System.Collections.Generic;
using System.Data;


/// <summary>
///IIQCBasicData 的摘要说明
/// </summary>
public interface IIQCBasicData
{
    //模糊查询物料基础信息用于维护进料检验
    DataSet Search_IMMaterialBasicData_IQC(string Condition);

     //新增物料到进料检验
    int Insert_IMMaterialBasicData_IQC(Guid IMMBD_MaterialID);

     //从进料检验删除物料
     int Delete_IMMaterialBasicData_IQC(Guid IMMBD_MaterialID);

    //查询进料检验物料的检验项目Grid
     DataSet Search_IQCItemsTable(Guid IMMBD_MaterialID);

     //查询进料检验物料的检验项目（by 项目ID）用于编辑
     IList<IQCBasicDataInfo> Search_IQCItemsTable_ID(Guid IQCIT_ID);

    //模糊查询进料检验物料的检验项目Grid
     DataSet Search_IQCItemsTable_M(string Condition);

     //新增进料检验物料的检验项目
     int Insert_IQCItemsTable(IQCBasicDataInfo A);

    //修改进料检验物料的检验项目
     int Update_IQCItemsTable(IQCBasicDataInfo A);

    //删除进料检验的检验项目
     int Delete_IQCItemsTable(Guid IQCIT_ID);

    //查询进料检验的检验项目的检验标准
     DataSet Search_IQCStandardTable(Guid IQCIT_ID);

     //查询进料检验的检验项目的检验标准用于编辑（by ID）
     IList<IQCBasicDataInfo> Search_IQCStandardTable_ID(Guid IQCST_ID);

     //模糊查询进料检验的检验项目的检验标准
     DataSet Search_IQCStandardTable_M(Guid IQCIT_ID, string IQCIT_Standard, string IQCIT_Remarks);

    //新增进料检验物料的检验项目的检验标准
     int Insert_IQCStandardTable(IQCBasicDataInfo BDI);

    //修改进料检验物料的检验项目的检验标准
     int Update_IQCStandardTable(IQCBasicDataInfo BDI);

    //删除进料检验的检验项目
     int Delete_IQCStandardTable(Guid IQCST_ID);

     //模糊查询产品型号用于维护认证信息(认证)
     DataSet Search_ProType_RZ(string PS_Name, string PT_Name);

    //模糊查询产品型号用于维护认证信息(其他)
     DataSet Search_ProType_QT(string PS_Name, string PT_Name);

    //增加产品认证型号
     int Insert_ProType_RZ(Guid PT_ID);

    //删除产品认证型号
     int Delete_ProType_RZ(Guid PT_ID);

    //认证工序查看
     DataSet Search_PRDetail_RZ(Guid PT_ID);

     //ID查询产品型号用于界面显示
     IList<IQCBasicDataInfo> Search_ProType_ID(Guid PT_ID);

    //认证工艺路线工序查看
     DataSet Search_PRDetail_RZR(Guid PT_ID);

    //该产品型号实际工序查看
     DataSet Search_PRDetail_SJ(Guid PT_ID);

    //该产品型号实际工序模糊检索
     DataSet Search_PRDetail_SJM(string PT_ID, string Condition);

    //认证工艺路线工序添加
     int Insert_PRDetail_RZR(Guid PRD_ID);

     //认证工艺路线工序修改
     int Update_PRDetail_RZR(Guid PRD_ID, int PRD_RouteOrder);

    //认证工序添加
     int Insert_PRDetail_RZ(Guid PRD_ID);

     //认证工序修改
     int Update_PRDetail_RZ(Guid PRD_ID, int PRD_RenZhengOrder);

    //认证工艺路线工序删除
     int Delete_PRDetail_RZR(Guid PRD_ID);

    //认证工序删除
     int Delete_PRDetail_RZ(Guid PRD_ID);

     //查询入库明细中需要进料检验的物料用于默认绑定
     DataSet Search_IMInStoreDetail_IQC(string Condition);

     //查询待审核物料用于审核
     DataSet Search_IMInStoreDetail_Au(string Condition);

     //新增检验单及检验值
     int Insert_IQCDetailTable(Guid IMISD_ID, Guid IMMBD_MaterialID);

     //查询检验详情表
     IList<IQCBasicDataInfo> Search_IQCDetailTable(Guid IQCDT_ID);

     //质检员判定检验合格
     int Update_IMInStoreDetail_IQC(IQCBasicDataInfo et);

     //审核人审核检验结果
     int Update_IMInStoreDetail_IQCAU(IQCBasicDataInfo et);

     //查询检验标准用于录入时的显示
     DataSet Search_IQCStandardTable_Grid(Guid IQCIT_ID, Guid IMISD_ID);

     //录入某项检验项目的某项检验标准
     int Insert_IQCStandardValue(Guid IQCSV_ID, string QCSV_Value, string QCSV_Result);

     //查询入库明细中需要进料检验的物料的信息用于新增检验单时查看
     IList<IQCBasicDataInfo> Search_IMInStoreDetail_New(string Condition);

     //查询待审核物料的检验详情用于显示
     IList<IQCBasicDataInfo> Search_IMInStoreDetail_ViewAu(string Condition);

     //新增认证信息
     int Insert_WorkOrder_IQC(IQCBasicDataInfo IQC);

     //查询检验详情审核结果
     IList<IQCBasicDataInfo> Search_IQCDetailTable_Au(Guid IQCDT_ID);

     //选择是否继续生产认证样品
     int Update_WorkOrder_IQC(IQCBasicDataInfo et);
}