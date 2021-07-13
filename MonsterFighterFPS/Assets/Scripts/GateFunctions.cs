using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateFunctions : MonoBehaviour
{
    
    Animator _anim;
    BoxCollider _boxCollider;
    
    // Start is called before the first frame update
    void Start() {
        _anim = GetComponent<Animator>();
        _boxCollider = GetComponent<BoxCollider>();
    }

    public void GateOpen() {
        _anim.SetTrigger("open");
        _boxCollider.enabled = false;
    }
}
