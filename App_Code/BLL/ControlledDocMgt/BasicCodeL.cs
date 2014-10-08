using System;
using System.Data;

/// <summary>
///BasicCodeL 的摘要说明
/// </summary>
public class BasicCodeL
{
    private static readonly IBasicCode equipm = DALFactory.CreateBasicCode();
	public BasicCodeL()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    public void Insert_Update_BDOrganization_depcode(string BDOS_Name, string BDOS_DepCode, string BDOS_No)
    {
        equipm.Insert_Update_BDOrganization_depcode(BDOS_Name, BDOS_DepCode, BDOS_No);
    }
    public int Delete_BDOrganization_depcode(string BDOS_Code)
    {
        return equipm.Delete_BDOrganization_depcode( BDOS_Code);
    }
    public DataSet Search_BDOrganization_depcode(string condition)
    {
        return equipm.Search_BDOrganization_depcode( condition);
    }
    public DataSet Search_BDOrganization_BDdepcode()
    {
        return equipm.Search_BDOrganization_BDdepcode();
    }
    public void Insert_CDDepDistributeCodeT(string CDDDCT_Dep, string CDDDCT_Code)
    {
        equipm.Insert_CDDepDistributeCodeT(CDDDCT_Dep, CDDDCT_Code);
    }
    public void Update_CDDepDistributeCodeT(Guid CDDDCT_ID, string CDDDCT_Dep, string CDDDCT_Code)
    {
        equipm.Update_CDDepDistributeCodeT( CDDDCT_ID, CDDDCT_Dep, CDDDCT_Code);
    }
    public int Delete_CDDepDistributeCodeT(Guid CDDDCT_ID)
    {
        return equipm.Delete_CDDepDistributeCodeT( CDDDCT_ID);
    }
    public DataSet Search_CDDepDistributeCodeT(string condition)
    {
        return equipm.Search_CDDepDistributeCodeT( condition);
    }
    public void Insert_CDThirdLevelCode(string CDTLC_DocType, string CDTLC_Code)
    {
        equipm.Insert_CDThirdLevelCode( CDTLC_DocType, CDTLC_Code);
    }
    public void Update_CDThirdLevelCode(Guid CDTLC_ID, string CDTLC_DocType, string CDTLC_Code)
    {
        equipm.Update_CDThirdLevelCode( CDTLC_ID, CDTLC_DocType, CDTLC_Code);
    }
    public int Delete_CDThirdLevelCode(Guid CDTLC_ID)
    {
        return equipm.Delete_CDThirdLevelCode( CDTLC_ID);
    }
    public DataSet Search_CDThirdLevelCode(string condition)
    {
        return equipm.Search_CDThirdLevelCode( condition);
    }
}