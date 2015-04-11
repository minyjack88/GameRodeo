using UnityEngine;
using System.Collections;

public class TractorBeam : Pulling {

    private PolygonCollider2D myCollider;
    public float startSize = 3;
    private float size;
    

    void Start()
    {
        cs = CenterObject.GetComponent<CenterStats>();
        myCollider = GetComponent<PolygonCollider2D>();
        SetSize(startSize);
        gameObject.SetActive(false);
    }

	
    public void SetSize(float newSize)
    {
        size = newSize;
        Vector2[] pathVec = myCollider.GetPath(0);
		
        Vector2 dircetionVector1 = (pathVec[0] - pathVec[1]).normalized;
        Vector2 dircetionVector2 = (pathVec[3] - pathVec[2]).normalized;
		
        pathVec[0] = pathVec[1] + (dircetionVector1 * size);
        pathVec[3] = pathVec[2] + (dircetionVector2 * size);

        myCollider.SetPath(0, pathVec);
    }



    public float GetSize()
    {
        return size;
    }
}
