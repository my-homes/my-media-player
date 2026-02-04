#! /usr/bin/env bash
set -uvx
set -e
cwd=`pwd`

rm -rf obj bin *.exe

#dotnet restore

msbuild.exe -restore -verbosity:quiet mmp.csproj
msbuild.exe -t:Rebuild -p:Configuration=Release -verbosity:quiet mmp.csproj
find ./bin/Release -name *.exe

cd $cwd/bin/Release/net462
ilmerge.exe -out:$cwd/mmp.exe -wildcards mmp.exe *.dll

cd $cwd
ls -lh *.exe *.pdb
