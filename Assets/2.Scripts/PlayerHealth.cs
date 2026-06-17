using StarterAssets;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int betterHealth;
    public int currentHealth;

    [Header("Audio")]
    public AudioClip damageSound;
    private AudioSource audioSource;

    private Animator animator;
    private bool isDead = false;

    void Start()
    {
        currentHealth = betterHealth;

        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    
    }

    public void ApplyHealthUpgrade(int multiplier)
    {
        betterHealth = maxHealth + multiplier;
        currentHealth = betterHealth;

        HUDManager.instance.UpdateHealth(currentHealth, betterHealth);
    }

    public void TakeDamage(int damage)
    {
        if (isDead)
            return;

        currentHealth -= damage;

        if (animator != null)
        {
            animator.SetTrigger("Hit");
        }

        if (audioSource != null && damageSound != null)
        {
            audioSource.PlayOneShot(damageSound);
        }

        HUDManager.instance.UpdateHealth(currentHealth, betterHealth);

        Debug.Log("Vida actual: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        if (isDead)
            return;

        isDead = true;

        Debug.Log("GAME OVER");

        if (animator != null)
        {
            animator.SetTrigger("Die");
        }

        ThirdPersonController controller =
            GetComponent<ThirdPersonController>();

        if (controller != null)
        {
            controller.enabled = false;
        }

        StartCoroutine(DeathRoutine());
    }


    private System.Collections.IEnumerator DeathRoutine()
    {
        yield return new WaitForSeconds(2f);

        GameOverMenu.instance.ShowGameOver();
    }
}