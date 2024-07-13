using BoardingTranslationFix.Utils.Log;
using ColossalFramework.Globalization;
using ICities;
using Snooper.Utils;
using System.Reflection;

namespace BoardingTranslationFix
{
    public class Mod : IUserMod, ILoadingExtension
    {
        public string Name => "Boarding Translation Fix v" + ModVersion;
        public string Description => "修正 “Boarding” 的中文翻译";
        private const string HarmonyId = "Will258012.BoardingTranslationFix";

        private string ModVersion
        {
            get
            {
                var assemblyVersion = ModAssembly.GetName().Version;
                return $"{assemblyVersion.Major}.{assemblyVersion.Minor}.{assemblyVersion.Build}";
            }
        }
        public void OnEnabled() => HarmonyPatcher.PatchOnReady(ModAssembly, HarmonyId);

        public void OnCreated(ILoading loading)
        {

        }
        public void OnLevelLoaded(LoadMode mode)
        {
            if (LocaleManager.exists && LocaleManager.instance.language != "zh")
            {
                Log.Err("Game language is not supported!");
            }
        }

        public void OnLevelUnloading()
        {

        }
        public void OnReleased()
        {
        }

        public void OnDisabled() => HarmonyPatcher.TryUnpatch(HarmonyId);
        private Assembly ModAssembly => Assembly.GetExecutingAssembly();
        
    }
}
