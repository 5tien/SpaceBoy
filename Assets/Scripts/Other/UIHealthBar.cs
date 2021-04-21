using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour
{
    [Range(0, 1)] public float barcharge;
    public Text m_currentHealth;

    private Health healthScript;
    private Image barImage;

    private void Awake()
    {
        barImage = transform.Find("HealthBar").GetComponent<Image>();
        healthScript = FindObjectOfType<Health>();
    }
    void Update()
    {
        m_currentHealth.text = healthScript.currentHealth.ToString();

        //If the counter gets down to 1 the counter will become red
        if (healthScript.currentHealth == 1)
        {
            //m_currentHealth.color = new Color32(219, 82, 82, 255);              
        }


        barcharge = healthScript.currentHealth / healthScript.maxHealth;
        barImage.fillAmount = barcharge;

        //Healthbar color flash
        if (healthScript.HealthbarRed == true)
        {
            barImage.color = new Color32(255, 0, 0, 255);
        }
        else
        {
            barImage.color = new Color32(255, 255, 255, 255);
        }
    }
}
