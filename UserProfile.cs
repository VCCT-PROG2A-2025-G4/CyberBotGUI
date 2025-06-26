using System.Collections.Generic;

namespace CyberBotGUI
{
    public class UserProfile
    {
        public string Name { get; set; } = string.Empty;
        public string Interest { get; set; } = string.Empty;
        public List<string> MemoryLog { get; } = new();
    }
}
