using RBot;

public class Script {
	public ScriptInterface Bot;
	
	public void CheckItemsRequired() {
		if ( Bot.Bank.Contains( "Legion Token" ) )
			Bot.Bank.ToInventory( "Legion Token" );
	}
	
	public void CheckQuests() {
		if ( Bot.Quests.CanComplete( 3021 ) )
			Bot.Quests.EnsureComplete( 3021 );
		
		Bot.Quests.EnsureAccept( 3021 );
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
		bot.Drops.Add( "Legion Token" );
		bot.Drops.Start();
		bot.Player.LoadBank();
		CheckItemsRequired();
		CheckQuests();
		
		while ( bot.Inventory.GetQuantity( "Legion Token" ) < 25000 ) {
			bot.Options.PrivateRooms = false;
			
			if ( bot.Map.Name != "battleunderb" )
				bot.Player.Join( "battleunderb" );
			
			bot.Player.HuntForItem( "Undead Champion", "Champion Head", 13, true );
			
			bot.Options.PrivateRooms = true;
			
			if ( bot.Map.Name != "battleundera" )
				bot.Player.Join( "battleundera" );
			
			bot.Player.HuntForItem( "Angry Undead Giant", "Undead Head", 1, true );
			CheckQuests();
		}
	}
}
