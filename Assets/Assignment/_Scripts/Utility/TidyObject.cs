
using UnityEngine;

public class TidyObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public static void DestroyObject(GameObject obj, float time)
    {
        Destroy(obj, time);
    }

}
