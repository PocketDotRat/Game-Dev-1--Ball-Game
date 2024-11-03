using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;

    // Gets the distance between the player and the camera which is used in "LateUpdate" to calculate the position of the camera
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Moves the camera with the player
    // LateUpdate is called once per frame, after everything in Update()
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }

}
