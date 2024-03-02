public static void Effects(Player player)
{
	bool Detected = false;
	foreach(Player i in Main.player)
	{
	if (player.whoAmi != i.whoAmi && (player.team != 0 && i.team != 0 && player.team == i.team) && Vector2.Distance(player.position,i.position) <= 400)
	{
	for (int num36 = 2; num36 <= 7; num36++)
	{
	if (i.armor[num36].type == Config.itemDefs.byName["Element of Harmony"].type) Detected = true;
	}
	}
	}
	
	if (Detected)
	{
	player.statDefense += 2;
	player.moveSpeed += 0.10f;
	player.magicDamage += 0.05f;
	player.meleeDamage += 0.05f;
	player.rangedDamage += 0.05f;
	player.meleeSpeed += 0.10f;
	player.magicCrit += 2;
	player.meleeCrit += 2;
	player.rangedCrit += 2;
	player.manaCost -= 0.10f;
	if (Main.rand.Next(30) == 0)
	{
	int dust = Dust.NewDust(new Vector2((float) player.position.X, (float) player.position.Y), player.width, player.height, 16, Main.rand.Next(-3,3), Main.rand.Next(-3,3), 100, Color.White, 1.5f);
	Main.dust[dust].noGravity = true;
	Main.dust[dust].noLight = true;
	}
	}
}