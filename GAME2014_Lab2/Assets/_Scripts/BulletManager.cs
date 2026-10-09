using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    private Queue<GameObject> pool;

    [SerializeField] private int bulletNumber = 50;

    [SerializeField] private GameObject bulletPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pool = new Queue<GameObject>();
        BuildBulletPool();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void BuildBulletPool()
    {
        for (int i = 0; i < bulletNumber; i++)
        {
            var bullet = Instantiate(bulletPrefab);
            bullet.transform.SetParent(transform);
            bullet.SetActive(false);
            pool.Enqueue(bullet);
        }
    }

    public GameObject GetBullet(Vector3 spawnPosition)
    {
        if (pool.Count < 1)
        {
            AddBullet();
        }

        var bullet = pool.Dequeue();
        bullet.transform.position = spawnPosition;
        bullet.SetActive(true);
        return bullet;
    }

    public void ReturnBullet(GameObject bullet)
    {
        bullet.SetActive(false);
        pool.Enqueue(bullet);
    }

    private void AddBullet()
    {
        var bullet = Instantiate(bulletPrefab);
        bullet.transform.SetParent(transform);
        bullet.SetActive(false);
        pool.Enqueue(bullet);
        bulletNumber++;
    }
}
