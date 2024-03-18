// PickupBase.cpp

#include "PickupBase.h"

// Sets default values for this component's properties
UPickupBase::UPickupBase()
{
    // Set this component to be initialized when the game starts, and to be ticked every frame
    PrimaryComponentTick.bCanEverTick = false;
}

// Called when the game starts
void UPickupBase::BeginPlay()
{
    Super::BeginPlay();
}

// Function to execute when the pickup is collected
void UPickupBase::OnPickupCollected()
{
    // Implement this function in child classes
}
