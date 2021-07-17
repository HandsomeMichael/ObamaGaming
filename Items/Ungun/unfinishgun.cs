using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;


namespace ObamaGaming.Items.Ungun
{
	public abstract class finishitem : ModItem
    {
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Unfinished Gun");
			Tooltip.SetDefault("You can talk to obama to finish this");
		}
		public override void SetDefaults() 
		{
			item.width = 26;
			item.height = 26;
			//item.maxStack = 5;
			item.rare = 5;
		}
	}
	// minecraft is the best game 10 / 10 would recomend gud english moment
	public class unfinishgun1 : finishitem {}
	public class unfinishgun2 : finishitem {}
	public class unfinishgun3 : finishitem {}
	public class unfinishgun4 : finishitem {}
	public class unfinishgun5 : finishitem {}
	public class unfinishgun6 : finishitem {}
}