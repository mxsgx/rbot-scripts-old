using RBot;

public class Script {
	public ScriptInterface Bot;
	
	public void CheckQuests() {
		if ( Bot.Quests.CanComplete( 1682 ) )
			Bot.Quests.EnsureComplete( 1682, -1, false, 5 );
		
		Bot.Quests.EnsureAccept( 1682 );
	}
	
	public void CheckRequiredItems() {
		if ( Bot.Bank.Contains( "Fishing Dynamite" ) )
			Bot.Bank.ToInventory( "Fishing Dynamite" );
	}
	
	public void ScriptMain( ScriptInterface bot ){
		Bot = bot;
		bot.Options.SafeTimings = true;
		bot.Options.RestPackets = true;
		bot.Options.ExitCombatBeforeQuest = true;
		bot.Options.InfiniteRange = true;
		bot.Drops.RejectElse = true;
		
		bot.Skills.Add( 1, 1 );
		bot.Skills.Add( 2, 1 );
		bot.Skills.Add( 3, 1 );
		bot.Skills.Add( 4, 1 );
		bot.Skills.StartTimer();
		bot.Drops.Add( "Fishing Bait" );
		bot.Drops.Add( "Fishing Dynamite" );
		bot.Drops.Start();
		
		bot.Player.LoadBank();
		CheckRequiredItems();
		CheckQuests();
		
		while ( ! bot.ShouldExit() ) {
			if ( bot.Map.Name != "greenguardwest" )
				bot.Player.Join( "greenguardwest" );
			
			bot.Player.HuntForItem( "Slime", "Faith's Fi'shtick", 1, true, false );
			CheckQuests();
		}
	}
}
