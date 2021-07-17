using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;


namespace ObamaGaming.Items.lootbox
{
	public class boxgold : ModItem
    {
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Coin Loot Box");
			Tooltip.SetDefault("<right> to open"+
			$"\nContain Some Coins [i:71][i:72][i:73]");
		}
		public override void SetDefaults() 
		{
			item.width = 32;
			item.height = 38;
			item.maxStack = 5;
			item.rare = 1;
		}
		public override bool CanRightClick() => true;
		public override void RightClick(Player player) {
			player.QuickSpawnItem(ItemID.CopperCoin, Main.rand.Next(1, 101));
			player.QuickSpawnItem(ItemID.SilverCoin, Main.rand.Next(1, 51));
			if (Main.rand.Next(7) == 0) {player.QuickSpawnItem(ItemID.SilverCoin, Main.rand.Next(1, 2));}
		}
	}
	public class boxhmgold : ModItem
    {
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Hardmode Coin Loot Box");
			Tooltip.SetDefault("<right> to open"+
			$"\nContain Some Coins [i:72][i:73]");
		}
		public override void SetDefaults() 
		{
			item.width = 32;
			item.height = 38;
			item.maxStack = 5;
			item.rare = 6;
		}
		public override bool CanRightClick() => true;
		public override void RightClick(Player player) {
			player.QuickSpawnItem(ItemID.SilverCoin, Main.rand.Next(51, 101));
			player.QuickSpawnItem(ItemID.GoldCoin, Main.rand.Next(5, 16));
		}
	}
	public class boxlife : ModItem
    {
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("life Loot Box");
			Tooltip.SetDefault("<right> to open"+
			$"\nContain Some Life Crystal [i:29]");
		}
		public override void SetDefaults() 
		{
			item.width = 32;
			item.height = 38;
			item.maxStack = 5;
			item.rare = 2;
		}
		public override bool CanRightClick() => true;
		public override void RightClick(Player player) {
			player.QuickSpawnItem(ItemID.LifeCrystal, Main.rand.Next(1, 4));
		}
	}
	public class boxhmlife : ModItem
    {
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("life Fruit Loot Box");
			Tooltip.SetDefault("<right> to open"+
			$"\nContain Some Life Fruit [i:1291]");
		}
		public override void SetDefaults() 
		{
			item.width = 32;
			item.height = 38;
			item.maxStack = 5;
			item.rare = 7;
		}
		public override bool CanRightClick() => true;
		public override void RightClick(Player player) {
			player.QuickSpawnItem(ItemID.LifeFruit, Main.rand.Next(1, 4));
		}
	}
	public class boxstart : ModItem
    {
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Starting Loot Box");
			Tooltip.SetDefault("<right> to open"+
			$"\nContain Some Starting Item [i:21][i:29][i:28][i:50][i:{ItemID.SwiftnessPotion}]"+
			"\nChange Copper Tools To Silver [i:21]");
		}
		public override void SetDefaults() 
		{
			item.width = 32;
			item.height = 38;
			item.maxStack = 5;
			item.rare = 1;
		}
		public override bool CanRightClick() => true;
		public override void RightClick(Player player) {
			if (player.HasItem(ItemID.CopperAxe) && player.HasItem(ItemID.CopperPickaxe) && player.HasItem(ItemID.CopperShortsword)) {
				int a = player.FindItem(ItemID.CopperShortsword);
				int b = player.FindItem(ItemID.CopperPickaxe);
				int c = player.FindItem(ItemID.CopperAxe);
				player.inventory[a].TurnToAir();
				player.inventory[b].TurnToAir();
				player.inventory[c].TurnToAir();
			}
			if (player.HasItem(ItemID.SilverShortsword)) {player.QuickSpawnItem(ItemID.SilverShortsword);}
			if (player.HasItem(ItemID.SilverPickaxe)) {player.QuickSpawnItem(ItemID.SilverPickaxe);}
			if (player.HasItem(ItemID.SilverAxe)) {player.QuickSpawnItem(ItemID.SilverAxe);}
			if (player.HasItem(ItemID.SilverHammer)) {player.QuickSpawnItem(ItemID.SilverHammer);}
			if (player.HasItem(ItemID.SilverBow)) {player.QuickSpawnItem(ItemID.SilverBow);}
			player.QuickSpawnItem(ItemID.LifeCrystal, 3);
			player.QuickSpawnItem(ItemID.ManaCrystal, 3);
			player.QuickSpawnItem(ItemID.WoodenArrow, 150);
			player.QuickSpawnItem(ItemID.LesserHealingPotion, 10);
			player.QuickSpawnItem(ItemID.LesserManaPotion, 10);
			player.QuickSpawnItem(ItemID.MagicMirror);
			player.QuickSpawnItem(ItemID.Aglet);
			player.QuickSpawnItem(ItemID.Wood, 150);
			player.QuickSpawnItem(ItemID.Gel, 25);
			player.AddBuff(BuffID.Swiftness, 18000);
			player.AddBuff(BuffID.Regeneration, 18000);
			player.AddBuff(BuffID.Ironskin, 18000);
			player.AddBuff(BuffID.Mining, 18000);
			string[] say = { "Subscribe To Pewdiepie", "Subscribe To ChippyCouch", "Subscribe To Pedguin", "Subscribe To Ymir", "Subscribe To Obama"};
			Main.NewText(Main.rand.Next(say), Color.Pink);
		}
	}
	public class boxstar_12 : ModItem
    {
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Star Loot Box");
			Tooltip.SetDefault("<right> to open"+
			$"\nContain Some Fallen Star [i:75]");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 12));
		}
		public override void SetDefaults() 
		{
			item.width = 32;
			item.height = 38;
			item.maxStack = 5;
			item.rare = 1;
		}
		public override bool CanRightClick() => true;
		public override void RightClick(Player player) {
			player.QuickSpawnItem(ItemID.FallenStar, Main.rand.Next(3, 11));
		}
	}
	public class boxhmsoul : ModItem
    {
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Soul Loot Box");
			Tooltip.SetDefault("<right> to open"+
			$"\nContain Some Souls [i:520][i:521]");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 4));
		}
		public override void SetDefaults() 
		{
			item.width = 32;
			item.height = 38;
			item.maxStack = 5;
			item.rare = 6;
		}
		public override bool CanRightClick() => true;
		public override void RightClick(Player player) {
			player.QuickSpawnItem(ItemID.SoulofLight, Main.rand.Next(3, 7));
			player.QuickSpawnItem(ItemID.SoulofNight, Main.rand.Next(3, 7));
			if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3) {
				player.QuickSpawnItem(ItemID.SoulofFright, Main.rand.Next(1, 5));
				player.QuickSpawnItem(ItemID.SoulofMight, Main.rand.Next(1, 5));
				player.QuickSpawnItem(ItemID.SoulofSight, Main.rand.Next(1, 5));
			}
		}
	}
	public class boxore : ModItem
    {
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Ore Loot Box");
			Tooltip.SetDefault("<right> to open"+
			$"\nContain Some Ore [i:{ItemID.CopperOre}][i:{ItemID.IronOre}][i:{ItemID.TungstenOre}][i:{ItemID.GoldOre}]");
		}
		public override void SetDefaults() 
		{
			item.width = 32;
			item.height = 38;
			item.maxStack = 5;
			item.rare = 1;
		}
		public override bool CanRightClick() => true;
		public override void RightClick(Player player) {
			int choice = Main.rand.Next(7);
			if (choice == 0) {player.QuickSpawnItem(ItemID.CopperOre, Main.rand.Next(5, 12));}
			if (choice == 1) {player.QuickSpawnItem(ItemID.TinOre, Main.rand.Next(3, 11));}
			if (choice == 2) {player.QuickSpawnItem(ItemID.IronOre, Main.rand.Next(3, 10));}
			if (choice == 3) {player.QuickSpawnItem(ItemID.LeadOre, Main.rand.Next(3, 10));}
			if (choice == 4) {player.QuickSpawnItem(ItemID.TungstenOre, Main.rand.Next(3, 9));}
			if (choice == 5) {player.QuickSpawnItem(ItemID.SilverOre, Main.rand.Next(3, 9));}
			if (choice == 6) {player.QuickSpawnItem(ItemID.GoldOre, Main.rand.Next(3, 7));}
			if (choice == 7) {player.QuickSpawnItem(ItemID.PlatinumOre, Main.rand.Next(3, 7));}
		}
	}
	public class boxhmore : ModItem
    {
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Hardmode Ore Loot Box");
			Tooltip.SetDefault("<right> to open"+
			$"\nContain Some Hardmode Ore [i:{ItemID.PalladiumOre}][i:{ItemID.IronOre}][i:{ItemID.TungstenOre}][i:{ItemID.GoldOre}]");
		}
		public override void SetDefaults() 
		{
			item.width = 32;
			item.height = 38;
			item.maxStack = 5;
			item.rare = 6;
		}
		public override bool CanRightClick() => true;
		public override void RightClick(Player player) {
			int choice = Main.rand.Next(5);
			if (choice == 0) {player.QuickSpawnItem(ItemID.PalladiumOre, Main.rand.Next(5, 12));}
			if (choice == 1) {player.QuickSpawnItem(ItemID.CobaltOre, Main.rand.Next(3, 11));}
			if (choice == 2) {player.QuickSpawnItem(ItemID.OrichalcumOre, Main.rand.Next(3, 10));}
			if (choice == 3) {player.QuickSpawnItem(ItemID.MythrilOre, Main.rand.Next(3, 10));}
			if (choice == 4) {player.QuickSpawnItem(ItemID.TitaniumOre, Main.rand.Next(3, 5));}
			if (choice == 5) {player.QuickSpawnItem(ItemID.AdamantiteOre, Main.rand.Next(3, 5));}
			if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
				if (Main.rand.Next(20) == 0) {player.QuickSpawnItem(ItemID.ChlorophyteOre, Main.rand.Next(3, 10));}
		}
	}
	public class boxjungle : ModItem
    {
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Jungle Loot Box");
			Tooltip.SetDefault("<right> to open"+
			$"\nContain Some Jungle Item [i:331][i:209][i:210]");
		}
		public override void SetDefaults() 
		{
			item.width = 32;
			item.height = 38;
			item.maxStack = 5;
			item.rare = 3;
		}
		public override bool CanRightClick() => true;
		public override void RightClick(Player player) {
			if (Main.rand.Next(2) == 0)
				player.QuickSpawnItem(ItemID.JungleSpores, Main.rand.Next(1, 4));
			if (Main.rand.Next(2) == 0)
				player.QuickSpawnItem(ItemID.Vine, Main.rand.Next(1, 4));
			player.QuickSpawnItem(ItemID.Stinger, Main.rand.Next(1, 4));
		}
	}
	public class boxpotion : ModItem
    {
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Potion Loot Box");
			Tooltip.SetDefault("<right> to open"+
			$"\nContain Some Potion [i:288][i:289][i:290][i:291][i:292][i:293][i:294] And Many More +");
		}
		public override void SetDefaults() 
		{
			item.width = 32;
			item.height = 38;
			item.maxStack = 5;
			item.rare = 2;
		}
		public override bool CanRightClick() => true;
		public override void RightClick(Player player) {
			int choice = Main.rand.Next(16);
			if ((choice == 0)) {player.QuickSpawnItem(ItemID.SwiftnessPotion, 1);}
			if ((choice == 1)) {player.QuickSpawnItem(ItemID.MiningPotion, 1);}
			if ((choice == 2)) {player.QuickSpawnItem(ItemID.IronskinPotion, 1);}
			if ((choice == 3)) {player.QuickSpawnItem(ItemID.RegenerationPotion, 1);}
			if ((choice == 4)) {player.QuickSpawnItem(ItemID.ObsidianSkinPotion, 1);}
			if ((choice == 5)) {player.QuickSpawnItem(ItemID.RagePotion, 1);}
			if ((choice == 6)) {player.QuickSpawnItem(ItemID.CratePotion, 1);}
			if ((choice == 7)) {player.QuickSpawnItem(ItemID.GillsPotion, 1);}
			if ((choice == 8)) {player.QuickSpawnItem(ItemID.ShinePotion, 1);}
			if ((choice == 9)) {player.QuickSpawnItem(ItemID.SonarPotion, 1);}
			if ((choice == 10)) {player.QuickSpawnItem(ItemID.StinkPotion, 1);}
			if ((choice == 11)) {player.QuickSpawnItem(ItemID.WrathPotion, 1);}
			if ((choice == 12)) {player.QuickSpawnItem(ItemID.BattlePotion, 1);}
			if ((choice == 13)) {player.QuickSpawnItem(ItemID.ThornsPotion, 1);}
			if ((choice == 14)) {player.QuickSpawnItem(ItemID.ArcheryPotion, 1);}
			if ((choice == 15)) {player.QuickSpawnItem(ItemID.CalmingPotion, 1);}
			if ((choice == 16)) {player.QuickSpawnItem(ItemID.FlipperPotion, 1);}
		}
	}
}