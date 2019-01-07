using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace Maggic.Items.Spells
{
	public class SpellTeleportation : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spell: Teleportation");
			Tooltip.SetDefault("Has some unpredictable side effects");
		}
		
		public override void SetDefaults()
		{
			item.width = 36;
			item.height = 36;
			item.rare = 7;
			item.mana = 50;
			item.useTime = 50;
			item.useAnimation = item.useTime;
			item.useStyle = 5;
			item.noUseGraphic = true;
		}

		public override bool UseItem(Player player)
		{
			if (item.owner == player.whoAmI)
			{
				int chance = player.statDefense > 70 ? 4 : 2;
				player.TeleportationPotion();
				player.AddBuff(BuffID.ChaosState, 600);

				if (player.chaosState)
				{
					player.statLife -= player.statLifeMax / 6;

					if (player.statLife <= 0)
					{
						player.KillMe(PlayerDeathReason.ByCustomReason(player.name + " didn't materialize"), 0, 0);
					}
				}

				if (Main.rand.Next(chance) == 0)
				{
					if (!NPC.downedAncientCultist)
						player.AddBuff(BuffID.Darkness, Main.rand.Next(300, 1800));
					else player.AddBuff(BuffID.Blackout, Main.rand.Next(120, 600));
				}
			}
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "SpellScroll");
			recipe.AddIngredient(ItemID.TeleportationPotion, 20);
			recipe.AddIngredient(ItemID.CrystalShard,30);
			recipe.AddTile(mod.TileType("EnchantedTable_Tile"));
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}