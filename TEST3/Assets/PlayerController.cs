using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] int health = 10;
    [SerializeField] private Text hpText;
    [SerializeField] float speed = 2;
    private Rigidbody2D Rigidbody;
    private Animator animator;
    [SerializeField] private GameObject hhptc;
    public float restart = 1f;
    [SerializeField] public GameObject completeLvl;
    [SerializeField] public Spawner spawner;
    [SerializeField] public int qb;
    // Start is called before the first frame update
    void Start()
    {

        Rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        Rigidbody.velocity = new Vector2(horizontal * speed, Rigidbody.velocity.y);

        if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("isWalking", true);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            animator.SetBool("isWalking", false);
        }

        if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("isBWalking", true);
        } 
        if (Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("isBWalking", false);
        }

        if ((health <= 0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (transform.position.x <= -165f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (transform.position.x >= 1050f)
        {
            spawner.timeBetweenSpawn = 1;
            hpText.text = "Winner";
            speed = 0;
            animator.SetBool("isWalking", false);
            animator.SetBool("isBWalking", false);
            completeLvl.SetActive(true);
            if (qb == 1)
            {
                Invoke("Nextlvl", 2f);
            }
        }
    }
    void Nextlvl()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + qb);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Fish")
        {
            Destroy(collision.gameObject);
            Instantiate(hhptc, collision.transform.position , Quaternion.identity);
            health -= 2;
            hpText.text = health.ToString();
            if (health <= 0)
            {
                print("Game Over please ResTarT");
                hpText.text = "Game Over";
            }
        }

        if (collision.tag == "Ice")
        {
            Destroy(collision.gameObject);
            Instantiate(hhptc, collision.transform.position, Quaternion.identity);
            health -= 5;
            hpText.text = health.ToString();
            if (health <= 0)
            {
                print("Game Over please ResTarT");
                hpText.text = "Game Over";
            }
        }

        if (collision.tag == "Penguin")
        {
            Destroy(collision.gameObject);
            Instantiate(hhptc, collision.transform.position, Quaternion.identity);
            health--;
            hpText.text = health.ToString();
            if (health <= 0)
            {
                print("Game Over please ResTarT");
                hpText.text = "Game Over";
            }
        }

        if (collision.tag == "Sealboy")
        {
            Destroy(collision.gameObject);
            Instantiate(hhptc, collision.transform.position, Quaternion.identity);
            health -= 3;
            hpText.text = health.ToString();
            if (health <= 0)
            {
                print("Game Over please ResTarT");
                hpText.text = "Game Over";
            }
        }
    }
}
