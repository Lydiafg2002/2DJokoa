using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public float health = 100f;
    public Image healthBar;

    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health < 0)
        {
            health = 0;
            SceneManager.LoadScene("GameOver");
        }
        float newFillAmount = health / 100.0f;

        healthBar.fillAmount = newFillAmount;
    }

    public void Heal(float healAmount)
    {
        Debug.Log("Healing " + healAmount + " dmg");
        health += healAmount;
        if (health > 100)
        {
            health = 100;
        }
        healthBar.fillAmount = health / health;

    }
}