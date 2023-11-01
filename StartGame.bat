@echo off

set /A servercount=%1
set /A clientcount=%2

::set /p servercount="Server Count: "
::set /p clientcount="Client Count: "

echo -StartAs 0 > "D:\Unity\Projects\Builds\MultiplayerGame\MultiplayerGame_Data\StreamingAssets\CommandLine.txt"
FOR /L %%x IN (1, 1, %servercount%) DO Start "" "D:\Unity\Projects\Builds\MultiplayerGame\MultiplayerGame.exe"

timeout /t 2

echo -StartAs 1 > "D:\Unity\Projects\Builds\MultiplayerGame\MultiplayerGame_Data\StreamingAssets\CommandLine.txt"
FOR /L %%x IN (1, 1, %clientcount%) DO Start "" "D:\Unity\Projects\Builds\MultiplayerGame\MultiplayerGame.exe"
