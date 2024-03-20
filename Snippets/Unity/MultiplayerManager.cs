using UnityEngine;

namespace GSG {
  public class MultiplayerManager : MonoBehaviour
  {
      public GameObject playerPrefab;
      public Transform[] spawnPoints;
      private GameObject[] players = new GameObject[4];   // Array to store player objects
      private int[] gamepadIndices = new int[4];         // Array to store gamepad indices for each player
  
      void Update()
      {
          // Check for player join input
          for (int i = 1; i <= 4; i++)
          {
              if (Input.GetButtonDown("JoinPlayer" + i))
              {
                  // Find an available player slot
                  int playerIndex = FindAvailablePlayerIndex();
  
                  // Spawn player if not already spawned
                  if (playerIndex != -1 && players[playerIndex] == null)
                  {
                      players[playerIndex] = Instantiate(playerPrefab, spawnPoints[playerIndex].position, Quaternion.identity);
                      gamepadIndices[playerIndex] = i; // Map gamepad index to player index
                  }
              }
          }
  
          // Check for player leave input
          for (int i = 0; i < players.Length; i++)
          {
              if (players[i] != null && Input.GetButtonDown("LeavePlayer" + gamepadIndices[i]))
              {
                  Destroy(players[i]);
                  players[i] = null;
              }
          }
      }
  
      int FindAvailablePlayerIndex()
      {
          for (int i = 0; i < players.Length; i++)
          {
              if (players[i] == null)
              {
                  return i;
              }
          }
          return -1; // No available player slots
      }
  }
}
