using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private Boundary movementBounds;
    [SerializeField] private Boundary startingXRange;
    [SerializeField] private Boundary startingYRange;

    private Vector2 startingPoint;

    private float randomSpeed;

    [SerializeField] private Transform bulletSpawn;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private int shotDelay = 10;
    private BulletManager bulletManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bulletManager = FindAnyObjectByType<BulletManager>();

        randomSpeed = Random.Range(
            movementBounds.min,
            movementBounds.max
            );
        
        startingPoint = new Vector2(
            Random.Range(
                startingXRange.min,
                startingXRange.max
            ),
            Random.Range(
                startingYRange.min,
                startingYRange.max
            )
        );

        transform.position = startingPoint;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(
            movementBounds.min + Mathf.PingPong(
                Time.time * randomSpeed + startingPoint.x - movementBounds.min,
                movementBounds.max - movementBounds.min
            ),
            transform.position.y
        );
    }

    private void FixedUpdate()
    {
        if (Time.frameCount % shotDelay == 0)
        {
            //var bullet = Instantiate(bulletPrefab);
            //bullet.transform.position = bulletSpawn.position;
            bulletManager.GetBullet(bulletSpawn.position);
        }
    }
}
