using System;
using System.Data;

/// <summary>
///IBasicCode 的摘要说明
/// </summary>
public interface IBasicCode
{
    void Insert_Update_BDOrganization_depcode(string BDOS_Name, string BDOS_DepCode, string BDOS_No);
    int Delete_BDOrganization_depcode(string BDOS_Code);
    DataSet Search_BDOrganization_depcode(string condition);
    DataSet Search_BDOrganization_BDdepcode();
    void Insert_CDDepDistributeCodeT( string CDDDCT_Dep, string CDDDCT_Code);
    void Update_CDDepDistributeCodeT(Guid CDDDCT_ID, string CDDDCT_Dep, string CDDDCT_Code);
    int Delete_CDDepDistributeCodeT(Guid CDDDCT_ID);
    DataSet Search_CDDepDistributeCodeT(string condition);
    void Insert_CDThirdLevelCode(string CDTLC_DocType, string CDTLC_Code);
    void Update_CDThirdLevelCode(Guid CDTLC_ID, string CDTLC_DocType, string CDTLC_Code);
    int Delete_CDThirdLevelCode(Guid CDTLC_ID);
    DataSet Search_CDThirdLevelCode(string condition);
}