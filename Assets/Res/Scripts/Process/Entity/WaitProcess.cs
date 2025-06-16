using UnityEngine;
using YFramework;

public class WaitProcess : BaseProcess
{
    private float mTimer;
    private float mTime;
    public WaitProcess(float time)
    {
        mTime = time;
    }
    public override void Update()
    {
        base.Update();
        mTimer += Time.deltaTime;
        if (mTimer > mTime) 
        {
            DoNext();
        }
    }
}
