using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PColliderEnter : MonoBehaviour
{
    [SerializeField] private PlayerController1 pc;

    void OnTriggerStay(Collider other)
    {
        if (!other.isTrigger && !other.gameObject.name.Equals("PCapsule1"))
            pc.ResetJump();
    }
}
