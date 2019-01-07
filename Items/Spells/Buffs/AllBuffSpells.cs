using Terraria.ID;

namespace Maggic.Items.Spells.Buffs
{
    public class SpellBuffAmmo : BuffSpell
    {
        public override int Buff
        {
            get { return BuffID.AmmoReservation; }
        }

        public override void SpellRecipe()
        {
            Recipe.AddIngredient(ItemID.DoubleCod, 5);
            Recipe.AddIngredient(ItemID.Moonglow, 5);
        }
    }

    public class SpellBuffArchery : BuffSpell
    {
        public override int Buff
        {
            get { return BuffID.Archery; }
        }

        public override void SpellRecipe()
        {
            Recipe.AddIngredient(ItemID.Daybloom, 5);
            Recipe.AddIngredient(ItemID.Lens, 5);
        }
    }

    public class SpellBuffDanger : BuffSpell
    {
        public override int Buff
        {
            get { return BuffID.Dangersense; }
        }

        public override void SpellRecipe()
        {
            Recipe.AddIngredient(ItemID.Shiverthorn, 5);
            Recipe.AddIngredient(ItemID.Cobweb, 50);
        }
    }

    public class SpellBuffEndurance : BuffSpell
    {
        public override int Buff
        {
            get { return BuffID.Endurance; }
        }

        public override void SpellRecipe()
        {
            Recipe.AddIngredient(ItemID.ArmoredCavefish, 5);
            Recipe.AddIngredient(ItemID.Blinkroot, 5);
        }
    }

    public class SpellBuffFeaterfall : BuffSpell
    {
        public override int Buff
        {
            get { return BuffID.Featherfall; }
        }

        public override void SpellRecipe()
        {
            Recipe.AddIngredient(ItemID.Daybloom, 5);
            Recipe.AddIngredient(ItemID.Blinkroot, 5);
            Recipe.AddIngredient(ItemID.Feather, 5);
        }
    }

    public class SpellBuffGills : BuffSpell
    {
        public override int Buff
        {
            get { return BuffID.Gills; }
        }


        public override void SpellRecipe()
        {
            Recipe.AddIngredient(ItemID.Waterleaf, 5);
            Recipe.AddIngredient(ItemID.Coral, 5);
        }
    }

    public class SpellBuffGravity : BuffSpell
    {
        public override int Buff
        {
            get { return BuffID.Gravitation; }
        }

        public override void SpellRecipe()
        {
            Recipe.AddIngredient(ItemID.Fireblossom, 5);
            Recipe.AddIngredient(ItemID.Deathweed, 5);
            Recipe.AddIngredient(ItemID.Blinkroot, 5);
            Recipe.AddIngredient(ItemID.Feather, 5);
        }
    }

    public class SpellBuffHunter : BuffSpell
    {
        public override int Buff
        {
            get { return BuffID.Hunter; }
        }

        public override void SpellRecipe()
        {
            Recipe.AddIngredient(ItemID.Daybloom, 5);
            Recipe.AddIngredient(ItemID.Blinkroot, 5);
            Recipe.AddIngredient(ItemID.SharkFin, 5);
        }
    }

    public class SpellBuffInferno : BuffSpell
    {
        public override int Buff
        {
            get { return BuffID.Inferno; }
        }

        public override void SpellRecipe()
        {
            Recipe.AddIngredient(ItemID.FlarefinKoi, 5);
            Recipe.AddIngredient(ItemID.Obsidifish, 10);
            Recipe.AddIngredient(ItemID.Fireblossom, 5);
        }
    }
    public class SpellBuffIronskin : BuffSpell
    {
        public override int Buff
        {
            get { return BuffID.Ironskin; }
        }

        public override void SpellRecipe()
        {
            Recipe.AddIngredient(ItemID.Daybloom, 5);
            Recipe.AddRecipeGroup("Maggic:IronLeadOres", 5);
        }
    }

    public class SpellBuffLifeforce : BuffSpell
    {
        public override int Buff
        {
            get { return BuffID.Lifeforce; }
        }

        public override void SpellRecipe()
        {
            Recipe.AddIngredient(ItemID.Prismite, 5);
            Recipe.AddIngredient(ItemID.Moonglow, 5);
            Recipe.AddIngredient(ItemID.Shiverthorn, 5);
            Recipe.AddIngredient(ItemID.Waterleaf, 5);
        }
    }

    public class SpellBuffRage : BuffSpell
    {
        public override int Buff
        {
            get { return BuffID.Rage; }
        }

        public override void SpellRecipe()
        {
            Recipe.AddIngredient(ItemID.Hemopiranha, 5);
            Recipe.AddIngredient(ItemID.Deathweed, 5);
        }
    }

    public class SpellBuffRegeneration : BuffSpell
    {
        public override int Buff
        {
            get { return BuffID.Regeneration; }
        }

        public override void SpellRecipe()
        {
            Recipe.AddIngredient(ItemID.Daybloom, 5);
            Recipe.AddIngredient(ItemID.Mushroom, 5);
        }
    }

    public class SpellBuffSwiftness : BuffSpell
    {
        public override int Buff
        {
            get { return BuffID.Swiftness; }
        }

        public override void SpellRecipe()
        {
            Recipe.AddIngredient(ItemID.Blinkroot, 5);
            Recipe.AddIngredient(ItemID.Cactus, 5);
        }
    }

    public class SpellBuffThorns : BuffSpell
    {
        public override int Buff
        {
            get { return BuffID.Thorns; }
        }

        public override void SpellRecipe()
        {
            Recipe.AddIngredient(ItemID.Deathweed, 5);
            Recipe.AddIngredient(ItemID.Cactus, 5);
            Recipe.AddIngredient(ItemID.Stinger, 5);
            Recipe.AddIngredient(ItemID.WormTooth, 5);
        }
    }
}