using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosetProperties : MonoBehaviour
{
    private bool isActive = false;
    private bool isReady = true;
    public GameObject eventSystem;
    private float timeActive = 0f;
    private string[] text = { "Es un armario, pero no hay forma de abrirlo.", "¿Dónde están los pomos cuando los necesitas?" };
    private string[] text2 = { "¡Qué cantidad de pasta!" };
    private string[] text3 = { "¡No puedo llevarme un armario!" };
    private string[] text4 = { "¡No se puede abrir!" };
    private string[] text5 = { "Me voy a cargar el armario con la motosierra" };

    private GamePlay gamePlay;
    private DialogueManager dialog;
    private InventoryManager inventoryManager;
    private string inventoryItem = "";
    [SerializeField] private Sprite sprite1;
    [SerializeField] private Sprite sprite2;
    [SerializeField] private Sprite sprite3;

    // Start is called before the first frame update
    void Start()
    {
        gamePlay = eventSystem.GetComponent<GamePlay>();
        dialog = GameObject.FindGameObjectWithTag("MainCharacter").GetComponent<DialogueManager>();
        inventoryManager = GameObject.FindGameObjectWithTag("Inventario").GetComponent<InventoryManager>();
    }

    private void Update()
    {
        CheckButtonDown();
        ClosetStatus();
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


    private void ClosetStatus()
    {
        if (isActive && isReady)
        {
            timeActive = timeActive + Time.deltaTime;
            if (timeActive <= 1)
            {
                this.GetComponent<SpriteRenderer>().sprite = sprite1;
            }
            else if (timeActive > 1f && timeActive <= 3f)
            {
                this.GetComponent<SpriteRenderer>().sprite = sprite2;
            }
            else
            {
                this.GetComponent<SpriteRenderer>().sprite = sprite3;
                isReady = false;
            }
        }
    }


    private void OnMouseClick()
    {
        inventoryItem = inventoryManager.GetButtonPressed();
        if (inventoryItem == "")
        {

            if (!isActive && gamePlay.GetuseButton())
            {
                dialog.dialogues = text4;
                dialog.StartDialogue();
            }
            if (!isActive && gamePlay.GetlookButton())
            {
                dialog.dialogues = text;
                dialog.StartDialogue();
            }
            if (!isActive && gamePlay.GetgetButton())
            {
                dialog.dialogues = text3;
                dialog.StartDialogue();
            }
            if (isActive && gamePlay.GetlookButton())
            {
                dialog.dialogues = text2;
                dialog.StartDialogue();
            }
        }
        else if(inventoryItem == "Chainsaw")
        {
            dialog.dialogues = text5;
            dialog.StartDialogue();
            isActive = true;
        }
    }

}
