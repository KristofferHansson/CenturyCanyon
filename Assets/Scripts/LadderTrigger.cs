using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderTrigger : MonoBehaviour
{
    [SerializeField] private LevelScript lvl;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("P1Capsule"))
        {
            lvl.PlayerIn(true);
        }
        else if (other.gameObject.name.Equals("P2Capsule"))
        {
            lvl.PlayerIn(false);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Equals("P1Capsule"))
        {
            lvl.PlayerOut(true);
        }
        else if (other.gameObject.name.Equals("P2Capsule"))
        {
            lvl.PlayerOut(false);
        }
    }
}
