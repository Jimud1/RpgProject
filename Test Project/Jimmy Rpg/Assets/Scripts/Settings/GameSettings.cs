using System;
using UnityEngine.UI;
using UnityEditor;
using System.IO;
using System.Reflection;

namespace Assets.Scripts.Settings
{
    public static class GameSettings 
    {
        /// <summary>
        /// This will come from a json file in the future
        /// </summary>
        public static string StoryJsonFilePath
        {
            get
            {
                return @"E:\Development\RpgProject\RpgProject\Test Project\Jimmy Rpg\Assets\Json\Story.json";
            }
        }

        public static string QuestsJsonPath
        {
            get
            {
                return @"E:\Development\RpgProject\RpgProject\Test Project\Jimmy Rpg\Assets\Json\Quests.json";
            }
        }

        public static string TestGetFullPath
        {
            get
            {
                return Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            }
        }

        public static string WeaponsJsonPath
        {
            get
            {
                return @"E:\Development\RpgProject\RpgProject\Test Project\Jimmy Rpg\Assets\Json\Weapons.json";
            }
        } 

        public static string GameBtnPath
        {
            get
            {
                return "Assets/Resources/Button.prefab";
            }
        }

        public static Button GameButton
        {
            get
            {
                try
                {
                    var btn = AssetDatabase.LoadAssetAtPath<Button>(GameBtnPath);
                    return btn;
                }
                catch(Exception ex)
                {
                    throw new Exception("Error loading resource", ex);
                }
            }
        }
    }
}
