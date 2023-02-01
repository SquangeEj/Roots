using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private LayerMask layerMask;
    private Mesh mesh;
    private Vector3 origin;
    private float startingAngle;
    public float viewDistance = 25f;
    [SerializeField]    private float fov = 90;
    private void Start()
    {
         mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
         origin = Vector3.zero;
    }
    void LateUpdate()
    {



        int rayCount = 50;
        float angle = startingAngle;
        float angleIncrease = fov / rayCount;
       
        Vector3[] vertices = new Vector3[rayCount+1 +1];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount*3];


        vertices[0] = origin;

        int vertexIndex = 1;
        int triangleIndex = 0;
        for(int i = 0; i <= rayCount; i++)
        {
            
            float angleRad = angle * (Mathf.PI / 180f);
              Vector3 AngleOrigin = new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));

            Vector3 vertex;

           RaycastHit2D raycastHit2D = Physics2D.Raycast(origin, AngleOrigin, viewDistance,layerMask);
            if(raycastHit2D.collider == null)
            {
                // no hit
                vertex = origin + AngleOrigin * viewDistance;
            }
            else
            {
                // hit
                vertex = raycastHit2D.point;
            }
            vertices[vertexIndex] = vertex;

            if (i > 0) {
                triangles[triangleIndex + 0] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                triangles[triangleIndex + 2] = vertexIndex;
                triangleIndex += 3;
            }

            vertexIndex++;
          

            angle -= angleIncrease;
        }

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
        mesh.RecalculateBounds();

    }

    public void SetOrigin(Vector3 origin)
    {
        this.origin = origin;
    }

    public void SetAimDirection(Vector3 direction)
    {
        startingAngle = GetAngleFromVectorFloat(direction) + fov/2f;
            
    }
    private float GetAngleFromVectorFloat(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;
        
        return n;
    }

}
