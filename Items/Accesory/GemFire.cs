using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace ObamaGaming.Items.Accesory
{
	public class FireGem : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Getting hit by enemy will ignites them on fire");
		}
		public override void SetDefaults() {
			item.width = 20;
			item.height = 20;
			item.accessory = true;
			item.value = 50000;
			item.rare = ItemRarityID.Pink;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.GetModPlayer<ObamaPlayer>().onfirehit = true;
		}

		public override int ChoosePrefix(UnifiedRandom rand) {
			// When the item is given a prefix, only roll the best modifiers for accessories
			return rand.Next(new int[] { PrefixID.Arcane, PrefixID.Lucky, PrefixID.Menacing, PrefixID.Quick, PrefixID.Violent, PrefixID.Warding });
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Gel, 10);
			recipe.AddIngredient(ItemID.Torch, 5);
			recipe.AddIngredient(ItemID.Shackle, 1);
			recipe.AddRecipeGroup("ObamaGaming:Gem", 2);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
