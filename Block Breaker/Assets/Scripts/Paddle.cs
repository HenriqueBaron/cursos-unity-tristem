using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public bool autoPlay = false;

    private Ball ball;

    // Use this for initialization
    void Start()
    {
        ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!autoPlay) MoveWithMouse();
        else AutoPlay();
    }

    private void MoveWithMouse()
    {
        float paddleWidth = GetComponent<SpriteRenderer>().bounds.size.x;
        float mousePositionInBlocks = Mathf.Clamp(Input.mousePosition.x / Screen.width * 16, paddleWidth / 2, 16f - paddleWidth / 2);
        Vector3 newPaddlePos = new Vector3(mousePositionInBlocks, transform.position.y, transform.position.z);
        transform.position = newPaddlePos;
    }

    void AutoPlay()
    {
        Vector3 newPaddlePos = new Vector3(ball.transform.position.x, this.transform.position.y, this.transform.position.z);
        transform.position = newPaddlePos;
    }
}
