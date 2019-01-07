using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System.Text;

namespace Maggic
{
	//PLAYER============================================================================================================
	public class MaggicPlayer : ModPlayer
	{
		public bool Dyslexia;
		public int BuffSpellTime = 3600;
		public int BuffSpellDyslexia = 7200;
		public bool ManaFullSpec, LifeFullSpec;
		
		public bool CrystalliteSet;
		private float _crystalliteSetAngle = 0f;
		private const float CrystalliteSetSpeed=0.025f;

		public override void ResetEffects()
		{
			Dyslexia = false;
			ManaFullSpec = false;
			LifeFullSpec = false;
			
			if (!CrystalliteSet)
			{
				_crystalliteSetAngle = 0f;
			}
			CrystalliteSet = false;
		}

		public override void DrawEffects(PlayerDrawInfo drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright)
		{
			if (player.GetModPlayer<MaggicPlayer>(mod).CrystalliteSet && player.active)
			{
				if (_crystalliteSetAngle < MathHelper.TwoPi)
					_crystalliteSetAngle += CrystalliteSetSpeed;
				else _crystalliteSetAngle = 0f;
				Vector2 position = new Vector2(player.Center.X,player.Center.Y)-Main.screenPosition;
				Texture2D texture = mod.GetTexture("Items/Armor/CrystalliteCircle");
				DrawData data = new DrawData(texture, position, null, Color.White, _crystalliteSetAngle, new Vector2(texture.Width/2,texture.Height/2), 0.5f, SpriteEffects.None, 0);
				Main.playerDrawData.Add(data);
            }
            
		}
	}

    //WORLD============================================================================================================
    public class MaggicWorld : ModWorld
    {
        public override void PostWorldGen()
        {
            int[] items = { mod.ItemType("VitalityAmulet"), mod.ItemType("ManapowerAmulet") };
            int[] items2 = { mod.ItemType("LeafStaff") };
            int choose = 0;
            for (int chestIndex = 0; chestIndex < 1000; chestIndex++)
            {
                Chest chest = Main.chest[chestIndex];
                if (Main.rand.NextFloat() < 0.1)
                {
                    if (chest != null && Main.tile[chest.x, chest.y].type == TileID.Containers &&
                        Main.tile[chest.x, chest.y].frameX == 2 * 36)
                    {
                        for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
                        {
                            if (chest.item[inventoryIndex].type == 0)
                            {
                                chest.item[inventoryIndex].SetDefaults(items[choose]);
                                choose = (choose + 1) % items.Length;
                                break;
                            }
                        }
                    }
                }

                if (Main.rand.NextFloat() < 0.3)
                {
                    if (chest != null && Main.tile[chest.x, chest.y].type == TileID.Containers &&
                        Main.tile[chest.x, chest.y].frameX == 12 * 36)
                    {
                        for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
                        {
                            if (chest.item[inventoryIndex].type == 0)
                            {
                                chest.item[inventoryIndex].SetDefaults(items2[choose]);
                                choose = (choose + 1) % items.Length;
                                break;
                            }
                        }
                    }
                }
            }
        }
    }

    //ITEMS=============================================================================================================
    public class MaggicItems : GlobalItem 
	{
		public override bool CanUseItem(Item item, Player player)
		{
			if (item.type == ItemID.ManaCrystal)
			{
				if (!Main.hardMode)
				{
					if (player.statManaMax < 100)
					return true;
					return false;
				}
			}
			return base.CanUseItem(item, player);
		}
		
		public override bool CanPickup(Item item, Player player) 
		{
			if (player.GetModPlayer<MaggicPlayer>(mod).LifeFullSpec)
			if (item.type == ItemID.Heart || item.type == ItemID.CandyApple || item.type == ItemID.CandyCane) 
			{ 
				return player.statLife < player.statLifeMax2; 
			} 

			if (player.GetModPlayer<MaggicPlayer>(mod).ManaFullSpec)
			if (item.type == ItemID.Star || item.type == ItemID.SoulCake || item.type == ItemID.SugarPlum) 
			{ 
				return player.statMana < player.statManaMax2; 
			} 
			return base.CanPickup(item, player); 
		}

		public override void OpenVanillaBag(string context, Player player, int arg)
		{
			if (context == "bossBag" && arg == ItemID.FishronBossBag)
			{
				if (Helper.TryChance(.3f))
				player.QuickSpawnItem(mod.ItemType("CthulhusTwister"));
			}
		}
	}

    //Projectiles=======================================================================================================

    //NPC===============================================================================================================
    public class MaggicNPC : GlobalNPC 
	{
        public override void SetupShop(int type, Chest shop, ref int nextSlot)
        {
            if (type == NPCID.Merchant && Main.bloodMoon && NPC.downedBoss3)
            {

                shop.item[nextSlot].SetDefaults(mod.ItemType("SpellScroll"));
                nextSlot++;

            }

            if (type == NPCID.Clothier && Main.bloodMoon)
            {
                shop.item[nextSlot].SetDefaults(mod.ItemType(!WorldGen.crimson ? "CorruptThread" : "BloodyThread"));
                nextSlot++;
            }
        }

		public override void NPCLoot(NPC npc)
		{
			if (npc.type == NPCID.Tim)
			{
				if (Helper.TryChance(.08f))
				{
					Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,mod.ItemType("QuickSpellSkyArrows"), Main.rand.Next(4, 8));
				}
			}
			
			if (npc.type == NPCID.Demon)
			{
				if (Helper.TryChance(.05f))
				{
					Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,mod.ItemType("QuickSpellDemonScythe"), Main.rand.Next(4, 12));
				}
			}			
			
			if (npc.type == NPCID.VoodooDemon)
			{
				if (Helper.TryChance(.1f))
				{
					Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,mod.ItemType("QuickSpellDemonScythe"), Main.rand.Next(4, 12));
				}
			}
			
			if (npc.type == NPCID.PinkJellyfish || npc.type == NPCID.GreenJellyfish || npc.type == NPCID.BlueJellyfish)
			{
				if (Helper.TryChance(.2f))
				{
					Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,mod.ItemType("QuickSpellGlow"), Main.rand.Next(3, 6));
				}
			}

			if (npc.type == NPCID.Lavabat || npc.type == NPCID.LavaSlime)
			{
				if (Helper.TryChance(.3f))
				{
					Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
						mod.ItemType("QuickSpellFireFirework"), Main.rand.Next(3, 6));
				}
			}

            if (npc.type == NPCID.FireImp)
            {
                if (Helper.TryChance(.1f))
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height,
                        mod.ItemType("FireImpStaff"));
                }
            }

            //Runes

            int[] nature = {NPCID.Moth,mod.NPCType("ShamanZombie")};
			int[] ice = {mod.NPCType("GiantIceCube"), NPCID.IceGolem};
			int[] fire = {NPCID.RedDevil, mod.NPCType("Phoenix")};
			
			if (nature.Contains(npc.type))
			{
				if (Helper.TryChance(.3f))
					Item.NewItem(npc.getRect(), mod.ItemType("NatureRune"));
			}

			if (ice.Contains(npc.type))
			{
				if (Helper.TryChance(.3f))
					Item.NewItem(npc.getRect(), mod.ItemType("IceRune"));
			}

			if (fire.Contains(npc.type))
			{
				if (Helper.TryChance(.3f))
					Item.NewItem(npc.getRect(), mod.ItemType("FireRune"));
			}
		}
	}
}