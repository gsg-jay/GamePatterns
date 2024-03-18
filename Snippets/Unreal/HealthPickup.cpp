// HealthPickup.cpp

#include "HealthPickup.h"

// Sets default values for this component's properties
UHealthPickup::UHealthPickup()
{
    // Set default health restore amount
    HealthRestoreAmount = 25.0f;
}

// Called when the game starts
void UHealthPickup::BeginPlay()
{
    Super::BeginPlay();
}

// Called when the health pickup is collected
void UHealthPickup::OnPickupCollected()
{
    // Implement health collection logic here
    // For example, restore the player's health by HealthRestoreAmount
}
