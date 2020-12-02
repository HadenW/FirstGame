using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : BasePawn, IDamageable
{
    // * THESE VARIABLES/STATS/FUNCTIONS DEFINED BELOW ARE SPECIFIC/UNIQUE TO THIS PAWN *

    [Space(10)]

    //public HealthBar healthBar;             // Reference For Health Bar

    // Dazed On Melee
    [Header("Stun Settings")]    
    public float startDazedTime;            // Length Of The Daze
    private float dazedTime;                // Time Left Dazed

    // Flashing When Hit
    public int numberOfFlashes;             // Number Of Time The Pawn Will Flash When Hit
    public new MeshRenderer renderer;       // 
    public Color normalColor;               // Default Color
    public Color flashColor;                // Color When Flashing

    // Amount Given To Player On Destroy
    public int MoneyAmount;


    // Start is called before the first frame update
    void Start()
    {
        stats.currentHealth = stats.maxHealth;
        //healthBar.SetMaxHealth(stats.maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        HandleAttack();
        HandleDaze();        
    }

    private void HandleDaze()
    {
        // Getting Dazed
        if (dazedTime <= 0)
        {
            stats.currentSpeed = stats.defaultSpeed;
        }
        else
        {
            //speed = 0;
            dazedTime -= Time.deltaTime;
        }
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("2");
        dazedTime = startDazedTime;
        // Play a hurt sound

        stats.currentHealth -= damage;
        if (stats.currentHealth <= 0)
        {
            GameManager.DestroyEnemy(this);
        }

        //healthBar.SetHealth(stats.currentHealth);
        StartCoroutine(Flash());
    }

    private IEnumerator Flash()
    {
        for (int i = 0; i < numberOfFlashes; i++)
        {
            renderer.material.color = flashColor;
            yield return new WaitForSeconds(.1f);
            renderer.material.color = normalColor;
            yield return new WaitForSeconds(.1f);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        //Gizmos.DrawWireCube(attackPos.position, new Vector3(attackRangeX, attackRangeY, 1));
    }
}
