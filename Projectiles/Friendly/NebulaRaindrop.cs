using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace Maggic.Projectiles.Friendly
{
	public class NebulaRaindrop : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nebula Raindrop");
		}
		public override void SetDefaults()
		{
			projectile.width = 16;
			projectile.height = 16;
			projectile.alpha = 255;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
			projectile.timeLeft = 600;
			projectile.light = 0.7f;
		}
		
		public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough) 
		{ 
			width = 2; 
			height = 2; 
			return true; 
		}

		public override void AI()
		{
			for(int i=0; i<6;i++)
			DustHelper.CreateDust(projectile.Center,254,Color.White,-projectile.velocity.ToRotation().ToRotationVector2()*Main.rand.NextFloat(5),noGrav:true,fadeIn:1.2f,rotation:Main.rand.NextFloat(MathHelper.TwoPi));
			if (Main.netMode != 1)
			{
				projectile.tileCollide = projectile.Center.Y > projectile.OwnerPlayer().Top.Y;
				projectile.netUpdate = true;
			}
		}
	}
}