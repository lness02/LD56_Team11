using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Reference to the player prefabs
    public GameObject[] playerPrefabs;
    public Transform spawnPoint;  // Where the player will spawn in the game scene

    void Start()
    {
        // Instantiate the selected player character based on the selected index
        int selectedCharacter = CharacterSelectManager.selectedCharacter;
        Instantiate(playerPrefabs[selectedCharacter], spawnPoint.position, Quaternion.identity);
    }
}
