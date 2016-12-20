using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPAid.Models
{
    /// <summary>
    /// Enum representing the VoiceType setting for a user.
    /// </summary>
    public enum VoiceType
    {
        MASCULINE_HERITAGE, MASCULINE_MODERN, FEMININE_HERITAGE, FEMININE_MODERN
    }

    /// <summary>
    /// Class for retrieving the appropriate VoiceType enum value from the given string
    /// </summary>
    public static class VoiceTypeConverter
    {
        private static Dictionary<string, VoiceType> voiceTypeDictionary;
        //todo: add strings/voicetypes to dictionary

        /// <summary>
        /// Returns the appropriate enum for the inputted string; null if string is not in dictionary.
        /// </summary>
        /// <param name="voiceString">The string to convert into VoiceType</param>
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