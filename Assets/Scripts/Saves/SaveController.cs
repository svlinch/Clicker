using UnityEngine;

public class SaveController
{
    private AbstractSaveSystem _saveSystem;

    public SaveController()
    {
        _saveSystem = new PrefsSaveSystem();
    }

    public PlayerData GetSave()
    {
        var data = _saveSystem.Load();
        if (data == null)
        {
            data = Resources.Load<FreshSave>("Settings/FreshSave").Data;
        }
        return data;
    }

    public void HandleSave()
    {
        _saveSystem.Save(GameData.Instance.PlayerData);
    }
}
