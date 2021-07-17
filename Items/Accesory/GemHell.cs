using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace ObamaGaming.Items.Accesory
{
	public class HellGem : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Getting hit by enemy will ignites them on fire forever"+
			"\nCritical attack inflicts fire on enemy");
		}
		public override void SetDefaults() {
			item.width = 20;
			item.height = 20;
			item.accessory = true;
			item.value = 50000;
			item.rare = ItemRarityID.Pink;
			item.defense = 2;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.GetModPlayer<ObamaPlayer>().hellfirehit = true;
			player.statDefense += 2;
		}

		public override int ChoosePrefix(UnifiedRandom rand) {
			// When the item is given a prefix, only roll the best modifiers for accessories
			return rand.Next(new int[] { PrefixID.Arcane, PrefixID.Lucky, PrefixID.Menacing, PrefixID.Quick, PrefixID.Violent, PrefixID.Warding });
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HellstoneBar, 5);
			recipe.AddIngredient(ItemID.MagmaStone, 1);
			recipe.AddRecipeGroup("ObamaGaming:Ruby", 5);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
