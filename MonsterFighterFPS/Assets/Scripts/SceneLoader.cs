using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] GameObject _controlPanel;
    [SerializeField] GameObject _gameElements;
    [SerializeField] GameObject _menuElements;
    
    public void StartGame() {
        _gameElements.SetActive(true);
        _menuElements.SetActive(false);
        // SceneManager.LoadScene("Main");
    }

    public void Controls() {
        _controlPanel.SetActive(true);
    }

    public void PlayAgain() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        Time.timeScale = 1;
    }
    
    public void QuitGame() {
        Application.Quit();
    }

    public void BackButton() {
        _controlPanel.SetActive(false);
    }
}
