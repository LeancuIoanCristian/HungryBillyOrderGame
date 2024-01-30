using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class DragAndDrop : MonoBehaviour
{
    [SerializeField] private GameObject selectedPiece;
    [SerializeField] private List<PiecesFunctionality> piecesJigsaw;
    [SerializeField] private bool solved = false;
    [SerializeField] private Transform deck;
    [SerializeField] private Vector3 mousePosition;
    [SerializeField] private PuzzlesManager puzzleManagerReference;
    [SerializeField] private int inPlaceCounter;
    private void Start()
    {
        SetUp();
    }

    private void SetUp()
    {
        for (int index = 0; index < piecesJigsaw.Count; index++)
        {
            piecesJigsaw[index].MoveToDeck(deck);
        }
        solved = false;
    }

    private void Update()
    {
        Actions();
    }

    private void Actions()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            for (int index = 0; index < piecesJigsaw.Count && !solved; index++)
            {
                piecesJigsaw[index].transform.position = piecesJigsaw[index].GetCorrectPosition();
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SetUp();
        }
        CheckSolution();
    }

    public bool Solved() => solved;
    private void CheckSolution()
    {
        if (!solved)
        {
            inPlaceCounter = piecesJigsaw.Count;
            for (int index = 0; index < piecesJigsaw.Count; index++)
            {
                if (!piecesJigsaw[index].InCorrectPosition())
                {
                    solved = false;
                    break;
                }
                else
                {
                    inPlaceCounter--;
                }
            }
            if (inPlaceCounter == 0)
            {
                solved = true;
                new WaitForSeconds(3);
                puzzleManagerReference.SendCameraBackToBody(true);
            }
        }       
        
    }
}

