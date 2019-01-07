using System;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;

namespace Maggic.NPCs.Element
{
    class JungleZombie : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.Zombie];
        }

        public override void SetDefaults()
        {
            npc.width = 26;
            npc.height = 46;
            npc.damage = 15;
            npc.defense = 8;
            npc.lifeMax = 60;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath2;
            npc.value = 80f;
            npc.knockBackResist = 0.5f;
            npc.aiStyle = 3;
            aiType = NPCID.Zombie;
            animationType = NPCID.Zombie;
            banner = npc.type;
            bannerItem = mod.ItemType("BannerJungleZombie");
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            Player player = spawnInfo.player;
            if (player.ZoneJungle && !Main.dayTime)
            {
                return 0.05f;
            }
            return 0f;
        }

        public override void NPCLoot()
        {
            if (Helper.TryChance(0.004f))
            {
                Item.NewItem(npc.getRect(), ItemID.ZombieArm);
            }
            if (Helper.TryChance(0.02f))
            {
                Item.NewItem(npc.getRect(),ItemID.Shackle);
            }
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            npc.DropGores(3);
            for (int i = 0; i < 8; i++)
                Dust.NewDust(npc.Center, 0, 0, DustID.Blood);
        }
    }
}
