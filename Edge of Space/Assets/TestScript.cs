using UnityEngine;
using System.Collections;

public class TestScript : MonoBehaviour {

    public int number = 0;
	// Use this for initialization
	void Start () 
    {
       PolygonCollider2D pc =  GetComponent<PolygonCollider2D>();
       Vector2[] paths = pc.GetPath(0);

       paths[number] = new Vector2(1, 1);
       
        pc.SetPath(0,paths);

	}
	
}
