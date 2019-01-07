using System;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;

namespace Maggic.NPCs.Enchanted
{
    public class EnchantedZombie : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.Zombie];
        }

        public override void SetDefaults()
        {
            npc.width = 18;
            npc.height = 40;
            npc.damage = 20;
            npc.defense = 8;
            npc.lifeMax = 90;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath2;
            npc.value = 90f;
            npc.knockBackResist = 0.5f;
            npc.aiStyle = 3;
            aiType = NPCID.Zombie;
            animationType = NPCID.Zombie;
            banner = Item.NPCtoBanner(NPCID.Zombie);
            bannerItem = Item.BannerToItem(banner);
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            Player player = spawnInfo.player;
            if (NPC.downedBoss1 || NPC.downedBoss2 || NPC.downedBoss3)
            {
                return SpawnCondition.OverworldNightMonster.Chance * 0.008f * (Main.hardMode ? 1.3f : 1f);
            }

            return 0f;
        }

        public override void NPCLoot()
        {
            if (Main.rand.NextFloat() < .5f)
                Item.NewItem(npc.getRect(), mod.ItemType("EnchantmentPiece"));
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            npc.DropGores(3);

            for (int i = 0; i < 8; i++)
                Dust.NewDust(npc.Center, 0, 0, DustID.Blood);
        }

        public override void AI()
        {
            Lighting.AddLight(npc.Center, Color.Violet.ToVector3());
        }
    }

    public class EnchantedEye : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.DemonEye];
        }

        public override void SetDefaults()
        {
            npc.width = 30;
            npc.height = 32;
            npc.damage = 24;
            npc.defense = 3;
            npc.lifeMax = 120;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 120f;
            npc.knockBackResist = 0.8f;
            npc.aiStyle = 2;
            aiType = NPCID.DemonEye;
            animationType = NPCID.DemonEye;
            banner = Item.NPCtoBanner(NPCID.DemonEye);
            bannerItem = Item.BannerToItem(banner);
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            Player player = spawnInfo.player;
            if (NPC.downedBoss1 || NPC.downedBoss2 || NPC.downedBoss3)
            {
                return SpawnCondition.OverworldNightMonster.Chance * 0.01f * (Main.hardMode ? 1.3f : 1f);
            }

            return 0f;
        }

        public override void NPCLoot()
        {
            if (Main.rand.NextFloat() < .5f)
                Item.NewItem(npc.getRect(), mod.ItemType("EnchantmentPiece"));

        }
        public override void HitEffect(int hitDirection, double damage)
        {
            npc.DropGores(2);
        }

        public override void AI()
        {
            Lighting.AddLight(npc.Center, Color.Violet.ToVector3());
        }
    }

    public class EnchantedSkeleton : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.Skeleton];
        }

        public override void SetDefaults()
        {
            npc.width = 18;
            npc.height = 40;
            npc.damage = 30;
            npc.defense = 8;
            npc.lifeMax = 120;
            npc.HitSound = SoundID.NPCHit2;
            npc.DeathSound = SoundID.NPCDeath2;
            npc.value = 120f;
            npc.knockBackResist = 0.5f;
            npc.aiStyle = 3;
            aiType = NPCID.Skeleton;
            animationType = NPCID.Skeleton;
            banner = Item.NPCtoBanner(NPCID.Skeleton);
            bannerItem = Item.BannerToItem(banner);
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            Player player = spawnInfo.player;
            if (NPC.downedBoss1 || NPC.downedBoss2 || NPC.downedBoss3)
            {
                return SpawnCondition.Cavern.Chance * 0.008f * (Main.hardMode ? 1.3f : 1f);
            }

            return 0f;
        }

        public override void NPCLoot()
        {
            if (Main.rand.NextFloat() < .5f)
                Item.NewItem(npc.getRect(), mod.ItemType("EnchantmentPiece"));
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            npc.DropGores(3);
        }

        public override void AI()
        {
            Lighting.AddLight(npc.Center, Color.Violet.ToVector3());
        }
    }
}