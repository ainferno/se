using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class MainMenu : MonoBehaviour
{
    public VideoPlayer vP;
    public GameObject playButton;
    public GameObject quitButton;

    void Start()
    {
        vP.loopPointReached += EndReached;
    }

    public void StartGame() {
        playButton.SetActive(false);
        quitButton.SetActive(false);
        vP.Play();
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        GameData.Scene = "Game";
        SceneManager.LoadScene("Loading");
    }

    public void QuitGame() {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
