using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace Maggic.Projectiles.Friendly
{
	public class GlowBlow : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Glow Blow");
		}

		public override void SetDefaults()
		{
			projectile.width = 12;
			projectile.height = 12;
			projectile.alpha = 255;
			projectile.penetrate = -1;
			projectile.friendly = true;
			projectile.damage = 0;
			projectile.magic = true;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
			projectile.light = 1.5f;
		}

		private int _timer = 180;
		private int _timerr = 0;

		public override void AI()
		{
			if (projectile.velocity.X!=0 || projectile.velocity.Y!=0)
				DustHelper.CreateDust(projectile.Center,64,Color.White,Vector2.Zero,scale:1.3f,noGrav:true);

			if (projectile.owner == Main.myPlayer)
			{
				if (_timer > 0)
				{
					_timer--;
				}
				else
				{
					_timer = 180;
					float speed = Main.rand.NextFloat(4, 8);
					float dir = Main.rand.NextFloat(MathHelper.TwoPi);

					projectile.velocity += dir.ToRotationVector2() * speed;
					_timerr = 30;
					projectile.netUpdate = true;
				}

				if (_timerr > 0)
					_timerr--;
				else
				{
					projectile.velocity = new Vector2(0, 0);
					projectile.netUpdate = true;
				}
			}
		}

		public override bool? CanCutTiles()
		{
			return false;
		}

		public override void Kill(int timeLeft)
		{
			for (int i=0;i<Main.rand.Next(20,30);i++)
			if (Main.rand.NextFloat() < 1f)
			{
				Dust dust;
				Vector2 position = projectile.Center;
				dust = Main.dust[Terraria.Dust.NewDust(position, 20, 20, 64, 0f, 0f, 0, new Color(255,255,255), 1.5f)];
				dust.noGravity = true;
				dust.alpha = Main.rand.Next(0, 50);
			}
		}
	}
}