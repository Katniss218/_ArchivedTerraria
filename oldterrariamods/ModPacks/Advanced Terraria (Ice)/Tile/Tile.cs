public void ModifyWorld() {
        Main.statusText = "Adding ColdStone ...";
        for(int i=0;i<3+(int)(Main.maxTilesY/12);i++) AddOres();
        Main.statusText = "Counting ores...";
        string data="";
        DictionaryHandler<int, int> countType = new DictionaryHandler<int,int>();
        for(int x=0;x<Main.maxTilesX;x++) {
                for(int y=0;y<Main.maxTilesY;y++) {
                        Main.statusText = "Counting ores... ("+((x*(y+1))/(Main.maxTilesX*Main.maxTilesY))+"%)";
                        try {
                                int type=Main.tile[x,y].type;
                                if(type==7 || type==8 || type==9 || type==Config.tileDefs.ID["CStone"]) countType[type]++; 
                        } catch {
                        }

                }
        }
        data+="Copper: "+countType[7]+"\n";
        data+="Silver: "+countType[9]+"\n";
        data+="Gold: "+countType[8]+"\n";
        data+="Greenium: "+countType[Config.tileDefs.ID["CStone"]]+"\n";
        data+="Greenium added for world size: "+(int)(Main.maxTilesY/5)+"\n";
        File.WriteAllText(Main.SavePath+@"\"+"Ores.txt", data);
}
public void AddOres()
{
	int i2 = WorldGen.genRand.Next(100, Main.maxTilesX - 100);
	double num6;
	num6 = Main.rockLayer;
	int j2 = WorldGen.genRand.Next((int)num6, Main.maxTilesY - 150);
	WorldGen.OreRunner(i2, j2, (double)WorldGen.genRand.Next(4, 7), WorldGen.genRand.Next(4, 6), Config.tileDefs.ID["CStone"]);
}