using System.Numerics;
using Raylib_cs;

const int screenFactor = 80;
const int screenWidth = 16 * screenFactor;
const int screenHeight = 9 * screenFactor;
const int branchLength = 100;
const float branchThickness = 5;
const int countPieces = 5;
const int levels = 5;

Raylib.InitWindow(screenWidth, screenHeight, "Snowflake");
Random rnd = new Random();
Raylib.BeginDrawing();
Raylib.ClearBackground(new Color(38, 38, 38, 255));
var center = new Vector2((float)(screenWidth * 0.5), (float)(screenHeight * 0.5));
DrawSnowflake(center, branchLength, branchThickness, Color.Red, levels);
Raylib.EndDrawing();

while (!Raylib.WindowShouldClose())
{
    
}

void DrawSnowflake(Vector2 newCenter, double branchLen, float thickness, Color color, int level)
{
    if (level == 0) { return; }
    var newColor = Raylib.ColorFromHSV(rnd.Next(0, 361), rnd.Next(0, 101), 100);
    for (var i = 1; i <= countPieces; i++)
    {
        var angle = (2 * Math.PI / countPieces) * i;
        var endPosition = new Vector2(newCenter.X + (float)(Math.Cos(angle) * branchLen), newCenter.Y + (float)(Math.Sin(angle) * branchLen));
        Raylib.DrawLineEx(newCenter, endPosition, thickness, color);
        DrawSnowflake(endPosition, branchLen * 0.5, (float)(thickness * 0.5), newColor,level - 1);
    }
}
