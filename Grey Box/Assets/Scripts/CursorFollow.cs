using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorFollow : MonoBehaviour {

    //public Texture2D cursorTexture;
    //public CursorMode cursorMode = CursorMode.Auto;
    //public Vector2 hotSpot;

    // Use this for initialization
    void Start () {
        //hotSpot = new Vector2(183, 259);
        Cursor.visible = false;
       //Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = Input.mousePosition;
    }
}
