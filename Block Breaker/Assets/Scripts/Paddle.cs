using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float mousePositionInBlocks = Mathf.Clamp(Input.mousePosition.x / Screen.width * 16, 0.5f, 15.5f);
        Vector3 newPaddlePos = new Vector3(mousePositionInBlocks, transform.position.y, transform.position.z);
        transform.position = newPaddlePos;
    }
}
