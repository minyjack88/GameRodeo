using UnityEngine;
using System.Collections;

public class Pulling : MonoBehaviour
{

    public GameObject CenterObject;
    public int PullabledLayer;
    private CenterStats cs;

    void start()
    {
        cs = CenterObject.GetComponent<CenterStats>();
    }
    

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.layer == PullabledLayer)
        {
            cs.pullingObject.Add(coll.GetComponent<Rigidbody2D>());
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.layer == PullabledLayer)
        {
            cs.pullingObject.Remove(coll.GetComponent<Rigidbody2D>());
        }
    }
                
}
