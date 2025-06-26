using System;
using System.IO;
using System.Media;

namespace CyberBotGUI
{
    public static class VoicePlayer
    {
        public static void PlayIntro()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Prog Intro.wav");
            if (File.Exists(path))
                new SoundPlayer(path).PlaySync();
        }

        public static void PlayNameClip()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "My_Name_Is.wav");
            if (File.Exists(path))
                new SoundPlayer(path).PlaySync();
        }
    }
}