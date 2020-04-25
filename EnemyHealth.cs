using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float InitHealth = 100;
    private float currentHealth;
    public Image hpBar;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = InitHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(float amount)
    {
        currentHealth -= amount;
        hpBar.fillAmount = currentHealth / InitHealth;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            
        }
    }
}
