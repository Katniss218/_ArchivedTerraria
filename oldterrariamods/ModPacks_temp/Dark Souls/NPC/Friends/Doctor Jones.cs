public static bool SpawnNPC(int x, int y, int playerID) {
	if(Main.player[playerID].zoneJungle && Main.rand.Next(50)==1){ //&& Main.rand.Next(1)==1
		for(int i = 0; i < Main.npc.Length; i++){
			if (Main.npc[i].type==Config.npcDefs.byName["Archeologist"].type){
				return false;
			}
		}
		Main.NewText("The spirit of adventure is nearby...",255,255,0);
		return true;
	}
	return false;
}

#region Names	
public void Initialize() 
{
	if(Main.chrName[npc.type] == null){ Main.chrName[npc.type] = SetName(); }
}

public static string SetName() {
	return "Henry";
}
#endregion

public void AI() {
	npc.Transform(Config.npcDefs.byName["Archeologist"].type);
}
public static string Chat() {
	string[] dialogs = {
	"I sell lots of good things, because I'm kind of awesome like that.", 
	"I don't like people hovering over my name, so a little : is all you get. Sometimes. It's wierd.", 
	"I *hate* snakes.",
	"So, this game's pretty cool, huh? I was playing the beta 2 months ago and then this happened...",
	"Don't go in the underground jungle. There's only a grappling hook down there. Me? I prefer a whip.",
	"Did you ever wonder why they call them 'dark' souls? They're actually kinda green..."
	};
	int choice = Main.rand.Next(0, dialogs.Length);
	return dialogs[choice];
}

