using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Translate", order = 6)]
public class TranslateObject : ScriptableObject
{
    [SerializeField]
    private List<string> _idList;
    public ReadOnlyCollection<string> IdList
    {
        get { return _idList.AsReadOnly(); }
    }

    [SerializeField]
    private List<string> _translationList;
    public ReadOnlyCollection<string> TranslationList
    {
        get { return _translationList.AsReadOnly(); }
    }
}
