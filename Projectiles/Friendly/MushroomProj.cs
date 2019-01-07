using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace Maggic.Projectiles.Friendly
{
	public class MushroomProj : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Glowing Mushroom");
		}

		public override void SetDefaults()
		{
			projectile.width = 22;
			projectile.height = 24;
			projectile.alpha = 200;
			projectile.penetrate = -1;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.ignoreWater = true;
			projectile.magic = true;
		}

		private float _rot = 1;
		private float minrot = 0.4f;
		int maxalpha = 0;
		
		public override void AI()
		{
			Lighting.AddLight(projectile.Center, Color.Blue.ToVector3() * 0.8f);
			
			if (projectile.alpha > maxalpha)
			{
				projectile.alpha-=5;
				projectile.scale += 0.00625f;
				if (_rot>minrot)
				_rot-=0.1f;
				projectile.rotation += _rot;
			}
			else
			{
				projectile.timeLeft = 0;
			}
		}
		
		public override void Kill(int timeLeft)
		{
			for (int i=0;i<40;i++)
			DustHelper.CreateDust(projectile.Center,16,Color.White,Vector2.Zero,1f,0,1,true);

			int c = 6;
			for (int i = 0; i < c; i++)
			{
				Vector2 pos = projectile.Center + (MathHelper.TwoPi / c * i).ToRotationVector2()*20;
				Projectile p =Projectile.NewProjectileDirect(pos, Vector2.Zero, ProjectileID.TruffleSpore, projectile.damage, 0f, projectile.owner);
				p.timeLeft = 60;
			}
		}
	}
}