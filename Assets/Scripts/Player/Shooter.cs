using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("Bullet Config")]
    public float CurrentGun = 1;
    public GameObject bullet;
    public float delayTimer;

    [Header("1 | Machine shot Settings")]
    [Range(0, 1)] public float machineShotInterval = 0.22f;
    public float machineBNSpeed = 10;
    public float machineBNSize = 0.05f;
    public bool constandCharging;
    [Range(0, 5)] public float maxChargeMachine = 0.8f;
    [Range(0, 1)] public float reloadSpeed;
    [Range(1, 5)] public float ammoDrainSpeed;
    public float bulDamageM = 25;
    private float cooldownTimer;
    private float currentInterval;
    
    [Header("2 | Single shot Settings")]
    [Range(0, 9)] public float chargeDrag = 3;
    [Range(0, 2)] public float shootDelaySingle = 0.8f;
    public float singleBNSpeed = 10;
    public float singleBNSize = 0.15f;
    public float bulDamageS = 50;
    public float bulDamageMultiplier = 3f;
    public float charge = 0;

    private void Start()
    {
        delayTimer = 0;
        currentInterval = 0;
    }

    void Update()
    {
        //Gun switcher.
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (CurrentGun < 2)     //This is the amount of guns it will switch between.
            {
                CurrentGun = CurrentGun + 1;
            }
            else
            {
                CurrentGun = 1;
            }
        }

        switch (CurrentGun)
        {
            case 1:
                MachineShot();      //Just a simple gun, shoot a lot of bullets in a short amount of time.
                break;
            case 2:
                SingleShot();       //A gun which will shoot 1 bullet at a time on cooldown. Hold longer for a bigger blast which does more damage.
                break;
        }
    }

    void SingleShot()
    {
        if (delayTimer >= shootDelaySingle)
        {
            if (Input.GetKey(KeyCode.Mouse0) || Input.GetKey(KeyCode.Space))
            {
                if (charge < 1)
                {
                    charge += Time.deltaTime;
                }
                else
                {
                    charge = 1;
                }
            }
            else if (Input.GetKeyUp(KeyCode.Mouse0) || Input.GetKeyUp(KeyCode.Space))
            {
                GameObject newBullet = Instantiate(bullet, transform.position + new Vector3(0, 0, 2), Quaternion.identity);

                if (charge >= 0)
                {
                    newBullet.transform.localScale = new Vector3(singleBNSize + charge, singleBNSize + charge, singleBNSize + charge);
                    newBullet.GetComponent<BulletHit>().direction = new Vector3(0, 0, singleBNSpeed - charge * chargeDrag);
                }

                delayTimer = 0 - charge;
                charge = 0;
            }
        }
        else if(delayTimer < shootDelaySingle)
        {
            delayTimer = delayTimer + 1 * Time.deltaTime;
        }

        if (delayTimer > shootDelaySingle)
        {
            delayTimer = shootDelaySingle;
        }
    }

    void MachineShot()
    {
        if (delayTimer > 0)
        {
            if (cooldownTimer <= 0)
            {
                if (currentInterval >= machineShotInterval)
                {
                    if (Input.GetKey(KeyCode.Mouse0) || Input.GetKey(KeyCode.Space))
                    {
                        GameObject newBullet = Instantiate(bullet, transform.position + new Vector3(-0.4f, 0, 1.5f), Quaternion.identity);
                        GameObject newBullet2 = Instantiate(bullet, transform.position + new Vector3(0.4f, 0, 1.5f), Quaternion.identity);

                        newBullet.transform.localScale = new Vector3(machineBNSize, machineBNSize * 2.5f, machineBNSize);
                        newBullet2.transform.localScale = new Vector3(machineBNSize, machineBNSize * 2.5f, machineBNSize);

                        newBullet.GetComponent<BulletHit>().direction = new Vector3(0, 0, machineBNSpeed);
                        newBullet2.GetComponent<BulletHit>().direction = new Vector3(0, 0, machineBNSpeed);


                        currentInterval = 0;
                        delayTimer = delayTimer -= Time.deltaTime * ammoDrainSpeed;
                    }
                    else if (constandCharging == true)
                    {
                        delayTimer += reloadSpeed * Time.deltaTime;
                    }
                }
                else if (currentInterval < machineShotInterval)
                {
                    currentInterval += Time.deltaTime;
                }

                if (currentInterval > machineShotInterval)
                {
                    currentInterval = machineShotInterval;
                }
            }
            else
            {
                cooldownTimer -= reloadSpeed * Time.deltaTime;
                delayTimer += reloadSpeed * Time.deltaTime;
            }
        }
        else
        {
            cooldownTimer = maxChargeMachine;
            delayTimer += reloadSpeed * Time.deltaTime;
        }

        if (delayTimer > maxChargeMachine)
        {
            delayTimer = maxChargeMachine;
        }
    }
}
