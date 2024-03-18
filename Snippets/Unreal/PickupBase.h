// PickupBase.h

#pragma once

#include "CoreMinimal.h"
#include "Components/ActorComponent.h"
#include "PickupBase.generated.h"

UCLASS(ClassGroup=(Custom), meta=(BlueprintSpawnableComponent))
class YOURGAME_API UPickupBase : public UActorComponent
{
    GENERATED_BODY()

public: 
    // Sets default values for this component's properties
    UPickupBase();

    // Called when the game starts
    virtual void BeginPlay() override;

    // Function to execute when the pickup is collected
    UFUNCTION(BlueprintCallable)
    virtual void OnPickupCollected();
};
