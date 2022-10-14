using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cityspawntestscript : MonoBehaviour
{
    [SerializeField]
    public List<GameObject> Objects;
    public List<GameObject> ObjectPool;

    public List<GameObject> CurrentActive;

    public Vector3 StartPos;
    public int SpawnOffset;

    public float speed =0.2f;

    int[] rotationDegrees = { 0, 90, 180, 270 };


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < Objects.Count; i++)
        {
            for (int ii = 0; ii < 5; ii++)
            {
                GameObject temp = Instantiate(Objects[ii], new Vector3(999,999,999), Quaternion.identity);
                int rot = UnityEngine.Random.Range(0, 4);
                temp.transform.Rotate(0, rotationDegrees[rot], 0);
                temp.transform.SetParent(this.gameObject.transform);
                ObjectPool.Add(temp);
                temp.SetActive(false);            
            }
        }

        Debug.Log(ObjectPool.Count);
        for (int i = 0; i < 4; i++)
        {

            int RandomInt = UnityEngine.Random.Range(0, ObjectPool.Count);
            Debug.Log(RandomInt);

            GameObject tile = ObjectPool[RandomInt];
            tile.SetActive(true);
            Debug.Log(StartPos);
            tile.transform.localPosition = StartPos;
            CurrentActive.Add(tile);
            StartPos.z += 60;
        }
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
    void FixedUpdate()
    {
        for (int i = 0; i < CurrentActive.Count; i++)
        {

            CurrentActive[i].gameObject.transform.localPosition = 
                new Vector3(CurrentActive[i].gameObject.transform.localPosition.x , 
                CurrentActive[i].gameObject.transform.localPosition.y, CurrentActive[i].gameObject.transform.localPosition.z - speed);

            if (CurrentActive[i].gameObject.transform.localPosition.z < -65)
            {
                //delete the game object
                //instantinate new gameobject at xxx, add it to list 
                int RandomInt = UnityEngine.Random.Range(0, ObjectPool.Count);
                Debug.Log(RandomInt);

                GameObject tile = ObjectPool[RandomInt].gameObject;
                tile.SetActive(true);
                tile.transform.localPosition = new Vector3(CurrentActive[CurrentActive.Count - 1].transform.localPosition.x ,
                    CurrentActive[CurrentActive.Count - 1].transform.localPosition.y, CurrentActive[CurrentActive.Count - 1].transform.localPosition.z + 60);
                    
                GameObject ToBeDeleted = CurrentActive[i].gameObject;
                CurrentActive.RemoveAt(i);
                CurrentActive.Add(tile);
                ObjectPool.Add(ToBeDeleted);
                ToBeDeleted.transform.position = new Vector3(999, 999, 999);
                ToBeDeleted.SetActive(false);
                //Destroy(ToBeDeleted);


            }
        }
    }

    
}
