using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossController : MonoBehaviour
{
    [SerializeField]
    private Animator finalBossAnimator;
    [SerializeField]
    private float attackRate = 4.0f;

    private float nextAttack;

    private void Update()
    {
        if(Time.time > nextAttack)
        {
            nextAttack = Time.time + attackRate;

            finalBossAnimator.SetBool("isAttacking", true);
            finalBossAnimator.SetInteger("state", Random.Range(1, 4));
        }
    }

    public void EndAttack()
    {
        finalBossAnimator.SetBool("isAttacking", false);
    }
}
