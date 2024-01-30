using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlesManager : MonoBehaviour
{
    [SerializeField] private Transform rotatingPuzzlecameraPozition;
    [SerializeField] private GameObject playerCamera;
    [SerializeField] private Transform playerCameraLocationReference;
    [SerializeField] private bool cameraMoved = false;
    [SerializeField] private PlayerCameraMovemant cameraMovement;
    [SerializeField] private PlayerController controller;
    [SerializeField] private Transform sliderGameCameraPosition;
    [SerializeField] private int solvedPuzzles = 0;
    [SerializeField] private int triedPuzzles = 0;
    [SerializeField] private bool allSolved = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Actions();
    }

    private void Actions()
    {
        CameraChangeDebug();
        if (Input.GetKeyDown(KeyCode.R))
        {
            solvedPuzzles = 0;
            triedPuzzles = 0;
            allSolved = false;
        }
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

    public void SendToPuzzle(GameObject puzzle)
    {
        if (puzzle.tag == "RotatingPuzzle")
        {
            playerCamera.transform.position = rotatingPuzzlecameraPozition.position;
            playerCamera.transform.rotation = rotatingPuzzlecameraPozition.rotation;
        }
        if (puzzle.tag == "JigsawPuzzle")
        {
            playerCamera.transform.position = sliderGameCameraPosition.position;
            playerCamera.transform.rotation = sliderGameCameraPosition.rotation;
        }
        cameraMoved = true;
        cameraMovement.ToogleEngagement();
        controller.ToogleEngagement();
    }
    private void SendToPuzzle()
    {    
        playerCamera.transform.position = rotatingPuzzlecameraPozition.position;
        playerCamera.transform.rotation = rotatingPuzzlecameraPozition.rotation;
        cameraMoved = true;
        cameraMovement.ToogleEngagement();
        controller.ToogleEngagement();
    }
    public void SendCameraBackToBody(bool value)
    {
        if (value)
        {
            solvedPuzzles++;
            if (solvedPuzzles == 2)
            {
                allSolved = true;
            }
        }
        triedPuzzles++;
        playerCamera.transform.position = playerCameraLocationReference.position;
        playerCamera.transform.rotation = playerCameraLocationReference.rotation;
        cameraMoved = false;
        cameraMovement.ToogleEngagement(false);
        controller.ToogleEngagement(false);

    }

    public bool Solved() => allSolved;
    public int PuzzlesTried() => triedPuzzles ;
}
