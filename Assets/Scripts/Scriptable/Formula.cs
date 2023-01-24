using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Formula_", menuName = "ScriptableObjects /Formula", order = 4)]
public class Formula: ScriptableObject
{
    [SerializeField]
    private List<FormulaElement> _elements;

    [SerializeField]
    private List<Operation> _operations;

    public enum ElementType
    {
        Lvl,
        Income,
        Price,
        Upgrade,
        Const
    }

    public enum Operation
    {
        Plus,
        Minus,
        Multiply
    }

    //формула вводится с раскрытыми скобками(если есть)
    //после умножения и деления остаются только слагаемые
    //складываются, получается результат
    public int GetResult(BusinessModel model)
    {
        var result = 0f; 
        
        var partsAfterMultiply = new List<float>();

        var newElement = getElement(model, _elements[0]);

        //умножение
        for (int i = 0; i < _operations.Count; i++)
        {
            if ((int)_operations[i] == 2)
            {
                newElement *= getElement(model, _elements[i + 1]);
                if (_operations.Count == 1)
                {
                    partsAfterMultiply.Add(newElement);
                }
                else if (_operations.Count - 1 == i)
                {
                    partsAfterMultiply.Add(newElement);
                }
            }
            else
            {
                partsAfterMultiply.Add(newElement);
                for (int j = i + 1; j < _operations.Count; j++)
                {
                    if ((int)_operations[j] == 2)
                    {
                        i = j - 1;
                        newElement = getElement(model, _elements[j]);
                        break;
                    }
                }
            }
        }

        if (_elements.Count == 1)
        {
            result = getElement(model, _elements[0]);
        }
        else
        {
            result = partsAfterMultiply[0];
        }

        //сумма
        var operationIndex = 0;
        for (int i = 1; i < partsAfterMultiply.Count; i++)
        {
            var nextOperation = 0;
            for (int j = operationIndex; j < _operations.Count; j++)
            {
                if ((int)_operations[j] != 2)
                {
                    nextOperation = (int)_operations[j];
                    operationIndex = j + 1;
                    break;
                }
            }
            switch (nextOperation)
            {
                case 0: result += partsAfterMultiply[i]; break;
                case 1: result -= partsAfterMultiply[i]; break;
            }
        }

        return Mathf.FloorToInt(result);
    }

    private float getElement(BusinessModel model, FormulaElement element)
    {
        switch (element.Type)
        {
            case ElementType.Const: return element.Const;
            case ElementType.Income: return model.Template.BaseIncome;
            case ElementType.Price: return model.Template.BasePrice;
            case ElementType.Lvl: return model.Level;
            case ElementType.Upgrade: if (model.Upgrades[element.Index])
                {
                    return model.Template.Upgrades[element.Index].Percent/100f;
                }
                break;
        }
        return 0;
    }

    [Serializable]
    public struct FormulaElement
    {
        [SerializeField]
        private ElementType _type;
        public ElementType Type
        {
            get { return _type; }
        }

        [Header("Константа")]
        [SerializeField]
        private int _const;
        public int Const
        {
            get { return _const; }
        }

        [Header("Номер апгрейда, откуда берется множитель дохода.(Upgrade type)(первый = 0)")]
        [SerializeField]
        private int _index;
        public int Index
        {
            get { return _index; }
        }
    }
}
