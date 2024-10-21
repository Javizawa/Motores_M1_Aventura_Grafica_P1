using UnityEngine;
using System.Collections;

public class ItemInventory : MonoBehaviour
{
    [SerializeField] private GameObject eventSystem;
    private GamePlay gameManager;
    private InventoryManager inventoryManager;
    public string itemName;
    public bool isActive = false;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GamePlay>();
        inventoryManager = GameObject.FindGameObjectWithTag("Inventario").GetComponent<InventoryManager>();
    }

    public void UseItem()
    {
        gameManager.ResetButtons();
        inventoryManager.ResetInventoriButtons();
        isActive = true; 
    }

    public bool GetIsActiveButton()
    {
        return isActive;
    }

    public void ResetButton()
    {
        isActive = false;
    }


    public void SetItemName(string itemName)
    {
        this.itemName = itemName;
    }

    public string GetItemName()
    {
        return itemName;
    }
}
