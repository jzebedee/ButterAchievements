using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Reflection;
using TaleWorlds.CampaignSystem;

namespace ButterAchievements;
using static KnownVersions;

[HarmonyPatch]
public static partial class SuppressModulesPatch
{
    public static bool Prepare()
    {
        var version = CurrentVersion;

        //only enable this on pre-1.2.7 games
        //post-1.2.7 uses the DumpIntegrityCampaignBehavior to check this
        if (version < KnownVersions.v1_2_7)
        {
            return true;
        }

        return false;
    }

    public static MethodBase TargetMethod()
    {
        var version = CurrentVersion;
        if (version < KnownVersions.v1_1_0)
        {
            //TaleWorlds.CampaignSystem.Campaign.DetermineModules() : void @06000277
            //// Token: 0x06000277 RID: 631 RVA: 0x000110C8 File Offset: 0x0000F2C8
            return AccessTools.Method(typeof(Campaign), "DetermineModules");
        }

        //TaleWorlds.CampaignSystem.Campaign.DeterminedSavedStats(Campaign.GameLoadingType) : void @06000280
        //// Token: 0x06000280 RID: 640 RVA: 0x000119D4 File Offset: 0x0000FBD4
        return AccessTools.Method(typeof(Campaign), "DeterminedSavedStats");
    }

    //StoryMode.GameComponents.CampaignBehaviors.AchievementsCampaignBehavior.CheckIfModulesAreDefault() : bool @06000410
    //// Token: 0x06000410 RID: 1040 RVA: 0x00018BA0 File Offset: 0x00016DA0/
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
