using ColossalFramework.Globalization;
using HarmonyLib;
using static ColossalFramework.Globalization.Locale;

namespace BoardingTranslationFix.Patches
{
    [HarmonyPatch]
    public static class KeyLocalePatch
    {
        [HarmonyPatch(typeof(Locale), nameof(Locale.Get), new[] { typeof(Key) })]
        public static bool Prefix(ref string __result, Key id)
        {
            if (id.m_Key == "LeftBracket")
            {
                __result = "[键";
                return false;
            }
            if (id.m_Key == "RightBracket")
            {
                __result = "]键";
                return false;
            }
            if (id.m_Key == "Equals")
            {
                __result = "=键";
                return false;
            }

            return true;
        }
    }
}


