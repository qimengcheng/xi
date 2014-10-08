/* ==============================================================================
 * 类名称：BLLMatchNumber 
 * 类的作用描述:这个类是BLL层的基类，里面共享了一些BLL需要的公共函数，避免了代码重复
 * 创建人：bush2582
 * 创建时间：1/9/2014 10:26
 * 修改人：
 * 修改时间：
 * 修改备注：
 * @version 1.0
 * ==============================================================================*/
using System;
using System.Text.RegularExpressions;
/// <summary>
/// 这个类是BLL层的基类，里面共享了一些BLL需要的公共函数，避免了代码重复
/// </summary>
public class BLLMatchNumber
{

    /// <summary>
    /// 函数名：IsMatchInt
    /// 作者：bush2582
    /// 作用：匹配字符串是否全为整数，且是否符合上下界
    /// 返回值：是否符合条件
    /// </summary>
    /// <param name="WantToMatch">要匹配的字符串</param>
    /// <param name="Low">上界</param>
    /// <param name="Upper">下界</param>
    /// <returns>返回是否匹配</returns>
    public bool IsMatchInt(string WantToMatch, int Low, int Upper)
    {
        if (Regex.IsMatch(WantToMatch, "^([0-9]{1,})$")==false)
        {
            return false;
        }
        else if ((Convert.ToInt32(WantToMatch) < Upper) && (Convert.ToInt32(WantToMatch) > Low))
        {
            return true;
        }
        else
        {
            return false;
        }  
    }

    /// <summary>
    /// 函数名：IsMatchInt
    /// 作者：bush2582
    /// 作用：匹配字符串是否全为整数，且是否符合下界
    /// 返回值：是否符合条件
    /// </summary>
    /// <param name="WantToMatch">要匹配的字符串</param>
    /// <param name="Low">整数的下界</param>
    /// <returns>是否匹配</returns>
    public bool IsMatchInt(string WantToMatch, int Low)
    {
        if (Regex.IsMatch(WantToMatch, "^([0-9]{1,})$") == false)
        {
            return false;
        }
        else if ( (Convert.ToInt32(WantToMatch) > Low) )//匹配下界
        {
            return true;
        }
        else
        {
            return false;
        }  
    }


    /// <summary>
    /// 函数名：IsMatchDecimal
    /// 作者：bush2582
    /// 作用：匹配字符串是否全为小数，且是否符合上下界
    /// 返回值：是否符合条件
    /// </summary>
    /// <param name="WantToMatch">要匹配的字符串</param>
    /// <param name="Low">上界</param>
    /// <param name="Upper">下界</param>
    /// <returns>返回是否匹配</returns>
    public bool IsMatchDecimal(string WantToMatch, Decimal Low, Decimal Upper)
    {
        if (Regex.IsMatch(WantToMatch, "^([0-9]{1,}[.][0-9]*)$") == false)
        {
            return false;
        }
        else if ((Convert.ToDecimal(WantToMatch) < Upper) && (Convert.ToDecimal(WantToMatch) > Low))
        {
            return true;
        }
        else
        {
            return false;
        }  
    }
	public BLLMatchNumber()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}