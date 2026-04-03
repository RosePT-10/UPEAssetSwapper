using MelonLoader;

[assembly: MelonInfo(typeof(UPEAssetSwapper.Core), "UPEAssetSwapper", "1.0.0", "RosePT-10", null)]
[assembly: MelonGame("Videocult", "Airframe")]

namespace UPEAssetSwapper
{
    public class Core : MelonMod
    {
        public override void OnInitializeMelon()
        {
            LoggerInstance.Msg("Initialized.");
        }

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            base.OnSceneWasLoaded(buildIndex, sceneName);
            LoggerInstance.Msg($"the scene {sceneName} with the... uh... build index? of {buildIndex} was loaded");
        }
    }
}