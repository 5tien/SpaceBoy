using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour
{
    private Health healthScript;
    [Range(0, 1)] public float barcharge;
    private Image barImage;
    public Text m_currentHealth;
    private float currentHealthAMNT;


    private void Awake()
    {
        barImage = transform.Find("HealthBar").GetComponent<Image>();
        healthScript = FindObjectOfType<Health>();
    }
    void Update()
    {
        currentHealthAMNT = healthScript.currentHealth;

        barcharge = healthScript.currentHealth / healthScript.maxHealth;
        barImage.fillAmount = barcharge;
        m_currentHealth.text = currentHealthAMNT.ToString();

        if (healthScript.currentHealth == 1)
        {
            //m_currentHealth.color = new Color32(219, 82, 82, 255);              
        }

        if (healthScript.HealthbarRed == true)
        {
            //barImage.color = new Color32(255, 0, 0, 255);
        }
        else
        {
            //barImage.color = new Color32(255, 255, 255, 255);

        }
    }
}
