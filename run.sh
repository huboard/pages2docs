if [ "$1" == "docker" ]
then
    docker run -t -p 5000:5000 --env-file ./.env pages2docs
else
  source .env
  cd ./build/
  mono pages2docs.exe
fi
