using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace Maggic.Items.Armor.Vanity
{
    [AutoloadEquip(EquipType.Body)]
    public class DarkRobe : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 28;
            item.rare = 1;
            item.vanity = true;
            item.value = Item.sellPrice(silver: 50);
        }

        public override void UpdateVanity(Player player, EquipType type)
        {
            Lighting.AddLight(player.Center, Color.DarkViolet.ToVector3() * 0.6f * Main.essScale);
        }

        public override void DrawHands(ref bool drawHands, ref bool drawArms)
        {
            drawArms = false;
            drawHands = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Silk, 20);
            recipe.AddIngredient(mod.ItemType("CorruptThread"), 3);
            recipe.AddTile(TileID.Loom);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }

    [AutoloadEquip(EquipType.Body)]
    public class DarkRobeCrimson : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dark Robe");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 28;
            item.rare = 1;
            item.vanity = true;
            item.value = Item.sellPrice(silver: 50);
        }

        public override void DrawHands(ref bool drawHands, ref bool drawArms)
        {
            drawArms = false;
            drawHands = true;
        }

        public override void UpdateVanity(Player player, EquipType type)
        {
            Lighting.AddLight(player.Center, Color.DarkRed.ToVector3() * 0.6f * Main.essScale);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Silk,20);
            recipe.AddIngredient(mod.ItemType("BloodyThread"), 3);
            recipe.AddTile(TileID.Loom);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }

    public class CorruptThread : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 20;
            item.rare = 0;
            item.value = Item.buyPrice(gold: 1);
            item.maxStack = 99;
        }
    }

    public class BloodyThread : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 20;
            item.rare = 0;
            item.value = Item.buyPrice(gold: 1);
            item.maxStack = 99;
        }
    }
}