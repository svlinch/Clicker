using System.Collections;
using UnityEngine;

public class BusinessController : MonoBehaviour
{
    [SerializeField]
    private BusinessUI _businessUI;

    private BusinessModel _model;

    public IEnumerator Initialize(BusinessModel model)
    {
        _model = model;
        model.CheckoutFormulas();
        _businessUI.CheckoutModel(model);
        yield return null;
    }

    public void HandleUpdate()
    {
        if (_model.Level > 0)
        {
            _model.HandleUpdate();
            _businessUI.HandleUpdate();
        }
    }
}
