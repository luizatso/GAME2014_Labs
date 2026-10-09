using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] float horizontalForce;

    [SerializeField] Boundary bounds;

    [SerializeField]
    [Range(0.0f, 1.0f)]
    float decay;

    private Rigidbody2D rigidBody;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckBounds();
    }

    private void FixedUpdate()
    {
        rigidBody.linearVelocity *= decay;
    }

    private void Move()
    {
        float x = GetTouchDirection();

        rigidBody.AddForce(new Vector2(x * horizontalForce, 0.0f));
    }

    private float GetTouchDirection()
    {
        if (Touchscreen.current == null)
        {
            return 0.0f;
        }

        var touch = Touchscreen.current.primaryTouch;

        if (!touch.press.isPressed)
        {
            return 0.0f;
        }

        Vector2 pos = touch.position.ReadValue();

        if (pos.x < Screen.width / 2.0f)
        {
            return -1.0f;
        }

        return 1.0f;
    }

    private void CheckBounds()
    {
        if (transform.position.x < bounds.min)
        {
            transform.position = new Vector2(
                bounds.min,
                transform.position.y
            );
        }
        if (transform.position.x > bounds.max)
        {
            transform.position = new Vector2(
                bounds.max,
                transform.position.y
            );
        }
    }
}
