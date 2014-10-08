using EquipmentMangementAjax.SQLServer;

/// <summary>
/// �������ʹ�÷��䣬ʹ���������web.config������
/// </summary>
public class DALFactory
{
    //private static readonly string t = ConfigurationManager.AppSettings["t"].ToString();
    
	private DALFactory()
	{}

	  public static ICMProcessRoute CreateCMProcessRoute()
    {
        return new CMProcessRouteD();
    }//����
	 public static IOEMTrack CreateOEMTrack()
    {
        return new OEMTrackD();
    }
  public static IProSeriesInfo_ProType CreateProSeriesInfo_ProType()//��Ʒ������Ϣ����
    {
        return new ProSeriesInfo_ProTypeD();
    }
	 
	public static IWorkOrder CreateWorkOrder()  //�湤������
    {
        return new WorkOrderD();
    }
	
	 public static IErrorRelevant CreateErrorRelevant() //�쳣���
    {
        return new ErrorRelevant();
    }

    public static IWorkOrderCheck CreateWorkOrderCheck() //����Ʒ�鿴
    {
        return new WorkOrderCheckD();
    }

    public static IWOSSalary CreateWOSSalary() //�湤��н��
    {
        return new WOSSalaryD();
    }
	
	public static ICapacityBasic CreateCapacity() //���ܺ˶�
    {
        return new CapacityBasicD();
    }
	
	
    #region ZM �ͻ�����
    public static IClientBasic ClientBasic()//�ͻ�������Ϣά��
    {
        return new ClientBasic();
    }
  
    //public static IClientInfo ClientInfo()//�ͻ���Ϣ����
    //{
    //    return new EquipmentMangementAjax.SQLServer.ClientInfo();
    //}



    #endregion
	
       #region XWJ ZM ������
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

  public static IStoreBasic StoreBasic()//���ͣ�����������
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
     #region XWJ ���۹���
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
  #region XWJ �ɹ��ƻ�
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

   

    #region QZL��Ա����ѵ
    //��Ա����ѵ
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

    #region//QZL��Ա����ѵ
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

    #region QZL���µ�������
    //���µ����������¸�λ
    public static IHRFilesMgt CreateIHRFilesMgt()
    {
        return new HRFilesMgtD();
    }

    //���µ�������Ա������
    public static IHREType CreateIHREType()
    {
        return new HRETypeD();
    }
    //���µ�����Ϣ����
    public static IHRDDetail CreateIHRDDetail()
    {
        return new HRDDetailD();
    }
    #endregion

    #region//QZLн�ʹ���
    public static ISalaryAccountSetMaintanancecs CreateISalaryAccountSetMaintanancecs()
    {
        return new SalaryAccountSetMaintananceD();
    }//н�ʹ�������������ά��

    public static ISalaryTimeItemMaintanance CreateISalaryTimeItemMaintanance()
    {
        return new SalaryTimeItemMaintananceD();
    }//н�ʹ�������ʱ��Ŀά��

    public static ISalaryPieceworkItemMaintanance CreateISalaryPieceworkItemMaintanance()
    {
        return new SalaryPieceworkItemMaintananceD();
    }//н�ʹ������Ƽ���Ŀά��

    public static ISalaryTimeDayCalculate CreateISalaryTimeDayCalculate()
    {
        return new SalaryTimeDayCalculateD();
    }//н�ʹ�������ʱ�����ռ���
    public static ISalaryMonthCalculate CreateISalaryMonthCalculate()
    {
        return new SalaryMonthCalculateD();
    }//н�ʹ�����н���¶Ƚ���

    public static ISalaryReview CreateISalaryReview()
    {
        return new SalaryReviewD();
    }//н�ʹ�����н�ʲ鿴

    public static ISalaryIndividualIncome CreateISalaryIndividualIncome()
    {
        return new SalaryIndividualIncomeD();
    }//н�ʹ�������������˰������Ϣά��
    #endregion

    #region LJ���ϼ���ģ��
    //���ϼ����������
   // public static IIQCBasicData CreateIQCBasicDataInfo()
   // {
   //     return new EquipmentMangementAjax.SQLServer.IQCBasicDataD();
   // }
    #endregion

