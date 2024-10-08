### Game Boot Enter
```mermaid
flowchart TD;
gm["GameManager"]
gm-->gs["Action_GameBootEnter()"]
gs-->e["GameBootEnterEvent"]
e-->mvm("MovieManager")-->|EventHandler_OnGameBootEnterEvent|mvmeh("PlayMovie('boot_intro')")
e-->p("Player")-->|EventHandler_OnGameBootEnterEvent|peh("EnterControlMode('movie')")
peh-->act(Action_XYZ)
```

---

### Game Boot End
```mermaid
flowchart TD;
gm["GameManager"]
gm-->gs["Action_GameBootEnd()"]
gs-->e["GameBootEndEvent"]
e-->mvm("MovieManager")-->|EventHandler_OnGameBootEndEvent|mvmeh("PlayMovie('game_opening')")
e-->p("Player")-->|EventHandler_OnGameBootEndEvent|peh("EnterControlMode('movie')")
peh-->act(Action_XYZ)
```

---

### Title Menu Enter
```mermaid
flowchart TD;
gm["GameManager"]
gm-->gs["Action_TitleMenuEnter()"]
gs-->e["TitleMenuEnterEvent"]
e-->p("Player")-->|EventHandler_OnTitleMenuEnterEvent|peh("EnterControlMode('main_menu')")
```

---

### Game Start
```mermaid
flowchart TD;
gm["GameManager"]
gm-->gs["Action_GameStart()"]
gc-->e["GameStartEvent"]
e-->gm("GameManager")-->|EventHandler_OnGameStartEvent|gmeh("LoadLevel('hub', '')");
e-->p("Player")-->|EventHandler_OnGameStartEvent|peh("EnterControlMode('gameplay')")
```

---

### Level Complete
```mermaid
flowchart TD;
lm["LevelManager"]
lm-->lc["Action_LevelClear()"]
lc-->e["LevelClearEvent"]
e-->sm("SoundManager")-->|EventHandler_OnLevelClearEvent|smeh("PlayBGM('Victory')")
e-->p("Player")-->|EventHandler_OnLevelClearEvent|peh("SuspendControl()")
e-->ch("Character")-->|EventHandler_OnLevelClearEvent|cheh("Action_VictoryDance()")
e-->gd("GameData")-->|EventHandler_OnLevelClearEvent|gdeh("SaveGameData()")
e-->gm("GameManager")-->|EventHandler_OnLevelClearEvent|gmeh("LoadLevel('hub', '')");
```

---

### Game Complete 
```mermaid
flowchart TD;
gm["GameManager"]
gm-->gc["Action_GameClear()"]
gc-->e["GameClearEvent"]
e-->mvm("MovieManager")-->|EventHandler_OnGameClearEvent|mvmeh("PlayMovie('game_ending')")
e-->p("Player")-->|EventHandler_OnGameClearEvent|peh("EnterControlMode('movie')")
```
