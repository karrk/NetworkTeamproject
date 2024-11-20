using UnityEngine;

public class Manager : MonoBehaviour
{
    private static Manager _instance { get; set; }
    
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Init()
    {
        if(_instance == null)
        {
            _instance = FindAnyObjectByType<Manager>();
            DontDestroyOnLoad(_instance);

            _instance.InitManagers();
            _instance.ProgramSetting();
        }
    }

    private void Awake()
    {
        if (_instance != this)
        {
            Destroy(this.gameObject);
        }
    }

    private void InitManagers()
    {
        IManager[] managers = GetComponents<IManager>();

        foreach (var manager in managers)
        {
            manager.Init();
        }
    }

    private void ProgramSetting()
    {
        Application.targetFrameRate = 60;
    }
}