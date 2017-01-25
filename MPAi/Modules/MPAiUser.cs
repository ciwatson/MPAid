﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using MPAi.Models;
using MPAi.Cores.Scoreboard;
using System.Windows.Forms;
using MPAi.Cores;
using NAudio.CoreAudioApi;
using NAudio.Wave;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Vlc.DotNet.Forms;
using System.Threading;

namespace MPAi
{
    /// <summary>
    /// Class representing a user in the MPAi system.
    /// </summary>
    public class MPAiUser
    {
        private string userName;
        private string passWord;
        private VoiceType? voiceType;
        private MPAiSpeakScoreBoard speakScoreboard;
        private MPAiSoundScoreBoard soundScoreboard;
        private Speaker speaker;
        private Category category;
        private readonly string adminStr = "admin";

        /// <summary>
        /// Wrapper property for the user's username, allowing access from outside the class.
        /// </summary>

        [DisplayName("UserName")]
        public string UserID
        {
            get { return userName; }
            set
            {
                // prevent the user from changing the name of the admin
                if (userName != adminStr)
                {
                    userName = value;
                }
            }
        }
        /// <summary>
        /// Wrapper property for the user's password, allowing access outside of the class.
        /// </summary>
        [DisplayName("Password")]
        public string UserPswd
        {
            get { return passWord; }
            set
            {
                passWord = value;
            }
        }

        /// <summary>
        /// Wrapper property for the user's voice type, allowing access outside of the class.
        /// </summary>
        [DisplayName("VoiceType")]
        public VoiceType? Voice
        {
            get { return voiceType; }
            set {
                voiceType = value;
                setSpeakerFromVoiceType();
            }
        }
        
        /// <summary>
        /// Wrapper property for the administrator status of the user, allowing ti to be checked from outside the class.
        /// </summary>
        [DisplayName("IsAdministrator")]
        public bool IsAdmin
        {
            get { return isAdmin(); }
        }

        public Speaker Speaker
        {
            get
            {
                return speaker;
            }

            set
            {
                speaker = value;
            }
        }
        /// <summary>
        /// Wrapper property for the user's username, allowing access from outside the class.
        /// </summary>
        [DisplayName("SpeakScoreBoard")]
        public MPAiSpeakScoreBoard SpeakScoreboard
        {
            get
            {
                loadScoreBoards();
                return speakScoreboard;
            }
        }

        /// <summary>
        /// Wrapper property for the user's username, allowing access from outside the class.
        /// </summary>
        [DisplayName("SoundScoreBoard")]
        public MPAiSoundScoreBoard SoundScoreboard
        {
            get
            {
                loadScoreBoards();
                return soundScoreboard;
            }
        }
        private MPAiModel InitializeDBModel(MPAiModel DBModel)
        {
            DBModel.Database.Initialize(false);
            DBModel.Recording.Load();
            DBModel.Speaker.Load();
            DBModel.Category.Load();
            DBModel.Word.Load();
            DBModel.SingleFile.Load();
            return DBModel;
        }

        /// <summary>
        /// Constructor for the MPAiUser class, with a default value for voice type.
        /// </summary>
        /// <param name="name">The new user's username</param>
        /// <param name="code">The new user's password</param>
        public MPAiUser(string name, string code) :
            this(name, code, VoiceType.MASCULINE_HERITAGE)
        {
            // As Peter Keegan's recordings are the only one we have for testing, users default to MASCULINE_HERITAGE.
        }


        /// <summary>
        /// Constructor for the MPAiUser class.
        /// </summary>
        /// <param name="name">The new user's username</param>
        /// <param name="code">The new user's password</param>
        public MPAiUser(string name, string code, VoiceType? voiceType)
        {
            userName = name;
            passWord = code;
            Voice = voiceType;
        }

        public void setSpeakerFromVoiceType()
        {
            using (MPAiModel DBModel = new MPAiModel())
            {
                InitializeDBModel(DBModel);
                switch (voiceType)
                {
                    case VoiceType.MASCULINE_HERITAGE:
                        speaker = DBModel.Speaker.Local.Where(x => x.SpeakerId == 2).SingleOrDefault();
                        break;

                    case VoiceType.FEMININE_HERITAGE:
                        speaker = DBModel.Speaker.Local.Where(x => x.SpeakerId == 1).SingleOrDefault();
                        break;

                    case VoiceType.MASCULINE_MODERN:
                        speaker = DBModel.Speaker.Local.Where(x => x.SpeakerId == 4).SingleOrDefault();
                        break;

                    case VoiceType.FEMININE_MODERN:
                        speaker = DBModel.Speaker.Local.Where(x => x.SpeakerId == 3).SingleOrDefault();
                        break;
                }
            }
        }

