using UnityEngine;
using UnityEngine.SceneManagement; 

public class CharacterSelectManager : MonoBehaviour
{
    // Create a static variable to store the selected character index across scenes
    public static int selectedCharacter = 0;

    // These will hold the references to the player prefabs (Rat, Rabbit, Bird, Squirrel)
    public GameObject[] playerPrefabs;

    // Method to select the character when a button is clicked
    public void SelectCharacter(int index)
    {
        selectedCharacter = index;  // Set the selected character index
        SceneManager.LoadScene("SampleScene");  // Load the game scene after selection
    }
}
