using System;
using System.Data;
using System.Data.SqlClient;
using EquipmentMangementAjax.DBUtility;

/// <summary>
///TemplateUploadD 的摘要说明
/// </summary>
public class TemplateUploadD
{
	public TemplateUploadD()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    public DataSet S_TemplateUpload(string TmpUpload_Name)//模糊检索模板
    {
        SqlParameter[] para = new SqlParameter[1];
        para[0] = new SqlParameter("@TmpUpload_Name", SqlDbType.VarChar, 50);
        para[0].Value = TmpUpload_Name;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_TemplateUpload", para);
    }

    public DataSet SList_TemplateUpload()//检索所有模板
    {

        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_SList_TemplateUpload", null);
    }

    public DataSet S_TemplatUpload_Name(string TmpUpload_Name)//检索是否存在同名模板
    {
        SqlParameter para = new SqlParameter("@TmpUpload_Name", TmpUpload_Name);
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_TemplateUpload_Name", para);
    }

    public void I_TemplatUpload(TempUploadInfo info)//插入新的模板
    {
        SqlParameter[] parm = new SqlParameter[4];
        parm[0] = new SqlParameter("@TmpUpload_Name", SqlDbType.VarChar, 50);
        parm[0].Value = info.TmpUpload_Name;
        parm[1] = new SqlParameter("@TmpUpload_ImgUrl", SqlDbType.VarChar, 80);
        parm[1].Value = info.TmpUpload_ImgUrl;
        parm[2] = new SqlParameter("@TmpUpload_Time", SqlDbType.DateTime);
        parm[2].Value = info.TmpUpload_Time;
        parm[3] = new SqlParameter("@TmpUpload_Person", SqlDbType.VarChar, 50);
        parm[3].Value = info.TmpUpload_Person;

        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_TemplateUpload", parm);
    }

    public void U_TemplatUpload(TempUploadInfo info)//修改模板
    {
        SqlParameter[] parm = new SqlParameter[5];
        parm[0] = new SqlParameter("@TmpUpload_ID", SqlDbType.UniqueIdentifier);
        parm[0].Value = info.TmpUpload_ID;
        parm[1] = new SqlParameter("@TmpUpload_Name", SqlDbType.VarChar, 50);
        parm[1].Value = info.TmpUpload_Name;
        parm[2] = new SqlParameter("@TmpUpload_ImgUrl", SqlDbType.VarChar, 80);
        parm[2].Value = info.TmpUpload_ImgUrl;
        parm[3] = new SqlParameter("@TmpUpload_Time", SqlDbType.DateTime);
        parm[3].Value = info.TmpUpload_Time;
        parm[4] = new SqlParameter("@TmpUpload_Person", SqlDbType.VarChar, 50);
        parm[4].Value = info.TmpUpload_Person;

        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_TemplateUpload", parm);
    }

    public int D_TemplatUpload(Guid TmpUpload_ID)//删除模板
    {
        SqlParameter[] parm = new SqlParameter[1];
        parm[0] = new SqlParameter("@TmpUpload_ID", SqlDbType.UniqueIdentifier);
        parm[0].Value = TmpUpload_ID;
        return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
          CommandType.StoredProcedure, "Proc_D_TemplateUpload", parm);
    }

    public DataSet S_TemplatUpload_ImgUrl(Guid TmpUpload_ID)//获取模板图片地址
    {
        SqlParameter[] parm = new SqlParameter[1];
        parm[0] = new SqlParameter("@TmpUpload_ID", SqlDbType.UniqueIdentifier);
        parm[0].Value = TmpUpload_ID;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_TemplatUpload_ImgUrl", parm);
    }
    public DataSet S_TemplatUpload_ProType(string condition)//查看一个模板所属产品型号
    {
        SqlParameter[] para = new SqlParameter[1];

        para[0] = new SqlParameter("@condition", SqlDbType.NVarChar, 2000);
        para[0].Value = condition;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_TemplatUpload_ProType", para);

    }

    public DataSet S_TemplatUpload_ForChose(string condition)//检索待选产品型号
    {
        SqlParameter[] parm = new SqlParameter[1];
        parm[0] = new SqlParameter("@condition", SqlDbType.VarChar, 1000);
        parm[0].Value = condition;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
          CommandType.StoredProcedure, "Proc_S_TemplatUpload_ForChose", parm);
    }

    public void U_TemplatUpload_AddTemp(Guid TmpUpload_ID, Guid pT_ID)//为产品型号添加模板
    {
        SqlParameter[] parm = new SqlParameter[2];
        parm[0] = new SqlParameter("@TmpUpload_ID", SqlDbType.UniqueIdentifier);
        parm[0].Value = TmpUpload_ID;
        parm[1] = new SqlParameter("@PT_ID", SqlDbType.UniqueIdentifier);
        parm[1].Value = pT_ID;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
        CommandType.StoredProcedure, "U_TemplatUpload_AddTemp", parm);
    }

    public void D_TemplatUpload_ProType(Guid pT_ID)//删除产品型号的模板
    {
        SqlParameter[] parm = new SqlParameter[1];
        parm[0] = new SqlParameter("@PT_ID", SqlDbType.UniqueIdentifier);
        parm[0].Value = pT_ID;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
        CommandType.StoredProcedure, "Proc_D_TemplatUpload_ProType", parm);
    }


}