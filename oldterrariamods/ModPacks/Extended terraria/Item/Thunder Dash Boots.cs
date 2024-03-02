float oldVel;
int frames = 0;
int x = 0;
int y = 0;
bool dir = false;
int CD = 0;
bool
	rO = false,
	lockR = false;
public void Effects(Player P)
{
	frames++;
	if (frames > 180) frames = 0;
	x = (int)(P.position.X / 16f);
	y = (int)(P.position.Y / 16f);
	P.noKnockback = true;
	P.noFallDmg = true;
	P.doubleJump = true;
	P.baseMaxSpeed = 8f;
	if (!dir && P.direction == -1 && Math.Abs(P.velocity.X) == 0f)
	{
		dir = true;
		CD += 50;
		if (CD > 200) CD = 150;
	}
	else if (dir && P.direction == 1 && Math.Abs(P.velocity.X) == 0f)
	{
		dir = false;
		CD += 50;
		if (CD > 200) CD = 150;
	}
	else
	{
		CD -= 5;
		if(CD < 0) CD = 0;
	}
	if (Math.Abs(P.velocity.X) < 1f && CD == 0 && !rO &&
	    oldVel < Math.Abs(P.velocity.X) && !lockR && (P.controlLeft ^ P.controlRight) &&
	    (!Main.tile[x - 1, y + 2].active && Main.tileSolid[Main.tile[x - 1, y + 2].type] ||
	    !Main.tile[x + 2, y + 2].active && Main.tileSolid[Main.tile[x + 2, y + 2].type] ||
	    !Main.tile[x - 1, y + 1].active && Main.tileSolid[Main.tile[x - 1, y + 1].type] ||
	    !Main.tile[x + 2, y + 1].active && Main.tileSolid[Main.tile[x + 2, y + 1].type] ||
	    !Main.tile[x - 1, y].active && Main.tileSolid[Main.tile[x - 1, y].type] ||
	    !Main.tile[x + 2, y].active && Main.tileSolid[Main.tile[x + 2, y].type]) && P.velocity.Y == 0f && P.velocity.X != 0f)
	{
		rO = lockR = true;
	}
	if (rO)
	{
		int a = Projectile.NewProjectile(P.position.X, P.position.Y - 25, 0f, 0f, Config.projectileID["Lightning Bolts"], 35, 2f, Main.myPlayer);
		Main.PlaySound(2, (int)P.position.X, (int)P.position.Y, SoundHandler.soundID["Thunder"]);
	}
	if (oldVel > Math.Abs(P.velocity.X) && (P.controlLeft ^ P.controlRight))
	{
		lockR = false;
	}
	rO = false;
	if (P.velocity.X > 3 || P.velocity.X < -3)
	{
		if (frames % 10 == 0 && Main.tile[(int)(P.position.X / 16f), (int)(P.position.Y / 16f) + 3].active && Main.tileSolid[Main.tile[(int)(P.position.X / 16f), (int)(P.position.Y / 16f) + 3].type])
		{
			Main.PlaySound(17, (int)P.position.X, (int)P.position.Y, 0);
		}
		Color color = new Color();
		int dust = Dust.NewDust(new Vector2((float) P.position.X, (float) P.position.Y), P.width, P.height, 57, Main.rand.Next(-5,5), Main.rand.Next(-5,5), 100, color, 2.0f);
		Main.dust[dust].noGravity = true;
	}
	oldVel = Math.Abs(P.velocity.X);
}