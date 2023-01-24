using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/FreshSave", order = 1)]
public class FreshSave: ScriptableObject
{
    [SerializeField]
    private PlayerData _data;
    public PlayerData Data
    {
        get { return _data; }
    }
}
