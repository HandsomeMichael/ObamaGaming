using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ObamaGaming.Items
{
	public class Nocraft : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Unobtainable");
			Tooltip.SetDefault("this item is Unobtainable.");
		}

		public override void SetDefaults() 
		{
            item.width = 14;
            item.height = 14;
            item.rare = ItemRarityID.Red;
            item.value = 69;
		}
	}
}