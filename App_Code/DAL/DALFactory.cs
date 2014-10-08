using EquipmentMangementAjax.SQLServer;

/// <summary>
/// 该类可以使用反射，使得其可以在web.config中配置
/// </summary>
public class DALFactory
{
    //private static readonly string t = ConfigurationManager.AppSettings["t"].ToString();
    
	private DALFactory()
	{}

	  public static ICMProcessRoute CreateCMProcessRoute()
    {
        return new CMProcessRouteD();
    }//工艺
	 public static IOEMTrack CreateOEMTrack()
    {
        return new OEMTrackD();
    }
  public static IProSeriesInfo_ProType CreateProSeriesInfo_ProType()//产品基础信息管理
    {
        return new ProSeriesInfo_ProTypeD();
    }
	 
	public static IWorkOrder CreateWorkOrder()  //随工单生成
    {
        return new WorkOrderD();
    }
	
	 public static IErrorRelevant CreateErrorRelevant() //异常相关
    {
        return new ErrorRelevant();
    }

    public static IWorkOrderCheck CreateWorkOrderCheck() //在制品查看
    {
        return new WorkOrderCheckD();
    }

    public static IWOSSalary CreateWOSSalary() //随工单薪资
    {
        return new WOSSalaryD();
    }
	
	public static ICapacityBasic CreateCapacity() //产能核定
    {
        return new CapacityBasicD();
    }
	
	
    #region ZM 客户管理
    public static IClientBasic ClientBasic()//客户基础信息维护
    {
        return new ClientBasic();
    }
  
    //public static IClientInfo ClientInfo()//客户信息管理
    //{
    //    return new EquipmentMangementAjax.SQLServer.ClientInfo();
    //}



    #endregion
	
       #region XWJ ZM 库存管理
     public static IMaterialBasicData MaterialBasicData()
    {
        return new MaterialBasicDataD();
    }
    //public static IIMInStore InStore()
    //{
    //    return new EquipmentMangementAjax.SQLServer.IMInStoreMainD();
    //}
    //public static IIMOutStore OutStore()
    //{
    //    return new EquipmentMangementAjax.SQLServer.IMOutStoreD();
    //}

  public static IStoreBasic StoreBasic()//张猛，库存基础数据
  {
      return new StoreBasic();
  }
public static IIMOver IMOver()
    {
        return new IMOverD();
    }
public static IIMDiaobo Diaobo()
    {
        return new IMDiaoboD();
    }
    #endregion
     #region XWJ 销售管理
    public static ISalesMonthPlan MonthPlan()
    {
        return new SalesMonthPlanD();
    }
    public static ISalesWeekPlan WeekPlan()
    {
        return new SalesWeekPlanD();
    }
    public static ISalesOrder SalseOrder()
    {
        return new SalesOrderD();
    }
    public static ISMOrderDeliverPlan OrderDeliverPlan()
    {
        return new SMOrderDeliverPlanD();
    }
    //public static ISalseReturn  SalseReturn()
    //{
    //    return new EquipmentMangementAjax.SQLServer.SalesReturnD();
    //}
    //public static ISalseAfter SalesAfter()
    //{
    //    return new EquipmentMangementAjax.SQLServer.SalesAfterD();
    //}
    //public static ISalsePrice SalesPrice()
    //{
    //    return new EquipmentMangementAjax.SQLServer.SalesPriceD();
    //}
    //public static ISalsePayBill SalesPayBill()
    //{
    //    return new EquipmentMangementAjax.SQLServer.SalesPayBillD();
    //}
    #endregion
  #region XWJ 采购计划
    public static IPurchasingPlan PurchasingPlan()
    {
        return new PurchasingPlanD();
    }
    #endregion
    public static IUser CreateUser()
    {
        return new EquipmentMangementAjax.SQLServer.User();
    }

    public static IBasicData CreateBasicData()
    {
        return new EquipmentMangementAjax.SQLServer.BasicData();
    }

   

    #region QZL新员工培训
    //新员工培训
    public static INETtainning CreateNET()
    {
        return new NETtainningD();
    }
    public static INewEmpInfoAdd CreateNewEmpInfoAdd()
    {
        return new NewEmpInfoAddD();
    }
    public static INewEmpResulsD CreateNewEmpResulsD()
    {
        return new NewEmpResulsD();
    }
    #endregion

    #region//QZL老员工培训
    public static ITrainingTypeMaintenance CreateTrainingTypeMaintenanceD()
    {
        return new TrainingTypeMaintenanceD();
    }

