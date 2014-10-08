using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
///PMPurchaseOrderL 的摘要说明
/// </summary>
public class PMPurchaseOrderL
{
    private static readonly IPMPurchaseOrder PMP = DALFactory.CreatePMPurchaseOrder();
	public PMPurchaseOrderL()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    public DataSet SelectPMPurchaseApplySummary(string condition)
    {
        return PMP.SelectPMPurchaseApplySummary(condition);
    }
    public DataSet SelectPMPurchaseApply_Material(string condition)
    {
        return PMP.SelectPMPurchaseApply_Material(condition);
    }
    public void InsertPMPurchaseOrder(PMPurchaseOrderinfo pMPurchaseOrderinfo)
    {
        PMP.InsertPMPurchaseOrder(pMPurchaseOrderinfo);
    }

    public void UpdatePMPurchaseApplyDetail(PMPurchaseOrderinfo pMPurchaseOrderinfo)
    {
        PMP.UpdatePMPurchaseApplyDetail(pMPurchaseOrderinfo);
    }
    public void InsertPMPurchaseOrderDetail(PMPurchaseOrderinfo pMPurchaseOrderinfo)
    {
        PMP.InsertPMPurchaseOrderDetail(pMPurchaseOrderinfo);
    }
    public void UpdatePMPurchaseApplyDetail_One(PMPurchaseOrderinfo pMPurchaseOrderinfo)
    {
        PMP.UpdatePMPurchaseApplyDetail_One(pMPurchaseOrderinfo);
    }
    public void InsertPMPurchaseApplyDetailPrice(PMPurchaseOrderinfo pMPurchaseOrderinfo)
    {
        PMP.InsertPMPurchaseApplyDetailPrice(pMPurchaseOrderinfo);
    }
    public DataSet  SelectPMPurchaseOrder()
    {
        return PMP.SelectPMPurchaseOrder();
    }
    public DataSet SelectPMPurchaseOrderDetail(PMPurchaseOrderinfo pMPurchaseOrderinfo)
    { 
    return PMP.SelectPMPurchaseOrderDetail(pMPurchaseOrderinfo);
    }
    public void  UpdatePMPurchaseOrderDetail(PMPurchaseOrderinfo pMPurchaseOrderinfo)
    {
    PMP. UpdatePMPurchaseOrderDetail( pMPurchaseOrderinfo);
    }
    public DataSet SelectPMPurchaseApplyDetail_Material(PMPurchaseOrderinfo pMPurchaseOrderinfo)
    {
      return  PMP.SelectPMPurchaseApplyDetail_Material(pMPurchaseOrderinfo);
    }
    public DataSet SelectPMPurchaseApplyDetail_Apply(PMPurchaseOrderinfo pMPurchaseOrderinfo)
    {
        return PMP.SelectPMPurchaseApplyDetail_Apply(pMPurchaseOrderinfo);
    }
    public void UpdatePMPurchaseOrder(PMPurchaseOrderinfo pMPurchaseOrderinfo)
    {
        PMP.UpdatePMPurchaseOrder(pMPurchaseOrderinfo);
    }
    public void UpdatePMPAD_Purchase(PMPurchaseOrderinfo pMPurchaseOrderinfo)
    {
        PMP.UpdatePMPAD_Purchase(pMPurchaseOrderinfo);
    }

    public DataSet SelectPMPurchaseOrderMain(string condition)
    {
       return PMP.SelectPMPurchaseOrderMain(condition);
    }
    public DataSet SelectPMPurchaseOrderDetail_look(PMPurchaseOrderinfo pMPurchaseOrderinfo)
    {
        return PMP.SelectPMPurchaseOrderDetail_look(pMPurchaseOrderinfo);
    }
    public void InsertPMPurchaseOrderMain(PMPurchaseOrderinfo pMPurchaseOrderinfo)
    {
        PMP.InsertPMPurchaseOrderMain(pMPurchaseOrderinfo);
    }
    public void InsertPMPurchaseOrderDetail_Direct(PMPurchaseOrderinfo pMPurchaseOrderinfo)
    { 
    PMP.InsertPMPurchaseOrderDetail_Direct(pMPurchaseOrderinfo);
    }
    public void UpdatePMPurchaseOrderDetail_Direct(PMPurchaseOrderinfo pMPurchaseOrderinfo)
    {
        PMP.UpdatePMPurchaseOrderDetail_Direct(pMPurchaseOrderinfo);
    }
    public void DeletePMPurchaseOrderDetail_Direct(PMPurchaseOrderinfo pMPurchaseOrderinfo)
    {
        PMP.DeletePMPurchaseOrderDetail_Direct(pMPurchaseOrderinfo);
    }
    public void UpdatePMPurchaseOrder_State(PMPurchaseOrderinfo pMPurchaseOrderinfo)
    {
        PMP.UpdatePMPurchaseOrder_State(pMPurchaseOrderinfo);
    }
    public void DeletePMPurchaseOrder(PMPurchaseOrderinfo pMPurchaseOrderinfo)
    {
        PMP.DeletePMPurchaseOrder(pMPurchaseOrderinfo);
    }
    public DataSet SelectPMPurchase_Material(string condition)
    {
        return PMP.SelectPMPurchase_Material(condition);
    }
    public DataSet SelectPMPurchaseOrderMain_Material(string condition)
    {
        return PMP.SelectPMPurchaseOrderMain_Material(condition);
    }
}