// MyHUD.h

#pragma once

#include "CoreMinimal.h"
#include "GameFramework/HUD.h"
#include "MyHUD.generated.h"

UCLASS()
class YOURGAME_API AMyHUD : public AHUD
{
    GENERATED_BODY()

public:
    // Sets default values for this HUD's properties
    AMyHUD();

protected:
    // Called when the HUD is being drawn
    virtual void DrawHUD() override;

    // Reference to the player character
    class AMyCharacter* PlayerCharacter;

    // Font used for drawing text
    UPROPERTY(EditDefaultsOnly, Category = "HUD")
    UFont* HUDFont;

    // Function to draw the health bar
    void DrawHealthBar(float HealthPercentage);

    // Function to draw points
    void DrawPoints(int32 Points);
};
