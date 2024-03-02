static double tpCD = 0;
private int fallStart_old = -1;
bool runonce = true;
int a = -1;
public void Effects(Player player)
{
	int i2 = (int)(player.position.X + (float)(player.width / 2) + (float)(8 * player.direction)) / 16;
	int j2 = (int)(player.position.Y + 2f) / 16;
	Lighting.addLight(i2,j2,2.5f,2.5f,2.5f);
	player.starCloak = true;
	player.longInvince = true;
	player.findTreasure = true;
	player.detectCreature = true;
	player.statManaMax2 += 80;
	player.doubleJump = true;
}

public static bool IsHotkeyPressed(string NameOfHotkey)
{
	Microsoft.Xna.Framework.Input.Keys[] pressedKeys = Main.keyState.GetPressedKeys();
	for (int j = 0; j < pressedKeys.Length; j++)
	{
		string a = string.Concat(pressedKeys[j]);
		if (a == NameOfHotkey)
		{
			return true;
		}
	}
	return false;
}

public void DealtPlayer(Player P,double DMG,NPC N)
{
	P.immuneTime += 40;
}

public void SetBonus(Player P)
{
	/*int sw = (int)(Main.screenWidth);
	int sh = (int)(Main.screenHeight);
	int sx = (int)(Main.screenPosition.X);
	int sy = (int)(Main.screenPosition.Y);

	if (fallStart_old == -1) fallStart_old = P.fallStart;
	int fall_dist = 0;
	if (P.velocity.Y == 0f) // && !wings) // detect landing from a fall
		fall_dist = (int)((float)((int)(P.position.Y / 16f) - fallStart_old) * P.gravDir);
	Vector2 p_pos = P.position+new Vector2(P.width,P.height)/2f;

	if (fall_dist > 3) // just fell
	{
		for (int k = 0; k < Main.npc.Length; k++)
		{ // iterate through NPCs
			NPC N = Main.npc[k];
			if (!N.active || N.dontTakeDamage || N.friendly || N.life < 1) continue;
			Vector2 n_pos = new Vector2(N.position.X + (float)N.width * 0.5f, N.position.Y + (float)N.height * 0.5f); // NPC location
			int HitDir = -1;
			if (n_pos.X > p_pos.X) HitDir = 1;
			if ((N.position.X >= sx) && (N.position.X <= sx+sw) && (N.position.Y >= sy) && (N.position.Y <= sy+sh))
			{ // on screen
				N.StrikeNPC(2*fall_dist, 5f, HitDir);
				if(Main.netMode!=0) NetMessage.SendData(28,-1,-1,"",k,2*fall_dist,10f,HitDir,0); // for multiplayer support
				// optionally add debuff here
			} // END on screen
		} // END iterate through NPCs
	} // END just fell
	fallStart_old=P.fallStart;*/

	Rectangle playerWS = new Rectangle((int)P.Center.X - 32, (int)P.Center.Y - 32, 64, 64);
	foreach (Projectile Pr in Main.projectile)
	{
		if (!Pr.friendly)
		{
			Rectangle proj2 = ModGeneric.NewRect(Pr);
			if (proj2.Intersects(playerWS))
			{
				for (int i = 0; i < 5; i++)
				{
					int dust = Dust.NewDust(Pr.position, Pr.width, Pr.height, 15, 0f, 0f, 100, new Color(), 1f);
					Main.dust[dust].noGravity = true;
				}
				Pr.hostile = false;
				Pr.friendly = true;
				Pr.velocity.X *= -1f;
				Pr.velocity.Y *= -1f;
			}
		}
	}
	foreach (NPC N in Main.npc)
	{
		if (!N.friendly && N.aiStyle == 9)
		{
			Rectangle npc = ModGeneric.NewRect(N);
			if (npc.Intersects(playerWS))
			{
				for (int i = 0; i < 5; i++)
				{
					int dust = Dust.NewDust(N.position, N.width, N.height, 15, 0f, 0f, 100, new Color(), 1f);
					Main.dust[dust].noGravity = true;
				}
				N.friendly = true;
				N.velocity.X *= -1f;
				N.velocity.Y *= -1f;
				int b = Projectile.NewProjectile(N.position.X, N.position.Y, N.velocity.X, N.velocity.Y, Config.projectileID["Invisibling"], N.damage, 1f, 255);
				Main.projectile[b].timeLeft = N.timeLeft;
			}
		}
	}

	P.setBonus = "Permanent Shadows buff(Press J to teleport to the cursor)";
	P.ShadowTail = true;
	P.ShadowAura = true;
	if (tpCD > 300)
	{
		tpCD = 300;
	}
	tpCD += 1;
	if (IsHotkeyPressed("J"))
	{
		if (tpCD > 300)
		{
			tpCD = 0;
			for (int num89 = 0; num89 < 70; num89++)
			{
				Dust.NewDust(P.position, P.width, P.height, 15, P.velocity.X * 0.5f, P.velocity.Y * 0.5f, 150, default(Color), 1.1f);
			}
			P.position.X = (Main.mouseX + Main.screenPosition.X);
			P.position.Y = (Main.mouseY + Main.screenPosition.Y);
			for (int num91 = 0; num91 < 70; num91++)
			{
				Dust.NewDust(P.position, P.width, P.height, 15, 0f, 0f, 150, default(Color), 1.1f);
			}
		}
	}
}