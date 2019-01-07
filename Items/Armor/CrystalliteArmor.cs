using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
namespace Maggic.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class CrystalliteHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("5% increased magic damage and critical strike chance");
        }
        public override void SetDefaults()
        {
            item.width = 36;
            item.height = 36;
            item.defense = 19;
            item.rare = 11;
        }

        public override void UpdateEquip(Player player)
        {
            player.magicDamage *= 1.05f;
            player.magicCrit *= (int)1.05;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("CrystalliteBreastplate") && legs.type == mod.ItemType("CrystalliteLeggings");
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "5% reduced mana usage\nMagic damage done to enemies heals the player with the lowest health\nMagic damage done will damage extra nearby enemies\nCauses stars to fall when injured";
            player.starCloak = true;
            player.manaCost *= 0.95f;
            player.ghostHeal = true;
            player.ghostHurt = true;
            player.statManaMax2 += player.statManaMax2/2;
            player.statLifeMax2 += player.statLifeMax2/5;
            player.GetModPlayer<MaggicPlayer>(mod).CrystalliteSet = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.NebulaHelmet);
            recipe.AddIngredient(ItemID.SpectreMask);
            recipe.AddIngredient(mod.ItemType("CrystalliteBar"),10);
            recipe.AddTile(mod.TileType("EnchantedTable_Tile"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
    
    [AutoloadEquip(EquipType.Body)]
    public class CrystalliteBreastplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("8% increased magic damage and critical strike chance");
        }
        public override void SetDefaults()
        {
            item.width = 36;
            item.height = 36;
            item.defense = 23;
            item.rare = 11;
        }

        public override void UpdateEquip(Player player)
        {
            player.magicDamage *= 1.08f;
            player.magicCrit *= (int)1.08;
        }
        
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.NebulaBreastplate);
            recipe.AddIngredient(ItemID.SpectreRobe);
            recipe.AddIngredient(mod.ItemType("CrystalliteBar"),12);
            recipe.AddTile(mod.TileType("EnchantedTable_Tile"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
    
    [AutoloadEquip(EquipType.Legs)]
    public class CrystalliteLeggings : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("5% increased magic damage and critical strike chance");
        }
        public override void SetDefaults()
        {
            item.width = 36;
            item.height = 36;
            item.defense = 19;
            item.rare = 11;
        }

        public override void UpdateEquip(Player player)
        {
            player.magicDamage *= 1.05f;
            player.magicCrit *= (int)1.05;
        }
        
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.NebulaLeggings);
            recipe.AddIngredient(ItemID.SpectrePants);
            recipe.AddIngredient(mod.ItemType("CrystalliteBar"),8);
            recipe.AddTile(mod.TileType("EnchantedTable_Tile"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}