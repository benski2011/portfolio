using UnityEditor;
using UnityEngine;

public class addrandomness : MonoBehaviour
{
    public static int i = 0;

        [MenuItem("Tools/Count Scene Objects")]
        public static void Execute()
        {
            GameObject count = GameObject.Find("trees");
            foreach (Transform child in count.transform)
            {
                float rand = (Random.Range(-30.0f, 30.0f)/100)+1;
                float tempy = (child.transform.localScale.y* rand);
                child.transform.localScale = new Vector3(child.transform.localScale.x, tempy, child.transform.localScale.z);

            }
        Debug.Log(i);
        }
    
}
