using RBot;

public class Script {

	public void ScriptMain( ScriptInterface bot ){
		bot.Options.SafeTimings = true;
		bot.Options.RestPackets = true;
		bot.Options.ExitCombatBeforeQuest = true;
		bot.Options.InfiniteRange = true;
		bot.Options.SkipCutsenes = true;
		
		bot.Drops.Add( "Ultimate Weapon Kit" );
		bot.Drops.Add( "Loyal Spirit Orb" );
		bot.Drops.Add( "Bright Aura" );
		bot.Drops.Add( "Spirit Orb" );
		bot.Drops.Start();
		bot.Skills.Add( 1, 1 );
		bot.Skills.Add( 2, 1 );
		bot.Skills.Add( 3, 1 );
		bot.Skills.Add( 4, 1 );
		bot.Skills.StartTimer();
		
		while ( ! bot.ShouldExit() ) {
			bot.Quests.EnsureAccept( 2163 );
			
			if ( ! bot.Inventory.ContainsTempItem( "No. 1337 Blade Oil" ) ) {
				if ( bot.Map.Name != "kitsune" )
					bot.Player.Join( "kitsune" );
				
				bot.Player.HuntForItem( "Kitsune", "No. 1337 Blade Oil", 1, true );
				bot.Player.Jump( "Enter", "Spawn" );
				bot.Sleep( 750 );
			}
			if ( ! bot.Inventory.ContainsTempItem( "Greenguard Dragon Hide", 3 ) ) {
				if ( bot.Map.Name != "greendragon" )
					bot.Player.Join( "greendragon" );
				
				bot.Player.HuntForItem( "Greenguard Dragon", "Greenguard Dragon Hide", 3, true );
				bot.Player.Jump( "Enter", "Spawn" );
				bot.Sleep( 750 );
			}
			if ( ! bot.Inventory.ContainsTempItem( "Gold Brush" ) ) {
				if ( bot.Map.Name != "sandcastle" )
					bot.Player.Join( "sandcastle" );
				
				bot.Player.HuntForItem( "Chaos Sphinx", "Gold Brush", 1, true );
				bot.Player.Jump( "Enter", "Spawn" );
				bot.Sleep( 750 );
			}
			if ( ! bot.Inventory.ContainsTempItem( "Sharp Stone Sharpener" ) ) {
				if ( bot.Map.Name != "roc" )
					bot.Player.Join( "roc" );
				
				bot.Player.HuntForItem( "Rock Roc", "Sharp Stone Sharpener", 1, true );
				bot.Player.Jump( "Enter", "Spawn" );
				bot.Sleep( 750 );
			}
			if ( ! bot.Inventory.ContainsTempItem( "Blinding Lacquer Finish" ) ) {
				if ( bot.Map.Name != "citadel" )
					bot.Player.Join( "citadel" );
				
				bot.Player.HuntForItem( "Grand Inquisitor", "Blinding Lacquer Finish", 1, true );
				bot.Player.Jump( "Enter", "Spawn" );
				bot.Sleep( 750 );
			}
			if ( ! bot.Inventory.ContainsTempItem( "Non-abrasive Power Powder" ) ) {
				if ( bot.Map.Name != "crashsite" )
					bot.Player.Join( "crashsite" );
				
				bot.Player.HuntForItem( "Protosartorium", "Non-abrasive Power Powder", 1, true );
				bot.Player.Jump( "Enter", "Spawn" );
				bot.Sleep( 750 );
			}
			if ( ! bot.Inventory.ContainsTempItem( "Suede Travel Case" ) ) {
				if ( bot.Map.Name != "djinn" )
					bot.Player.Join( "djinn" );
				
				bot.Player.HuntForItem( "Harpy", "Suede Travel Case", 1, true );
				bot.Player.Jump( "Enter", "Spawn" );
				bot.Sleep( 750 );
			}
			if ( ! bot.Inventory.Contains( "Great Ornate Warhammer" ) ) {
				if ( bot.Map.Name != "dragonplane" )
					bot.Player.Join( "dragonplane", "Cut1", "Left" );
				
				bot.Player.Jump( "r2", "Right" );
				bot.Player.HuntForItem( "Earth Elemental", "Great Ornate Warhammer", 1 );
				bot.Player.Jump( "Enter", "Spawn" );
				bot.Sleep( 750 );
			}
			
			if ( bot.Quests.CanComplete( 2163 ) )
				bot.Quests.EnsureComplete( 2163, -1, false, 5 );
		}
	}
}
