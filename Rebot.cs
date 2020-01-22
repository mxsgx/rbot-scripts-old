using System;
using System.Collections.Generic;
using System.Reflection;
using RBot;

public class Script
{
	public class Rebot
	{
		public class Storyboard
		{
			public class Story
			{
				public object[] narrative
				{
					get;
					set;
				}

				public string title
				{
					get;
					set;
				}

				public Story(string title, object[] narrative)
				{
					this.title = title;
					this.narrative = narrative;
				}
			}

			public List<Script.Rebot.Storyboard.Story> Stories = new List<Script.Rebot.Storyboard.Story>();

			public ScriptInterface Bot;

			public Script.Rebot.Storyboard Hunt(string monster)
			{
				this.Stories.Add(
					this.NewStory("Hunt", monster)
				);
				
				return this;
			}

			public Script.Rebot.Storyboard HuntForItem(string monster, string item, int quantity, bool isTemporaryItem = false, bool rejectElse = true)
			{
				this.Stories.Add(
					this.NewStory("HuntForItem", monster, item, quantity, isTemporaryItem, rejectElse)
				);
				
				return this;
			}

			public Script.Rebot.Storyboard Join(string map, string cell = "Enter", string pad = "Spawn")
			{
				this.Stories.Add(
					this.NewStory("Join", map, cell, pad)
				);
				
				return this;
			}

			public Script.Rebot.Storyboard JoinAndHuntForItem(string map, string monster, string item, int quantity, bool isTemporaryItem = false, bool rejectElse = true)
			{

				this.Stories.Add(
					this.NewStory("JoinAndHuntForItem", map, monster, item, quantity, isTemporaryItem, rejectElse)
				);
				
				return this;
			}

			public Script.Rebot.Storyboard.Story NewStory(string title, params object[] narrative)
			{
				return new Script.Rebot.Storyboard.Story(title, narrative);
			}

			public Storyboard(ScriptInterface Bot)
			{
				this.Bot = Bot;
			}

			public void Start(Script.Rebot rebot)
			{
				foreach(var story in this.Stories)
				{
					string method = story.title;
					object[] args = story.narrative;

					rebot.GetType()
					     .GetMethod(method)
					     .Invoke(rebot, args);

					rebot.Bot.Sleep(1000);
				}
			}
		}

		private bool StoryboardIsRunning = false;

		private List<int> QuestIDs = new List<int>();

		private List<Script.Rebot.Storyboard> Storyboards = new List<Script.Rebot.Storyboard>();
		
		private List<string> Drops = new List<string>();

		public ScriptInterface Bot;

		public Rebot(ScriptInterface Bot)
		{
			this.Bot = Bot;
		}

		public Script.Rebot AcceptQuest(int questID)
		{
			if (!this.Bot.Quests.IsInProgress(questID))
			{
				this.Bot.Quests.EnsureAccept(questID);
				this.Bot.Sleep(100);
			}

			return this;
		}

		public Script.Rebot AcceptQuests(params object[] questIDs)
		{
			for (int i = 0; i < questIDs.Length; i++)
			{
				int questID = Convert.ToByte(questIDs[i]);

				if (!this.Bot.Quests.IsInProgress(questID))
				{
					this.Bot.Quests.EnsureAccept(questID);
					this.Bot.Sleep(100);
				}
			}

			return this;
		}

		public Script.Rebot AcceptQueueQuests()
		{
			this.QuestIDs.ForEach((questID) => {
				if (!this.Bot.Quests.IsInProgress(questID))
				{
					this.Bot.Quests.EnsureAccept(questID);
					this.Bot.Sleep(100);
				}
			});

			return this;
		}

		public Script.Rebot AddDrop(string item)
		{
			this.Bot.Drops.Add(item);
			this.Drops.Add(item);
			
			return this;
		}

		public Script.Rebot AddDrops(params object[] items)
		{
			for (int i = 0; i < items.Length; i++)
			{
				string item = Convert.ToString(items[i]);
				
				this.AddDrop(item);
			}

			return this;
		}

		public Script.Rebot AddQuest(int questID)
		{
			this.QuestIDs.Add(questID);

			return this.AcceptQuest(questID);
		}

		public Script.Rebot AddQuests(params object[] questIDs)
		{
			for (int i = 0; i < questIDs.Length; i++)
			{
				int questID = Convert.ToInt32(questIDs[i]);
				
				this.AddQuest(questID);
			}

			return this;
		}

