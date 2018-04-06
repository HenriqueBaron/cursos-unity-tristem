using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormationController : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float width = 10f;
    public float height = 5f;
    private float spawnDelay = 0.5f;
    public Vector2 startVelocity = new Vector2(3, 0);

    private float xMin;
    private float xMax;
    private Vector3 velocity;

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
    }

    // Use this for initialization
    void Start()
    {
        SpawnEnemies();

        velocity = startVelocity;

        float zDistance = transform.position.z - Camera.main.transform.position.z;
        xMin = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, zDistance)).x + width / 2;
        xMax = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, zDistance)).x - width / 2;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = transform.position + velocity * Time.deltaTime;

        if (newPosition.x > xMax || newPosition.x < xMin)
        {
            velocity.x *= -1;
            if (newPosition.x > xMax) newPosition.x = xMax;
            else newPosition.x = xMin;
        }

        transform.position = newPosition;

        if (AllMembersDead())
            SpawnUntilFull();

    }

    Transform NextFreePosition()
    {
        foreach (Transform childPositionGameObject in transform)
        {
            if (childPositionGameObject.childCount <= 0) return childPositionGameObject.transform;
        }
        return null;
    }

    bool AllMembersDead()
    {
        foreach (Transform childPositionGameObject in transform)
        {
            if (childPositionGameObject.childCount > 0) return false;
        }
        return true;
    }

    private void SpawnEnemies()
    {
        foreach (Transform child in transform)
        {
            GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = child;
        }
    }

    private void SpawnUntilFull()
    {
        Transform freePosition = NextFreePosition();
        if (freePosition)
        {
            GameObject enemy = Instantiate(enemyPrefab, freePosition.transform.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = freePosition;
            Invoke("SpawnUntilFull", spawnDelay);
        }
    }
}
