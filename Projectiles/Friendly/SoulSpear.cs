using Terraria.Graphics.Shaders;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Maggic.Projectiles.Friendly
{
	public class SoulSpear : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Soul Spear");
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
			projectile.light = .5f;
		}

		public override void AI()
		{
            for (int i = 0; i < 6; i++)
                DustHelper.CreateDust(
                    projectile.Center + new Vector2(Main.rand.Next(-8, 8), Main.rand.Next(-8, 8)) + (projectile.rotation + MathHelper.PiOver2).ToRotationVector2() * 10, 180,
                    new Color(61 + Main.rand.Next(15), 142 - Main.rand.Next(20), 228), Vector2.Zero, scale: .7f, noGrav: true, fadeIn: .5f);
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

		public override bool PreKill(int timeLeft)
		{
			for (int i = 0; i < 20; i++)
				DustHelper.CreateDust(new Vector2(projectile.Center.X + Main.rand.NextFloat(-4, 4),
						projectile.Center.Y + Main.rand.NextFloat(-4, 4)), 182, new Color(0, 255, 242),
					projectile.oldVelocity.ToRotation().ToRotationVector2() * Main.rand.NextFloat(2, 6), 1, 0, 1, true,
					shader: GameShaders.Armor.GetSecondaryShader(87, Main.LocalPlayer));
			return base.PreKill(timeLeft);
		}
	}
}