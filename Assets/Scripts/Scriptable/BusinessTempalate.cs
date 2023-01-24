using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

[CreateAssetMenu(fileName = "Business_", menuName = "ScriptableObjects /BusinessTemplate", order = 3)]
public class BusinessTempalate : ScriptableObject
{
    [SerializeField]
    private string _id;
    public string Id
    {
        //get { return string.Copy(_id); }
        get { return _id; }
    }

    [SerializeField]
    private int _delay;
    public int Delay
    {
        get { return _delay; }
    }

    [SerializeField]
    private int _basePrice;
    public int BasePrice
    {
        get { return _basePrice; }
    }

    [SerializeField]
    private int _baseIncome;
    public int BaseIncome
    {
        get { return _baseIncome; }
    }

    [SerializeField]
    private List<UpgradeTemplate> _upgrades;
    public ReadOnlyCollection<UpgradeTemplate> Upgrades
    {
        get { return _upgrades.AsReadOnly(); }
    }

    [SerializeField]
    private string _incomeFormula;
    public string IncomeFormulaId
    {
        get { return _incomeFormula; }
    }
    
    [SerializeField]
    private string _levelUpFormula;
    public string LevelUpFormula
    {
        get { return _levelUpFormula; }
    }
}

[System.Serializable]
public struct UpgradeTemplate
{
    [SerializeField]
    private string _title;
    public string Title
    {
        get { return _title; }
    }

    [SerializeField]
    private int _price;
    public int Price
    {
        get { return _price; }
    }

    [SerializeField]
    private int _percent;
    public int Percent
    {
        get { return _percent; }
    }
}


