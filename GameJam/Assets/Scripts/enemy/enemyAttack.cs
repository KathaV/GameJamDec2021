using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMelee : MonoBehaviour
{

    [Header("Attack Parameters")]
    [SerializeField] private float attackCooldown;
    
    private float cooldownTimer = Mathf.Infinity;
    private Animator anim;
    
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        cooldownTimer += Time.deltaTime;
 
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (cooldownTimer >= attackCooldown)
            {
                //attack
                cooldownTimer = 0;
                anim.SetTrigger("meleeAttack");
                collision.gameObject.GetComponent<stunPlayer>().startCoroutine();

            }
            

        }
    }


}
