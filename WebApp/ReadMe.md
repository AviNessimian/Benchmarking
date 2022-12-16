docker build -t loggertest1 -f ./Dockerfile .

# docker run -d -p 5058:80 --memory="2g" --memory-swap="2g"  -c 512 loggertest1 --cpu 1

docker run -d -p 5058:80 loggertest1