using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    private float movementSpeed = 5.0f;
    private int movementDirection = 0;
    private float topBorder;
    private float bottomBorder;
    private float paddleHalfHeight;


    [SerializeField] private Camera mainCamera;
    [SerializeField] private Renderer paddleRenderer;

    // Start is called before the first frame update
    void Start()
    {
        topBorder = mainCamera.orthographicSize;
        bottomBorder = -1 * topBorder;
        paddleHalfHeight = paddleRenderer.bounds.extents.y;
    }

    // Update is called once per frame
    void Update()
    {
        movementDirection = 0;
        if(Input.GetKey(KeyCode.W))
        {
            movementDirection = 1;
        }
        else if(Input.GetKey(KeyCode.S))
        {
            movementDirection = -1;
        }

        float newYLocation = movementDirection * movementSpeed * Time.deltaTime;
        float paddleTopY = transform.position.y + paddleHalfHeight;
        float paddleBottomY = transform.position.y - paddleHalfHeight;

        if(paddleTopY + newYLocation <= topBorder && paddleBottomY + newYLocation >= bottomBorder)
        {
            transform.Translate(new Vector3(0, newYLocation, 0));
        }
    }
}
