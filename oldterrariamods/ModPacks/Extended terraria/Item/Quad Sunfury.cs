byte
    mode = 1;
byte[] timer = new byte[2] { 0, 0 };
bool done = false;
bool runonce = false;
bool isNDown = false;
public void UseStyle(Player P)
{
    int PID = P.whoAmi;
	float
        num48 = 12f,
        speedX = (Main.mouseX + Main.screenPosition.X) - (P.position.X + P.width / 2),
        speedY = (Main.mouseY + Main.screenPosition.Y) - (P.position.Y + P.height / 2),
        num51 = (float) Math.Sqrt((double) ((speedX * speedX) + (speedY * speedY)));
	num51 = num48 / num51;
	speedX *= num51;
	speedY *= num51;
	if (mode == 1 && !done)
	{
		timer[0]++;
		if (timer[0] == 1)
			Projectile.NewProjectile(P.position.X + P.width / 2, P.position.Y + P.height / 2, (float)speedX, (float)speedY, Config.projDefs.byName["Quad Ball"].type, (int)(P.inventory[P.selectedItem].damage * P.meleeDamage), 8, PID);
		if (timer[0] == 16)
			Projectile.NewProjectile(P.position.X + P.width / 2, P.position.Y + P.height / 2, (float)speedX, (float)speedY, Config.projDefs.byName["Quad Ball"].type, (int)(P.inventory[P.selectedItem].damage * P.meleeDamage), 8, PID);
		if (timer[0] == 31)
			Projectile.NewProjectile(P.position.X + P.width / 2, P.position.Y + P.height / 2, (float)speedX, (float)speedY, Config.projDefs.byName["Quad Ball"].type, (int)(P.inventory[P.selectedItem].damage * P.meleeDamage), 8, PID);
		if (timer[0] == 46)
		{
			Projectile.NewProjectile(P.position.X + P.width / 2, P.position.Y + P.height / 2, (float)speedX, (float)speedY, Config.projDefs.byName["Quad Ball"].type, (int)(P.inventory[P.selectedItem].damage * P.meleeDamage), 8, PID);
			timer[0] = 0;
			done = true;
			//return;
		}
	}
}
public bool PreShoot(Player P, Vector2 pos, Vector2 vel, int type, int dmg, float kb, int PID)
{
	done = false;
	if (mode == 2)
	{   
		Projectile.NewProjectile(pos.X, pos.Y, vel.X, vel.Y, type, dmg, kb, PID);
		Projectile.NewProjectile(pos.X, pos.Y, -vel.X, vel.Y, type, dmg, kb, PID);
		Projectile.NewProjectile(pos.X, pos.Y, vel.X, -vel.Y, type, dmg, kb, PID);
		Projectile.NewProjectile(pos.X, pos.Y, -vel.X, -vel.Y, type, dmg, kb, PID);
	}
	if (mode == 3)
		Projectile.NewProjectile(pos.X, pos.Y, vel.X, vel.Y, Config.projectileID["MegaQuad Ball"], dmg, kb, PID);
    if (mode == 4)
	{   
        int amt = 4;
	    int spread = 24;
	    float mult = 0.1f;
	    for (int i = 0; i < amt; i++)
	    {
		    float
                vX = vel.X + (float)Main.rand.Next(-spread, spread + 1) * mult,
                vY = vel.Y + (float)Main.rand.Next(-spread, spread + 1) * mult;
		    Projectile.NewProjectile(pos.X, pos.Y, vX, vY, type, dmg, kb, PID);
	    }
	}
	return false;
}
public void HoldStyle(Player P)
{
    //timer[1]++;
    if (Main.keyState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.N) && !isNDown) // && timer[1] > 20)
    {
	mode++;
	//runonce = true;
	isNDown = true;
    }
    if (!Main.keyState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.N) && isNDown)
    {
	isNDown = false;
    }
    if (mode > 4)
    {
        mode = 1;
	done = false;
    }
    //if (timer[1] > 21)
    //    timer[1] = 21;
    //Main.NewText("Mode: " + mode.ToString());
    item.toolTip2 = "Mode: " + mode.ToString();
}
public void Save(BinaryWriter W)
{
    W.Write(mode);
}
public void Load(BinaryReader R, int V)
{
    try
    {
        mode = R.ReadByte();
    }
    catch
    {
        mode = 1;
    }
}