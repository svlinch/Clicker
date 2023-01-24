using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System;
using TMPro;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField]
    private Button _button;
    [SerializeField]
    private TextMeshProUGUI _title;
    [SerializeField]
    private TextMeshProUGUI _percent;
    [SerializeField]
    private TextMeshProUGUI _priceTitle;
    [SerializeField]
    private TextMeshProUGUI _price;

    private Action<int> _callback;
    private int _index;

    public void Initialize(Action<int> callback, int index, UpgradeTemplate upgrade, bool purchased)
    {
        _button.onClick.AddListener(clickHandle);

        _callback = callback;
        _index = index;

        _title.text = GameData.Instance.Translate.GetTranslation(upgrade.Title);

        var sb = new StringBuilder();

        sb.Append("+");
        sb.Append(upgrade.Percent.ToString());
        sb.Append("%");

        _percent.text = sb.ToString();

        sb.Clear();

        if (purchased)
        {
            SetPurchased();
        }
        else
        {
            sb.Append(upgrade.Price.ToString());
            sb.Append("$");
            _price.text = sb.ToString();
        }
    }

    public void SetState(bool state)
    {
        _button.interactable = state;
    }

    public void SetPurchased()
    {
        //translate
        _priceTitle.text = "Куплено";
        _price.enabled = false;
        _button.interactable = false;
    }

    private void clickHandle()
    {
        _callback?.Invoke(_index);
    }
}
