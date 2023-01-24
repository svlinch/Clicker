using System.Collections;
using UnityEngine;
using TMPro;

public class CanvasController : Starter
{
    [SerializeField]
    private TextMeshProUGUI _moneyText;

    public override IEnumerator Initialize()
    {
        _moneyText.text = GameData.Instance.PlayerData.Money.ToString();
        yield return null;
    }

    public void HandleUpdate()
    {
        if (GameData.Instance.PlayerData.Changed)
        {
            _moneyText.text = GameData.Instance.PlayerData.Money.ToString();
            GameData.Instance.PlayerData.ResetChange();
        }
    }
}
