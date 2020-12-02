using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePawn : MonoBehaviour
{
    public enum ObjectType
    {
        PLAYER,
        ALLY,
        ENEMY
    }

    [System.Serializable]
    public class AllyStats
    {
        public ObjectType objType;       // The Defined Type: Enemy | Player | Etc.
        [Header("Health Values")]
        public int maxHealth;            // The Max Health
        public int currentHealth;        // The Current Health At Any Given Time
        [Header("Damage Values")]
        public int meleeDamage;          // The Value Of A Melee Attack
        public int rangedDamage;         // The Value Of A Ranged Attack
        [Header("Speed Values")]
        public float currentSpeed;       // The Current Speed At Any Given Time
        public float defaultSpeed;       // The Default Speed | Not To Mistaken With The Current Speed
    }

    public AllyStats stats = new AllyStats();

    public LayerMask whatIsEnemies;      // The Layer To Search For Enemies When Attacking

    //Ranged Variables
    public GameObject projectilePrefab;  // Reference To The Projectile Prefab

    [Header("Attack Settings")]

    // Melee Variables
    public Transform meleeAttackPos;     // The Position Of The Origin Of The Melee Attack Box
    public float meleeAttackRangeX;      // The X Value For The Melee Attack Box
    public float meleeAttackRangeY;      // The Y Value For The Melee Attack Box
    
    [Space(10)]

    public float startTimeBtwAttack;     // Actual Cooldown Value | Used To Reset Cooldown
    private float timeBtwAttack;         // Attack Cooldown Current Time


    public List<GameObject> enemiesToShoot = new List<GameObject>();    
      
    private void Start()
    {
        stats.currentSpeed = stats.defaultSpeed;
    }

    public void HandleMovement()
    { 
        switch (stats.objType)
        {
            case ObjectType.ALLY:
                transform.Translate(Vector2.right * stats.currentSpeed * Time.deltaTime);
                break;
            case ObjectType.ENEMY:
                transform.Translate(Vector2.left * stats.currentSpeed * Time.deltaTime);
                break;
            default:
                break;
        }
    }

    public void HandleAttack()
    {
        if (timeBtwAttack <= 0)
        {
            // NOTE: Melee Targets Will Be Prioritized Ranged
            Collider[] enemiesToMelee = Physics.OverlapBox(meleeAttackPos.position, new Vector2(meleeAttackRangeX / 2, meleeAttackRangeY / 2), Quaternion.identity, whatIsEnemies);

            if (enemiesToMelee.Length > 0)
            {
                for (int i = 0; i < enemiesToMelee.Length; i++)
                {
                    IDamageable lTarget = enemiesToMelee[i].GetComponent<IDamageable>();

                    if (lTarget != null)
                    {
                        enemiesToMelee[i].GetComponent<IDamageable>().TakeDamage(stats.meleeDamage);
                    }                    
                }
                // Start Attack Cooldown
                timeBtwAttack = startTimeBtwAttack;
            }
            // If No Enemies Were Found To Melee, Search For Enemies To Shoot
            else if (enemiesToMelee.Length <= 0)
            {
                if (enemiesToShoot.Count > 0)
                {
                    if (IsEnemyAlive(enemiesToShoot[0]))
                    {
                        Transform target = enemiesToShoot[0].transform;
                        if (target != null)
                        {
                            ShootEnemy(target);
                        }
                    }
                    else
                    {
                        enemiesToShoot.RemoveAt(0);
                    }                                      
                }
                timeBtwAttack = startTimeBtwAttack;
            }
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }

    public void ShootEnemy(Transform _target)
    {
        var newProjectileObj = Instantiate(projectilePrefab);
        newProjectileObj.transform.position = meleeAttackPos.position;

        ProjectileBehavior projectileBehavior = newProjectileObj.GetComponent<ProjectileBehavior>();
        projectileBehavior.IntializeProjectile(_target, stats.rangedDamage);
    }

    // For Detecting Ranged Targets
    private void OnTriggerEnter(Collider collidedEnemy)
    {
        if (collidedEnemy != null)
        {
            //  *** Need To Research This Statement | It Works But I Dont Know Why ***
            if ((whatIsEnemies & 1 << collidedEnemy.gameObject.layer) == 1 << collidedEnemy.gameObject.layer)
            {
                enemiesToShoot.Add(collidedEnemy.gameObject);
            }
        }
    }
    private void OnTriggerExit(Collider collidedEnemy)
    {
        enemiesToShoot.Remove(collidedEnemy.gameObject);
    }    

    // For Detecting Melee Attacks
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(meleeAttackPos.position, new Vector3(meleeAttackRangeX, meleeAttackRangeY, 1));
    }

    private bool IsEnemyAlive(GameObject _target)
    {
        if (_target == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
