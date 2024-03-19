using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomScale : MonoBehaviour
{
    public PlayerScale ps;

    public Transform player;

    public void Start()
    {
        transform.position = transform.localPosition;
    }
    // Update is called once per frame
    void Update()
    {
        float playerX = player.position.x;
        float playerZ = player.position.z;

        float cameraScale = ps.scale;

        float cameraX = playerX;
        float cameraY = (cameraScale + 10) * 1.2f;
        float cameraZ = playerZ + -(cameraScale + 10) * 1.2f;

        Vector3 newCameraPos = new Vector3(cameraX, cameraY, cameraZ);

        transform.position = newCameraPos;
    }
}
