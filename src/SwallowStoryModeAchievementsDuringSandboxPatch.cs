using HarmonyLib;
using StoryMode;
using StoryMode.GameComponents.CampaignBehaviors;
using System;

namespace ButterAchievements;

//StoryMode.GameComponents.CampaignBehaviors.AchievementsCampaignBehavior.RegisterEvents() : void @060003C9
// Token: 0x060003C9 RID: 969 RVA: 0x000175E8 File Offset: 0x000157E8
[HarmonyPatch(typeof(AchievementsCampaignBehavior), nameof(AchievementsCampaignBehavior.RegisterEvents))]
public class SwallowStoryModeAchievementsDuringSandboxPatch
{
    public static Exception? Finalizer(Exception __exception)
        => __exception switch
        {
            NullReferenceException when StoryModeManager.Current is null => null,
            _ => __exception
        };
}
