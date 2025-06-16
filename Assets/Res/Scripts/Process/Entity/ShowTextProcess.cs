using System.Collections;
using UnityEngine.UI;
using YFramework;
using UnityEngine;

public class ShowTextProcess : BaseProcess
{
    private Text mText;
    private string mContent;
    public ShowTextProcess(Text text,string content)
    {
        mContent = content;
        mText = text;
    }
    public override void Enter()
    {
        base.Enter();
        IEnumeratorModule.StartCoroutine(IEShowContent());
    }
    private IEnumerator IEShowContent() 
    {
        char[] chs = mContent.ToCharArray();
        for (int i = 0; i < chs.Length; i++)
        {
            mText.text += chs[i];
            yield return new WaitForSeconds(0.1f);
        }
        DoNext();
    }
}
