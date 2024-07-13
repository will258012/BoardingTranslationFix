using ColossalFramework.Globalization;
using HarmonyLib;
using System.Collections.Generic;

namespace BoardingTranslationFix.Patches
{
    [HarmonyPatch]
    public static class StatusLocalePatch
    {
        private static readonly HashSet<string> TargetIds = new HashSet<string>
        {
            "VEHICLE_STATUS_TRAM_STOPPED",
            "VEHICLE_STATUS_BUS_STOPPED",
            "VEHICLE_STATUS_METRO_STOPPED",
            "VEHICLE_STATUS_PASSENGERTRAIN_STOPPED",
            "VEHICLE_STATUS_PASSENGERSHIP_STOPPED",
            "VEHICLE_STATUS_FERRY_STOPPED",
        };
            
        [HarmonyPatch(typeof(Locale), nameof(Locale.Get), new[] { typeof(string) })]
        public static bool Prefix(ref string __result, string id)
        {
            if (TargetIds.Contains(id))
            {
                __result = NewBoardingTranslate;
                return false;
            }
            return true;
        }
        private const string NewBoardingTranslate = "上客";
    }
}


