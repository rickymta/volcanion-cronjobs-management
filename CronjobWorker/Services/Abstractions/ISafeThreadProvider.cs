﻿namespace CronjobWorker.Services.Abstractions;

/// <summary>
/// ISafeThreadProvider
/// </summary>
public interface ISafeThreadProvider
{
    /// <summary>
    /// WaitOne
    /// </summary>
    /// <param name="id"></param>
    public void WaitOne(int id);

    /// <summary>
    /// Release
    /// </summary>
    /// <param name="id"></param>
    public void Release(int id);
}
