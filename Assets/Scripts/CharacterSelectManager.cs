using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class CharacterSelectManager : MonoBehaviour
{
    public static int selectedCharacter = -1;  // Default to -1, meaning no character selected yet.
    
    public GameObject[] playerPrefabs;  // List of player prefabs
    public Button[] skinButtons;  // Buttons representing each skin selection
    public Button startGameButton;  // Start game button

    private void Start()
    {
        // Disable Start Game button initially until a skin is selected
        startGameButton.interactable = false;

        // Ensure no button is highlighted initially
        ResetButtonHighlights();
    }
    public void SelectCharacter(int index)
    {
        // Set the selected character
        selectedCharacter = index;

        // Save the selected character to PlayerPrefs
        PlayerPrefs.SetInt("SelectedAnimal", selectedCharacter); // Save index to PlayerPrefs

        // Enable the Start Game button after a character is selected
        startGameButton.interactable = true;

        // Highlight the selected button visually
        ResetButtonHighlights();  // Reset highlights
        HighlightButton(index);  // Highlight the clicked button
    }

    // Method to load the game scene when the Start button is clicked
    public void StartGame()
    {
        if (selectedCharacter >= 0)  // Ensure a character has been selected
        {
            SceneManager.LoadScene("SampleScene");
        }
        else
        {
            Debug.LogError("No character selected. Please select a skin.");
        }
    }

    // Resets all buttons' colors (or visual indicators)
    private void ResetButtonHighlights()
    {
        foreach (Button btn in skinButtons)
        {
            ColorBlock cb = btn.colors;
            cb.normalColor = Color.white;  // Reset to default white
            btn.colors = cb;
        }
    }

    // Highlights the selected button
    private void HighlightButton(int index)
    {
        ColorBlock cb = skinButtons[index].colors;
        cb.normalColor = Color.green;  // Highlight selected skin with green
        skinButtons[index].colors = cb;
    }
}
