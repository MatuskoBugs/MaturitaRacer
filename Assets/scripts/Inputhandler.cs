using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inputhandler : MonoBehaviour
{
    public int playerNumber = 1;

    CarController carController;

    private void Awake()
    {
        carController = GetComponent<CarController>();
    }



    // Update is called once per frame
    void Update()
    {
        Vector3 inputVector = Vector3.zero;
        switch (playerNumber)
        {
            case 1:
                inputVector.x = Input.GetAxis("Horizontal");
                inputVector.y = Input.GetAxis("Vertical");
                inputVector.x = Input.GetAxis("JHorizontal");
                inputVector.y = Input.GetAxis("JVertical");
                break;
            case 2:
                inputVector.x = Input.GetAxis("Horizontal_P2");
                inputVector.y = Input.GetAxis("Vertical_P2");
                inputVector.x = Input.GetAxis("JHorizontal_P2");
                inputVector.y = Input.GetAxis("JVertical_P2");
                break;
            case 3:
                inputVector.x = Input.GetAxis("Horizontal_P3");
                inputVector.y = Input.GetAxis("Vertical_P3");
                inputVector.x = Input.GetAxis("JHorizontal_P3");
                inputVector.y = Input.GetAxis("JVertical_P3");
                break;
            case 4:
                inputVector.x = Input.GetAxis("Horizontal_P4");
                inputVector.y = Input.GetAxis("Vertical_P4");
                inputVector.x = Input.GetAxis("JHorizontal_P4");
                inputVector.y = Input.GetAxis("JVertical_P4");
                break;
        }

        carController.SetInputVector(inputVector);
    }
}
