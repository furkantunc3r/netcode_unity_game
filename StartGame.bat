@echo off

set /A servercount=%1
set /A clientcount=%2

echo -StartAs 0 > "D:\Unity\Projects\Builds\MultiplayerGame\MultiplayerGameBootcampLesson_Data\StreamingAssets\CommandLine.txt"
FOR /L %%x IN (1, 1, %servercount%) DO Start "" "D:\Unity\Projects\Builds\MultiplayerGame\MultiplayerGameBootcampLesson.exe"

timeout /t 1

echo -StartAs 1 > "D:\Unity\Projects\Builds\MultiplayerGame\MultiplayerGameBootcampLesson_Data\StreamingAssets\CommandLine.txt"
FOR /L %%x IN (1, 1, %clientcount%) DO Start "" "D:\Unity\Projects\Builds\MultiplayerGame\MultiplayerGameBootcampLesson.exe"
