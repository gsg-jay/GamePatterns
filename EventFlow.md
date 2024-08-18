```mermaid
flowchart LR;
lc("Level Clear Action")
lc-->e["LevelClearEvent"]
e-->sm("Sound Manager")-->smeh("Play victory BGM")
e-->p("Player")-->peh("Suspend Controls")
e-->gd("GameData")-->gdeh("Save Game Data")
```
