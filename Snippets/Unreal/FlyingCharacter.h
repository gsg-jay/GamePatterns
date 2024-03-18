// FlyingCharacter.h

#pragma once

#include "CoreMinimal.h"
#include "GameFramework/Character.h"
#include "FlyingCharacter.generated.h"

UCLASS()
class YOURGAME_API AFlyingCharacter : public ACharacter
{
    GENERATED_BODY()

public:
    // Sets default values for this character's properties
    AFlyingCharacter();

protected:
    // Called when the game starts or when spawned
    virtual void BeginPlay() override;

public: 
    // Called every frame
    virtual void Tick(float DeltaTime) override;

    // Called to bind functionality to input
    virtual void SetupPlayerInputComponent(class UInputComponent* PlayerInputComponent) override;

private:
    // Movement speed while flying
    UPROPERTY(EditAnywhere, Category = "Flying")
    float FlyingSpeed;

    // Function to handle flying input
    void HandleFlyingInput(float Value);

    // Flag to check if the character is flying
    bool bIsFlying;
};
