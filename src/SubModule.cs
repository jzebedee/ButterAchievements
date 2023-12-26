using HarmonyLib;
using System;
using System.Reflection;
using TaleWorlds.MountAndBlade;

namespace ButterAchievements;

    public class SubModule : MBSubModuleBase
    {
        private const string HarmonyId = $"{nameof(ButterAchievements)}.harmony";

        private readonly Lazy<Harmony> _harmony = new(() => new Harmony(HarmonyId));

        protected override void OnSubModuleLoad()
        {
            base.OnSubModuleLoad();

            //EnableAchievementsPatch:
            // 1. re-enables achievements in previously tainted savefiles
            // 2. activates achievements even if mods or cheat mode is present

            //EnableSandboxAchievementsPatch:
            // 1. loads the achievements behavior in Sandbox mode games

            //SwallowStoryModeAchievementsDuringSandboxPatch:
            // 1. prevents game from crashing while registering Story mode achievements that Sandbox doesn't have

            //SuppressModulesPatch:
            // 1. hides non-official mods from the module list, so that tainted saves can be used in vanilla and after using this mod

            _harmony.Value.PatchAll(Assembly.GetExecutingAssembly());
        }
    }