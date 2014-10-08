using System.Web.UI.WebControls;

/// <summary>
///CollectWebControl 的摘要说明
/// </summary>
public class CollectWebControl : WebControl
{
	
    protected WebControl mListControl;
    protected DataControlField mDataControlField;
    private bool BoolIsDataControlField;
    public CollectWebControl(WebControl input)
    {
        mListControl=input;
    }
    public CollectWebControl(DataControlField input)
    {
        mDataControlField = input;
        BoolIsDataControlField = true;
    }

    public void SetVisible(bool IsVisible)
    {
        if (BoolIsDataControlField == true)
        {
            mDataControlField.Visible = IsVisible;
        }
        else
        {
            mListControl.Visible = IsVisible;
        }
    }
    public CollectWebControl()
    {
        BoolIsDataControlField = false;
    }
}