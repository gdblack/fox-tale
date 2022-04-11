using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public int currentHealth, maxHealth;
    public static PlayerHealthController instance;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DealDamage()
    {
        currentHealth--;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            // Death
            gameObject.SetActive(false);
        }
        UIController.instance.UpdateHealthDisplay();
    }
}
