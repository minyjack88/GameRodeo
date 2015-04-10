using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pullabled: MonoBehaviour
{
    public List<GameObject> pullingObject;

    public int weight = 1;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pullingObject = new List<GameObject>();
    }

    void FixedUpdate()
    { 
        foreach( GameObject go in pullingObject)
        {
         MoveTo(go);  
        }
    }


    void MoveTo(GameObject go)
    {

        float forceAmount = go.GetComponent<CenterStats>().pullForceAmount;
        rb.AddForce((go.transform.position - transform.position).normalized * forceAmount * Time.smoothDeltaTime);
    }

}
