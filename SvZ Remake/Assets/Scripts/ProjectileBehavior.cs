using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    private Transform target;
    public float speed;
    private int damage;

    public float xDistanceThreshold;
    public float yDistanceThreshold;

    public float lifespan;
    private float timer;

    Vector3 currentPosition;

    // Start is called before the first frame update
    void Start()
    {
        timer = lifespan;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
        transform.position += transform.forward * speed * Time.deltaTime;

        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            DestroyProjectile();
        }

      //  if (CheckIfAtTarget() == true)
       // {
        //    Debug.Log("Hit Target");
         //   DamageTarget();
          //  DestroyProjectile();
           // Debug.Log("Finished Hitting");
       // }
    }

    public void IntializeProjectile(Transform transform, int projectileDamage)
    {
        target = transform;
        damage = projectileDamage;
    }

    public void DestroyProjectile()
    {
        Debug.Log("Destroyed Self");
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider lTarget)
    {
        if (lTarget.transform == target)
        {
            Debug.Log("Collided With Target");
            DamageTarget();
            Destroy(gameObject);
        }        
    }

    private bool CheckIfAtTarget()
    {
        float targetX = target.transform.position.x;
        float targetY = target.transform.position.y;
        float projectileX = transform.position.x;
        float projectileY = transform.position.y;

        if ( targetX - projectileX <= xDistanceThreshold && targetY - projectileY <= yDistanceThreshold)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void DamageTarget()
    {
        IDamageable damageableObj = target.GetComponent<IDamageable>();

        if (damageableObj != null)
        {
            Debug.Log("1");
            damageableObj.TakeDamage(damage);
            target = null;
            Debug.Log("3");
        }
        else if (damageableObj == null)
        {
            Debug.Log("Null");
        }
    }
}
