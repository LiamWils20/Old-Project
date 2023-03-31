using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public Transform player;
    private float dist;
    public float speed = 1;
    public Transform enemy;
    public int DamageToPlayer;
    AudioSource audioIntense;



    public GameObject bullet;
    public int launchVelocity = 900;

    private Animator animator;

    public enum EnemyStates {idle, chasing, attacking, range}
    public EnemyStates enemyState;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        audioIntense = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

    }
    public Vector3 moving;
    // Update is called once per frame
    void Update()
    {
        dist = CalculateDistanceBetwenVector3(player.position, transform.position); // Vector3.Distance(player.position, transform.position);
        //Debug.Log(CalculateDistanceBetwenVector3(player.position, transform.position));
        switch (enemyState)
        {
            case EnemyStates.idle:
                
                animator.SetBool("isMoving", false);

                break;

            case EnemyStates.chasing:
                //Player in Sight? Chase Begin.
                //glare at player
                animator.SetBool("isMoving", true);
                speed = 1;
                transform.LookAt(player.transform.position);
                //run after player
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
                // intense audio
                
                //audioIntense.Play(0);

                break;

            case EnemyStates.attacking:
                // Stop Enemy from moving
                speed = 0;
                animator.SetBool("isAttacking", false);
                // Begin attacking player
                // StartCoroutine(DealDamage());
                GetComponent<BossZombie>().StartCoroutine(DealDamage());
                break;
        }
        //Player Distance from enemy is between 1 and 15, enemy will chase
        //If not enemy will idle,
        //If Player is 1 from enemy, enemy will attack.
        if (dist <= 15 && dist >= 1)
        {
            enemyState = EnemyStates.chasing;
            //animator.SetBool("isMoving", true);
        }
        else
        {
            enemyState = EnemyStates.idle;
            //animator.SetBool("isMoving", false);
        }
        if (dist <= 3)
        {
            enemyState = EnemyStates.attacking;
        }
    }
    public float CalculateDistanceBetwenVector3(Vector3 v1, Vector3 v2)
    {
        // Sqaure root of 1.x-2.x squared, plus 1.y-2.y squared
        float x = v1.x - v2.x;
        float y = v1.y - v2.y;
        float z = v1.z - v2.z;

        // Square root of the x y z squared
        x = Mathf.Pow(x, 2);
        y = Mathf.Pow(y, 2);
        z = Mathf.Pow(z, 2);

        // add squared values
        float sqXYZ = x + y + z;

        return Mathf.Sqrt(sqXYZ);
    }

    IEnumerator DealDamage()
    {
        //GameObject ball = Instantiate(bullet, transform.position, transform.rotation);
        //ball.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, launchVelocity, 0));

        GetComponent<BossEnemyShooter>().Fire();

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);
    }

    
}
