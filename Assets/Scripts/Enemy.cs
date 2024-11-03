using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameManager game_manager;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Will kill the player if they collide with this object
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player.gameObject)
        {
            //print("Hit!");
            player.GetComponent<PlayerController>().KillPlayer();
        }
    }
}
