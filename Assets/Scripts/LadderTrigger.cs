using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderTrigger : MonoBehaviour
{
    [SerializeField] private LevelScript lvl;

    void Start()
    {
        if (lvl is null)
            lvl = GameObject.Find("LevelMaster").GetComponent<LevelScript>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("P1Capsule") || other.gameObject.name.Equals("P2Capsule"))
        {
            lvl.PlayerIn();
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Equals("P1Capsule") || other.gameObject.name.Equals("P2Capsule"))
        {
            lvl.PlayerOut();
        }
    }
}
