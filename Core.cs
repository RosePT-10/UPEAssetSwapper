using Il2CppMenus;
using Il2CppQuantum;
using MelonLoader;
using UnityEngine;
using HarmonyLib;
using Il2CppQuantum.Migration;
using Il2Cpp;
using Unity.Baselib;
using JetBrains.Annotations;

[assembly: MelonInfo(typeof(UPEAssetSwapper.Core), "UPEAssetSwapper", "1.0.0", "RosePT-10", null)]
[assembly: MelonGame("Videocult", "Airframe")]


namespace UPEAssetSwapper
{
    public class Core : MelonMod
    {
        
        public static AssetBundle testbundle;
        public static UnityEngine.GameObject testobject;
        
        public override void OnInitializeMelon()
        {
            LoggerInstance.Msg("Initialized.");
            LoggerInstance.Msg("Subscribed AND hit the bell.");
        }

        [HarmonyPatch(typeof(Core), "DrawMenu")]
        private static class Patch
        {
            private static void Prefix()
            {
                //Melon<Core>.Logger.Msg("yay");
            }
        }

        private void DrawMenu()
        {
            GUI.Box(new Rect(0, 0, 300, 500), "");
        }


        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            // boilerplate?
            base.OnSceneWasLoaded(buildIndex, sceneName);
            // identify scene names
            LoggerInstance.Msg($"the scene {sceneName} with the... uh... build index? of {buildIndex} was loaded");

            // list loaded assets
            //MelonEvents.OnSceneWasLoaded.GetAllLoadedAssets();
            
            // messing with paths and accessing assets
            string path_stuff = Path.GetFullPath("Assets/Texture2D/AFULogo.png");
            LoggerInstance.Msg(path_stuff);
            NativeLibrary.Load("Assets/Texture2D/AFULogo.png");
            


            // testing for loading specific scenes
            if (sceneName == "MainMenu")
            {
                MelonEvents.OnGUI.Subscribe(DrawMenu, 0);
            }
            if (sceneName == "Warehouse")
            {
                MelonEvents.OnGUI.Dispose();
            }
        }
    }
}