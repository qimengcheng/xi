using System;
using System.Data;

/// <summary>
///CMProcessRouteL 的摘要说明
/// </summary>
public class CMProcessRouteL
{
    private static readonly ICMProcessRoute cmpr = DALFactory.CreateCMProcessRoute();
    public CMProcessRouteL()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }
    public DataSet S_ProcessRoute_Doc(string condition)//检索工艺文件列表
    {
        return cmpr.S_ProcessRoute_Doc(condition);
    }
    public DataSet S_ProcessRoute(Guid cDA_ID)//检索某工艺文件列表所属工艺路线
    {
        return cmpr.S_ProcessRoute(cDA_ID);
    }
    public DataSet S_ProcessRoute_PRDetail(Guid pR_ID)//检索某工艺路线所属工序
    {
        return cmpr.S_ProcessRoute_PRDetail(pR_ID);
    }
    public void I_ProcessRoute(CMProcessRouteInfo cMProcessRouteInfo)//新增工艺路线
    {

        cmpr.I_ProcessRoute(cMProcessRouteInfo);
    }
    public void U_ProcessRoute(CMProcessRouteInfo cMProcessRouteInfo)//编辑工艺路线
    {

        cmpr.U_ProcessRoute(cMProcessRouteInfo);
    }
    public void D_ProcessRoute(CMProcessRouteInfo cMProcessRouteInfo)//删除工艺路线
    {
        cmpr.D_ProcessRoute(cMProcessRouteInfo);
    }
    public void U_ProcessRoute_PRDetail(CMProcessRouteInfo cMProcessRouteInfo)//编辑某工艺路线所属工序
    {
        cmpr.U_ProcessRoute_PRDetail(cMProcessRouteInfo);
    }
    public void D_ProcessRoute_PRDetail(CMProcessRouteInfo cMProcessRouteInfo)//删除工艺路线所属工序
    {
        cmpr.D_ProcessRoute_PRDetail(cMProcessRouteInfo);
    }
    public DataSet S_ProcessRoute_PBCraftInfo(Guid pR_ID)//检索某工艺路线所属工序
    {
        return cmpr.S_ProcessRoute_PBCraftInfo(pR_ID);
    }
    public void I_PRDetail_PBCraftInfo(Guid prid, Guid pbcid)//将工序新增至工艺路线详细
    {
         cmpr.I_PRDetail_PBCraftInfo(prid, pbcid);
    }
    public void I_CopyPRDetail(Guid prid1, Guid prid2)//插入某个工艺路线的所有工序
    {
        cmpr.I_CopyPRDetail(prid1, prid2);
    }
}