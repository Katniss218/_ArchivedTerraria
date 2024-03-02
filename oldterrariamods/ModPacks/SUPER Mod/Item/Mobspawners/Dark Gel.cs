public void UseItem(Player player, int playerID){

 NPC.NewNPC((int)player.position.X-750,(int) player.position.Y-50, Config.npcDefs.byName["Ultra Slime"].type, 0);
 NPC.NewNPC((int)player.position.X-750,(int) player.position.Y-50, Config.npcDefs.byName["Omnirs Hydra"].type, 0);
}