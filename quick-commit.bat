@echo off
set arg1=%1
git checkout src/LDJam46/Assets/Prefabs/Core.meta
git checkout src/LDJam46/Assets/Sprites/Environment/Mind/Objects.meta
git add .
git commit -m %arg1%
git pull
git push
