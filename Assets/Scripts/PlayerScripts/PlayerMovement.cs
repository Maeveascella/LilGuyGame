using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    private bool _canJump;
    public GameObject interactText;
    public bool interactIsActive;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal, 0, vertical);
        transform.Translate(direction * 6 * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && _canJump == true)
        {
            _canJump = false;
            rb.AddForce(new Vector3(0, 400, 0));
        }
        if (transform.position.y <= -3)
        {
            transform.position = new Vector3(0, 1.5f, 0);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        _canJump = true;
    }

    public void NearInteractable(bool nearby)
    {
        interactText.SetActive(nearby);
        interactIsActive = nearby;
    }
    
}
