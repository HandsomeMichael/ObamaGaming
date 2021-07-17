using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using ObamaGaming;
using Terraria;
using Terraria.Utilities;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace ObamaGaming.Items.Weapon
{
	public class ReforgeSword : ModItem
	{
		public override bool CloneNewInstances => true;

		public int reforged;
		public int reforgedmax;
		public int reforgedupdate = 0; // I use this to check if reforge is done
		public int permanentdamage;
		public int plsdontsuemeforusingcopyrightedsound;

		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Increases Stat By Reforging It"+
			"\nReforge Capacity Is Increased By How Much You Progress"+
			"\nDecrease Reforge Point When Used");
		}

		public override void SetDefaults() {
			item.damage = 1;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 6;
			item.value = 100000;
			item.rare = 3;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}
		public override void PostReforge()
		{
			if (reforged < reforgedmax) {
				reforged++;
				Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/mus_sfx_a_grab").WithVolume(.7f).WithPitchVariance(.5f));
				plsdontsuemeforusingcopyrightedsound++;
				if(Main.rand.Next(90) == 0 && permanentdamage < reforgedmax / 2)
				{	
					permanentdamage += 1;
				}
			}
			if(reforged == reforgedmax)
			{
				Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/no").WithPitchVariance(.5f));
				plsdontsuemeforusingcopyrightedsound++;
			}
			reforgedupdate = 1;
		}
		public override void ModifyTooltips(List<TooltipLine> tooltips) {
			var ComboCount = new TooltipLine(mod, "Sword:Reforge", $"Reforge : [ {reforged} / {reforgedmax} ] + "+permanentdamage+$" [i:7]");
			ComboCount.overrideColor = Color.Cyan;
			tooltips.Add(ComboCount);
		}
		public override void UpdateInventory(Player player)
		{
			item.damage = 1 + reforged + permanentdamage;
			if (reforgedupdate == 1)
			{
				if (reforged < reforgedmax) {
					CombatText.NewText(player.getRect(), Color.Cyan, "Reforged "+ reforged +" Times");
					reforgedupdate = 0;
				}
				else
				{
					CombatText.NewText(player.getRect(), Color.Cyan, "Max Reforge");
					reforgedupdate = 0;
				}
			}
			if(reforgedmax == 0)
			{
				reforgedmax = 10;
			}
			//Boss Reforge Max Increasement Hook
			if (NPC.downedBoss1)
			{
				reforgedmax = 20;
				if(NPC.downedBoss2)
				{
					reforgedmax = 30;
					if(NPC.downedBoss3)
					{
						reforgedmax = 45;
						if(Main.hardMode)
						{
							reforgedmax = 60;
							if (NPC.downedMechBossAny)
							{
								reforgedmax = 70;
								if (NPC.downedPlantBoss)
								{
									reforgedmax = 100;
									if (NPC.downedGolemBoss)
									{
										reforgedmax = 120;
										if (NPC.downedAncientCultist)
										{
											reforgedmax = 160;
											if (NPC.downedTowerSolar)
											{
												reforgedmax = 180;
												if (NPC.downedMoonlord)
												{
													reforgedmax = 300;
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
		{
			if (NPC.downedQueenBee && Main.rand.Next(60) == 0)
			{
				target.AddBuff(BuffID.Poisoned, reforged*10);
			}
			if (NPC.downedPlantBoss && Main.rand.Next(60) == 0)
			{
				target.AddBuff(BuffID.Confused, reforged*10);
			}
			if (Main.rand.Next(reforgedmax / 4) == 0)
			{
				if (reforged > 1)
				{
					reforged -= 1;
					CombatText.NewText(player.getRect(), Color.Red, "-1");
					Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/protomy").WithVolume(.7f).WithPitchVariance(.5f));
					plsdontsuemeforusingcopyrightedsound++;
				}
			}
			if (Main.rand.Next(120) == 0 && reforged > 4 && permanentdamage < reforgedmax / 2)
			{
				permanentdamage += 1;
				CombatText.NewText(player.getRect(), Color.Green, "+1");
				Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/FNFconfirmMenu").WithVolume(.7f).WithPitchVariance(.5f));
				plsdontsuemeforusingcopyrightedsound++;
			}
		}		
		public override TagCompound Save()
        {
            TagCompound tag = new TagCompound() {
				{ "permanentdamage", permanentdamage },
                { "reforged", reforged },
				{ "reforgedmax", reforgedmax }
            };
            return tag;
        }

        public override void Load(TagCompound tag)
        {
            base.Load(tag);
			permanentdamage = tag.GetInt("permanentdamage");
            reforged = tag.GetInt("reforged");
			reforgedmax = tag.GetInt("reforgedmax");
        }
		/*public override void MeleeEffects(Player player, Rectangle hitbox) {
			if (Main.rand.NextBool(10)) {
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType<Sparkle>());
			}
		}*/
	}
}