using UnityEngine;
using YFramework;

public class GameCenter : MonoBehaviour
{
    public static GameCenter Instance;
    public ProcessController processController { get; private set; }
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Launcher()
    {
        GameObject gameManager = new GameObject(typeof(GameCenter).Name);
        GameObject.DontDestroyOnLoad(gameManager);
        Instance = gameManager.AddComponent<GameCenter>();
    }

    private void Awake()
    {
        processController = new ProcessController();
    }

    void Update()
    {
        processController.Update();
    }
}
