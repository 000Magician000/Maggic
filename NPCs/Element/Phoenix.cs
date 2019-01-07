using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;
using Terraria;
using Terraria.Achievements;
using Terraria.ID;

namespace Maggic.NPCs.Element
{
    public class Phoenix : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.Raven];
        }

        public override void SetDefaults()
        {
            npc.width = 72;
            npc.height = 76;
            npc.damage = 24;
            npc.defense = 20;
            npc.lifeMax = 120;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = Item.buyPrice(silver:50);
            npc.aiStyle = 17;
            aiType = NPCID.Raven;
            animationType = NPCID.Raven;
        }

        private int dashtime = 180;
        private const int dashtimemax = 180;

        private int dashtimes = 60;

        private void Dash()
        {
            var close = PlayerHelper.Closest(npc.Center,float.MaxValue);
            if (close != -1)
            {
                Player plr = Main.player[close];
                if (Vector2.Distance(npc.Center, plr.Center) < 800)
                {
                    npc.velocity.X = 14 * -npc.spriteDirection;
                    Vector2 svel = VectorHelper.FromTo(npc.Center, plr.Center,5);
                    int count = 3;
                        
                    const float cir = MathHelper.TwoPi;
                    float one = cir / (count * 15);
                    for (int i = -count / 2; i < count / 2+1; i++)
                    {
                        Vector2 vel = (svel.ToRotation()+ (one * i)).ToRotationVector2() * 18;
                        Projectile p = Projectile.NewProjectileDirect(npc.Center, vel, mod.ProjectileType("PhoenixFeather"), npc.damage/2, 1.5f, Main.myPlayer);
                        p.hostile = true;
                        p.friendly = false;
                    }
                }
            }
        }

        public override void AI()
        {
            if (--dashtime == 0 && Main.netMode != 1)
            {
                Dash();
                dashtime = dashtimemax;
                npc.netUpdate = true;
            }
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            Player player = spawnInfo.player;
            if (player.ZoneUnderworldHeight && Main.hardMode)
            {
                return 0.08f;
            }
            return 0f;
        }

        public override void NPCLoot()
        {
            if (Helper.TryChance(.013f))
                Item.NewItem(npc.getRect(), ItemID.FireFeather);
        }
        
        public override void HitEffect(int hitDirection, double damage)
        {
            npc.DropGores(3);
        }
    }
}