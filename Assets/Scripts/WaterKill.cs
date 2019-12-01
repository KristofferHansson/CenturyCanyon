﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterKill : MonoBehaviour
{
    [SerializeField] private LevelScript lvl;

    void OnTriggerEnter(Collider other)
    {
        bool playerIn = false;
        string deadPlayerName = "";
        if (other.gameObject.name.Equals("P1Capsule"))
        {
            playerIn = true;
            deadPlayerName = "Past player";
        }
        else if (other.gameObject.name.Equals("P2Capsule"))
        {
            playerIn = true;
            deadPlayerName = "Future player";
        }
        if (playerIn)
        {
            lvl.ReportFailure();
            print(deadPlayerName + " has drowned.");
        }
    }
}
