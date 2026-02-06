using UnityEngine;

public class BallMovement : MonoBehaviour
{
    private Vector3 ballDirection;
    private float ballSpeed = 5.0f;
    private float topBorder;
    private float bottomBorder;
    private float ballTopY;
    private float ballRightX;
    private float cameraWidth;

    private int hit = 0;

    [SerializeField] private Camera mainCamera;
    [SerializeField] private Renderer ballRenderer;
    [SerializeField] private Renderer paddleRenderer;

    void Start()
    {
        hit = 0;
        ballTopY = ballRenderer.bounds.extents.y;
        ballRightX = ballRenderer.bounds.extents.x;
        topBorder = mainCamera.orthographicSize + mainCamera.transform.position.y;
        bottomBorder = mainCamera.transform.position.y - mainCamera.orthographicSize;

        cameraWidth = mainCamera.orthographicSize * mainCamera.aspect;

        float randomYDirection = Random.Range(0.1f, 1.0f);
        if(Random.Range(0, 10) < 5)
        {
            randomYDirection *= -1;
        }
        ballDirection = new Vector3(-1, randomYDirection, 0).normalized;
    }

    void Update()
    {
        Vector3 paddleMinBound = paddleRenderer.bounds.min;
        Vector3 paddleMaxBound = paddleRenderer.bounds.max;

        //top bottom border collision        
        Vector3 newPosition = transform.position + ballDirection * ballSpeed * Time.deltaTime;
        if(newPosition.y + ballTopY >= topBorder || newPosition.y - ballTopY <= bottomBorder)
        {
            ballDirection.y *= -1;
        }

        float ballLeft = newPosition.x - ballRightX;
        float ballRight = newPosition.x + ballRightX;
        float ballTop = newPosition.y + ballTopY;
        float ballBottom = newPosition.y - ballTopY;

        bool overlapWithPaddle = ballRight >= paddleMinBound.x && 
                                    ballLeft <= paddleMaxBound.x &&
                                    ballBottom <= paddleMaxBound.y &&
                                    ballTop >= paddleMinBound.y;

        //paddle collision
        if(overlapWithPaddle && ballDirection.x < 0)
        {
            ballDirection.x *= -1;
            ballSpeed *= 1.1f;
            transform.position += new Vector3(paddleMaxBound.x + ballRightX + 0.01f - newPosition.x, 0, 0);
            hit++;
            Debug.Log("Hits: " + hit);
        }

        //right border collision
        if(newPosition.x + ballRightX >= mainCamera.transform.position.x + cameraWidth)
        {
            if(ballDirection.x > 0)
            {
                ballDirection.x *= -1;
            }
        }

        transform.Translate(ballDirection * ballSpeed * Time.deltaTime);
    }
}
