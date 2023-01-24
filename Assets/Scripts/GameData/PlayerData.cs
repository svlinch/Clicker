using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

[Serializable]
public class PlayerData
{
    [SerializeField]
    private int _money;
    public int Money
    {
        get { return _money; }
    }

    [SerializeField]
    private List<BusinessModel> _models;
    public ReadOnlyCollection<BusinessModel> Models
    {
        get { return _models.AsReadOnly(); }
    }

    public bool Changed { get; private set; }

    public void ChangeMoney(int amount, bool plus)
    {
        _money += plus ? amount : -amount;
        Changed = true;
    }

    public void ResetChange()
    {
        Changed = false;
    }

    public void AddNewBusinessModel(BusinessModel newModel)
    {
        foreach(var model in _models)
        {
            if (model.Template.Id.Equals(newModel.Template.Id))
            {
                return;
            }
        }
        _models.Add(newModel);
    }
}
