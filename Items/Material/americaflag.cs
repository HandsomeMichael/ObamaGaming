using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ObamaGaming.Items.Material
{
	public class americaflag : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Unique Flag");
			Tooltip.SetDefault($"[i:521] Gathered from far away land [i:521]"+
			$"\nThis item will problaby attract someone to move in your town [i:{item.type}]");
		}

		public override void SetDefaults() 
		{
            item.width = 14;
            item.height = 14;
            item.rare = -12;
		}
	}
}