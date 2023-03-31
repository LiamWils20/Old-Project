using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowEnemy : MonoBehaviour
{
    //Public variables
    public Transform player;
    public float dist;
    //When triggering grow() GameObject will scale up to [grownScale] over [time]
    public Vector3 grownScale;
    //Private variables
    private bool active = false;
    private Vector3 originalScale;
    private float progress;
    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        dist = Vector3.Distance(player.position, transform.position);
        enemy.GetComponent<BossZombie>().healthD = 1000;
        originalScale = transform.localScale;
        grow();
    }

    // Update is called once per frame
    void Update()
    {
        if (dist <= 15)
        {
            // Display Boss health

        }
    }
    public void grow()
    {
        active = true;
        transform.localScale = new Vector3(
                            (1 - progress) * grownScale.x + progress * grownScale.x,
                            (1 - progress) * grownScale.y + progress * grownScale.y,
                            (1 - progress) * grownScale.z + progress * grownScale.z
                            );
    }

    

    public void originalSize()
    {
        active = true;
        originalScale = transform.localScale;
    }
}
