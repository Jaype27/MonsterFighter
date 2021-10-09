using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayCastInteract : MonoBehaviour
{

    [SerializeField] Camera _fpsCamera;
    [SerializeField] float _range;
    [SerializeField] int _fuses = 0;
    [SerializeField] Canvas _interactText;
    [Range(2f, 5f)] [SerializeField] float _messageDuration = 2f;
    [SerializeField] Canvas _messageText;
    [SerializeField] Text _fuseAmount;
    [SerializeField] AudioSource[] _characterSFX;


    // Start is called before the first frame update
    void Start()
    {
        _messageText.enabled = false;
        _interactText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        ProcessRayCast();
        DisplayFuse();
    }

    void ProcessRayCast()
    {
        RaycastHit hit;

        if (Physics.Raycast(_fpsCamera.transform.position, _fpsCamera.transform.forward, out hit, _range))
        {
            if (hit.transform.tag == "Gate")
            {
                _interactText.enabled = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (_fuses >= 3)
                    {
                        GateFunctions gateFunctions = hit.transform.GetComponent<GateFunctions>();
                        if (gateFunctions == null) return;
                        gateFunctions.GateOpen();
                    }
                    else
                    {
                        StartCoroutine(GameMessage());
                    }
                }
            }
            else if (hit.transform.tag == "End")
            {
                _interactText.enabled = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    GetComponent<DeathHandler>().EndGame();
                }
            }
        }
        else
        {
            _interactText.enabled = false;
            return;
        }

    }

    IEnumerator GameMessage()
    {
        _messageText.enabled = true;
        yield return new WaitForSeconds(_messageDuration);
        _messageText.enabled = false;
    }

    void DisplayFuse()
    {
        _fuseAmount.text = _fuses.ToString();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Fuse")
        {
            _characterSFX[2].Play();
            other.gameObject.SetActive(false);
            _fuses++;
        }

        if(other.gameObject.tag == "Pickup" || other.gameObject.tag == "Weapon") 
        {
            _characterSFX[0].Play();
        }

        if (other.gameObject.tag == "Heal")
        {
           _characterSFX[1].Play();
        }
    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _range);
    }
}
