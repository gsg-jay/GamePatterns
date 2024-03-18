// MyHUD.cpp

#include "MyHUD.h"
#include "MyCharacter.h"
#include "Engine/Canvas.h"

AMyHUD::AMyHUD()
{
    // Set default font
    static ConstructorHelpers::FObjectFinder<UFont> FontObj(TEXT("/Engine/EngineFonts/Roboto"));
    HUDFont = FontObj.Object;
}

void AMyHUD::DrawHUD()
{
    Super::DrawHUD();

    // Get reference to the player character
    if (!PlayerCharacter)
    {
        PlayerCharacter = Cast<AMyCharacter>(GetOwningPawn());
    }

    if (PlayerCharacter)
    {
        // Draw health bar
        DrawHealthBar(PlayerCharacter->GetHealthPercentage());

        // Draw points
        DrawPoints(PlayerCharacter->GetPoints());
    }
}

void AMyHUD::DrawHealthBar(float HealthPercentage)
{
    // Get canvas
    UCanvas* Canvas = GetCanvas();
    if (!Canvas || !HUDFont) return;

    // Get screen dimensions
    FVector2D ScreenDimensions = FVector2D(Canvas->SizeX, Canvas->SizeY);

    // Calculate size and position of health bar
    FVector2D HealthBarSize = FVector2D(200, 20);
    FVector2D HealthBarPosition = FVector2D((ScreenDimensions.X - HealthBarSize.X) / 2, 50);

    // Draw background of health bar
    FCanvasTileItem HealthBarBackground(HealthBarPosition, FLinearColor::Gray, HealthBarSize);
    Canvas->DrawItem(HealthBarBackground);

    // Draw health bar
    FVector2D HealthBarFillSize = FVector2D(HealthBarSize.X * HealthPercentage, HealthBarSize.Y);
    FCanvasTileItem HealthBarFill(HealthBarPosition, FLinearColor::Green, HealthBarFillSize);
    Canvas->DrawItem(HealthBarFill);
}

void AMyHUD::DrawPoints(int32 Points)
{
    // Get canvas
    UCanvas* Canvas = GetCanvas();
    if (!Canvas || !HUDFont) return;

    // Draw points text
    FString PointsText = FString::Printf(TEXT("Points: %d"), Points);
    FVector2D TextSize;
    GetTextSize(PointsText, TextSize.X, TextSize.Y, HUDFont);
    FVector2D TextPosition = FVector2D(20, 20);
    FCanvasTextItem TextItem(TextPosition, FText::FromString(PointsText), HUDFont, FLinearColor::White);
    Canvas->DrawItem(TextItem);
}
