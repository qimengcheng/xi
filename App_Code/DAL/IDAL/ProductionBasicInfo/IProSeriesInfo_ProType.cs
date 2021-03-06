﻿using System;
using System.Data;

/// <summary>
///IProSeriesInfo_ProType 的摘要说明
/// </summary>
public interface IProSeriesInfo_ProType
{
    DataSet SList_ProSeries();//检索所有产品系列

    void I_ProSeries(ProSeriesInfo_ProTypeInfo proSeriesInfo_ProTypeInfo);//插入新的产品系列
    DataSet S_PBCraftInfo(Guid pBC_ID);//检索某一个工序

    DataSet S_ProSeries(string pS_Name);//模糊检索产品系列
    DataSet S_ProSeries_Name(string pS_Name);

    void U_ProSeries(ProSeriesInfo_ProTypeInfo proSeriesInfo_ProTypeInfo);//编辑产品系列名称

    int D_ProSeries(Guid pS_ID);//删除产品系列

    DataSet S_ProSeries_ProType(string condition);//查看一种产品系列所属产品型号

    DataSet SPTName_ProSeries_ProType(Guid pS_ID, string pT_Name);//检索一种产品系列特定产品型号


    void I_ProType(ProSeriesInfo_ProTypeInfo proSeriesInfo_ProTypeInfo);//新增产品型号
    void I_ProType_new(ProSeriesInfo_ProTypeInfo proSeriesInfo_ProTypeInfo, string PT_Parameters, string PT_Code);//新增产品型号_新


    void U_ProType(ProSeriesInfo_ProTypeInfo proSeriesInfo_ProTypeInfo);//编辑产品型号

    int D_ProType(Guid pT_ID);//删除产品型号

    DataSet S_ProType_ProcessRoute(Guid pR_ID);//显示某产品型号的工艺路线


    void I_ProProcessParameter(ProSeriesInfo_ProTypeInfo proSeriesInfo_ProTypeInfo);//编辑产品某个工序的工艺参数

    void U_ProProcessParameter(ProSeriesInfo_ProTypeInfo proSeriesInfo_ProTypeInfo);//编辑产品某个工序的工艺参数


    DataSet S_ProProcessParameter(Guid pT_ID, Guid pBC_ID);//查询产品某个工序的工艺参数
    DataSet S_PR_Name();//检索工艺路线名称
    DataSet S_BOM_Name();//检索BOM名称
    void I_ProMainSeries(string pMS_Name);//新增产品大型号
    void U_ProMainSeries(Guid pMS_ID, string pMS_Name);//编辑产品大型号
    void D_ProMainSeries(Guid pMS_ID);//删除产品大型号
    DataSet S_ProMainSeries(string condition);//查询产品大型号
    void U_Protype_ProMainSeries(Guid pMS_ID, Guid pT_ID);//为产品型号添加产品大型号
    void D_Protype_ProMainSeries(Guid pT_ID);//删除产品型号的产品大型号
    DataSet S_Protype_ProMainSeries(string condition);//检索待选产品型号
    DataSet S_ProMainSeries_Protype(string condition);//检索所属产品型号
    DataSet S_ProType_new(string condition);//检索所属产品型号
    DataSet S_ProType_WorkOrder(string PT_Name);//检查随工单里是否有该产品型号名称
    void U_ProType_new(ProSeriesInfo_ProTypeInfo proSeriesInfo_ProTypeInfo, string PT_Parameters, string PT_Code);//编辑产品型号_新
    DataSet S_PTCB();//产品编码属性检索
    DataSet S_PTCB_Detail(string condition, string PTCB_Section);//检索产品编码详情
    void D_PTCB_Detail(Guid PTCB_ID);//删除产品编码详情
    void I_PTCB_Detail(int PTCB_Section, string PTCB_Code, string PTCB_Detail);//新增产品编码详情
    void U_PTCB_Detail(Guid PTCB_ID, string PTCB_Code, string PTCB_Detail);//编辑产品编码详情
    void U_Protype_ProSeries(Guid pS_ID, Guid pT_ID);//为产品型号添加产品系列
    void D_Protype_ProSeries(Guid pT_ID);//删除产品型号的产品系列
    DataSet S_Protype_ProSeries_ForChose(string condition);//检索待选产品型号
    DataSet S_ErrorPhenomenonOptionDetail(string EPO_ID, string condition);//查询异常选项详细项目
    void U_ErrorPhenomenonOptionDetail(Guid EPOD_ID, string EPOD_Name, Guid PBC_ID);//编辑异常选项详细项目
    void I_ErrorPhenomenonOptionDetail(Guid EPO_ID, string EPOD_Name, Guid PBC_ID);//新建异常选项详细项目
    void D_ErrorPhenomenonOptionDetail(Guid EPOD_ID);//删除异常选项详细项目

}