using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private CharacterController playerBody;
    [SerializeField] private float sensitivity = 100f;
    [SerializeField] private bool puzzleEngaged = false;

    // Update is called once per frame
    void Update()
    {
        if (!puzzleEngaged)
        {
            float xInput = Input.GetAxisRaw("Horizontal");
            float zInput = Input.GetAxisRaw("Vertical");
            float horizontalMouseMovement = Input.GetAxis("MouseX") * sensitivity * Time.deltaTime;

            Vector3 moveDirection = transform.right * xInput + transform.forward * zInput;
            playerBody.Move(moveDirection * speed * Time.deltaTime);

            playerBody.transform.Rotate(Vector3.up * horizontalMouseMovement);
        }
        
    }

    public void ToogleEngagement()
    {
        puzzleEngaged = !puzzleEngaged;
    }
}
