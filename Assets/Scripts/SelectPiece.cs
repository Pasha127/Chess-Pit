using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SelectPiece : MonoBehaviour
{
    GameManager gameManager;
    public Material selectEffectMaterial;
    public string pieceType;
    public string pieceColor;

    // Start is called before the first frame update
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void selectEffect()
    {
        if (this.gameObject != null && selectEffectMaterial != null)
        {
            this.gameObject.GetComponent<MeshRenderer>().material=selectEffectMaterial;
        }
    }
}
