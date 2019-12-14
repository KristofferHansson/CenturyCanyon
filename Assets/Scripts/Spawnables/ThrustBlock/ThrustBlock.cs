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

    private Material m_Material;
    private Color m_Color;
    private float alpha = 1.0f;
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        m_Material = GetComponent<Renderer>().material;
        m_Color = m_Material.color;
        time = Time.time;
        Invoke("setMovement", countdown);
    }

    // Update is called once per frame
    void Update()
    {
        //GetComponent<Rigidbody>().AddForce(force * movement * Time.deltaTime);
        GetComponent<Rigidbody>().velocity = force * movement;
        m_Material.color = new Color(m_Color.r, m_Color.g, m_Color.b, alpha);
        float total = countdown + destructionCountdown + movementDuration;
        alpha = (total - (Time.time - time)) / total;
        print(alpha);
    }

    private void setMovement()
    {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;

        if (direction == "UP")
        {
            movement.y = 1;
        }

        if (direction == "DOWN")
        {
            movement.y = -1;
        }

        if (direction == "RIGHT")
        {
            movement.z = -1;
        }

        if (direction == "LEFT")
        {
            movement.z = 1;
        }

        Invoke("stopMovement", movementDuration);

    }

    private void stopMovement()
    {
        //movement = Vector3.zero;
        Invoke("selfDestruct", destructionCountdown);
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
    }

    private void selfDestruct()
    {
        Destroy(this.gameObject);
    }

}
