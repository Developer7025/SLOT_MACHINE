# SLOT_MACHINE
🔹 Game Overview

This is a simple Slot Machine simulation built using Unity and C#.
Players can place bets, pull the handle to spin the reels, and win based on symbol matches. The game features animated reels, dynamic payouts, and a smooth user interface.

🎮 Features

Interactive Slot Mechanism: Pull the handle to spin reels with smooth animation.

Randomized Rotation: Each reel spins a random number of times for unpredictability.

Symbol Matching & Payouts:

3 matching symbols → Big win

2 matching symbols → Small win

Dynamic Betting System: Players can place bets, see their balance, and earn rewards.

UI & Feedback: Real-time balance updates and win notifications.

Scalable Design: Easy to add or modify symbols and multipliers.

Optimized Performance: Uses coroutines for smooth reel rotation.

🛠 Instructions to Run WebGL Build

Open the project in Unity Editor (version used: 2025.x recommended).

Navigate to the WebGL build folder: /Build/WebGL/.

Open the index.html file in a web browser to run the game.

Place a bet, pull the handle, and try to match the symbols for winnings.

⚡ Bonus Features

Smooth reel slowing effect near the end of spin.

Staggered reel start for more realistic slot machine feel.

Easy-to-edit symbol multipliers and rotation range through the Unity Inspector.

🧠 Thought Process / Approach

Implemented reel rotations using coroutines for frame-independent movement.

Created a flexible payout system using serialized symbol objects with 2x and 3x multipliers.

Managed balance, bets, and winnings to ensure realistic gameplay.

Focused on project structure and readability to make the project easy to maintain and expand