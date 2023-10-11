# MultiplayerCoinToss
This game was commissioned to me in 2021 on Fiverr by a person who wanted a coin thrower created in Unity, in multiplayer and available online on a website.

This repository hosts a Unity-based game that provides an engaging coin-tossing experience. This technical description will delve into the key components and functionalities of the project, including the integration of PUN2 for multiplayer capabilities.

# Technical Overview:

## 1. Unity Engine:

The game is built on the Unity game engine, which offers a versatile platform for creating interactive 3D experiences.
The latest tested version for which the game works totally is: Unity 2021-3-4f1


## 2. Coin Toss Mechanism:
The core gameplay involves six 3D coins that rotate with animation. Each toss of a coin produces a random result, with each coin sporting a unique face. The user can relaunch the coins while other connected users see the scene synchronized.
![gameplay 1](https://github.com/iFralex/MultiplayerCoinToss/assets/61825057/5fae3a0f-8a34-4a14-aaad-15ce9bb7054f)
<img width="960" alt="gameplay 2" src="https://github.com/iFralex/MultiplayerCoinToss/assets/61825057/efb98136-9acc-44be-bef8-fca8d0922da8">
<img width="960" alt="gameplay 3" src="https://github.com/iFralex/MultiplayerCoinToss/assets/61825057/5abe4495-1ad8-487a-88d5-84f45fc130a0">

## 3. Multiplayer Integration with PUN2:
The project leverages the Photon Unity Networking 2 (PUN2) plugin to implement seamless real-time multiplayer functionality.
PUN2 facilitates the connection of multiple players to the same game session, enabling them to interact and experience the coin-tossing together.

Because of the low price of the work and the customer's haste, I used the PUN2 tutorial project called PunBasics as the basic structure of networking. The scripts were adapted to the game, but still many methods remained unchanged.

## 4. Networking Features:
PUN2 manages network synchronization, ensuring that players see the same results when coins are tossed.
Real-time updates are provided to all connected players, enabling them to enjoy the experience simultaneously.

Via the memù screen, players can enter the game right away. They are connected to the MasterServer, are joined to the main room and are transferred to the scene where the coins are. All coins are synced via Photon Translate View. Thanks to this component, players who are not the room managers, that is, the first player to enter, can see the location and rotation of the coins in real time as on the room manager's screen.

# C# Scripts
A Unity project has many files in addition to scripts that are usually not managed by the developer. If **you are only interested in seeing my work**, namely the C# scripts I wrote, go directly to the [assets folder](https://github.com/iFralex/Rompecabezas/tree/main/Assets) and open the C# files.

Unfortunately, the project was not developed with the intention of publication, so the file names, variables, and functions are in Italian, and no scripts are commented or written to facilitate reading by others.

Keep in mind that I programmed this video game when I was 15 years old, so you can imagine that the code is not perfect or optimized to the best, but it still works perfectly, and you can study it to understand how Unity and PUN 2 work.
