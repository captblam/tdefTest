using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Mortar_CS : MonoBehaviour
{

    [SerializeField] Transform target;
    [SerializeField] float range = 15;
    [SerializeField] float turnSpeed = 5;
    [SerializeField] float fireRate = 1;
    [SerializeField] float fireCountDown = 0;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public Transform TA;
    public Transform toRotate;
    


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        
        foreach(GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if(nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            return;
        }

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rot = Quaternion.Lerp(toRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        toRotate.rotation = Quaternion.Euler(0f, rot.y, 0f);

        if(fireCountDown <= 0)
        {
            Shoot();
            fireCountDown = 1 / fireRate;
        }
        fireCountDown -= Time.deltaTime;
    }

    void Shoot()
    {
        GameObject bulletGO = (GameObject) Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        bullet_CS bullet = bulletGO.GetComponent<bullet_CS>();

        if(bullet != null)
        {
            bullet.Seek(target);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
