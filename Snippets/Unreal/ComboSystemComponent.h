// ComboSystemComponent.h

#pragma once

#include "CoreMinimal.h"
#include "Components/ActorComponent.h"
#include "ComboSystemComponent.generated.h"

UCLASS( ClassGroup=(Custom), meta=(BlueprintSpawnableComponent) )
class YOURGAME_API UComboSystemComponent : public UActorComponent
{
    GENERATED_BODY()

public: 
    // Sets default values for this component's properties
    UComboSystemComponent();

protected:
    // Called when the game starts
    virtual void BeginPlay() override;

public: 
    // Called every frame
    virtual void TickComponent(float DeltaTime, ELevelTick TickType, FActorComponentTickFunction* ThisTickFunction) override;

    // Function to handle input for combo sequence
    UFUNCTION(BlueprintCallable)
    void HandleComboInput();

    // Function to reset the combo sequence
    UFUNCTION(BlueprintCallable)
    void ResetComboSequence();

private:
    // Combo sequence
    TArray<FKey> ComboKeys;

    // Index of the current key in the combo sequence
    int32 CurrentComboIndex;

    // Time window for performing the combo
    float ComboInputTimeWindow;

    // Time since the last input
    float LastInputTime;

    // Function to check if the combo sequence is complete
    bool IsComboComplete() const;

    // Function to reset the combo sequence after a timeout
    void ResetComboSequenceDelayed();
};
