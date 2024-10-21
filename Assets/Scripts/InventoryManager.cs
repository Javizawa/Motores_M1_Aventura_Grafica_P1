using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public List<Sprite> itemSprites; // Lista de imágenes de ítems
    public List<Button> itemSlots; // Lista de botones que actúan como slots en el inventario
    private bool isActive = false;
    public string itemName = "";
    [SerializeField] private GameObject inventory;

    // Añadir un ítem al inventario
    public void AddItem(Sprite itemSprite, string pItemName)
    {
        for (int i = 0; i < itemSlots.Count; i++)
        {
            // Si el slot está vacío, añade el ítem
            if (itemSlots[i].GetComponent<Image>().sprite == null)
            {
                itemSlots[i].GetComponent<Image>().sprite = itemSprite;
                itemSlots[i].GetComponent<ItemInventory>().SetItemName(pItemName);
                break;
            }
        }
    }


    public string GetButtonPressed()
    {
        for (int i = 0; i < itemSlots.Count; i++)
        {
            // Si el slot está vacío, añade el ítem
            if (itemSlots[i].GetComponent<ItemInventory>().GetIsActiveButton())
            {
                itemName = itemSlots[i].GetComponent<ItemInventory>().GetItemName();
                break;
            }
        }
        return itemName;
    }



    public void ResetInventoriButtons()
    {
        itemName = "";
        for (int i = 0; i < itemSlots.Count; i++)
        {
            itemSlots[i].GetComponent<ItemInventory>().ResetButton();
        }
    }


    // Quitar ítem del inventario
    public void RemoveItem(int index)
    {
        if (index < itemSlots.Count)
        {
            itemSlots[index].GetComponent<Image>().sprite = null;
        }
    }

    public void ShowInventory()
    {
        if (!isActive)
        {
            isActive = true;
            inventory.SetActive(true);
        }
        else
        {
            isActive = false;
            inventory.SetActive(false);
        }
    }
}
