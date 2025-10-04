using System;
using UnityEngine;
using UnityEngine.Rendering;

public class Backpack : MonoBehaviour
{

    [Header("References")] 
    [SerializeField]
    private BackpackUI ui;
    private AudioSource _audioSource;

    [Header("Prefabs")] 
    [SerializeField] 
    private GameObject itemInWorld;

    [Header("Dict")] 
    [SerializeField] 
    private SerializedDictionary<int, Item> inventory = new();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
