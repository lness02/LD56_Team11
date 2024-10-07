using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] animalPrefabs; // Array of animal player prefabs to choose from
    public Transform spawnPoint; // The spawn point for the player
    public ShadowController[] shadowControllers; // Reference to all ShadowController instances in the scene

    private GameObject playerInstance; // Holds the reference to the spawned player
    private Camera mainCamera; // Reference to the Main Camera


    void Start()
    {
        // Get the main camera reference
        mainCamera = Camera.main;

        int selectedAnimalIndex = PlayerPrefs.GetInt("SelectedAnimal", 0); // Default to the first skin
        SpawnPlayer(selectedAnimalIndex);

        // Assign the player object to all ShadowController scripts
        AssignPlayerToShadows();

        // Assign the camera to the player
        AssignCameraToPlayer();
    }

    void SpawnPlayer(int animalIndex)
    {
        // Instantiate the player at the spawn point
        playerInstance = Instantiate(animalPrefabs[animalIndex], spawnPoint.position, Quaternion.identity);
    }

    void AssignPlayerToShadows()
    {
        // Find all ShadowController instances in the scene
        shadowControllers = FindObjectsOfType<ShadowController>();

        // Assign the player instance to each shadow
        foreach (ShadowController shadow in shadowControllers)
        {
            shadow.AssignPlayer(playerInstance); 
        }
    }

    void AssignCameraToPlayer()
    {
        // Make sure the Main Camera follows the player
        if (mainCamera != null && playerInstance != null)
        {
            // Get the PlayerController from the playerInstance and assign the camera
            PlayerController playerController = playerInstance.GetComponent<PlayerController>();

            if (playerController != null)
            {
                playerController.mainCamera = mainCamera; // Assign the camera
            }
        }
    }
}
