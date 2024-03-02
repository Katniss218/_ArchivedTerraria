public static void Effects(Player player) {
	player.magicDamage += 0.10f;
}

public static void SetBonus(Player player) {
	player.setBonus = "+10% Magic Damage, -10% Mana Usage";
	player.magicDamage += 0.10f;
	player.manaCost -= 0.10f;
}

public void PlayerFrame(Player player)
{
	if (player.legs == Config.itemDefs.byName["Magma Greaves"].legSlot && player.body == Config.itemDefs.byName["Magma Breastplate"].bodySlot && player.head == Config.itemDefs.byName["Magma Helmet"].headSlot && Main.rand.Next(3)==0)
	{
	Color color = new Color();
	int dust = Dust.NewDust(new Vector2((float) player.position.X, (float) player.position.Y), player.width, player.height, 6, Main.rand.Next(-5,5), Main.rand.Next(-5,5), 200, color, 4.0f);
	Main.dust[dust].noGravity = true;
	Main.dust[dust].noLight = true;
	}
}