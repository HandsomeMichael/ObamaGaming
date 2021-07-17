using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ObamaGaming;

namespace ObamaGaming
{
	public static class ObamaRecipe
	{
		private static void mrecipe(Mod mod, int modIngredient, int ingredientStack, int resultType, int resultStack)
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(modIngredient, ingredientStack);
			recipe.AddTile(TileID.WorkBenches);
			/*if (reqTile != null) {
				recipe.AddTile(null, reqTile);
			}*/
			recipe.SetResult(resultType, resultStack);
			recipe.AddRecipe(); 
		}
		public static void AddModSupport(Mod mod) {
			//Mod pboneMod = ModLoader.GetMod("PboneUtils");
			//Mod fargoMod = ModLoader.GetMod("Fargowiltas");
			Mod calamityMod = ModLoader.GetMod("CalamityMod");
			Mod calamityAlt = ModLoader.GetMod("calamityVanillaItemRecipeChanges");
			//Mod splitMod = ModLoader.GetMod("Split");
			Mod spiritMod = ModLoader.GetMod("SpiritMod");
			Mod thoriumMod = ModLoader.GetMod("ThoriumMod");

			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<Items.Material.charcoal>());
			recipe.AddIngredient(ItemID.Wood, 1);
			recipe.SetResult(ItemID.Torch, 1);
			recipe.AddRecipe();
			
			if (spiritMod != null) {
				if (calamityMod != null) {mrecipe(mod, spiritMod.ItemType("BloodFire"), 1, calamityMod.ItemType("BloodOrb"), 3);}
				if (calamityAlt != null) {mrecipe(mod, spiritMod.ItemType("BloodFire"), 1, calamityAlt.ItemType("BloodOrb"), 3);}
				if (thoriumMod != null) {mrecipe(mod, spiritMod.ItemType("BloodFire"), 1, thoriumMod.ItemType("Blood"), 30);}
			}
			if (calamityMod != null) {
				if (spiritMod != null) {mrecipe(mod, calamityMod.ItemType("BloodOrb"), 3, spiritMod.ItemType("BloodFire"), 1);}
				if (thoriumMod != null) {mrecipe(mod, calamityMod.ItemType("BloodOrb"), 1, thoriumMod.ItemType("Blood"), 10);}
			}
			if (calamityAlt != null) {
				if (spiritMod != null) {mrecipe(mod, calamityAlt.ItemType("BloodOrb"), 3, spiritMod.ItemType("BloodFire"), 1);}
				if (thoriumMod != null) {mrecipe(mod, calamityAlt.ItemType("BloodOrb"), 1, thoriumMod.ItemType("Blood"), 10);}
			}
			if (thoriumMod != null) {
				if (calamityMod != null) {mrecipe(mod, thoriumMod.ItemType("Blood"), 10, calamityMod.ItemType("BloodOrb"), 1);}
				if (calamityAlt != null) {mrecipe(mod, thoriumMod.ItemType("Blood"), 10, calamityAlt.ItemType("BloodOrb"), 1);}
				if (spiritMod != null) {mrecipe(mod, thoriumMod.ItemType("Blood"), 30, spiritMod.ItemType("BloodFire"), 1);}
			}
			/*
			if (spiritMod != null && calamityAlt != null || calamityMod != null ) {
				recipe = new ModRecipe(mod);
				recipe.AddIngredient(spiritMod.ItemType("BloodFire"), 1);
				recipe.AddTile(TileID.WorkBenches);
				if (calamityMod != null) {recipe.SetResult(calamityMod.ItemType("BloodOrb"), 3);}
				if (calamityAlt != null) {recipe.SetResult(calamityAlt.ItemType("BloodOrb"), 3);}
				recipe.AddRecipe();

				recipe = new ModRecipe(mod);
				if (calamityMod != null) {recipe.AddIngredient(calamityMod.ItemType("BloodOrb"), 3);}
				if (calamityAlt != null) {recipe.AddIngredient(calamityAlt.ItemType("BloodOrb"), 3);}
				recipe.AddTile(TileID.WorkBenches);
				recipe.SetResult(spiritMod.ItemType("BloodFire"), 1);
				recipe.AddRecipe();
			}*/
		}
	}
}