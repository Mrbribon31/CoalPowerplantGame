using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class steamProperty : MonoBehaviour
{
    public static steamProperty instance {  get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public float FindCV(float P)
    {
        return ( -4E-06f*Mathf.Pow(P,6) + 0.0002f * Mathf.Pow(P,5) - 0.0036f * Mathf.Pow(P, 4) + 0.0303f * Mathf.Pow(P, 3) - 0.1141f * Mathf.Pow(P, 2) + 0.2276f * P + 1.5454f);
    }

    public float FindBoilTemp(float P)
    {
        return (172.87f * Mathf.Pow(P, 0.2592f));
    }
//    public IEnumerable aaa() 
//    {
//        print
//        yield return new WaitForSecondsRealtime(1);
//    }
// This is a coroutine

}
