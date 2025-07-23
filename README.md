# OOP_Final_Ass (Semester 2)

This project simulates the chemical evolution of a planet's atmosphere in a controlled environment using object-oriented design. It was developed as part of the *Object-Oriented Programming* course assignment during the second semester of the Computer Science program at Eötvös Loránd University.

---

## Project Idea

Imagine layers of gases like **ozone (Z)**, **oxygen (X)**, and **carbon dioxide (C)** floating in the atmosphere. As time passes and different conditions apply, these layers interact, split, shrink, or combine to form others — all based on scientific rules encoded into object behavior.

This simulation models that idea. Each type of gas reacts differently when hit by environmental variables (`O`, `S`, `T`), and these interactions determine whether the gas layers grow, shrink, transform, or disappear altogether.

---

## Simulation Flow

1. **Input** is read from a `.txt` file:
   - First line: Number of initial gas layers
   - Next N lines: Each gas layer with its type (`Z`, `X`, or `C`) and thickness
   - Last line: A string of transformation characters representing environmental changes

2. The simulation continues in **rounds**:
   - Each round prints the state of the atmosphere (gas types and their thicknesses).
   - Layers with thickness `< 0.5` are removed.
   - Each layer attempts to **transform** based on the input string (e.g., `OOOOSSTSSOO`).
   - If **any gas type goes extinct**, the simulation ends.

---

## Core Components

| Component        | Responsibility                                                                 |
|------------------|--------------------------------------------------------------------------------|
| `GasLayer`       | Abstract class defining basic gas properties and transformation behavior       |
| `Ozone` (`Z`)    | Transforms into `Oxygen` (`X`) when hit by `O`                                 |
| `Oxygen` (`X`)   | Can turn into `Ozone` or `Carbon Dioxide` depending on the variable            |
| `CarbonDioxide` (`C`) | Converts into `Oxygen` under the right conditions                          |
| `Atmosphere`     | Manages the list of gas layers, simulates interactions, prints results         |
| `Program.cs`     | Entry point: Reads input file and launches the simulation                      |

---

## Gas Transformation Rules

| Gas Layer | Variable | Transformation                    |
|-----------|----------|-----------------------------------|
| Ozone (Z) | `O`      | Turns 5% of itself into Oxygen    |
| Oxygen (X) | `T`     | Converts 50% into Ozone           |
| Oxygen (X) | `S`     | Converts 5% into Ozone            |
| Oxygen (X) | `O`     | Converts 10% into Carbon Dioxide  |
| Carbon Dioxide (C) | `S` | Converts 5% into Oxygen       |

> Layers under 0.5 thickness are removed.

---

## Sample Input File

```txt
4
Z 5
X 0.8
C 3
X 4
OOOOSSTSSOO
