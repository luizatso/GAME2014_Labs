using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private Boundary screenBounds;

    private BulletManager bulletManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bulletManager = FindAnyObjectByType<BulletManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckBounds();
    }

    private void Move()
    {
        transform.position -= new Vector3(
            0.0f,
            speed * Time.deltaTime,
            0.0f
            );
    }

    private void CheckBounds()
    {
        if (transform.position.y < screenBounds.min)
        {
            //Destroy(gameObject);
            bulletManager.ReturnBullet(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Destroy(gameObject);
            bulletManager.ReturnBullet(gameObject);
            SceneManager.LoadScene("End");
        }
    }
}
