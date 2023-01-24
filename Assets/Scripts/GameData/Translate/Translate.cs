using System.Collections.Generic;
using UnityEngine;

public class Translate
{
    private Dictionary<string, string> _translates;

    public Translate()
    {
        _translates = new Dictionary<string, string>();
        var translation = Resources.Load<TranslateObject>("Settings/Translation");
        for (int i = 0; i < translation.IdList.Count; i++)
        {
            _translates.Add(translation.IdList[i], translation.TranslationList[i]);
        }
    }

    public string GetTranslation(string id)
    {
        return string.Copy(_translates[id]);
    }
}
