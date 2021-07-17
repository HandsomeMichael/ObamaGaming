using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using Terraria.Localization;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace ObamaGaming.Items.Accesory
{
	public class WoodenEnchunt : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("List of Ability :"+
			$"\n[i:39]Wooden Bow Will Shoot More Arrow"+
			$"\n[i:40]Wooden Arrow Will Create More Arrow When Crit"+
			$"\n[i:24]Wooden Sword Will Create More Sword"+
			$"\n[i:196]Wooden Hammer Will Confuse Enemy"+
			$"\n[i:284]Wooden Boomerang Will Create Damaging Wood"+
			$"\n[i:3278]Wooden YoYo Will Slow Down Enemy And Create Damaging Wood"+
			$"\n[i:728]Wearing Full Wooden Armor Gives You Dryad Bless");
		}
		public override void SetDefaults() {
			item.width = 20;
			item.height = 20;
			item.accessory = true;
			item.value = 50000;
			item.rare = ItemRarityID.Pink;
		}
		public override void ModifyTooltips(List<TooltipLine> list) {
            foreach (TooltipLine tooltipLine in list) {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName") {
                    tooltipLine.overrideColor = new Color(102, 51, 0);
                }
            }
        }
		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.GetModPlayer<ObamaPlayer>().enchunt_wood = true;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Wood, 20);
			recipe.AddIngredient(ItemID.Gel, 5);
			recipe.AddIngredient(ItemID.FallenStar, 1);
			recipe.AddIngredient(ItemID.WoodenBow, 1);
			recipe.AddIngredient(ItemID.WoodenSword, 1);
			recipe.AddIngredient(ItemID.WoodenHammer, 1);
			recipe.AddIngredient(ItemID.WoodHelmet, 1);
			recipe.AddIngredient(ItemID.WoodBreastplate, 1);
			recipe.AddIngredient(ItemID.WoodGreaves, 1);
			recipe.AddIngredient(ItemID.WoodenArrow, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
