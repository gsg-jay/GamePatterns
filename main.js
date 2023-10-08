const fs = require("node:fs")
const inquirer = require("inquirer")

const projectName = `GSGUEGameTemplate`;
const templateHeader = (name, classType) => `
#pragma once

#include "CoreMinimal.h"
#include "GameFramework/${classType}.h"
#include "${name}.generated.h"

DECLARE_DYNAMIC_MULTICAST_DELEGATE(FOn${name}InteractEvent);
// DECLARE_DYNAMIC_MULTICAST_DELEGATE(FOnSomeEvent);

UCLASS()
class ${projectName} ${name} : public A${classType}
{
    GENERATED_BODY()

public:
    // Sets default values for this actor's properties
    ${name}${classType}();

    // ---------------------------------------------------------
    // Auto generated  - continue this pattern
    // ---------------------------------------------------------
    // Event to be triggered when the actor is interacted with
    UPROPERTY(BlueprintAssignable, Category = "Events")
    FOn${name}InteractEvent On${name}Interact;

    // ---------------------------------------------------------
    // Placeholder
    // ---------------------------------------------------------
    // Event to be triggered when the actor is interacted with
    // UPROPERTY(BlueprintAssignable, Category = "Events")
    // FOnSomeEvent OnSomeInteract;

    // ---------------------------------------------------------
    // Auto generated  - continue this pattern
    // ---------------------------------------------------------
    // Function to simulate an interaction
    UFUNCTION(BlueprintCallable, Category = "${name}Interactions")
    void Interact();

    // ---------------------------------------------------------
    // Placeholder
    // ---------------------------------------------------------
    // Function for something else
    // UFUNCTION(BlueprintCallable, Category = "${name}Actions")
    // void SomeAction();
};
`;
const templateCPP = (name, classType) => `
#include "${name}${classType}.h"

// Sets default values
${name}${classType}::${name}${classType}()
{
    // Set this actor to call Tick() every frame
    PrimaryActorTick.bCanEverTick = false;
}

// ---------------------------------------------------------
// Auto generated  - continue this pattern
// ---------------------------------------------------------
// Simulate an interaction
void ${name}${classType}::Interact()
{
    // Perform interaction logic here

    // Trigger the OnInteract event
    On${name}Interact.Broadcast();
}
// ---------------------------------------------------------
// Placeholder
// ---------------------------------------------------------
void ${name}${classType}::SomeAction()
{
    // Perform interaction logic here
    // Trigger the OnSomeAction event
    OnSomeAction.Broadcast();
}
`;

// Flying,
// GameUIMenu,
// Quest,
// ResourceGauge,
// ImpactFX,
// Vehicle,
// WorldMap,
// WorldTimeReceiver,
// BossEnemy,
// Adventurer,
// Inventory,
// GameMovieSequence,
// ForceReceiver,
// GunFighter,
// MeleeFighter,
// Item,
// ResourceGauge


// Lifecycle SummonAssist AIAgent JuggleReceiver StunReceiver Combat Destructible GameItem Hazard

inquirer
    .prompt([
        {
            type: 'list',
            name: 'ClassType',
            message: 'What do you want to create?',
            choices: ["Actor", "Pawn"]
        },
        {
            type: 'input',
            name: 'Classes',
            message: 'Write a space separated list of the class names (e.g. Player Enemy)?',
        },
    ])
    .then((answers) => {
        // Use user feedback for... whatever!!
        console.log(answers.Classes.replace(" ", ""))
        const { Classes, ClassType } = answers;
        const _list = Classes.split(' ');

        let classPrefix = "A";
        let classSuffix = "Actor";
        if (ClassType === "Pawn") {
            classSuffix = "Pawn"
        }

        for (let i = 0; i < _list.length; i++) {
            let item = _list[i];
            const filename = `${classPrefix}${item}${classSuffix}`
            fs.mkdirSync("interfaces/" + filename);
            fs.writeFileSync(
                `interfaces/${filename}/${filename}.cpp`,
                templateHeader(filename, ClassType)
            );
            fs.writeFileSync(`interfaces/${filename}/${filename}.h`, templateCPP(filename, ClassType));
        }
    })
    .catch((error) => {
        if (error.isTtyError) {
            // Prompt couldn't be rendered in the current environment
            return console.log("Error", error)
        } else {
            // Something else went wrong
            return console.log("A general error occurred!")
        }
    });
