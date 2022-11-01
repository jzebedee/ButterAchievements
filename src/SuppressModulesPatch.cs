using HarmonyLib;
using System;
using System.Collections.Generic;

namespace ButterAchievements
{
    //TaleWorlds.CampaignSystem.Campaign.DetermineModules() : void @06000277
    //// Token: 0x06000277 RID: 631 RVA: 0x000110C8 File Offset: 0x0000F2C8
    [HarmonyPatch(typeof(TaleWorlds.CampaignSystem.Campaign), "DetermineModules")]
    public class SuppressModulesPatch
    {
        private static readonly HashSet<string> _allowedModules = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
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
}
