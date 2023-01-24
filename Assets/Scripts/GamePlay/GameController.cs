using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : Starter
{
    [SerializeField]
    private CanvasController _canvasController;
    [SerializeField]
    private LevelController _levelController;
    private List<BusinessController> _businesses;

    private bool _pause = true;

    public override IEnumerator Initialize()
    {
        _businesses = new List<BusinessController>();
        yield return StartCoroutine(_levelController.Initialize(_businesses));
        _pause = false;
    }

    private void Update()
    {
        if (_pause)
        {
            return;
        }

        for(var i = 0; i < _businesses.Count; i++)
        {
            _businesses[i].HandleUpdate();
        }

        _canvasController.HandleUpdate();
    }
}
