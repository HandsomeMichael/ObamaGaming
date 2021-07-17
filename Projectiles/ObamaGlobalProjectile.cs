using Microsoft.Xna.Framework;
using System;
using ObamaGaming;
using ObamaGaming.Projectiles;
using ObamaGaming.Dusts;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ObamaGaming.Projectiles
{
	public class ObamaGlobalProj : GlobalProjectile
	{
		public override void Kill(Projectile projectile, int timeLeft)
		{
			var spiritMod = ModLoader.GetMod("SpiritMod");
			Player player = Main.player[projectile.owner];
			ObamaPlayer p = (ObamaPlayer)player.GetModPlayer(mod, "ObamaPlayer");
			
			/*if (projectile.type == ProjectileID.WoodenArrowFriendly && p.woodenstaf) {
				player.QuickSpawnItem(ItemID.WoodenArrow);
			}*/
		}
		public override void AI(Projectile projectile) {
			var spiritMod = ModLoader.GetMod("SpiritMod");
			Player player = Main.player[projectile.owner];
			ObamaPlayer p = (ObamaPlayer)player.GetModPlayer(mod, "ObamaPlayer");
			if (projectile.type == ProjectileID.WoodenArrowFriendly && p.enchunt_wood && Main.rand.Next(30) == 0) {
				Dust.NewDust(projectile.position, 1, 1, ModContent.DustType<Woodust>());
			}
		}
		public override void PostAI(Projectile projectile) {
			//Main.netMode != NetmodeID.MultiplayerClient
			if (projectile.type == ProjectileID.PurificationPowder) {
				for (int i = 0; i < Main.maxNPCs; i++) {
					if (Main.npc[i].active && Main.npc[i].type == NPCID.CorruptBunny || Main.npc[i].type == NPCID.CrimsonBunny && projectile.Hitbox.Intersects(Main.npc[i].Hitbox)) {
						Main.npc[i].Transform(NPCID.Bunny);
					}
					if (Main.npc[i].active && Main.npc[i].type == NPCID.CorruptGoldfish || Main.npc[i].type == NPCID.CrimsonGoldfish && projectile.Hitbox.Intersects(Main.npc[i].Hitbox)) {
						Main.npc[i].Transform(NPCID.Goldfish);
					}
					if (Main.npc[i].active && Main.npc[i].type == NPCID.CorruptPenguin || Main.npc[i].type == NPCID.CrimsonPenguin && projectile.Hitbox.Intersects(Main.npc[i].Hitbox)) {
						Main.npc[i].Transform(NPCID.Penguin);
					}
				}
			}
			if (projectile.type == ProjectileID.VilePowder) {
				for (int i = 0; i < Main.maxNPCs; i++) {
					if (Main.npc[i].active && Main.npc[i].type == NPCID.Bunny && projectile.Hitbox.Intersects(Main.npc[i].Hitbox)) {
						Main.npc[i].Transform(NPCID.CorruptBunny);
					}
					if (Main.npc[i].active && Main.npc[i].type == NPCID.Goldfish && projectile.Hitbox.Intersects(Main.npc[i].Hitbox)) {
						Main.npc[i].Transform(NPCID.CorruptGoldfish);
					}
					if (Main.npc[i].active && Main.npc[i].type == NPCID.Penguin && projectile.Hitbox.Intersects(Main.npc[i].Hitbox)) {
						Main.npc[i].Transform(NPCID.CorruptPenguin);
					}
				}
			}
			if (projectile.type == ProjectileID.ViciousPowder) {
				for (int i = 0; i < Main.maxNPCs; i++) {
					if (Main.npc[i].active && Main.npc[i].type == NPCID.Bunny && projectile.Hitbox.Intersects(Main.npc[i].Hitbox)) {
						Main.npc[i].Transform(NPCID.CrimsonBunny);
					}
					if (Main.npc[i].active && Main.npc[i].type == NPCID.Goldfish && projectile.Hitbox.Intersects(Main.npc[i].Hitbox)) {
						Main.npc[i].Transform(NPCID.CrimsonGoldfish);
					}
					if (Main.npc[i].active && Main.npc[i].type == NPCID.Penguin && projectile.Hitbox.Intersects(Main.npc[i].Hitbox)) {
						Main.npc[i].Transform(NPCID.CrimsonPenguin);
					}
				}
			}
		}
	}
}