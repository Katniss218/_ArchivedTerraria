

public void DamageNPC(Player myPlayer,NPC npc, ref int damage, ref float knockback){
if(Main.rand.Next(10)==0){
myPlayer.HealEffect(damage); 
myPlayer.statLife+=damage;
}

if (npc.name=="Eater of Worlds Head") damage *= 4;
else if (npc.name=="Eater of Worlds Body") damage *= 4;
else if (npc.name=="Eater of Worlds Tail") damage *= 4;
    else if (npc.name=="Eater of Souls") damage *= 2;
	else if (npc.name=="Big Eater") damage *= 2;
	else if (npc.name=="Little Eater") damage *= 3;
}


