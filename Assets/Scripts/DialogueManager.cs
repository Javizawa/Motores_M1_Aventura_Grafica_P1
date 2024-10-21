using System.Collections;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public string[] dialogues;
    public float letterDelay = 0.05f; // Delay entre cada letra

    private Animator animator;

    private Coroutine typingCoroutine;

    void Start()
    {
        //textMeshPro = this.GetComponentInChildren<TextMeshProUGUI>();
        animator = GameObject.FindGameObjectWithTag("MainCharacter").GetComponent<Animator>();
        // Comienza el diálogo
        StartDialogue();
    }

    public void StartDialogue()
    {
        // Inicia la corutina para mostrar el texto
        typingCoroutine = StartCoroutine(TypeDialogue());
    }

    IEnumerator TypeDialogue()
    {
        foreach (string dialogue in dialogues)
        {
            // Limpia el texto actual
            textMeshPro.text = "";

            animator.SetBool("isSpeaking", true);

            // Muestra el texto letra por letra
            foreach (char letter in dialogue)
            {
                textMeshPro.text += letter;
                yield return new WaitForSeconds(letterDelay);
            }

            // Espera hasta que el jugador pulse una tecla antes de pasar al siguiente diálogo
//            yield return new WaitUntil(() => Input.anyKeyDown);
        }

        // Fin del diálogo
        animator.SetBool("isSpeaking", false);
    }

    public void SkipDialogue()
    {
        // Si el diálogo está siendo mostrado letra por letra, se puede saltar al siguiente diálogo
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
            typingCoroutine = null;
            textMeshPro.text = dialogues[dialogues.Length - 1]; // Muestra todo el texto de una vez
        }
    }
}