using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using ObamaGaming;

namespace ObamaGaming.Items
{
	public class Testitem : ModItem
	{
		public override string Texture => "Terraria/Item_" + Main.rand.Next(1, ItemID.Count);
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Test");
			Tooltip.SetDefault("This is an item test");
		}

		public override void SetDefaults() 
		{
            item.width = 14;
            item.height = 14;
            item.rare = 0;
            item.value = 69;
		}
		public override bool CanRightClick() => true;
		public override void RightClick(Player player) {
			CombatText.NewText(player.getRect(), Color.White, ObamaConfig.Instance.Password);
			//CombatText.NewText(player.getRect(), Color.White, ObamaConfig.Instance.BlacklistShortsword);
		}
		public override bool CanUseItem (Player player) {
			CombatText.NewText(player.getRect(), Color.White, ObamaConfig.Instance.Password);
			return base.CanUseItem(player);
		}
	}
}