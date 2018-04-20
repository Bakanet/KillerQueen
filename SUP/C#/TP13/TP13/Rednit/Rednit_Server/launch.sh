if [ "$#" -ne 0 -a "$1" == '-b' ]; then
  msbuild
fi
bin="$(find . -name Rednit_Server.exe)"
if [ "$?" -ne 0 -o "$bin" = "" ]; then
  echo -e "\e[91mThe executable could not be found"
  exit
fi
echo $bin
mono $bin
