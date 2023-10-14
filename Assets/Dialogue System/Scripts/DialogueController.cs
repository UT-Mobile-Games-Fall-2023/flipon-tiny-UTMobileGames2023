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

    public void StartDialogue(SingleDialogueData dialogueData)
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
    public void StartDialogue(MultiDialogueData dialogueData)
    {
        if (dialogueData == null)
        {
            Debug.LogWarning("Dialogue Data is null. Cannot start dialogue.");
            return;
        }

        if (dialogueData.dialogueEntries.Count == 0)
        {
            Debug.LogWarning("Dialogue Data does not contain any dialogue entries.");
            return;
        }

        characterName.text = dialogueData.dialogueEntries[0].characterName;
        characterImage.sprite = dialogueData.dialogueEntries[0].characterSprite;

        sentences.Clear();

        foreach (MultiDialogueData.DialogueEntry entry in dialogueData.dialogueEntries)
        {
            sentences.Enqueue(entry.sentence);
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