    public static ITrainningYearPlanMgt CreateTrainningYearPlanMgtD()
    {
        return new TrainningYearPlanMgtD();
    }

    public static ITrainningMonthPlanD CreateITrainningMonthPlanD()
    {
        return new TrainningMonthPlanD();
    }
    #endregion

    #region QZL人事档案管理
    //人事档案管理人事岗位
    public static IHRFilesMgt CreateIHRFilesMgt()
    {
        return new HRFilesMgtD();
    }

    //人事档案管理员工类型
    public static IHREType CreateIHREType()
    {
        return new HRETypeD();
    }
    //人事档案信息管理
    public static IHRDDetail CreateIHRDDetail()
    {
        return new HRDDetailD();
    }
    #endregion

    #region//QZL薪资管理
    public static ISalaryAccountSetMaintanancecs CreateISalaryAccountSetMaintanancecs()
    {
        return new SalaryAccountSetMaintananceD();
    }//薪资管理——工资账套维护

    public static ISalaryTimeItemMaintanance CreateISalaryTimeItemMaintanance()
    {
        return new SalaryTimeItemMaintananceD();
    }//薪资管理——计时项目维护

    public static ISalaryPieceworkItemMaintanance CreateISalaryPieceworkItemMaintanance()
    {
        return new SalaryPieceworkItemMaintananceD();
    }//薪资管理——计件项目维护

    public static ISalaryTimeDayCalculate CreateISalaryTimeDayCalculate()
    {
        return new SalaryTimeDayCalculateD();
    }//薪资管理——计时工资日计算
    public static ISalaryMonthCalculate CreateISalaryMonthCalculate()
    {
        return new SalaryMonthCalculateD();
    }//薪资管理——薪资月度结算

    public static ISalaryReview CreateISalaryReview()
    {
        return new SalaryReviewD();
    }//薪资管理——薪资查看

    public static ISalaryIndividualIncome CreateISalaryIndividualIncome()
    {
        return new SalaryIndividualIncomeD();
    }//薪资管理——个人所得税基础信息维护
    #endregion

    #region LJ进料检验模块
    //进料检验基础数据
   // public static IIQCBasicData CreateIQCBasicDataInfo()
   // {
   //     return new EquipmentMangementAjax.SQLServer.IQCBasicDataD();
   // }
    #endregion

    #region LJ实验测试管理模块
    //实验申请
    public static IExpAppSubmit CreateExpTestAppInfo()
    {
        return new ExpAppSubmitD();
    }
    //样品类型、实验项目维护
    public static IExpTest CreateExpSampleType_ExpItems()
    {
        return new ExpTestD();
    }
    #endregion


    #region LJ有毒物质管理模块
    //实验申请
    public static IHSFBasicData CreateHSFBasicData()
    {
        return new HSFBasicDataD();
    }
    #endregion


    
    

//生产计划





 
  

   
    #region// 项目管理和采购管理  HLL
    //项目管理
    public static IPRMProjectSchedule CreatePRMProjectSchedule()
    {
        return new PRMProjectScheduleD();
    }
    public static IPRMProject CreatePRMProject()
    {
        return new PRMProjectD();
    }
//采购管理
    public static IPMSupplyInfo_PMSupplyContact CreatePMSupplyInfo_PMSupplyContact()
    {
        return new PMSupplyInfo_PMSupplyContactD();
    }
    public static IPMPurchaseingApplyRule CreatePMPurchaseingApplyRule()
    {
        return new PMPurchaseingApplyRuleD();
    }
    public static IPMSupplyCertific CreatePMSupplyCertific()
    {
        return new PMSupplyCertificD();
    }
    public static IPMSupplyMaterial CreatePMSupplyMaterial()
    {
        return new PMSupplyMaterialD();
    }
    public static IPMPurchaseOrder CreatePMPurchaseOrder()
    {
        return new PMPurchaseOrderD();
    }
 public static IPMCopperFoundry CreatePMCopperFoundry()
    {
        return new PMCopperFoundryD();
    }
 public static IPMEquipment CreatePMEquipment()
 {
     return new PMEquipmentD();
 }
 public static IPMPaymentBill CreatePMPaymentBill()
 {
     return new PMPaymentBillD();
 }

