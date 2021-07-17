using System;
using Microsoft.Xna.Framework;
using ObamaGaming;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ObamaGaming.Projectiles
{
	public class WSThrow : ModProjectile
	{
		public override string Texture => "ObamaGaming/Items/Weapon/WeirdSword";
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Throwed Weird Sword");
		}

		public override void SetDefaults()
		{
			projectile.arrow = true;
			projectile.width = 10;
			projectile.height = 10;
			projectile.aiStyle = 3;
			projectile.friendly = true;
			projectile.ranged = true;
			projectile.CloneDefaults(ProjectileID.EnchantedBoomerang);
			aiType = ProjectileID.EnchantedBoomerang;
		}
	}
	public class WSSpear : ModProjectile
	{
		public override string Texture => "ObamaGaming/Items/Weapon/WeirdSword";
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Speared Weird Sword");
		}

		public override void SetDefaults()
		{
			projectile.arrow = true;
			projectile.width = 10;
			projectile.height = 10;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.ranged = true;
			projectile.penetrate = 2;
			//projectile.CloneDefaults(ProjectileID.WoodenArrowFriendly);
			aiType = ProjectileID.WoodenArrowFriendly;
		}
		public override bool OnTileCollide(Vector2 oldVelocity) {
			//If collide with tile, reduce the penetrate.
			//So the projectile can reflect at most 5 times
			projectile.penetrate--;
			if (projectile.penetrate <= 0) {
				projectile.Kill();
			}
			else {
				Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
				Main.PlaySound(SoundID.Item10, projectile.position);
				if (projectile.velocity.X != oldVelocity.X) {
					projectile.velocity.X = -oldVelocity.X;
				}
				if (projectile.velocity.Y != oldVelocity.Y) {
					projectile.velocity.Y = -oldVelocity.Y;
				}
			}
			return false;
		}
		public override void Kill(int timeLeft)
		{
			// This code and the similar code above in OnTileCollide spawn dust from the tiles collided with. SoundID.Item10 is the bounce sound you hear.
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
			Main.PlaySound(SoundID.Item10, projectile.position);
			Gore.NewGore(projectile.position, projectile.velocity, mod.GetGoreSlot("Gores/WSLid1"), projectile.scale);
			Gore.NewGore(projectile.position, projectile.velocity, mod.GetGoreSlot("Gores/WSLid2"), projectile.scale);
		}
	}
}