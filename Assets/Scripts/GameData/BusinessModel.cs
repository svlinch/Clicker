using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BusinessModel
{
    [SerializeField]
    private string _id;

    [SerializeField]
    private int _level;
    public int Level
    {
        get { return _level; }
    }

    [SerializeField]
    private List<bool> _upgrades;
    public ReadOnlyCollection<bool> Upgrades
    {
        get { return _upgrades.AsReadOnly(); }
    }

    [SerializeField]
    private float _delay;
    public float Delay
    {
        get { return _delay; }
    }

    public int CurrentIncome { get; private set; }
    public int LevelCost { get; private set; }
    public BusinessTempalate Template { get; private set; }

    public void Initialize(BusinessTempalate template)
    {
        _id = template.Id;
        Template = template;
        _upgrades = new List<bool>();

        foreach(var upgrade in template.Upgrades)
        {
            _upgrades.Add(false);
        }

        _delay = Template.Delay;
    }

    public void SetTemplate(BusinessTempalate template)
    {
        Template = template;
    }

    public void HandleUpdate()
    {
        _delay -= Time.deltaTime;
        if (_delay <= 0f)
        {
            _delay = Template.Delay;
            GameData.Instance.PlayerData.ChangeMoney(CurrentIncome, true);
        }
    }

    public void SetUpgradePurchased(int index)
    {
        _upgrades[index] = true;
        CheckoutFormulas();
    }

    public void LevelUp()
    {
        _level++;
        CheckoutFormulas();
    }

    public void CheckoutFormulas()
    {
        if (Level == 0)
        {
            CurrentIncome = Template.BaseIncome;
            LevelCost = Template.BasePrice;
            return;
        }
        CurrentIncome = GameData.Instance.Formulas.GetFormula(Template.IncomeFormulaId).GetResult(this);
        LevelCost = GameData.Instance.Formulas.GetFormula(Template.LevelUpFormula).GetResult(this);
    }

    public bool CheckIdEquality(string id)
    {
        return id.Equals(_id);
    }
}
