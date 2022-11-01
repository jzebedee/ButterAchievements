using HarmonyLib;
using System;

namespace ButterAchievements
{
    //StoryMode.GameComponents.CampaignBehaviors.AchievementsCampaignBehavior.CheckAchievementSystemActivity() : bool @060003DE
    //// Token: 0x060003DE RID: 990 RVA: 0x00017B98 File Offset: 0x00015D98
    [HarmonyPatch(typeof(StoryMode.GameComponents.CampaignBehaviors.AchievementsCampaignBehavior), CheckAchievementSystemActivity)]
    public class EnableAchievementsPatch
    {
        private const string CheckAchievementSystemActivity = nameof(CheckAchievementSystemActivity);

        public static bool Prefix(ref bool __result, ref bool ____deactivateAchievements)
        {
            HarmonyLib.FileLog.Log($"[{DateTimeOffset.Now:g}] Reached {CheckAchievementSystemActivity}");
            HarmonyLib.FileLog.Log($"[{DateTimeOffset.Now:g}] Initial state of {nameof(__result)}: {__result}");
            HarmonyLib.FileLog.Log($"[{DateTimeOffset.Now:g}] Initial state of {nameof(____deactivateAchievements)}: {____deactivateAchievements}");
            ____deactivateAchievements = false;
            __result = true;
            var ret = false;
            HarmonyLib.FileLog.Log($"[{DateTimeOffset.Now:g}] Final state of {nameof(____deactivateAchievements)}: {____deactivateAchievements}");
            HarmonyLib.FileLog.Log($"[{DateTimeOffset.Now:g}] Final state of {nameof(__result)}: {__result}");
            HarmonyLib.FileLog.Log($"[{DateTimeOffset.Now:g}] Returning {nameof(ret)}: {ret}");
            return ret;
        }
    }
}
