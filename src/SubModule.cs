using HarmonyLib;
using System;
using System.Reflection;
using TaleWorlds.MountAndBlade;

namespace ButterAchievements
{
    public class SubModule : MBSubModuleBase
    {
        private const string HarmonyId = $"{nameof(ButterAchievements)}.harmony";

        private readonly Lazy<Harmony> _harmony = new(() => new Harmony(HarmonyId));

        protected override void OnSubModuleLoad()
        {
            base.OnSubModuleLoad();

            FileLog.Log($"[{DateTimeOffset.Now:g}] Reached {nameof(OnSubModuleLoad)} for {HarmonyId}");

            _harmony.Value.PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}