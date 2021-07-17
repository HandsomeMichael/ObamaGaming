using MonoMod.Cil;
using System;
using Terraria.Localization; 
using Terraria.Utilities;
using ObamaGaming.Items;
using ObamaGaming.Items.ModCross;
using ObamaGaming.Items.Weapon;
using ObamaGaming.Items.Ungun;
using ObamaGaming.Items.Material;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ObamaGaming
{
	public class ObamaGaming : Mod
	{
		class ObamaGlobalModNpc : GlobalNPC
		{
			public override void SetupShop(int type, Chest shop, ref int nextSlot) 
			{
				var modPbone = ModLoader.GetMod("PboneUtils");
				var fargoMod = ModLoader.GetMod("Fargowiltas");

				if (type == NPCID.GoblinTinkerer) 
				{
					shop.item[nextSlot].SetDefaults(ModContent.ItemType<ReforgeSword>());
					nextSlot++;
				}
				if (type == NPCID.Merchant) 
				{
					shop.item[nextSlot].SetDefaults(ModContent.ItemType<americaflag>());
					shop.item[nextSlot].shopCustomPrice = 60000;
					nextSlot++;
					if (fargoMod != null) {
						shop.item[nextSlot].SetDefaults(fargoMod.ItemType("RegalStatue"));
						shop.item[nextSlot].shopCustomPrice = 60000;
						nextSlot++;
					}
					if (fargoMod != null) {
						shop.item[nextSlot].SetDefaults(fargoMod.ItemType("SuperDummy"));
						shop.item[nextSlot].shopCustomPrice = 10000;
						nextSlot++;
					}
				}
				if (fargoMod != null) {
					if (type == fargoMod.NPCType("Mutant")) {
						shop.item[nextSlot].SetDefaults(fargoMod.ItemType("BoomShuriken"));
						shop.item[nextSlot].shopCustomPrice = 15000;
						nextSlot++;
						shop.item[nextSlot].SetDefaults(fargoMod.ItemType("MiniInstaBridge"));
						shop.item[nextSlot].shopCustomPrice = 15000;
						nextSlot++;
					}
				}
			}
			public override void NPCLoot(NPC npc) {
				//mod support
				Mod spiritMod = ModLoader.GetMod("SpiritMod");

				if (npc.boss)
				{
					if (ObamaConfig.Instance.AllowKingCoinBoss) {
						Item.NewItem(npc.getRect(), ModContent.ItemType<KingCoin>(), 1);
					}
					if (Main.rand.Next(90) == 0 && spiritMod != null) {
						Item.NewItem(npc.getRect(), ModContent.ItemType<RuneWizard1>());
					}
				}
				if (!npc.boss && npc.lifeMax > 1 && npc.damage > 0 && !npc.friendly && npc.value > 0f )
				{
					if (ObamaConfig.Instance.Allowunfinishgun && NPC.AnyNPCs(ModContent.NPCType<NPCs.Obama>())) {
						if (Main.rand.Next(150) == 0)
							Item.NewItem(npc.getRect(), ModContent.ItemType<unfinishgun1>());
						if (Main.rand.Next(150) == 0 && NPC.downedBoss3)
							Item.NewItem(npc.getRect(), ModContent.ItemType<unfinishgun2>());
						if (Main.rand.Next(150) == 0 && Main.hardMode)
							Item.NewItem(npc.getRect(), ModContent.ItemType<unfinishgun3>());
						if (Main.rand.Next(150) == 0)
							Item.NewItem(npc.getRect(), ModContent.ItemType<unfinishgun4>());
					}
					if (npc.position.Y > Main.rockLayer * 16.0) {
						if (Main.rand.Next(80) == 0 && spiritMod != null) {
							Item.NewItem(npc.getRect(), ModContent.ItemType<Adventurer1>());
						}
					}
				}
				//unfinished gun
			}
		}
		//public override void Load()
		//{
			//if (Main.netMode != NetmodeID.Server) {
				//Music Boxes
				//AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/Armageddon"), ItemType("NeonMusicBox"), TileType("NeonMusicBox"));
			//}
		//}
		public override void AddRecipes() //RECIPE EDITOR THINGY =====
		{
			//All mod support
			//finder = new RecipeFinder();
			//finder.AddRecipeGroup("IronBar"); this has been noted for later purposes
			//finder.AddTile(TileID.Anvils);
			//finder.AddIngredient(ItemID.Chain);
			//editor.AddIngredient(ModContent.ItemType<HallowedStaffHolder>(), 1);
			//editor.DeleteRecipe();
			// ================================================
			// Molten Recipe will be replaced By Dynamic Molten Bar
			RecipeFinder finder = new RecipeFinder();
			finder.SetResult(ItemID.Megashark, 1);
			foreach (Recipe recipe in finder.SearchRecipes())
				{
					RecipeEditor editor = new RecipeEditor(recipe);
					editor.AddIngredient(ModContent.ItemType<americaflag>(), 1);
				}
			
			ObamaRecipe.AddModSupport(this);
		}
		public override void AddRecipeGroups()
		{
			RecipeGroup basegroup(object GroupName, int[] Items) //Thank you spirit mod
			{
				string Name = "";
				switch(GroupName) 
				{
					case int i: //modcontent items
						Name += Lang.GetItemNameValue((int)GroupName);
						break;
					case short s: //vanilla item ids
						Name += Lang.GetItemNameValue((short)GroupName);
						break;
					default: //custom group names
						Name += GroupName.ToString();
						break;
				}

				return new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + Name, Items);
			}

			RecipeGroup.RegisterGroup("ObamaGaming:GoldBar", basegroup(ItemID.GoldBar, new int[]
			{
				ItemID.GoldBar,
				ItemID.PlatinumBar
			}));

			RecipeGroup.RegisterGroup("ObamaGaming:EvilHardMaterial", basegroup(ItemID.CursedFlame, new int[]
			{
				ItemID.CursedFlame,
				ItemID.Ichor
			}));

			RecipeGroup.RegisterGroup("ObamaGaming:EvilMaterial", basegroup(ItemID.ShadowScale, new int[]
			{
				ItemID.ShadowScale,
				ItemID.TissueSample
			}));

			RecipeGroup.RegisterGroup("ObamaGaming:SilverBar", basegroup(ItemID.SilverBar, new int[]
			{
				ItemID.SilverBar,
				ItemID.TungstenBar
			}));

			RecipeGroup.RegisterGroup("ObamaGaming:CopperBar", basegroup(" Legendary Bar", new int[]
			{
				ItemID.CopperBar,
				ItemID.TinBar
			}));

			RecipeGroup.RegisterGroup("ObamaGaming:EvilBar", basegroup(" Evil Bar", new int[]
			{
				ItemID.CrimtaneBar,
				ItemID.DemoniteBar
			}));

			RecipeGroup.RegisterGroup("ObamaGaming:SapphireStaffs", basegroup("Sapphire or Emerald Staff", new int[]
			{
				ItemID.SapphireStaff,
				ItemID.EmeraldStaff
			})); 
			
			RecipeGroup.RegisterGroup("ObamaGaming:RubyStaffs", basegroup("Ruby or Diamond Staff", new int[]
			{
				ItemID.RubyStaff,
				ItemID.DiamondStaff
			}));

			RecipeGroup.RegisterGroup("ObamaGaming:TitaniumBar", basegroup(" Titanium or Adamantite", new int[]
			{
				ItemID.TitaniumBar,
				ItemID.AdamantiteBar
			}));

			RecipeGroup.RegisterGroup("ObamaGaming:OrichalcumBar", basegroup(" OrichalCUM or Mythril Bar", new int[]
			{
				ItemID.OrichalcumBar,
				ItemID.MythrilBar
			}));
			RecipeGroup.RegisterGroup("ObamaGaming:HSoul", basegroup(" Hardmode Soul", new int[]
			{
				ItemID.SoulofLight,
				ItemID.SoulofNight
			}));
			RecipeGroup.RegisterGroup("ObamaGaming:MSoul", basegroup(" Mech Soul", new int[]
			{
				ItemID.SoulofMight,
				ItemID.SoulofFright,
				ItemID.SoulofSight
			}));
			RecipeGroup.RegisterGroup("ObamaGaming:Fragment", basegroup(" Lunar Fragment", new int[]
			{
				ItemID.FragmentNebula,
				ItemID.FragmentStardust,
				ItemID.FragmentVortex,
				ItemID.FragmentSolar
			}));
			RecipeGroup.RegisterGroup("ObamaGaming:Ruby", basegroup(" Ruby Or Diamond Gem", new int[]
			{
				ItemID.Diamond,
				ItemID.Ruby
			}));
			RecipeGroup.RegisterGroup("ObamaGaming:Gem", basegroup(" Gem", new int[]
			{
				ItemID.Topaz,
				ItemID.Amethyst,
				ItemID.Sapphire,
				ItemID.Emerald,
				ItemID.Diamond,
				ItemID.Ruby
			}));
		}
	}
}