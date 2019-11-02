using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterKill : MonoBehaviour
{
    [SerializeField] private L00_MechanicsTestbed lvl;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
