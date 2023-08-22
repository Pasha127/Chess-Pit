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
    private GameObject selectedPiece = null;
    private SelectPiece selectedPieceComponent = null;

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

    public void pieceSelected(GameObject go, SelectPiece selecPieceComp, bool isWhite)
    {
        selecPieceComp.selectEffect();
        this.selectedPiece = go;
        this.selectedPieceComponent = selecPieceComp;

        //switchPlayer();
    }
    public void clearSelection()
    {
        selectedPiece = null;
        selectedPieceComponent = null;

    }
    public void findPlaces()
    {
        if (selectedPiece == null) { return; }
        Vector3 anchor = selectedPiece.transform.position;
        
        List<GameObject> places = new List<GameObject>();


        switch (selectedPieceComponent.pieceType)
        {
            case "pawn":
                //add custom loop logic for each case?
                break;
            case "rook":
                break;
            case "knight":
                break;
            case "bishop":
                break;
            case "king":
                break;
            case "queen":
                break;
            default:
                throw new Exception("impossible case reached");

        }

        //create overlapping sphere cast to find places according to distance and direction from piece. 
        List<SelectPlace> selectPlaceComps = new List<SelectPlace>(); 
        Collider[] colliders = Physics.OverlapSphere(ray.origin, 3f);

        foreach (Collider collider in colliders)
        {
            GameObject go = collider.gameObject;
            if (go != null)
            {
                SelectPlace placeComp = go.GetComponent<SelectPlace>();
                if (placeComp != null)
                {
                    selectPlaceComps.Add(placeComp);
                };
            }
        }
        //TODO: nest me correctly
        foreach (SelectPlace selector in selectPlaceComps)
        {
            selector.selectEffect();
        }
    }
}
