using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{

    [SerializeField] AmmoSlot[] _ammoSlots;
    
    [System.Serializable]
    private class AmmoSlot {
        public AmmoType ammoType;
        public int ammoAmount;
    }

    public int GetCurrentAmmo(AmmoType ammoType) {
        return GetAmmoSlot(ammoType).ammoAmount;
    }

    public void IncreaseAmmoType(AmmoType ammoType, int newAmmo) {
        GetAmmoSlot(ammoType).ammoAmount += newAmmo;
    }

    public void ShootCurrentAmmo(AmmoType ammoType) {
        GetAmmoSlot(ammoType).ammoAmount--;
    }

    private AmmoSlot GetAmmoSlot(AmmoType ammoType) {
        foreach(AmmoSlot slot in _ammoSlots) {
            if(slot.ammoType == ammoType) {
                return slot;
            }
        }

        return null;
    }
}
