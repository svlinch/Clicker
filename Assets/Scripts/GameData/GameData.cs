using System.Collections;

public class GameData : SingletonStarter<GameData>
{
    public BusinessTemplates BusinessTemplates { get; private set; }
    public Formulas Formulas { get; private set; }
    public Translate Translate { get; private set; }
    public PlayerData PlayerData { get; private set; }

    private SaveController _saveController;

    public override IEnumerator Initialize()
    {
        _saveController = new SaveController();
        BusinessTemplates = new BusinessTemplates();
        Formulas = new Formulas();
        Translate = new Translate();

        yield return StartCoroutine(BusinessTemplates.Initialize());
        yield return StartCoroutine(Formulas.Initialize());

        PlayerData = _saveController.GetSave();
    }

    private void OnApplicationQuit()
    {
        _saveController.HandleSave();
    }

    private void OnApplicationPause(bool pause)
    {
        if (!pause)
        {
            return;
        }
        _saveController.HandleSave();
    }
}
