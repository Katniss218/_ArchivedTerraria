public static void SetBonus(Player player) {
	player.setBonus = "+8% Ranged Damage, -5% Mana Usage, and +10% movement speed";
	player.rangedDamage += 0.08f;
	player.manaCost -= 0.05f;
    player.moveSpeed += 0.10f;
}

public void PlayerFrame(Player player)
{
	if (Main.rand.Next(3)==0)
	{
	Color color = new Color();
	int dust = Dust.NewDust(new Vector2((float) player.position.X, (float) player.position.Y), player.width, player.height, 0, Main.rand.Next(-5,5), Main.rand.Next(-5,5),100, color, 1.8f);
	Main.dust[dust].noGravity = true;
	}
}