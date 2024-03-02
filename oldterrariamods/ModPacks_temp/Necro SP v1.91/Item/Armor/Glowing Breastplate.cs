public static void Effects(Player player) {
	player.magicDamage += 0.10f;
}

public static void SetBonus(Player player) {
	player.setBonus = "+10% Magic Damage, -10% Mana Usage, Double Jump, Light, and +5% Movement Speed";
	player.magicDamage += 0.10f;
	player.manaCost -= 0.10f;
    player.doubleJump=true;
    player.lightOrb=true;
    player.moveSpeed=5f;
}

        public void PlayerFrame(Player player){

            Color color = new Color();
            int dust = Dust.NewDust(
	    new Vector2((float) player.position.X, 
	    (float) player.position.Y), 
	    player.width, player.height,3,0,0,100,color,1.5f);
	    Main.dust[dust].noGravity = true;
}	    
	    
	     
	    
	     
	   
	    
	
           

