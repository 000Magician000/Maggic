using System;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;

namespace Maggic.NPCs.Element
{
    public class GlacialSlime : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.BlueSlime];
        }

        public override void SetDefaults()
        {
            npc.width = 80;
            npc.height = 60;
            npc.damage = 34;
            npc.defense = 25;
            npc.lifeMax = 500;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 1200f;
            npc.knockBackResist = 0.2f;
            npc.aiStyle = 1;
            npc.alpha = 50;
            aiType = NPCID.BlueSlime;
            animationType = NPCID.BlueSlime;
            banner = npc.type;
            bannerItem = mod.ItemType("BannerGiantIceCube");
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            Player player = spawnInfo.player;
            if (NPC.downedBoss1 && player.ZoneSnow && Main.hardMode)
            {
                return spawnInfo.spawnTileY > Main.rockLayer ? 0.2f : 0f;
            }

            return 0f;
        }

        public override void AI()
        {
            npc.DirectionToSpriteDirection();
        }

        public override void NPCLoot()
        {
            Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, ItemID.IceBlock, Main.rand.Next(10, 20));
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            dust(4);

            if (npc.life <= 0)
            {
                dust(20);
                Shoot(8);
            }
        }

        private void Shoot(int count)
        {
            if (Main.netMode != 1)
            {
                int spd = 7, type = mod.ProjectileType("Icy"), dmg = npc.damage / 2;
                Vector2 spawn = npc.Center;

                for (int i = 0; i < count; i++)
                {
                    Vector2 vel = (MathHelper.TwoPi / count * i).ToRotationVector2() * spd;
                    var p = Projectile.NewProjectileDirect(spawn, vel, type, dmg, 0f, Main.myPlayer);
                    p.netUpdate = true;
                }
            }
        }

        private void dust(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Vector2 position = npc.Center;
                Dust.NewDust(position, 0, 0, 80, 0f, 0f, 0, Color.White);
            }
        }
    }
}