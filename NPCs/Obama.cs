using System;
using ObamaGaming.Dusts;
using ObamaGaming.Items;
using ObamaGaming.Items.Heads;
using ObamaGaming.Items.Material;
using ObamaGaming.Items.Ungun;
using ObamaGaming.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ObamaGaming.NPCs
{
	// [AutoloadHead] and npc.townNPC are extremely important and absolutely both necessary for any Town NPC to work at all.
	[AutoloadHead]
	public class Obama : ModNPC
	{
		public string originality = "Nothing here is original , expect less from lazy people";
		public override string Texture => "ObamaGaming/NPCs/ObamaRework";

		//public override string[] AltTextures => new[] { "ExampleMod/NPCs/ExamplePerson_Alt_1" };

		public override bool Autoload(ref string name) {
			name = "Obama";
			return mod.Properties.Autoload;
		}

		public override void SetStaticDefaults() {
			// DisplayName automatically assigned from .lang files, but the commented line below is the normal approach.
			DisplayName.SetDefault("Obama");
			Main.npcFrameCount[npc.type] = 25;
			NPCID.Sets.ExtraFramesCount[npc.type] = 9;
			NPCID.Sets.AttackFrameCount[npc.type] = 4;
			NPCID.Sets.DangerDetectRange[npc.type] = 700;
			NPCID.Sets.AttackType[npc.type] = 0;
			NPCID.Sets.AttackTime[npc.type] = 90;
			NPCID.Sets.AttackAverageChance[npc.type] = 30;
			NPCID.Sets.HatOffsetY[npc.type] = 4;
		}

		public override void SetDefaults() {
			npc.townNPC = true;
			npc.friendly = true;
			npc.width = 18;
			npc.height = 40;
			npc.aiStyle = 7;
			npc.damage = 10;
			npc.defense = 15;
			npc.lifeMax = 250;
			npc.HitSound = mod.GetLegacySoundSlot(SoundType.NPCHit, "Sounds/NPCHit/obamahurt2");
			npc.DeathSound = SoundID.NPCDeath1;
			npc.knockBackResist = 0.5f;
			animationType = NPCID.Guide;
		}
		public override void AI() {
			npc.HitSound = mod.GetLegacySoundSlot(SoundType.NPCHit, "Sounds/NPCHit/obamahurt"+Main.rand.Next(1, 4));
		}

		public override void HitEffect(int hitDirection, double damage) {
			int num = npc.life > 0 ? 1 : 5;
			for (int k = 0; k < num; k++) {
				Dust.NewDust(npc.position, npc.width, npc.height, ModContent.DustType<Sparkle>());
			}
			//string[] hurtoof = { "oof", "aww", "ouch", "that hurt", "ugh"};
			//CombatText.NewText(npc.getRect(), Color.White, Main.rand.Next(hurtoof));
		}
		public override bool CanTownNPCSpawn(int numTownNPCs, int money) {
			for (int k = 0; k < 255; k++) {
				Player player = Main.player[k];
				if (!player.active) {
					continue;
				}

				foreach (Item item in player.inventory) {
					if (item.type == ModContent.ItemType<americaflag>()) {
						return true;
					}//ModContent.ItemType<ExampleItem>()
				}
			}
			return false;
		}

		// Example Person needs a house built out of ExampleMod tiles. You can delete this whole method in your townNPC for the regular house conditions.
		/*public override bool CheckConditions(int left, int right, int top, int bottom) {
			int score = 0;
			for (int x = left; x <= right; x++) {
				for (int y = top; y <= bottom; y++) {
					int type = Main.tile[x, y].type;
					if (type == ModContent.TileType<ExampleBlock>() || type == ModContent.TileType<ExampleChair>() || type == ModContent.TileType<ExampleWorkbench>() || type == ModContent.TileType<ExampleBed>() || type == ModContent.TileType<ExampleDoorOpen>() || type == ModContent.TileType<ExampleDoorClosed>()) {
						score++;
					}
					if (Main.tile[x, y].wall == ModContent.WallType<ExampleWall>()) {
						score++;
					}
				}
			}
			return score >= (right - left) * (bottom - top) / 2;
		}*/

		public override string TownNPCName() {
			switch (WorldGen.genRand.Next(4)) {
				case 0:
					return "Handsome Obama";
				case 1:
					return "Edgy Obama";
				case 2:
					return "Politic Obama";
				default:
					return "Obama";
			}
		}

		public override void FindFrame(int frameHeight) {
			/*npc.frame.Width = 40;
			if (((int)Main.time / 10) % 2 == 0)
			{
				npc.frame.X = 40;
			}
			else
			{
				npc.frame.X = 0;
			}*/
		}

		public override string GetChat() {
			int Guide = NPC.FindFirstNPC(NPCID.Guide);
			if (Guide >= 0 && Main.rand.NextBool(4)) {//obamaguide
				Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/obamaguide").WithVolume(.7f), (int)npc.position.X, (int)npc.position.Y);
				return "I want to erase someone";
			} 
			switch (Main.rand.Next(9)) {
				case 0:
					{
					Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/obamagameng").WithVolume(.7f), (int)npc.position.X, (int)npc.position.Y);
					return "As an expert gamer , iam also have epic gaming chair with a extending feature.";
					}
				case 1:
					{
					Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/obamavbuck").WithVolume(.7f), (int)npc.position.X, (int)npc.position.Y);
					return "Vote me for free V-bucks for everyone in this town.";
					}
				case 2:// The Obama Upgrade
					{
						// obamafinish like the angler quest
						Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/obamafinish").WithVolume(.7f), (int)npc.position.X, (int)npc.position.Y);
						Main.npcChatCornerItem = ModContent.ItemType<Items.Material.americaflag>();
						return $"Hey, if you find a unfinished item. I can finish that for 1 [i:{ModContent.ItemType<Items.KingCoin>()}]King Coin Each";
					}
				case 3:
					{
						Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/obamadebate").WithVolume(.7f), (int)npc.position.X, (int)npc.position.Y);
						return "There is a secret political debate underground, Maybe you can find G-Fuel there";
					}
				case 4:
					{
						Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/obamatown").WithVolume(.7f), (int)npc.position.X, (int)npc.position.Y);				
						return "I want to became the leader of this town";
					}
				case 5:
					{
						Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/obamafeature").WithVolume(.7f), (int)npc.position.X, (int)npc.position.Y);				
						return "The feature is real";
					}
				case 6:
					{
						Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/obamaweather").WithVolume(.7f), (int)npc.position.X, (int)npc.position.Y);				
						return "The weather is pretty nice.";
					}
				case 7:
					{
						Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/obamacoin").WithVolume(.7f), (int)npc.position.X, (int)npc.position.Y);				
						return $"You can get [i:{ModContent.ItemType<Items.KingCoin>()}] King Coin From Killing Bosses.";
					}
				default:
					{
						Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/obamadark").WithVolume(.7f), (int)npc.position.X, (int)npc.position.Y);
						return "My existance is just pure darkness.";
					}
			}
		}
		public override void SetChatButtons(ref string button, ref string button2) {
			button = Language.GetTextValue("LegacyInterface.28");
			button2 = "lol";
			if (Main.LocalPlayer.HasItem(ModContent.ItemType<unfinishgun1>()) ||
			 Main.LocalPlayer.HasItem(ModContent.ItemType<unfinishgun2>()) ||
			 Main.LocalPlayer.HasItem(ModContent.ItemType<unfinishgun3>()))
			{
				button2 = $"Finish Gun ( 1 King Coin)";
			}
		}

		public override void OnChatButtonClicked(bool firstButton, ref bool shop) {
			if (firstButton) {
				shop = true;
			}
			else {
				int KingCoinLeft = 0;
				int payment = Main.LocalPlayer.FindItem(ModContent.ItemType<Items.KingCoin>());

				foreach(var item in Main.LocalPlayer.inventory)
				{
    				if(item.type == ModContent.ItemType<Items.KingCoin>())
        				KingCoinLeft += item.stack;
				}
				if (Main.LocalPlayer.HasItem(ModContent.ItemType<unfinishgun1>()))
				{
					if (KingCoinLeft > 0) {
						Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/obamapay").WithVolume(.7f), (int)npc.position.X, (int)npc.position.Y);
						Main.PlaySound(SoundID.Item37); // Reforge/Anvil sound
						Main.npcChatText = $"I have finished your stuff , dont forget to vote me as extra payment ! ";
						int obamafix1 = Main.LocalPlayer.FindItem(ModContent.ItemType<unfinishgun1>());
						foreach(var item in Main.LocalPlayer.inventory)
						{
    						if(item.type == ModContent.ItemType<Items.KingCoin>()) {
								if (item.stack > 1) {
									item.stack -= 1;
								}
								else {
									Main.LocalPlayer.inventory[payment].TurnToAir();
								}
							}
							if(item.type == ModContent.ItemType<unfinishgun1>()) {
								if (item.stack > 1) {
									item.stack -= 1;
								}
								else {
									Main.LocalPlayer.inventory[obamafix1].TurnToAir();
								}
							}
						}
						Main.LocalPlayer.QuickSpawnItem(ItemID.Minishark);
						return;
					}
					else {
						Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/obamanomoney").WithVolume(.7f), (int)npc.position.X, (int)npc.position.Y);
						Main.npcChatText = $"Sorry link, I can’t give credit, Come back when you are a little richer ( Need 1 [i:{ModContent.ItemType<Items.KingCoin>()}] King Coin )";
					}
				}
				if (Main.LocalPlayer.HasItem(ModContent.ItemType<unfinishgun2>()))
				{
					if (KingCoinLeft > 0) {
						Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/obamapay").WithVolume(.7f), (int)npc.position.X, (int)npc.position.Y);
						Main.PlaySound(SoundID.Item37); // Reforge/Anvil sound
						Main.npcChatText = $"I have finished your stuff , dont forget to vote me as extra payment ! ";
						int obamafix1 = Main.LocalPlayer.FindItem(ModContent.ItemType<unfinishgun2>());
						foreach(var item in Main.LocalPlayer.inventory)
						{
    						if(item.type == ModContent.ItemType<Items.KingCoin>()) {
								if (item.stack > 1) {
									item.stack -= 1;
								}
								else {
									Main.LocalPlayer.inventory[payment].TurnToAir();
								}
							}
							if(item.type == ModContent.ItemType<unfinishgun2>()) {
								if (item.stack > 1) {
									item.stack -= 1;
								}
								else {
									Main.LocalPlayer.inventory[obamafix1].TurnToAir();
								}
							}
						}
						Main.LocalPlayer.QuickSpawnItem(ItemID.Handgun);
						return;
					}
					else {
						Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/obamanomoney").WithVolume(.7f), (int)npc.position.X, (int)npc.position.Y);
						Main.npcChatText = $"Sorry link, I can’t give credit, Come back when you are a little richer ( Need 1 [i:{ModContent.ItemType<Items.KingCoin>()}] King Coin )";
					}
				}
				if (Main.LocalPlayer.HasItem(ModContent.ItemType<unfinishgun3>()))
				{
					if (KingCoinLeft > 0) {
						Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/obamapay").WithVolume(.7f), (int)npc.position.X, (int)npc.position.Y);
						Main.PlaySound(SoundID.Item37); // Reforge/Anvil sound
						Main.npcChatText = $"I have finished your stuff , dont forget to vote me as extra payment ! ";
						int obamafix1 = Main.LocalPlayer.FindItem(ModContent.ItemType<unfinishgun3>());
						foreach(var item in Main.LocalPlayer.inventory)
						{
    						if(item.type == ModContent.ItemType<Items.KingCoin>()) {
								if (item.stack > 1) {
									item.stack -= 1;
								}
								else {
									Main.LocalPlayer.inventory[payment].TurnToAir();
								}
							}
							if(item.type == ModContent.ItemType<unfinishgun3>()) {
								if (item.stack > 1) {
									item.stack -= 1;
								}
								else {
									Main.LocalPlayer.inventory[obamafix1].TurnToAir();
								}
							}
						}
						Main.LocalPlayer.QuickSpawnItem(ModContent.ItemType<Items.Weapon.Ak47>());
						return;
					}
					else {
						Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/obamanomoney").WithVolume(.7f), (int)npc.position.X, (int)npc.position.Y);
						Main.npcChatText = $"Sorry link, I can’t give credit, Come back when you are a little richer ( Need 1 [i:{ModContent.ItemType<Items.KingCoin>()}] King Coin )";
					}
				}
				//Main.PlaySound(SoundID.Roar);
				// and start an instance of our UIState.
				//ModContent.GetInstance<ExampleMod>().ExamplePersonUserInterface.SetState(new UI.ExamplePersonUI());
				// Note that even though we remove the chat window, Main.LocalPlayer.talkNPC will still be set correctly and we are still technically chatting with the npc.
			}
		}

		public override void SetupShop(Chest shop, ref int nextSlot) {
			shop.item[nextSlot].SetDefaults(ModContent.ItemType<americaflag>());
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Weapon.Ammo.WoodenBullet>());
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.IronBar);
			shop.item[nextSlot].shopCustomPrice = 10000;
			nextSlot++;
			/*
			if (Main.LocalPlayer.HasBuff(BuffID.Lifeforce)) {
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<ExampleHealingPotion>());
				nextSlot++;
			}
			if (Main.LocalPlayer.GetModPlayer<ExamplePlayer>().ZoneExample && !ModContent.GetInstance<ExampleConfigServer>().DisableExampleWings) {
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<ExampleWings>());
				nextSlot++;
			}
			if (Main.moonPhase < 2) {
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<ExampleSword>());
				nextSlot++;
			}
			else if (Main.moonPhase < 4) {
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<ExampleGun>());
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Weapons.ExampleBullet>());
				nextSlot++;
			}
			else if (Main.moonPhase < 6) {
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<ExampleStaff>());
				nextSlot++;
			}
			else {
			}*/
			// Here is an example of how your npc can sell items from other mods.
			var modPbone = ModLoader.GetMod("PboneUtils");
			if (modPbone != null) {
				shop.item[nextSlot].SetDefaults(modPbone.ItemType("VoidPiggy"));
				shop.item[nextSlot].shopCustomPrice = 150000;
				nextSlot++;
			}

			/*if (!Main.LocalPlayer.GetModPlayer<ExamplePlayer>().examplePersonGiftReceived && ModContent.GetInstance<ExampleConfigServer>().ExamplePersonFreeGiftList != null)
			{
				foreach (var item in ModContent.GetInstance<ExampleConfigServer>().ExamplePersonFreeGiftList)
				{
					if (item.IsUnloaded)
						continue;
					shop.item[nextSlot].SetDefaults(item.Type);
					shop.item[nextSlot].shopCustomPrice = 0;
					shop.item[nextSlot].GetGlobalItem<ExampleInstancedGlobalItem>().examplePersonFreeGift = true;
					nextSlot++;
					// TODO: Have tModLoader handle index issues.
				}	
			}*/
		}

		public override void NPCLoot() {
			Item.NewItem(npc.getRect(), ModContent.ItemType<ObamaHead>());
		}

		// Make this Town NPC teleport to the King and/or Queen statue when triggered.
		public override bool CanGoToStatue(bool toKingStatue) {
			return true;
		}

		// Make something happen when the npc teleports to a statue. Since this method only runs server side, any visual effects like dusts or gores have to be synced across all clients manually.
		/*public override void OnGoToStatue(bool toKingStatue) {
			if (Main.netMode == NetmodeID.Server) {
				ModPacket packet = mod.GetPacket();
				packet.Write((byte)ExampleModMessageType.ExampleTeleportToStatue);
				packet.Write((byte)npc.whoAmI);
				packet.Send();
			}
			else {
				StatueTeleport();
			}
		}*/

		// Create a square of pixels around the NPC on teleport.
		public void StatueTeleport() {
			for (int i = 0; i < 30; i++) {
				Vector2 position = Main.rand.NextVector2Square(-20, 21);
				if (Math.Abs(position.X) > Math.Abs(position.Y)) {
					position.X = Math.Sign(position.X) * 20;
				}
				else {
					position.Y = Math.Sign(position.Y) * 20;
				}
				Dust.NewDustPerfect(npc.Center + position, ModContent.DustType<Pixel>(), Vector2.Zero).noGravity = true;
			}
		}

		public override void TownNPCAttackStrength(ref int damage, ref float knockback) {
			damage = 10;
			knockback = 8f;
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown) {
			cooldown = 30;
			randExtraCooldown = 30;
		}

		public override void TownNPCAttackProj(ref int projType, ref int attackDelay) {
			projType = ProjectileID.ChlorophyteBullet;
			attackDelay = 1;
		}

		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset) {
			multiplier = 12f;
			randomOffset = 2f;
		}
	}
}
