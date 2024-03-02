public void UseItem(Player player, int playerID)
{
Main.NewText("I am impressed you've made it this far, Red. But I'm done playing games. It's time to end this...", 175, 75, 255);
NPC.SpawnOnPlayer(playerID, "Okiku");
}