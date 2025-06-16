using JW;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using YFramework;

public static class HttpModule
{
    private static Dictionary<string, Sprite> mSpriteDic;

    /// <summary>
    /// 加载图片
    /// </summary>
    /// <param name="url"></param>
    /// <param name="callBack"></param>
    public static void DownLoadImage(string url, Action<Sprite> callBack,Action<string> error = null) 
    {
        IEnumeratorModule.StartCoroutine(DownloadImage(url, callBack,error));
    }

    private static IEnumerator DownloadImage(string url,Action<Sprite> callBack, Action<string> error)
    {
        if (url.IsNullOrEmpty())
        {
            error?.Invoke("url is null");
            yield break;
        }

        if (mSpriteDic == null) mSpriteDic = new Dictionary<string, Sprite>();
        if (mSpriteDic.ContainsKey(url))
        { 
            callBack?.Invoke(mSpriteDic[url]);
            yield break;
        }
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);
        yield return request.SendWebRequest();
        if (request.result == UnityWebRequest.Result.Success)
        {
            Texture2D texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
            Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            callBack?.Invoke(sprite);
            mSpriteDic.Add(url,sprite);
        }
        else
        {
            error?.Invoke("Error downloading image: " + request.error);
            Debug.LogError("Error downloading image: " + request.error);
        }
    }

    /// <summary>
    /// 发送请求
    /// </summary>
    /// <param name="url"></param>
    /// <param name="jsonData"></param>
    /// <param name="success"></param>
    /// <param name="fail"></param>
    public static void GetData<TS>(string url, Action<TS> success, Action<string> fail) where TS : ResponseJsonBase
    {
        IEnumeratorModule.StartCoroutine(IEGetData(url, success, fail));
    }
    /// <summary>
    /// 发送请求
    /// </summary>
    /// <param name="url"></param>
    /// <param name="jsonData"></param>
    /// <param name="success"></param>
    /// <param name="fail"></param>
    public static void PostData<TS>(string url, object jsonTarget, Action<TS> success, Action<string> fail) where TS : ResponseJsonBase
    {
        if (jsonTarget == null)
        {
            fail?.Invoke("Json target is null!");
            return;
        }
        string json = UnityEngine.JsonUtility.ToJson(jsonTarget);
        IEnumeratorModule.StartCoroutine(IEPostData(url, json, success, fail));
    }
    /// <summary>
    /// 发送请求
    /// </summary>
    /// <param name="url"></param>
    /// <param name="jsonData"></param>
    /// <param name="success"></param>
    /// <param name="fail"></param>
    public static void PostData(string url, object jsonTarget, Action<string> success, Action<string> fail)
    {
        if(jsonTarget == null) 
        {
            fail?.Invoke("Json target is null!");
            return;   
        }
        PostData(url, UnityEngine.JsonUtility.ToJson(jsonTarget), success, fail);
    }
    /// <summary>
    /// 发送请求
    /// </summary>
    /// <param name="url"></param>
    /// <param name="jsonData"></param>
    /// <param name="success"></param>
    /// <param name="fail"></param>
    public static void PostData(string url,string jsonData, Action<string> success, Action<string> fail) 
    {
        IEnumeratorModule.StartCoroutine(IEPostData(url, jsonData, success, fail));
    }

    private static IEnumerator IEPostData(string url, string jsonData,Action<string> success,Action<string> fail)
    {
        UnityWebRequest request = new UnityWebRequest(url, "POST");
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonData);
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        request.SetRequestHeader("Authorization", $"Bearer {AppVarData.Token}");
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            string responseText = request.downloadHandler.text;
            Debug.Log("PostData:"+ responseText);
            success?.Invoke(responseText);
        }
        else
        {
            Debug.LogError("PostError:" + request.error);
            fail?.Invoke(request.error);
        }
    }
    private static IEnumerator IEGetData<TS>(string url,Action<TS> success, Action<string> fail) where TS : ResponseJsonBase
    {
        UnityWebRequest request = new UnityWebRequest(url, "GET");
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("X-Authorization", $"Bearer {AppVarData.Token}");
        yield return request.SendWebRequest();
        if (request.result == UnityWebRequest.Result.Success)
        {
            string responseText = request.downloadHandler.text;
            TS res = JsonUtility.FromJson<TS>(responseText);
            if (res == null)
            {
                Debug.LogError("Response value is null");
                fail?.Invoke("Response value is null");
            }
            else if (res.code != 200)
            {
                Debug.LogError("URL:"+ url + "GetData:   Code:" + res.code + "Msg:" + res.msg);
                fail?.Invoke("Code:" + res.code + "Msg:" + res.msg);
                AppTools.Toast("Code:" + res.code + "Msg:" + res.msg);
            }
            else
            {
                Debug.Log("GetData:" + responseText);
                success?.Invoke(res);
            }
        }
        else
        {
            Debug.LogError("GetError:" + request.error);
            fail?.Invoke(request.error);
        }
    }

    private static IEnumerator IEPostData<TS>(string url, string jsonData, Action<TS> success, Action<string> fail) where TS : ResponseJsonBase
    {
        UnityWebRequest request = new UnityWebRequest(url, "POST");
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonData);
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        request.SetRequestHeader("X-Authorization", $"Bearer {AppVarData.Token}");
        yield return request.SendWebRequest();
        if (request.result == UnityWebRequest.Result.Success)
        {
            string responseText = request.downloadHandler.text;
            TS res = JsonUtility.FromJson<TS>(responseText);
            if (res == null)
            {
                Debug.LogError("Response value is null");
                fail?.Invoke("Response value is null");
            }
            else if (res.code !=200)
            {
                Debug.LogError("URL:" +url+"PostData:   Code:" + res.code + "Msg:" + res.msg);
                fail?.Invoke("Code:"+ res.code +"Msg:" + res.msg);
                AppTools.Toast("Code:" + res.code + "Msg:" + res.msg);
            }
            else
            {
                Debug.Log("URL:"+ url + " PostData:" + responseText);
                success?.Invoke(res);
            }
        }
        else
        {
            Debug.LogError("PostError:" + request.error);
            fail?.Invoke(request.error);
        }
    }
}
