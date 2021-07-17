using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;


namespace ObamaGaming.Items.Material
{
	public class obamium : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Obamium");
			Tooltip.SetDefault("Used To Craft Eternal Item"+
			"\n<right> the item in inventory to break"+
			"\nbreaking the item will give you shatered obamium"+
			$"\n[i:{item.type}] One Of To Eternal Power [i:{item.type}]");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 50));
			ItemID.Sets.ItemIconPulse[item.type] = true;
			ItemID.Sets.ItemNoGravity[item.type] = true;
		}

		public override void SetDefaults() 
		{
            Item refItem = new Item();
			refItem.SetDefaults(ItemID.SoulofSight);
			item.width = refItem.width;
			item.height = refItem.height;
			item.maxStack = 999;
			item.rare = -12;
		}
	}
}