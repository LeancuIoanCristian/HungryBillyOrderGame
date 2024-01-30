using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiecesFunctionality : MonoBehaviour
{
    [SerializeField] private Vector3 correctPosition;
    [SerializeField] private bool inCorrectPosition = false;
    [SerializeField] private bool selected = false;
    [SerializeField] private Vector3 mousePosition;
    // Start is called before the first frame update
    void Start()
    {
       
       
    }

    // Update is called once per frame
    void Update()
    {
        PlacementChecker();

    }

    private void PlacementChecker()
    {
        if (Vector3.Distance(transform.position, correctPosition) < 0.5f)
        {
            if (!selected)
            {
                transform.position = correctPosition;
                inCorrectPosition = true;
            }
        }
    }

    private void OnMouseDown()
    {
        mousePosition = Input.mousePosition - GetMousePosition();
    }
    private void OnMouseDrag()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition);
    }
    private Vector3 GetMousePosition() => Camera.main.WorldToScreenPoint(transform.position);

    public Vector3 GetCorrectPosition() => correctPosition;

    public void Selected(bool value)
    {
        selected = value;
    }

    public void MoveToDeck(Transform location)
    {
        correctPosition = transform.position;
        transform.position = location.position;
    }
    public bool InCorrectPosition() => inCorrectPosition;
}
