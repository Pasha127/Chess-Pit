using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> blackPieces;
    public List<GameObject> whitePieces;
    public bool isWhiteTurn = true;
    public Transform camPointW;
    public Transform camPointB;
    public Camera cam;

    // Start is called before the first frame update
    void Awake()
    {
      
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void switchPlayer()
    {

        if (isWhiteTurn)
        {
            cam.transform.position = camPointB.position;
            cam.transform.rotation = camPointB.rotation;
        }
        else
        {
            cam.transform.position = camPointW.position;
            cam.transform.rotation = camPointW.rotation;  
        }         
        isWhiteTurn = !isWhiteTurn;
    }
}
