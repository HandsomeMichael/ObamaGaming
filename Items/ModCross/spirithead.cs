using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ObamaGaming.Items.ModCross
{
	public class AdventurerThrow : ModProjectile
	{
		public override string Texture => "ObamaGaming/Items/ModCross/Adventurer1";
		
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Wait what who's head is that ?");
		}
		public override void SetDefaults() {
			projectile.CloneDefaults(ProjectileID.Shuriken);
		}
		public override bool OnTileCollide(Vector2 oldVelocity) {
			projectile.Kill();
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
			Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/omgded"), projectile.position);
			return true;
		}
	}
	public class Adventurer1 : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Head");
			Tooltip.SetDefault("Seems like his adventure is ended by the monster"+
			"\nCan be throwed");
		}

		public override void SetDefaults() 
		{
			item.CloneDefaults(ItemID.Shuriken);
            item.width = 14;
            item.height = 14;
            item.rare = 2;
			item.damage = 5;
			item.shoot = ModContent.ProjectileType<AdventurerThrow>();
			item.maxStack = 10;
		}
	}
	public class RuneWizard1 : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Head");
			Tooltip.SetDefault("Its strangely emitting spirit energy"+
			"\nYou can problaby use this to create powerfull energy");
		}

		public override void SetDefaults() 
		{
            item.width = 14;
            item.height = 14;
            item.rare = -12;
		}
	}
}