using System.Collections.Generic;

namespace CyberBotGUI
{
    public class CyberSecurityKnowledgeBase
    {
        public Dictionary<string, string> CyberSecurityInfo { get; } = new(StringComparer.OrdinalIgnoreCase)
        {
            {"phishing", "Phishing is a type of attack using fake emails to steal info."},
            {"malware", "Malware is software intended to damage or disable systems."},
            {"2fa", "Two-Factor Authentication adds an extra step to login for security."},
            {"firewall", "A firewall monitors and controls incoming/outgoing traffic."},
        };

        public Dictionary<string, List<string>> KeywordResponses { get; } = new()
        {
            ["password"] = new() {
                "Use strong, unique passwords.",
                "Never reuse old passwords.",
                "Use a password manager."
            },
            ["privacy"] = new() {
                "Adjust your social media privacy settings.",
                "Avoid oversharing personal info online."
            },
            ["phishing"] = new() {
                "Phishing emails often create urgency to trick you.",
                "Don't click links from unknown senders."
            }
        };

        public List<string> PositiveFeelings { get; } = new() { "curious", "interested", "learning" };
        public List<string> WorriedFeelings { get; } = new() { "worried", "anxious", "scared" };
    }
}
