// AmmoPickup.h

#pragma once

#include "CoreMinimal.h"
#include "PickupBase.h"
#include "AmmoPickup.generated.h"

UCLASS(ClassGroup=(Custom), meta=(BlueprintSpawnableComponent))
class YOURGAME_API UAmmoPickup : public UPickupBase
{
    GENERATED_BODY()

public: 
    // Sets default values for this component's properties
    UAmmoPickup();

    // Number of bullets in this ammo pickup
    UPROPERTY(EditAnywhere, BlueprintReadOnly, Category = "Ammo")
    int32 AmmoCount;
};
