using RBot;

public class Script {
	public ScriptInterface Bot;
	public string[] Items;
	
	public void CheckItemsRequired() {
		foreach ( string item in Items ) {
			if ( Bot.Bank.Contains( item ) )
				Bot.Bank.ToInventory( item );
		}
	}
	
	public void CheckQuests() {
		if ( Bot.Quests.CanComplete( 2178 ) )
			Bot.Quests.EnsureComplete( 2178, -1, false, 5 );
		
		Bot.Quests.EnsureAccept( 2178 );
		
		Bot.Sleep( 1000 );
	}
	
	public void ScriptMain( ScriptInterface bot ){
		Bot = bot;
		Items = new string[] {
			"Bone Dust",
			"Spirit Orb",
			"Undead Energy",
			"Undead Essence",
			"Bliding Aura",
			"Bright Aura",
			"Blinding Light Fragments"
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
		bot.Drops.Add( "Bliding Aura" );
		bot.Drops.Add( "Bright Aura" );
		bot.Drops.Add( "Blinding Light Fragments" );
		bot.Drops.Start();
		bot.Player.LoadBank();
		CheckItemsRequired();
		
		while ( ! bot.ShouldExit() ) {
			if ( bot.Map.Name != "battleunderb" )
				bot.Player.Join( "battleunderb" );
			
			bot.Player.Hunt( "Skeleton Warrior|Skeleton Fighter|Undead Champion" );
			Bot.Sleep( 1750 );
			CheckItemsRequired();
			CheckQuests();
		}
	}
}