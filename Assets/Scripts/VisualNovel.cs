using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity; 
using UnityEngine.UI;

public class VisualNovel : MonoBehaviour
{
    private DialogueRunner dialogueRunner;
    public Dictionary<string, Character> characters = new Dictionary<string, Character>();
    public Image characterSprite;
    public Image backgroundSprite;
    public Character rat; 

    private void Awake() {
        dialogueRunner = FindObjectOfType<Yarn.Unity.DialogueRunner>();  
        characters.Add(rat.fullName, rat);
    }

    public void StartDialogue(string node) {
        dialogueRunner.StartDialogue(node); 
    }

    public void PauseGame() {
        Time.timeScale = 0f;
    }

    public void ResumeGame() {
        Time.timeScale = 1f;
    }

    [YarnCommand("show_sprite")]
    public void Show() {
        characterSprite.enabled = true;
    }

    [YarnCommand("hide_sprite")]
    public void Hide() {
        characterSprite.enabled = false; 
    }

    [YarnCommand("show_background")]
    public void ShowBackground() {
        backgroundSprite.enabled = true;
    }

    [YarnCommand("hide_background")]
    public void HideBackground() {
        backgroundSprite.enabled = false; 
    }

    // use <<change_character characterName mood>>
    [YarnCommand("change_character")]
    public void ChangeCharacter(string characterName, string mood)
    {
        Vector2 spriteSize = Vector2.zero; 

        if (characters.ContainsKey(characterName))
        {
            if (mood == "neutral")
            {
                characterSprite.sprite = characters[characterName].neutral;
                spriteSize = characters[characterName].neutral.bounds.size;
            }
            else
            {
                Debug.LogError("Mood not found for character: " + characterName);
            }

            // resize
            RectTransform rectTransform = characterSprite.GetComponent<RectTransform>();
            if (rectTransform != null)
            {
                rectTransform.sizeDelta = spriteSize * 150;
            }
            else
            {
                Debug.LogError("RectTransform not found on Image component!");
            }
        }
        else
        {
            Debug.LogError("Character not found: " + characterName);
        }
    }
}
