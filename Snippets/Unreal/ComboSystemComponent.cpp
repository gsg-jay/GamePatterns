// ComboSystemComponent.cpp

#include "ComboSystemComponent.h"

// Sets default values for this component's properties
UComboSystemComponent::UComboSystemComponent()
{
    // Set this component to be initialized when the game starts, and to be ticked every frame
    PrimaryComponentTick.bCanEverTick = true;

    // Initialize variables
    ComboInputTimeWindow = 0.5f; // Adjust as needed
    CurrentComboIndex = 0;
    LastInputTime = 0.0f;

    // Add combo sequence keys (example sequence)
    ComboKeys.Add(EKeys::Gamepad_FaceButton_West);
    ComboKeys.Add(EKeys::Gamepad_FaceButton_West);
    ComboKeys.Add(EKeys::Gamepad_FaceButton_West);
}

// Called when the game starts
void UComboSystemComponent::BeginPlay()
{
    Super::BeginPlay();
}

// Called every frame
void UComboSystemComponent::TickComponent(float DeltaTime, ELevelTick TickType, FActorComponentTickFunction* ThisTickFunction)
{
    Super::TickComponent(DeltaTime, TickType, ThisTickFunction);

    // Check for combo input
    if (IsComboComplete())
    {
        // Perform combo action
        UE_LOG(LogTemp, Warning, TEXT("Combo sequence complete!"));
        ResetComboSequence();
    }
}

// Function to handle input for combo sequence
void UComboSystemComponent::HandleComboInput()
{
    if (IsComboComplete())
    {
        // Reset combo sequence if it's complete
        ResetComboSequence();
    }
    else if (CurrentComboIndex < ComboKeys.Num())
    {
        // Check if the current input matches the expected key in the combo sequence
        if (GetCurrentInputKey() == ComboKeys[CurrentComboIndex])
        {
            // Move to the next key in the combo sequence
            CurrentComboIndex++;
            LastInputTime = GetWorld()->GetTimeSeconds();
        }
        else
        {
            // Reset combo sequence if the input is incorrect
            ResetComboSequence();
        }
    }
}

// Function to reset the combo sequence
void UComboSystemComponent::ResetComboSequence()
{
    CurrentComboIndex = 0;
    LastInputTime = 0.0f;
}

// Function to check if the combo sequence is complete
bool UComboSystemComponent::IsComboComplete() const
{
    return CurrentComboIndex >= ComboKeys.Num();
}

// Function to reset the combo sequence after a timeout
void UComboSystemComponent::ResetComboSequenceDelayed()
{
    // Check if the timeout has elapsed since the last input
    if (GetWorld()->GetTimeSeconds() - LastInputTime >= ComboInputTimeWindow)
    {
        ResetComboSequence();
    }
}
