using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPatrol : MonoBehaviour
{
    [Header ("Patrol Points")]
    
    [SerializeField] private Transform leftedge;
    [SerializeField] private Transform rightedge;


    [Header("Patrol Points")]
    [SerializeField] private Transform enemy;
    
    [Header("Movement Parameters")]
    [SerializeField] private float speed;

    [Header("Idle Behaviour")]
    [SerializeField] private float idleDuration;
    private float idleTimer;

    [Header("Enemy Animator")]
    [SerializeField] private Animator anim;

    private Vector3 initScale;
    private bool movingLeft;

    // Start is called before the first frame update
    void Start()
    {
        initScale = enemy.localScale;

        //movingLeft = true;


    }

    private void OnDisable()
    {
        //anim.SetBool("moving", false);
    }

    // Update is called once per frame
    void Update()
    {
        //MoveInDirection(-1);
        if (movingLeft)

        {
            
            if(enemy.position.x >= leftedge.position.x)
            MoveInDirection(-1);

            else
            {
                //chnage direction
                DirectionChange();
                

            }
        }
        else
        { 

            if (enemy.position.x <= rightedge.position.x)
                MoveInDirection(1);
            else
            {
                //chnage direction
               DirectionChange();
            }
        }

    }

    private void DirectionChange()
    {
        //anim.SetBool("moving", false);
        idleTimer += Time.deltaTime;

        if (idleTimer > idleDuration)
            movingLeft = !movingLeft;
    }
    
    public void ForceDirectionChange()
    {
        //anim.SetBool("moving", false);
   
            movingLeft = !movingLeft;
    }

    public void MoveInDirection(int _direction)
    {
        idleTimer = 0;
        //anim.SetBool("moving", true);

        //Make enemy face direction
        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction, initScale.y, initScale.z);

        //Move in the direction
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed,
            enemy.position.y, enemy.position.z);
    }
}
