using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public float panSpeed = 0.2f;
    public float panBoarderTickness = 1f;
    public float scrollSpeed = 20f;
    public float minY = 20f;
    public float maxY = 120f;
	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.position;
        if (Input.GetKey("w"))
            pos.y += panSpeed * Time.deltaTime;
        if (Input.GetKey("s"))
            pos.y -= panSpeed * Time.deltaTime;
        if (Input.GetKey("d"))
            pos.x += panSpeed * Time.deltaTime;
        if (Input.GetKey("a"))
            pos.x -= panSpeed * Time.deltaTime;
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        pos.y -= scroll * scrollSpeed * 10f * Time.deltaTime;
        transform.position = pos;
    }
}
