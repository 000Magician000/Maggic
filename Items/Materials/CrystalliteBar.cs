using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.ObjectData;
using Microsoft.Xna.Framework;

namespace Maggic.Items.Materials
{
    public class CrystalliteBar : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 38;
            item.height = 32;
            item.rare = 5;
            item.maxStack = 99;
            item.value = Item.sellPrice(silver:50);
            item.createTile = mod.TileType("CrystalliteBar_Tile");
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HallowedBar);
            recipe.AddIngredient(ItemID.CrystalShard, 2);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }

    public class CrystalliteBar_Tile : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileSolidTop[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
            TileObjectData.newTile.Height = 1;
            TileObjectData.newTile.CoordinateHeights = new[]{16};
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleWrapLimit = 111;
            TileObjectData.addTile(Type);
            drop = mod.ItemType("CrystalliteBar");
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Metal Bar");
            AddMapEntry(new Color(224, 194, 101), name);
            Main.tileShine[Type] = 1100;
            Main.tileSolid[Type] = true;
            dustType = DustID.PurpleCrystalShard;
        }
    }
}