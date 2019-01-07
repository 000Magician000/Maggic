using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;

namespace Maggic
{
    public static class PlayerHelper
    {
        public static int Closest(Vector2 point, float max = int.MaxValue)
        {
            float range = max;
            int n = -1;
            foreach (var player in Main.player)
            {
                float dist = Vector2.Distance(player.Center, point);
                if (dist < range && player.active)
                {
                    range = dist;
                    n = player.whoAmI;
                }
            }

            return n;
        }
    }

    public static class ProjectileHelper
    {
        public static void VelocityToRotation(this Projectile projectile, float angle = 0, float origAngle = 0)
        {
            float superAngle = 0;
            if (origAngle == 90)
                superAngle = MathHelper.PiOver2;
            else if (origAngle == 180)
                superAngle = MathHelper.Pi;
            else if (origAngle == 270)
                superAngle = MathHelper.PiOver2 * 3;
            projectile.rotation = projectile.velocity.ToRotation() - (origAngle == 0 ? angle : superAngle);
        }

        public static void FromTo(this Projectile projectile, Vector2 to, float speed, float smooth)
        {
            Vector2 range = VectorHelper.FromTo(projectile.Center, to, speed);

            projectile.velocity += (range - projectile.velocity) / smooth;
        }

        public static Player OwnerPlayer(this Projectile projectile)
        {
            return Main.player[projectile.owner];
        }

        public static void Animate(this Projectile p, int speed)
        {
            if (++p.frameCounter >= Main.projFrames[p.type])
            {
                p.frameCounter = 0;
                if (++p.frame >= speed)
                {
                    p.frame = 0;
                }
            }
        }
    }

    public static class NPCHelper
    {
        public static void DropGores(this NPC npc,int count = 1)
        {
            if (npc.life <= 0)
            {
                for (int k = 0; k < count; k++)
                {
                    Gore i = Gore.NewGoreDirect(npc.position, npc.velocity.ToRotation().ToRotationVector2() * Main.rand.NextFloat(2),
                        Helper.mod.GetGoreSlot(String.Format("Gores/{0}{1}_{2}", string.Join("", npc.FullName.Split(' ')), "Gore", k)));
                }
            }
        }
        public static int Closest(Vector2 point, float max = int.MaxValue, bool dontCheckDontTakeDmg = false,
            bool dontCheckFriendly = true, int[] disallowedNPCs = null)
        {
            float range = max;
            int n = -1;
            foreach (var npc in Main.npc)
            {
                float dist = Vector2.Distance(npc.Center, point);
                if (dist < range && npc.active && !disallowedNPCs.Contains(npc.netID) &&
                    (!dontCheckFriendly || !npc.friendly) && (!dontCheckDontTakeDmg || !npc.dontTakeDamage))
                {
                    range = dist;
                    n = npc.whoAmI;
                }
            }

            return n;
        }

        public static NPC ClosestNPC(Vector2 point, float max = int.MaxValue, bool dontCheckDontTakeDmg = false,
            bool dontCheckFriendly = true, int[] disallowedNPCs = null)
        {
            NPC close = Main.npc[Closest(point, max, dontCheckDontTakeDmg, dontCheckFriendly, disallowedNPCs)];
            return close;
        }

        public static void DirectionToSpriteDirection(this NPC npc)
        {
            npc.spriteDirection = npc.direction;
        }

        public static void VelocityToRotation(this NPC npc)
        {
            npc.rotation = npc.velocity.ToRotation();
        }
    }

    public static class VectorHelper
    {
        public static List<Vector2> Circle(int count, float distance = 1, float start = 0f)
        {
            List<Vector2> list = new List<Vector2>();
            for (int i = 0; i < count; i++)
            {
                Vector2 vec = (start + MathHelper.TwoPi / count * i).ToRotationVector2() * distance;
                list.Add(vec);
            }

            return list;
        }

        public static Vector2 FromTo(Vector2 from, Vector2 to, float speed)
        {
            Vector2 range = to - from;

            float magnitude = range.Length();

            if (magnitude > 0)
            {
                range *= speed / magnitude;
            }
            else
            {
                range = new Vector2(0f, speed);
            }

            return range;
        }
    }

    public static class DustHelper
    {
        public static void CreateDust(Vector2 pos, int type, Color color = default(Color), Vector2? velocity = null, float chance = 1f,
            int alpha = 0, float scale = 1,
            bool noGrav = false, float fadeIn = 0f, float rotation = 0f, ArmorShaderData shader = null)
        {
            if (Main.rand.NextFloat() < chance)
            {
                Dust dust = Dust.NewDustPerfect(pos, type, null, alpha, color, scale);
                dust.noGravity = noGrav;
                dust.fadeIn = fadeIn;
                if (velocity.HasValue)
                {
                    dust.velocity = velocity.Value;
                }
                dust.rotation = rotation;
                if (shader != null)
                {
                    dust.shader = shader;
                }
            }
        }
    }

    public static class Helper
    {
        public static Mod mod
        {
            get { return Maggic.Instance; }
        }
        public static bool TryChance(float chance)
        {
            if (chance > 1) chance /= 100;

            return Main.rand.NextFloat() < Math.Abs(chance);
        }
    }
}