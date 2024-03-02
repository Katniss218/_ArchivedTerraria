public static void SetBonus(Player player) {
	player.setBonus = "Philosopher's Stone and No Knockback Effects";
	player.noKnockback=true;
	player.pStone=true;
}

public void PlayerFrame(Player player){

        Color color = new Color();
        int dust = Dust.NewDust(
	    new Vector2((float) player.position.X, 
	    (float) player.position.Y), 
	    player.width, player.height,3,0,0,100,color,1.5f);
	    Main.dust[dust].noGravity = true;
}