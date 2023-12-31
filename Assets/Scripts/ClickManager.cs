using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    private Camera cam;
    public GameManager gameManager;

    private void Awake()
    {
        cam = Camera.main;
        gameManager = this.gameObject.GetComponent<GameManager>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                Collider collider = hitInfo.collider;
                if (collider != null)
                {
                    GameObject clickedObject = collider.gameObject;
                    HandleClickedObject(clickedObject);
                }
            }
        }
    }

    private void HandleClickedObject(GameObject clickedObject)
    {
        SelectPiece selectPieceComponent = clickedObject.GetComponent<SelectPiece>();
        if (selectPieceComponent == null)
        {
            Debug.LogError("SelectPiece component not found on clicked object: " + clickedObject.name);
            return;
        }       
        if (gameManager.isWhiteTurn && selectPieceComponent.pieceColor == "white")
        {
            if (selectPieceComponent) {
            gameManager.pieceSelected(clickedObject, selectPieceComponent, true);
            }
        }
        if (!gameManager.isWhiteTurn && selectPieceComponent.pieceColor == "black")
        {
            
            if (selectPieceComponent) { 
            gameManager.pieceSelected(clickedObject, selectPieceComponent, false);
            }
        }


        //Debug.Log("Clicked object: " + clickedObject.name);
    }
}

