using RBot;

public class Script {

	public void ScriptMain( ScriptInterface bot ){
		bot.Options.SafeTimings = true;
		bot.Options.RestPackets = true;
		bot.Options.ExitCombatBeforeQuest = true;
		bot.Options.InfiniteRange = true;
		
		bot.Drops.Add( "Basic Weapon Kit" );
		bot.Drops.Start();
		bot.Skills.Add( 1, 1 );
		bot.Skills.Add( 2, 1 );
		bot.Skills.Add( 3, 1 );
		bot.Skills.Add( 4, 1 );
		bot.Skills.StartTimer();
		
		while ( ! bot.ShouldExit() ) {
			bot.Quests.EnsureAccept( 2136 );
			
			if ( ! bot.Inventory.Contains( "Zardman's StoneHammer" ) ) {
				if ( bot.Map.Name != "forest" )
					bot.Player.Join( "forest" );
				
				bot.Player.HuntForItem( "Zardman Grunt", "Zardman's StoneHammer", 1 );
				bot.Player.Jump( "Enter", "Spawn" );
				bot.Sleep( 750 );
			}
			if ( ! bot.Inventory.ContainsTempItem( "Triple Ply Mummy Wrap", 7 ) ) {
				if ( bot.Map.Name != "pyramid" )
					bot.Player.Join( "pyramid" );
				
				bot.Player.HuntForItem( "Mummy|Golden Scarab", "Triple Ply Mummy Wrap", 7, true );
				bot.Player.Jump( "Enter", "Spawn" );
				bot.Sleep( 750 );
			}
			if ( ! bot.Inventory.ContainsTempItem( "Golden Lacquer Finish" ) ) {
				if ( bot.Map.Name != "pyramid" )
					bot.Player.Join( "pyramid" );
				
				bot.Player.HuntForItem( "Golden Scarab", "Golden Lacquer Finish", 1, true );
				bot.Player.Jump( "Enter", "Spawn" );
				bot.Sleep( 750 );
			}
			if ( ! bot.Inventory.ContainsTempItem( "Noob Blade Oil" ) ) {
				if ( bot.Map.Name != "noobshire" )
					bot.Player.Join( "noobshire" );
				
				bot.Player.HuntForItem( "Horc Noob", "Noob Blade Oil", 1, true );
				bot.Player.Jump( "Enter", "Spawn" );
				bot.Sleep( 750 );
			}
			if ( ! bot.Inventory.ContainsTempItem( "Bronze Brush" ) ) {
				if ( bot.Map.Name != "lair" )
					bot.Player.Join( "lair" );
				
				bot.Player.HuntForItem( "Bronze Draconian", "Bronze Brush", 1, true );
				bot.Player.Jump( "Enter", "Spawn" );
				bot.Sleep( 750 );
			}
			if ( ! bot.Inventory.ContainsTempItem( "Rocky Stone Sharpener" ) ) {
				if ( bot.Map.Name != "bloodtusk" )
					bot.Player.Join( "bloodtusk" );
				
				bot.Player.HuntForItem( "Rock", "Rocky Stone Sharpener", 1, true );
				bot.Player.Jump( "Enter", "Spawn" );
				bot.Sleep( 750 );
			}
			if ( ! bot.Inventory.ContainsTempItem( "Burlap Cloth" ) ) {
				if ( bot.Map.Name != "farm" )
					bot.Player.Join( "farm" );
				
				bot.Player.HuntForItem( "Scarecrow", "Burlap Cloth", 4, true );
				bot.Player.Jump( "Enter", "Spawn" );
				bot.Sleep( 750 );
			}
			
			if ( bot.Quests.CanComplete( 2136 ) )
				bot.Quests.EnsureComplete( 2136, -1, false, 5 );
		}
	}
}
