using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using ObamaGaming;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace ObamaGaming.Items.Weapon
{
	public class WeirdSword : ModItem
	{
		public override bool CloneNewInstances => true;
		//-854156397
		public int counter = 0;
		int counting = 1;
		int critz = 0;
		int randomizi = 0;
		int speedp = 0;
		int classy = 1;
		public int reforged = 0;
		int reforgedupdate = 0;
		int ifyouarereadingthissorryifmycodearebadlol;

		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Test Sword"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Hook List = [ Use Style Randomize + Combo In Reference To Weapon out + Broken Reforge System + Class Change]"+
			"\nThis Item Is For Testing Purposes"+
			"\nIt Is Very Recommended to not use this on normal playtrough"+
			"\n<right> to use 5 combo");
		}

		public override void SetDefaults() 
		{
			item.damage = 10;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 10000;
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shootSpeed = 7f;
		}
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<Nocraft>());
			recipe.SetResult(this);
			recipe.AddRecipe();

		}
		public override void ModifyTooltips(List<TooltipLine> tooltips) {
			var ComboCount = new TooltipLine(mod, "ComboCounter", $"{counter} Combo Left");
			ComboCount.overrideColor = Color.Cyan;
			tooltips.Add(ComboCount);
		}
		public override void PostReforge()
		{
			reforgedupdate = 1;
		}
		public override bool CanRightClick() => true;

		public override void RightClick(Player player) {
			ifyouarereadingthissorryifmycodearebadlol++;
			classy++;
			if (classy == 2){
				item.melee = false;
				item.ranged = true;
				item.summon = false;
				item.magic = false;
				CombatText.NewText(player.getRect(), Color.LightYellow, "Ranged Mode");
				item.color = Color.Yellow;
			}
			if (classy == 3){
				item.melee = false;
				item.ranged = false;
				item.summon = true;
				item.magic = false;
				CombatText.NewText(player.getRect(), Color.LightGreen, "Summon Mode");
				item.color = Color.Green;
			}
			if (classy == 4){
				item.melee = false;
				item.ranged = false;
				item.summon = false;
				item.magic = true;
				CombatText.NewText(player.getRect(), Color.LightBlue, "Magic Mode");
				item.color = Color.Cyan;
			}
			if (classy > 4){
				classy = 1;
				item.melee = true;
				item.ranged = false;
				item.summon = false;
				item.magic = false;
				item.color = Color.Red;
				CombatText.NewText(player.getRect(), Color.Pink, "Melee Mode");
			}
		}
		public override bool ConsumeItem(Player player) => false;

		public override void UpdateInventory(Player player)
		{
			if (classy == 1){
				item.color = Color.Red;
			}
			counting++;
			if ( critz < 120 && critz > 0){
				item.damage = randomizi;
			}
			else {
				item.damage = reforged / 10 + counter / 2 + 10;
			}
			if (counting > 200 && counter > 0)
			{
				counter = 0;
				counting = 0;
				CombatText.NewText(player.getRect(), Color.Orange, "Combo Run Out");
			}
			if (critz > 0 )
			{
				critz -= 1;
				item.crit = 100;
			}
			else
			{
				speedp = 0;
				item.crit = counter;
			}
			if (randomizi < 50 )
			{
				randomizi++;
			}
			else{
				randomizi = 1;
			}
			//reforged
			if (reforgedupdate == 1){
				reforged++;
				reforgedupdate = 0;
				CombatText.NewText(player.getRect(), Color.Cyan, "Total Reforged : " + reforged);
			}
			//anger bug fix
			if (critz > 700)
			{
				critz = 200;
				player.AddBuff(BuffID.OnFire, 600);
				CombatText.NewText(player.getRect(), Color.OrangeRed, "TOO MUCH ANGER !!");
				Main.PlaySound(SoundID.Pixie, player.position, 0);
			}
		}
		public override bool AltFunctionUse(Player player) {
			return true;
		}
		public override bool UseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
				if ( counter > 4)
				{
					//player.AddBuff(BuffID.ShadowDodge, 60);
					if ( critz == 0) {
						counter -= 5;
						critz = 600;
						speedp = 5;
						CombatText.NewText(player.getRect(), Color.Red, " Critical Strike Active !");
						Main.PlaySound(SoundID.Roar, player.position, 0);
					}
					else
					{
						CombatText.NewText(player.getRect(), Color.Pink, critz / 60 + " Second Left !");
					}
				}
				else
				{
					if ( critz == 0) {
						CombatText.NewText(player.getRect(), Color.Pink, "Not enough combo");
					}
					else {
						CombatText.NewText(player.getRect(), Color.Pink, critz / 60 + " Second Left !");
					}
				}
			}
			return true;
		}
		/*public override bool OnPickup(Player player)
		{
			counter++;
			Color color = CombatText.HealLife;
			CombatText.NewText(player.getRect(), color, "Combo Weapon");
			return true;
		}*/
		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
		{
			if (critz > 0 )
			{
				target.AddBuff(BuffID.OnFire, 10*counter);
				if (speedp > 5) {
					target.AddBuff(BuffID.Confused, 10*counter);
				}
			}
			counting = 0;
			if (counter < 20)
			{
				counter++;
				CombatText.NewText(player.getRect(), Color.Cyan, counter);
			}
			else
			{
				CombatText.NewText(player.getRect(), Color.Red, "!! ANGER !!");
				player.AddBuff(BuffID.Rage, 600);
				player.AddBuff(BuffID.ShadowDodge, 120);
				Main.PlaySound(SoundID.Zombie, player.position, 0);
				counter = 0;
				if (critz > 0 )
				{
					speedp += 5;
					critz += 100;
				}
				else{
					critz += 200;
					speedp += 5;
				}
			}
		}
		public override bool CanUseItem(Player player) {
			if (player.altFunctionUse == 2)
			{
				item.useStyle = 4;
				item.noUseGraphic = false;
				item.shoot = ProjectileID.None;
				item.useTime = 30;
				item.useAnimation = 30;
				item.UseSound = SoundID.Item4;
				item.noMelee = true;
			}
			else
			{
				item.noMelee = false;
				item.UseSound = SoundID.Item1;
				if (Main.rand.Next(3) == 0) {
					item.useStyle = 3;
					item.noUseGraphic = false;
					item.shoot = ProjectileID.None;
					item.useTime = 20-speedp;
					item.useAnimation = 20-speedp;
				}
				else 
				{
					item.useStyle = 1;
					if (Main.rand.Next(2) == 0) 
					{
						item.useTime = 35-speedp;
						item.useAnimation = 35-speedp;
						item.noUseGraphic = true;
						if (Main.rand.Next(2) == 0)
						{
							item.shoot = ModContent.ProjectileType<Projectiles.WSThrow>();
						}
						else
						{
							item.shoot = ModContent.ProjectileType<Projectiles.WSSpear>();
						}
					}
					else
					{
						item.useTime = 20-speedp;
						item.useAnimation = 20-speedp;
						item.noUseGraphic = false;
						item.shoot = ProjectileID.None;
					}
				}
			}
			return base.CanUseItem(player);
		}
		public override void MeleeEffects(Player player, Rectangle hitbox) {
			if (Main.rand.NextBool(3) && critz > 0) {
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Fire, player.velocity.X * 0.2f + (float)(player.direction * 3), player.velocity.Y * 0.2f, 100, default(Color), 2.5f);
				Main.dust[dust].noGravity = true;
			}
		}
		// Shotgun style: Multiple Projectiles, Random spread 
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (Main.rand.Next(10) == 0 || critz > 0) 
			{
				int numberProjectiles = 2 + Main.rand.Next(2); // 4 or 5 shots
				for (int i = 0; i < numberProjectiles; i++)
				{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(30)); // 30 degree spread.
				// If you want to randomize the speed to stagger the projectiles
				// float scale = 1f - (Main.rand.NextFloat() * .3f);
				// perturbedSpeed = perturbedSpeed * scale; 
				// After Type it will be damage
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, reforged / 4 + counter / 2 + 6, knockBack, player.whoAmI);
				}
			}
			return true; // return false because we don't want tmodloader to shoot projectile
		}
		public override TagCompound Save()
        {
            TagCompound tag = new TagCompound() {
                { "reforged", reforged }
            };
            return tag;
        }

        public override void Load(TagCompound tag)
        {
            base.Load(tag);
            reforged = tag.GetInt("reforged");
        }
	}
}