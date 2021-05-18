using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdVideo : MonoBehaviour, IUnityAdsListener
{
    public bool showVideo;
    
    private void Start()
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize("4123227");
    }

    // Update is called once per frame
    void Update()
    {
        if (showVideo)
        {
            Advertisement.Show("Interstitial_Android");
            showVideo = false;
        }
    }

    public void OnUnityAdsReady(string placementId)
    {
        throw new NotImplementedException();
    }

    public void OnUnityAdsDidError(string message)
    {
        throw new NotImplementedException();
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        throw new NotImplementedException();
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        throw new NotImplementedException();
    }
}
