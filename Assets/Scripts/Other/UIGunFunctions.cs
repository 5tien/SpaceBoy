using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGunFunctions : MonoBehaviour
{
    [Header("Bar settings")]
    private Shooter shootScript;
    [Range (0, 1)] public float barcharge;
    [SerializeField] private bool automaticBarCharge = true;
    private Image barImage;

    [Header("Weapon Select settings")]
    public Sprite singleShot;
    public Sprite doubleShot;
    private Image selectedWeapon;

    private void Awake()
    {
        barImage = transform.Find("Bar").GetComponent<Image>();
        selectedWeapon = transform.Find("SelectedWeapon").GetComponent<Image>();

        shootScript = FindObjectOfType<Shooter>();
    }
    void Update()
    {
        if (automaticBarCharge == true)
        {
        //barcharge = shootScript.delayTimer / shootScript.shootDelaySingle;
        barcharge = shootScript.delayTimer / shootScript.maxChargeMachine;
        }
        barImage.fillAmount = barcharge;

        switch (shootScript.CurrentGun)
        {
            case 1:
                selectedWeapon.sprite = doubleShot;
                break;
            case 2:
                selectedWeapon.sprite = singleShot;
                break;
        }
    }
}