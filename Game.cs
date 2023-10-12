// []
class GameSession
{
    Player[] _players = null;

    public int GetPlayerCount()
    {
        return _players.Num();
    }

    public int SetPlayers(int playerCount)
    {
        _players = playerCount;
        return _players;
    }
    public Vec3 SetPlayerSpawnPosition(Player playerToChange, Vec3 startPosition)
    {
        playerToChange.SetPosition(startPosition);
        return startPosition;
    }
}

class GameEntity
{
    // Var
    int _health;
    int _maxHealth;
    public bool isDead;

    // Fn
    public int SetHealth(int newHealth)
    {
        _health = newHealth;
        return _health;
    }
    public int SetMaxHealth(int newMaxHealth)
    {
        _maxHealth = newMaxHealth;
        return _maxHealth;
    }
    public int GetHealth()
    {
        return _health;
    }
    public int TakeDamage(int damage)
    {
        _health -= damage;
        return _health;
    }
}

class Hitbox
{

}
class Hurtbox
{
    private GameEntity _owner;
    public int _base_damage;
    public void GetOwner()
    {
        return _owner;
    }
}

class Collectible
{
    public string collecitble_id;
    // Various properties
}

class Weapon
{
    public string weapon_id;
}

class Hazard
{
    public string hazard_id;
}

class Interactible
{
    UENUM(BlueprintType)
    enum class InteractibleType : uint8
    {
        BUTTON,
        VEHICLE
    }
}

class LevelEventZone
{
    string level_event_id;
    UENUM(BlueprintType)
    enum class LevelEventType : uint8
    {
        LEVEL_CLEAR,
        STORY_EVENT,
        FAILED,
        SUCCESS
    };
}

class EventZone
{
    UENUM()
    enum class EventZoneType
    {
        LEVEL_EVENT,
        STORY_EVENT
    }
    public EventZoneType event_type;
    public string event_id;
    public bool is_started = false;
    public bool is_complete = false;
    void TriggerEvent(EventZoneType eventType, string eventIDToTrigger)
    {
        if (eventType === EventZoneType.LEVEL_EVENT && !this.is_complete && !this.is_started)
        {
            // Broadcast Level event (eventIDToTrigger)
        }
        if (eventType === EventZoneType.STORY_EVENT && !this.is_complete && !this.is_started)
        {
            // Broadcast Story event (eventIDToTrigger)
        }
    }
    void SetComplete()
    {
        is_started = true;
    }
    void SetStarted()
    {
        is_complete = false;
        is_started = true;
    }
}

class Player : GameEntity
{
    public TArray<Collectible> ItemInventory;
    public TArray<Collectible> WeaponInventory;
    public TArray<Collectible> Abilities;

    public int CollectItem(Collectible collectible)
    {
        int item_already_exists = -1;
        int item_max_limit_exceeded = 0;
        int item_added_successfully = 1;

        for (int32 i = 0; i < ItemInventory.Num(); i++)
        {
            if (ItemInventory[i].collecitble_id === collectible.collecitble_id)
            {
                hasItem = true;
                break;
            }
            else
            {
                ItemInventory.Add(collectible);
            }
        }
    }
    public int CollectWeapon(Collectible collectible)
    {
        bool hasItem;
        for (int32 i = 0; i < ItemInventory.Num(); i++)
        {
            if (ItemInventory[i].collecitble_id === collectible.collecitble_id)
            {
                hasItem = true;
                break;
            }
            else
            {
                ItemInventory.Add(collectible);
            }
        }
    }
}

/*
    --------------------
    LEVEL START
    --------------------
    GameSession.players.ForEach((Player player, int index) => GameSession.SetPlayerSpawnPosition(player, spawnPositionForPlayer[index])
    GameSession.SetQuestArea(mapName);
    GameSession.Set


    --------------------
    COLLISION
    --------------------
    Hitbox !* Hurtbox           = Hitbox.GetOwner().TakeDamage()
    Collectible !* Player       = Player.CollectItem(Collectible.collecitble_id)
    Weapon !* Player            = Player.CollectWeapon(Weapon.weapon_id)
    Hazard !* Player            = Player.ContactWithHazard(Hazard)
    Interactible !* Player      = Player.InteractWith(Interactible.)
    DeadZone !* Player          = Player.Die(DeadZone.cause_of_death)
    QuestZone !* Player         = Player.ChangeQuestState(QuestZone.quest_id, quest_state)
    EventZone !* Player         = EventZone.TriggerEvent(StoryEventZone)
*/


