using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class daciagamestart : MonoBehaviour
{
    public static bool GameStart = false;
    public static int DaciaHighscore = 0;
    public static int DaciaPrevScore = 0;

    // Start is called before the first frame update
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    public int wh = 100;


    void Start()
    {
        cursorTexture.Resize(wh, wh);

        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }
    void OnMouseEnter()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }
}
