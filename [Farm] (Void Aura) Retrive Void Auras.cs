using RBot;

public class Script {
	public string[] monstersName = {
		"Astral Ephemerite",
		"Belrot the Fiend",
		"Black Knight",
		"Tiger Leech",
		"Carnax",
		"Chaos Vordred",
		"Dai Tengu",
		"Unending Avatar",
		"Void Dragon",
		"Creature Creation"
	};
	public string[] mapsName = {
		"timespace",
		"citadel",
		"greenguardwest",
		"mudluk",
		"aqlesson",
		"necrocavern",
		"hachiko",
		"timevoid",
		"dragonchallenge",
		"maul"
	};
	public string farmedItemName = "Void Aura";
	public int farmedItemMaxStacks = 7500;
		
	public void ScriptMain(ScriptInterface bot) {
		bot.Options.SafeTimings = true;
		bot.Options.RestPackets = true;
		bot.Options.ExitCombatBeforeQuest = true;
		bot.Options.InfiniteRange = true;
		
		bot.Player.LoadBank();
		
		bot.Skills.Add(1, 1);
		bot.Skills.Add(2, 1);
		bot.Skills.Add(3, 1);
		bot.Skills.Add(4, 1);
		bot.Skills.StartTimer();
		
		bot.Drops.Add("Void Aura");
		bot.Drops.Start();
		
		foreach (string name in monstersName) {
			string itemName = name + " Essence";
			
			if (bot.Bank.Contains(itemName)) {
				bot.Bank.ToInventory(itemName);
				bot.Sleep(1000);
			}
		}
		
		if (bot.Bank.Contains(farmedItemName)) {
			bot.Bank.ToInventory(farmedItemName);
		}
		
		bot.Quests.EnsureAccept(4432);
		
		while (!bot.Inventory.Contains(farmedItemName, farmedItemMaxStacks)) {
			for (int i = 0; i < mapsName.Length; i++ ) {
				string mapName = mapsName[i];
				string monsterName = monstersName[i];
				string itemName = monsterName + " Essence";
				int itemQuantity = 20;
				
				if (!bot.Inventory.Contains(itemName, itemQuantity)) {
					if (bot.Map.Name != mapName) {
						bot.Player.Join(mapName);
					}
					
					bot.Player.HuntForItem(monsterName, itemName, itemQuantity);
				}
				
				if (bot.Quests.CanComplete(4432)) {
					bot.Quests.EnsureComplete(4432);
					bot.Quests.EnsureAccept(4432);
				}
			}
		}
	}
}
