int timerRocket = 0;
public bool equipd = false;

public void Effects(Player P) {equipd = true;}

public void UpdatePlayer(Player player)
{
	for (int num36 = 2; num36 <= 7; num36++)
	{
	if (player.armor[num36].type == 492 || player.armor[num36].type == 493) equipd = false;
	}
	if (equipd)
	{
		player.rocketBoots = 1;
		player.jumpBoost = true;
		player.noFallDmg = true;
		if (player.controlJump && player.rocketTime < player.rocketTimeMax && player.statMana >= 2 && !player.wet)
		{
			player.baseSpeed*=1.5f;
			player.maximumMaxSpeed*=1.5f;
			player.baseMaxSpeed*=1.5f;
			player.baseSpeedAcceleration*=1.5f;
			player.rocketTime = 1;
			if (timerRocket % 2 == 0) player.statMana -= 1;
			if (timerRocket == 0) Main.PlaySound(2, (int)player.position.X, (int)player.position.Y, 34);
			player.manaRegenDelay = (int)player.maxRegenDelay;
			int num3 = Dust.NewDust(new Vector2(player.position.X+(player.width/2)-(16*player.direction), player.position.Y+(player.height/2)-4), 4, 4, 6, Main.rand.Next(-40,40)/10f, -10f, 100, default(Color), 3f);
			Main.dust[num3].noGravity = true;
			Main.dust[num3].noLight = true;
			player.velocity.Y -= 0.4f;
			timerRocket++;
			if (timerRocket > 9) timerRocket = 0;
		}
		else
		{
			timerRocket = 0;
			if (player.statMana < 2 && player.manaFlower && !player.noItems)
			{
				for (int i = 0; i < 48; i++)
				{
					if (player.inventory[i].stack > 0 && player.inventory[i].type > 0 && player.inventory[i].healMana > 0 && (player.potionDelay == 0 || !player.inventory[i].potion))
					{
						Main.PlaySound(2, (int)player.position.X, (int)player.position.Y, player.inventory[i].useSound);
						if (player.inventory[i].potion)
						{
							player.potionDelay = player.potionDelayTime;
							player.AddBuff(21, player.potionDelay, true);
						}
						player.statLife += player.inventory[i].healLife;
						player.statMana += player.inventory[i].healMana;
						if (player.statLife > player.statLifeMax)
						{
							player.statLife = player.statLifeMax;
						}
						if (player.statMana > player.statManaMax2)
						{
							player.statMana = player.statManaMax2;
						}
						if (player.inventory[i].healLife > 0 && Main.myPlayer == player.whoAmi)
						{
							player.HealEffect(player.inventory[i].healLife);
						}
						if (player.inventory[i].healMana > 0 && Main.myPlayer == player.whoAmi)
						{
							player.ManaEffect(player.inventory[i].healMana);
						}
						player.inventory[i].stack--;
						if (player.inventory[i].stack <= 0)
						{
							player.inventory[i].type = 0;
							player.inventory[i].name = "";
						}
						Recipe.FindRecipes();
						break;
					}
				}
			}
		}
	}
	equipd = false;
}