public void ModifyWorld() {
        Main.statusText = "Adding Unobtanium Ore..."; //set to your ore
        for(int i=0;i<20+(int)(Main.maxTilesY/5);i++) AddOres(); //change the 100 to suit your needs, higher is less rare.
        //Count ores, for comparison purposes...
        //Gold ore=8
        //Silver ore=9
        //Copper ore=7
        Main.statusText = "Counting ores...";
        string data="";
        DictionaryHandler<int, int> countType = new DictionaryHandler<int,int>();
        for(int x=0;x<Main.maxTilesX;x++) {
                for(int y=0;y<Main.maxTilesY;y++) {
                        Main.statusText = "Counting ores... ("+((x*(y+1))/(Main.maxTilesX*Main.maxTilesY))+"%)";
                        try {
                                int type=Main.tile[x,y].type;
                                if(type==7 || type==8 || type==9 || type==Config.tileDefs.ID["Unobtanium Ore"]) countType[type]++; //Change the 'Placeable' to the name of your ore's tile(mine happened to be called Placeable.
                        } catch {
                        }
 
                }
        }
        data+="Copper: "+countType[7]+"\n";
        data+="Silver: "+countType[9]+"\n";
        data+="Gold: "+countType[8]+"\n";
        data+="Unobtanium: "+countType[Config.tileDefs.ID["Unobtanium Ore"]]+"\n"; //same as last, change placeable.
        data+="Unobtanium added for world size: "+(int)(Main.maxTilesY/5)+"\n";
        File.WriteAllText(Main.SavePath+@"\"+"Ores.txt", data);
}
public void AddOres() {
    int add = 0;
    //float num3 = (float)(Main.maxTilesX / 4200);
    int i2 = WorldGen.genRand.Next(100, Main.maxTilesX - 100);
    double num6 = Main.worldSurface;
    int j2 = WorldGen.genRand.Next((int)num6, Main.maxTilesY - 50);
    WorldGen.OreRunner(i2, j2, (double)WorldGen.genRand.Next(5, 9 + add), WorldGen.genRand.Next(5, 9 + add), Config.tileDefs.ID["Unobtanium Ore"]); //change yet again.
}
