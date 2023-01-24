using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BusinessUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _title;
    [SerializeField]
    private TextMeshProUGUI _level;
    [SerializeField]
    private TextMeshProUGUI _income;

    [SerializeField]
    private LevelButton _levelUpButton;
    [SerializeField]
    private List<UpgradeButton> _upgradeButtons;

    [SerializeField]
    private Slider _progressSlider;

    private BusinessModel _model;

    public void CheckoutModel(BusinessModel model)
    {
        _model = model;

        _title.text = GameData.Instance.Translate.GetTranslation(model.Template.Id);
        _level.text = model.Level.ToString();
        _income.text = model.CurrentIncome.ToString();

        _levelUpButton.Initialize(levelUpHandle);
        _levelUpButton.Checkout(_model.LevelCost);

        //если улучшения может быть не 2, нужны изменения здесь:
        for (int i = 0; i < model.Template.Upgrades.Count; i++)
        {
            _upgradeButtons[i].Initialize(handleUpgradeClicked, i, model.Template.Upgrades[i], model.Upgrades[i]);
        }

        if (model.Level == 0)
        {
            foreach(var button in _upgradeButtons)
            {
                button.SetState(false);
            }
        }
    }

    public void HandleUpdate()
    {
        _progressSlider.value = 1f - _model.Delay / (float)_model.Template.Delay;
        //если зеленая полоса должна уменьшаться:
        //_progressSlider.value =_model.Delay / (float)_model.Template.Delay;
    }

    private void handleUpgradeClicked(int index)
    {
        if (GameData.Instance.PlayerData.Money >= _model.Template.Upgrades[index].Price)
        {
            GameData.Instance.PlayerData.ChangeMoney(_model.Template.Upgrades[index].Price, false);
            _model.SetUpgradePurchased(index);
            _upgradeButtons[index].SetPurchased();
            checkoutText();
        }
    }

    private void levelUpHandle()
    {
        if (GameData.Instance.PlayerData.Money >= _model.LevelCost)
        {
            GameData.Instance.PlayerData.ChangeMoney(_model.LevelCost, false);
            _model.LevelUp();
            _levelUpButton.Checkout(_model.LevelCost);
            checkoutText();
            if (_model.Level == 1)
            {
                foreach(var upgrade in _upgradeButtons)
                {
                    upgrade.SetState(true);
                }
            }
        }
    }

    private void checkoutText()
    {
        _level.text = _model.Level.ToString();
        //string builder +-
        _income.text = _model.CurrentIncome.ToString() + "$";
    }
}
