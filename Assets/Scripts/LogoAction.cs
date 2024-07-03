using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogoAction : MonoBehaviour
{
    private void Start()
    {
    }

    

    public void NextScene()
    {
        SceneManager.LoadScene(1);
    }
}
