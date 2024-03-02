public static void SetBonus(Player player) {
	player.setBonus = "+10% Critical Hit chance";
	player.rangedCrit += 10;
	player.meleeCrit += 10;
	player.magicCrit += 10;
	player.ShadowAura=true;
}

public void Effects(Player player){
	if (player.velocity.X !=0 || player.velocity.Y !=0)
	{
		Color color = new Color();
		int dust = Dust.NewDust(new Vector2((float) player.position.X, (float) player.position.Y), player.width, player.height, 29, Main.rand.Next(-5,5), Main.rand.Next(-5,5), 0, color, 2.0f);
		Main.dust[dust].noGravity = true;
	}
}