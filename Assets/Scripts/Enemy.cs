using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int healthValue;
    public int armorValue;

    enum difficulty {EASY,NORMAL,HARD};
    difficulty myDifficulty;

    enum armorTypes{ LIGHT, HEAVY, SUPERHEAVY };
    armorTypes armor;

    // Start is called before the first frame update
    void Start()
    {
        myDifficulty = difficulty.NORMAL;

        healthValue = 100;

        armor = armorTypes.LIGHT;
        switch (armor)
        {
            case armorTypes.LIGHT:
                armorValue = 15;
                break;
            case armorTypes.HEAVY:
                armorValue = 30;
                break;
            case armorTypes.SUPERHEAVY:
                armorValue = 45;
                break;
            default:
                break;
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        int bulletDamageStatic = 50;
        //int dmgReduction = (int)(bulletDamageStatic * (armorValue / 100));
        healthValue -= (bulletDamageStatic - armorValue);
        Debug.Log("Enemy is HIT;\tHP: " + healthValue + "\tARMOR: " + armorValue); //+ "\tDMGREDUCTION: "+ dmgReduction);

        if (healthValue <= 0)
        {
            Debug.Log("Enemy ded");
            Destroy(gameObject);
        }
    }
}
