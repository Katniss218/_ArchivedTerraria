//public class Ultrablivion_NPC
//{
    bool sword = false;
        //eyeRSpawned = false,
        //eyeLSpawned = false,
    int[] txtC = new int[3] { 0, 0, 0 };
    int lived = 0;
    string[]
        txt1 = new string[] { "You awoke me...", "Why would you do this?", "Do you know what you've done to the Earth?", "We're trying to stop you from terrorizing the Earth!", "I'm Terraria's last stand...", "If you defeat me, the whole Earth will be destroyed.", "Are you still sure you want to face me?" },
        txt2 = new string[] { "You've choosen to fight me? Then you'll die.", "I will not hold back on you!", "I'll stop you destroying the Earth!", "Now I'm angry! Take this!", "Go, eyes!" };
    bool oldHalf = false;
    public void AI()
    {
        lived++;
        NPC N = npc;
        Player T = Main.player[N.target];
        Vector2 NM = new Vector2(N.position.X + N.width / 2, N.position.Y + N.height / 2);
        int chance = lived < 1800 ? 10 : 30;
        if (Main.rand.Next(chance) == 0 && txtC[0] < txt1.Length && txtC[2] > 80)
        {
            Say(txt1[txtC[0]]);
            txtC[0]++;
            txtC[2] = 0;
        }
        if (Main.rand.Next(20) == 0 && txtC[1] < txt2.Length && txtC[2] > 320)
        {
            if (txtC[1] == 4)
                txtC[1]++;
            Say(txt2[txtC[1]]);
            txtC[1]++;
            txtC[2] = 0;
        }
        txtC[2]++;
        if (N.life < N.lifeMax / 2 && !oldHalf)
            Say(txt2[4]);
        /*if (!eyeRSpawned)
        {
            int arm1 = NPC.NewNPC((int)NM.X, (int)NM.Y, "UltrOeyeR", N.whoAmI);
            Main.npc[arm1].ai[1] = N.whoAmI;
            Main.npc[arm1].target = N.target;
            eyeRSpawned = true;
        }
        if (!eyeLSpawned)
        {
            int arm2 = NPC.NewNPC((int)NM.X, (int)NM.Y, "UltrOeyeL", N.whoAmI);
            Main.npc[arm2].ai[1] = N.whoAmI;
            Main.npc[arm2].target = N.target;
            eyeLSpawned = true;
        }*/
        npc.AI(true);
        if (!sword)
            NPC.NewNPC((int)NM.X, (int)NM.Y, "Ultrablivion's Sword", 0);
        sword = true;
        float
            spd = 12f,
            rot = (float)Math.Atan2(NM.Y - (T.position.Y + (T.height / 2f)), NM.X - (T.position.X + (T.width / 2f)));
        if (Main.rand.Next(40) == 0)
        {
            int type = Config.projDefs.byName["Dark Flames"].type;
            Projectile.NewProjectile(NM.X, NM.Y, (float)((Math.Cos(rot) * spd) * -1), (float)((Math.Sin(rot) * spd) * -1), type, 100, 0f, 0);
            Main.PlaySound(2, (int)N.position.X, (int)N.position.Y, 20);
        }
	if (Main.rand.Next(50) == 0)
        {
            Projectile.NewProjectile(NM.X, NM.Y, (float)((Math.Cos(rot) * spd) * -1), (float)((Math.Sin(rot) * spd) * -1), 100, 80, 0f, 0);
            Main.PlaySound(2, (int)N.position.X, (int)N.position.Y, 33);
        }
        if (Main.rand.Next(200) == 0)
            Projectile.NewProjectile(NM.X, NM.Y, 0.0001f, 0.0001f, Config.projDefs.byName["Explodey"].type, 1, 5f, 0);
        if (N.life < (int)(N.lifeMax / 2))
        {
            if (Main.rand.Next(30) == 0)
            {
                Projectile.NewProjectile(NM.X, NM.Y, (float)((Math.Cos(rot) * spd) * -1), (float)((Math.Sin(rot) * spd) * -1), 100, 90, 0f, 0);
                Main.PlaySound(2, (int)N.position.X, (int)N.position.Y, 33);
            }
            if (Main.rand.Next(1900) == 0)
            {
		Say("I bring my warriors upon you!");
                int jug = NPC.NewNPC((int)NM.X, (int)NM.Y, "Juggernaut", N.whoAmI);
                Main.npc[jug].ai[1] = N.whoAmI;
                Main.npc[jug].target = N.target;
            }
        }
        for (int i = 0; i < 3; i++)
            Dust.NewDust(N.position, N.width, N.height, 54, ((float)Main.rand.Next(-20, 21) / 10f), 1.6f, 100, default(Color), ((float)Main.rand.Next(10) / 10f) + 1f);
        N.netUpdate = true;
        N.ai[2]++;
        N.ai[1]++;
        if (N.target < 0 || N.target == 255 || T.dead || !T.active)
            N.TargetClosest(true);
        if (N.ai[2] < 600)
        {
            if (T.position.X < N.position.X)
                if (N.velocity.X > -8)
                    N.velocity.X -= 0.22f;
            if (T.position.X > N.position.X)
                if (N.velocity.X < 8)
                    N.velocity.X += 0.22f;
            if (T.position.Y < N.position.Y + 300)
            {
                if (N.velocity.Y > 0f)
                    N.velocity.Y -= 0.8f;
                else
                    N.velocity.Y -= 0.07f;
            }
            if (T.position.Y > N.position.Y + 300)
            {
                if (N.velocity.Y < 0f)
                    N.velocity.Y += 0.8f;
                else
                    N.velocity.Y += 0.07f;
            }
        }
        else if (N.ai[2] >= 600 && N.ai[2] < 1200)
        {
            N.velocity.X *= 0.98f;
            N.velocity.Y *= 0.98f;
            if ((N.velocity.X < 2f) && (N.velocity.X > -2f) && (N.velocity.Y < 2f) && (N.velocity.Y > -2f))
            {
                N.velocity.X = (float)(Math.Cos(rot) * 25) * -1;
                N.velocity.Y = (float)(Math.Sin(rot) * 25) * -1;
            }
        }
        else
            npc.ai[2] = 0;
        oldHalf = N.life < N.lifeMax / 2;
        if (T.dead)
        {
            N.velocity.Y -= 0.04f;
            if (N.timeLeft > 10)
            {
                N.timeLeft = 10;
                Say("Thanks for saving the Earth!");
                return;
            }
        }
    }
    public void DamagePlayer(Player P, ref int damage)
    {
        if (Main.rand.Next(5) == 1)
            P.AddBuff(31, 600);
    }
    public void NPCLoot()
    {
        NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, Config.npcDefs.byName["UODead"].type, 0);
	ModWorld.DeadUBReal();
    }
    public void Say(string txt)
    {
        string UO = "<Ultrablivion>: ";
        if (Main.netMode == 0)
            Main.NewText(UO + txt, 255, 100, 150);
        else if (Main.netMode == 2)
            NetMessage.SendData(25, -1, -1, UO + txt, 255, 255f, 100f, 150f, 0);
    }
//}