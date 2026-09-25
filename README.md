# Surface Based AR

基于 Unity AR Foundation 的平面检测 AR 项目。检测水平平面后，可点击平面放置盆栽，并通过触控旋转和缩放模型。

## 功能

- 检测水平平面并显示平面可视化
- 点击已检测平面放置一个 Monstera 盆栽
- 放置后隐藏平面并停止继续检测
- 单指拖动旋转已选中的模型
- 双指捏合缩放模型
- 支持 Android ARCore 和 iOS ARKit

## 环境

- Unity `6000.3.24f1`
- AR Foundation `6.3.5`
- ARCore XR Plugin `6.3.5`
- ARKit XR Plugin `6.3.5`
- Input System `1.20.0`

## 运行

1. 使用 Unity Hub 打开项目。
2. 打开 `Assets/MainScene.unity`。
3. 在支持 ARCore 或 ARKit 的真机上构建并运行。
4. 缓慢移动设备以检测地面或桌面。
5. 点击检测到的平面放置盆栽。
6. 点击盆栽后，单指拖动旋转，双指捏合缩放。

## 主要文件

- `Assets/MainScene.unity`：AR 主场景
- `Assets/Prefabs/Monstera.prefab`：盆栽预制体
- `Assets/Prefabs/AR Default Plane.prefab`：平面可视化预制体
- `Assets/Scripts/TapToPlace.cs`：射线检测、模型放置和隐藏平面
- `Assets/Scripts/PlantInteraction.cs`：模型选择、旋转和缩放

