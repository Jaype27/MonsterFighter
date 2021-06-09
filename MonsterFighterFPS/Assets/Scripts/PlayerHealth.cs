using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float _maxPlayerHealth = 25f;
    [SerializeField] Text _healthText;

    float _playerHealth;

    void Start() {
        _playerHealth = _maxPlayerHealth;
    }

    void Update() {
        DisplayHealth();
    }

    void DisplayHealth() {
        _healthText.text = _playerHealth.ToString();
    }

    public void DamageTaken(float damage) {
        
        _playerHealth -= damage;

        if(_playerHealth <= 0) {

            GetComponent<DeathHandler>().HandleDeath();
        }
    }

    public void RestoreHealth(float restore) {
        _playerHealth += restore;
        if(_playerHealth > _maxPlayerHealth) {
            _playerHealth = _maxPlayerHealth;

        }
    }
}
