using System;
using System.Linq;

namespace CyberBotGUI
{
    public class ResponseGenerator
    {
        private readonly CyberSecurityKnowledgeBase _kb;
        private readonly UserProfile _profile;

        public ResponseGenerator(CyberSecurityKnowledgeBase kb, UserProfile profile)
        {
            _kb = kb;
            _profile = profile;
        }

        public string GenerateResponse(string input)
        {
            if (_kb.PositiveFeelings.Any(f => input.Contains(f)))
                return "I'm glad you're feeling good! Let's explore cybersecurity together.";

            if (_kb.WorriedFeelings.Any(f => input.Contains(f)))
                return "No worries! I'm here to help you stay safe online.";

            if (input.Contains("your name"))
            {
                VoicePlayer.PlayNameClip();
                return "Cyber Bot!";
            }

            if (input.Contains("my name"))
                return $"Your name is {_profile.Name}, right?";

            if (input.Contains("interested in"))
            {
                _profile.Interest = input.Substring(input.IndexOf("interested in") + 13).Trim();
                _profile.MemoryLog.Add($"User interested in: {_profile.Interest}");
                return $"Great! I'll remember you're interested in {_profile.Interest}.";
            }

            foreach (var pair in _kb.KeywordResponses)
            {
                if (input.Contains(pair.Key))
                {
                    var responses = pair.Value;
                    var random = new Random();
                    return responses[random.Next(responses.Count)];
                }
            }

            foreach (var term in _kb.CyberSecurityInfo.Keys)
            {
                if (input.Split(' ').Contains(term.ToLower()))
                    return _kb.CyberSecurityInfo[term];
            }

            return "I'm not sure how to respond yet, but I'm learning more every day!";
        }
    }
}
