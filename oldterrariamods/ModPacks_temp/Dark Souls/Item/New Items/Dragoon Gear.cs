public static void Effects(Player player) 
{
    player.noFallDmg = true;
	int num21 = (int)(player.position.Y / 16f) - player.fallStart;
    if ((player.gravDir == 1f) && (player.velocity.Y > 0))
    {
        player.meleeDamage *= (int) ((player.velocity.Y*0.15) + 1);
    }
    if ((player.gravDir == -1f) && (player.velocity.Y < 0))
    {
        player.meleeDamage *= (int) -(((player.velocity.Y*0.15) - 1));
    }
    ModPlayer.dragoonBoots = true;
    //Player.jumpHeight += 5;
    //if (!Main.player[Main.myPlayer].controlDown)
    //{
    //    Player.jumpSpeed += 10f;
    //}
}