using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManagerFuture : MonoBehaviour
{
    private static ResourceManagerFuture _instance;

    public static ResourceManagerFuture Instance { get { return _instance; } }

    [SerializeField] private UIMiddleman ui = null;

    private int energy = 0;

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

    // 
    public void PickUp(int number = 1)
    {
        energy += number;
        ui.SetEnergyCount(Instance.GetEnergy());
    }

    // item = "vine", "tree", or "bouncingBush"
    public int GetEnergy()
    {
        return energy;
    }

    public void Use(int number = 1)
    {
        energy -= number;
        if (energy < 0)
            energy = 0;
    }
}
