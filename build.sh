#! /usr/bin/env bash
set -uvx
set -e
cwd=`pwd`
rm -rf obj bin *.exe
dotnet restore

msbuild.exe -restore -verbosity:quiet
msbuild.exe -t:Rebuild -p:Configuration=Release -verbosity:quiet
find ./bin/Release -name *.exe

#cd $cwd/bin/Release/net462
#ilmerge.exe -out:$cwd/mmp.exe -wildcards mmp.exe *.dll
cd $cwd/bin/Release
ilmerge.exe -out:$cwd/MyMediaPlayer.exe -wildcards MyMediaPlayer.exe *.dll

cd $cwd
ls -lh *.exe *.pdb
