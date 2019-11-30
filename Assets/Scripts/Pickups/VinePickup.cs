using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VinePickup : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("P1Capsule"))
        {
            ResourceManagerPast.Instance.PickUp("vine");
        }
        Destroy(this.gameObject.transform.parent.gameObject, 0.5f);
    }
}
