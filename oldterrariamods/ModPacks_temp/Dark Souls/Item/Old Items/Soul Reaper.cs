public void Effects(Player P)
{
Vector2 PC = P.position+new Vector2(P.width/2,P.height/2);
foreach(Item I in Main.item)
{
if(!I.active || I.type != Config.itemDefs.byName["Dark Soul"].type)
continue;
Vector2 IC = I.position+new Vector2((I.width*I.scale)/2,(I.height*I.scale)/2);
float Dist = Vector2.Distance(PC,IC);
if(Dist < 300f) //insert some different range check here
{
I.velocity = Vector2.Lerp(IC,PC,.05f)-IC; //increasing the float number thingy would supposably increase the draw speed , and the draw speed is scaled by the distance , so that the closer the slower it moves , making an ambient speed.
}
}
}