using ColossalFramework.Globalization;
using HarmonyLib;

namespace BoardingTranslationFix.Patches
{
    [HarmonyPatch]
    public static class StatusLocalePatch
    {
        private static readonly string[] TargetIds =
        {
            "VEHICLE_STATUS_TRAM_STOPPED",
            "VEHICLE_STATUS_BUS_STOPPED",
            "VEHICLE_STATUS_METRO_STOPPED",
            "VEHICLE_STATUS_PASSENGERTRAIN_STOPPED",
            "VEHICLE_STATUS_PASSENGERSHIP_STOPPED",
            "VEHICLE_STATUS_FERRY_STOPPED",
        };

        [HarmonyPatch(typeof(Locale), nameof(Locale.Get), new[] { typeof(string) })]
        [HarmonyPrefix]
        public static bool GetPatch(ref string __result, string id)
        {
            if (System.Array.Exists(TargetIds, element => element == id))
            {
                __result = "上客";
                return false;
            }
            return true;
        }
    }
}


