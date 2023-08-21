using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PieceCount : MonoBehaviour
{
    public TextMeshProUGUI text;
    public GameManager gameManager;    

    // Start is called before the first frame update
    void Start()
    {
        text.text = $"{gameManager.whitePieces.Count} White Pieces {gameManager.blackPieces.Count} Black Pieces";
    }

    // Update is called once per frame
    void Update()
    {
        text.text = $"{gameManager.whitePieces.Count} White Pieces {gameManager.blackPieces.Count} Black Pieces. Is it white's turn? {gameManager.isWhiteTurn}";
    }
}
