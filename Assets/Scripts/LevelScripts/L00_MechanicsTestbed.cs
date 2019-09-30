using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L00_MechanicsTestbed : MonoBehaviour, ILevelScript
{
    [SerializeField] private GameObject mapToCopy;
    [SerializeField] private GameObject p2Prefab;
    //[SerializeField] private Transform p1Transform;
    [SerializeField] private int offset;
    [SerializeField] UIMiddleman ui;

    [SerializeField] private GameObject p1;
    private GameObject p2;

    // Start is called before the first frame update
    void Start()
    {
        if (ui is null)
            ui = GameObject.Find("UIMaster").GetComponent<UIMiddleman>();

        GameObject p2Map = Instantiate(mapToCopy);
        p2Map.transform.position = mapToCopy.transform.position + new Vector3(offset, 0.0f, 0.0f);

        p2 = Instantiate(p2Prefab);
        p2.transform.position = p1.transform.position + new Vector3(offset, 0.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetOffset()
    {
        return offset;
    }

    public void ReportFailure()
    {
        ui.ShowEndGamePanel();

        if (!(p1 is null))
        {
            p1.GetComponent<PlayerController1>().Die();
            p1.GetComponent<Rigidbody>().velocity = Vector3.zero;
            p1.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            p1.GetComponent<Rigidbody>().useGravity = false;
            p1 = null;
        }

        if (!(p2 is null))
        {
            p2.GetComponent<PlayerController2>().Die();
            p2.GetComponent<Rigidbody>().velocity = Vector3.zero;
            p2.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            p2.GetComponent<Rigidbody>().useGravity = false;
            p2 = null;
        }
}
}
