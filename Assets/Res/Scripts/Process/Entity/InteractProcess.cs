using YFramework;

public class InteractProcess : BaseProcess
{
    private InteractableGeneral mInteractableGeneral;
    public InteractProcess(InteractableGeneral interactable)
    {
        mInteractableGeneral = interactable;
    }
    public override void Enter()
    {
        base.Enter();
        mInteractableGeneral.onFirstInteract.AddListener(()=>
        {
            DoNext();
        });
    }
    public override void Exit()
    {
        base.Exit();
        mInteractableGeneral.onFirstInteract.RemoveAllListeners();
    }
}
