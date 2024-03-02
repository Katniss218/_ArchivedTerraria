public Vector2 End = new Vector2(0,0);
public Vector2 StartReal = new Vector2(0,0);
public float L = 0f;
public float L2 = 0f;
bool Following = true;
bool DrawLazer = true;
int cooldown = 0;
public float Lr = 0.5019f, Lg = 0.1922f , Lb = 0.5765f;
public float aLr = 1f, aLg = 1f , aLb = 1f;
public float Ds = 2f;
public int DT = 62;
public int[] ai2 = new int[4] { 0, 0, 0, 0 };
public int npcIndex = -1;
public int npcIndex2 = -1;
public Color DC = Color.Purple;
float dustSpeed = 4f;
public void Initialize() {
    End = projectile.position;
    StartReal = projectile.position;
}
public void AI()
{
	Projectile P = projectile;
	P.timeLeft = 200;
	P.penetrate = 200;
	Player O = Main.player[P.owner];
	if (P.active)
	{
		if(O.channel && Following)
		{
			L += 25f;
			float MaxLineLength = 2500;
			if (L > MaxLineLength) L = MaxLineLength;
		}
		else
		{
			P.tileCollide = true;
			Following = false;
			L2 += 25f;
			P.position = StartReal + new Vector2(L2 * P.velocity.X, L2 * P.velocity.Y);
		}
		P.position -= P.velocity;
		P.rotation = (float)Math.Atan2((P.velocity.Y), (P.velocity.X)) + (float)(Math.PI / 2);
		if (ai2[0] == 0)
		{
			if (ModWorld.FindClosestNPC(new Vector2((Main.mouseX + Main.screenPosition.X), (Main.mouseY + Main.screenPosition.Y)), 128) != -1)
			{
				npcIndex = ModWorld.FindClosestNPC(new Vector2((Main.mouseX + Main.screenPosition.X), (Main.mouseY + Main.screenPosition.Y)), 144);
				End = Main.npc[npcIndex].Center;
				int projIndex = Projectile.NewProjectile(End.X, End.X, P.velocity.X, P.velocity.Y, Config.projectileID["Focus Pulse"], 25, 0f, P.owner);
				Main.projectile[projIndex].ai[0] = End.X; // ++;
				Main.projectile[projIndex].ai[1] = End.Y; //npcIndex;
				ai2[0]++;
			}
			else End = P.position + new Vector2(L * P.velocity.X, L * P.velocity.Y);
		}
		else if (ai2[0] == 1)
		{
			Vector2 cpos = new Vector2(P.ai[0], P.ai[1]);
			if (ModWorld.FindClosestNPC(cpos, 144) != -1)
			{
				npcIndex2 = ModWorld.FindClosestNPC(cpos, 160);
				End = Main.npc[npcIndex2].Center;
			}
			else End = P.position + new Vector2(L * P.velocity.X, L * P.velocity.Y);
		}
	}
	cooldown++;
	if (cooldown >= 8)
	{
		O.statMana -= 1;
		cooldown = 0;
		if (O.statMana <= 0)
		{
			O.statMana = 0;
			O.controlUseItem = false;
			P.Kill();
		}
	}
}
public void PostDraw(SpriteBatch SB) {
    //if (projectile.active) {
        DrawChain(projectile.position, End, "beam3", SB);
    //}
}
public void TotalRotate(Vector2 O,Vector2 A)
{
	projectile.position = O;
	StartReal = O;
	projectile.velocity = A;
	//Main.NewText(""+A.X+" "+A.Y);
}
 public Vector2 RotateAboutOrigin(Vector2 point, Vector2 origin, float rotation) {
    Vector2 u = point - origin; //point relative to origin  
    if (u == Vector2.Zero)
        return point;
    float a = (float)Math.Atan2(u.Y, u.X); //angle relative to origin  
    a += rotation; //rotate  
    //u is now the new point relative to origin  
    u = u.Length() * new Vector2((float)Math.Cos(a), (float)Math.Sin(a));
    return u + origin;
} 

