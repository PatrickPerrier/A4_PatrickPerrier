using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    float minX = -10f;

    [SerializeField]
    float maxX = 10f;

    [SerializeField]
    float maxY = 10f;

    [SerializeField]
    float minY = -10f;

    private Vector3 newPos;

    [SerializeField]
    GameObject target;

    private void Start()
    {
       // target = GetComponent<GameObject>();
    }

    private void Update()
    {
        //mainCamera.transform.position = new Vector3(transform.position.x, transform.position.y, -10);
        // if (newPos.x > minX && newPos.x < maxX && newPos.y > minY && newPos.y < maxY)
        //     transform.position = newPos;

        transform.position = new Vector3(Mathf.Clamp(target.transform.position.x, minX, maxX), Mathf.Clamp(target.transform.position.y, minY, maxY), -10);
    }
    
}
