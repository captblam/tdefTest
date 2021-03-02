using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEditor;
using UnityEngine;

public class bullet_CS : MonoBehaviour
{

    private Transform target;
    public GameObject impactEffect;
    [SerializeField] float speed = 70;
    [SerializeField]int damage;
    [SerializeField] float dmgRange;
    

    public void Seek(Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

    }

    void HitTarget()
    {
        GameObject EffectInstance = (GameObject) Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(EffectInstance, 2f);

        if (dmgRange > 0)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }

        Destroy(gameObject);
    }
    
    void Damage(Transform enemy)
    {
        enemy_CS e = enemy.GetComponent<enemy_CS>();
        if (e != null)
        {
            e.TakeDamage(damage);
        }
    }

    void Explode() 
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, dmgRange);
        foreach(Collider collider in colliders)
        {
            if (collider.tag == "enemy")
            {
                Damage(collider.transform);
            }
        }

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, dmgRange);
    }

}
