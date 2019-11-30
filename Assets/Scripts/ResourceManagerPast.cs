using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManagerPast : MonoBehaviour
{
    private static ResourceManagerPast _instance;

    public static ResourceManagerPast Instance { get { return _instance; } }

    [SerializeField] private UIMiddleman ui = null;

    private int vines = 0;
    private int trees = 0;
    private int bouncingBushes = 0;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    void Start()
    {
        if (ui is null || ui == null)
            ui = GameObject.Find("UIMaster").GetComponent<UIMiddleman>();
    }

    // item = "vine", "tree", or "bouncingBush"
    public void PickUp(string item, int number = 1)
    {
        if (item.Equals("vine"))
        {
            vines += number;
            ui.SetVineCount(Instance.GetNumberOf("vine"));
        }
        else if (item.Equals("tree"))
        {
            trees += number;
            ui.SetTreeCount(Instance.GetNumberOf("tree"));
        }
        else if (item.Equals("bush"))
        {
            bouncingBushes += number;
            ui.SetBushCount(Instance.GetNumberOf("bush"));
        }
    }

    // item = "vine", "tree", or "bouncingBush"
    public int GetNumberOf(string item)
    {
        if (item.Equals("vine"))
        {
            return vines;
        }
        else if (item.Equals("tree"))
        {
            return trees;
        }
        else if (item.Equals("bush"))
        {
            return bouncingBushes;
        }
        else
            return -1;
    }

    public void Use(string item)
    {
        if (item.Equals("vine"))
        {
            vines--;
            ui.SetVineCount(Instance.GetNumberOf("vine"));
        }
        else if (item.Equals("tree"))
        {
            trees--;
        }
        else if (item.Equals("bush"))
        {
            bouncingBushes--;
        }
    }
}
