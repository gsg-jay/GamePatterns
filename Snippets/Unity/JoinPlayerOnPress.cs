using UnityEngine;
using System;

// Script that will spawn a new player when a button on a device is pressed.
public class JoinPlayerOnPress : MonoBehaviour
{
  // We instantiate this GameObject to create a new player object.
  // Expected to have a PlayerInput component in its hierarchy.
  public GameObject playerPrefab;
  
  // We want to remove the event listener we install through InputSystem.onAnyButtonPress
  // after we're done so remember it here.
  private IDisposable m_EventListener;
  
  // When enabled, we install our button press listener.
  void OnEnable()
  {
      // Start listening.
      m_EventListener =
          InputSystem.onAnyButtonPress
              .Call(OnButtonPressed)
  }
  
  // When disabled, we remove our button press listener.
  void OnDisable()
  {
      m_EventListener.Dispose();
  }
  
  void OnButtonPressed(InputControl button)
  {
      var device = button.device;
  
      // Ignore presses on devices that are already used by a player.
      if (PlayerInput.FindFirstPairedToDevice(device) != null)
          return;
  
      // Create a new player.
      var player = PlayerInput.Instantiate(playerPrefab, pairWithDevice: device);
  
      // If the player did not end up with a valid input setup,
      // unjoin the player.
      if (player.hasMissingRequiredDevices)
          Destroy(player);
  
      // If we only want to join a single player, could uninstall our listener here
      // or use CallOnce() instead of Call() when we set it up.
  }
}
