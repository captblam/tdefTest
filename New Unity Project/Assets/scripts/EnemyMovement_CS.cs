using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(enemy_CS))]
public class EnemyMovement_CS : MonoBehaviour
{
    private Transform target;
    private int wavePointIndex = 0;

    private enemy_CS enemy;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<enemy_CS>();
        target = WayPoints_CS.waypoints[0];
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if (wavePointIndex >= WayPoints_CS.waypoints.Length - 1)
        {
            WaveSpawner_CS.EnemiesAlive--;
            EndPath();
            return;
        }
        wavePointIndex++;
        target = WayPoints_CS.waypoints[wavePointIndex];
    }
    void EndPath()
    {
        Destroy(gameObject);
    }
}
