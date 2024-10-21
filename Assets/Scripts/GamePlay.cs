using UnityEngine;
using TMPro;

public class GamePlay : MonoBehaviour
{
    public TextMeshProUGUI textButton1;
    public TextMeshProUGUI textButton2;
    public TextMeshProUGUI textButton3;
    private bool getButton = false;
    private bool lookButton = false;
    private bool useButton = false;
    private InventoryManager inventoryManager;

    public void Start()
    {
        inventoryManager = GameObject.FindGameObjectWithTag("Inventario").GetComponent<InventoryManager>();
    }

    public bool GetgetButton()
    {
        return getButton;
    }

    public bool GetlookButton()
    {
        return lookButton;
    }

    public bool GetuseButton()
    {
        return useButton;
    }

    public void Look()
    {
        inventoryManager.ResetInventoriButtons();
        if (!lookButton)
        {
            textButton1.color = new Color32(91, 255, 0, 255);
            textButton2.color = new Color32(14, 183, 6, 255);
            textButton3.color = new Color32(14, 183, 6, 255);
            getButton = false;
            useButton = false;
            lookButton = true;
        }
        else
        {
            textButton1.color = new Color32(14, 183, 6, 255);
            lookButton = false;
        }
    }

    public void Use()
    {
        inventoryManager.ResetInventoriButtons();
        if (!useButton)
        {
            textButton1.color = new Color32(14, 183, 6, 255);
            textButton2.color = new Color32(91, 255, 0, 255);
            textButton3.color = new Color32(14, 183, 6, 255);
            useButton = true;
            getButton = false;
            lookButton = false;
        }
        else
        {
            textButton2.color = new Color32(14, 183, 6, 255);
            useButton = false;
        }
    }

    public void Get()
    {
        inventoryManager.ResetInventoriButtons();
        if (!getButton)
        {
            textButton3.color = new Color32(91, 255, 0, 255);
            textButton1.color = new Color32(14, 183, 6, 255);
            textButton2.color = new Color32(14, 183, 6, 255);
            getButton = true;
            useButton = false;
            lookButton = false;
        }
        else
        {
            textButton3.color = new Color32(14, 183, 6, 255);
            getButton = false;
        }
    }

    public void ResetButtons()
    {
        textButton3.color = new Color32(14, 183, 6, 255);
        textButton1.color = new Color32(14, 183, 6, 255);
        textButton2.color = new Color32(14, 183, 6, 255);
        getButton = false;
        useButton = false;
        lookButton = false;
    }

}
