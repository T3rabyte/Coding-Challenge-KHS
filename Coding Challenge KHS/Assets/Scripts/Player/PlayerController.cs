using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private float playerSpeed = 5f;

    private void Start()
    {
        // always add a controller
        controller = gameObject.AddComponent<CharacterController>();
    }

    void Update()
    {
        float xDir = Input.GetAxis("Horizontal");
        float zDir = Input.GetAxis("Vertical");

        Vector3 move = transform.right * xDir + transform.forward * zDir;

        controller.Move(move * playerSpeed * Time.deltaTime);
    }
}