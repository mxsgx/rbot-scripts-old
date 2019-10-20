using RBot;

public class Script {
	public ScriptInterface Bot;
	public string[] Items;
	
	public void CheckItemsRequired() {
		foreach ( string item in Items ) {
			if ( Bot.Bank.Contains( item ) )
				Bot.Bank.ToInventory( item );
		}
		
		if ( Bot.Inventory.GetQuantity( "Undead Energy" ) > 1000 ) {
			while ( Bot.Map.Name != "necropolis" ) {
				Bot.Player.Jump( "Enter", "Spawn" );
				Bot.Sleep( 1000 );
				Bot.Player.Join( "necropolis" );
			}
			
			while ( Bot.Inventory.GetQuantity( "Undead Energy" ) > 50 ) {
				Bot.Shops.BuyItem( 422, "Spirit Orb" );
				Bot.Sleep( 1500 );
			}
		}
	}
	
	public void CheckQuests() {
		if ( Bot.Quests.CanComplete( 2082 ) )
			Bot.Quests.EnsureComplete( 2082, -1, false, 5 );
		
		if ( Bot.Quests.CanComplete( 2083 ) )
			Bot.Quests.EnsureComplete( 2083, -1, false, 5 );
		
		Bot.Quests.EnsureAccept( 2082 );
		Bot.Quests.EnsureAccept( 2083 );
		
		Bot.Sleep( 1000 );
	}
	
	public void ScriptMain( ScriptInterface bot ){
		Bot = bot;
		Items = new string[] {
			"Bone Dust",
			"Spirit Orb",
			"Undead Energy",
			"Undead Essence"
		};
		bot.Options.SafeTimings = true;
		bot.Options.RestPackets = true;
		bot.Options.InfiniteRange = true;
		bot.Options.ExitCombatBeforeQuest = true;
		bot.Drops.RejectElse = true;

		bot.Skills.Add( 1, 1 );
		bot.Skills.Add( 2, 1 );
		bot.Skills.Add( 3, 1 );
		bot.Skills.Add( 4, 1 );
		bot.Skills.StartTimer();
		
		bot.Drops.Add( "Spirit Orb" );
		bot.Drops.Add( "Undead Energy" );
		bot.Drops.Add( "Undead Essence" );
		bot.Drops.Add( "Bone Dust" );
		bot.Drops.Start();
		bot.Player.LoadBank();
		CheckItemsRequired();
		
		while ( bot.Inventory.GetQuantity( "Spirit Orb" ) < 65000 ) {
			if ( bot.Map.Name != "battleunderb" )
				bot.Player.Join( "battleunderb" );
			
			bot.Player.Hunt( "Skeleton Warrior|Skeleton Fighter|Undead Champion" );
			Bot.Sleep( 1750 );
			CheckItemsRequired();
			CheckQuests();
		}
	}
}
