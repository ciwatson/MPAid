using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPAid.Models
{
    public enum VoiceType
    {
        MASCULINE_HERITAGE, MASCULINE_MODERN, FEMININE_HERITAGE, FEMININE_MODERN
    }

    public static class VoiceTypeConverter
    {
        private static Dictionary<string, VoiceType> voiceTypeDictionary;
        //todo: add strings/voicetypes to dictionary

        public static VoiceType? getVoiceTypeFromString(string voiceString)
        {
            if(voiceTypeDictionary.ContainsKey(voiceString))
            {
                return voiceTypeDictionary[voiceString];
            } else
            {
                return null;
            }
        }
    }
}
