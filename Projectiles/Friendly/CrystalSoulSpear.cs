using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Maggic.Projectiles.Friendly
{
	public class CrystalSoulSpear : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystal Soul Spear");;
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(246);
			projectile.width = 14;
			projectile.height = 38;
			projectile.alpha = 0;
			projectile.timeLeft = 600;
			projectile.penetrate = 3;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.scale = 1f;
			projectile.ignoreWater = true;
			projectile.light = .7f;
		}
		
		public override void AI()
		{
			for (int i = 0; i < 2; i++)
			{
				DustHelper.CreateDust(new Vector2(projectile.Center.X+Main.rand.NextFloat(-6,6),projectile.Center.Y+Main.rand.NextFloat(-6,6)),255,Color.White,Vector2.Zero,noGrav:true,scale:Main.rand.NextFloat(1f,1.8f));
			}
			
			if (projectile.owner == Main.myPlayer && Helper.TryChance(.15f))
			{
				for (int i = 0; i < Main.rand.Next(2,3); i++)
				{
					Vector2 position = projectile.Center;
					Vector2 vel = new Vector2(Main.rand.Next(-1,1),Main.rand.Next(-1,1));
					int type = ProjectileID.CrystalStorm;
					int proj=Projectile.NewProjectile(position.X, position.Y, vel.X, vel.Y, type,(projectile.damage/3)*2,0,Main.myPlayer);
					Main.projectile[proj].tileCollide = false;
					Main.projectile[proj].timeLeft = Main.rand.Next(30,90);
				}
			}
		}
		
		public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough) 
		{ 
			width = 10; 
			height = 10; 
			return true; 
		}
		
		public override Color? GetAlpha(Color lightColor) 
		{ 
			return Color.White * ((255 - projectile.alpha) / 255f); 
		}
	}
}