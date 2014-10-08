using System;

/// <summary>
///HSFReskLevelInfo 的摘要说明
/// </summary>
public class HSFReskLevelInfo
{
    private Guid iMMBD_MaterialID;

    public Guid IMMBD_MaterialID
    {
        get { return iMMBD_MaterialID; }
        set { iMMBD_MaterialID = value; }
    }


    private Guid hSFRL_RiskLevelID;

    public Guid HSFRL_RiskLevelID
    {
        get { return hSFRL_RiskLevelID; }
        set { hSFRL_RiskLevelID = value; }
    }

    private string hSFRL_RiskLeve;

    public string HSFRL_RiskLeve
    {
        get { return hSFRL_RiskLeve; }
        set { hSFRL_RiskLeve = value; }
    }

    private bool hSFRL_IsDeleted;

    public bool HSFRL_IsDeleted
    {
        get { return hSFRL_IsDeleted; }
        set { hSFRL_IsDeleted = value; }
    }
	public HSFReskLevelInfo()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    public HSFReskLevelInfo(Guid _hSFRL_RiskLevelID, string _hSFRL_RiskLeve, bool _hSFRL_IsDeleted)
    {
        hSFRL_RiskLevelID = _hSFRL_RiskLevelID;
        hSFRL_RiskLeve = _hSFRL_RiskLeve;
        hSFRL_IsDeleted = _hSFRL_IsDeleted;
    }
}