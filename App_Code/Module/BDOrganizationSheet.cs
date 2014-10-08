/// <summary>
///BDOrganizationSheet 的摘要说明
/// </summary>
public class BDOrganizationSheet
{

    private string bDOS_Code;

    public string BDOS_Code1
    {
        get { return bDOS_Code; }
        set { bDOS_Code = value; }
    }
    private string bDOS_Name;
    private bool bDOS_Isdeleted;

    public BDOrganizationSheet()
	{
		
	}
    public BDOrganizationSheet(string _bDOS_Code, string _bDOS_Name, bool _bDOS_Isdeleted)
    {
        bDOS_Code = _bDOS_Code;
        bDOS_Name = _bDOS_Name;
        bDOS_Isdeleted = _bDOS_Isdeleted;                                  
    }

    public string BDOS_Code
    {
        get { return BDOS_Code1; }
        set { BDOS_Code1 = value; }
    }
    public string BDOS_Name
    {
        get { return bDOS_Name; }
        set { bDOS_Name = value; }
    }
    public bool BDOS_Isdeleted
    {
        get { return bDOS_Isdeleted; }
        set { bDOS_Isdeleted = value; }
    }
	
}
