using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class Menu : MonoBehaviour
{
    public void OnStartButton()
    {
        AudioManager.Instance.StopMusic();
        Destroy(AudioManager.Instance);
        SceneManager.LoadScene(1);
    }

    public void OnQuitButton()
    {
#if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
