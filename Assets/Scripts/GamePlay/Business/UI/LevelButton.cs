using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelButton : MonoBehaviour
{
    [SerializeField]
    private Button _button;
    [SerializeField]
    private TextMeshProUGUI _levelCost;
    private Action _callback;

    public void Initialize(Action callback)
    {
        _button.onClick.AddListener(clickHandle);
        _callback = callback;
    }

    public void Checkout(int newCost)
    {
        _levelCost.text = newCost.ToString() + "$";
    }

    private void clickHandle()
    {
        _callback?.Invoke();
    }
}
