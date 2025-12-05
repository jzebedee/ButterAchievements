using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.ModuleManager;

namespace ButterAchievements;

[HarmonyPatch(typeof(Campaign), "DetermineSavedStats")]
public static class SuppressModulesPatch
{
    private static readonly HashSet<string> _allowedModuleIds = new(ModuleHelper.GetOfficialModuleIds(), StringComparer.OrdinalIgnoreCase);

    public static void Postfix(ref List<string> ____previouslyUsedModules)
    {
        var slug = ____previouslyUsedModules.LastOrDefault();
        ____previouslyUsedModules.Clear();

        var onlyOfficialModules = CleanModulesSlug(slug)
            .Select(def => $"{def.ModuleId}{MBSaveLoad.ModuleVersionSeperator}{def.ModuleVersion}");
        var onlyOfficialModulesSlug = string.Join(MBSaveLoad.ModuleCodeSeperator.ToString(), onlyOfficialModules);

        ____previouslyUsedModules.Add(onlyOfficialModulesSlug);
    }

    private static IEnumerable<ModuleDef> CleanModulesSlug(string? slug)
    {
        if (slug is null)
        {
            yield break;
        }

        var modules = slug.Split(MBSaveLoad.ModuleCodeSeperator);
        foreach (var module in modules)
        {
            if (IsAllowedModule(module, out var def))
            {
                yield return def;
            }
        }

        static bool IsAllowedModule(string s, out ModuleDef def)
        {
            var moduleSegments = s.Split(MBSaveLoad.ModuleVersionSeperator);
            if (moduleSegments is not { Length: 2 }) // is not [string moduleId, string moduleVersion])
            {
                def = default;
                return false;
            }

            var moduleId = moduleSegments[0];
            var moduleVersion = moduleSegments[1];

            def = new(moduleId, moduleVersion);
            return _allowedModuleIds.Contains(moduleId);
        }
    }

    private readonly record struct ModuleDef(string ModuleId, string ModuleVersion)
    {
        public static ModuleDef Empty => default;
    }
}
