using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Restart : MonoBehaviour
{
    [SerializeField] Button but;
    void Start()
    {
        but.onClick.AddListener(Restartg);
    }

    private void Restartg()
    {
       // Application.LoadLevel(Application.loadedLevel);
        SceneManager.LoadScene("MainGame");
    }
}
