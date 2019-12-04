using RBot;

public class Script {
	public string[] monstersName = {
		"Slugfit",
		"Fire Imp",
		"Dark Makai",
		"Cyclops Warlord",
		"Big Bad Boar"
	};
	public string[] itemsName = {
		"Slugfit Horn",
		"Imp Flame",
		"Makai Fang",
		"Cyclops Horn",
		"Wereboar Tusk"
	};
	public string[] mapsName = {
		"mobius",
		"mobius",
		"evilmarsh",
		"faerie",
		"greenguardwest"
	};
	public string[] itemQuantities = {
		"5",
		"3",
		"5",
		"3",
		"2"
	};
	
	public void ScriptMain(ScriptInterface bot){
		bot.Options.SafeTimings = true;
		bot.Options.RestPackets = true;
		bot.Options.ExitCombatBeforeQuest = true;
		bot.Options.InfiniteRange = true;
		
		bot.Player.LoadBank();
		
		bot.Drops.Add("Dark Crystal Shard");
		bot.Drops.Add("Diamond of Nulgath");
		bot.Drops.Add("Unidentified 13");
		bot.Drops.Add("Tainted Gem");
		bot.Drops.Add("Voucher of Nulgath");
		bot.Drops.Add("Voucher of Nulgath (non-mem)");
		bot.Drops.Add("Totem of Nulgath");
		bot.Drops.Add("Gem of Nulgath");
		bot.Drops.Add("Fiend Token");
		bot.Drops.Add("Blood Gem of the Archfiend");
		bot.Drops.Add("Archfiend's Birthday Cake");
		bot.Drops.Add("Fiendish Caladbolg");
		bot.Drops.Start();
		
		bot.Skills.Add(1, 1);
		bot.Skills.Add(2, 1);
		bot.Skills.Add(3, 1);
		bot.Skills.Add(4, 1);
		bot.Skills.StartTimer();
		
		foreach (string dropName in bot.Drops.Pickup) {
			if (bot.Bank.Contains(dropName)) {
				bot.Bank.ToInventory(dropName);
				bot.Sleep(1000);
			}
		}
		
		while (true) {
			if (bot.Quests.CanComplete(6183)) {
				bot.Quests.EnsureComplete(6183);
			}
			
			bot.Quests.EnsureAccept(6183);
			
			for (int i = 0; i < monstersName.Length; i++) {
				string monsterName = monstersName[i];
				string mapName = mapsName[i];
				string itemName = itemsName[i];
				int itemQuantity = int.Parse(itemQuantities[i]);
				
				if (!bot.Inventory.ContainsTempItem(itemName, itemQuantity)) {
					if (bot.Map.Name != mapName) {
						bot.Player.Join(mapName);
					}
					
					bot.Player.HuntForItem(monsterName, itemName, itemQuantity, true);
					
					bot.Player.Jump("Enter", "Spawn");
					bot.Sleep(2000);
				}
			}
		}
	}
}
