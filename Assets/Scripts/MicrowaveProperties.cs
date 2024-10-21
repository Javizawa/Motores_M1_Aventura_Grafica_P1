using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MicrowaveProperties : MonoBehaviour
{
    public bool isActive = false;
    public bool isReady = true;
    public GameObject eventSystem;
    private float timeActive = 0f;
    private string[] text = { "Parece que funciona","¡Anda, parece que hay palomitas!", "¡Madre mía! ¡Había algo vivo!" };
    private string[] text2 = { "Es un microondas", "¿Me pregunto si funciona?" };
    private string[] text3 = { "No pienso abrir eso", "A saber lo que me he cargado" };
    private string[] text4 = { "¿Lo meto en el bolsillo?", "¿Cómo voy a llevarme eso?" };

    [SerializeField] private Sprite sprite1;
    [SerializeField] private Sprite sprite2;
    [SerializeField] private Sprite sprite3;

    private GamePlay gamePlay;
    private AudioSource sound;
    private DialogueManager dialog;

    // Start is called before the first frame update
    void Start()
    {
        gamePlay = eventSystem.GetComponent<GamePlay>();
        sound = this.GetComponent<AudioSource>();
        sound.volume = 1f;
        dialog = GameObject.FindGameObjectWithTag("MainCharacter").GetComponent<DialogueManager>();
    }

    private void Update()
    {
        CheckButtonDown();
        MicrowaveStatus();
    }



    private void MicrowaveStatus()
    {
        if (isActive && isReady && gamePlay.GetuseButton())
        {
            timeActive = timeActive + Time.deltaTime;
            if (timeActive <= 3)
            {
                this.GetComponent<SpriteRenderer>().sprite = sprite1;
            }
            else if (timeActive > 3f && timeActive <= 5f)
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
            sound.Play();
            dialog.dialogues = text;
            dialog.StartDialogue();
        }
        if (gamePlay.GetlookButton())
        {
            if (!isActive) {
                dialog.dialogues = text2;
                dialog.StartDialogue();
            }
            else
            {
                dialog.dialogues = text3;
                dialog.StartDialogue();
            }
        }
        if (gamePlay.GetgetButton())
        {
            dialog.dialogues = text4;
            dialog.StartDialogue();
        }
    }
}