    #region LJʵ����Թ���ģ��
    //ʵ������
    public static IExpAppSubmit CreateExpTestAppInfo()
    {
        return new ExpAppSubmitD();
    }
    //��Ʒ���͡�ʵ����Ŀά��
    public static IExpTest CreateExpSampleType_ExpItems()
    {
        return new ExpTestD();
    }
    #endregion


    #region LJ�ж����ʹ���ģ��
    //ʵ������
    public static IHSFBasicData CreateHSFBasicData()
    {
        return new HSFBasicDataD();
    }
    #endregion


    
    

//�����ƻ�





 
  

   
    #region// ��Ŀ����Ͳɹ�����  HLL
    //��Ŀ����
    public static IPRMProjectSchedule CreatePRMProjectSchedule()
    {
        return new PRMProjectScheduleD();
    }
    public static IPRMProject CreatePRMProject()
    {
        return new PRMProjectD();
    }
//�ɹ�����
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
//������Ʒ���¿ͻ�����
 public static ICRMNewCustormDevelop CreateCRMNewCustormDevelop()
 {
     return new CRMNewCustormDevelopD();
 }
 //public static ICRMOutsideSample CreateCRMOutsideSample()
 //{
 //    return new EquipmentMangementAjax.SQLServer.CRMOutsideSampleD();
 //}
    #endregion

    #region �豸���� CC
    //�豸����
    public static IEquipType CreateEquipType()
    {
        return new EquipTypeD();
    }
    //�豸���Ƽ��ͺ�
    public static IEquipNameModel CreateEquipNameModel()
    {
        return new EquipNameModelD();
    }
    //�豸̨��
    public static IEquipmentInf CreateEquipmentInf()
    {
        return new EquipmentInfD();
    }
    //����
    public static IEquipUnusedApp CreateEquipUnusedApp()
    {
        return new EquipUnusedAppD();
    }
    //������Ŀ
    public static IEquipUpkeepItem CreateEquipUpkeepItem()
    {
        return new EquipUpkeepItemD();
    }
    //�����ƻ�
    public static IEquipUpkeepPlan CreateEquipUpkeepPlan()
    {
        return new EquipUpkeepPlanD();
    }
    //����ά��
    public static IEquipMaintenanceApp CreateEquipMaintenanceApp()
    {
        return new EquipMaintenanceAppD();
    }
    #endregion

    #region ��ʽ������� CC
    //�豸����
    public static ITypeTest CreateTypeTest()
    {
        return new TypeTestD();
    }
    #endregion ��ʽ������� CC

    #region �ܿ��ļ����� CC
    //��������ά��
    public static IBasicCode CreateBasicCode()
    {
        return new BasicCodeD();
    }
    //�ܿ��ļ�����
    public static IControlldeDoc CreateControlldeDoc()
    {
        return new ControlldeDocD();
    }
    #endregion �ܿ��ļ����� CC

    //#region//��Ч���� ZX
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
    #region//��Ч���� ZX
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

     #region �������߹��� ZXN
    public static IMeasAppliance CreateMeasAppliance()
    {
        return new MeasApplianceD();
    }
    #endregion

    /// <summary> 
    /// ������:IProSeriesInfo_ProErrorType
    /// ����:bush2582
    /// ����:����ģʽ����һ�����ݿ������ProSeriesInfo_ProErrorType
    /// ����:��
    /// </summary> 
    public static IProSeriesInfo_ProErrorType CreateProSeriesInfo_ProErrorType()
    {
        return new ProSeriesInfo_ProErrorType();
    }

    /// <summary>
    /// ������:IProcessCraftMgt
    /// ����:bush2582
    /// ����:����ģʽ����һ�����ݿ������ProcessCraftMgt
    /// ����:��
    /// <returns></returns>
    public static IProcessCraftMgt CreateIProcessCraftMgt()
    {
        return new ProcessCraftMgt();
    }

    /// <summary>
    /// ������:IProcess_BadProductTypeInfo
    /// ����:bush2582
    /// ����:����ģʽ����һ�����ݿ������Process_BadProductType
    /// ����:��
    /// <returns></returns>
    public static IProcess_BadProductTypeInfo CreateIProcess_BadProductTypeInfo()
    {
        return new Process_BadProductType();
    }

}
