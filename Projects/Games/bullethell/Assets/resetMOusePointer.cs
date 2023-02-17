using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetMOusePointer : MonoBehaviour
{

    public CursorMode cursorMode = CursorMode.Auto;
    // Start is called before the first frame update


    private void Awake()
    {
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }


}
