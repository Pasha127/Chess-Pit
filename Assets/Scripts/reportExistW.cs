using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reportExistW : MonoBehaviour
{
    private GameManager gameManager;

    // Start is called before the first frame update
    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        gameManager.whitePieces.Add(this.gameObject);
    }

    // Update is called once per frame
    void OnDestroy()
    {
        gameManager.whitePieces.Remove(this.gameObject);
    }
}

