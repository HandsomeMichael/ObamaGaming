using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using System;
using ObamaGaming.Dusts;
using System.Collections.Generic;

namespace ObamaGaming.NPCs
{
	[AutoloadBossHead]
	public class Nihilar : ModNPC
	{
		public int playerproj = ProjectileID.SpikyBall;
		//public int playerdamg;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nihilar The Goblin");
			Main.npcFrameCount[npc.type] = 4;
			NPCID.Sets.TrailCacheLength[npc.type] = 4;
			NPCID.Sets.TrailingMode[npc.type] = 0;
		}

		public override void SetDefaults()
		{
			npc.width = 100;
			npc.height = 88;
			npc.damage = 40;
			npc.defense = 14;
            npc.value = 65000;
			npc.lifeMax = 6000;
			npc.knockBackResist = 0;
			npc.boss = true;
			npc.noGravity = true;
			npc.aiStyle = -1;
			//music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/Armageddon");
			npc.noTileCollide = true;
			npc.HitSound = SoundID.NPCHit2;
			npc.DeathSound = SoundID.NPCDeath5;
			animationType = NPCID.Wraith;
		}
		public override void OnHitByProjectile(Projectile projectile, int damage, float knockback, bool crit) {
			if (!projectile.minion) {playerproj = projectile.type;}
			for (int i = 0; i < 5; i++) {
				// this wil repeated 4 times iirc
				int a = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y - 16f, Main.rand.Next(-10, 11) * .25f, Main.rand.Next(-10, 11) * .25f, playerproj, damage*3, 0);
				Main.projectile[a].aiStyle = 1;
				Main.projectile[a].hostile = true;
				Main.projectile[a].tileCollide = true;
			}
		}
		public virtual void NihilSound(string sound) {
			Main.PlaySound(SoundLoader.customSoundType, npc.position, mod.GetSoundSlot(SoundType.Custom, "Sounds/Nihil/"+sound));
		}
		public bool SummonedMe = false;
		protected float speed = 5f;//2
		protected float acceleration = 0.1f;
		protected float speedY = 1.5f;
		protected float accelerationY = 0.04f;
		public override void AI() {
			if (!SummonedMe) {
				NihilSound("nihilarsummon");
				CombatText.NewText(npc.getRect(), Color.White, "Who Have Summoned Me ?");
				SummonedMe = true;
			}
			if (!ShouldMove(npc.ai[3])) {
				CustomBehavior(ref npc.ai[3]);
				return;
			}
			bool flag33 = false;
			if (npc.justHit) {
				npc.ai[2] = 0f;
			}
			if (npc.ai[2] >= 0f) {
				int num379 = 16;
				bool flag34 = false;
				bool flag35 = false;
				if (npc.position.X > npc.ai[0] - (float)num379 && npc.position.X < npc.ai[0] + (float)num379) {
					flag34 = true;
				}
				else if (npc.velocity.X < 0f && npc.direction > 0 || npc.velocity.X > 0f && npc.direction < 0) {
					flag34 = true;
				}
				num379 += 24;
				if (npc.position.Y > npc.ai[1] - (float)num379 && npc.position.Y < npc.ai[1] + (float)num379) {
					flag35 = true;
				}
				if (flag34 && flag35) {
					npc.ai[2] += 1f;
					if (npc.ai[2] >= 30f && num379 == 16) {
						flag33 = true;
					}
					if (npc.ai[2] >= 60f) {
						npc.ai[2] = -200f;
						npc.direction *= -1;
						npc.velocity.X *= -1f;
						npc.collideX = false;
					}
				}
				else {
					npc.ai[0] = npc.position.X;
					npc.ai[1] = npc.position.Y;
					npc.ai[2] = 0f;
				}
				npc.TargetClosest(true);
			}
			else {
				npc.ai[2] += 1f;
				if (Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) > npc.position.X + (float)(npc.width / 2)) {
					npc.direction = -1;
				}
				else {
					npc.direction = 1;
				}
			}
			int num380 = (int)((npc.position.X + (float)(npc.width / 2)) / 16f) + npc.direction * 2;
			int num381 = (int)((npc.position.Y + (float)npc.height) / 16f);
			bool flag36 = true;
			bool flag37 = false;
			int num382 = 3;
			for (int num404 = num381; num404 < num381 + num382; num404++) {
				if (Main.tile[num380, num404] == null) {
					Main.tile[num380, num404] = new Tile();
				}
				if (Main.tile[num380, num404].nactive() && Main.tileSolid[(int)Main.tile[num380, num404].type] || Main.tile[num380, num404].liquid > 0) {
					if (num404 <= num381 + 1) {
						flag37 = true;
					}
					flag36 = false;
					break;
				}
			}
			if (flag33) {
				flag37 = false;
				flag36 = true;
			}
			if (flag36) {
				npc.velocity.Y += Math.Max(0.2f, 2.5f * accelerationY);
				if (npc.velocity.Y > Math.Max(2f, speedY)) {
					npc.velocity.Y = Math.Max(2f, speedY);
				}
			}
			else {
				if (npc.directionY < 0 && npc.velocity.Y > 0f || flag37) {
					npc.velocity.Y -= 0.2f;
				}
				if (npc.velocity.Y < -4f) {
					npc.velocity.Y = -4f;
				}
			}
			if (npc.collideX) {
				npc.velocity.X = npc.oldVelocity.X * -0.4f;
				if (npc.direction == -1 && npc.velocity.X > 0f && npc.velocity.X < 1f) {
					npc.velocity.X = 1f;
				}
				if (npc.direction == 1 && npc.velocity.X < 0f && npc.velocity.X > -1f) {
					npc.velocity.X = -1f;
				}
			}
			if (npc.collideY) {
				npc.velocity.Y = npc.oldVelocity.Y * -0.25f;
				if (npc.velocity.Y > 0f && npc.velocity.Y < 1f) {
					npc.velocity.Y = 1f;
				}
				if (npc.velocity.Y < 0f && npc.velocity.Y > -1f) {
					npc.velocity.Y = -1f;
				}
			}
			if (npc.direction == -1 && npc.velocity.X > -speed) {
				npc.velocity.X -= acceleration;
				if (npc.velocity.X > speed) {
					npc.velocity.X -= acceleration;
				}
				else if (npc.velocity.X > 0f) {
					npc.velocity.X += acceleration / 2f;
				}
				if (npc.velocity.X < -speed) {
					npc.velocity.X = -speed;
				}
			}
			else if (npc.direction == 1 && npc.velocity.X < speed) {
				npc.velocity.X += acceleration;
				if (npc.velocity.X < -speed) {
					npc.velocity.X += acceleration;
				}
				else if (npc.velocity.X < 0f) {
					npc.velocity.X -= acceleration / 2f;
				}
				if (npc.velocity.X > speed) {
					npc.velocity.X = speed;
				}
			}
			if (npc.directionY == -1 && (double)npc.velocity.Y > -speedY) {
				npc.velocity.Y -= accelerationY;
				if ((double)npc.velocity.Y > speedY) {
					npc.velocity.Y -= accelerationY * 1.25f;
				}
				else if (npc.velocity.Y > 0f) {
					npc.velocity.Y += accelerationY * 0.75f;
				}
				if ((double)npc.velocity.Y < -speedY) {
					npc.velocity.Y = -speedY;
				}
			}
			else if (npc.directionY == 1 && (double)npc.velocity.Y < speedY) {
				npc.velocity.Y += accelerationY;
				if ((double)npc.velocity.Y < -speedY) {
					npc.velocity.Y += accelerationY * 1.25f;
				}
				else if (npc.velocity.Y < 0f) {
					npc.velocity.Y -= accelerationY * 0.75f;
				}
				if ((double)npc.velocity.Y > speedY) {
					npc.velocity.Y = speedY;
				}
			}
			CustomBehavior(ref npc.ai[3]);
		}
		int attack1;
		int attackback;
		int teleport;
		int createteleport;
		int teltick;
		public virtual void CustomBehavior(ref float ai) {
			attack1++;
			attackback++;
			teleport++;
			createteleport++;
			Player player = Main.player[npc.target];
			if (attack1 > 60) {
				if (Main.rand.Next(10) == 0) {
					NihilSound("nihilarat1");
					CombatText.NewText(npc.getRect(), Color.White, "Take That !");
				}
				int at1 = Projectile.NewProjectile(npc.position.X, npc.position.Y, npc.velocity.X*3, npc.velocity.Y*3, ProjectileID.Dynamite, 20, 5);
				Main.projectile[at1].timeLeft = 120;
				Main.projectile[at1].hostile = true;
				CombatText.NewText(npc.getRect(), Color.White, "Ha !");
				attack1 = 0;
			}
			if (attackback > 100 && playerproj != 0) {
				if (Main.rand.Next(10) == 0) {
					NihilSound("nihilarat2");
					CombatText.NewText(npc.getRect(), Color.White, "Hahaha !");
				}
				int at1 = Projectile.NewProjectile(npc.position.X, npc.position.Y, npc.velocity.X*3, npc.velocity.Y*3, playerproj, 20, 5);
				//Main.projectile[at1].timeLeft = 120;
				Main.projectile[at1].hostile = true;
				attackback = 0;
			}
			if (createteleport > 200 ) {
				NihilSound("nihilfight2");
				for (int i = 0; i < 5; i++) {Projectile.NewProjectile(player.position.X + Main.rand.Next(-500, 501), player.position.Y + Main.rand.Next(-500, 501), 0, 0, ModContent.ProjectileType<NihilarPortal>(), 25, 5);}
				createteleport = 0;
			}
			if (teleport > 360 ) {
				NihilSound("nihilfight");
				for (int b = 0; b < 5; b++) {
					for (int i = 0; i < 5; i++) 
					{ 
						Dust.NewDust(npc.position, 2, 2, ModContent.DustType<Sparkle>());
					}
					Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/protomy").WithVolume(.7f).WithPitchVariance(.5f));
					for (int i = 0; i < 5; i++) {Projectile.NewProjectile(npc.position.X, npc.position.Y, Main.rand.Next(-30, 31), Main.rand.Next(-30, 31), playerproj, 20, 5);}
					CombatText.NewText(npc.getRect(), Color.Red, "DIE");
					npc.position.X = player.position.X + Main.rand.Next(-300, 301);
					npc.position.Y = player.position.Y + Main.rand.Next(-300, 301);
					for (int a = 0; a < 20; a++) 
					{ 
						Dust.NewDust(npc.position, 2, 2, ModContent.DustType<Sparkle>());
					}
				}
				teleport = 0;
			}
		}

		public virtual bool ShouldMove(float ai) {
			return true;
		}
		public override void NPCLoot() {
			NihilSound("nihilded");
			CombatText.NewText(npc.getRect(), Color.White, "Nooo! I have been defeated");
			Item.NewItem(npc.getRect(), ItemID.UmbrellaHat);
		}
	}
	public class NihilarPortal : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Nihilar Portal");
		}
		public override void SetDefaults() {
			projectile.width = 128;               //The width of projectile hitbox
			projectile.height = 128;              //The height of projectile hitbox
			projectile.aiStyle = -1;             //The ai style of the projectile, please reference the source code of Terraria
			projectile.friendly = false;         //Can the projectile deal damage to enemies?
			projectile.hostile = true;         //Can the projectile deal damage to the player?
			//projectile.ranged = true;           //Is the projectile shoot by a ranged weapon?
			projectile.penetrate = 1;           //How many monsters the projectile can penetrate. (OnTileCollide below also decrements penetrate for bounces as well)
			projectile.timeLeft = 500;          //The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
			projectile.alpha = 255;             //The transparency of the projectile, 255 for completely transparent. (aiStyle 1 quickly fades the projectile in) Make sure to delete this if you aren't using an aiStyle that fades in. You'll wonder why your projectile is invisible.
			projectile.light = 0.5f;            //How much light emit around the projectile
			projectile.ignoreWater = true;          //Does the projectile's speed be influenced by water?
			projectile.tileCollide = false;          //Can the projectile collide with tiles?
			projectile.extraUpdates = 1;            //Set to above 0 if you want the projectile to update multiple time in a frame
			projectile.scale = 0.5f;
			drawOriginOffsetY = -200; // doesn't change
			drawOriginOffsetX = -100;
			//projectile.color = Main.DiscoG;
		}
		public int state = 0;
		public bool hitplayer = false;
		public override bool CanHitPlayer(Player target)
		{
			return hitplayer;
		}
		public override void AI () {
			//projectile.rotation++;
			if (state == 0) {
				projectile.alpha--;
				if (projectile.alpha < 1) {state = 1;}
				for (int i = 0; i < Main.maxProjectiles; i++) {
					if (Main.projectile[i].active && Main.projectile[i].friendly && projectile.Hitbox.Intersects(Main.projectile[i].Hitbox)) {
						Main.projectile[i].Kill();
					}
				}
			}
			if (state == 1 && projectile.timeLeft < 245) {
				projectile.alpha++;
				hitplayer = true;
				//projectile.hostile = true;
				//projectile.color = Color.Red;
				projectile.scale -= (float)0.01f;
			}
		}
	}
}
