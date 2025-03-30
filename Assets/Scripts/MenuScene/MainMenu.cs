using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void ContinueGame()
    {
        Debug.Log("Continue game (Load dữ liệu nếu có)");
    }

    public void OpenOptions()
    {
        Debug.Log("Mở menu Options");
    }

    public void QuitGame()
    {
        Debug.Log("Thoát game");
        Application.Quit();
    }
}
