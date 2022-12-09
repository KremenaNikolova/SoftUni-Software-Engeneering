using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
    public class WarController
    {
        private List<Character> characters;
        private List<Item> items;
        public WarController()
        {
            characters = new List<Character>();
            items = new List<Item>();
        }

        public string JoinParty(string[] args)
        {
            string charackterType = args[0];
            string name = args[1];

            Character character;
            switch (charackterType)
            {
                case "Warrior": character = new Warrior(name); break;
                case "Priest": character = new Priest(name); break;
                default: throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType, charackterType));
            }

            characters.Add(character);
            return string.Format(SuccessMessages.JoinParty, name);
        }

        public string AddItemToPool(string[] args)
        {
            string name = args[0];

            Item item;
            switch (name)
            {
                case "FirePotion": item = new FirePotion(); break;
                case "HealthPotion": item = new HealthPotion(); break;
                default: throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem, name));
            }

            items.Add(item);
            return string.Format(SuccessMessages.AddItemToPool, name);
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];

            var character = characters.FirstOrDefault(x => x.Name == characterName);
            if (character == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }
            if (!items.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);
            }
            var item = items.Last();
            character.Bag.AddItem(item);
            items.Remove(item);

            return string.Format(SuccessMessages.PickUpItem, characterName, item.GetType().Name);

        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];
            var character = characters.FirstOrDefault(x => x.Name == characterName);
            if (character == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }
            if (!character.Bag.Items.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyBag);
            }

            var item = character.Bag.Items.FirstOrDefault(x => x.GetType().Name == itemName);
            if (item == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ItemNotFoundInBag, itemName));
            }

            character.UseItem(item);
            return string.Format(SuccessMessages.UsedItem, characterName, itemName);

        }

        public string GetStats()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var hero in characters.OrderByDescending(x => x.IsAlive).ThenByDescending(x => x.Health))
            {
                string aliveOrDead = hero.IsAlive ? "Alive" : "Dead";
                sb.AppendLine($"{hero.Name} - HP: {hero.Health}/{hero.BaseHealth}, AP: {hero.Armor}/{hero.BaseArmor}, Status: {aliveOrDead}");
            }

            return sb.ToString().TrimEnd();
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string receiverName = args[1];

            var attacker = characters.FirstOrDefault(x => x.Name == attackerName);
            var receiver = characters.FirstOrDefault(x => x.Name == receiverName);
            if (attacker == null || receiver == null)
            {
                string nullCharackter = attacker == null ? attackerName : receiverName;
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, nullCharackter));
            }
            if (!receiver.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
            if (attacker is Priest)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.AttackFail, attacker.Name));
            }
            Warrior warrior = (Warrior)attacker;
            warrior.Attack(receiver);

            string output = receiver.IsAlive
                ? string.Format(SuccessMessages.AttackCharacter, attackerName, receiverName, attacker.AbilityPoints, receiverName, receiver.Health, receiver.BaseHealth, receiver.Armor, receiver.BaseArmor)
                : string.Format(SuccessMessages.AttackCharacter, attackerName, receiverName, attacker.AbilityPoints, receiverName, receiver.Health, receiver.BaseHealth, receiver.Armor, receiver.BaseArmor) 
                + Environment.NewLine
                + string.Format(SuccessMessages.AttackKillsCharacter, receiverName);

            return output;
        }

        public string Heal(string[] args)
        {
            string healerName = args[0];
            string healerReceiverName = args[1];

            var healer = characters.FirstOrDefault(x => x.Name == healerName);
            var healerReceiver = characters.FirstOrDefault(x => x.Name == healerReceiverName);
            if (healer == null || healerReceiver == null)
            {
                string nullCharackter = healer == null ? healerName : healerReceiverName;
                throw new ArgumentException(ExceptionMessages.CharacterNotInParty, nullCharackter);
            }
            if (healer is Warrior)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.HealerCannotHeal, healerName));
            }
            Priest priest = (Priest)healer;
            priest.Heal(healerReceiver);

            return string.Format(SuccessMessages.HealCharacter, healerName, healerReceiverName, healer.AbilityPoints, healerReceiverName, healerReceiver.Health);

        }
    }
}
