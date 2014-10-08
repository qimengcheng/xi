using System;
using System.Data;

/// <summary>
///ICMProcessRoute 的摘要说明
/// </summary>
public interface ICMProcessRoute
{

    DataSet S_ProcessRoute_Doc(string condition);//检索工艺文件列表
    DataSet S_ProcessRoute(Guid cDA_ID);//检索某工艺文件列表所属工艺路线
    DataSet S_ProcessRoute_PRDetail(Guid pR_ID);//检索某工艺路线所属工序
    void I_ProcessRoute(CMProcessRouteInfo cMProcessRouteInfo);//新增工艺路线
    void U_ProcessRoute(CMProcessRouteInfo cMProcessRouteInfo);//编辑工艺路线
    void D_ProcessRoute(CMProcessRouteInfo cMProcessRouteInfo);//删除工艺路线
    void U_ProcessRoute_PRDetail(CMProcessRouteInfo cMProcessRouteInfo);//编辑某工艺路线所属工序
    void D_ProcessRoute_PRDetail(CMProcessRouteInfo cMProcessRouteInfo);//删除工艺路线所属工序
    DataSet S_ProcessRoute_PBCraftInfo(Guid pR_ID);//检索某工艺路线所属工序
    void I_PRDetail_PBCraftInfo(Guid prid, Guid pbcid);//将工序新增至工艺路线详细
    void I_CopyPRDetail(Guid prid1, Guid prid2);//插入某个工艺路线的所有工序
}