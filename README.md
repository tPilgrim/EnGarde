# ⚔️ En Garde! - 2D Fighting Game

## 📖 Overview
**En Garde!** is a fast-paced 2D fighting game set in a medieval world, where two swordsmen engage in intense fencing duels.

Each match lasts **60 seconds**, and every successful hit scores a point. There are no health bars, only precision, timing, and skill determine the winner.

<p float="left">
<img src="Screenshots/En Garde! 1.png" width="350"/>
  <img src="Screenshots/En Garde! 2.png" width="350"/>
  <img src="Screenshots/En Garde! 3.png" width="350"/>
</p>

## 🎯 Features
- ⚔️ Fast-paced 1v1 sword combat
- 🤖 Play against AI or another player
- ⏱️ 60-second match system
- 🎯 Hit-based scoring (no health bars)
- 🎮 Smooth movement, dash, and attack mechanics
- 🎨 Pixel-art medieval arena

## 🕹️ Controls

### Player 1
- **A / D** → Move left / right  
- **W** → Jump  
- **S** → Dash  
- **Space** → Attack  

### Player 2
- **Left Arrow / Right Arrow** → Move left / right  
- **Up Arrow** → Jump  
- **Down Arrow** → Dash  
- **Enter** → Attack  

## 🧠 Game Mechanics

### ⚔️ Combat System
- Each attack is a **thrust-based strike**
- Successful hits increment score
- Attack includes:
  - Wind-up
  - Active hitbox
  - Recovery phase

### 💨 Movement System
- Smooth horizontal movement
- Jumping with grounded check

### ⚡ Dash Mechanic
- Fast burst movement
- Has cooldown and duration
- Temporarily disables collisions

### 🤖 AI Behavior
- Follows player position dynamically
- Adjusts direction automatically
- Attacks when in range
- Uses same movement system as player

### 🏁 Game Flow
- Match duration: **60 seconds**
- Score is tracked in real-time
- At the end:
  - Higher score wins
  - Draw is possible
- UI buttons:
  - Resume
  - Restart
  - Menu
 
### 🤖 AI Controller

- Player tracking
- Automatic movement
- Conditional attacking
- Same animation & physics system as player

### 🧮 Score System

- Timer countdown
- Score tracking
- Win condition logic
- UI updates
