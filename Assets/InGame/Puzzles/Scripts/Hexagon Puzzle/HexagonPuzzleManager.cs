using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexagonPuzzleManager : MonoBehaviour
{
    public delegate void HasEnteredInterface(bool hasEnterd);
    public static HasEnteredInterface onHasEnteredInterface;



    [Header("General")]
    [SerializeField] private HexagonPuzzlePiece[] puzzlePieces;
    [SerializeField] private int totalPieces = 30;

    [Header("UI")]
    [SerializeField] private GameObject interactionPrompt;
    [SerializeField] private GameObject hudUI;
    [SerializeField] private GameObject hexagonUI;

    #region Boolians
    private bool completed = false;
    private bool playerInRange = false;
    private bool playerInteracting = false;
    #endregion


    public static HexagonPuzzleManager instance;
    void Awake()
    {
        if(instance == null) { instance = this; }
        HexagonPuzzlePiece.onCheckForPuzzleCompletion += CheckCompletion;
        totalPieces = puzzlePieces.Length;
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && playerInRange)
        {
            interactionPrompt.gameObject.SetActive(false);
            hudUI.gameObject.SetActive(false);
            hexagonUI.gameObject.SetActive(true);
            playerInteracting = true;
            
            // Turn off player controls
            onHasEnteredInterface(true);
        }
        if(Input.GetKeyDown(KeyCode.Escape) && playerInteracting)
        {
            interactionPrompt.gameObject.SetActive(true);
            hudUI.gameObject.SetActive(true);
            hexagonUI.gameObject.SetActive(false);
            playerInteracting = false;
            
            // Turn on player controls
            onHasEnteredInterface(false);
        }
    }


    public void CheckCompletion()
    {
        int solvedPieces = 0;

        foreach (HexagonPuzzlePiece piece in puzzlePieces)
        {
            for (int i = 0; i < piece.solvedPosition.Length; i++)
            {
                if (piece.currentPosition == piece.solvedPosition[i])
                {
                    solvedPieces++;
                }
            }
        }
        
        if(solvedPieces == totalPieces)
        {
            Debug.Log("You Solved The Puzzle!");
        }
        else
        {
            solvedPieces = 0;
        }
    }

    public void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Triggered!");
        interactionPrompt.gameObject.SetActive(true);
        playerInRange = true;
        
    }

    private void OnTriggerExit(Collider collider)
    {
        interactionPrompt.gameObject.SetActive(false);
        playerInRange = false;
    }
}
