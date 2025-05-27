using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class ItemPickup : MonoBehaviour
{
    // Name of the item (optional, can be used for inventory management)
    public string itemName;
    private CauldronCollision cauldron;
    public GameObject CauldronGo;
    public AudioSource PickupSound;

    private void Start()
    {
        cauldron = CauldronGo.GetComponent<CauldronCollision>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the colliding object has the "Player" tag
        if (other.CompareTag("Player"))
        {
            PickupSound.Play();
            PickUpItem();
        }
    }

    void PickUpItem()
    {
        Debug.Log("Picked up: " + itemName);

        // Here you could add the item to the player's inventory system
        // Example: InventoryManager.Instance.AddItem(this);

        // Destroy the item object after picking it up
        cauldron.itemspicked.Add(itemName);
        
        Destroy(gameObject);
    }
}
