
public int boneCount = 30;


// Normalement Ok, a voir pour l'affichage
public int DecreaseCount(int stackCount) {
boneCount--;
return boneCount;
}


public void Initialize(){
this.item.toolTip3 = "Durability : "+boneCount+"/30";

}
public void Save(BinaryWriter writer) {
writer.Write(boneCount);
}

public void Load(BinaryReader reader, int version) {
boneCount = reader.ReadInt32();
this.item.toolTip3 = "Durability : "+boneCount+"/30";
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
stackCount = (int)stackCount/3;

for(int i=0; i<stackCount; i++){
    if(boneCount<30){
        boneCount++;
        consumed++;
this.item.toolTip3 = "Durability : "+boneCount+"/30";
    }else{
        return consumed*3;
    }
}
return consumed*6;

}




