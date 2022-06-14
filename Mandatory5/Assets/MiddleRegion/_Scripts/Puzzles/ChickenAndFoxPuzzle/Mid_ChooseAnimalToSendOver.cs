using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mid_ChooseAnimalToSendOver : MonoBehaviour
{
    public Mid_Shore midShoreScript;
    public Mid_Boat midBoat;

    private void Start()
    {
        CloseCanvas();
    }
    public void OpenCanvas()
    {
        gameObject.GetComponent<CanvasGroup>().alpha = 1;
        gameObject.GetComponent<CanvasGroup>().interactable = true;
        gameObject.GetComponent<CanvasGroup>().blocksRaycasts = true;
        Time.timeScale = 0f;
    }
    public void CloseCanvas()
    {
        gameObject.GetComponent<CanvasGroup>().alpha = 0;
        gameObject.GetComponent<CanvasGroup>().interactable = false;
        gameObject.GetComponent<CanvasGroup>().blocksRaycasts = false;
        Time.timeScale = 1f;
    }
    public void ChooseAnimal1()
    {
        midShoreScript.chosenAnimal = 0;
        midBoat.seatOneFilled = false;
        CloseCanvas();
    }
    public void ChooseAnimal2()
    {
        midShoreScript.chosenAnimal = 1;
        CloseCanvas();
    }
}
