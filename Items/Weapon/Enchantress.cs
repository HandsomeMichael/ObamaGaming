using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ObamaGaming.Items.Weapon
{
	public class Enchantress : ModItem
	{
		public override bool CloneNewInstances => true;
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("<left> To Summon portal on your cursor"+
			"\n<right> To Teleport to the portal"+
			"\nPortal will damage enemy too");  //The (English) text shown below your weapon's name
			ItemID.Sets.GamepadWholeScreenUseRange[item.type] = true;
		}
		public override void SetDefaults() {
			item.damage = 10;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 20; 
			item.useAnimation = 20;
			item.knockBack = 6; 
			item.value = Item.buyPrice(gold: 1); 
			item.rare = ItemRarityID.Pink;
			item.shoot = ModContent.ProjectileType<EnchantressPortal>();
			item.shootSpeed = 0.01f;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true; 
			item.useStyle = 1;
		}
		public override bool AltFunctionUse(Player player) => true;
		public override bool CanUseItem (Player player) {
			if (player.altFunctionUse == 2) {
				item.useStyle = 4;
				item.shoot = ProjectileID.None;
				player.position.X = teleportx;
				player.position.Y = teleporty;
				Main.PlaySound(SoundLoader.customSoundType, player.position, mod.GetSoundSlot(SoundType.Custom, "Sounds/protomy"));
				for (int num424 = 0; num424 < 30; num424++) {
					Dust.NewDust(new Vector2(player.position.X, player.position.Y), 128, 128, 133, player.velocity.X * 0.1f, player.velocity.Y * 0.1f, 0, default(Color), 0.75f);
				}
			}
			else {
				for (int i = 0; i < Main.maxProjectiles; i++) {
					if (Main.projectile[i].active && Main.projectile[i].type == ModContent.ProjectileType<EnchantressPortal>()) {
						Main.projectile[i].Kill();
					}
				}
				item.useStyle = 1;
				item.shoot = ModContent.ProjectileType<EnchantressPortal>();
			}
			return base.CanUseItem(player);
		}
		public override void UpdateInventory (Player player) {}
		public float teleportx;
		public float teleporty;
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			position = Main.MouseWorld;
			teleportx = position.X + 12f;
			teleporty = position.Y;
			return true;
		}
	}
	public class EnchantressPortal : ModProjectile
	{
		public override string Texture => "ObamaGaming/NPCs/NihilarPortal";
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Enchantress Portal");
		}
		public override void SetDefaults() {
			projectile.width = 256;               //The width of projectile hitbox
			projectile.height = 256;              //The height of projectile hitbox
			projectile.aiStyle = -1;             //The ai style of the projectile, please reference the source code of Terraria
			projectile.friendly = true;         //Can the projectile deal damage to enemies?
			projectile.melee = true;           //Is the projectile shoot by a ranged weapon?
			projectile.penetrate = 1;           //How many monsters the projectile can penetrate. (OnTileCollide below also decrements penetrate for bounces as well)
			projectile.timeLeft = 6000;          //The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
			projectile.alpha = 255;             //The transparency of the projectile, 255 for completely transparent. (aiStyle 1 quickly fades the projectile in) Make sure to delete this if you aren't using an aiStyle that fades in. You'll wonder why your projectile is invisible.
			projectile.light = 0.5f;            //How much light emit around the projectile
			projectile.ignoreWater = true;          //Does the projectile's speed be influenced by water?
			projectile.tileCollide = false;          //Can the projectile collide with tiles?
			projectile.extraUpdates = 1;            //Set to above 0 if you want the projectile to update multiple time in a frame
			projectile.scale = 0.25f;
			drawOriginOffsetY = -200; // doesn't change
			drawOriginOffsetX = -100;
			//projectile.color = Main.DiscoG;
		}
		public override void AI () {
			//projectile.rotation += 0.01f;
			if (projectile.alpha > 1) {
				projectile.alpha -= 5;
			}
			if (projectile.scale < 0.5f) {
				projectile.scale += 0.01f;
			}
		}
	}
}
