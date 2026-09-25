# Surface Based AR

A plane detection AR project built with Unity AR Foundation. Users can detect a horizontal surface, place a potted plant, and control the model with touch gestures.

## Features

- Detects horizontal surfaces and displays plane visualization
- Places one Monstera plant on a detected plane
- Hides detected planes and stops plane detection after placement
- Rotates the selected model with a one finger drag
- Scales the model with a two finger pinch
- Supports Android with ARCore and iOS with ARKit

## Requirements

- Unity `6000.3.24f1`
- AR Foundation `6.3.5`
- ARCore XR Plugin `6.3.5`
- ARKit XR Plugin `6.3.5`
- Input System `1.20.0`

## Run the Project

1. Open the project in Unity Hub.
2. Open `Assets/MainScene.unity`.
3. Build and run on an ARCore or ARKit compatible device.
4. Move the device slowly to detect a floor or table.
5. Tap a detected plane to place the plant.
6. Tap the plant, drag with one finger to rotate it, or pinch with two fingers to scale it.

## Main Files

- `Assets/MainScene.unity`: Main AR scene
- `Assets/Prefabs/Monstera.prefab`: Plant prefab
- `Assets/Prefabs/AR Default Plane.prefab`: Plane visualization prefab
- `Assets/Scripts/TapToPlace.cs`: Raycasting, object placement, and plane hiding
- `Assets/Scripts/PlantInteraction.cs`: Object selection, rotation, and scaling

