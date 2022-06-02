using UnityEngine;
using Dreamteck.Splines;


public class PathController : MonoBehaviour
{
    //public Transform[] objects;
    public SplineMesh roadSpline;
    public SplineMesh leftWallSpline,rightWallSpline;
    private SplinePoint[] points;
    public SplineComputer splineComputer;

    public void GeneratePath(int limit, float width, float length, GameObject startPoint, GameObject endPoint)
    {
        splineComputer.type = Spline.Type.Linear;
        points = new SplinePoint[limit + 2];
        points[0] = new SplinePoint();
        points[0].position = startPoint.transform.position;
        points[0].normal = Vector3.up;
        points[0].size = 1f;
        points[0].color = Color.white;
        for (int i = 0; i < limit; i++)
        {
            points[i + 1] = new SplinePoint();
            points[i + 1].position = new Vector3(Random.Range(0.0f, width), 0.0f, Random.Range(points[i].position.z, length / limit * (i + 1))); ;
            points[i + 1].normal = Vector3.up;
            points[i + 1].size = 1f;
            points[i + 1].color = Color.white;
        }
        points[limit + 1] = new SplinePoint();
        points[limit + 1].position = endPoint.transform.position;
        points[limit + 1].normal = Vector3.up;
        points[limit + 1].size = 1f;
        points[limit + 1].color = Color.white;
        splineComputer.SetPoints(points);
    }
    public void SetRoadData(float roadWidth)
    {
        roadSpline.channels[0].minScale = new Vector3(roadWidth, 1.0f, 1.0f);
        rightWallSpline.channels[0].meshes[0].offset = new Vector3(roadWidth/2.0f+0.5f, 2, 0);
        leftWallSpline.channels[0].meshes[0].offset = new Vector3(-roadWidth / 2.0f - 0.5f, 2, 0);
        roadSpline.Rebuild();
        rightWallSpline.Rebuild();
        leftWallSpline.Rebuild();
    }

    public void SetStartFinishPoint(Transform player, Transform finish)
    {
        player.position = (points[0].position * 9 / 10 + points[1].position / 10) + Vector3.up;
        player.LookAt(points[1].position);
        finish.position = (points[points.Length - 1].position * 9 / 10 + points[points.Length - 2].position / 10) + Vector3.up;
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
