bool ActUp = false;
bool immunething = false;

public void Effects(Player P)
{
	immunething = true;
}

public void DamagePlayer(Player P,ref int DMG,NPC N)
{
    if (immunething)
    {
    if(P.immune) return;
    int NT = N.type;
    if(NT == 42 || NT == Config.npcDefs.byName["Queen Hornet"].type)
    {
          ActUp = true;
          P.immune = true;
	  P.immuneAlpha = 0;
    }
    }
}
public void DealtPlayer(Player P,double DMG,NPC N)
{
	if(ActUp && immunething)
	{
		P.immune = false;
		ActUp = false;
	}
}