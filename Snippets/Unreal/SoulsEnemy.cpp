// SoulsEnemyAI.cpp

#include "SoulsEnemyAI.h"
#include "GameFramework/Character.h"
#include "Kismet/GameplayStatics.h"

ASoulsEnemyAI::ASoulsEnemyAI()
{
    // Initialize variables
    bIsAttacking = false;
    bIsDodging = false;
    AttackCooldown = 0.0f;
    DodgeCooldown = 0.0f;
    Stamina = 100.0f;
}

void ASoulsEnemyAI::BeginPlay()
{
    Super::BeginPlay();

    // Find the player character
    PlayerCharacter = UGameplayStatics::GetPlayerPawn(this, 0);
}

void ASoulsEnemyAI::Tick(float DeltaTime)
{
    Super::Tick(DeltaTime);

    if (PlayerCharacter)
    {
        // Track the player
        TrackPlayer();

        // Perform attack
        if (IsPlayerInRange(200.0f) && CanAttack())
        {
            Attack();
        }

        // Perform dodge
        if (IsPlayerInRange(300.0f) && CanDodge())
        {
            Dodge();
        }
    }

    // Update cooldowns
    AttackCooldown = FMath::Max(AttackCooldown - DeltaTime, 0.0f);
    DodgeCooldown = FMath::Max(DodgeCooldown - DeltaTime, 0.0f);
}

void ASoulsEnemyAI::TrackPlayer()
{
    // Rotate towards the player
    if (PlayerCharacter)
    {
        FRotator LookAtRotation = UKismetMathLibrary::FindLookAtRotation(GetPawn()->GetActorLocation(), PlayerCharacter->GetActorLocation());
        GetPawn()->SetActorRotation(LookAtRotation);
    }
}

void ASoulsEnemyAI::Attack()
{
    // Perform attack logic
    bIsAttacking = true;
    // Implement attack animation and damage to player
    AttackCooldown = 2.0f; // Set attack cooldown
}

void ASoulsEnemyAI::Dodge()
{
    // Perform dodge logic
    bIsDodging = true;
    // Implement dodge animation
    DodgeCooldown = 3.0f; // Set dodge cooldown
}

bool ASoulsEnemyAI::IsPlayerInRange(float Range) const
{
    // Check if player is within range
    if (PlayerCharacter)
    {
        return FVector::Dist(GetPawn()->GetActorLocation(), PlayerCharacter->GetActorLocation()) <= Range;
    }
    return false;
}

bool ASoulsEnemyAI::CanAttack() const
{
    // Check if attack is off cooldown and AI has enough stamina
    return !bIsAttacking && AttackCooldown <= 0.0f && Stamina >= 20.0f;
}

bool ASoulsEnemyAI::CanDodge() const
{
    // Check if dodge is off cooldown and AI has enough stamina
    return !bIsDodging && DodgeCooldown <= 0.0f && Stamina >= 30.0f;
}
