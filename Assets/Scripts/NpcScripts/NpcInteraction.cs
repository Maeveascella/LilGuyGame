using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcInteraction : MonoBehaviour
{
    private PlayerMovement _playerPos;
    private Dialogue _dialogue;
    private bool _inDialogue;
    GameObject interactText;
    public string[] dialogueLines;
    public bool _playerClose;
    // Start is called before the first frame update
    void Start()
    {
        _playerPos = GameObject.Find("Player").GetComponent<PlayerMovement>();
        _dialogue = GameObject.Find("Canvas").GetComponent<Dialogue>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerClose == true)
        {
            if (Input.GetKeyDown(KeyCode.E) && _inDialogue == false)
            {
                _dialogue.StartDialogue(dialogueLines);
                _inDialogue = true;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _playerPos.NearInteractable(true);
            _playerClose = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _playerPos.NearInteractable(false);
            _playerClose = false;
            _inDialogue = false;
        }
    }
}
