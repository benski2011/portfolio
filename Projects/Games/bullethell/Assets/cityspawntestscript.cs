using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cityspawntestscript : MonoBehaviour
{
    [SerializeField]
    public List<GameObject> Objects;
    public Vector3 StartPos;
    public int SpawnOffset;

    int[] rotationDegrees = { 0, 90, 180, 270 };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void RemoveMapItem()
    {
        throw new NotImplementedException();
    }

    private void NewMapItem()
    {
        throw new NotImplementedException();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
