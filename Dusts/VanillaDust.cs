using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace ObamaGaming.Dusts
{
	public class Woodust : ModDust
	{	
		public override void OnSpawn(Dust dust) {
			dust.noGravity = true;
			dust.noLight = true;
			dust.frame = new Rectangle(0, 0, 24, 22);
			dust.scale = 0.500f;
		}
		public override bool Update(Dust dust) {
			dust.position += dust.velocity;
			dust.rotation += 0.05f;
			dust.scale -= 0.005f;
			if (dust.scale < 0) {
				dust.active = false;
			}
			//else {
				//Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), dust.color.R / 255f * 0.5f, dust.color.G / 255f * 0.5f, dust.color.B / 255f * 0.5f);
			//}
			return false;
		}
	}
}