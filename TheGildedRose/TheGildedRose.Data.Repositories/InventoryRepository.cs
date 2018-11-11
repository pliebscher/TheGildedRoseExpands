using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TheGildedRose.Data.Models;

namespace TheGildedRose.Data.Repositories
{
    public class InventoryRepository : IInventoryRepository
    {
        private static readonly List<Item> _inventory = new List<Item>();

        static InventoryRepository()
        {
            // Taken from https://en.wikipedia.org/wiki/List_of_mythological_objects
            _inventory.Add(new Item() { Id = Guid.Parse("344DD455-691D-4BBB-89A6-A67588DB3173"), Name = "Chrysaor", Description = "Golden sword of Sir Artegal.", Price = 29.99 });
            _inventory.Add(new Item() { Id = Guid.Parse("344DD455-691D-4BBB-89A6-A67588DB3174"), Name = "Flaming Sword", Description = "Sword glowing with flame by some supernatural power.", Price = 15.95 });
            _inventory.Add(new Item() { Id = Guid.Parse("344DD455-691D-4BBB-89A6-A67588DB3175"), Name = "Orna", Description = "Sword of the Fomorian king Tethra.", Price = 27.75 });
            _inventory.Add(new Item() { Id = Guid.Parse("344DD455-691D-4BBB-89A6-A67588DB3176"), Name = "Aphrodite's Magic Girdle", Description = "A magic material that made whoever the wearer desired fall in love with him/her.", Price = 9.99 });
            _inventory.Add(new Item() { Id = Guid.Parse("344DD455-691D-4BBB-89A6-A67588DB3177"), Name = "Hagoromo", Description = "A colored or feathered kimono of a tennin.", Price = 14.25 });
            _inventory.Add(new Item() { Id = Guid.Parse("344DD455-691D-4BBB-89A6-A67588DB3178"), Name = "Fast-walker Boots", Description = "Allows the person wearing them to walk and run at an amazing pace.", Price = 11.99 });
            _inventory.Add(new Item() { Id = Guid.Parse("344DD455-691D-4BBB-89A6-A67588DB3179"), Name = "Mantle of Arthur", Description = "Invisibility cloak.", Price = 75.00 });
            _inventory.Add(new Item() { Id = Guid.Parse("344DD455-691D-4BBB-89A6-A67588DB3170"), Name = "Robe of the Fire-rat", Description = "A legendary robe of China that is made of the fireproof fur of the fire-rat.", Price = 59.99 });
            _inventory.Add(new Item() { Id = Guid.Parse("344DD455-691D-4BBB-89A6-A67588DB3171"), Name = "Mjölnir", Description = "The magic hammer of Thor.", Price = 99.99 });
            _inventory.Add(new Item() { Id = Guid.Parse("344DD455-691D-4BBB-89A6-A67588DB3172"), Name = "Vasavi Shakti", Description = "The magical dart of Indra.", Price = 11.00 });
            _inventory.Add(new Item() { Id = Guid.Parse("344DD455-691D-4BBB-89A6-A67588DB3183"), Name = "Brísingamen", Description = "The necklace of the goddess Freyja.", Price = 4.95 });
        }

        /// <summary>
        /// Retreives the stores current inventory.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Item> GetInventory()
        {
            return _inventory;
        }

        /// <summary>
        /// Retreives a single item from the inventory.
        /// </summary>
        /// <param name="itemid">The Id of the desired item.</param>
        /// <returns></returns>
        public Item GetItem(Guid itemId)
        {
            if (itemId == Guid.Empty)
                throw new ArgumentNullException("itemId");

            // TODO: Make sure the item exists!

            return _inventory.FirstOrDefault((item) => item.Id == itemId);
        }

    }
}
