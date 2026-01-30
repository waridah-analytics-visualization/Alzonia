using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectible : MonoBehaviour
{
    public GameObject onCollectEffect;
    private Text scoreText;
    public static int scoreCount = 0;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        scoreText = FindFirstObjectByType<Text>();

        if (scoreCount == 0 && scoreText != null)
        {
            scoreText.text = "Score: 0";
        }
    }




    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 1, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            scoreCount += 1;

            if (scoreText != null)
            {
                // Update the actual UI text
                scoreText.text = "Score: " + scoreCount.ToString();
            }

            // Destroy Collectible
            Destroy(gameObject);

            // Instantiate Particle
            Instantiate(onCollectEffect, transform.position, transform.rotation);



        }
    }
}




