using HarmonyLib;
using System.Collections.Generic;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;

namespace ButterAchievements;

[HarmonyPatch(typeof(Campaign), "DetermineSavedStats")]
public static class SuppressUsedVersionsPatch
{
    public static void Postfix(ref List<string> ____usedGameVersions)
    {
        ____usedGameVersions.Clear();
        ____usedGameVersions.Add(MBSaveLoad.LastLoadedGameVersion.ToString());
    }
}
