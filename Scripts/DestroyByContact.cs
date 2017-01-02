using UnityEngine;
using System.Collections;

namespace Done
{

    public class DestroyByContact : MonoBehaviour
    {

        public GameObject Explosion;
        public GameObject PlayerExplosion;
        public int scoreValue;
        private GameController gameController;

        void Start()
        {
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

        void OnTriggerEnter(Collider other)
        {

            if (other.tag == "Boundary")
            {
                return;
            }
            Instantiate(Explosion, transform.position, transform.rotation);
            if (other.tag == "Player")
            {

                return;

            }
            else
            {
                gameController.AddScore(scoreValue);
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
        }

    }


    //player dead
    //            Instantiate(PlayerExplosion, other.transform.position, other.transform.rotation);
    //gameController.GameOver();
    //            gameController.AddScore(scoreValue);
    //            DesgameObject);

}