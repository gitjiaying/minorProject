using UnityEngine;
using System.Collections.Generic;
using System;
using UnityEngine.Analytics;

public class AnalyticsSystem : MonoBehaviour
{

    private bool trigger = true;

    void Start()
    {


    }


    void Update()
    {
  
        if (trigger = true)
        {
            if (GameManagerScript.alive == false)
            {
                OnGameOver();
                trigger = false;
            }
        }
    }

    void OnGameOver()
    {
//        Analytics.CustomEvent("Game over", new Dictionary<string, object>
//        {
//            {"books fired", GameManagerScript.booksFired },
//            {"geo thrown", GameManagerScript.geoThrown },
//            {"books hit", GameManagerScript.booksHit },
//            {"geo hit", GameManagerScript.geoHit },
//            {"nerds killed", GameManagerScript.nerdsKilled },
//            {"nerds average life", GameManagerScript.nerdsAverageLife },
//			{"time player was alive", GameManagerScript.timeAlive},
//			{"nerds killed with a book", GameManagerScript.killedByBook},
//			{"nerds killed with a geo", GameManagerScript.killedByGeo},
//			{"nerds killed with melee", GameManagerScript.killedByMelee}
//        });
    }
}