		public Script.Rebot AddStoryboard(Script.Rebot.Storyboard storyboard)
		{
			this.Storyboards.Add(storyboard);

			return this;
		}

		public Script.Rebot CompleteQueueQuests()
		{
			this.QuestIDs.ForEach((questID) => {
				if (this.Bot.Quests.CanComplete(questID))
				{
					this.Bot.Quests.EnsureComplete(questID);
					this.Bot.Sleep(100);
				}
			});

			return this;
		}

		public Script.Rebot Hunt(string monster)
		{
			this.Bot.Player.Hunt(monster);

			return this;
		}

		public Script.Rebot HuntForItem(string monster, string item, int quantity, bool isTemporaryItem = false, bool rejectElse = true)
		{
			while (!this.Bot.ShouldExit() && (isTemporaryItem || !this.Bot.Inventory.Contains(item, quantity)) && (!isTemporaryItem || !this.Bot.Inventory.ContainsTempItem(item, quantity)))
			{
				this.Hunt(monster);
				
				if (!isTemporaryItem && !this.Drops.Contains(item))
				{
					this.Bot.Player.Pickup(new string[]
					{
						item
					});
				}
				
				if (rejectElse)
				{
					List<string> items = new List<string>
					{
						item
					};
					
					this.Drops.ForEach((whitelistItem) => {
						items.Add(whitelistItem);
					});
					
					this.Bot.Player.RejectExcept(items.ToArray());
				}
			}

			return this;
		}

		public Script.Rebot Join(string map, string cell = "Enter", string pad = "Spawn")
		{
			if (this.Bot.Map.Name != map || this.Bot.Options.PrivateRooms)
			{
				this.Bot.Player.Join(map, cell, pad);
			}

			return this;
		}

		public Script.Rebot JoinAndHuntForItem(string map, string monster, string item, int quantity, bool isTemporaryItem = false, bool rejectElse = true)
		{
			if ((isTemporaryItem || !this.Bot.Inventory.Contains(item, quantity)) && (!isTemporaryItem || !this.Bot.Inventory.ContainsTempItem(item, quantity)))
			{
				this.Join(map)
				    .HuntForItem(monster, item, quantity, isTemporaryItem, rejectElse);
			}

			return this;
		}

		public Script.Rebot LoadSkills(string xml)
		{
			this.Bot.Skills.LoadSkills(xml);

			return this;
		}

		public Script.Rebot SetOption(string option, string value)
		{
			PropertyInfo optionInfo = this.Bot.Options.GetType().GetProperty(option);

			optionInfo.SetValue(this.Bot.Options, Convert.ChangeType(value, optionInfo.PropertyType), null);

			return this;
		}

		public Script.Rebot SetSkills(params object[] skills)
		{
			this.Bot.Skills.Clear();

			for (int i = 0; i < skills.Length; i++)
			{
				int skill = Convert.ToInt32(skills[i]);
				
				this.Bot.Skills.Add(skill, 1);
			}

			return this;
		}

		public Script.Rebot.Storyboard NewStoryboard()
		{
			return new Script.Rebot.Storyboard(this.Bot);
		}

		public void RunStoryboard()
		{
			this.Bot.Events.MonsterKilled += (bot, monster) => {
				this.StoryboardIsRunning = false;
				this.CompleteQueueQuests().AcceptQueueQuests();
				this.StoryboardIsRunning = true;
			};

			this.AcceptQueueQuests()
			    .Bot.Skills.StartTimer();
			this.Bot.Drops.Start();

			this.StoryboardIsRunning = true;

			while (this.StoryboardIsRunning)
			{
				foreach(var storyboard in this.Storyboards)
				{
					storyboard.Start(this);
				}
			}
		}
	}

	public void ScriptMain(ScriptInterface Bot)
	{
		Script.Rebot rebot = new Script.Rebot(Bot);
		
		rebot.SetOption("SafeTimings", "true")
		     .SetOption("RestPackets", "true")
		     .SetOption("InfiniteRange", "true")
		     .SetSkills(1, 2, 3, 4)
		     .AddStoryboard(
		     	rebot.NewStoryboard()
		     	     .Join("battleontown")
		     	     .Hunt("Frogzard")
		     )
		     .RunStoryboard();
	}
}
