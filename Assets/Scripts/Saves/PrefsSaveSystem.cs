using UnityEngine;

public class PrefsSaveSystem : AbstractSaveSystem
{
    public override PlayerData Load()
    {
        if (PlayerPrefs.HasKey("save"))
        {
            return JsonUtility.FromJson<PlayerData>(PlayerPrefs.GetString("save"));
        }
        return null;
    }

    public override void Save(PlayerData data)
    {
        var json = JsonUtility.ToJson(data);

        PlayerPrefs.SetString("save", json);
        PlayerPrefs.Save();
    }
}
