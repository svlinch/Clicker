using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{
    [SerializeField]
    private List<Starter> _loadList;

    private IEnumerator Start()
    {
        foreach(var script in _loadList)
        {
            yield return StartCoroutine(script.Initialize());
            Debug.Log(string.Format("{0} Initialized", script.name));
        }
    }
}
