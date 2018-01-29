# LogViewer
## Install
First you install docker. Then install docker-compose. Don't forget about nc for windows! Then clone this.
## Docker

### ASampleApp
Build the image in ASampleApp: `docker build -t asampleapp .`. This will create an image named asampleapp. In order to connect to the container, execute `docker exec -it aspnet bash` (after you launch it via `docker-compose up`), then launch the application: `dotnet ASampleApp.dll`. Start generating entries in the log.
### Docker compose
Run `docker-compose up`. This will launch XXX containers: Elasticsearch, Logstash, Kibana, asampleapp (see docker-compose.yml):

 What | Where | How
 -----|-------|----
 Elasticsearch (input) | 5000 | TCP
 Elasticsearch (http) | 9200 | HTTP
 Logstash (input) | 5000 | TCP
 Kibana | 5601 | HTTP 
 asampleapp | x | x 

Then you have to feed elasticsearch via logstash: `echo "abc" | nc localhost 5000`. 

After that you can use kibana to define an index and see the data: http://localhost:5601.



### Still to do:
- [ ] complete the environment by launching other containers: web app, sql server?, some x server...
- [ ] install varius beats into these machines 
