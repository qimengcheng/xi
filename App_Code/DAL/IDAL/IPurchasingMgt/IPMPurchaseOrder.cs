using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;
using System.Collections;


/// <summary>
///IPMPurchaseOrder 的摘要说明
/// </summary>
public interface IPMPurchaseOrder
{
    DataSet SelectPMPurchaseApplySummary(string condition);
    DataSet SelectPMPurchaseApply_Material(string condition);
    void InsertPMPurchaseOrder(PMPurchaseOrderinfo pMPurchaseOrderinfo);
    void UpdatePMPurchaseApplyDetail(PMPurchaseOrderinfo pMPurchaseOrderinfo);
    void InsertPMPurchaseOrderDetail(PMPurchaseOrderinfo pMPurchaseOrderinfo);
    void UpdatePMPurchaseApplyDetail_One(PMPurchaseOrderinfo pMPurchaseOrderinfo);
    void InsertPMPurchaseApplyDetailPrice(PMPurchaseOrderinfo pMPurchaseOrderinfo);
    DataSet SelectPMPurchaseOrder();
    DataSet SelectPMPurchaseOrderDetail(PMPurchaseOrderinfo pMPurchaseOrderinfo);
   void UpdatePMPurchaseOrderDetail(PMPurchaseOrderinfo pMPurchaseOrderinfo);
    DataSet SelectPMPurchaseApplyDetail_Material(PMPurchaseOrderinfo pMPurchaseOrderinfo);
    DataSet SelectPMPurchaseApplyDetail_Apply(PMPurchaseOrderinfo pMPurchaseOrderinfo);
    void UpdatePMPurchaseOrder(PMPurchaseOrderinfo pMPurchaseOrderinfo);
    void UpdatePMPAD_Purchase(PMPurchaseOrderinfo pMPurchaseOrderinfo);
    DataSet SelectPMPurchaseOrderMain(string condition);
    DataSet SelectPMPurchaseOrderDetail_look(PMPurchaseOrderinfo pMPurchaseOrderinfo);
    void InsertPMPurchaseOrderMain(PMPurchaseOrderinfo pMPurchaseOrderinfo);
    void InsertPMPurchaseOrderDetail_Direct(PMPurchaseOrderinfo pMPurchaseOrderinfo);
    void UpdatePMPurchaseOrderDetail_Direct(PMPurchaseOrderinfo pMPurchaseOrderinfo);
    void DeletePMPurchaseOrderDetail_Direct(PMPurchaseOrderinfo pMPurchaseOrderinfo);
    void UpdatePMPurchaseOrder_State(PMPurchaseOrderinfo pMPurchaseOrderinfo);
    void DeletePMPurchaseOrder(PMPurchaseOrderinfo pMPurchaseOrderinfo);
    DataSet SelectPMPurchase_Material(string condition);
    DataSet SelectPMPurchaseOrderMain_Material(string condition);
}