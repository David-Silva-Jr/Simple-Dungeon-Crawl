using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAttack : MonoBehaviour
{
    [SerializeField]
    float interval;

    [SerializeField]
    Animator slimeAnimator;

    float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= interval){
            timer -= interval;
            slimeAnimator.SetTrigger("Attack");
        }
    }
}
