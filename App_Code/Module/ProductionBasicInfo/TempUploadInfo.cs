using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///TempUploadInfo 的摘要说明
/// </summary>
public class TempUploadInfo
{
	public TempUploadInfo()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    private Guid tmpUpload_ID;

    public Guid TmpUpload_ID
    {
        get { return tmpUpload_ID; }
        set { tmpUpload_ID = value; }
    }

    private string tmpUpload_Person;

    public string TmpUpload_Person
    {
        get { return tmpUpload_Person; }
        set { tmpUpload_Person = value; }
    }

    private DateTime tmpUpload_Time;

    public DateTime TmpUpload_Time
    {
        get { return tmpUpload_Time; }
        set { tmpUpload_Time = value; }
    }

    private string tmpUpload_ImgUrl;

    public string TmpUpload_ImgUrl
    {
        get { return tmpUpload_ImgUrl; }
        set { tmpUpload_ImgUrl = value; }
    }

    private string tmpUpload_Name;

    public string TmpUpload_Name
    {
        get { return tmpUpload_Name; }
        set { tmpUpload_Name = value; }
    }
    
}