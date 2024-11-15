using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    public string nextSceneName;
    public int playerLayer;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == playerLayer)
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
