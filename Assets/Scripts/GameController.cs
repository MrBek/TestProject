using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("Player data")]
    public float playerSpeed;
    public PlayerController playerController;
    [Header("Camera data")]
    public float camSpeed;
    public float camDistance;
    public float camHeight;
    public CameraController camController;
    [Header("Plane data")]
    public float regLength;
    public float regWidth;
    public GameObject finishPoint;
    [Header("Road data")]
    public float roadWidth;
    public int pointLimit;
    public PathController pathController;
    // Start is called before the first frame update
    void Start()
    {
        createGama();
        setupCamera();
        StartCoroutine(startGame());
    }
    public void createGama()
    {
        playerController.transform.position = new Vector3(Random.Range(0.0f, regWidth), 0.0f, 0.0f);
        finishPoint.transform.position = new Vector3(Random.Range(0.0f, regWidth), 0.0f, regLength);
        pathController.GeneratePath(pointLimit, regWidth, regLength, playerController.gameObject, finishPoint);
        pathController.SetRoadData(roadWidth);
        pathController.SetStartFinishPoint(playerController.transform, finishPoint.transform);
    }
    public void setupCamera()
    {
        camController.setup(camDistance, camHeight, camSpeed);
    }

    public IEnumerator startGame()
    {
        yield return new WaitForEndOfFrame();
        playerController.agent.destination = playerController.goal.position;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
