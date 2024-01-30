using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerCameraMovemant : MonoBehaviour
{
    [SerializeField] private float sensitivity = 100f;
    [SerializeField] private float xAxisRotation = 0f;
    [SerializeField] private bool puzzleEngaged = false;
    [SerializeField] private float timer = 100f;
    [SerializeField] private PuzzlesManager puzzlesManagerReference;
    [SerializeField] private Image timerUI;
    [SerializeField] private float currentTime;
    [SerializeField] private TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = timer;
    }

    // Update is called once per frame
    void Update()
    {
        Actions();

    }

    private void Actions()
    {
        if (!puzzleEngaged)
        {
            float verticalMouseMovement = Input.GetAxis("MouseY") * sensitivity * Time.deltaTime;
            xAxisRotation -= verticalMouseMovement;
            xAxisRotation = Mathf.Clamp(xAxisRotation, -90f, 75f);
            transform.localRotation = Quaternion.Euler(xAxisRotation, 0.0f, 0.0f);
            currentTime = timer;
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
        timerUI.fillAmount = currentTime / timer;
        if (puzzleEngaged)
        {
            if (currentTime <= 1f)
            {
                puzzlesManagerReference.SendCameraBackToBody(false);
            }
            currentTime -= 1f * Time.deltaTime;
        }

        if (puzzlesManagerReference.PuzzlesTried() == 2)
        {
            if (puzzlesManagerReference.Solved())
            {
                text.text = "You Won";
            }
            else
            {
                text.text = "You Lost";
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            text.text = "";
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            puzzlesManagerReference.SendCameraBackToBody();
        }
    }

    public void ToogleEngagement()
    {
        puzzleEngaged = !puzzleEngaged;
    }
    public void ToogleEngagement(bool value)
    {
        puzzleEngaged = value;
    }
}
