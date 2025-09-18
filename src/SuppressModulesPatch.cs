using HarmonyLib;
using System.Collections.Generic;
using System.Linq;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.ModuleManager;

namespace ButterAchievements;

[HarmonyPatch(typeof(Campaign), "DetermineSavedStats")]
public static class SuppressModulesPatch
{
    //private static readonly HashSet<string> _allowedModules = [.. ModuleHelper.GetOfficialModuleIds()];

    private static readonly string _allowedModulesSlug = string.Join(MBSaveLoad.ModuleCodeSeperator.ToString(),
        ModuleHelper.GetOfficialModuleIds()
          .Select(moduleId => $"{moduleId}{MBSaveLoad.ModuleVersionSeperator}v0.0.0.0"));

    public static void Postfix(ref List<string> ____previouslyUsedModules)
    {
        ____previouslyUsedModules.Clear();
        ____previouslyUsedModules.Add(_allowedModulesSlug);
        //____previouslyUsedModules.RemoveAll(pum => !_allowedModules.Contains(pum));
    }
}
