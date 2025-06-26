using System;
using System.Speech.Synthesis;

namespace CyberBotGUI
{
    public class ChatBot
    {
        private readonly UserProfile _userProfile;
        private readonly ResponseGenerator _responseGenerator;
        private readonly SpeechSynthesizer _synthesizer;

        public ChatBot(UserProfile userProfile, ResponseGenerator responseGenerator)
        {
            _userProfile = userProfile;
            _responseGenerator = responseGenerator;
            _synthesizer = new SpeechSynthesizer();
        }

        public string GetResponse(string input)
        {
            string response = _responseGenerator.GenerateResponse(input);
            Speak(response);
            return response;
        }

        private void Speak(string message)
        {
            try
            {
                _synthesizer.SpeakAsync(message);
            }
            catch (Exception ex)
            {
                // Log or ignore speech error
                Console.WriteLine("Speech error: " + ex.Message);
            }
        }
    }
}
