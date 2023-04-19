using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class gen : MonoBehaviour
{
    public int segmentCount;
    public float maxHeight;
    public float segmentDist;


    // Start is called before the first frame update
    void Start()
    {
        GetComponent<PathCreator> ().bezierPath = GeneratePath(generatePoints(segmentCount, maxHeight, segmentDist));
    }
    Vector2[] generatePoints(int segmentCount, float maxHeight, float segmentDist){
        Vector2 point = GetComponent<Transform>().position;
        Debug.Log(segmentCount);
        float len = segmentDist;
        Vector2[] positions = new Vector2[segmentCount];
        positions[0] = point;
        for(var i = 1; i < segmentCount; i++){
            Vector2 new_point = new Vector2(point.x + len, Random.Range(0, maxHeight));
            len += segmentDist;
            positions[i] = new_point;
        }
        return positions;
    }

    BezierPath GeneratePath(Vector2[] points){
        BezierPath bezierPath = new BezierPath(points, false, PathSpace.xy);
        return bezierPath;
    }

}
