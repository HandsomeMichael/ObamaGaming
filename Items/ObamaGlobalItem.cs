using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;
using Terraria.ID;
using ObamaGaming;

namespace ObamaGaming.Items
{
	public class ObamaGlobalItem : GlobalItem
	{
		public override bool CloneNewInstances => true;
		public override bool InstancePerEntity => true;
		public bool isNormalShrtswrd = false;
		//public override void SetDefaults(Item item) {}
		public override void UpdateInventory(Item item, Player player) {
			if (item.useStyle == 3 && ObamaConfig.Instance.AllowShortswordAlt) {isNormalShrtswrd = true;}
			if (!ObamaConfig.Instance.AllowShortswordAlt && isNormalShrtswrd) {isNormalShrtswrd = false;}
			foreach (ItemDefinition itemDefinition in ObamaConfig.Instance.BlacklistShortsword) {
                if (itemDefinition.Type == item.type){isNormalShrtswrd = false;}
            }
			//Update done one inventory so its can be quickly changes
		}
		public override void HoldItem(Item item, Player player)
		{
			ObamaPlayer p = (ObamaPlayer)player.GetModPlayer(mod, "ObamaPlayer");
			p.PlayerHold = item.type;
		}
		public override bool AltFunctionUse(Item item, Player player) {
			if (isNormalShrtswrd) {return true;}
			else {return false;}
		}
		public override bool UseItem(Item item, Player player)
		{
			if (isNormalShrtswrd) { 
				if(player.altFunctionUse == 2) { item.useStyle = 1;} 
				else {item.useStyle = 3;}
			}
			return base.CanUseItem(item, player);
		}
	}
}