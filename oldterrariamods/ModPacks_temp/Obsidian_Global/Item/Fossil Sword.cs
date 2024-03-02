public int boneCount = 40;

public void DamageNPC(Player myPlayer,NPC npc, ref int damage, ref float knockback){
boneCount --;
this.item.toolTip3  = "Durability : "+boneCount+"/40";
}

public void Initialize(){
this.item.toolTip3  = "Durability : "+boneCount+"/40";

}


public void UseItem(Player player, int playerID) {

}

public void Save(BinaryWriter writer) {
writer.Write(boneCount);
}

public void Load(BinaryReader reader, int version) {
boneCount = reader.ReadInt32();
this.item.toolTip3 = "Durability : "+boneCount+"/40";
}


public bool CanUse(Player player, int playerID){
if(boneCount < 1){
return false;
}
return true;
}

// Normalement Ok, a voir pour l'affichage
public int Repair(int stackCount) {
int consumed = 0;
stackCount = (int)stackCount/2;

for(int i=0; i<stackCount; i++){
    if(boneCount<40){
        boneCount++;
        consumed++;
this.item.toolTip3 = "Durability : "+boneCount+"/40";
    }else{
        return consumed*2;
    }
}
return consumed*2;

}

