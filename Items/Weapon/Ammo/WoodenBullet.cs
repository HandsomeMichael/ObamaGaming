using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ObamaGaming.Items.Weapon.Ammo
{
	public class WoodenBullet : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Pointless just like my life.");
		}

		public override void SetDefaults() {
			item.damage = 1;
			item.ranged = true;
			item.width = 8;
			item.height = 8;
			item.maxStack = 3996;
			item.consumable = true;             
			item.knockBack = 1.5f;
			item.value = 10;
			item.rare = 0;
			item.shoot = ModContent.ProjectileType<Projectiles.WBProj>();   
			item.shootSpeed = 16f;                  
			item.ammo = AmmoID.Bullet;              
		}

		// More pain just like my life
		public override void OnConsumeAmmo(Player player) {
			if (Main.rand.NextBool(10)) {
				player.AddBuff(BuffID.Slow, 300);
			}
			if (Main.rand.NextBool(20)) {
				player.AddBuff(BuffID.Cursed, 60);
			}
		}
		/*public virtual void OnCraft(Recipe recipe)
		{
			if (Main.rand.NextBool(10)) {
				player.AddBuff(BuffID.Slow, 300);
			}
			if (Main.rand.NextBool(20)) {
				player.AddBuff(BuffID.Cursed, 60);
			}
		}*/

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DirtBlock, 1);
			recipe.AddIngredient(ItemID.Wood, 1);
			recipe.SetResult(this, 69);
			recipe.AddRecipe();
		}
	}
}
