﻿using HiFramework;
using UnityEngine;

/// <summary>
/// Resource文件夹下异步加载
/// </summary>
public class AsyncResourceLoadTask : AsyncTask
{
    private ResourceRequest resourceRequest;

    /// <summary>
    /// resource文件夹下路径
    /// </summary>
    /// <param name="param"></param>
    public AsyncResourceLoadTask(string param)
    {
        resourceRequest = Resources.LoadAsync(param);
    }

    protected override void Update()
    {
        if (resourceRequest.isDone)
            isDone = true;
    }

    protected override void Complate()
    {
        action(resourceRequest.asset);
    }
}
