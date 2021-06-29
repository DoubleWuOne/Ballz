using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Button m_PlayButton;
    [SerializeField] Button m_QuitButton;
    [SerializeField] Button m_OptionsButton;
    [SerializeField] Button m_BackFromOptionsButton;
    [SerializeField] GameObject m_OptionsMenu;
    [SerializeField] GameObject m_MainMenu;
    public Animator transition;
    private void Start()
    {

        m_PlayButton.onClick.AddListener(PlayGame);
        m_QuitButton.onClick.AddListener(QuitGame);
        m_OptionsButton.onClick.AddListener(GameOptions);
        m_BackFromOptionsButton.onClick.AddListener(BackFromOptions);
    }
    //private void PlayGame()
    //{
    //    StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    //}
    private void PlayGame()
    {
        transition.SetTrigger("Start");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    private void QuitGame()
    {
        Application.Quit();
    }
    private void GameOptions()
    {
        m_MainMenu.SetActive(false);
        m_OptionsMenu.SetActive(true);
    }
    private void BackFromOptions()
    {
        m_MainMenu.SetActive(true);
        m_OptionsMenu.SetActive(false);
    }
    //IEnumerator LoadLevel (int levelIndex)
    //{
    //    transition.SetTrigger("Start");
    //    yield return new WaitForSeconds(0.1f);
    //    SceneManager.LoadScene(levelIndex);
    //}
}
