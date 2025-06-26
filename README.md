# Cybersecurity Awareness Chatbot (PROG6221 Part 3)

## Student Info

- Student Number: ST10440720
- Module: PROG6221 Programming 2A
- Part 3 POE Submission

---

## Description

This is a WPF-based chatbot designed to promote cybersecurity awareness. It simulates conversation, teaches cybersecurity concepts, and includes interactive features such as a quiz and task assistant. Voice playback and speech synthesis are integrated to enhance user engagement.

---

## Features

- Keyword-based cybersecurity education
- Voice introduction using a WAV file
- Speech synthesis using System.Speech.Synthesis
- Task Assistant: add and view task reminders
- Quiz Game: 10-question multiple choice quiz
- Activity Log: tracks chatbot interactions
- WPF GUI built using XAML

---

## Technologies Used

- C# (.NET)
- WPF with XAML
- System.Speech
- System.Media
- Visual Studio 2022

---

## How to Run

1. Clone or download the repository.
2. Open the solution in Visual Studio.
3. Ensure the following files exist in the `/Resources` folder:
   - Prog Intro.wav
   - My_Name_Is.wav
   - Set both files to: `Copy to Output Directory → Copy if newer`
4. Build and run the project.
5. Use the chatbot by typing:
   - `what is phishing`
   - `start quiz`
   - `add task`
   - `show log`
   - `what is your name`

---

## Video Demonstration
https://youtu.be/0M6FcG_n26s
---
## GitHub Commit Log

- Commit 1: Initial WPF layout
- Commit 2: Added chatbot core and response generator
- Commit 3: Integrated quiz and task assistant
- Commit 4: Final integration and README

---

## Final Notes

This project improved my understanding of:
- GUI application design in WPF
- Event-driven programming
- Basic natural language processing techniques
- Cybersecurity content delivery through interactivity
