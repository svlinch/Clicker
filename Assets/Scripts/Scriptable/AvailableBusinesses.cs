using System.Collections.ObjectModel;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/AvailableBusinesses", order = 2)]
public class AvailableBusinesses : ScriptableObject
{
    [SerializeField]
    private List<string> _businessesList;

    public ReadOnlyCollection<string> BusinessesList
    {
        get { return _businessesList.AsReadOnly(); }
    }
}
