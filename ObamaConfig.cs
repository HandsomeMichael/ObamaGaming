using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;
using Terraria.ModLoader.Config.UI;
using Terraria.UI;

namespace ObamaGaming
{
	//[BackgroundColor(144, 252, 249)]
	[Label("Obama America Config")]
	public class ObamaConfig : ModConfig
	{
		public override ConfigScope Mode => ConfigScope.ServerSide;
		public static ObamaConfig Instance => ModContent.GetInstance<ObamaConfig>();

		[Label("Shortsword Alternate Attack")]
		[Tooltip("Allow Shortsword To Have Alternative Swing Attack")]
		[DefaultValue(true)]
		public bool AllowShortswordAlt { get; set; }

		[Label("Blacklist Shortsword Mechanic")]
		[Tooltip("Item listed here will not given shortsword alternate attack\nUse Shortsword weapon type pls")]
		public List<ItemDefinition> BlacklistShortsword { get; set; } = new List<ItemDefinition>();

		[Label("Talking Npc")]
		[Tooltip("Some Npc Can Talk Using Combat Text")]
		[DefaultValue(true)]
		public bool AllowNpcTalk { get; set; }

		[Label("King Coin From Boss")]
		[Tooltip("Boss Will Drop King Coin")]
		[DefaultValue(true)]
		public bool AllowKingCoinBoss { get; set; }

		[Label("Unfinish Gun")]
		[Tooltip("Some Enemy will drop unfinish gun that can be finish by obama")]
		[DefaultValue(true)]
		public bool Allowunfinishgun { get; set; }
		
		[Label("Secret Code")]
		[Tooltip("Amongus funni")]
		[DefaultValue("Obama")]
		public string Password { get; set; }
	}
}
