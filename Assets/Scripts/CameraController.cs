using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    private float distance = 5.0f;
    private float height = 3.0f;
    private float speed = 10.0f;
    // Start is called before the first frame update
    public void Setup(float distance, float height, float speed)
    {
        this.distance = distance;
        this.height = height;
        this.speed = speed;
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 tmp = (target.forward * distance);
        transform.position = Vector3.Lerp(transform.position, target.position - new Vector3(tmp.x, tmp.y - height, tmp.z), Time.deltaTime * speed);
        transform.LookAt(target);
    }
}
