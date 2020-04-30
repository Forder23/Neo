using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    public Image healthBar;
    public float Health=1.0f;
    [SerializeField]
    private float currentHealth;
    private void Start()
    {
        //SetCurrentHealth(Health);
    }
    public void SetCurrentHealth(float hp)
    {
        healthBar.fillAmount = hp;
    }

    public void SetMaxHealth(float hp)
    {
        healthBar.fillAmount = 1.0f;
    }

}
