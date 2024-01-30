using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlesManager : MonoBehaviour
{
    [SerializeField] private Transform cameraPorition;
    [SerializeField] private GameObject playerCamera;
    [SerializeField] private Transform playerCameraLocationReference;
    [SerializeField] private bool cameraMoved = false;
    [SerializeField] private PlayerCameraMovemant cameraMovement;
    [SerializeField] private PlayerController controller;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CameraChangeDebug();
    }

    private void CameraChangeDebug()
    {
        if (Input.GetKeyDown(KeyCode.K) && cameraMoved == false)
        {
            SendToPuzzle();
        }
        if (Input.GetKeyDown(KeyCode.L) && cameraMoved == true)
        {
            SendCameraBackToBody();
        }
    }

    public void SendCameraBackToBody()
    {
        playerCamera.transform.position = playerCameraLocationReference.position;
        playerCamera.transform.rotation = playerCameraLocationReference.rotation;
        cameraMoved = false;
        cameraMovement.ToogleEngagement();
        controller.ToogleEngagement();
    }

    private void SendToPuzzle()
    {
        playerCamera.transform.position = cameraPorition.position;
        playerCamera.transform.rotation = cameraPorition.rotation;
        cameraMoved = true;
        cameraMovement.ToogleEngagement();
        controller.ToogleEngagement();
    }
}
