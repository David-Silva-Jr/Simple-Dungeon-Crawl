using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleWeapon : MonoBehaviour
{
    Weapon weapon1;
    Weapon weapon2;

    // Start is called before the first frame update
    void Start()
    {
        weapon1 = new NormalSword("Sample Sword", "Just an example of how a sword should work", 100, 1, 10, 50);
        weapon2 = new Sword("Sample Sword 2", "Just an example of how a sword should work", 100, 1, 30, 40);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            print(weapon1.Name + " damage: " + weapon1.GetDamage());
        }
        if(Input.GetMouseButtonDown(1)){
            print(weapon2.Name + " damage: " + weapon2.GetDamage());
        }
    }
}
