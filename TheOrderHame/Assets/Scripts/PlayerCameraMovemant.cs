using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraMovemant : MonoBehaviour
{
    [SerializeField] private float sensitivity = 100f;
    [SerializeField] private float xAxisRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float verticalMouseMovement = Input.GetAxis("MouseY") * sensitivity * Time.deltaTime;
        xAxisRotation -= verticalMouseMovement;
        xAxisRotation = Mathf.Clamp(xAxisRotation, -90f, 75f);
        transform.localRotation = Quaternion.Euler(xAxisRotation, 0.0f, 0.0f);
    }
}
