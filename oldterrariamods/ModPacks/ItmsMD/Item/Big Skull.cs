public void UseItem(Player player, int playerID) {
        NPC.NewNPC((int)player.position.X-20,(int)player.position.Y,"Skeletron",0);
Main.NewText("Skeletron has avoken", 175, 75, 255);
}