using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace ObamaGaming.Items.Weapon
{
	public class Ak47 : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("50% chance to not consume ammo");
		}

		public override void SetDefaults() {
			item.damage = 20;
			item.ranged = true; 
			item.width = 40; 
			item.height = 20; 
			item.useTime = 5; 
			item.useAnimation = 5; 
			item.useStyle = ItemUseStyleID.HoldingOut; 
			item.noMelee = true; 
			item.knockBack = 4; 
			item.value = 10000; 
			item.rare = ItemRarityID.Green; 
			item.UseSound = SoundID.Item11; // Krunker Gaming.
			item.autoReuse = true; 
			item.shoot = 10; 
			item.shootSpeed = 16f; 
			item.useAmmo = AmmoID.Bullet; 
		}
		public override bool ConsumeAmmo(Player player)
		{
			return Main.rand.NextFloat() >= .50f;
		}
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(2, 0);
		}
	}
}
