using UnityEngine;
using System.Collections;
using System.Collections.Generic;		//Allows us to use Lists. 

namespace Done{

    public class GameController : MonoBehaviour {

        public GameObject hazard;
        public GameObject health;

        private List<int> test;
        private List<Object> hazards;

        public Vector3 spawnValues;
        public float spawnWait;
        public float startWait;
        public float waveWait;

        public int hazardCount;
        public int healthCount;

        public GUIText scoreText;
        public GUIText restartText;
        public GUIText gameOverText;
        public GUIText asteroid_speed;

        private bool gameOver;
        private bool restart;

        private int score;



        void Start()
        {
            // Message with a link to an object.
            Debug.Log("Hello");

            // Message using rich text.
            Debug.Log("<color=red>Fatal error:</color> AssetBundle not found");

            gameOver = false;
            restart = false;
            restartText.text = "";
            gameOverText.text = "";
            score = 0;
            updateScore();
            StartCoroutine(spawnHazardWaves());
            StartCoroutine(spawnHealthWaves());
        }



        void Update()
        {
            if (restart)
            {
                if (Input.GetKeyDown(KeyCode.R))
                {
                    Application.LoadLevel(Application.loadedLevel);
                }
            }
        }

        IEnumerator spawnHazardWaves()
        {
            yield return new WaitForSeconds(startWait);
            while (true)
            {
                for (int i = 0; i < hazardCount; i++)
                {

                    Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                    Quaternion spawnRotation = Quaternion.identity;
                    Instantiate(hazard, spawnPosition, spawnRotation);
                    //asteroid_speed.text = "Speed: " + hazards[0];


                    yield return new WaitForSeconds(spawnWait);
                }
                yield return new WaitForSeconds(waveWait);
                if (gameOver)
                {
                    restartText.text = "Press 'R' to restart";
                    restart = true;
                    break;
                }
            }
        }
        IEnumerator spawnHealthWaves()
        {
            yield return new WaitForSeconds(startWait);
            while (true)
            {
                for (int i = 0; i < healthCount; i++)
                {
                    Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z + 2f);
                    Quaternion spawnRotation = Quaternion.identity;
                    Instantiate(health, spawnPosition, spawnRotation);
                    yield return new WaitForSeconds(spawnWait);
                }
                yield return new WaitForSeconds(waveWait);
                if (gameOver)
                {
                    restartText.text = "Press 'R' to restart";
                    restart = true;
                    break;
                }
            }
        }

        public void GameOver()
        {
            gameOverText.text = "Game Over!";
            gameOver = true;
        }

        public void AddScore(int newScoreValue)
        {
            score += newScoreValue;
            updateScore();
        }

        void updateScore()
        {
            scoreText.text = "Score: " + score;
        }

        void updateSpeed()
        {
            //asteroid_speed = 
        }
    }
}