using Terraria.ID;
using System;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;

namespace ObamaGaming.Items.ModCross.FargoSoul
{
	public class Champer : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Champer Enchantment"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Double damage but no more crits"+
			"\n( Summoner does not get the bonus )");
		}

		public override void SetDefaults() {
			item.width = 34;
			item.height = 34;
			item.accessory = true;
			item.value = 150000;
			item.rare = -12;
			item.expert = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.meleeCrit = 0;
			player.rangedCrit = 0;
			player.magicCrit = 0;
			player.rangedDamage += 1f;
			player.meleeDamage += 1f;
			player.magicDamage += 1f;
		}
	}
	public class RandomSoul : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Random Soul"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("25% increased all damage"+
			"\nWhen equipped your projectile will be randomized"+
			"\nWhen equipped your projectile inflict random buff"+
			"\nWhen equipped your melee weapon inflict random buff"+
			"\nGetting Hit By Npc Summon Random Projectile");
		}

		public override void SetDefaults() {
			item.width = 34;
			item.height = 34;
			item.accessory = true;
			item.value = 150000;
			item.rare = -12;
			item.expert = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.GetModPlayer<ObamaPlayer>().fargorandomsoul = true;
			player.allDamage += 0.25f;
			item.defense = Main.rand.Next(1, 20);
			player.statDefense += Main.rand.Next(1, 20);
		}
	}
	public class sansfrag : ModItem
	{
		public override void SetStaticDefaults()
		{
			string[] names = { "Sans Fragment", "Golem Fragment", "Eternity Golem Fragment", "Eternity Sans Fragment", "White Golem Fragment", "Coom Golem Fragment" };
			DisplayName.SetDefault(Main.rand.Next(names));
			Tooltip.SetDefault("used to craft random item");
		}

		public override void SetDefaults() {
			item.width = 34;
			item.height = 34;
			item.value = 150000;
			item.rare = -12;
			item.maxStack = 69;
			item.expert = true;
		}
	}
}