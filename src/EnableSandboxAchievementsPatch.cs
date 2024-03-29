﻿using HarmonyLib;
using StoryMode.GameComponents.CampaignBehaviors;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;

namespace ButterAchievements;

//SandBox.SandBoxSubModule.InitializeGameStarter(Game, IGameStarter) : void @060000DD
// Token: 0x060000DD RID: 221 RVA: 0x00006A78 File Offset: 0x00004C78
[HarmonyPatch(typeof(SandBox.SandBoxSubModule), "InitializeGameStarter")]
public class EnableSandboxAchievementsPatch
{
    public static void Postfix(IGameStarter gameStarterObject)
    {
        if(gameStarterObject is not CampaignGameStarter cgs)
        {
            return;
        }

        cgs.AddBehavior(new AchievementsCampaignBehavior());
    }
}
