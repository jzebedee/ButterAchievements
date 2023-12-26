using HarmonyLib;

namespace ButterAchievements;

//StoryMode.GameComponents.CampaignBehaviors.AchievementsCampaignBehavior.CheckAchievementSystemActivity() : bool @060003DE
// Token: 0x060003DE RID: 990 RVA: 0x00017B98 File Offset: 0x00015D98
[HarmonyPatch(
    typeof(StoryMode.GameComponents.CampaignBehaviors.AchievementsCampaignBehavior),
    nameof(StoryMode.GameComponents.CampaignBehaviors.AchievementsCampaignBehavior.CheckAchievementSystemActivity)
)]
public class EnableAchievementsPatch
{
    public static bool Prefix(ref bool __result, ref bool ____deactivateAchievements)
    {
        //don't deactivate achievements
        ____deactivateAchievements = false;
        //do pass achievement system check
        __result = true;
        //don't run original
        return false;
    }
}