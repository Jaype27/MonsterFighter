using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas _gameOverCanvas;
    [SerializeField] Canvas _endGameCanvas;

    void Start() {
        _gameOverCanvas.enabled = false;
        _endGameCanvas.enabled = false;
    }

    public void HandleDeath() {
        _gameOverCanvas.enabled = true;
        Time.timeScale = 0;
        FindObjectOfType<WeaponSwap>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void EndGame() {
        _endGameCanvas.enabled = true;
        Time.timeScale = 0;
        FindObjectOfType<WeaponSwap>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
