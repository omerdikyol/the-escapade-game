# The Escapade

A 3D puzzle adventure built for a game-design course. Explore low-poly scenes, collect and use inventory items, and solve environmental puzzles and minigames to progress.

[Download the playable release](https://github.com/omerdikyol/the-escapade-game/releases)

## Open in Unity

Open the repository root in **Unity 2021.3.20f1**, the version recorded in [ProjectVersion.txt](ProjectSettings/ProjectVersion.txt). Use the scenes and configured build settings in the project; opening the scripts alone will not recreate the scene references.

## Code map

- [GameController](Assets/Scripts/GameController.cs): scene/game coordination.
- [Inventory UI](Assets/Scripts/Inventory/InventoryUI.cs): item presentation and interaction.
- [PipePuzzle](Assets/Scripts/ForScenes/Level3/PipePuzzle.cs): a scene-specific rotation puzzle.
- [SaveGame](Assets/Scripts/SaveGame.cs): scene-name save behavior.

Saving currently records the scene name rather than the complete inventory/world state. It writes under `Application.dataPath`; packaged-build persistence needs a writable save location. The repository also includes imported art and plugins alongside the gameplay scripts, whose existing attribution should be retained.


## Screenshots

![image](https://github.com/user-attachments/assets/198ffff3-7b18-4414-91ae-a636d2879429)

![image](https://github.com/user-attachments/assets/2f2be4e0-5125-43a4-8524-d2d66d4a5c61)

![image](https://github.com/user-attachments/assets/73b172f3-18a2-4128-bb40-ecb4a2a9dd9f)
