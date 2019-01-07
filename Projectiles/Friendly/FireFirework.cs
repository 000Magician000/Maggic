using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;

namespace Maggic.Projectiles.Friendly
{
	public class FireFirework : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fireball");
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.BallofFire);
			projectile.width = 16;
			projectile.height = 16;
			projectile.penetrate = -1;
			projectile.timeLeft = 60;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.ignoreWater = false;
			projectile.damage = 0;
			projectile.light = .6f;
		}
		
		public override void AI()
		{
			if (projectile.rotation<MathHelper.TwoPi)
			projectile.rotation += .1f;
			else
			projectile.rotation = 0;
		}

		private void Shoot()
		{
			Vector2 position = projectile.Center;
			Vector2 vel = new Vector2(Main.rand.NextFloat(-3f,3f),Main.rand.NextFloat(-6f,-2f));
			int type = Main.rand.Next(400,403);
			int proj= Projectile.NewProjectile(position.X, position.Y, vel.X, vel.Y, type,24,0,Main.myPlayer);
			Main.projectile[proj].timeLeft = Main.rand.Next(60,90);
		}

		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < Main.rand.Next(12, 20); i++)
			{
				DustHelper.CreateDust(projectile.Center, 6, Color.White,
					new Vector2(Main.rand.NextFloat(-1f, 1f), Main.rand.NextFloat(-18f, -10f)), noGrav: true, fadeIn: .9f);
			}
			
			if (projectile.owner == Main.myPlayer)
			{
				for (int i = 0; i < 5; i++)
				{
					Shoot();
				}
			}
		}
		
		public override Color? GetAlpha(Color lightColor) 
		{ 
			return Color.White * ((255 - projectile.alpha) / 255f); 
		}
	}
}