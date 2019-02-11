using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadLevel : MonoBehaviour
{
    public static LoadLevel instance;
    public void LoadLevelFunc(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }

    private void Start()
    {
        if (instance==null)
        {
            instance = this;
        }
    }
}
