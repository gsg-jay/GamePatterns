// HealthPickup.h

#pragma once

#include "CoreMinimal.h"
#include "PickupBase.h"
#include "HealthPickup.generated.h"

UCLASS(ClassGroup=(Custom), meta=(BlueprintSpawnableComponent))
class YOURGAME_API UHealthPickup : public UPickupBase
{
    GENERATED_BODY()

public: 
    // Sets default values for this component's properties
    UHealthPickup();

    // Amount of health restored by this pickup
    UPROPERTY(EditAnywhere, BlueprintReadOnly, Category = "Health")
    float HealthRestoreAmount;
};
