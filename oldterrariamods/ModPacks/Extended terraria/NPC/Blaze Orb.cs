public void AI()
{
    if (npc.target == 255)
    {
        npc.TargetClosest(true);
        float num157 = 6f;
        num157 = 7f;
        Vector2 vector15 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
        float num158 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) - vector15.X;
        float num159 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - vector15.Y;
        float num160 = (float)Math.Sqrt((double)(num158 * num158 + num159 * num159));
        num160 = num157 / num160;
        npc.velocity.X = num158 * num160;
        npc.velocity.Y = num159 * num160;
    }
    npc.ai[0] += 1f;
    if (npc.ai[0] > 3f)
    {
        npc.ai[0] = 3f;
    }
    if (npc.ai[0] == 2f)
    {
        npc.position += npc.velocity;
        Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 20);
        for (int num161 = 0; num161 < 20; num161++)
        {
            int num162 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y + 2f), npc.width, npc.height, 6, 0f, 0f, 100, default(Color), 1.8f);
            Main.dust[num162].velocity *= 1.3f;
            Main.dust[num162].velocity += npc.velocity;
            Main.dust[num162].noGravity = true;
        }
    }
    if (Collision.SolidCollision(npc.position, npc.width, npc.height))
    {
        if (Main.netMode != 1)
        {
            int num163 = (int)(npc.position.X + (float)(npc.width / 2)) / 16;
            int num164 = (int)(npc.position.Y + (float)(npc.height / 2)) / 16;
            int num165 = 8;
            for (int num166 = num163 - num165; num166 <= num163 + num165; num166++)
            {
                for (int num167 = num164 - num165; num167 < num164 + num165; num167++)
                {
                    if ((double)(Math.Abs(num166 - num163) + Math.Abs(num167 - num164)) < (double)num165 * 0.5)
                    {
                        Tile T = Main.tile[num166, num167];
                        if (T.type == 57)
                        {
                            if (Main.rand.Next(3) == 0)
                            {
                                Main.tile[num166, num167].type = 58;
                            }
                            else
                            {
                                Main.tile[num166, num167].type = (ushort)Config.tileDefs.ID["Brimstone Block"];
                            }
                            WorldGen.SquareTileFrame(num166, num167, true);
                            if (Main.netMode == 2)
                            {
                                NetMessage.SendTileSquare(-1, num166, num167, 1);
                            }
                        }
                        else
                        {
                            if (T.type == 58)
                            {
                                if (Main.rand.Next(5) == 0 && ModWorld.superHardmode && Main.hardMode)
                                {
                                    Main.tile[num166, num167].type = (ushort)Config.tileDefs.ID["Magmatic Ore"];
                                }
                                WorldGen.SquareTileFrame(num166, num167, true);
                                if (Main.netMode == 2)
                                {
                                    NetMessage.SendTileSquare(-1, num166, num167, 1);
                                }
                            }
                            else
                            {
                                if (T.type == 56)
                                {
                                    if (Main.rand.Next(10) == 0)
                                    {
                                        Main.tile[num166, num167].type = 58;
                                    }
                                    WorldGen.SquareTileFrame(num166, num167, true);
                                    if (Main.netMode == 2)
                                    {
                                        NetMessage.SendTileSquare(-1, num166, num167, 1);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        npc.life = 0;
        npc.active = false;
        npc.NPCLoot();
    }
    if (npc.timeLeft > 100)
    {
        npc.timeLeft = 100;
    }
	for (int num168 = 0; num168 < 2; num168++)
    {
        int num171 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y + 2f), npc.width, npc.height, 6, npc.velocity.X * 0.1f, npc.velocity.Y * 0.1f, 80, default(Color), 1.3f);
        Main.dust[num171].velocity *= 0.3f;
        Main.dust[num171].noGravity = true;
    }
    npc.rotation += 0.4f * (float)npc.direction;
    return;
}