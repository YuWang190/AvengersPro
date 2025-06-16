using UnityEngine;
using UnityEngine.UI;
using YFramework;

public class Part1Manager : MonoBehaviour
{
    public GameObject chatBG;
    public Text chatContent;
    public InteractableGeneral toHospital;
    void Start()
    {
       IProcess process =   GameCenter.Instance.processController.Create()
            .Concat( new  SetActiveProcess(chatBG,true))
            .Concat( new  ShowTextProcess(chatContent, "When I woke up, I felt dizzy, nauseous and had a fever. Please take me to a nearby large general hospital for treatment"))
            .Concat( new WaitProcess(2))
            .Concat(new SetActiveProcess(toHospital.gameObject,true))
            .Concat( new InteractProcess(toHospital))
            .Concat( new LoadSceneProcess("Part2"))
            ;
        process.processManager.Launcher();
    }
}
