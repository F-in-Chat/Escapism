using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexagonPuzzlePiece : MonoBehaviour
{
    public delegate void CheckForPuzzleCompletion();
    public static CheckForPuzzleCompletion onCheckForPuzzleCompletion;
    
    public int currentPosition = 0;
    public int setPosition = 0;
    public int[] solvedPosition;
    private int currentRotation;
    private bool rotate = true;

    private void OnEnable()
    {
        SetInitialRotation();
    }

    private void OnDisable()
    {
        currentPosition = 0;
    }

    // Occurs through UI Buttons 
    // Clicking on the tile selects the tile, then A/D or the joystick will rotate the tile?
    public void RotatePiece()
    {
        if(rotate)
        {
            if(currentPosition >= 5)
            {
                currentPosition = 0;
            }
            else
            {
                currentPosition++;
            }
            currentRotation += 60;
            this.transform.rotation = Quaternion.Euler(0,0,currentRotation);   
        }
        onCheckForPuzzleCompletion();
    }

    // Setting the initial position of the puzzle piece 0 - 5
    private void SetInitialRotation()
    {
        // Current position should always be 0 when they open the puzzle
        for(int i = currentPosition; i < setPosition; i++)
        {
            RotatePiece();
        }
    }
}
