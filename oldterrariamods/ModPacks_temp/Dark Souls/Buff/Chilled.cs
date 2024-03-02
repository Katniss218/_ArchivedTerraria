int tickCount = 0;
public void ModifyPlayerDrawColors(Player P,ref bool OF,ref float r,ref float g,ref float b,ref float a)
{
    r*=(float)(149/255);
    g*=(float)(269/255);
    b*=(float)(390/255);
}
public void Effects(Player player) 
{
    player.moveSpeed *= 0.8f;
    player.velocity.X *= 0.9f;
    player.jump = (int)(player.jump*0.5);
    player.meleeSpeed *= 0.5f;
    player.statDefense -= 20;
	if(tickCount == 0){
		tickCount = 12;
		int dust = Dust.NewDust(player.position, player.width, player.height, 43, 0, 0, 0, default(Color), 0.8f);
		Main.dust[dust].noGravity = true;
		Main.dust[dust].velocity *= new Vector2(0.1f,0.1f);
	}else{
		tickCount--;
	}
}
/*
bool initial=true;
int npcDef=0;
public void NPCEffects(NPC npc,int buffIndex,int buffType,int buffTime) 
{
	if(initial){
		initial=false;
		npcDef=npc.defense;
	}
	
	npc.velocity.X *= 0.8f;
	if(npc.velocity.Y<0){ //npc travelling up
		npc.velocity.Y *= 0.92f;
	}
	npc.defense = npcDef - 20;
	Color colour=new Color(0, 149, 269, 390);
	npc.color = colour;
	
	if(tickCount == 0){
		tickCount = 12;
		int dust = Dust.NewDust(npc.position, npc.width, npc.height, 43, 0, 0, 0, default(Color), 0.8f);
		Main.dust[dust].noGravity = true;
		Main.dust[dust].velocity *= new Vector2(0.1f,0.1f);
	}else{
		tickCount--;
	}
	
	if(buffTime <= 1){
		NetMessage.SendData(25, -1, -1, "Net remove custom buff : "+buffType, 255, 50f, 255f, 130f, 0);//debug

		npc.color = default(Color);
		npc.defense = npcDef;
	}
}
*/