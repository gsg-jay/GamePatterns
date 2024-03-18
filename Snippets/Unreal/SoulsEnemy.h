// SoulsEnemyAI.h

#pragma once

#include "CoreMinimal.h"
#include "AIController.h"
#include "SoulsEnemyAI.generated.h"

UCLASS()
class YOURGAME_API ASoulsEnemyAI : public AAIController
{
    GENERATED_BODY()

public:
    ASoulsEnemyAI();

protected:
    virtual void BeginPlay() override;
    virtual void Tick(float DeltaTime) override;

private:
    // Reference to the player character
    APawn* PlayerCharacter;

    // AI behavior variables
    bool bIsAttacking;
    bool bIsDodging;
    float AttackCooldown;
    float DodgeCooldown;
    float Stamina;

    // AI behavior functions
    void TrackPlayer();
    void Attack();
    void Dodge();

    // AI utility functions
    bool IsPlayerInRange(float Range) const;
    bool CanAttack() const;
    bool CanDodge() const;
};
