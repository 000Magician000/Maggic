using System;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;

namespace Maggic.NPCs.Element
{
    class ShamanZombie : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.Zombie];
        }

        public override void SetDefaults()
        {
            npc.width = 26;
            npc.height = 46;
            npc.damage = 50;
            npc.defense = 24;
            npc.lifeMax = 320;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath2;
            npc.value = 420f;
            npc.knockBackResist = 0.4f;
            npc.aiStyle = 3;
            aiType = NPCID.Zombie;
            animationType = NPCID.Zombie;
            banner = npc.type;
            bannerItem = mod.ItemType("BannerShamanZombie");
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            Player player = spawnInfo.player;
            if (player.ZoneJungle && !Main.dayTime && Main.hardMode)
            {
                return 0.003f;
            }
            return 0f;
        }

        public override void NPCLoot()
        {
            if (Helper.TryChance(0.01f))
                Item.NewItem(npc.getRect(), ItemID.FeralClaws);
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            npc.DropGores(4);
            for (int i = 0; i < 8; i++)
                Dust.NewDust(npc.Center, 0, 0, DustID.Blood);
        }
    }
}