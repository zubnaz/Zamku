using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject coll = collision.gameObject;
        if (coll.tag == "Projectile") {
            if (GameStatistick.Shots % 2 == 0)
            {
                GameStatistick.ScorePlayer2++;
            }
            else
            {
                GameStatistick.ScorePlayer1++;
            }
            if (GameStatistick.Level < 3)
            {
                
                GameStatistick.Level++;
                SceneManager.LoadScene("SampleScene");
            }
            else if (GameStatistick.Level == 3)
            {
                GameStatistick.Level = 1;
                SceneManager.LoadScene("GameOverMenu");
            }

           
        }
    }
}
