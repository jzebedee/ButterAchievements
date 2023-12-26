using HarmonyLib;
using TaleWorlds.CampaignSystem;

namespace ButterAchievements;

//SandBox.CampaignBehaviors.DumpIntegrityCampaignBehavior.CheckCheatUsage() : bool @060008CD
// Token: 0x060008CD RID: 2253 RVA: 0x000425D4 File Offset: 0x000407D4
[HarmonyPatch(typeof(SandBox.CampaignBehaviors.DumpIntegrityCampaignBehavior), "CheckCheatUsage")]
public class SuppressCheatIntegrityPatch
{
    /* Campaign.EnabledCheatsBefore info
     * Added in v1.2.7
     * // Token: 0x17000028 RID: 40
     * // (get) Token: 0x06000180 RID: 384 RVA: 0x0000F2B2 File Offset: 0x0000D4B2
     * // (set) Token: 0x06000181 RID: 385 RVA: 0x0000F2BA File Offset: 0x0000D4BA
     * [SaveableProperty(83)]
     * public bool EnabledCheatsBefore { get; set; }
     */
    public static bool Prefix(ref bool __result)
    {
        //suppress cheat usage
        Campaign.Current.EnabledCheatsBefore = false;
        //do pass cheat integrity check
        __result = true;
        //don't run original
        return false;
    }
}