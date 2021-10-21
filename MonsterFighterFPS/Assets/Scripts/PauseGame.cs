using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    
    [SerializeField] Canvas _pauseMenu;
    
    void Update() {
        PauseMenu();
    }
    
    void PauseMenu() {
        if(Input.GetKeyDown(KeyCode.P)) {
            _pauseMenu.enabled = true;
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void ContinueGame() {
        Time.timeScale = 1;
        _pauseMenu.enabled = false;
    }
}
