using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public GameObject inventoryPanel;
    public GameObject slotPrefab;
    public int slotCount;
    public GameObject[] itemPrefabs;

    void Start()
    {
        if (inventoryPanel == null)
        {
            Debug.LogError("Inventory panel is not assigned!");
            return;
        }

        if (slotPrefab == null)
        {
            Debug.LogError("Slot prefab is not assigned!");
            return;
        }

        for (int i = 0; i < slotCount; i++)
        {
            // Instantiate the slot
            GameObject slotObj = Instantiate(slotPrefab, inventoryPanel.transform);
            Slot slot = slotObj.GetComponent<Slot>();

            if (slot == null)
            {
                Debug.LogError("Slot component missing on instantiated slot prefab.");
                continue;
            }

            // Optionally add item to slot
            if (itemPrefabs != null && i < itemPrefabs.Length && itemPrefabs[i] != null)
            {
                GameObject item = Instantiate(itemPrefabs[i], slotObj.transform);
                RectTransform itemRect = item.GetComponent<RectTransform>();

                if (itemRect != null)
                {
                    itemRect.anchoredPosition = Vector2.zero;
                }
                else
                {
                    Debug.LogError("Item prefab is missing RectTransform component.");
                }

                slot.currentItem = item;
            }
        }
    }
}
