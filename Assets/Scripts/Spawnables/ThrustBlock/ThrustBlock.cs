using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrustBlock : MonoBehaviour
{
    //Directions are UP, DOWN, LEFT and RIGHT
    public string direction = "UP";

    public float force = 100f;

    public float countdown = 3f;

    public float movementDuration = 1f;

    public float destructionCountdown = 5f;

    private Vector3 movement = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        Invoke("setMovement", countdown);
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().AddForce(movement);
    }

    private void setMovement()
    {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;

        if (direction == "UP")
        {
            movement.y = 1 * force;
        }

        if (direction == "DOWN")
        {
            movement.y = -1 * force;
        }

        if (direction == "RIGHT")
        {
            movement.z = -1 * force;
        }

        if (direction == "LEFT")
        {
            movement.z = 1 * force;
        }

        Invoke("stopMovement", movementDuration);

    }

    private void stopMovement()
    {
        movement = Vector3.zero;
        Invoke("selfDestruct", destructionCountdown);
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
    }

    private void selfDestruct()
    {
        Destroy(this.gameObject);
    }

}
