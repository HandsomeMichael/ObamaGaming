using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ObamaGaming.Items.Heads
{
	public class ObamaHead : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Obama Head");
			Tooltip.SetDefault("Causes great political damage."+
			$"\nThis item will problaby attract someone to move in your town [i:{item.type}]");
		}

		public override void SetDefaults() 
		{
            item.width = 14;
            item.height = 14;
            item.rare = -12;
            item.value = 69;
			item.scale = 0.7f;
		}
	}
}