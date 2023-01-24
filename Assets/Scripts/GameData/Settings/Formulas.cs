using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Formulas
{
    private Dictionary<string, Formula> _formulas;

    public IEnumerator Initialize()
    {
        _formulas = new Dictionary<string, Formula>();

        var list = Resources.Load<AvailableFormulas>("Settings/FormulaList");
        foreach (var id in list.Formulas)
        {
            _formulas.Add(id, Resources.Load<Formula>("Formulas/" + id));
            yield return null;
        }
    }

    public Formula GetFormula(string id)
    {
        return _formulas[id];
    }
}
