using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChainsawProperties : MonoBehaviour
{
    public bool isActive = false;
    public GameObject eventSystem;
    private string itemName = "Chainsaw";
    private string[] text = { "¿Quién tiene una motosierra en la cocina?", "¿La usará para cortar el pan?" };
    private string[] text2 = { "¡Pues me la llevo!", "Nunca se sabe para qué la puedo usar" };
    private string[] text3 = { "¡Paso de usarla ahora!", "¡Ya hay demasiada sangre en la cocina!" };

    private GamePlay gamePlay;
    private DialogueManager dialog;
    [SerializeField] private GameObject inventory;

    // Start is called before the first frame update
    void Start()
    {
        gamePlay = eventSystem.GetComponent<GamePlay>();
        dialog = GameObject.FindGameObjectWithTag("MainCharacter").GetComponent<DialogueManager>();
    }

    private void Update()
    {
        CheckButtonDown();
    }

    private void CheckButtonDown()
    {
        // Detectar clic izquierdo del ratón
        if (Input.GetMouseButtonDown(0))
        {
            // Crear un raycast desde la cámara hacia el mouse
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            // Verificar si el raycast colisionó con un objeto
            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                OnMouseClick();
            }
        }
    }

    private void OnMouseClick()
    {
        if (!isActive) { 
            if (!isActive && gamePlay.GetuseButton())
            {
                dialog.dialogues = text3;
                dialog.StartDialogue();
            }
            if (!isActive && gamePlay.GetlookButton())
            {
                dialog.dialogues = text;
                dialog.StartDialogue();
            }
            if (!isActive && gamePlay.GetgetButton())
            {
                isActive = true;
                dialog.dialogues = text2;
                dialog.StartDialogue();
                inventory.GetComponent<InventoryManager>().AddItem(this.GetComponent<SpriteRenderer>().sprite, itemName);
                this.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 0);
                this.GetComponent<SpriteRenderer>().sprite = null;
            }
        }
    }
}

