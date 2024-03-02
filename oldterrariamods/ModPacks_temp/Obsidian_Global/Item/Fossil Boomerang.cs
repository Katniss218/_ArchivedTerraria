
public int boneCount = 35;


// Normalement Ok, a voir pour l'affichage
public int DecreaseCount(int stackCount) {
boneCount--;
return boneCount;
}


public void Initialize(){
this.item.toolTip3 = "Durability : "+boneCount+"/35";

}
public void Save(BinaryWriter writer) {
writer.Write(boneCount);
}

public void Load(BinaryReader reader, int version) {
boneCount = reader.ReadInt32();
this.item.toolTip3 = "Durability : "+boneCount+"/35";
}


// Normalement Ok, a voir pour l'affichage
public int Repair(int stackCount) {
int consumed = 0;
stackCount = (int)stackCount/3;

for(int i=0; i<stackCount; i++){
    if(boneCount<35){
        boneCount++;
        consumed++;
this.item.toolTip3 = "Durability : "+boneCount+"/35";
    }else{
        return consumed*3;
    }
}
return consumed*6;

}





public bool CanUse(Player player, int pID) {
	bool use=true;

    if(boneCount < 1){
        use =  false;
    }

	//This code is used by boomerangs to limit the amount of boomerang projectiles that can be thrown.
	for (int m = 0; m < 1000; m++)
	{
		if (Main.projectile[m].active && Main.projectile[m].owner == Main.myPlayer && Main.projectile[m].type == this.item.shoot)
		{
            
			use = false;
			break;
		}
	}
	return use;
}