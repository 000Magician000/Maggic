using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;

namespace Maggic.Projectiles.Hostile
{
    public class Icy : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 16;
            projectile.height = 16;
            projectile.alpha = 0;
            projectile.timeLeft = 1200;
            projectile.penetrate = 2;
            projectile.hostile = true;
            projectile.light = 0.5f;
        }

        private bool _deactive = false;

        public override void AI()
        {
            if (projectile.rotation < MathHelper.TwoPi)
            {
                projectile.rotation += _deactive ? 0.3f : 0.1f;
            }
            else
            {
                projectile.rotation = 0;
            }

            if (_deactive)
            {
                if (projectile.scale > 0)
                {
                    projectile.scale -= 0.02f;
                }
                else
                {
                    projectile.Kill();
                }
            }

            if (projectile.lavaWet) projectile.Kill();
            dust(3 * (int) projectile.scale);
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (!_deactive)
            {
                projectile.tileCollide = false;
                _deactive = true;
            }

            return false;
        }

        public override bool? CanCutTiles()
        {
            return false;
        }

        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
        {
            width = 5;
            height = 5;
            return base.TileCollideStyle(ref width, ref height, ref fallThrough);
        }

        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(BuffID.Frozen, 120);
        }

        private void dust(int rnd)
        {
            Vector2 position = new Vector2(projectile.Center.X + Main.rand.NextFloat(-rnd, rnd),
                projectile.Center.Y + Main.rand.NextFloat(-rnd, rnd));
            DustHelper.CreateDust(position, 156, Color.White, Vector2.Zero, 0.8f, noGrav: true);
        }

        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 30; i++)
                dust(8);
        }
    }
}