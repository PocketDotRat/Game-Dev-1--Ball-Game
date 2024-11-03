using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameManager GameManager;
    public float speed;
    public float jump_force;
    private Rigidbody rb;
    private bool can_jump;

    // Gets the rigidbody of the player which is later used in the movement 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Contains the movement controls 
    private void FixedUpdate()
    {
        // When the player wins, this code will disable the controls
        if (GameManager.score == GameManager.victory_score)
        {
            return;
        }

        // Gets the input and applies the force to move the character
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);

        // Gets the input and applies the force to allow the character to jump
        if (Input.GetKey(KeyCode.Space) && can_jump == true)
        {
            Vector3 jump = new Vector3(0.0f, jump_force, 0.0f);
            rb.AddForce(jump);
            can_jump = false;
        }
    }

    // Deletes the player from existence 
    public void KillPlayer()
    {
        GameManager.Defeated();
        gameObject.SetActive(false);
    }
    void OnTriggerEnter(Collider other)
    {
        // Enables collectibles
        if (other.gameObject.CompareTag("PickUp"))
        {
            //print("Collected");
            Destroy(other.gameObject);
            GameManager.IncreaseScore();
        }

        // Allows the player to jump when they are colliding with the ground
        if (other.gameObject.CompareTag("Ground"))
        {
            //print("On Ground");
            can_jump = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Disables the ability to jump when the player isn't colliding with the ground
        if (other.gameObject.CompareTag("Ground"))
        {
            //print("Left Ground");
            can_jump = false;
        }
    }
}
