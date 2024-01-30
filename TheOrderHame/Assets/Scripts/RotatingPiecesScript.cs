using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class RotatingPiecesScript : MonoBehaviour
{
    [SerializeField] private PuzzlesManager puzzleManagerReference;
    [SerializeField] private int selectedPiece = 0;
    [SerializeField] private Material normalColor;
    [SerializeField] private Material highlightColor;
    [SerializeField] private bool solved = false;
    [SerializeField] private List<GameObject> piecesList;
    // Start is called before the first frame update
    void Start()
    {
        for (int index = 0; index < piecesList.Count; index++)
        {
            piecesList[index].GetComponent<MeshRenderer>().material = normalColor;
            piecesList[index].transform.Rotate(Vector3.forward, 90 * Random.Range(-3, 3));
        }

    }

    // Update is called once per frame
    void Update()
    {
        Actions();
    }

    private void Actions()
    {
        piecesList[selectedPiece].GetComponent<MeshRenderer>().material = highlightColor;
        MovingThroughThePieces();
        RotatePieces();
        CheckIfSolved();
    }


    private void RotatePieces()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            piecesList[selectedPiece].transform.Rotate(Vector3.forward * 90f);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            piecesList[selectedPiece].transform.Rotate(Vector3.forward * -90f);
        }
    }
    
    private void CheckIfSolved()
    {
        if (!solved)
        {
            int notInPlace = 0;
            for (int index = 0; index < piecesList.Count; index++)
            {
                if (piecesList[index].transform.rotation.z / 360 != 0)
                {
                    notInPlace++;
                }
            }
            solved = (notInPlace == 0);
            if (solved)
            {
                new WaitForSeconds(3);
                puzzleManagerReference.SendCameraBackToBody();
            }
        }
        
    }

    private void MovingThroughThePieces()
    {
        for (int index = 0; index < piecesList.Count; index++)
        {
            Debug.Log((int)piecesList[index].transform.eulerAngles.z);
        }
        if (Input.GetKeyDown(KeyCode.A) && selectedPiece > 0)
        {
            piecesList[selectedPiece].GetComponent<MeshRenderer>().material = normalColor;
            selectedPiece -= 1;
        }
        if (Input.GetKeyDown(KeyCode.D) && selectedPiece < piecesList.Count - 1)
        {
            piecesList[selectedPiece].GetComponent<MeshRenderer>().material = normalColor;
            selectedPiece += 1;
        }
        if (Input.GetKeyDown(KeyCode.S) && selectedPiece + 3 <= piecesList.Count - 1)
        {
            piecesList[selectedPiece].GetComponent<MeshRenderer>().material = normalColor;
            selectedPiece += 3;
        }
        if (Input.GetKeyDown(KeyCode.W) && selectedPiece - 3 >= 0)
        {
            piecesList[selectedPiece].GetComponent<MeshRenderer>().material = normalColor;
            selectedPiece -= 3;
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            for (int index = 0; index < piecesList.Count; index++)
            {
                piecesList[index].transform.Rotate(Vector3.forward, -(int)piecesList[index].transform.eulerAngles.z);
            }
        }
    }
}
