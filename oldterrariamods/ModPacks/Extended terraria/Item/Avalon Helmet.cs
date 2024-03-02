public void Effects(Player player)
{
	player.rangedDamage += 0.32f;
	player.magicDamage += 0.32f;
	player.meleeDamage += 0.32f;
	player.meleeSpeed += 0.1f;
	player.manaCost -= 0.2f;
}

public void DamagePlayer(Player P, ref int damage, NPC N)
{
	int[] dust = { 0, 0, 0, 0 };
	int[] dust2 = { 0, 0, 0, 0 };
	if ((ModPlayer.HasItemInArmor(Config.itemDefs.byName["Slime Talisman"].type) || ModPlayer.HasItemInExtraSlots(Config.itemDefs.byName["Slime Talisman"].type)) && (N.type == 1 || N.type == 16 || N.type == 59 || N.type == 71 || N.type == 81 || N.type == 121 || N.type == 122 || N.type == 138 || N.type == 141 || N.type == Config.npcDefs.byName["White Slime"].type || N.type == Config.npcDefs.byName["Boom Slime"].type))
	{
		return;
	}
	if ((ModPlayer.HasItemInArmor(Config.itemDefs.byName["Dragon Stone"].type) || ModPlayer.HasItemInExtraSlots(Config.itemDefs.byName["Dragon Stone"].type)) && (N.type == 2 || N.type == 6 || N.type == 42 || N.type == 48 || N.type == 49 || N.type == 51 || N.type == 60 || N.type == 61 || N.type == 62 || N.type == 66 || N.type == 75 || N.type == 93 || N.type == 94 || N.type == 112 || N.type == 133 || N.type == 137 || N.type == Config.npcDefs.byName["Illuminant Eye"].type || N.type == Config.npcDefs.byName["Hallowor"].type || N.type == Config.npcDefs.byName["Bloodshot Eye"].type || N.type == Config.npcDefs.byName["Hallow Spit"].type || N.type == Config.npcDefs.byName["Cloud Bat"].type))
	{
		return;
	}
	if ((ModPlayer.HasItemInArmor(Config.itemDefs.byName["Undead Talisman"].type) || ModPlayer.HasItemInExtraSlots(Config.itemDefs.byName["Undead Talisman"].type)) && (N.type == 3 || N.type == 21 || N.type == 31 || N.type == 32 || N.type == 33 || N.type == 34 || N.type == 44 || N.type == 45 || N.type == 52 || N.type == 53 || N.type == 77 || N.type == 78 || N.type == 79 || N.type == 80 || N.type == 82 || N.type == 109 || N.type == 110 || N.type == 132 || N.type == 140 || N.type == Config.npcDefs.byName["Magma Skeleton"].type || N.type == Config.npcDefs.byName["Troll"].type || N.type == Config.npcDefs.byName["Heavy Zombie"].type || N.type == Config.npcDefs.byName["Ice Skeleton"].type || N.type == Config.npcDefs.byName["Irate Bones"].type))
	{
		return;
	}
	for (int k = 0; k < 10; k++)
	{
		dust[0] = Dust.NewDust(P.position, P.width, P.height, 3, (P.velocity.X * 0.2f) + (P.direction * 3), P.velocity.Y * 1.2f, 100, new Color(), 1f);
		dust[1] = Dust.NewDust(P.position, P.width, P.height, 3, (P.velocity.X * 0.2f) + (P.direction * 3), P.velocity.Y * 1.2f, 100, new Color(), 1f);
		dust[2] = Dust.NewDust(P.position, P.width, P.height, 3, (P.velocity.X * 0.2f) + (P.direction * 3), P.velocity.Y * 1.2f, 100, new Color(), 1f);
		dust[3] = Dust.NewDust(P.position, P.width, P.height, 3, (P.velocity.X * 0.2f) + (P.direction * 3), P.velocity.Y * 1.2f, 100, new Color(), 1f);
		for (int i = 0; i < 4; i++)
		{
			if (i == 0 || i == 1)
			{
				Main.dust[dust[i]].velocity.X *= 1.1f;
			}
			if (i == 0 || i == 2)
			{
				Main.dust[dust[i]].velocity.Y *= 1.1f;
			}
			if (i == 1 || i == 3)
			{
				Main.dust[dust[i]].velocity.Y *= -1.1f;
			}
			if (i == 2 || i == 3)
			{
				Main.dust[dust[i]].velocity.X *= -1.1f;
			}
		}
		for (int j = 0; j < 4; j++)
		{
			int num54 = Projectile.NewProjectile(Main.dust[dust[j]].position.X, Main.dust[dust[j]].position.Y, Main.dust[dust[j]].velocity.X, Main.dust[dust[j]].velocity.Y, Config.projDefs.byName["Leaves"].type, 10, 2, Main.myPlayer);
		}
	}
	for (int m = 0; m < 10; m++)
	{
		dust2[0] = Dust.NewDust(P.position, P.width, P.height, 3, (P.velocity.X * 0.2f) + (P.direction * 3), P.velocity.Y * 1.2f, 100, new Color(), 1f);
		dust2[1] = Dust.NewDust(P.position, P.width, P.height, 3, (P.velocity.X * 0.2f) + (P.direction * 3), P.velocity.Y * 1.2f, 100, new Color(), 1f);
		dust2[2] = Dust.NewDust(P.position, P.width, P.height, 3, (P.velocity.X * 0.2f) + (P.direction * 3), P.velocity.Y * 1.2f, 100, new Color(), 1f);
		dust2[3] = Dust.NewDust(P.position, P.width, P.height, 3, (P.velocity.X * 0.2f) + (P.direction * 3), P.velocity.Y * 1.2f, 100, new Color(), 1f);
		for (int i = 0; i < 4; i++)
		{
			if (i == 0) Main.dust[dust2[i]].velocity.Y *= -1.1f;
			if (i == 1) Main.dust[dust2[i]].velocity.X *= -1.1f;
			if (i == 2) Main.dust[dust2[i]].velocity.Y *= 1.1f;
			if (i == 3) Main.dust[dust2[i]].velocity.X *= 1.1f;
		}
		for (int j = 0; j < 4; j++)
		{
			int num54 = Projectile.NewProjectile(Main.dust[dust2[j]].position.X, Main.dust[dust2[j]].position.Y, Main.dust[dust2[j]].velocity.X, Main.dust[dust2[j]].velocity.Y, Config.projDefs.byName["Leaves"].type, 10, 2, Main.myPlayer);
		}
	}
}