        private void loadScoreBoards()
        {
            if (speakScoreboard == null)
            {
                if (File.Exists(MPAiSpeakScoreboardLoader.SpeakScoreboardFileAddress(this)))
                {
                    speakScoreboard = MPAiSpeakScoreboardLoader.LoadScoreboard(this);
                }
                else
                {
                    speakScoreboard = new MPAiSpeakScoreBoard(this);
                }
            }
            
            if(soundScoreboard == null)
            {
                if (File.Exists(MPAiSoundScoreboardLoader.SpeakScoreboardFileAddress(this)))
                {
                    soundScoreboard = MPAiSoundScoreboardLoader.LoadScoreboard(this);
                }
                else
                {
                    soundScoreboard = new MPAiSoundScoreBoard(this);
                }
            }
        }

        /// <summary>
        /// Changes the voice type to feminine.
        /// </summary>
        public void changeVoiceToFeminine()
        {
            switch(voiceType)
            {
                case VoiceType.MASCULINE_HERITAGE:
                    Voice = VoiceType.FEMININE_HERITAGE;
                    break;
                case VoiceType.MASCULINE_MODERN:
                    Voice = VoiceType.FEMININE_MODERN;
                    break;
            }
        }

        /// <summary>
        /// Changes the voice type to Masculine.
        /// </summary>
        public void changeVoiceToMasculine()
        {
            switch (voiceType)
            {
                case VoiceType.FEMININE_HERITAGE:
                    Voice = VoiceType.MASCULINE_HERITAGE;
                    break;
                case VoiceType.FEMININE_MODERN:
                    Voice = VoiceType.MASCULINE_MODERN;
                    break;
            }
        }

        /// <summary>
        /// Changes the voice type to Heritage.
        /// </summary>
        public void changeVoiceToHeritage()
        {
            switch (voiceType)
            {
                case VoiceType.FEMININE_MODERN:
                    Voice = VoiceType.FEMININE_HERITAGE;
                    break;
                case VoiceType.MASCULINE_MODERN:
                    Voice = VoiceType.MASCULINE_HERITAGE;
                    break;
            }
        }
        /// <summary>
        /// Changes the voice type to Modern.
        /// </summary>
        public void changeVoiceToModern()
        {
            switch (voiceType)
            {
                case VoiceType.FEMININE_HERITAGE:
                    Voice = VoiceType.FEMININE_MODERN;
                    break;
                case VoiceType.MASCULINE_HERITAGE:
                    Voice = VoiceType.MASCULINE_MODERN;
                    break;
            }
        }
        /// <summary>
        /// Checks if the input string matches this user's password. Case sensitive.
        /// </summary>
        /// <param name="code">The string to check against the password.</param>
        /// <returns>True if the password is correct, false otherwise.</returns>
        public bool codeCorrect(string code)
        {
            return (code.Equals(passWord));
        }
        /// <summary>
        /// Checks if the username of the user matches that of the admin, returning whether or not they are the same person.
        /// </summary>
        /// <returns>True if the user is the administrator, false otherwise.</returns>
        public bool isAdmin()
        {
            return (getName() == adminStr);
        }
        /// <summary>
        /// Getter for username, Not case senstive.
        /// </summary>
        /// <returns>The lower-case username, as a string.</returns>
        public string getName()
        {
            return userName.ToLower();
        }

        /// <summary>
        /// Getter for the Users inputed username. Case sensitive.
        /// </summary>
        /// <returns>The case sensitive username, as a string</returns>
        public string getRawName() {
            return userName;
        }
        /// <summary>
        /// Getter for password. Case Senstive.
        /// </summary>
        /// <returns>The password, as a string.</returns>
        public string getCode()
        {
            return passWord;
        }
        /// <summary>
        /// Override for equals().
        /// Two users with the same username are considered the same user.
        /// </summary>
        /// <param name="obj">The object to be compared to the current user.</param>
        /// <returns>True if the user and the object are the same thing, false otherwise.</returns>
        public override bool Equals(System.Object obj)
        {
            if (obj is MPAiUser)
            {
                MPAiUser otherUser = (MPAiUser)obj;
                if (userName == null || passWord == null)
                {
                    return false;
                }
                return (getName() == otherUser.getName());
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Override for GetHashCode(). Functions the same.
        /// </summary>
        /// <returns>The hashcode for this object, as an int.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        /// <summary>
        /// Override for ToString(), returning the username - this should be unique for each user.
        /// </summary>
        /// <returns>The username, as a string.</returns>
        public override string ToString()
        {
            return userName;
        }
    }
}
