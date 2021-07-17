using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using ObamaGaming;
using Terraria;
using Terraria.Utilities;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace ObamaGaming.Items.ModCross.PbonePlus
{
	public class EndlessIchlorophyte : ModItem
	{
		public override bool CloneNewInstances => true;

		public int beh = 1;
		public int bullettype = 1;
		public int timer = 0;
		public int rightclickupdate;
		public string stringsus = "time";

		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Endless Ichorlophyte Bullet");
			Tooltip.SetDefault("<right> in inventory to change behaviour");
		}

		public override void SetDefaults() {
			item.damage = 10;
			item.ranged = true;
			item.width = 8;
			item.height = 8;
			item.consumable = false;
			item.knockBack = 1.5f;
			item.value = 10;
			item.rare = -12;
			item.shoot = ProjectileID.None;
			item.shootSpeed = 16f;
			item.ammo = AmmoID.Bullet;
		}
		public override bool CanRightClick() => true;

		public override void RightClick(Player player) {
			beh++;
			rightclickupdate = 1;
			timer = 0;
			if (beh > 4){
				beh = 1;
			}
		}

		public override bool ConsumeItem(Player player) => false;

		public override void UpdateInventory(Player player)
		{
			//display hook
			timer++;
			if (beh == 1)
			{
				stringsus = "quarter of a second";
				bullettype++;
				if (timer > 14) {
					bullettype++;
					timer = 0;
				}
			}
			if (beh == 2) {
				stringsus = "half a second";
				if (timer > 29) {
					bullettype++;
					timer = 0;
				}
			}		
			if (beh == 3) {
				stringsus = "second";
				if (timer > 59) {
					bullettype++;
					timer = 0;
				}
			}
			if (beh == 4) {
				stringsus = "5 second";
				if (timer > 299) {
					bullettype++;
					timer = 0;
				}
			}
			//Bullet changes
			if (bullettype == 1) {
				item.damage = 10;
				item.shoot = ProjectileID.ChlorophyteBullet;
			}
			if (bullettype == 2) {
				item.damage = 13;
				item.shoot = ProjectileID.IchorBullet;
			}
			if (bullettype > 2) {
				bullettype = 1;
			}
			//if (timer == 0) {
				//CombatText.NewText(player.getRect(), Color.Lime, timer);
			//}
			if (rightclickupdate == 1) {
				CombatText.NewText(player.getRect(), Color.Cyan, "Changes Bullet Every "+stringsus);
				rightclickupdate = 0;
			}
		}
		public override void ModifyTooltips(List<TooltipLine> tooltips) {
			var display1 = new TooltipLine(mod, "pbone:display1", $"Changes Bullet Every "+stringsus);
			display1.overrideColor = Color.Cyan;
			var displaydebug = new TooltipLine(mod, "pbone:displaydebug", "time"+timer+" bullet type "+bullettype+" i "+item.shoot);
			displaydebug.overrideColor = Color.Cyan;
			tooltips.Add(display1);
			//tooltips.Add(displaydebug);
		}

		public override void AddRecipes() {
			// Modding
			Mod pboneMod = ModLoader.GetMod("PboneUtils");
			Mod fargoMod = ModLoader.GetMod("Fargowiltas");

			ModRecipe recipe = new ModRecipe(mod);
			if (pboneMod != null) {
				recipe.AddIngredient(pboneMod.ItemType("EndlessIchorBullet"));
				recipe.AddIngredient(pboneMod.ItemType("EndlessChlorophyteBullet"));
			}
			else {
				recipe.AddIngredient(ItemID.ChlorophyteBullet, 3996);
				recipe.AddIngredient(ItemID.IchorBullet, 3996);
			}
			recipe.AddIngredient(ItemID.SoulofLight, 3);
			recipe.AddIngredient(ItemID.SoulofNight, 3);
			recipe.AddIngredient(ItemID.HallowedBar, 5);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();

			if (fargoMod != null) {
				recipe = new ModRecipe(mod);
				recipe.AddIngredient(fargoMod.ItemType("ChlorophytePouch"));
				recipe.AddIngredient(fargoMod.ItemType("IchorPouch"));
				recipe.AddIngredient(ItemID.SoulofLight, 3);
				recipe.AddIngredient(ItemID.SoulofNight, 3);
				recipe.AddIngredient(ItemID.HallowedBar, 5);
				recipe.AddTile(TileID.MythrilAnvil);
				recipe.SetResult(this);
				recipe.AddRecipe();
			}
		}
	}
}
