using System;
using System.Data;
using System.Data.SqlClient;
using EquipmentMangementAjax.DBUtility;

/// <summary>
/// Class1 的摘要说明
/// </summary>
public class ProClassifiedInfoD
{
    public ProClassifiedInfoD()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
    public int Insert_ProClassifiedInfo(string name, string Class, string Type, string Need)
    {
        SqlParameter[] para = new SqlParameter[]{
                new SqlParameter("@PT_Name", SqlDbType.VarChar,60),
                    new  SqlParameter("@PCI_Class", SqlDbType.VarChar, 20),
          new  SqlParameter("@PCI_Type", SqlDbType.VarChar, 30),
         new   SqlParameter("@PCI_Need", SqlDbType.VarChar, 200),        };
        para[0].Value = name;
        para[1].Value = Class;
        para[2].Value = Type;
        para[3].Value = Need;

        return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_ProClassifiedInfo", para);

               

    }
    public int Delete_ProClassifiedInfo(Guid id)
    {
        SqlParameter para = new SqlParameter("@PCI_ID", SqlDbType.UniqueIdentifier);
        para.Value = id;
        return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_ProClassifiedInfo", para);


    }
    public DataSet Query_ProClassifiedInfo(string type)
    {
        SqlParameter para = new SqlParameter("@type", SqlDbType.VarChar, 60);
        para.Value = type;

        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_ProClassifiedInfo", para);

        return ds;


    }
    public DataSet Query_ProType(string type)
    {
        SqlParameter para = new SqlParameter("@type", SqlDbType.VarChar, 60);
        para.Value = type;

        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_ProType_S", para);

        return ds;


    }
    public int Update_ProClassifiedInfo(Guid Id, string Class, string Type, string Need)
    {
        SqlParameter[] para = new SqlParameter[]{
                new SqlParameter("@PCI_ID", SqlDbType.UniqueIdentifier),
                    new  SqlParameter("@PCI_Class", SqlDbType.VarChar, 20),
          new  SqlParameter("@PCI_Type", SqlDbType.VarChar, 30),
         new   SqlParameter("@PCI_Need", SqlDbType.VarChar, 200),        };
        para[0].Value = Id;
        para[1].Value = Class;
        para[2].Value = Type;
        para[3].Value = Need;





        return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_ProClassifiedInfo", para);


    }
}
