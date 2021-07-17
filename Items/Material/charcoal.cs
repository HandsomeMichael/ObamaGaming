using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;


namespace ObamaGaming.Items.Material
{
	public class charcoal : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Charcoal");
			Tooltip.SetDefault("Alternative to gel");
		}

		public override void SetDefaults() 
		{
			item.width = 26;
			item.height = 26;
			item.rare = 0;
			item.maxStack = 100;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Wood, 6);
			recipe.AddTile(TileID.Furnaces);
			recipe.SetResult(this, 3);
			recipe.AddRecipe();
		}
	}
}