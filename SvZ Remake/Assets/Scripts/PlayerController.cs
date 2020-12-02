using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BasePawn, IDamageable
{
    // * THESE VARIABLES/STATS/FUNCTIONS DEFINED BELOW ARE SPECIFIC/UNIQUE TO THIS PAWN *

    public float healthRegenRate = 2.0f;        // How Fast Health Is Regenerated

    // For Health
    public HealthBar healthBar;                 // Reference For Health Bar

    // To Flash When Hit
    public int numberOfFlashes;                 // Number Of Times The Pawn Will Flash When Hit
    public new MeshRenderer renderer;
    public Color normalColor;                   // Default Color
    public Color flashColor;                    // Color When Flashing

    // Start is called before the first frame update
    void Start()
    {
        healthBar.SetMaxHealth(stats.maxHealth);
        InvokeRepeating("RegenHealth", 1.0f / healthRegenRate, 1.0f / healthRegenRate);
    }

    // Update is called once per frame
    void Update()
    {
        InputController();
        HandleAttack();
    }

    public void InputController()
    {
        Vector3 pos = transform.position;

        if (Input.GetKey(KeyCode.A))
        {
            pos.x -= stats.defaultSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            pos.x += stats.defaultSpeed * Time.deltaTime;
        }
        transform.position = pos;
    }

    void RegenHealth()
    {
        if (stats.currentHealth < stats.maxHealth)
        {
            stats.currentHealth += 1;
            // Update Health Bar
            healthBar.SetHealth(stats.currentHealth);
        }        
    }

    public void TakeDamage(int _damage)
    {
        // Play a hurt sound
        stats.currentHealth -= _damage;

        if (stats.currentHealth <= 0)
        {
            GameManager.DestroyPlayer(this);
        }

        // To Flash When Hit
        StartCoroutine(Flash());
        // Updating Health Bar
        healthBar.SetHealth(stats.currentHealth);
    }

    IEnumerator Flash()
    {
        for (int i = 0; i < numberOfFlashes; i++)
        {
            renderer.material.color = flashColor;
            yield return new WaitForSeconds(.1f);
            renderer.material.color = normalColor;
            yield return new WaitForSeconds(.1f);
        }
    }
}
