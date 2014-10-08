using System;
using System.Collections.Generic;
using System.Web.Security;

public class User
{
    private static readonly IUser us = DALFactory.CreateUser();
    public User()
    {
       
    }
    public string EncodingPassword(string password)
    {
        return FormsAuthentication.HashPasswordForStoringInConfigFile(password, "SHA1");//"MD5"  
    }

    public int Insert_UMUserInfo(UMUserInfoInfo uMUserInfoInfo)
    {
       return  us.Insert_UMUserInfo(uMUserInfoInfo);
    }
    public int Update_UMUserInfo(UMUserInfoInfo uMUserInfoInfo)
    {
        return us.Update_UMUserInfo(uMUserInfoInfo);
    }
    public int Delete_UMUserInfo(string uMUI_UserID)
    {
        return us.Delete_UMUserInfo(uMUI_UserID);
    }
    public IList<UMUserInfoInfo> Select_UMUserInfo(string condition)
    {
        return us.Select_UMUserInfo(condition);
    }
    public int Update_SingleCol(string colname, string colvalue, string keyname, string keyvalue, string tabname)
    {
        BasicData bd = new BasicData();
        return bd.Update_SingleCol(colname, colvalue, keyname, keyvalue, tabname);
    }
    public string Select_SingleCol(string colname,  string keyname, string keyvalue, string tabname)
    {
        BasicData bd = new BasicData();
        return bd.Select_SingleCol(colname, keyname, keyvalue, tabname);
    }
    public string TimeConvert(DateTime dt)
    {
        string year = dt.Year.ToString();
        string month = "";
        if (dt.Month < 10)
        {
            month = "0" + dt.Month.ToString();
        }
        else
        {
            month = dt.Month.ToString();
        }
        string day = "";
        if (dt.Day < 10)
        {
            day = "0" + dt.Day.ToString();
        }
        else
        {
            day = dt.Day.ToString();
        }
        string hour = "";
        if (dt.Hour < 10)
        {
            hour = "0" + dt.Hour.ToString();
        }
        else
        {
            hour = dt.Hour.ToString();
        }
        string minute = "";
        if (dt.Minute < 10)
        {
            minute = "0" + dt.Minute.ToString();
        }
        else
        {
            minute = dt.Minute.ToString();
        }
        string second = "";
        if (dt.Second < 10)
        {
            second = "0" + dt.Second.ToString();
        }
        else
        {
            second = dt.Second.ToString();
        }
        string datetime = year + "-" + month + "-" + day + " " + hour + ":" + minute + ":" + second;
        return datetime;
    }

    public string TimeConvert(string dt)
    {
        string date = dt.Substring(0, 10).Trim();
        string time = dt.Substring(dt.IndexOf(":") - 2, dt.Length - dt.IndexOf(":") + 2).Trim();
        string[] st = date.Split(new char[] { '/' });
        string[] st2 = time.Split(new char[] { ':' });
        string year = st[2];
        string month = st[1];
        if (Convert.ToInt32(month) < 10)
        {
            month = "0" + Convert.ToInt32(month).ToString();
        }
        else
        {

        }
        string day = st[0];
        if (Convert.ToInt32(day) < 10)
        {
            day = "0" + Convert.ToInt32(day).ToString();
        }
        else
        {

        }
        string hour = st2[0];
        if (Convert.ToInt32(hour) < 10)
        {
            hour = "0" + Convert.ToInt32(hour).ToString();
        }
        else
        {

        }
        string minute = st2[1];
        if (Convert.ToInt32(minute) < 10)
        {
            minute = "0" + Convert.ToInt32(minute).ToString();
        }
        else
        {

        }
        string second = st2[2];
        if (Convert.ToInt32(second) < 10)
        {
            second = "0" + Convert.ToInt32(second).ToString();
        }
        else
        {

        }
        string datetime = year + "-" + month + "-" + day + " " + hour + ":" + minute + ":" + second;
        return datetime;
    }
}