using UnityEngine;
using UnityEngine.Events;
using System;
using System.Collections.Generic;

namespace GSG
{
  public class Player : MonoBehaviour, ICharacterBase
  {
    private const _inputDeadzone = 0.01;
    public int joypadIndex;
    public CharacterProfile currentCharacter;
    private string _inputMap; // TODO Define in own class
    public string[] inputBuffer; // For buffering command inputs
    public UnityEvent OnControlsChanged;
    public UnityEvent OnQuarterCircleMotion;
    public UnityEvent OnQuarterCircleMotion;
    public UnityEvent OnHalfCircleMotion;

    // Unreal (Tick)
    void Update()
    {
      // Check for Game Paused
      Move(new Vector2(
        Input.GetAxis($"Gamepad{joypadIndex}Horizontal"),
        Input.GetAxis($"Gamepad{joypadIndex}Vertical"))
      );
    }
    public void Move(Vector2 moveVector)
    {
      throw new NotImplementedException("Player::Move not implemented!");
    }
    // Start
    public void ButtonStart()
    {
      inputBuffer.push("Start");
    }
    // L1
    public void ButtonLeftShoulder()
    {
      inputBuffer.push("LeftShoulder");
    }
    // L2
    public void ButtonLeftTrigger()
    {
      inputBuffer.push("LeftTrigger");
    }
    // R1
    public void ButtonRightShoulder()
    {
      inputBuffer.push("RightShoulder");
    }
    // R2
    public void ButtonRightTrigger()
    {
      inputBuffer.push("RightTrigger");
    }
    // TRIANGLE
    public void ButtonNorth()
    {
      inputBuffer.push("ButtonNorth");
    }
    // CROSS
    public void ButtonSouth()
    {
      inputBuffer.push("ButtonSouth");
    }
    // CIRCLE
    public void ButtonEast()
    {
      inputBuffer.push("ButtonEast");
    }
    // SQUARE
    public void ButtonWest()
    {
      inputBuffer.push("ButtonWest");
    }
    public void ClearInputBuffer()
    {
      inputBuffer = new string[0];
    }
    public void AssignControls(string inputMap)
    {
      _inputMap = inputMap;
      throw new NotImplementedException("Player::Move not implemented!");
    }
  }
}
