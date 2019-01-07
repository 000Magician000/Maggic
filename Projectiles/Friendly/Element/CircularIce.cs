using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Maggic.Projectiles.Friendly.Element
{
    public class CircularIce : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ice Shard");
        }

        public override void SetDefaults()
        {
            projectile.width = 26;
            projectile.height = 12;
            projectile.timeLeft = 300;
            projectile.penetrate = -1;
            projectile.friendly = true;
            projectile.damage = 10;
            projectile.magic = true;
            projectile.ignoreWater = true;
            projectile.light = .5f;
            projectile.tileCollide = false;
        }

        public override bool? CanCutTiles()
        {
            return false;
        }
        
        public override bool PreKill(int timeLeft)
        {
            for(int i=0;i<10;i++)
                DustHelper.CreateDust(new Vector2(projectile.Center.X + Main.rand.NextFloat(-4,4),
                        projectile.Center.Y + Main.rand.NextFloat(-4, 4)),156,Color.White,projectile.oldVelocity.ToRotation().ToRotationVector2()*Main.rand.NextFloat(2,6),1,0,.8f,true);
            return base.PreKill(timeLeft);
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Frostburn,60);
        }

        public override void AI()
        {
            projectile.VelocityToRotation();
            for (int i = 0; i < 5; i++)
            {
                DustHelper.CreateDust(new Vector2(projectile.Center.X+Main.rand.Next(-3,3),projectile.Center.Y+Main.rand.Next(-3,3)),156,Color.White,Vector2.Zero,1f,0,0.7f,true);
            }
        }
        
        public override Color? GetAlpha(Color lightColor) 
        { 
            return Color.White * ((255 - projectile.alpha) / 255f); 
        } 
    }
}