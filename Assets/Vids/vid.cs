using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class vid : MonoBehaviour
{
    public VideoPlayer vP;
    void Start()
    {
        vP.loopPointReached += EndReached;
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        SceneManager.LoadSceneAsync(1);
    }
}