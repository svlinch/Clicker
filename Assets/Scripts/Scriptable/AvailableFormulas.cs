using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/AvailableFormulas", order = 5)]
public class AvailableFormulas : ScriptableObject
{
    [SerializeField]
    private List<string> _formulas;
    public ReadOnlyCollection<string> Formulas
    {
        get { return _formulas.AsReadOnly(); }
    }
}
