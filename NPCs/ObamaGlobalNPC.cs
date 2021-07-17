using System;
using ObamaGaming;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace ObamaGaming.NPCs
{
	public class ObamaGlobalNPC : GlobalNPC
	{
		public override bool InstancePerEntity => true;
		private int obamatimer;

		/*public static void QuickSound(this NPC npc, string sound) {
			Main.PlaySound(SoundLoader.customSoundType, npc.position, mod.GetSoundSlot(SoundType.Custom, "Sounds/"+sound));
		}*/
		public override void PostAI(NPC npc)
		{
			/*var spiritMod = ModLoader.GetMod("SpiritMod");
			if (spiritMod != null && npc.type == spiritMod.NPCType("BoundAdventurer") || npc.type == spiritMod.NPCType("BoundGambler") || npc.type == spiritMod.NPCType("BoundRogue")) {
				obamatimer++;
				if (obamatimer > 240) {
					obamatimer = 0;
					string[] modnames = { "Help !", "Untied Me Pls !", "Pls Help !", "Help me !", "Pleeaasee Heelp Meeh !"};
					CombatText.NewText(npc.getRect(), Color.White, Main.rand.Next(modnames));
				}
			}*/
			if (ObamaConfig.Instance.AllowNpcTalk) {
				if (npc.type == NPCID.BoundGoblin || npc.type == NPCID.BoundMechanic || npc.type == NPCID.BoundWizard) {
					obamatimer++;
					if (obamatimer > 240) {
						obamatimer = 0;
						string[] names = { "Help !", "Hello ?", "Please :(", "Help me !", "Please Help Me !"};
						CombatText.NewText(npc.getRect(), Color.White, Main.rand.Next(names));
					}
				}
				if (npc.type == NPCID.BartenderUnconscious) {
					obamatimer++;
					if (obamatimer > 120) {
						obamatimer = 0;
						string[] sleep = { "Zzz", "ZzzZz", "zzZzz", "*sleeping noises", "ZZZ"};
						CombatText.NewText(npc.getRect(), Color.White, Main.rand.Next(sleep));
					}
				}
			}
		}
		public override void OnHitNPC(NPC npc, NPC target, int damage, float knockback, bool crit)
		{
			if (ObamaConfig.Instance.AllowNpcTalk) {
				if (target.townNPC) {
					/*if (npc.type == NPCID.BlueSlime && npc.type == NPCID.JungleSlime && npc.type == NPCID.YellowSlime 
					&& npc.type == NPCID.RedSlime && npc.type == NPCID.BlackSlime && npc.type == NPCID.BabySlime 
					&& npc.type == NPCID.GreenSlime && npc.type == NPCID.Pinky && npc.type == NPCID.PurpleSlime && npc.type == NPCID.BlueSlime
					&& npc.type == NPCID.KingSlime) {
						string[] slimiyuwwu = { "i hate slime", "pls go away slime", "slime is so sticky", "bad slime", "ugh"};
						CombatText.NewText(npc.getRect(), Color.White, Main.rand.Next(slimiyuwwu));
					}
					else {*/
						string[] hurtoof = { "oof", "aww", "ouch", "that hurt", "ugh :("};
						CombatText.NewText(npc.getRect(), Color.White, Main.rand.Next(hurtoof));
				}
			}
		}
	}
}