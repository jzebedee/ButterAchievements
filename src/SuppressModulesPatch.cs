using HarmonyLib;
using System;
using System.Collections.Generic;
using TaleWorlds.CampaignSystem;

namespace ButterAchievements;

//TaleWorlds.CampaignSystem.Campaign.DeterminedSavedStats(Campaign.GameLoadingType) : void @06000280
// Token: 0x06000280 RID: 640 RVA: 0x000119D4 File Offset: 0x0000FBD4
[HarmonyPatch(typeof(Campaign), "DeterminedSavedStats")]
public static class SuppressModulesPatch
{
    //StoryMode.GameComponents.CampaignBehaviors.AchievementsCampaignBehavior.CheckIfModulesAreDefault() : bool @06000410
    // Token: 0x06000410 RID: 1040 RVA: 0x00018BA0 File Offset: 0x00016DA0/
    private static readonly HashSet<string> _allowedModules = new(StringComparer.OrdinalIgnoreCase)
    {
        "Native",
        "SandBoxCore",
        "CustomBattle",
        "SandBox",
        "Multiplayer",
        "BirthAndDeath",
        "StoryMode"
    };

    public static void Postfix(ref List<string> ____previouslyUsedModules)
        => ____previouslyUsedModules.RemoveAll(x => !_allowedModules.Contains(x));
}
