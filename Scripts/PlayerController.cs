using System;
using UnityEngine;
using System.Collections;

namespace Done
{

    [System.Serializable]
    public class Boundary
    {
        public float xMin, xMax, zMin, zMax;
    }

    public class PlayerController : MonoBehaviour
    {

        public GameObject PlayerExplosion;
        private Rigidbody rb;
        private AudioSource audioSource;
        public float speed;
        public float tilt;
        public float fireRate = 0.5f;
        public float nextFire = 0.0f;
        public int health;
        public int playerDamageByAsteroid = 5;
        public int maxHealth = 100;
        public int healingByOrb = 10;
        private GameController gameController;


        public GameObject Shot;
        public Transform ShotSpawn;

        public Boundary boundary;

        void Start()
        {
            Console.Write("test\n");
            audioSource = GetComponent<AudioSource>();
            GameObject gameControllerObject = GameObject.FindWithTag("GameController");
            if (gameControllerObject != null)
            {
                gameController = gameControllerObject.GetComponent<GameController>();
            }
            else
            {
                Debug.Log("Cant find 'GameController' in the script");
            }
        }

        void MyGameMethod()
        {
            // Message with a link to an object.
            Debug.Log("Hello");

            // Message using rich text.
            Debug.Log("<color=red>Fatal error:</color> AssetBundle not found");
        }

        public void LoseHealth(int damage)
        {
            health -= damage;
        }

        public void RegainHealth(int healing)
        {
            if (health >= maxHealth - healingByOrb)
            {
                health = maxHealth;
            }
            else
            {
                health += healing;
            }
        }

        void Update()
        {

            if (Input.GetButton("Fire1") && Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                Instantiate(Shot, ShotSpawn.position, ShotSpawn.rotation);
                audioSource.Play();
            }
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Asteroid")
            {
                LoseHealth(playerDamageByAsteroid);
                Destroy(other.gameObject);
                checkIfGameOver();
            }
            if (other.tag == "Health")
            {
                RegainHealth(healingByOrb);
                Destroy(other.gameObject);

            }
        }

        void FixedUpdate()
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            rb = GetComponent<Rigidbody>();

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            rb.velocity = movement * speed;
            rb.position = new Vector3(
                Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
                0,
                Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
                );
            rb.rotation = Quaternion.Euler(0.0f, 0.0f, -rb.velocity.x * tilt);
        }

        void checkIfGameOver()
        {
            if (health <= 0)
            {
                Destroy(gameObject);
                gameController.GameOver();
            }
        }

    }
}