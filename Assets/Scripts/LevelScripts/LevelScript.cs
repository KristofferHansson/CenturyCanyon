using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScript : MonoBehaviour
{
    [SerializeField] protected GameObject waterBox;
    [SerializeField] protected GameObject pastAndFuture;
    [SerializeField] protected GameObject futureOnly;
    [SerializeField] protected GameObject player1Prefab;
    [SerializeField] protected GameObject player2Prefab;
    //[SerializeField] private Transform p1Transform;
    [SerializeField] protected Transform spawnPoint;
    [SerializeField] protected UIMiddleman ui;

    protected GameObject p1;
    protected GameObject p2;
    protected float offset;
    protected int playersInCompletionTrigger = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (ui is null)
            ui = GameObject.Find("UIMaster").GetComponent<UIMiddleman>();

        offset = waterBox.GetComponent<Renderer>().bounds.extents.magnitude * 2 + 100;

        GameObject p2Map = Instantiate(pastAndFuture);
        p2Map.transform.position = pastAndFuture.transform.position + new Vector3(offset, 0.0f, 0.0f);

        futureOnly.transform.position = pastAndFuture.transform.position + new Vector3(offset, 0.0f, 0.0f);

        p1 = Instantiate(player1Prefab);
        p1.transform.position = spawnPoint.position;

        p2 = Instantiate(player2Prefab);
        p2.transform.position = spawnPoint.position + new Vector3(offset, 0.0f, 0.0f);
    }

    public float GetOffset()
    {
        return offset;
    }

    // When one of the players dies
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

    // Player enters end-level trigger
    public void PlayerIn()
    {
        playersInCompletionTrigger++;

        if (playersInCompletionTrigger >= 2)
            LevelComplete();
    }

    // Player exits end-level trigger
    public void PlayerOut()
    {
        playersInCompletionTrigger--;
    }

    public void LevelComplete()
    {
        ui.ShowLevelCompletePanel();
    }
}
