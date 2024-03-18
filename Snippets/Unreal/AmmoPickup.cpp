// AmmoPickup.cpp

#include "AmmoPickup.h"

// Sets default values for this component's properties
UAmmoPickup::UAmmoPickup()
{
    // Set default ammo count
    AmmoCount = 10;
}

// Called when the game starts
void UAmmoPickup::BeginPlay()
{
    Super::BeginPlay();
}

// Called when the ammo pickup is collected
void UAmmoPickup::OnPickupCollected()
{
    // Implement ammo collection logic here
    // For example, add the collected ammo to the player's inventory
}
