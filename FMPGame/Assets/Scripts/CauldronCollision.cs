using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class CauldronCollision : MonoBehaviour
{

    private ItemPickup itempickup;
    public List<string> itemspicked = new List<string>();
    public GameObject WinPopup;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (itemspicked.Count == 4)
        {
            WinPopup.SetActive(true);
        }
    }
}
