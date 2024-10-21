using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SinkProperties : MonoBehaviour
{
    public bool isActive = false;
    public GameObject eventSystem;
    private string[] text = { "Es un grifo viejuno" };
    private string[] text2 = { "¿Me has visto cara de fontanero?" };
    private string[] text3 = { "¡Madre mía, sale sangre de las cañerías!" };
    private string[] text4 = { "¡No pienso volver a tocar eso!" };

    private GamePlay gamePlay;
    private DialogueManager dialog;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        gamePlay = eventSystem.GetComponent<GamePlay>();
        dialog = GameObject.FindGameObjectWithTag("MainCharacter").GetComponent<DialogueManager>();
        animator = this.GetComponent<Animator>();
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
            if (!isActive && gamePlay.GetuseButton())
            {
                isActive = true;
                animator.SetBool("isFlowing", true);
                dialog.dialogues = text3;
                dialog.StartDialogue();
            }else if (isActive && gamePlay.GetuseButton())
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
                dialog.dialogues = text2;
                dialog.StartDialogue();
            }
    }
}

