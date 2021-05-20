using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int _damage = 8;

    public int GetDamage() {
        return _damage;
    }
}