public void DrawChain(Vector2 start, Vector2 end, string name, SpriteBatch SP)
{
	start -= Main.screenPosition;
	end -= Main.screenPosition;
	Texture2D TEX = Main.goreTexture[Config.goreID[name]];
	int linklength = TEX.Height;
	Vector2 chain = end - start;

	float length = (float)chain.Length();
	int numlinks = (int)Math.Ceiling(length / linklength);
	Vector2[] links = new Vector2[numlinks];
	float rotation = (float)Math.Atan2(chain.Y, chain.X);
	Projectile P = projectile;
	Player Pr = Main.player[P.owner];
	Player MyPr = Main.player[Main.myPlayer];
	for (int i = 0; i < numlinks; i++)
	{
		links[i] = start + chain/numlinks * i;
		Vector2 LR = links[i] + Main.screenPosition;
		Rectangle R = new Rectangle((int)LR.X, (int)LR.Y, P.width, P.height);
		#region Light
		Lighting.addLight((int)((LR.X + (float)(P.width / 2)) / 16f), (int)((LR.Y + (float)(P.height / 2)) / 16f), Lr, Lg, Lb);
		#endregion
		#region Dust
		if (Main.rand.Next(100) == 0) {
			Vector2 DP = LR - (new Vector2(TEX.Width / 2, linklength / 2));
			Main.dust[Dust.NewDust(DP, 6, 6, DT, P.velocity.X * dustSpeed, P.velocity.Y * dustSpeed, 255, DC, Ds)].noGravity=true;
			//Main.NewText("1 " + P.velocity.X + " 2 " + P.velocity.Y);
		}
		#endregion
		#region damage time - damage players as enemy
		if (Main.netMode != 2 && P.hostile && Main.myPlayer < 255 && P.damage > 0)
		{
			if (MyPr.active && !MyPr.dead && !MyPr.immune)
			{
				Rectangle Rt = new Rectangle((int)MyPr.position.X, (int)MyPr.position.Y, MyPr.width, MyPr.height);
				if (R.Intersects(Rt))
				{
					int hitDirection = P.direction;
					if (MyPr.position.X + (float)(MyPr.width / 2) < LR.X + (float)(P.width / 2)) {
						hitDirection = -1;
					}
					else
					{
						hitDirection = 1;
					}
					int num9 = Main.DamageVar((float)P.damage);
					if (!MyPr.immune)
					{
						P.StatusPlayer(MyPr.whoAmi);
					}
					if (num9 > 70) MyPr.Hurt(num9 * 2, hitDirection, false, false, Lang.deathMsg(Pr.whoAmi, -1, P.whoAmI, -1), true);
					else if (num9 <= 70) MyPr.Hurt(num9 * 2, hitDirection, false, false, Lang.deathMsg(Pr.whoAmi, -1, P.whoAmI, -1), false);
				}
			}
		}
		#endregion
        #region damage time - damage enemies and pvp players
            if (P.owner == Main.myPlayer && P.friendly) {
				if (P.damage > 0) {
					for (int k = 0; k < Main.npc.Length; k++) {
                        NPC N = Main.npc[k];
                        if (N.active && !N.dontTakeDamage && ((!N.friendly && P.friendly) || (N.friendly && P.hostile)) && (P.owner < 0 || N.immune[P.owner] == 0)) {
							if (((N.noTileCollide || !P.ownerHitCheck || Collision.CanHit(Pr.position, Pr.width, Pr.height, N.position, N.width, N.height)))) {
								Rectangle NR = new Rectangle((int)N.position.X, (int)N.position.Y, N.width, N.height);
								if (R.Intersects(NR)) {
									bool Crit = false;
									if (P.melee && Main.rand.Next(100) <= Pr.meleeCrit) {
										Crit = true;
									}
									if (P.ranged && Main.rand.Next(100) <= Pr.rangedCrit) {
										Crit = true;
									}
									if (P.magic && Main.rand.Next(100) <= Pr.magicCrit) {
										Crit = true;
									}
									int VEC_L1 = Main.DamageVar((float)P.damage);
									P.StatusNPC(k);
									N.StrikeNPC(VEC_L1, P.knockBack, P.direction, Crit, false);
									if (Main.netMode != 0) {
										if (Crit) {
											NetMessage.SendData(28, -1, -1, "", k, (float)VEC_L1, P.knockBack, (float)P.direction, 1);
										}
										else {
											NetMessage.SendData(28, -1, -1, "", k, (float)VEC_L1, P.knockBack, (float)P.direction, 0);
										}
									}
									if (P.penetrate != 1) {
										N.immune[P.owner] = 10;
									}
									if (P.penetrate > 0) {
										P.penetrate--;
										if (P.penetrate == 0)
										{
											break;
										}
									}
								}
							}
                        }
                    }
                }
                if (P.damage > 0 && MyPr.hostile) {
					for (int l = 0; l < Main.player.Length; l++) {
                        Player PrL = Main.player[l];
						if (l != P.owner && PrL.active && !PrL.dead && !PrL.immune && PrL.hostile && P.playerImmune[l] <= 0 && (MyPr.team == 0 || MyPr.team != PrL.team) && (!P.ownerHitCheck || Collision.CanHit(Pr.position, Pr.width, Pr.height, PrL.position, PrL.width, PrL.height))) {
							Rectangle RP = new Rectangle((int)PrL.position.X, (int)PrL.position.Y, PrL.width, PrL.height);
							if (R.Intersects(RP)) {
								bool Crit = false;
								if (P.melee && Main.rand.Next(100) <= Pr.meleeCrit) {
									Crit = true;
								}
								if (P.ranged && Main.rand.Next(100) <= Pr.rangedCrit) {
									Crit = true;
								}
								if (P.magic && Main.rand.Next(100) <= Pr.magicCrit) {
									Crit = true;
								}
								int DMG = Main.DamageVar((float)P.damage);
								if (!PrL.immune) {
									P.StatusPvP(l);
								}
								PrL.Hurt(DMG, P.direction, true, false, Lang.deathMsg(Pr.whoAmi, P.whoAmI, -1, -1), Crit);
								if (Main.netMode != 0) {
									if (Crit) {
										NetMessage.SendData(26, -1, -1, Lang.deathMsg(Pr.whoAmi, P.whoAmI, -1, -1), l, (float)P.direction, (float)DMG, 1f, 1);
									}
									else {
										NetMessage.SendData(26, -1, -1, Lang.deathMsg(Pr.whoAmi, P.whoAmI, -1, -1), l, (float)P.direction, (float)DMG, 1f, 0);
									}
								}
								P.playerImmune[l] = 40;
								if (P.penetrate > 0) {
									P.penetrate--;
									if (P.penetrate == 0) {
										break;
									}
								}
							}
						}
					}
                }
            }
        #endregion
        //Color color = Lighting.GetColor((int)((LR.X+Main.screenPosition.X)/16), (int)((LR.Y+Main.screenPosition.Y)/16));
        Color color = new Color(aLr,aLg,aLb);
        color.A = 255;
        if(DrawLazer) SP.Draw(
        Main.goreTexture[Config.goreID[name]],
        links[i],
        new Rectangle(0, 0, Main.goreTexture[Config.goreID[name]].Width, linklength), 
        color, 
        rotation + 1.57f, 
        new Vector2(Main.goreTexture[Config.goreID[name]].Width / 2f, linklength), 
        1.1f ,
        SpriteEffects.None, 
        1f);
        int zx = (int)((LR.X + (float)(P.width / 2)) / 16f);
        int zy = (int)((LR.Y + (float)(P.height / 2)) / 16f);
        if(zx < 0) zx = 0;
        if(zy < 0) zy = 0;
        if(zx > Main.maxTilesX) zx = Main.maxTilesX;
        if(zy > Main.maxTilesY) zy = Main.maxTilesY;
        if(Main.tile[zx,zy].active && Main.tileSolid[(int)Main.tile[zx,zy].type]) return;
    }
}

public void Kill() {
    //Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, soundHandler.soundID["v_laser_gun_kill"]);
	projectile.ai[0] = 0;
	projectile.ai[1] = 0;
	projectile.active = false;
    //return;
}