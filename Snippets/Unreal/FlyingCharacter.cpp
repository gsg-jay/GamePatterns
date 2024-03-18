// FlyingCharacter.cpp

#include "FlyingCharacter.h"

// Sets default values
AFlyingCharacter::AFlyingCharacter()
{
    // Set default flying speed
    FlyingSpeed = 1000.0f;

    // Initialize flying flag
    bIsFlying = false;
}

// Called when the game starts or when spawned
void AFlyingCharacter::BeginPlay()
{
    Super::BeginPlay();
}

// Called every frame
void AFlyingCharacter::Tick(float DeltaTime)
{
    Super::Tick(DeltaTime);

    // Check if the character is flying
    if (bIsFlying)
    {
        // Implement flying logic here
        FVector NewLocation = GetActorLocation() + GetActorUpVector() * FlyingSpeed * DeltaTime;
        SetActorLocation(NewLocation);
    }
}

// Called to bind functionality to input
void AFlyingCharacter::SetupPlayerInputComponent(UInputComponent* PlayerInputComponent)
{
    Super::SetupPlayerInputComponent(PlayerInputComponent);

    // Bind flying input
    PlayerInputComponent->BindAxis("Fly", this, &AFlyingCharacter::HandleFlyingInput);
}

// Function to handle flying input
void AFlyingCharacter::HandleFlyingInput(float Value)
{
    // Check if the flying input axis value is greater than a threshold
    if (Value > 0.5f)
    {
        // Start flying
        bIsFlying = true;
    }
    else
    {
        // Stop flying
        bIsFlying = false;
    }
}
