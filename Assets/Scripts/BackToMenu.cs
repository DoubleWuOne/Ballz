using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackToMenu : MonoBehaviour
{
    [SerializeField] Button m_QuitButton;
    void Start()
    {
        m_QuitButton.onClick.AddListener(QuitGame);
    }

    private void QuitGame()
    {    
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
