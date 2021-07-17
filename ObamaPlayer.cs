using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using ObamaGaming;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization; 

namespace ObamaGaming
{
	public class ObamaPlayer : ModPlayer
	{
		//Base Player
		public int PlayerHold;

		public bool ichorhit;
		public bool cursedfirehit;
		public bool frostburnhit;
		public bool onfirehit;
		public bool hellfirehit;
		public bool frostgemhit;

		public bool enchunt_wood;
		public bool enchunt_bone;
		public bool enchunt_bolt;
		public bool enchunt_guider;

		public bool fargorandomsoul;
		public bool fargochamper;

		public override void ResetEffects() {

			ichorhit = false;
			cursedfirehit = false;
			frostburnhit = false;
			onfirehit = false;
			hellfirehit = false;
			frostgemhit = false;

			enchunt_wood = false;
			enchunt_bone = false;
			enchunt_bolt = false;
			enchunt_guider = false;

			fargorandomsoul = false;
			fargochamper = false;
		}
		public override void PostUpdate() {
			if (enchunt_wood && Main.rand.NextFloat() < 0.131579f)
			{
				Dust dust;
				// You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
				Vector2 position = Main.LocalPlayer.Center;
				dust = Main.dust[Dust.NewDust(player.position, 68, 115, 277, 0f, -1f, 0, new Color(255,255,255), 0f)];
			}
		}
		public override void OnHitByNPC(NPC npc, int damage, bool crit)
		{
			if (ichorhit) {	npc.AddBuff(BuffID.Ichor, damage*4); }
			if (cursedfirehit) { npc.AddBuff(BuffID.CursedInferno, damage*4); }
			if (frostburnhit) {	npc.AddBuff(BuffID.Frostburn, damage*4); }
			if (onfirehit) { npc.AddBuff(BuffID.OnFire, damage*4); }

			if (hellfirehit) { npc.AddBuff(BuffID.OnFire, 18000); }
			if (frostgemhit) { npc.AddBuff(BuffID.Frostburn, 18000); }
			if (fargorandomsoul) {Projectile.NewProjectile(player.position.X, player.position.Y, 0, 1, Main.rand.Next(1, ProjectileID.Count), damage*2, 1, player.whoAmI);}
		}
		public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit) {
			if (fargorandomsoul) {target.AddBuff(Main.rand.Next(1, BuffID.Count), damage*60);}
			if (hellfirehit && crit) { target.AddBuff(BuffID.OnFire, damage*4); }
			if (frostgemhit && proj.type == ProjectileID.SnowBallFriendly) { target.AddBuff(BuffID.Frostburn, damage*2); }
			if (frostgemhit && crit && proj.type != ProjectileID.SnowBallFriendly ) {
				for (int i = 0; i < 4; i++) {
					// this wil repeated 4 times iirc
					int a = Projectile.NewProjectile(proj.Center.X, proj.Center.Y - 16f, Main.rand.Next(-10, 11) * .25f, Main.rand.Next(-10, -5) * .25f, ProjectileID.SnowBallFriendly, (int)(proj.damage * .5f), 0, proj.owner);
					Main.projectile[a].aiStyle = 1;
					Main.projectile[a].tileCollide = true;
				}
			}
			if (enchunt_wood && proj.type == ProjectileID.WoodenArrowFriendly && crit && damage > 2) {
				for (int i = 0; i < 5; i++) {
					// this wil repeated 4 times iirc ( the thing substract by -1)
					int a = Projectile.NewProjectile(proj.Center.X, proj.Center.Y - 16f, Main.rand.Next(-10, 11) * .25f, Main.rand.Next(-10, -5) * .25f, ProjectileID.WoodenArrowFriendly, (int)(proj.damage * .5f), 0, proj.owner);
					Main.projectile[a].penetrate = 1;
				}				
			}
			//if ((proj.minion || ProjectileID.Sets.MinionShot[proj.type]) && FrostBurnSummon && !proj.noEnchantments) {
				//target.AddBuff(BuffID.Frostburn, 60 * Main.rand.Next(5, 15), false);
			//}
		}
		public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit) {
			if (fargorandomsoul) {
				target.AddBuff(Main.rand.Next(1, BuffID.Count), damage*60);
				target.position.Y -= damage;
			}
			if (hellfirehit && crit) { target.AddBuff(BuffID.OnFire, damage*4); }
			if (frostgemhit && crit) { target.AddBuff(BuffID.Frostburn, damage*4); }
		}
		public override bool Shoot(Item item, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (fargorandomsoul) {type = Main.rand.Next(1, ProjectileID.Count);}
			if (item.type == ItemID.WoodenBow && enchunt_wood) {
				int numberProjectiles = 4 + Main.rand.Next(2); 
				if (type == ProjectileID.WoodenArrowFriendly) {
					for (int i = 0; i < numberProjectiles; i++)
					{
						Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(30)); // 30 degree spread.
						// If you want to randomize the speed to stagger the projectiles
						int a = Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileID.WoodenArrowFriendly, damage, knockBack, player.whoAmI);
						Main.projectile[a].penetrate = 4;
					}						
				}
				else {
					Vector2 perturbedSpeed2 = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(30));
					Projectile.NewProjectile(position.X, position.Y, perturbedSpeed2.X, perturbedSpeed2.Y, type, damage, knockBack, player.whoAmI); 
				}			
			}
			return true;
		}
	}
}