using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    public GameObject DialoguePanel;

    public TMP_Text characterName;
    public TMP_Text dialogueText;
    public Image characterImage;

    private Queue<string> sentences;

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(DialogueData dialogueData)
    {
        characterName.text = dialogueData.characterName;
        characterImage.sprite = dialogueData.characterSprite;

        sentences.Clear();

        foreach (string sentence in dialogueData.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }
	private void Update()
	{
        // Add touch input detection and call DisplayNextSentence when touched.
        if (Input.GetMouseButtonDown(0))
        {
            DisplayNextSentence();
        }
    }
	void EndDialogue()
    {
        DialoguePanel.SetActive(false);
    }
}


