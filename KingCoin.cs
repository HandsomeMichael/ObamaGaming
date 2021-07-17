using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;


namespace ObamaGaming.Items
{
	public class KingCoin : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("King Coin");
			Tooltip.SetDefault("Used To Buy And Upgrade Stuff"+
			"\n<right> In Inventory To Turn Into Gold Coin");
			ItemID.Sets.ItemNoGravity[item.type] = true;
		}

		public override void SetDefaults() 
		{
			item.width = 26;
			item.height = 26;
			item.rare = -12;
			item.maxStack = 100;
		}
		public override bool CanRightClick() {
			return true;
		}

		public override void RightClick(Player player) {
			if (Main.expertMode)
			{
				player.QuickSpawnItem(ItemID.GoldCoin, Main.rand.Next(4, 6));
			}
			else
			{
				player.QuickSpawnItem(ItemID.GoldCoin, Main.rand.Next(2, 4));
			}
		}
	}
}