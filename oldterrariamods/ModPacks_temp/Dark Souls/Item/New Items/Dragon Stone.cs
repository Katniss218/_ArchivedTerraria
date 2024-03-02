bool ActUp = false;
public void DamagePlayer(Player P,ref int DMG,NPC N)
{
    if(P.immune) return;
    int NT = N.type;
    if(NT == 2 || NT == 6 || NT == 34 || NT == 42 || NT == 48 || NT == 49 || NT == 51 || NT == 60 || NT == 61 || NT == 62 || NT == 66 || NT == 75 || NT == 87 || NT == 88 || NT == 89 || NT == 90 || NT == 91 ||  NT == 92 || NT == 93 || NT == 94 || NT == 112 || NT == 122 || NT == 133 || NT == 137 )
    {
          ActUp = true;
          P.immune = true;
	  P.immuneAlpha = 0;
    }
}

public void DealtPlayer(Player P,double DMG,NPC N)
{
	if(ActUp)
	{
		P.immune = false;
		ActUp = false;
	}
	
}

// NT == Config.npcDefs.byName["Wyvern"].type || NT == Config.npcDefs.byName["Vampire Bat"].type || NT == Config.npcDefs.byName["SnowOwl"].type || NT == Config.npcDefs.byName["Cloud Bat"].type

public static void Effects(Player player) 
{
        player.fireWalk=true;
        player.noKnockback = true;
        player.blind = false;
}