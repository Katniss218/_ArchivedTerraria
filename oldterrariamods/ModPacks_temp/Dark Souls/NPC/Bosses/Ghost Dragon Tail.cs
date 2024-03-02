public void AI(){
if (!Main.npc[(int)npc.ai[1]].active)
{
	npc.life = 0;
	npc.HitEffect(0, 10.0);
	npc.active = false;
}
if (npc.position.X > Main.npc[(int)npc.ai[1]].position.X)
{
	npc.spriteDirection = 1;
}
if (npc.position.X < Main.npc[(int)npc.ai[1]].position.X)
{
	npc.spriteDirection = -1;
}
//Color color = new Color();
//int dust = Dust.NewDust(new Vector2((float) npc.position.X, (float) npc.position.Y+10), npc.width, npc.height, 6, 0, 0, 100, //color, 1.0f);
//Main.dust[dust].noGravity = true;

npc.AI(true);
}





