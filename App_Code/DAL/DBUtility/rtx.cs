using System;
using RTXSAPILib;

/// <summary>
/// rtx 的摘要说明
/// </summary>
public class Rtx
{
	public Rtx()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}

    public string RTX_SendIM(string sSender, string sPwd, string sMsg, string sReceiver)  
{  
    string sErr = "";  
    try  
    {  
        RTXSAPIRootObj RootObj = new RTXSAPIRootObj();     //创建根对象  
        RootObj.ServerIP = "192.168.1.3";
        RootObj.ServerPort = 8006;
        string sSessionID = "{f1b15e85-2542-4220-90b8-8be3661eaa38}";
        RootObj.SendIM(sSender, sPwd, sReceiver ,sMsg, sSessionID);  
    }  
    catch (Exception ex)  
    {  
        sErr = ex.Message;  
    }  
    return sErr;  
 
    }
   

}