using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Maggic.Items.Blocks
{
    public class EnchantmentTable : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Enchantment Table");
            Tooltip.SetDefault("Allows you to craft strong magical items");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.maxStack = 99;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.rare = 4;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.createTile = mod.TileType("EnchantedTable_Tile");
        }
        
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("CrystalliteBar"),18);
            recipe.AddIngredient(mod.ItemType("EnchantmentPiece"));
            recipe.AddIngredient(ItemID.SpellTome);
            recipe.AddTile(TileID.MythrilAnvil);	
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
    
    public class EnchantedTable_Tile : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
            TileObjectData.newTile.Height = 2;
            TileObjectData.newTile.Width = 3;
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Enchantment Table");
            AddMapEntry(Color.Violet, name);
            disableSmartCursor = true;
            dustType = 255;
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 32, 48, mod.ItemType("EnchantmentTable"));
        }
    }
}