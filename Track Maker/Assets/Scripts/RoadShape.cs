using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SplineMesh;

public class RoadShape : MonoBehaviour
{
    public SplineExtrusion se;

    public SplineMeshTiling railing1;
    public SplineMeshTiling railing2;

    public float roadWidth;
    public float wallHeight;


    /*
     * SplineExtension Shape Vertices:
     * 
     *
     *   |________________|
     *   1                0
     * 
     */

    // Start is called before the first frame update
    void Start()
    {
        se = GetComponent<SplineExtrusion>();
    }

    // Update is called once per frame
    void Update()
    {
        GenerateRoad();
    }

    [ContextMenu("Generate Road")]
    public void GenerateRoad()
    {
        se.shapeVertices[0].point = new Vector2(-roadWidth / 2, 0);
        se.shapeVertices[1].point = new Vector2(roadWidth / 2, 0);

        railing1.translation.z = -roadWidth / 2;
        railing2.translation.z = roadWidth / 2;

        railing1.scale.y = wallHeight;
        railing2.scale.y = wallHeight;

        railing1.CreateMeshes();
        railing2.CreateMeshes();

        se.SetToUpdate();


    }
}
