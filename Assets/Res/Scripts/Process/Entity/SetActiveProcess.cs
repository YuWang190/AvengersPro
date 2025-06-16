using UnityEngine;
using YFramework;

public class SetActiveProcess : BaseProcess
{
    private GameObject mTarget;
    private bool mActive;
    public SetActiveProcess(GameObject target,bool active)
    {
        mTarget = target;
        mActive = active;
    }
    public override void Enter()
    {
        base.Enter();
        mTarget.SetActive(mActive);
        DoNext();
    }
}