 public static IPRMProjectMaintenance CreatePRMProjectMaintenance()
 {
     return new PRMProjectMaintenanceD();
 }
//外送样品和新客户开发
 public static ICRMNewCustormDevelop CreateCRMNewCustormDevelop()
 {
     return new CRMNewCustormDevelopD();
 }
 //public static ICRMOutsideSample CreateCRMOutsideSample()
 //{
 //    return new EquipmentMangementAjax.SQLServer.CRMOutsideSampleD();
 //}
    #endregion

    #region 设备管理 CC
    //设备类型
    public static IEquipType CreateEquipType()
    {
        return new EquipTypeD();
    }
    //设备名称及型号
    public static IEquipNameModel CreateEquipNameModel()
    {
        return new EquipNameModelD();
    }
    //设备台账
    public static IEquipmentInf CreateEquipmentInf()
    {
        return new EquipmentInfD();
    }
    //报废
    public static IEquipUnusedApp CreateEquipUnusedApp()
    {
        return new EquipUnusedAppD();
    }
    //保养项目
    public static IEquipUpkeepItem CreateEquipUpkeepItem()
    {
        return new EquipUpkeepItemD();
    }
    //保养计划
    public static IEquipUpkeepPlan CreateEquipUpkeepPlan()
    {
        return new EquipUpkeepPlanD();
    }
    //厂内维修
    public static IEquipMaintenanceApp CreateEquipMaintenanceApp()
    {
        return new EquipMaintenanceAppD();
    }
    #endregion

    #region 型式试验管理 CC
    //设备类型
    public static ITypeTest CreateTypeTest()
    {
        return new TypeTestD();
    }
    #endregion 型式试验管理 CC

    #region 受控文件管理 CC
    //基础数据维护
    public static IBasicCode CreateBasicCode()
    {
        return new BasicCodeD();
    }
    //受控文件发放
    public static IControlldeDoc CreateControlldeDoc()
    {
        return new ControlldeDocD();
    }
    #endregion 受控文件管理 CC

    //#region//绩效管理 ZX
    //public static IHRPtype CreateIHRPtype()
    //{
    //    return new EquipmentMangementAjax.SQLServer.HRPerfD();
    //}
    //public static IHRPItem CreateIHRPItem()
    //{
    //    return new EquipmentMangementAjax.SQLServer.HRPItemD();

    //}
    //public static IHRPItemScore CreateIHRPItemScore()
    //{
    //    return new EquipmentMangementAjax.SQLServer.HRPItemScoreD();
    //}
    //public static IHRPerformceDetail CreatIHRPerformceDetail()
    //{
    //    return new EquipmentMangementAjax.SQLServer.HRPerformceDetailD();
    //}
    //#endregion
    #region//绩效管理 ZX
    public static IHRPtype CreateIHRPtype()
    {
        return new HRPerfD();
    }
    public static IHRPItem CreateIHRPItem()
    {
        return new HRPItemD();

    }
    public static IHRPItemScore CreateIHRPItemScore()
    {
        return new HRPItemScoreD();
    }
    public static IHRPerformceDetail CreatIHRPerformceDetail()
    {
        return new HRPerformceDetailD();
    }
    public static IHRerfYear CreatIHRPerformceYear()
    {
        return new HRPerfYearD();
    }
    #endregion

     #region 计量器具管理 ZXN
    public static IMeasAppliance CreateMeasAppliance()
    {
        return new MeasApplianceD();
    }
    #endregion

    /// <summary> 
    /// 函数名:IProSeriesInfo_ProErrorType
    /// 作者:bush2582
    /// 作用:工厂模式创建一个数据库访问类ProSeriesInfo_ProErrorType
    /// 参数:无
    /// </summary> 
    public static IProSeriesInfo_ProErrorType CreateProSeriesInfo_ProErrorType()
    {
        return new ProSeriesInfo_ProErrorType();
    }

    /// <summary>
    /// 函数名:IProcessCraftMgt
    /// 作者:bush2582
    /// 作用:工厂模式创建一个数据库访问类ProcessCraftMgt
    /// 参数:无
    /// <returns></returns>
    public static IProcessCraftMgt CreateIProcessCraftMgt()
    {
        return new ProcessCraftMgt();
    }

    /// <summary>
    /// 函数名:IProcess_BadProductTypeInfo
    /// 作者:bush2582
    /// 作用:工厂模式创建一个数据库访问类Process_BadProductType
    /// 参数:无
    /// <returns></returns>
    public static IProcess_BadProductTypeInfo CreateIProcess_BadProductTypeInfo()
    {
        return new Process_BadProductType();
    }

}
