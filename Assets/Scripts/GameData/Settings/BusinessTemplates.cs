using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class BusinessTemplates
{
    private List<BusinessTempalate> _templates;
    public ReadOnlyCollection<BusinessTempalate> Templates
    {
        get { return _templates.AsReadOnly(); }
    }

    public IEnumerator Initialize()
    {
        _templates = new List<BusinessTempalate>();

        var list = Resources.Load<AvailableBusinesses>("Settings/BusinessList");
        foreach(var id in list.BusinessesList)
        {
            _templates.Add(Resources.Load<BusinessTempalate>("Businesses/Business_" + id));
            yield return null;
        }
    }
}
