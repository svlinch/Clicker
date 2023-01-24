using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    [SerializeField]
    private GameObject _businessPrefab;
    [SerializeField]
    private RectTransform _businessHolder;
    [SerializeField]
    private VerticalLayoutGroup _group;
    private const float HolderSize = 1500f;

    public IEnumerator Initialize(List<BusinessController> businesses)
    {
        var data = GameData.Instance.PlayerData;
        var templates = GameData.Instance.BusinessTemplates;

        //Resources/Settings/BusinessList - список доступных бизнесов
        //Если бизнес уже добавлен в файл сохранения(куплен или игра запущена не впервые), данные берутся оттуда. Иначе создается новая Модель, основываясь на Шаблоне.
        foreach (var template in templates.Templates)
        {
            var id = template.Id;
            var purchased = false;
            var currentModel = new BusinessModel();

            foreach (var model in data.Models)
            {
                if (model.CheckIdEquality(id))
                {
                    currentModel = model;
                    currentModel.SetTemplate(template);
                    purchased = true;
                    break;
                }
            }

            if (!purchased)
            {
                currentModel.Initialize(template);
                data.AddNewBusinessModel(currentModel);
            }

            var business = Instantiate(_businessPrefab, _businessHolder).GetComponent<BusinessController>();

            yield return StartCoroutine(business.Initialize(currentModel));

            businesses.Add(business);
            yield return null;
        }
        _businessHolder.sizeDelta = new Vector2(_businessHolder.sizeDelta.x, businesses.Count * _businessPrefab.GetComponent<RectTransform>().rect.height + _group.padding.top + _group.padding.bottom + _group.spacing * (businesses.Count - 1));
        _businessHolder.anchoredPosition = new Vector2(0, (HolderSize - _businessHolder.sizeDelta.y) / 2);
    }
}
