using YFramework;

public class LoadSceneProcess : BaseProcess
{
    private string mSceneName;
    public LoadSceneProcess(string sceneName)
    {
        mSceneName = sceneName;
    }
    public override void Enter()
    {
        base.Enter();
        DoNext();
        UnityEngine.SceneManagement.SceneManager.LoadScene(mSceneName);
    }
}
