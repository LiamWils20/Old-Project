using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public Rigidbody rb;
    [SerializeField] private Transform player;
    [SerializeField] private Transform spawnPoint;
    public GameObject healthLowText;
    public GameObject pauseMenu;

    public float jumpAmount = 5;
    public int coinsCollected; // Declared and Assigned in a Single Line
    public float speed;
    public bool tutorialComplete;
    public int playerLevel;

    public int health = 100;
    public Text healthD;
    public int DamageToPlayer;

    public int maxHealth = 100;
    public Text maxHealthD;

    public GameObject myObjectToSpawn;

    // Animator Variables
    private Animator animator;
    //Public Text coinUIText;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        //coinsCollected = 0;
        speed = 3.2f;

        // Disabling Canvas Objects
        healthLowText.SetActive(false);
        pauseMenu.SetActive(false);
        // horizontalInput = 6.0f
    }

    // Update is called once per frame
    void Update()
    { 
        healthD.text = health.ToString();
        maxHealthD.text = maxHealth.ToString();

        // Player Movement Code
        // Read the Input of the Horizontal and Verticle, Store them in a Variable
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 inputFromPlayer = new Vector3(horizontalInput, 0, verticalInput);
        inputFromPlayer.Normalize();
        // Move the Player based on the values
        transform.Translate(inputFromPlayer * speed * Time.deltaTime);
        
        if (inputFromPlayer != Vector3.zero)
        {
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }

        if (Input.GetButtonDown("Sprint"))
        {
            speed = 10f;
        }
        if (Input.GetButtonUp("Sprint"))
        {
            speed = 3.2f;
        }

        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpAmount, ForceMode.Impulse);
        }
        if (Input.GetButtonDown("Pause"))
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

        }
        

        // If Statement to determine if the player is dead,
        // If the player is dead, player will respawn.
        if (health <= 0)
        {
            Respawn();
        }
        if (health <= 25)
        {
            healthLowText.SetActive(true);
        }
        else
        {
            healthLowText.SetActive(false);
        }
    }
    void BossDefeated()
    {

    }

    public void CollectedCoin(int numberOfCoinsCollectedInThisAction)
    {
        coinsCollected += numberOfCoinsCollectedInThisAction;
        if (coinsCollected == 5)
        {
            // Player has collected enough coins to level up
            playerLevel += 1;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Collision has happened eh, and it was " + collision.gameObject.name);

        if (collision.gameObject.name == "Wall")
        {
            // We hit the wall

        }
    }

    public void Damage(int dmg)
    {
        health = health - 10;
        if (health <= 0)
        {
            Destroy(player);
        }
    }

    public void Respawn()
    {
        player.transform.position = spawnPoint.position;
        health = 100;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
        Cursor.visible = false;
    }
}
