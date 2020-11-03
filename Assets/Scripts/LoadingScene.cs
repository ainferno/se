using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScene : MonoBehaviour
{
    public Slider ProgressBar;
    // Start is called before the first frame update
    void Start() {
        Debug.Log(GameData.Scene);
        StartCoroutine(LoadAsyncOperation());       
    }

    IEnumerator LoadAsyncOperation() {
        AsyncOperation gameLevel = SceneManager.LoadSceneAsync(GameData.Scene);

        while (gameLevel.progress < 1) {
            ProgressBar.value = gameLevel.progress;
            yield return new WaitForEndOfFrame();
        }
    }
}
